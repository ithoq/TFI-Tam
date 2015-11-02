Imports DAL
Imports EE
Public Class CartuchoMapper

    Private vDatos As Datos

    Sub New()
        Me.vDatos = New Datos
    End Sub

    Public Function Crear(ByVal entidad As Cartucho) As Boolean
        Dim parametros As New Hashtable

        'parametros.Add("@FechaCreacion", n.FechaCreacion)
        'parametros.Add("@Titulo", n.Titulo)
        'parametros.Add("@Contenido", n.Contenido)
        'parametros.Add("@Tipo", n.Tipo)
        'parametros.Add("@Categoria_Id", n.Categoria.Id)

        'Return vDatos.Escribir("s_AltaNovedad", parametros)
    End Function

    Public Function Editar(ByVal entidad As Cartucho) As Boolean

    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean

    End Function

    Public Function Listar() As List(Of Cartucho)

    End Function

    Public Function ConsutarPorId(ByVal id As Integer) As Boolean

    End Function

End Class
