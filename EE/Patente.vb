Public Class Patente
    Inherits Permiso

    Sub New()

    End Sub

    Sub New(ByVal id As Integer, ByVal nombre As String, ByVal descripcion As String, ByVal url As String, ByVal habilitado As Boolean, ByVal activo As Boolean)
        Me.Id = id
        Me.Nombre = nombre
        Me.Descripcion = descripcion
        Me.Url = url
        Me.Habilitado = habilitado
        Me.Activo = activo
    End Sub

End Class
