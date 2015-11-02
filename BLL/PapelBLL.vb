Imports MPP
Imports EE
Public Class PapelBLL

    Private vMapper As PapelMapper

    Sub New()
        Me.vMapper = New PapelMapper
    End Sub

    Public Function Crear(ByVal entidad As Papel) As Boolean
        Return Me.vMapper.Crear(entidad)
    End Function

    Public Function Editar(ByVal entidad As Papel) As Boolean
        Return Me.vMapper.Editar(entidad)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Return Me.vMapper.Eliminar(id)
    End Function

    Public Function Listar() As List(Of Papel)
        Return Me.vMapper.Listar()
    End Function

    Public Function ConsutarPorId(ByVal id As Integer) As Boolean
        Return Me.vMapper.ConsutarPorId(id)
    End Function

End Class
