Public Class Factura
    Inherits Movimiento


    Public Overrides Function ObtenerImporte() As Double
        Return Me.Importe * -1
    End Function

    Public Overrides Function ObtenerTipo() As String
        Return "Factura " + Me.TipoComprobante
    End Function
End Class
