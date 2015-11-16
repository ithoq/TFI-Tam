Imports System.ComponentModel.DataAnnotations
Public Class Tema

    Private vId As Integer
    Public Property Id() As Integer
        Get
            Return vId
        End Get
        Set(ByVal value As Integer)
            vId = value
        End Set
    End Property

    Private vTema As String
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Tema")>
    <StringLength(50, ErrorMessage:="Se ha superado la longitud permitida de 50 caracteres.")>
    Public Property Tema() As String
        Get
            Return vTema
        End Get
        Set(ByVal value As String)
            vTema = value
        End Set
    End Property

End Class
