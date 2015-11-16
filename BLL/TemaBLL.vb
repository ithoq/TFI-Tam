Imports MPP
Imports EE
Public Class TemaBLL

    Private vMapper As TemaMapper

    Sub New()
        Me.vMapper = New TemaMapper
    End Sub

    Public Function Crear(ByVal entidad As Tema) As Boolean
        Return Me.vMapper.Crear(entidad)
    End Function

    Public Function Editar(ByVal entidad As Tema) As Boolean
        Return Me.vMapper.Editar(entidad)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Return Me.vMapper.Eliminar(id)
    End Function

    Public Function ConsutarPorId(ByVal id As Integer) As Tema
        Return Me.vMapper.ConsutarPorId(id)
    End Function
    Public Function Listar() As List(Of Tema)
        Return vMapper.Listar()
    End Function

End Class
