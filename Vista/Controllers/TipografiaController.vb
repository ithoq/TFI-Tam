Imports BLL
Imports EE
Public Class TipografiaController
    Inherits BaseController

    Private vBLL As TipografiaBLL
    Sub New()
        Me.vBLL = New TipografiaBLL()
    End Sub

    '
    ' GET: /Tipografia

    <Autorizar(Roles:="VerTipografias")>
    Function Index() As ActionResult
        Dim vLista As List(Of Tipografia) = Me.vBLL.Listar()
        Return View(vLista)
    End Function

    '
    ' GET: /Tipografia/Details/5
    <Autorizar(Roles:="ConsultarTipografia")>
    Function Detalles(ByVal id As Integer) As ActionResult
        Dim vTipografia As Tipografia = Me.vBLL.ConsutarPorId(id)
        Return View(vTipografia)
    End Function

    '
    ' GET: /Tipografia/Create
    <Autorizar(Roles:="CrearTipografia")>
    Function Crear() As ActionResult
        Return View()
    End Function

    '
    ' POST: /Tipografia/Create
    <Autorizar(Roles:="CrearTipografia")>
    <HttpPost()> _
    Function Crear(ByVal t As EE.Tipografia) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Crear(t)
            Return RedirectToAction("Index")
        End If
        Return View(t)
    End Function

    '
    ' GET: /Tipografia/Edit/5
    <Autorizar(Roles:="EditarTipografia")>
    Function Editar(ByVal id As Integer) As ActionResult
        Dim vTipografia As Tipografia = Me.vBLL.ConsutarPorId(id)
        Return View(vTipografia)
    End Function

    '
    ' POST: /Tipografia/Edit/5
    <Autorizar(Roles:="EditarTipografia")>
    <HttpPost()> _
    Function Editar(ByVal id As Integer, ByVal t As Tipografia) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Editar(t)
            Return RedirectToAction("Index")
        End If
        Return View(t)
    End Function

    <Autorizar(Roles:="EliminarTipografia")>
    Function Eliminar(ByVal id As Integer) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Eliminar(id)
        End If
        Return RedirectToAction("Index")
    End Function
End Class