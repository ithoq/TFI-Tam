Imports DAL
Imports EE
Public Class PedidoMapper

    Private vDatos As Datos

    Sub New()
        Me.vDatos = New Datos
    End Sub

    Public Function Crear(ByVal entidad As Pedido) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Estado", entidad.Estado)
        parametros.Add("@Fecha_Inicio", entidad.FechaInicio)
        parametros.Add("@Importe", entidad.Importe)
        parametros.Add("@Usuario_Id", entidad.Usuario.Id)
        parametros.Add("@Direccion_Calle", entidad.Direccion.Calle)
        parametros.Add("@Direccion_Numero", entidad.Direccion.Numero)
        parametros.Add("@Direccion_Dpto_Piso", entidad.Direccion.DptoPiso)
        parametros.Add("@Direccion_Localidad", entidad.Direccion.Localidad)

        Dim dt As New DataTable()
        dt.Columns.Add("Producto_Id", System.Type.GetType("System.Int32"))
        dt.Columns.Add("Precio", System.Type.GetType("System.Decimal"))
        dt.Columns.Add("Cantidad", System.Type.GetType("System.Int32"))
        For Each dp As DetallePedido In entidad.ListaPedidos
            Dim dr As DataRow = dt.NewRow
            dr.Item("Producto_Id") = dp.Producto.Id
            dr.Item("Precio") = dp.Precio
            dr.Item("Cantidad") = dp.Cantidad
            dt.Rows.Add(dr)
        Next
        parametros.Add("@Detalles", dt)

        Return vDatos.Escribir("s_AltaPedido", parametros)
    End Function

    Public Function Listar() As List(Of Pedido)
        Dim ds As New DataSet
        Dim lista As New List(Of Pedido)
        ds = vDatos.Leer("s_ListarPedido", Nothing)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                Dim p As Pedido = New Pedido
                p.Id = Item("Id")
                p.FechaInicio = Item("FechaInicio")
                If IsDBNull(Item("FechaFin")) = False Then
                    p.FechaFin = Item("FechaFin")
                End If
                p.Importe = Item("Importe")
                p.Estado = Item("Estado")
                p.Usuario.NombreUsuario = Item("NombreUsuario")
                lista.Add(p)
            Next
        End If

        Return lista
    End Function

    Public Function ConsutarPorId(ByVal id As Integer) As Pedido
        Dim parametros As New Hashtable
        Dim ds As New DataSet

        parametros.Add("@Id", id)
        ds = vDatos.Leer("s_ConsultarPorIdPedido", parametros)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim row As DataRow = ds.Tables(0).Rows(0)
            Dim p As New Pedido
            p.Id = row.Item("Id")
            p.FechaInicio = row.Item("FechaInicio")
            If IsDBNull(row.Item("FechaFin")) = False Then
                p.FechaFin = row.Item("FechaFin")
            End If
            p.Importe = row.Item("Importe")
            p.Estado = row.Item("Estado")
            p.Direccion.Calle = row.Item("Calle")
            p.Direccion.Numero = row.Item("Numero")
            p.Direccion.DptoPiso = row.Item("DepartamentoPiso")
            p.Direccion.Localidad = row.Item("Localidad")
            p.Usuario.Nombre = row.Item("Nombre")
            p.Usuario.Apellido = row.Item("Apellido")
            p.Usuario.NombreUsuario = row.Item("NombreUsuario")
            p.Usuario.Telefono = row.Item("Telefono")
            Dim lista As New List(Of DetallePedido)
            If ds.Tables(1).Rows.Count > 0 Then
                For Each row2 As DataRow In ds.Tables(1).Rows
                    Dim dp As New DetallePedido
                    dp.Cantidad = row2.Item("Cantidad")
                    dp.Precio = row2.Item("Precio")
                    dp.Producto.Nombre = row2.Item("Nombre")
                    lista.Add(dp)
                Next
                p.ListaPedidos = lista
            End If
            Return p
        Else
            Return Nothing
        End If
    End Function


End Class
