Imports System.Web
Imports System.Web.Optimization

Public Class BundleConfig
    ' Para obtener más información acerca de Bundling, consulte http://go.microsoft.com/fwlink/?LinkId=254725
    Public Shared Sub RegisterBundles(ByVal bundles As BundleCollection)
        bundles.Add(New ScriptBundle("~/bundles/jquery").Include(
                   "~/Scripts/jquery-{version}.js"))

        bundles.Add(New ScriptBundle("~/bundles/jqueryui").Include(
                    "~/Scripts/jquery-ui-{version}.js"))

        bundles.Add(New ScriptBundle("~/bundles/jqueryval").Include(
                    "~/Scripts/jquery.unobtrusive*",
                    "~/Scripts/jquery.validate*"))

        ' Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información sobre los formularios. De este modo, estará
        ' preparado para la producción y podrá utilizar la herramienta de creación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
        bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
                    "~/Scripts/modernizr-*"))

        bundles.Add(New StyleBundle("~/Content/css").Include("~/Content/site.css"))

        bundles.Add(New StyleBundle("~/Content/themes/base/css").Include(
                    "~/Content/themes/base/jquery.ui.core.css",
                    "~/Content/themes/base/jquery.ui.resizable.css",
                    "~/Content/themes/base/jquery.ui.selectable.css",
                    "~/Content/themes/base/jquery.ui.accordion.css",
                    "~/Content/themes/base/jquery.ui.autocomplete.css",
                    "~/Content/themes/base/jquery.ui.button.css",
                    "~/Content/themes/base/jquery.ui.dialog.css",
                    "~/Content/themes/base/jquery.ui.slider.css",
                    "~/Content/themes/base/jquery.ui.tabs.css",
                    "~/Content/themes/base/jquery.ui.datepicker.css",
                    "~/Content/themes/base/jquery.ui.progressbar.css",
                    "~/Content/themes/base/jquery.ui.theme.css"))

        'bundles.Add(New StyleBundle("Vendor").Include(
        '    "~/Pages/assets/plugins/pace/pace-theme-flash.css",
        '    "~/Pages/assets/plugins/boostrapv3/css/bootstrap.min.css",
        '    "~/Pages/assets/plugins/font-awesome/css/font-awesome.css",
        '    "~/Pages/assets/plugins/jquery-scrollbar/jquery.scrollbar.css",
        '    "~/Pages/assets/plugins/bootstrap-select2/select2.css",
        '    "~/Pages/assets/plugins/switchery/css/switchery.min.css"))

        'bundles.Add(New StyleBundle("Pages").Include(
        '    "~/Pages/pages/css/pages-icons.css",
        '    "~/Pages/pages/css/pages.css"))
    End Sub
End Class