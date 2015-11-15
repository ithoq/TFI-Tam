Imports EE
Imports BLL
Public Class TemaController
    Inherits BaseController

    Private vBLL As TemaBLL
    Sub New()
        Me.vBLL = New TemaBLL
    End Sub
    '
    ' GET: /Tema
    <Autorizar(Roles:="VerTemas")>
    Function Index() As ActionResult
        Dim vLista As List(Of Tema) = Me.vBLL.Listar()
        Return View(vLista)
    End Function

    '
    ' GET: /Tema/Details/5
    <Autorizar(Roles:="ConsultarTema")>
    Function Detalles(ByVal id As Integer) As ActionResult
        Dim vTema As Tema = Me.vBLL.ConsutarPorId(id)
        Return View(vTema)
    End Function

    '
    ' GET: /Tema/Create
    <Autorizar(Roles:="CrearTema")>
    Function Crear() As ActionResult
        Return View()
    End Function

    '
    ' POST: /Tema/Create
    <Autorizar(Roles:="CrearTema")>
    <HttpPost()> _
    Function Crear(ByVal t As Tema) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Crear(t)
            Return RedirectToAction("Index")
        End If
        Return View(t)
    End Function

    '
    ' GET: /Tema/Edit/5
    <Autorizar(Roles:="EditarCartucho")>
    Function Editar(ByVal id As Integer) As ActionResult
        Dim vTema As Tema = Me.vBLL.ConsutarPorId(id)
        Return View(vTema)
    End Function

    '
    ' POST: /Tema/Edit/5
    <Autorizar(Roles:="EditarCartucho")>
    <HttpPost()> _
    Function Editar(ByVal id As Integer, ByVal t As Tema) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Editar(t)
            Return RedirectToAction("Index")
        End If
        Return View(t)
    End Function

    '
    ' GET: /Tema/Delete/5
    <Autorizar(Roles:="EliminarTema")>
    Function Eliminar(ByVal id As Integer) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Eliminar(id)
        End If
        Return RedirectToAction("Index")
    End Function

End Class