Imports BLL
Imports EE

Public Class UsuarioController
    Inherits BaseController

    Private vBLL As UsuarioBLL
    Sub New()
        Me.vBLL = New UsuarioBLL()
    End Sub

    '
    ' GET: /Usuario
    <Autorizar(Roles:="VerUsuarios")>
    Function Index() As ActionResult
        Dim vLista As List(Of Usuario) = Me.vBLL.Listar()
        Return View(vLista)
    End Function

    '
    ' GET: /Usuario/Details/5
    <Autorizar(Roles:="ConsultarUsuario")>
    Function Detalles(ByVal id As Integer) As ActionResult
        Dim vUsuario As Usuario = Me.vBLL.ConsultarPorId(id)
        Return View(vUsuario)
    End Function

    '
    ' GET: /Usuario/Create
    <Autorizar(Roles:="CrearUsuario")>
    Function Crear() As ActionResult
        Dim u As New Usuario()
        Dim PerfilBll As New BLL.PerfilBLL()
        ViewBag.Perfiles = PerfilBll.Listar()
        Return View(u)
    End Function

    '
    ' POST: /Usuario/Create
    <Autorizar(Roles:="CrearUsuario")>
    <HttpPost()> _
    Function Crear(ByVal u As Usuario) As ActionResult
        If ModelState.IsValid Then
            If Me.vBLL.VerificarExistenciaPorEmail(u.Email) = False Then
                If Me.vBLL.VerificarExistenciaPorNombreUsuario(u.NombreUsuario) = False Then
                    Me.vBLL.Crear(u)
                    Return RedirectToAction("Index")
                Else
                    ModelState.AddModelError("NombreUsuario", "El nombre de usuario ya está siendo utilizado")
                End If
            Else
                ModelState.AddModelError("Email", "El mail ya está siendo utilizado")
            End If
        End If

        Dim PerfilBll As New BLL.PerfilBLL()
        ViewBag.Perfiles = PerfilBll.Listar()

        Return View(u)
    End Function

    '
    ' GET: /Usuario/Edit/5
    <Autorizar(Roles:="EditarUsuario")>
    Function Editar(ByVal id As Integer) As ActionResult
        Dim vUsuario As EE.Usuario = Me.vBLL.ConsultarPorId(id)
        Dim PerfilBll As New BLL.PerfilBLL()
        ViewBag.Perfiles = PerfilBll.Listar()
        Return View(vUsuario)
    End Function

    '
    ' POST: /Usuario/Edit/5
    <Autorizar(Roles:="EditarUsuario")>
    <HttpPost()> _
    Function Editar(ByVal id As Integer, ByVal u As Usuario) As ActionResult
        Dim claveModelState = ModelState("Clave")
        claveModelState.Errors.Clear()
        If ModelState.IsValid Then
            Me.vBLL.Editar(u)
            Return RedirectToAction("Index")
        End If
        Dim PerfilBll As New BLL.PerfilBLL()
        ViewBag.Perfiles = PerfilBll.Listar()
        Return View(u)
    End Function

    '
    ' GET: /Usuario/Delete/5
    <Autorizar(Roles:="EliminarUsuario")>
    Function Eliminar(ByVal id As Integer) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Eliminar(id)
        Else
            TempData.Add("error", "Se ha producido un error al intentar eliminar el registro.")
        End If
        Return RedirectToAction("Index")
    End Function

    <Autorizar()>
    Function MiCuenta() As ActionResult
        Dim usu As Usuario = vBLL.ConsultarPorId(UsuarioActual.UsuarioId)
        Return View(usu)
    End Function

    Function Registrar() As ActionResult
        Return View()
    End Function

    <HttpPost()> _
    Function Registrar(ByVal umodel As RegistrarViewModel) As ActionResult
        If ModelState.IsValid Then
            Dim usu As New Usuario
            usu.Nombre = umodel.Nombre
            usu.Apellido = umodel.Apellido
            usu.NombreUsuario = umodel.NombreUsu
            usu.Clave = umodel.Clave
            usu.Email = umodel.Email
            Dim uri As String = Request.Url.Scheme.ToString + "://" + Request.Url.Host.ToString + ":" + Request.Url.Port.ToString + "/"
            Me.vBLL.Registrar(usu, uri)
            Return RedirectToAction("Index", "Home")
        End If

        Return View(umodel)
    End Function

    Function Activar(ByVal id As String) As ActionResult
        Me.vBLL.Activar(id)
        Return View()
    End Function

    Function EnviarClave(ByVal form As FormCollection) As ActionResult
        Me.vBLL.EnviarClave(form("email"))
        Return View("~/Views/Cuenta/LogIn.vbhtml")
    End Function

    <Autorizar()>
    Function CambiarClave() As ActionResult
        Return View()
    End Function

    <Autorizar()>
    <HttpPost()>
    Function CambiarClave(ByVal model As CambioClaveViewModel) As ActionResult
        If ModelState.IsValid Then
            Dim u As Usuario = Me.vBLL.ConsultarPorId(UsuarioActual.UsuarioId)
            If u IsNot Nothing Then
                If model.ClaveVieja = u.Clave Then
                    Me.vBLL.CambiarClave(u.Id, model.ClaveNueva, u.Email)
                    Return RedirectToAction("MiCuenta")
                Else
                    ModelState.AddModelError("ClaveVieja", "Contraseña anterior incorrecta")
                End If
            End If
        End If
        Return View()
    End Function

End Class