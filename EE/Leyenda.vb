Imports System.ComponentModel.DataAnnotations
Public Class Leyenda

    Private vId As Integer
    Public Property Id() As Integer
        Get
            Return vId
        End Get
        Set(ByVal value As Integer)
            vId = value
        End Set
    End Property

    Private vTexto As String
    Public Property Texto() As String
        Get
            Return vTexto
        End Get
        Set(ByVal value As String)
            vTexto = value
        End Set
    End Property

    Private vTamanio As Integer
    Public Property Tamanio() As Integer
        Get
            Return vTamanio
        End Get
        Set(ByVal value As Integer)
            vTamanio = value
        End Set
    End Property

    Private vPosArriba As Integer
    Public Property PosArriba() As Integer
        Get
            Return vPosArriba
        End Get
        Set(ByVal value As Integer)
            vPosArriba = value
        End Set
    End Property

    Private vPosAbajo As Integer
    Public Property PosAbajo() As Integer
        Get
            Return vPosAbajo
        End Get
        Set(ByVal value As Integer)
            vPosAbajo = value
        End Set
    End Property

    Private vProducto As New Producto
    Public Property Producto() As Producto
        Get
            Return vProducto
        End Get
        Set(ByVal value As Producto)
            vProducto = value
        End Set
    End Property

End Class
