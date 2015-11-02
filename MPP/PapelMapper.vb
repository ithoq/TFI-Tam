Imports DAL
Imports EE
Public Class PapelMapper

    Private vDatos As Datos

    Sub New()
        Me.vDatos = New Datos
    End Sub

    Public Function Crear(ByVal entidad As Papel) As Boolean

    End Function

    Public Function Editar(ByVal entidad As Papel) As Boolean

    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean

    End Function

    Public Function Listar() As List(Of Papel)

    End Function

    Public Function ConsutarPorId(ByVal id As Integer) As Boolean

    End Function

End Class
