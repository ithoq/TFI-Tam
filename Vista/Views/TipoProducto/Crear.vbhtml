@ModelType EE.TipoProducto

@section breadcrumb
    <ul class="breadcrumb">
        <li>
            <a href="@Url.Action("Index", "TipoProducto")">Tipos de Productos</a>
        </li>
        <li>
            <a class="active">Crear</a>
        </li>
    </ul>
end section

<div class="row">
    <div class="col-md-6">
        <!-- START PANEL -->
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="panel-title">
                    Creación de tipos de productos
                </div>
            </div>
            <div class="panel-body">
                @Using Html.BeginForm()
                    @Html.AntiForgeryToken()
                    @Html.ValidationSummary(True)
                    @<fieldset>
                        <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Tipo))), Nothing, "has-error")) ">
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

