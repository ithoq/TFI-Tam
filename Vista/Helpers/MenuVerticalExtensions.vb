Imports System.Runtime.CompilerServices
Imports System.Web.Http
Imports EE
Imports BLL

Public Module MenuVerticalExtensions
    <Extension()> _
    Public Function MenuVertical(ByVal helper As HtmlHelper) As HtmlString
        Dim customPrincipal As CustomPrincipal = TryCast(HttpContext.Current.User, CustomPrincipal)
        Dim output As String = ""
        If Not IsNothing(customPrincipal) Then
            Dim vPerfilBll As New PerfilBLL()
            Dim listaPermisos As List(Of Permiso) = vPerfilBll.ConsultarPermisos(0, customPrincipal.UsuarioId)

            output = output +
                "<li>" +
                    "<a href='javascript:;'>" +
                        "<span class='title'>Mi Cuenta</span>" +
                        "<span class='arrow'></span>" +
                    "</a>" +
                    "<i class='icon-thumbnail'>M</i>" +
                    "<ul class='sub-menu'>" +
                        "<li>" +
                            "<a href='/Usuario/MiCuenta'>" +
                                "<span class='title'>Información Básica</span>" +
                            "</a>" +
                            "<i class='icon-thumbnail'>IB</i>" +
                        "</li>" +
                        "<li>" +
                            "<a href='/Usuario/MiCuenta'>" +
                                "<span class='title'>Cuenta Corriente</span>" +
                            "</a>" +
                            "<i class='icon-thumbnail'>CC</i>" +
                        "</li>" +
                        "<li>" +
                            "<a href='/Usuario/MiCuenta'>" +
                                "<span class='title'>Mis Pedidos</span>" +
                            "</a>" +
                            "<i class='icon-thumbnail'>MP</i>" +
                        "</li>" +
                    "</ul>" +
                "</li>"

            For Each p As Permiso In listaPermisos
                If p.Habilitado And p.Activo Then
                    If TypeOf p Is Familia Then
                        If AlgunHijoActivoHabilitado(p) Then
                            output = output +
                                "<li>" +
                                    "<a href='javascript:;'>" +
                                        "<span class='title'>" + p.Descripcion + "</span>" +
                                        "<span class='arrow'></span>" +
                                    "</a>" +
                                    "<i class='icon-thumbnail'>" + p.Descripcion.Substring(0, 1) + "</i>" +
                                    "<ul class='sub-menu'>"
                            ArmarMenu(output, p)
                            output = output +
                                    "</ul>" +
                                "</li>"
                        End If
                    Else
                        output = output +
                            "<li>" +
                                "<a href='" + p.Url + "'>" +
                                    "<span class='title'>" + p.Descripcion + "</span>" +
                                "</a>" +
                                "<i class='icon-thumbnail'>" + p.Descripcion.Substring(0, 1) + "</i>" +
                            "</li>"
                    End If
                End If
            Next
        End If
        Return MvcHtmlString.Create(output)
    End Function

    Private Sub ArmarMenu(ByRef output As String, ByVal f As Familia)
        For Each p As Permiso In f.ListaPermisos
            If p.Habilitado And p.Activo Then
                If TypeOf p Is Familia Then
                    output = output +
                        "<li>" +
                            "<a href='javascript:;'>" +
                                "<span class='title'>" + p.Descripcion + "</span>" +
                                "<span class='arrow'></span>" +
                            "</a>" +
                            "<i class='icon-thumbnail'>" + p.Descripcion.Substring(0, 1) + "</i>" +
                            "<ul class='sub-menu'>"
                    ArmarMenu(output, p)
                    output = output +
                            "</ul>" +
                        "</li>"
                Else
                    output = output +
                        "<li>" +
                            "<a href='" + p.Url + "'>" +
                                "<span class='title'>" + p.Descripcion + "</span>" +
                            "</a>" +
                            "<i class='icon-thumbnail'>" + p.Descripcion.Substring(0, 1) + "</i>" +
                        "</li>"
                End If
            End If
        Next
    End Sub

    Private Function AlgunHijoActivoHabilitado(ByVal f As Familia) As Boolean
        Dim Mostrar As Boolean = True
        For Each p As Permiso In f.ListaPermisos
            If TypeOf p Is Familia Then
                Mostrar = Mostrar And AlgunHijoActivoHabilitado(p)
            Else
                If p.Activo Then
                    Mostrar = Mostrar And p.Habilitado
                End If
            End If
        Next
        Return Mostrar
    End Function

End Module
