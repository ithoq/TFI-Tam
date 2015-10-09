' Nota: para obtener instrucciones sobre cómo habilitar el modo clásico de IIS6 o IIS7, 
' visite http://go.microsoft.com/?LinkId=9394802
Imports System.Web.Http
Imports System.Web.Optimization
Imports Newtonsoft.Json

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Sub Application_Start()
        AreaRegistration.RegisterAllAreas()

        WebApiConfig.Register(GlobalConfiguration.Configuration)
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
    End Sub

    Protected Sub Application_PostAuthenticateRequest(sender As [Object], e As EventArgs)
        'Se obtiene la cookie con el nombre .ASPAUTH
        Dim authCookie As HttpCookie = Request.Cookies(FormsAuthentication.FormsCookieName)
        'Existe la cookie? hay alguien logueado?
        If authCookie IsNot Nothing Then
            'Se obtiene el ticket de logueo y se desencripta su valor
            Dim authTicket As FormsAuthenticationTicket = FormsAuthentication.Decrypt(authCookie.Value)
            'Se obtiene la información de usuario del ticket 
            Dim serializeModel As UsuarioSerializableModel = JsonConvert.DeserializeObject(Of UsuarioSerializableModel)(authTicket.UserData)
            'Se crea el usuario logueado dentro del contexto http tomando la información del ticket (Al HttpContext hay que pasarle un usuario del tipo IPrincipal)
            Dim newUser As New CustomPrincipal(authTicket.Name)
            newUser.UsuarioId = serializeModel.UsuarioId
            newUser.Nombre = serializeModel.Nombre
            newUser.NombreUsuario = serializeModel.NombreUsuario
            newUser.Apellido = serializeModel.Apellido
            newUser.Permisos = serializeModel.Permisos
            HttpContext.Current.User = newUser
            Dim vUsuarioBLL As New BLL.UsuarioBLL
            EE.SesionUsuario.Instance.UsuarioActual = vUsuarioBLL.ConsultarPorId(serializeModel.UsuarioId)
        End If
    End Sub

End Class
