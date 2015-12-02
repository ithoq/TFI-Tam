Imports MPP
Imports EE
Public Class CartuchoBLL

    Private vMapper As CartuchoMapper

    Sub New()
        Me.vMapper = New CartuchoMapper
    End Sub

    Public Function Crear(ByVal entidad As Cartucho) As Boolean
        If Me.vMapper.Crear(entidad) Then
            Servicios.BitacoraServicio.Crear(EE.TipoEvento.Informacion, "Alta de Cartucho")
        End If
        Return True
    End Function

    Public Function Editar(ByVal entidad As Cartucho) As Boolean
        If Me.vMapper.Editar(entidad) Then
            Servicios.BitacoraServicio.Crear(EE.TipoEvento.Informacion, "Edición de Cartucho")
        End If
        Return True
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        If Me.vMapper.Eliminar(id) Then
            Servicios.BitacoraServicio.Crear(EE.TipoEvento.Informacion, "Edición de Cartucho")
        End If
        Return True
    End Function

    Public Function Listar() As List(Of Cartucho)
        Return Me.vMapper.Listar()
    End Function

    Public Function ConsutarPorId(ByVal id As Integer) As Cartucho
        Return Me.vMapper.ConsutarPorId(id)
    End Function

End Class
