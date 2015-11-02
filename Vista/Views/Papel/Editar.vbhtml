@ModelType EE.Papel

@section breadcrumb
    <ul class="breadcrumb">
        <li>
            <a href="@Url.Action("Index", "Papel")">Papeles</a>
        </li>
        <li>
            <a class="active">Editar</a>
        </li>
    </ul>
end section

<div class="row">
    <div class="col-md-6">
        <!-- START PANEL -->
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="panel-title">
                    Edición de papeles
                </div>
            </div>
            <div class="panel-body">
                @Using Html.BeginForm()
                    @Html.AntiForgeryToken()
                    @Html.ValidationSummary(True)
                    @<fieldset>
                        @Html.HiddenFor(Function(model) model.Id)
                        <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Espesor))), Nothing, "has-error")) ">
                            @Html.LabelFor(Function(model) model.Espesor)
                            @Html.TextBoxFor(Function(model) model.Espesor, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.Espesor, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Color))), Nothing, "has-error")) ">
                            @Html.LabelFor(Function(model) model.Color)
                            @Html.TextBoxFor(Function(model) model.Color, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.Color, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Nombre))), Nothing, "has-error")) ">
                            @Html.LabelFor(Function(model) model.Nombre)
                            @Html.TextBoxFor(Function(model) model.Nombre, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.Nombre, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Precio))), Nothing, "has-error"))">
                            @Html.LabelFor(Function(model) model.Precio)
                            @Html.TextBoxFor(Function(model) model.Precio, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.Precio, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Tipo))), Nothing, "has-error"))">
                            @Html.LabelFor(Function(model) model.Tipo)
                            @Html.TextBoxFor(Function(model) model.Tipo, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.Tipo, Nothing, New With {.class = "help-block"})
                        </div>
                        <button type="submit" class="btn btn-primary btn-cons">Grabar</button>
                        @Html.ActionLink("Volver", "Index", Nothing, New With {.class = "btn btn-default btn-cons"})
                    </fieldset>
                End Using
            </div>
        </div>
        <!-- END PANEL -->
    </div>
</div>
