@ModelType SuscribirseViewModel

<div class="panel panel-default">
    <div class="panel-heading">
        <div class="panel-title">
            Newsletter
        </div>
    </div>
    <div class="panel-body">
        @code
            If TempData.ContainsKey("Info") Then
                @<div class="alert alert-success" role="alert">
                    <button class="close" data-dismiss="alert"></button>
                    <strong>Éxito: </strong>@TempData("Info")
                </div>
            End If
        End Code
        @Using Html.BeginForm()
            @<div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Email))), Nothing, "has-error")) ">
                @Html.LabelFor(Function(model) model.Email)
                @Html.TextBoxFor(Function(model) model.Email, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.Email, Nothing, New With {.class = "help-block"})
            </div>
            @<div class="form-group form-group-default form-group-default-select2 required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.ListaCategoriasSeleccionadas))), Nothing, "has-error"))">
                @Html.LabelFor(Function(model) model.ListaCategoriasSeleccionadas)
                @Html.ListBoxFor(Function(model) model.ListaCategoriasSeleccionadas, New MultiSelectList(ViewBag.Categorias, "Id", "Nombre"), New With {.style = "width: 100%;"})
                @Html.ValidationMessageFor(Function(model) model.ListaCategoriasSeleccionadas, Nothing, New With {.class = "help-block"})
            </div>
            @<button type="submit" class="btn btn-primary btn-cons">Suscribirse</button>
        End Using
    </div>
</div>