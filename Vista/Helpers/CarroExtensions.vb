Imports System.Runtime.CompilerServices
Imports System.Web.Http
Imports EE
Imports BLL

Public Module CarroExtensions
    <Extension()> _
    Public Function Carro(ByVal helper As HtmlHelper) As HtmlString
        Dim urlHelper As New UrlHelper(helper.ViewContext.RequestContext)
        Dim url = urlHelper.Action("VerCarro", "Pedido")
        Dim output As String = ""
        Dim badge As String = ""
        If ObtenerCarrito().ListaPedidos.Count > 0 Then
            badge += "<span class='bubble' style='padding-left: 3px; padding-top: 1px; right: 0px;'>" + ObtenerCarrito().ListaPedidos.Count.ToString() + "</span>"
        End If
        output = output +
            "<li class='p-r-15 inline'>" + _
                "<div>" + _
                    "<a href='" + url + "' class='fa fa-shopping-cart'>" + _
                        badge + _
                    "</a>" + _
                "</div>" + _
            "</li>"
        Return MvcHtmlString.Create(output)
    End Function

    Private Function ObtenerCarrito() As Pedido
        Dim sesionCarro = System.Web.HttpContext.Current.Session("Carrito")
        If sesionCarro IsNot Nothing Then
            Return DirectCast(sesionCarro, Pedido)
        Else
            Dim p As New Pedido
            p.FechaInicio = Now.Date
            p.Estado = "Pendiente"
            p.Importe = 0
            System.Web.HttpContext.Current.Session("Carrito") = p
            Return p
        End If
    End Function

End Module