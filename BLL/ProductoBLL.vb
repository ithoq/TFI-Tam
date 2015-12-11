Imports MPP
Imports EE
Public Class ProductoBLL
    Private vMapper As ProductoMapper

    Sub New()
        Me.vMapper = New ProductoMapper
    End Sub

    Public Function Crear(ByVal entidad As Producto) As Boolean
        If Me.vMapper.Crear(entidad) Then
            Servicios.BitacoraServicio.Crear(TipoEvento.Informacion, "Alta correcta de producto")
        End If
        Return True
    End Function

    Public Function Editar(ByVal entidad As Producto) As Boolean
        If Me.vMapper.Editar(entidad) Then
            Servicios.BitacoraServicio.Crear(TipoEvento.Informacion, "Edición de producto correcta")
        End If
        Return True
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        If Me.vMapper.Eliminar(id) Then
            Servicios.BitacoraServicio.Crear(TipoEvento.Informacion, "Baja de producto correcta")
        End If
        Return True
    End Function

    Public Function Listar() As List(Of Producto)
        Return Me.vMapper.Listar()
    End Function

    Public Function Comparar(ByVal ids As String) As List(Of Producto)
        Return Me.vMapper.Comparar(ids)
    End Function

    Public Function ConsutarPorId(ByVal id As Integer) As Producto
        Return Me.vMapper.ConsutarPorId(id)
    End Function

    Public Function Comentar(ByVal entidad As Comentario) As Boolean
        Return Me.vMapper.Comentar(entidad)
    End Function


End Class
