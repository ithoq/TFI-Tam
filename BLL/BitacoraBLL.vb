Imports MPP
Imports EE
Public Class BitacoraBLL

    Private vMapper As BitacoraMapper

    Sub New()
        Me.vMapper = New BitacoraMapper
    End Sub
    Public Function Listar() As List(Of Bitacora)
        Return vMapper.Listar()
    End Function

End Class
