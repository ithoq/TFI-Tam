Imports EE
Imports MPP
Public Class TipoProductoBLL

    Private vMapper As TipoProductoMapper

    Sub New()
        Me.vMapper = New TipoProductoMapper
    End Sub

    Public Function Crear(ByVal entidad As TipoProducto) As Boolean
        Return Me.vMapper.Crear(entidad)
    End Function

    Public Function Editar(ByVal entidad As TipoProducto) As Boolean
        Return Me.vMapper.Editar(entidad)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Return Me.vMapper.Eliminar(id)
    End Function

    Public Function ConsutarPorId(ByVal id As Integer) As TipoProducto
        Return Me.vMapper.ConsutarPorId(id)
    End Function
    Public Function Listar() As List(Of TipoProducto)
        Return vMapper.Listar()
    End Function

End Class

