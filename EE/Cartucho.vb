Imports System.ComponentModel.DataAnnotations
Public Class Cartucho
    Inherits MateriaPrima

    Private vModelo As String
    Public Property Modelo() As String
        Get
            Return vModelo
        End Get
        Set(ByVal value As String)
            vModelo = value
        End Set
    End Property

    Private vMarca As String
    Public Property Marca() As String
        Get
            Return vMarca
        End Get
        Set(ByVal value As String)
            vMarca = value
        End Set
    End Property

End Class
