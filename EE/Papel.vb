Imports System.ComponentModel.DataAnnotations
Public Class Papel
    Inherits MateriaPrima

    Private vEspesor As Double
    Public Property Espesor() As Double
        Get
            Return vEspesor
        End Get
        Set(ByVal value As Double)
            vEspesor = value
        End Set
    End Property

    Private vColor As String
    Public Property Color() As String
        Get
            Return vColor
        End Get
        Set(ByVal value As String)
            vColor = value
        End Set
    End Property

End Class
