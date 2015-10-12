Imports MPP
Imports EE
Imports Servicios
Public Class NovedadBLL

    Private vMapper As NovedadMapper

    Sub New()
        Me.vMapper = New NovedadMapper
    End Sub

    Public Function Crear(ByVal n As Novedad) As Boolean
        n.FechaCreacion = Now.Date
        n.Tipo = "Novedad"
        Return vMapper.Crear(n)
    End Function

    Public Function Listar() As List(Of Novedad)
        Return vMapper.Listar()
    End Function

End Class
