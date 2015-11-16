Imports EE
Imports DAL
Public Class TemaMapper

    Private vDatos As Datos

    Sub New()
        Me.vDatos = New Datos
    End Sub
    Public Function Crear(ByVal entidad As Tema) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Tema", entidad.Tema)

        Return vDatos.Escribir("s_AltaTema", parametros)
    End Function

    Public Function Editar(ByVal entidad As Tema) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", entidad.Id)
        parametros.Add("@Tema", entidad.Tema)

        Return vDatos.Escribir("s_ModificacionTema", parametros)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", id)

        Return vDatos.Escribir("s_BajaTema", parametros)
    End Function

    Public Function ConsutarPorId(ByVal id As Integer) As Tema
        Dim parametros As New Hashtable
        Dim ds As New DataSet

        parametros.Add("@Id", id)
        ds = vDatos.Leer("s_ConsultarPorIdTema", parametros)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim row As DataRow = ds.Tables(0).Rows(0)
            Dim t As New Tema
            t.Id = row.Item("Id")
            t.Tema = row.Item("Tema")
            Return t
        Else
            Return Nothing
        End If
    End Function

    Public Function Listar() As List(Of Tema)
        Dim ds As New DataSet
        Dim lista As New List(Of Tema)
        ds = vDatos.Leer("s_ListarTema", Nothing)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                Dim t As Tema = New Tema
                t.Id = Item("Id")
                t.Tema = Item("Tema")
                lista.Add(t)
            Next
        End If
        Return lista
    End Function

End Class
