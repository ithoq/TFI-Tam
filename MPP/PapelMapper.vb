Imports DAL
Imports EE
Public Class PapelMapper

    Private vDatos As Datos

    Sub New()
        Me.vDatos = New Datos
    End Sub

    Public Function Crear(ByVal entidad As Papel) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Espesor", entidad.Espesor)
        parametros.Add("@Color", entidad.Color)
        parametros.Add("@Nombre", entidad.Nombre)
        parametros.Add("@Precio", entidad.Precio)
        parametros.Add("@Tipo", entidad.Tipo)

        Return vDatos.Escribir("s_AltaPapel", parametros)
    End Function

    Public Function Editar(ByVal entidad As Papel) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", entidad.Id)
        parametros.Add("@Espesor", entidad.Espesor)
        parametros.Add("@Color", entidad.Color)
        parametros.Add("@Nombre", entidad.Nombre)
        parametros.Add("@Precio", entidad.Precio)
        parametros.Add("@Tipo", entidad.Tipo)

        Return vDatos.Escribir("s_ModificacionPapel", parametros)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", id)

        Return vDatos.Escribir("s_BajaPapel", parametros)
    End Function

    Public Function Listar() As List(Of Papel)
        Dim ds As New DataSet
        Dim lista As New List(Of Papel)
        ds = vDatos.Leer("s_ListarPapel", Nothing)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                Dim p As Papel = New Papel
                p.Id = Item("Id")
                p.Espesor = Item("Espesor")
                p.Color = Item("Color")
                p.Nombre = Item("Nombre")
                p.Precio = Item("Precio")
                p.Tipo = Item("Tipo")
                lista.Add(p)
            Next
        End If

        Return lista
    End Function

    Public Function ConsutarPorId(ByVal id As Integer) As Papel
        Dim parametros As New Hashtable
        Dim ds As New DataSet

        parametros.Add("@Id", id)
        ds = vDatos.Leer("s_ConsultarPorIdPapel", parametros)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim row As DataRow = ds.Tables(0).Rows(0)
            Dim p As New Papel
            p.Id = row.Item("Id")
            p.Espesor = row.Item("Espesor")
            p.Color = row.Item("Color")
            p.Nombre = row.Item("Nombre")
            p.Precio = row.Item("Precio")
            p.Tipo = row.Item("Tipo")
            Return p
        Else
            Return Nothing
        End If
    End Function

End Class
