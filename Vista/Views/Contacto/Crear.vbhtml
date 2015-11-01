@ModelType EE.Contacto

@section breadcrumb
    <ul class="breadcrumb">
        <li>
            <a href="@Url.Action("Index", "Home")">Inicio</a>
        </li>
        <li>
            <a class="active">Contacto</a>
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
                         <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.NombreApellido))), Nothing, "has-error")) ">
                             @Html.LabelFor(Function(model) model.NombreApellido)
                             @Html.TextBoxFor(Function(model) model.NombreApellido, New With {.class = "form-control"})
                             @Html.ValidationMessageFor(Function(model) model.NombreApellido, Nothing, New With {.class = "help-block"})
                         </div>
                         <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Email))), Nothing, "has-error")) ">
                             @Html.LabelFor(Function(model) model.Email)
                             @Html.TextBoxFor(Function(model) model.Email, New With {.class = "form-control"})
                             @Html.ValidationMessageFor(Function(model) model.Email, Nothing, New With {.class = "help-block"})
                         </div>
                         <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Asunto))), Nothing, "has-error")) ">
                             @Html.LabelFor(Function(model) model.Asunto)
                             @Html.TextBoxFor(Function(model) model.Asunto, New With {.class = "form-control"})
                             @Html.ValidationMessageFor(Function(model) model.Asunto, Nothing, New With {.class = "help-block"})
                         </div>
                         <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Mensaje))), Nothing, "has-error")) ">
                             @Html.LabelFor(Function(model) model.Mensaje)
                             @Html.TextAreaFor(Function(model) model.Mensaje, New With {.class = "form-control", .rows = 10, .style="height:auto;"})
                             @Html.ValidationMessageFor(Function(model) model.Mensaje, Nothing, New With {.class = "help-block"})
                         </div>
                        <button type="submit" class="btn btn-primary btn-cons">Enviar</button>
                    </fieldset>
                End Using
            </div>
        </div>
        <!-- END PANEL -->
    </div>
</div>


