Imports EE
Imports BLL
Public Class PedidoController
    Inherits BaseController

    Private vProductoBLL As ProductoBLL
    Private vBLL As PedidoBLL
    Private vMovimientoBLL As MovimientoBLL
    Private vUsuarioBLL As UsuarioBLL
    Private vOrdenProduccionBLL As OrdenProduccionBLL

    Sub New()
        Me.vProductoBLL = New ProductoBLL()
        Me.vBLL = New PedidoBLL()
        Me.vMovimientoBLL = New MovimientoBLL()
        Me.vUsuarioBLL = New UsuarioBLL()
        Me.vOrdenProduccionBLL = New OrdenProduccionBLL()
    End Sub
    '
    ' GET: /Pedido
    <Autorizar(Roles:="VerPedidos")>
    Function Index() As ActionResult
        Dim vLista As List(Of Pedido) = Me.vBLL.Listar()
        Return View(vLista)
    End Function

    <Autorizar(Roles:="ConsultarPedido")>
    Function Detalles(ByVal id As Integer) As ActionResult
        Dim vPedido As Pedido = Me.vBLL.ConsutarPorId(id)
        Return View(vPedido)
    End Function

    <Autorizar(Roles:="AnularPedido")>
    Function Anular(ByVal id As Integer) As ActionResult
        Me.vBLL.Anular(id)
        Return RedirectToAction("Detalles", New With {.id = id})
    End Function

    <Autorizar()>
    Function Comprar() As ActionResult
        Dim model As New ComprarViewModel
        model.Pedido = Me.ObtenerCarrito()
        model.SaldoAFavor = Me.vMovimientoBLL.SaldoAFavorPorCliente(Me.UsuarioActual.UsuarioId)
        model.TarjetaImporte = Me.ObtenerCarrito().Importe
        Return View(model)
    End Function

    <Autorizar()>
    <HttpPost()>
    Function Comprar(ByVal model As ComprarViewModel) As ActionResult
        If model.ClienteCondicion IsNot Nothing Then
            If model.ClienteCondicion <> "Responsable Inscripto" Then
                ModelState.Item("ClienteCuit").Errors.Clear()
            End If
        End If
        model.SaldoAFavor = Me.vMovimientoBLL.SaldoAFavorPorCliente(Me.UsuarioActual.UsuarioId)
        If model.PagoConNC Then
            If Me.ObtenerCarrito().Importe <= model.SaldoAFavor Then
                ModelState.Item("TarjetaTitular").Errors.Clear()
                ModelState.Item("TarjetaNombre").Errors.Clear()
                ModelState.Item("TarjetaCuotas").Errors.Clear()
                ModelState.Item("TarjetaNumero").Errors.Clear()
                ModelState.Item("TarjetaCodigoSeguridad").Errors.Clear()
                ModelState.Item("TarjetaFechaVencimiento").Errors.Clear()
            End If
        End If
        If ModelState.IsValid Then

            Dim direccionEnvio As New Direccion
            direccionEnvio.Calle = model.DireccionCalle
            direccionEnvio.Numero = model.DireccionNumero
            direccionEnvio.DptoPiso = model.DireccionDptoPiso
            direccionEnvio.Localidad = model.DireccionLocalidad

            'Se actualiza el usuario
            Dim usuarioLogeado As New Usuario
            usuarioLogeado = Me.vUsuarioBLL.ConsultarPorId(Me.UsuarioActual.UsuarioId)
            usuarioLogeado.Telefono = model.ClienteTelefono
            Me.vUsuarioBLL.Editar(usuarioLogeado)

            'Se crea el pedido
            Dim nuevoPedido As Pedido = Me.ObtenerCarrito
            nuevoPedido.Direccion = direccionEnvio
            nuevoPedido.Usuario = usuarioLogeado
            nuevoPedido.Estado = "Pendiente"
            nuevoPedido.FechaInicio = Now
            Dim listaMovimientoDetalles As New List(Of DetalleMovimiento)
            For Each dp As DetallePedido In nuevoPedido.ListaPedidos
                Dim nuevoDetalle As New DetalleMovimiento
                nuevoDetalle.Cantidad = dp.Cantidad
                nuevoDetalle.Precio = dp.Precio
                nuevoDetalle.Producto = dp.Producto
                listaMovimientoDetalles.Add(nuevoDetalle)
            Next
            Me.vBLL.Crear(nuevoPedido)

            'Se crean las ordenes de fabricación
            For Each dp As DetallePedido In nuevoPedido.ListaPedidos
                For Each o As OrdenProduccion In dp.Producto.CrearOrdenesProduccion(dp.Cantidad)
                    Me.vOrdenProduccionBLL.Crear(o)
                Next
            Next

            'Se crea la factura
            Dim nuevaFactura As New Factura
            If model.ClienteCondicion = "Responsable Inscripto" Then
                nuevaFactura.TipoComprobante = "A"
            Else
                nuevaFactura.TipoComprobante = "B"
            End If
            nuevaFactura.Usuario = usuarioLogeado
            nuevaFactura.Importe = nuevoPedido.Importe
            nuevaFactura.Fecha = Now.Date
            nuevaFactura.Cuit = model.ClienteCuit
            nuevaFactura.Direccion = direccionEnvio
            nuevaFactura.ListaDetalles = listaMovimientoDetalles
            Me.vMovimientoBLL.Crear(nuevaFactura)

            'Se crea el pago
            Dim importeTarjeta As Double = nuevoPedido.Importe
            If model.PagoConNC Then
                If model.SaldoAFavor >= importeTarjeta Then
                    importeTarjeta = 0
                Else
                    importeTarjeta -= model.SaldoAFavor
                End If
            End If
            If importeTarjeta > 0 Then
                Dim nuevoPago As New Pago
                nuevoPago.Usuario = usuarioLogeado
                nuevoPago.Importe = importeTarjeta
                nuevoPago.TipoComprobante = model.TarjetaNombre
                nuevoPago.Fecha = Now.Date
                Me.vMovimientoBLL.Crear(nuevoPago)
            End If

            'Se compensa las notas de credito con la factura dada de alta anteriormente
            If model.PagoConNC Then
                Me.vMovimientoBLL.Compensar(usuarioLogeado.Id, nuevoPedido.Importe - importeTarjeta)
            End If

            'Se elimina el carrito de compra
            Me.EliminarCarro()

            Return RedirectToAction("Exito", "Pedido")
        End If
        model.Pedido = Me.ObtenerCarrito()
        Return View(model)
    End Function

    Function Exito() As ActionResult
        Return View()
    End Function

    Function Agregar(ByVal form As FormCollection) As ActionResult
        Dim detalle As New DetallePedido
        If Integer.TryParse(form.Item("Cantidad"), detalle.Cantidad) = False Then
            TempData("error") = "Debe ingresar un número entero en la cantidad"
            Return RedirectToAction("Agregar", "Producto", New With {.id = form.Item("Producto_Id")})
        End If
        Dim prod As Producto = Me.vProductoBLL.ConsutarPorId(form.Item("Producto_Id"))
        detalle.Cantidad = form.Item("Cantidad")
        detalle.Precio = prod.ObtenerPrecioConIva()
        detalle.Producto = prod
        Me.ObtenerCarrito.Importe += detalle.Total
        Me.AgregarDetalle(detalle)
        Return RedirectToAction("Index", "Home")
    End Function

    Function Quitar(ByVal id As Integer) As ActionResult
        Dim p As Pedido = Me.ObtenerCarrito()
        If p IsNot Nothing Then
            For i = 0 To p.ListaPedidos.Count - 1
                Dim dp As DetallePedido = p.ListaPedidos(i)
                If dp.Producto.Id = id Then
                    p.ListaPedidos.RemoveAt(i)
                    p.Importe -= dp.Total
                    Exit for
                End If
            Next
        End If

        Return RedirectToAction("VerCarro")
    End Function

    Function AgregarDetalle(ByVal pd As DetallePedido) As ActionResult
        Dim p As Pedido = Me.ObtenerCarrito()
        Dim Encontro As Boolean = False
        If p IsNot Nothing Then
            For i = 0 To p.ListaPedidos.Count - 1
                Dim item As DetallePedido = p.ListaPedidos(i)
                If pd.Producto.Id = item.Producto.Id Then
                    item.Cantidad += pd.Cantidad
                    Encontro = True
                    Exit For
                End If
            Next
        End If
        If Encontro = False Then
            p.ListaPedidos.Add(pd)
        End If
        Return RedirectToAction("VerCarro")
    End Function

    Function VerCarro() As ActionResult
        Return View(Me.ObtenerCarrito())
    End Function

    Private Function ObtenerCarrito() As Pedido
        Dim sesionCarro = System.Web.HttpContext.Current.Session("Carrito")
        If sesionCarro IsNot Nothing Then
            Return DirectCast(sesionCarro, Pedido)
        Else
            Dim p As New Pedido
            p.FechaInicio = Now.Date
            p.Estado = "Pendiente"
            p.Importe = 0
            System.Web.HttpContext.Current.Session("Carrito") = p
            Return p
        End If
    End Function

    Private Sub EliminarCarro()
        System.Web.HttpContext.Current.Session("Carrito") = Nothing
    End Sub

End Class