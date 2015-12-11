Imports MPP
Imports EE
Imports Servicios
Public Class EncuestaBLL

    Private vMapper As EncuestaMapper

    Sub New()
        Me.vMapper = New EncuestaMapper
    End Sub

    Public Function Crear(ByVal e As Encuesta) As Boolean
        If Me.vMapper.Crear(e) Then
            BitacoraServicio.Crear(TipoEvento.Informacion, "Alta de Encuesta")
        End If
        Return True
    End Function

    Public Function Editar(ByVal e As Encuesta) As Boolean
        If Me.vMapper.Editar(e) Then
            BitacoraServicio.Crear(TipoEvento.Informacion, "Edición de Encuesta")
        End If
        Return True
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        If Me.vMapper.Eliminar(id) Then
            BitacoraServicio.Crear(TipoEvento.Informacion, "Baja de Encuesta")
        End If
        Return True
    End Function

    Public Function Listar() As List(Of Encuesta)
        Return vMapper.Listar()
    End Function

    Public Function ConsultarPorId(ByVal id As Integer) As Encuesta
        Return vMapper.ConsultarPorId(id)
    End Function

    Public Function ConsultarRandomPorTipo(ByVal tipo As String) As Encuesta
        Return vMapper.ConsultarRandomPorTipo(tipo)
    End Function

    Public Function Responder(ByVal opcionId As Integer) As Boolean
        Return vMapper.Responder(opcionId)
    End Function

End Class

