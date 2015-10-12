Imports BLL
Imports EE
Public Class NovedadController
    Inherits BaseController

    Private vBLL As NovedadBLL
    Sub New()
        Me.vBLL = New NovedadBLL()
    End Sub

    '
    ' GET: /Novedad
    <Autorizar(Roles:="VerNovedades")>
    Function Index() As ActionResult
        Dim vLista As List(Of Novedad) = Me.vBLL.Listar()
        Return View(vLista)
    End Function

    <Autorizar(Roles:="CrearNovedad")>
    Function Crear() As ActionResult
        Dim vBLLCat As New CategoriaBLL
        ViewBag.Categorias = vBLLCat.Listar()
        Return View()
    End Function

    <Autorizar(Roles:="CrearNovedad")>
    <HttpPost()> _
    Function Crear(ByVal n As Novedad) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Crear(n)
            Return RedirectToAction("Index", "Home")
        End If

        Return View(n)
    End Function

End Class