Imports DAL
Imports EE
Public Class TipografiaMapper

    Private vDatos As Datos

    Sub New()
        Me.vDatos = New Datos
    End Sub

    Public Function Crear(ByVal entidad As Tipografia) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Nombre", entidad.Nombre)

        Return vDatos.Escribir("s_AltaTipografia", parametros)
    End Function

    Public Function Editar(ByVal entidad As Tipografia) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", entidad.Id)
        parametros.Add("@Nombre", entidad.Nombre)

        Return vDatos.Escribir("s_ModificacionTipografia", parametros)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", id)

        Return vDatos.Escribir("s_BajaTipografia", parametros)
    End Function

    Public Function Listar() As List(Of Tipografia)
        Dim ds As New DataSet
        Dim lista As New List(Of Tipografia)
        ds = vDatos.Leer("s_ListarTipografia", Nothing)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                Dim t As Tipografia = New Tipografia
                t.Id = Item("Id")
                t.Nombre = Item("Nombre")
                lista.Add(t)
            Next
        End If

        Return lista
    End Function

    Public Function ConsutarPorId(ByVal id As Integer) As Tipografia
        Dim parametros As New Hashtable
        Dim ds As New DataSet

        parametros.Add("@Id", id)
        ds = vDatos.Leer("s_ConsultarPorIdTipografia", parametros)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim row As DataRow = ds.Tables(0).Rows(0)
            Dim t As New Tipografia
            t.Nombre = row.Item("Nombre")
            Return t
        Else
            Return Nothing
        End If
    End Function

End Class
