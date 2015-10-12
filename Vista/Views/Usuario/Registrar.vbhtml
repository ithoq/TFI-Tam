@ModelType Vista.RegistrarViewModel

@section breadcrumb
    <ul class="breadcrumb">
        <li>
            <p>Inicio</p>
        </li>
        <li>
            <a href="#" class="active">Registrarse</a>
        </li>
    </ul>
end section

<div class="row">
    <div class="col-md-6">
        <!-- START PANEL -->
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="panel-title">
                    Formulario de registro de usuarios
                </div>
            </div>
            <div class="panel-body">
                @Using Html.BeginForm()
                    @Html.AntiForgeryToken()
                    @Html.ValidationSummary(True)
                    @<fieldset>
                        <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Nombre))),Nothing,"has-error")) ">
                            @Html.LabelFor(Function(model) model.Nombre)
                            @Html.TextBoxFor(Function(model) model.Nombre, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.Nombre, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Apellido))), Nothing, "has-error")) ">
                            @Html.LabelFor(Function(model) model.Apellido)
                            @Html.TextBoxFor(Function(model) model.Apellido, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.Apellido, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Email))), Nothing, "has-error")) ">
                            @Html.LabelFor(Function(model) model.Email)
                            @Html.TextBoxFor(Function(model) model.Email, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.Email, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.NombreUsu))), Nothing, "has-error"))">
                            @Html.LabelFor(Function(model) model.NombreUsu)
                            @Html.TextBoxFor(Function(model) model.NombreUsu, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.NombreUsu, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Clave))), Nothing, "has-error"))">
                            @Html.LabelFor(Function(model) model.Clave)
                            @Html.PasswordFor(Function(model) model.Clave, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.Clave, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.ConfirmaClave))), Nothing, "has-error"))">
                            @Html.LabelFor(Function(model) model.ConfirmaClave)
                            @Html.PasswordFor(Function(model) model.ConfirmaClave, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.ConfirmaClave, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="checkbox check-success required">
                             <input type="checkbox" checked="checked" value="1" id="checkbox2">
                             <label for="checkbox2">Acepto <a>términos y condiciones</a></label>
                        </div>
                        <button type="submit" class="btn btn-primary btn-cons">Grabar</button>
                    </fieldset>
                End Using
            </div>
        </div>
        <!-- END PANEL -->
    </div>
</div>


