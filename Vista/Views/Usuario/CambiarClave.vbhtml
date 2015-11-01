@ModelType Vista.CambioClaveViewModel

@section breadcrumb
    <ul class="breadcrumb">
        <li>
            <a href="@Url.Action("Index", "Usuario")">Usuarios</a>
        </li>
        <li>
            <a class="active">Cambiar clave</a>
        </li>
    </ul>
end section

<div class="row">
    <div class="col-md-6">
        <!-- START PANEL -->
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="panel-title">
                    Cambio de clave de cuenta
                </div>
            </div>
            <div class="panel-body">
                @Using Html.BeginForm()
                    @Html.AntiForgeryToken()
                    @Html.ValidationSummary(True)
                    @<fieldset>
                        <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.ClaveVieja))), Nothing, "has-error")) ">
                            @Html.LabelFor(Function(model) model.ClaveVieja)
                            @Html.PasswordFor(Function(model) model.ClaveVieja, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.ClaveVieja, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.ClaveNueva))), Nothing, "has-error")) ">
                            @Html.LabelFor(Function(model) model.ClaveNueva)
                            @Html.PasswordFor(Function(model) model.ClaveNueva, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.ClaveNueva, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.RepetirClave))), Nothing, "has-error")) ">
                            @Html.LabelFor(Function(model) model.RepetirClave)
                            @Html.PasswordFor(Function(model) model.RepetirClave, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.RepetirClave, Nothing, New With {.class = "help-block"})
                        </div>
                        <button type="submit" class="btn btn-primary btn-cons">Grabar</button>
                    </fieldset>
                End Using
            </div>
        </div>
        <!-- END PANEL -->
    </div>
</div>



