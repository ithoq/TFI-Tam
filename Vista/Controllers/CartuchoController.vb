Imports BLL
Imports EE
Public Class CartuchoController
    Inherits BaseController

    Private vBLL As CartuchoBLL
    Sub New()
        Me.vBLL = New CartuchoBLL()
    End Sub

    '
    ' GET: /Cartucho
    <Autorizar(Roles:="VerCartuchos")>
    Function Index() As ActionResult
        Dim vLista As List(Of Cartucho) = Me.vBLL.Listar()
        Return View(vLista)
    End Function

    '
    ' GET: /Cartucho/Details/5
    <Autorizar(Roles:="ConsultarCartucho")>
    Function Detalles(ByVal id As Integer) As ActionResult
        Dim vCartucho As Cartucho = Me.vBLL.ConsutarPorId(id)
        Return View(vCartucho)
    End Function

    '
    ' GET: /Cartucho/Create
    <Autorizar(Roles:="CrearCartucho")>
    Function Crear() As ActionResult
        Return View()
    End Function

    '
    ' POST: /Cartucho/Create
    <Autorizar(Roles:="CrearCartucho")>
    <HttpPost()> _
    Function Crear(ByVal c As EE.Cartucho) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Crear(c)
            Return RedirectToAction("Index")
        End If
        Return View(c)
    End Function

    '
    ' GET: /Cartucho/Edit/5
    <Autorizar(Roles:="EditarCartucho")>
    Function Editar(ByVal id As Integer) As ActionResult
        Dim vCartucho As Cartucho = Me.vBLL.ConsutarPorId(id)
        Return View(vCartucho)
    End Function

    '
    ' POST: /Cartucho/Edit/5
    <Autorizar(Roles:="EditarCartucho")>
    <HttpPost()> _
    Function Editar(ByVal id As Integer, ByVal c As Cartucho) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Editar(c)
            Return RedirectToAction("Index")
        End If
        Return View(c)
    End Function

    <Autorizar(Roles:="EliminarCartucho")>
    Function Eliminar(ByVal id As Integer) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Eliminar(id)
        End If
        Return RedirectToAction("Index")
    End Function
End Class