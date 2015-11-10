Imports EE
Imports BLL
Public Class PedidoController
    Inherits BaseController

    Private vProductoBLL As ProductoBLL

    Sub New()
        Me.vProductoBLL = New ProductoBLL
    End Sub
    '
    ' GET: /Pedido

    Function Index() As ActionResult
        Return View()
    End Function

    Function Agregar(ByVal form As FormCollection) As ActionResult
        Dim detalle As New DetallePedido
        Dim prod As Producto = Me.vProductoBLL.ConsutarPorId(form.Item("Producto_Id"))
        detalle.Cantidad = form.Item("Cantidad")
        detalle.Precio = prod.ObtenerPrecio()
        detalle.Producto = prod
        Me.ObtenerCarrito.Importe += detalle.Total
        Me.ObtenerCarrito().ListaPedidos.Add(detalle)
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

End Class