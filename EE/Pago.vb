﻿Public Class Pago
    Inherits Movimiento

    Public Overrides Function ObtenerImporte() As Double
        Return Me.Importe
    End Function

    Public Overrides Function ObtenerTipo() As String
        Return "Pago " + Me.TipoComprobante
    End Function

    Public Overrides Function ObtenerTipoSinFormato() As String
        Return "Pago " + Me.TipoComprobante
    End Function

    Public Overrides Function ObtenerSoloTipo() As String
        Return "Pago"
    End Function

End Class
