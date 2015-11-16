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

    Private vTema As New Tema
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

    Private vValoracion As Integer
    Public Property Valoracion() As Integer
        Get
            Return vValoracion
        End Get
        Set(ByVal value As Integer)
            vValoracion = value
        End Set
    End Property

    Private vListaComentarios As New List(Of Comentario)
    Public Property ListaComentarios() As List(Of Comentario)
        Get
            Return vListaComentarios
        End Get
        Set(ByVal value As List(Of Comentario))
            vListaComentarios = value
        End Set
    End Property

    Public Function ObtenerCosto() As Double
        Dim volumen As Double = (Me.Ancho * 0.0264) * (Me.Alto * 0.0264) * (Me.Papel.Espesor * 0.1)
        Dim volumenPapel As Double = 21 * 45 * (Me.Papel.Espesor * 0.1)
        Dim costoPapel As Double = volumen * Me.Papel.Precio / volumenPapel
        Dim costoCartucho As Double = Me.Cartucho.Precio * 0.01
        Return Math.Round(costoPapel + costoCartucho, 2)
    End Function

    Public Function ObtenerPrecio() As Double
        Return Me.ObtenerCosto() * 4
    End Function

    Public Function ObtenerIva() As Double
        Return Math.Round(Me.ObtenerPrecio() * 0.21, 2)
    End Function

    Public Function ObtenerPrecioConIva() As Double
        Return Math.Round(Me.ObtenerPrecio() + Me.ObtenerIva(), 2)
    End Function

    Public Function CrearOrdenesProduccion(ByVal cantidad As Integer) As List(Of OrdenProduccion)
        Dim listaOrdenes As New List(Of OrdenProduccion)

        Dim o1 As New OrdenProduccion
        o1.Tipo = "Impresión"
        o1.Cantidad = cantidad
        o1.Estado = "Pendiente"
        o1.Producto = Me

        Dim o2 As New OrdenProduccion
        o2.Tipo = "Terminación"
        o2.Cantidad = cantidad
        o2.Estado = "Pendiente"
        o2.Producto = Me

        listaOrdenes.AddRange({o1, o2})

        Return listaOrdenes
    End Function

End Class
