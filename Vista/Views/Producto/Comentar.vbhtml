@ModelType EE.Comentario

@Code
    Layout = Nothing
End Code

@Using Html.BeginForm("Comentar", "Producto", FormMethod.Post)
    @Html.HiddenFor(Function(model) model.Producto.Id)
    @<div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Valoracion))), Nothing, "has-error"))" style="height:80px;">
        <label>Valoración</label>
        @Html.TextBoxFor(Function(model) model.Valoracion, New With {.type = "number", .class = "rating", .min = "0", .max = "5", .step="1", .data_glyphicon = "false", .data_size = "xs", .data_show_caption = "false"})
        @Html.ValidationMessageFor(Function(model) model.Valoracion, Nothing, New With {.class = "help-block"})
    </div>
    @<div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Mensaje))), Nothing, "has-error"))">
        <label>Mensaje</label>
        @Html.TextAreaFor(Function(model) model.Mensaje, New With {.class = "form-control", .rows = 10, .style="height:auto;"})
        @Html.ValidationMessageFor(Function(model) model.Mensaje, Nothing, New With {.class = "help-block"})
    </div>
    @<button type="submit" class="btn btn-primary btn-cons pull-right">Comentar</button>
End Using
