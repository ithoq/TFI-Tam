Imports MPP
Imports EE
Public Class ProductoBLL
    Private vMapper As ProductoMapper

    Sub New()
        Me.vMapper = New ProductoMapper
    End Sub

    Public Function Crear(ByVal entidad As Producto) As Boolean
        Return Me.vMapper.Crear(entidad)
    End Function

    Public Function Editar(ByVal entidad As Producto) As Boolean
        Return Me.vMapper.Editar(entidad)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Return Me.vMapper.Eliminar(id)
    End Function

    Public Function Listar() As List(Of Producto)
        Return Me.vMapper.Listar()
    End Function

    Public Function ConsutarPorId(ByVal id As Integer) As Producto
        Return Me.vMapper.ConsutarPorId(id)
    End Function

    Public Function Comentar(ByVal entidad As Comentario) As Boolean
        Return Me.vMapper.Comentar(entidad)
    End Function


End Class
