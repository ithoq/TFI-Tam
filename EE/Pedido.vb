Public Class Pedido

    Private vId As Integer
    Public Property Id() As Integer
        Get
            Return vId
        End Get
        Set(ByVal value As Integer)
            vId = value
        End Set
    End Property

    Private vFechaInicio As Date
    Public Property FechaInicio() As Date
        Get
            Return vFechaInicio
        End Get
        Set(ByVal value As Date)
            vFechaInicio = value
        End Set
    End Property

    Private vFechaFin As Date
    Public Property FechaFin() As Date
        Get
            Return vFechaFin
        End Get
        Set(ByVal value As Date)
            vFechaFin = value
        End Set
    End Property

    Private vImporte As Double
    Public Property Importe() As Double
        Get
            Return vImporte
        End Get
        Set(ByVal value As Double)
            vImporte = value
        End Set
    End Property

    Private vEstado As String
    Public Property Estado() As String
        Get
            Return vEstado
        End Get
        Set(ByVal value As String)
            vEstado = value
        End Set
    End Property

    Private vUsuarioId As New Usuario
    Public Property UsuarioId() As Usuario
        Get
            Return vUsuarioId
        End Get
        Set(ByVal value As Usuario)
            vUsuarioId = value
        End Set
    End Property

    Private vLista As New List(Of DetallePedido)
    Public Property ListaPedidos() As List(Of DetallePedido)
        Get
            Return vLista
        End Get
        Set(ByVal value As List(Of DetallePedido))
            vLista = value
        End Set
    End Property

End Class
