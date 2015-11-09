Imports BLL
Imports EE
Imports System.IO

Public Class ProductoController
    Inherits BaseController

    Private vBLL As ProductoBLL
    Private vPapelBLL As PapelBLL
    Private vCartuchoBLL As CartuchoBLL
    Sub New()
        Me.vBLL = New ProductoBLL()
        Me.vPapelBLL = New PapelBLL()
        Me.vCartuchoBLL = New CartuchoBLL()
    End Sub

    '
    ' GET: /Producto
    Function Index() As ActionResult
        Dim vLista As List(Of Producto) = Me.vBLL.Listar()
        Return View(vLista)
    End Function

    '
    ' GET: /Producto/Details/5
    <Autorizar(Roles:="ConsultarProducto")>
    Function Detalles(ByVal id As Integer) As ActionResult
        Dim vProducto As Producto = Me.vBLL.ConsutarPorId(id)
        Return View(vProducto)
    End Function

    '
    ' GET: /Producto/Create
    <Autorizar(Roles:="CrearProducto")>
    Function Crear() As ActionResult
        ViewBag.Papeles = Me.vPapelBLL.Listar()
        ViewBag.Cartuchos = Me.vCartuchoBLL.Listar()
        Return View()
    End Function

    '
    ' POST: /Producto/Create
    <Autorizar(Roles:="CrearProducto")>
    <HttpPost()> _
    Function Crear(ByVal entidad As Producto, ByVal Archivo As HttpPostedFileBase) As ActionResult
        Dim listaTiposImagenes As New List(Of String)
        listaTiposImagenes.AddRange({"image/gif", "image/jpeg", "image/png"})
        If Archivo Is Nothing Then
            ModelState.AddModelError("Archivo", "Campo requerido")
        ElseIf Archivo.ContentLength = 0 Then
            ModelState.AddModelError("Archivo", "Campo requerido")
        ElseIf listaTiposImagenes.Contains(Archivo.ContentType) = False Then
            ModelState.AddModelError("Archivo", "Tipo de archivo no permitido")
        End If
        If ModelState.IsValid Then
            Dim directorioSubidas As String = "~/Content/img"
            Dim urlSubidas As String = "/Content/img"
            Dim idImagen As String = Guid.NewGuid().ToString() + Path.GetExtension(Archivo.FileName)
            Dim rutaImagen As String = Path.Combine(Server.MapPath(directorioSubidas), idImagen)
            Dim urlImagen As String = urlSubidas + "/" + idImagen

            Dim imagen As System.Drawing.Image = System.Drawing.Image.FromStream(Archivo.InputStream)

            Archivo.SaveAs(rutaImagen)
            entidad.Fondo = urlImagen
            entidad.Ancho = imagen.Width
            entidad.Alto = imagen.Height

            Me.vBLL.Crear(entidad)
            Return RedirectToAction("Index")
        End If
        ViewBag.Papeles = Me.vPapelBLL.Listar()
        Return View(entidad)
    End Function

    '
    ' GET: /Producto/Edit/5
    <Autorizar(Roles:="EditarProducto")>
    Function Editar(ByVal id As Integer) As ActionResult
        Dim vProducto As Producto = Me.vBLL.ConsutarPorId(id)
        ViewBag.Papeles = Me.vPapelBLL.Listar()
        ViewBag.Cartuchos = Me.vCartuchoBLL.Listar()
        Return View(vProducto)
    End Function

    '
    ' POST: /Producto/Edit/5
    <Autorizar(Roles:="EditarProducto")>
    <HttpPost()> _
    Function Editar(ByVal id As Integer, ByVal entidad As Producto, ByVal Archivo As HttpPostedFileBase) As ActionResult
        Dim listaTiposImagenes As New List(Of String)
        listaTiposImagenes.AddRange({"image/gif", "image/jpeg", "image/png"})
        If Archivo IsNot Nothing Then
            If Archivo.ContentLength = 0 Then
                ModelState.AddModelError("Archivo", "Campo requerido")
            End If
            If listaTiposImagenes.Contains(Archivo.ContentType) = False Then
                ModelState.AddModelError("Archivo", "Tipo de archivo no permitido")
            End If
        End If
        If ModelState.IsValid Then
            If Archivo IsNot Nothing Then
                Dim vProducto As Producto = Me.vBLL.ConsutarPorId(id)
                Dim rutaImagenActual As String = Server.MapPath("~" + vProducto.Fondo)
                If IO.File.Exists(rutaImagenActual) Then
                    IO.File.Delete(rutaImagenActual)
                End If
                Dim directorioSubidas As String = "~/Content/img"
                Dim urlSubidas As String = "/Content/img"
                Dim idImagen As String = Guid.NewGuid().ToString() + Path.GetExtension(Archivo.FileName)
                Dim rutaImagen As String = Path.Combine(Server.MapPath(directorioSubidas), idImagen)
                Dim urlImagen As String = urlSubidas + "/" + idImagen

                Dim imagen As System.Drawing.Image = System.Drawing.Image.FromStream(Archivo.InputStream)

                Archivo.SaveAs(rutaImagen)
                entidad.Fondo = urlImagen
                entidad.Ancho = imagen.Width
                entidad.Alto = imagen.Height
            End If
            Me.vBLL.Editar(entidad)
            Return RedirectToAction("Index")
        End If
        ViewBag.Papeles = Me.vPapelBLL.Listar()
        ViewBag.Cartuchos = Me.vCartuchoBLL.Listar()
        Return View(entidad)
    End Function

    '
    ' GET: /Producto/Delete/5
    <Autorizar(Roles:="EliminarPapel")>
    Function Eliminar(ByVal id As Integer) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Eliminar(id)
        End If
        Return RedirectToAction("Index")
    End Function

End Class