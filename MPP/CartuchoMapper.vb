Imports DAL
Imports EE
Public Class CartuchoMapper

    Private vDatos As Datos

    Sub New()
        Me.vDatos = New Datos
    End Sub

    Public Function Crear(ByVal entidad As Cartucho) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Modelo", entidad.Modelo)
        parametros.Add("@Marca", entidad.Marca)
        parametros.Add("@Nombre", entidad.Nombre)
        parametros.Add("@Precio", entidad.Precio)
        parametros.Add("@Tipo", entidad.Tipo)

        Return vDatos.Escribir("s_AltaCartucho", parametros)
    End Function

    Public Function Editar(ByVal entidad As Cartucho) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", entidad.Id)
        parametros.Add("@Modelo", entidad.Modelo)
        parametros.Add("@Marca", entidad.Marca)
        parametros.Add("@Nombre", entidad.Nombre)
        parametros.Add("@Precio", entidad.Precio)
        parametros.Add("@Tipo", entidad.Tipo)

        Return vDatos.Escribir("s_ModificacionCartucho", parametros)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", id)

        Return vDatos.Escribir("s_BajaCartucho", parametros)
    End Function

    Public Function Listar() As List(Of Cartucho)
        Dim ds As New DataSet
        Dim lista As New List(Of Cartucho)
        ds = vDatos.Leer("s_ListarCartucho", Nothing)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                Dim c As Cartucho = New Cartucho
                c.Id = Item("Id")
                c.Modelo = Item("Modelo")
                c.Marca = Item("Marca")
                c.Nombre = Item("Nombre")
                c.Precio = Item("Precio")
                c.Tipo = Item("Tipo")
                lista.Add(c)
            Next
        End If

        Return lista
    End Function

    Public Function ConsutarPorId(ByVal id As Integer) As Cartucho
        Dim parametros As New Hashtable
        Dim ds As New DataSet

        parametros.Add("@Id", id)
        ds = vDatos.Leer("s_ConsultarPorIdCartucho", parametros)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim row As DataRow = ds.Tables(0).Rows(0)
            Dim c As New Cartucho
            c.Id = row.Item("Id")
            c.Modelo = row.Item("Modelo")
            c.Marca = row.Item("Marca")
            c.Nombre = row.Item("Nombre")
            c.Precio = row.Item("Precio")
            c.Tipo = row.Item("Tipo")
            Return c
        Else
            Return Nothing
        End If
    End Function

End Class
