Imports EE
Imports DAL

Public Class TipoProductoMapper

    Private vDatos As Datos

    Sub New()
        Me.vDatos = New Datos
    End Sub

    Public Function Crear(ByVal entidad As TipoProducto) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Tipo", entidad.Tipo)

        Return vDatos.Escribir("s_AltaTipoProducto", parametros)
    End Function

    Public Function Editar(ByVal entidad As TipoProducto) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", entidad.Id)
        parametros.Add("@Tipo", entidad.Tipo)

        Return vDatos.Escribir("s_ModificacionTipoProducto", parametros)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", id)

        Return vDatos.Escribir("s_BajaTipoProducto", parametros)
    End Function

    Public Function ConsutarPorId(ByVal id As Integer) As TipoProducto
        Dim parametros As New Hashtable
        Dim ds As New DataSet

        parametros.Add("@Id", id)
        ds = vDatos.Leer("s_ConsultarPorIdTipoProducto", parametros)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim row As DataRow = ds.Tables(0).Rows(0)
            Dim t As New TipoProducto
            t.Id = row.Item("Id")
            t.Tipo = row.Item("Tipo")
            Return t
        Else
            Return Nothing
        End If
    End Function

    Public Function Listar() As List(Of TipoProducto)
        Dim ds As New DataSet
        Dim lista As New List(Of TipoProducto)
        ds = vDatos.Leer("s_ListarTipoProducto", Nothing)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                Dim t As TipoProducto = New TipoProducto
                t.Id = Item("Id")
                t.Tipo = Item("Tipo")
                lista.Add(t)
            Next
        End If
        Return lista
    End Function

End Class
