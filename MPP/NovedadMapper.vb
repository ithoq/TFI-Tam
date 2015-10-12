Imports DAL
Imports EE
Public Class NovedadMapper

    Private vDatos As Datos

    Sub New()
        Me.vDatos = New Datos
    End Sub

    Public Function Crear(ByVal n As Novedad) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@FechaCreacion", n.FechaCreacion)
        parametros.Add("@Titulo", n.Titulo)
        parametros.Add("@Contenido", n.Contenido)
        parametros.Add("@Tipo", n.Tipo)
        parametros.Add("@Categoria", n.Categoria)

        Return vDatos.Escribir("s_AltaNovedad", parametros)
    End Function

    Public Function Listar() As List(Of Novedad)
        Dim ds As New DataSet
        Dim lista As New List(Of Novedad)
        ds = vDatos.Leer("s_ListarNovedad", Nothing)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                Dim n As Novedad = New Novedad
                n.Id = Item("Id")
                n.FechaCreacion = Item("FechaCreacion")
                n.Titulo = Item("Titulo")
                n.Contenido = Item("Contenido")
                n.Tipo = Item("Tipo")
                n.Categoria = Item("Categoria")
                lista.Add(n)
            Next
        End If

        Return lista
    End Function

End Class
