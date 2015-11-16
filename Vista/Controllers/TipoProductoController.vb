Imports EE
Imports BLL
Public Class TipoProductoController
    Inherits BaseController

    Private vBLL As TipoProductoBLL

    Sub New()
        Me.vBLL = New TipoProductoBLL
    End Sub

    '
    ' GET: /TipoProducto
    <Autorizar(Roles:="VerTiposProductos")>
    Function Index() As ActionResult
        Dim vLista As List(Of TipoProducto) = Me.vBLL.Listar()
        Return View(vLista)
    End Function

    '
    ' GET: /TipoProducto/Details/5
    <Autorizar(Roles:="ConsultarTipoProducto")>
    Function Detalles(ByVal id As Integer) As ActionResult
        Dim vTipoProducto As TipoProducto = Me.vBLL.ConsutarPorId(id)
        Return View(vTipoProducto)
    End Function

    '
    ' GET: /TipoProducto/Create
    <Autorizar(Roles:="CrearTipoProducto")>
    Function Crear() As ActionResult
        Return View()
    End Function

    '
    ' POST: /TipoProducto/Create
    <Autorizar(Roles:="CrearTipoProducto")>
    <HttpPost()> _
    Function Crear(ByVal tp As TipoProducto) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Crear(tp)
            Return RedirectToAction("Index")
        End If
        Return View(tp)
    End Function

    '
    ' GET: /TipoProducto/Edit/5
    <Autorizar(Roles:="EditarTipoProducto")>
    Function Editar(ByVal id As Integer) As ActionResult
        Dim vTipoProducto As TipoProducto = Me.vBLL.ConsutarPorId(id)
        Return View(vTipoProducto)
    End Function

    '
    ' POST: /TipoProducto/Edit/5
    <Autorizar(Roles:="EditarTipoProducto")>
    <HttpPost()> _
    Function Editar(ByVal id As Integer, ByVal tp As TipoProducto) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Editar(tp)
            Return RedirectToAction("Index")
        End If
        Return View(tp)
    End Function

    '
    ' GET: /TipoProducto/Delete/5
    <Autorizar(Roles:="EliminarTipoProducto")>
    Function Eliminar(ByVal id As Integer) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Eliminar(id)
        End If
        Return RedirectToAction("Index")
    End Function

End Class