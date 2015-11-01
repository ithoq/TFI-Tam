@ModelType EE.Usuario

@section breadcrumb
    <ul class="breadcrumb">
        <li>
            <a href="@Url.Action("Index", "Home")">Inicio</a>
        </li>
        <li>
            <a class="active">Mi cuenta</a>
        </li>
    </ul>
end section
<div class="panel panel-transparent ">
    <!-- Nav tabs -->
    <ul class="nav nav-tabs nav-tabs-fillup">
        <li class="active">
            <a data-toggle="tab" href="#tab-fillup1"><span>Información Básica</span></a>
        </li>
    </ul>
    <!-- Tab panes -->
    <div class="tab-content">
        <div class="tab-pane active" id="tab-fillup1">
            @Html.DisplayNameFor(Function(model) model.Nombre): @Html.DisplayFor(Function(model) model.Nombre)<br />
            @Html.DisplayNameFor(Function(model) model.Apellido): @Html.DisplayFor(Function(model) model.Apellido)<br />
            @Html.DisplayNameFor(Function(model) model.Email): @Html.DisplayFor(Function(model) model.Email)<br />
            @Html.DisplayNameFor(Function(model) model.NombreUsuario): @Html.DisplayFor(Function(model) model.NombreUsuario)<br />
            @Html.DisplayNameFor(Function(model) model.Activo): @Html.DisplayFor(Function(model) model.Activo)
        </div>
    </div>
</div>
<p>
    @*@Html.ActionLink("Editar", "Editar", New With {.id = Model.Id}, New With {.class = "btn btn-primary btn-cons"})*@
    @Html.ActionLink("Cambiar contraseña", "CambiarClave", New With {.id = Model.Id}, New With {.class = "btn btn-primary btn-cons"})
</p>


