Imports System.ComponentModel.DataAnnotations
Public Class Papel
    Inherits MateriaPrima

    Private vEspesor As Double
    <Required(ErrorMessage:="Campo requerido"), RegularExpression("^(\d{1,16}(\,\d{0,2})?)$", ErrorMessage:="Formato incorrecto")>
    Public Property Espesor() As Double
        Get
            Return vEspesor
        End Get
        Set(ByVal value As Double)
            vEspesor = value
        End Set
    End Property

    Private vColor As String
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Color")>
    <StringLength(50, ErrorMessage:="Se ha superado la longitud permitida de 50 caracteres.")>
    Public Property Color() As String
        Get
            Return vColor
        End Get
        Set(ByVal value As String)
            vColor = value
        End Set
    End Property

End Class
