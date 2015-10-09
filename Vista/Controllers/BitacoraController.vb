Imports BLL
Imports EE
Public Class BitacoraController
    Inherits BaseController

    Private vBLL As BitacoraBLL
    Sub New()
        Me.vBLL = New BitacoraBLL()
    End Sub

    '
    ' GET: /Bitacora
    <Autorizar(Roles:="VerBitacora")>
    Function Index() As ActionResult
        Dim vLista As List(Of Bitacora) = Me.vBLL.Listar
        Return View(vLista)
    End Function

End Class