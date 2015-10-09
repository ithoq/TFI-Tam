@ModelType EE.Usuario

@section breadcrumb
    <ul class="breadcrumb">
        <li>
            <p>Usuarios</p>
        </li>
        <li>
            <a href="#" class="active">Detalles</a>
        </li>
    </ul>
end section
<div class="panel panel-transparent ">
    <!-- Nav tabs -->
    <ul class="nav nav-tabs nav-tabs-fillup">
        <li class="active">
            <a data-toggle="tab" href="#tab-fillup1"><span>Información Básica</span></a>
        </li>
        <li>
            <a data-toggle="tab" href="#tab-fillup2"><span>Perfil</span></a>
        </li>
    </ul>
    <!-- Tab panes -->
    <div class="tab-content">
        <div class="tab-pane active" id="tab-fillup1">
            @Html.DisplayNameFor(Function(model) model.Nombre): @Html.DisplayFor(Function(model) model.Nombre)<br/>
            @Html.DisplayNameFor(Function(model) model.Apellido): @Html.DisplayFor(Function(model) model.Apellido)<br/>
            @Html.DisplayNameFor(Function(model) model.Email): @Html.DisplayFor(Function(model) model.Email)<br/>
            @Html.DisplayNameFor(Function(model) model.NombreUsuario): @Html.DisplayFor(Function(model) model.NombreUsuario)<br/>
            @Html.DisplayNameFor(Function(model) model.Activo): @Html.DisplayFor(Function(model) model.Activo)
        </div>
        <div class="tab-pane" id="tab-fillup2">
            <div class="row">
                <div class="col-md-12">
                    <ul>
                        @For Each item In Model.ListaPerfiles
                            @<li>
                                @Html.ActionLink(item.Nombre, "Detalles", "Perfil", New With {.id = item.Id}, Nothing)
                            </li>  
                        Next
                    </ul>
                </div>
            </div>
        </div>
    </div>
</div>
<p>
    @Code
        If Model.NombreUsuario <> "admin" And User.IsInRole("EditarUsuario") Then
        @Html.ActionLink("Editar", "Editar", New With {.id = Model.Id}, New With {.class = "btn btn-primary btn-cons"})
        End If
        If Model.NombreUsuario <> "admin" And User.IsInRole("EliminarUsuario") Then
        @<button class="btn btn-primary btn-cons" data-target="#modalStickUpSmall" data-toggle="modal">Eliminar</button>
        End If
        If User.IsInRole("VerUsuarios") Then
        @Html.ActionLink("Volver", "Index", Nothing, New With {.class = "btn btn-default btn-cons"})
        End If
    End Code
</p>

<div class="modal fade stick-up" id="modalStickUpSmall" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-sm">
        <div class="modal-content-wrapper">
            <div class="modal-content">
                <div class="modal-header clearfix text-left">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        <i class="pg-close fs-14"></i>
                    </button>
                    <h5>Está seguro que desea eliminar el registro?</h5>
                </div>
                <div class="modal-body">
                    <p class="no-margin">Esto eliminará permanentemente el registro.</p>
                </div>
                <div class="modal-footer">
                    @Using Html.BeginForm("Eliminar", "Usuario", New With {.id = Model.Id}, FormMethod.Get)
                        @Html.AntiForgeryToken()
                        @<button type="submit" class="btn btn-primary btn-cons pull-left inline">Aceptar</button>
                    End Using
                    <button type="button" class="btn btn-default btn-cons no-margin pull-left inline" data-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
