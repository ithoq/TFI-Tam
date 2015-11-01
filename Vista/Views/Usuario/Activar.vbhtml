@Code
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

@section breadcrumb
    <ul class="breadcrumb">
        <li>
            <a href="@Url.Action("Index", "Usuario")">Usuarios</a>
        </li>
        <li>
            <a class="active">Activar</a>
        </li>
    </ul>
end section

<h3>Su cuenta se ha activado correctamente. Ya puede iniciar sesión.</h3>