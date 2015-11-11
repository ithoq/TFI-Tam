Public Class NotaCredito
    Inherits Movimiento


    Public Overrides Function ObtenerImporte() As Double
        Return Me.Importe
    End Function

    Public Overrides Function ObtenerTipo() As String
        Return "Nota de Crédito " + Me.TipoComprobante
    End Function
End Class
