Imports EE
Imports DAL
Public Class InformeMapper

    Private vDatos As Datos

    Sub New()
        Me.vDatos = New Datos
    End Sub
    Public Function ListarInformeTiempoRespuesta() As InformeTiempoRespuesta
        Dim ds As New DataSet
        Dim i As New InformeTiempoRespuesta
        Dim lista As New List(Of DetalleInformeTiempoRespuesta)
        ds = vDatos.Leer("s_ListarDetalleInformeSatisfaccion", Nothing)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                Dim d As DetalleInformeTiempoRespuesta = New DetalleInformeTiempoRespuesta
                d.NOrden = Item("Id")
                d.FechaInicio = Item("FechaInicio")
                d.FechaFin = Item("FechaFin")
                lista.Add(d)
            Next
        End If
        i.ListaDetalles = lista
        Return i
    End Function

    Function ObtenerGanancias(ByVal desde As Date, ByVal hasta As Date) As Double
        Dim parametros As New Hashtable
        Dim ds As New DataSet

        parametros.Add("@Desde", desde)
        parametros.Add("@Hasta", hasta)
        ds = vDatos.Leer("s_ObtenerGananciasInforme", parametros)
        Return ds.Tables(0).Rows(0).Item(0)
    End Function

End Class
