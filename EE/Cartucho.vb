Imports System.ComponentModel.DataAnnotations
Public Class Cartucho
    Inherits MateriaPrima

    Private vModelo As String
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Modelo")>
    <StringLength(50, ErrorMessage:="Se ha superado la longitud permitida de 50 caracteres.")>
    Public Property Modelo() As String
        Get
            Return vModelo
        End Get
        Set(ByVal value As String)
            vModelo = value
        End Set
    End Property

    Private vMarca As String
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Marca")>
    <StringLength(50, ErrorMessage:="Se ha superado la longitud permitida de 50 caracteres.")>
    Public Property Marca() As String
        Get
            Return vMarca
        End Get
        Set(ByVal value As String)
            vMarca = value
        End Set
    End Property

End Class
