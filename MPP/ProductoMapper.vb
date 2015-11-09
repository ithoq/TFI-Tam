Imports DAL
Imports EE

Public Class ProductoMapper
    Private vDatos As Datos

    Sub New()
        Me.vDatos = New Datos
    End Sub

    Public Function Crear(ByVal entidad As Producto) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Fondo", entidad.Fondo)
        parametros.Add("@Nombre", entidad.Nombre)
        parametros.Add("@Alto", entidad.Alto)
        parametros.Add("@Ancho", entidad.Ancho)
        parametros.Add("@Papel_Id", entidad.Papel.Id)
        parametros.Add("@TipoProducto_Id", Convert.ToInt16(entidad.TipoProducto))
        parametros.Add("@Tema_Id", Convert.ToInt16(entidad.Tema))
        parametros.Add("@Cartucho_Id", entidad.Cartucho.Id)

        Return vDatos.Escribir("s_AltaProducto", parametros)
    End Function

    Public Function Editar(ByVal entidad As Producto) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", entidad.Id)
        If entidad.Fondo IsNot Nothing And entidad.Fondo <> "" Then
            parametros.Add("@Fondo", entidad.Fondo)
            parametros.Add("@Alto", entidad.Alto)
            parametros.Add("@Ancho", entidad.Ancho)
        End If
        parametros.Add("@Nombre", entidad.Nombre)
        parametros.Add("@Papel_Id", entidad.Papel.Id)
        parametros.Add("@TipoProducto_Id", Convert.ToInt16(entidad.TipoProducto))
        parametros.Add("@Tema_Id", Convert.ToInt16(entidad.Tema))
        parametros.Add("@Cartucho_Id", entidad.Cartucho.Id)

        Return vDatos.Escribir("s_ModificacionProducto", parametros)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", id)

        Return vDatos.Escribir("s_BajaProducto", parametros)
    End Function

    Public Function Listar() As List(Of Producto)
        Dim ds As New DataSet
        Dim lista As New List(Of Producto)
        ds = vDatos.Leer("s_ListarProducto", Nothing)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                Dim p As Producto = New Producto
                p.Id = Item("Id")
                p.Fondo = Item("Fondo")
                p.Alto = Item("Alto")
                p.Ancho = Item("Ancho")
                p.Nombre = Item("Nombre")
                p.TipoProducto = Item("TipoProducto_Id")
                p.Tema = Item("Tema_Id")
                p.Papel.Id = Item("IdPapel")
                p.Papel.Nombre = Item("NombrePapel")
                p.Papel.Precio = Item("PrecioPapel")
                p.Papel.Tipo = Item("TipoPapel")
                p.Papel.Color = Item("ColorPapel")
                p.Papel.Espesor = Item("EspesorPapel")
                p.Cartucho.Id = Item("IdCartucho")
                p.Cartucho.Nombre = Item("NombreCartucho")
                p.Cartucho.Precio = Item("PrecioCartucho")
                p.Cartucho.Tipo = Item("TipoCartucho")
                lista.Add(p)
            Next
        End If

        Return lista
    End Function

    Public Function ConsutarPorId(ByVal id As Integer) As Producto
        Dim parametros As New Hashtable
        Dim ds As New DataSet

        parametros.Add("@Id", id)
        ds = vDatos.Leer("s_ConsultarPorIdProducto", parametros)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim row As DataRow = ds.Tables(0).Rows(0)
            Dim p As New Producto
            p.Id = row.Item("Id")
            p.Fondo = row.Item("Fondo")
            p.Alto = row.Item("Alto")
            p.Ancho = row.Item("Ancho")
            p.Nombre = row.Item("Nombre")
            p.TipoProducto = row.Item("TipoProducto_Id")
            p.Tema = row.Item("Tema_Id")
            p.Papel.Id = row.Item("IdPapel")
            p.Papel.Nombre = row.Item("NombrePapel")
            p.Papel.Precio = row.Item("PrecioPapel")
            p.Papel.Tipo = row.Item("TipoPapel")
            p.Papel.Color = row.Item("ColorPapel")
            p.Papel.Espesor = row.Item("EspesorPapel")
            p.Cartucho.Id = row.Item("IdCartucho")
            p.Cartucho.Nombre = row.Item("NombreCartucho")
            p.Cartucho.Precio = row.Item("PrecioCartucho")
            p.Cartucho.Tipo = row.Item("TipoCartucho")
            Return p
        Else
            Return Nothing
        End If
    End Function

End Class
