Imports EE
Imports BLL

Public Class CategoriaController
    Inherits BaseController

    Private vBLL As categoriaBLL
    Sub New()
        Me.vBLL = New CategoriaBLL
    End Sub

    <Autorizar(Roles:="VerCategorias")>
    Function Index() As ActionResult
        Dim vLista As List(Of Categoria) = Me.vBLL.Listar()
        Return View(vLista)
    End Function

    <Autorizar(Roles:="ConsultarCategoria")>
    Function Detalles(ByVal id As Integer) As ActionResult
        Dim vCartucho As Categoria = Me.vBLL.ConsutarPorId(id)
        Return View(vCartucho)
    End Function

    <Autorizar(Roles:="CrearCategoria")>
    Function Crear() As ActionResult
        Return View()
    End Function

    <Autorizar(Roles:="CrearCategoria")>
    <HttpPost()> _
    Function Crear(ByVal c As Categoria) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Crear(c)
            Return RedirectToAction("Index")
        End If
        Return View(c)
    End Function

    <Autorizar(Roles:="EditarCategoria")>
    Function Editar(ByVal id As Integer) As ActionResult
        Dim vCategoria As Categoria = Me.vBLL.ConsutarPorId(id)
        Return View(vCategoria)
    End Function

    <Autorizar(Roles:="EditarCategoria")>
    <HttpPost()> _
    Function Editar(ByVal id As Integer, ByVal c As Categoria) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Editar(c)
            Return RedirectToAction("Index")
        End If
        Return View(c)
    End Function

    <Autorizar(Roles:="EliminarCategoria")>
    Function Eliminar(ByVal id As Integer) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Eliminar(id)
        End If
        Return RedirectToAction("Index")
    End Function
End Class