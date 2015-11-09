Imports System.ComponentModel.DataAnnotations
Public Class Producto

    Private vId As Integer
    Public Property Id() As Integer
        Get
            Return vId
        End Get
        Set(ByVal value As Integer)
            vId = value
        End Set
    End Property

    Private vFondo As String
    Public Property Fondo() As String
        Get
            Return vFondo
        End Get
        Set(ByVal value As String)
            vFondo = value
        End Set
    End Property

    Private vNombre As String
    Public Property Nombre() As String
        Get
            Return vNombre
        End Get
        Set(ByVal value As String)
            vNombre = value
        End Set
    End Property

    Private vAlto As Double
    Public Property Alto() As Double
        Get
            Return vAlto
        End Get
        Set(ByVal value As Double)
            vAlto = value
        End Set
    End Property

    Private vAncho As Double
    Public Property Ancho() As Double
        Get
            Return vAncho
        End Get
        Set(ByVal value As Double)
            vAncho = value
        End Set
    End Property

    Private vPapel As New Papel
    Public Property Papel() As Papel
        Get
            Return vPapel
        End Get
        Set(ByVal value As Papel)
            vPapel = value
        End Set
    End Property

    Private vTipoProducto As TipoProducto
    Public Property TipoProducto() As TipoProducto
        Get
            Return vTipoProducto
        End Get
        Set(ByVal value As TipoProducto)
            vTipoProducto = value
        End Set
    End Property

    Private vTema As Tema
    Public Property Tema() As Tema
        Get
            Return vTema
        End Get
        Set(ByVal value As Tema)
            vTema = value
        End Set
    End Property

    Private vCartucho As New Cartucho
    Public Property Cartucho() As Cartucho
        Get
            Return vCartucho
        End Get
        Set(ByVal value As Cartucho)
            vCartucho = value
        End Set
    End Property

    Public Function ObtenerCosto() As Double
        Dim volumen As Double = Me.Ancho * Me.Alto * Me.Papel.Espesor
        Dim volumenPapel As Double = 21 * 45 * 0.09
        Dim costoPapel As Double = volumen * Me.Papel.Precio / volumenPapel
        Dim costoCartucho As Double = Me.Cartucho.Precio * 0.01
        Return Math.Round(costoPapel + costoCartucho, 2)
    End Function

    Public Function ObtenerPrecio() As Double
        Return Me.ObtenerCosto() * 2
    End Function

End Class
