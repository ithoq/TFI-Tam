Imports MPP
Imports EE
Public Class PapelBLL

    Private vMapper As PapelMapper

    Sub New()
        Me.vMapper = New PapelMapper
    End Sub

    Public Function Crear(ByVal entidad As Papel) As Boolean
        If Me.vMapper.Crear(entidad) Then
            Servicios.BitacoraServicio.Crear(TipoEvento.Informacion, "Alta de Papel")
        End If
        Return True
    End Function

    Public Function Editar(ByVal entidad As Papel) As Boolean
        If Me.vMapper.Editar(entidad) Then
            Servicios.BitacoraServicio.Crear(TipoEvento.Informacion, "Edición de Papel")
        End If
        Return True
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        If Me.vMapper.Eliminar(id) Then
            Servicios.BitacoraServicio.Crear(TipoEvento.Informacion, "Baja de Papel")
        End If
        Return True
    End Function

    Public Function Listar() As List(Of Papel)
        Return Me.vMapper.Listar()
    End Function

    Public Function ConsutarPorId(ByVal id As Integer) As Papel
        Return Me.vMapper.ConsutarPorId(id)
    End Function

End Class
