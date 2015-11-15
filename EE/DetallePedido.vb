﻿Public Class DetallePedido

    Private vId As Integer
    Public Property Id() As Integer
        Get
            Return vId
        End Get
        Set(ByVal value As Integer)
            vId = value
        End Set
    End Property

    Private vCantidad As Integer
    Public Property Cantidad() As Integer
        Get
            Return vCantidad
        End Get
        Set(ByVal value As Integer)
            vCantidad = value
        End Set
    End Property

    Private vPrecio As Double
    Public Property Precio() As Double
        Get
            Return vPrecio
        End Get
        Set(ByVal value As Double)
            vPrecio = value
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

    Public ReadOnly Property Total As Double
        Get
            Return Math.Round(Me.Cantidad * Me.Precio, 2)
        End Get
    End Property
End Class
