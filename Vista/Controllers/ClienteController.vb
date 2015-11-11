Imports EE
Imports BLL

Public Class ClienteController
    Inherits BaseController

    Private vBLL As UsuarioBLL
    Sub New()
        Me.vBLL = New UsuarioBLL()
    End Sub

    '
    ' GET: /Cliente
    <Autorizar(Roles:="VerClientes")>
    Function Index() As ActionResult
        Dim vLista As List(Of Usuario) = Me.vBLL.ListarClientes()
        Return View(vLista)
    End Function

End Class