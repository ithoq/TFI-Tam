@ModelType EE.Novedad

@section breadcrumb
    <ul class="breadcrumb">
        <li>
            <p>Novedad</p>
        </li>
        <li>
            <a href="#" class="active">Crear</a>
        </li>
    </ul>
end section

<div class="row">
    <div class="col-md-6">
        <!-- START PANEL -->
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="panel-title">
                    Contacto
                </div>
            </div>
            <div class="panel-body">
                @Using Html.BeginForm()
                    @Html.AntiForgeryToken()
                    @Html.ValidationSummary(True)
                    @<fieldset>
                        <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.FechaCreacion))), Nothing, "has-error")) ">
                            @Html.LabelFor(Function(model) model.FechaCreacion)
                            @Html.TextBoxFor(Function(model) model.FechaCreacion, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.FechaCreacion, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Titulo))), Nothing, "has-error")) ">
                            @Html.LabelFor(Function(model) model.Titulo)
                            @Html.TextBoxFor(Function(model) model.Titulo, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.Titulo, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Categoria))), Nothing, "has-error")) ">
                             @Html.LabelFor(Function(model) model.Categoria)
                             @Html.TextAreaFor(Function(model) model.Categoria, New With {.class = "form-control"})
                             @Html.ValidationMessageFor(Function(model) model.Categoria, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Contenido))), Nothing, "has-error")) ">
                            @Html.LabelFor(Function(model) model.Contenido)
                            @Html.TextBoxFor(Function(model) model.Contenido, New With {.class = "form-control", .rows = 10, .style = "height:auto;"})
                            @Html.ValidationMessageFor(Function(model) model.Contenido, Nothing, New With {.class = "help-block"})
                        </div>
                        <button type="submit" class="btn btn-primary btn-cons">Grabar</button>
                    </fieldset>
                End Using
            </div>
        </div>
        <!-- END PANEL -->
    </div>
</div>
