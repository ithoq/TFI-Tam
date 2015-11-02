Imports BLL
Imports EE
Public Class PapelController
    Inherits BaseController

    Private vBLL As PapelBLL
    Sub New()
        Me.vBLL = New PapelBLL()
    End Sub

    '
    ' GET: /Papel
    <Autorizar(Roles:="VerPapeles")>
    Function Index() As ActionResult
        Dim vLista As List(Of Papel) = Me.vBLL.Listar()
        Return View(vLista)
    End Function

    '
    ' GET: /Papel/Details/5
    <Autorizar(Roles:="ConsultarPapel")>
    Function Detalles(ByVal id As Integer) As ActionResult
        Dim vPapel As Papel = Me.vBLL.ConsutarPorId(id)
        Return View(vPapel)
    End Function

    '
    ' GET: /Papel/Create
    <Autorizar(Roles:="CrearPapel")>
    Function Crear() As ActionResult
        Return View()
    End Function

    '
    ' POST: /Papel/Create
    <Autorizar(Roles:="CrearPapel")>
    <HttpPost()> _
    Function Crear(ByVal p As Papel) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Crear(p)
            Return RedirectToAction("Index")
        End If
        Return View(p)
    End Function

    '
    ' GET: /Papel/Edit/5
    <Autorizar(Roles:="EditarPapel")>
    Function Editar(ByVal id As Integer) As ActionResult
        Dim vPapel As Papel = Me.vBLL.ConsutarPorId(id)
        Return View(vPapel)
    End Function

    '
    ' POST: /Papel/Edit/5
    <Autorizar(Roles:="EditarPapel")>
    <HttpPost()> _
    Function Editar(ByVal id As Integer, ByVal p As Papel) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Editar(p)
            Return RedirectToAction("Index")
        End If
        Return View(p)
    End Function

    <Autorizar(Roles:="EliminarPapel")>
    Function Eliminar(ByVal id As Integer) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Eliminar(id)
        End If
        Return RedirectToAction("Index")
    End Function

End Class