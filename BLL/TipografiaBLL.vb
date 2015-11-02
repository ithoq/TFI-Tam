Imports MPP
Imports EE
Public Class TipografiaBLL

    Private vMapper As TipografiaMapper

    Sub New()
        Me.vMapper = New TipografiaMapper
    End Sub

    Public Function Crear(ByVal entidad As Tipografia) As Boolean
        Return Me.vMapper.Crear(entidad)
    End Function

    Public Function Editar(ByVal entidad As Tipografia) As Boolean
        Return Me.vMapper.Editar(entidad)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Return Me.vMapper.Eliminar(id)
    End Function

    Public Function Listar() As List(Of Tipografia)
        Return Me.vMapper.Listar()
    End Function

    Public Function ConsutarPorId(ByVal id As Integer) As Tipografia
        Return Me.vMapper.ConsutarPorId(id)
    End Function

End Class
