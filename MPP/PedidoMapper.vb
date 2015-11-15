Imports DAL
Imports EE
Public Class PedidoMapper

    Private vDatos As Datos

    Sub New()
        Me.vDatos = New Datos
    End Sub

    Public Function Listar() As List(Of Pedido)
        Dim ds As New DataSet
        Dim lista As New List(Of Pedido)
        ds = vDatos.Leer("s_ListarPedido", Nothing)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                Dim p As Pedido = New Pedido
                p.Id = Item("Id")
                p.FechaInicio = Item("FechaInicio")
                p.FechaFin = Item("FechaFin")
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
            p.FechaFin = row.Item("FechaFin")
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
