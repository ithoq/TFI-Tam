Imports MPP
Imports EE
Public Class CartuchoBLL

    Private vMapper As CartuchoMapper

    Sub New()
        Me.vMapper = New CartuchoMapper
    End Sub

    Public Function Crear(ByVal entidad As Cartucho) As Boolean
        Return Me.vMapper.Crear(entidad)
    End Function

    Public Function Editar(ByVal entidad As Cartucho) As Boolean
        Return Me.vMapper.Editar(entidad)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Return Me.vMapper.Eliminar(id)
    End Function

    Public Function Listar() As List(Of Cartucho)
        Return Me.vMapper.Listar()
    End Function

    Public Function ConsutarPorId(ByVal id As Integer) As Boolean
        Return Me.vMapper.ConsutarPorId(id)
    End Function

End Class
