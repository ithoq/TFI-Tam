@ModelType EE.Producto

@section breadcrumb
    <ul class="breadcrumb">
        <li>
            <a href="@Url.Action("Index", "Producto")">Productos</a>
        </li>
        <li>
            <a class="active">Editar</a>
        </li>
    </ul>
end section

@section javascripts_custom
    <script type="text/javascript">
        $(document).ready(function () {
            $("#Tema_Id").select2();
            $("#TipoProducto").select2();
            $("#Papel_Id").select2();
            $("#Cartucho_Id").select2();
        });
    </script>
End Section

<div class="row">
    <div class="col-md-6">
        <!-- START PANEL -->
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="panel-title">
                    Edición de productos
                </div>
            </div>
            <div class="panel-body">
                @Using Html.BeginForm("Editar", "Producto", FormMethod.Post, New With {.enctype = "multipart/form-data"})
                    @Html.AntiForgeryToken()
                    @Html.ValidationSummary(True)
                    @<fieldset>
                        @Html.HiddenFor(Function(model) model.Id)
                         <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Nombre))), Nothing, "has-error")) ">
                             @Html.LabelFor(Function(model) model.Nombre)
                             @Html.TextBoxFor(Function(model) model.Nombre, New With {.class = "form-control"})
                             @Html.ValidationMessageFor(Function(model) model.Nombre, Nothing, New With {.class = "help-block"})
                         </div>
                         <div class="form-group form-group-default form-group-default-select2 required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Papel.Id))), Nothing, "has-error"))">
                             <label>Papel</label>
                             @Html.DropDownListFor(Function(model) model.Papel.Id, New SelectList(ViewBag.Papeles, "Id", "Nombre"), "", New With {.class = "full-width select2-offscreen"})
                             @Html.ValidationMessageFor(Function(model) model.Papel.Id, Nothing, New With {.class = "help-block"})
                         </div>
                         <div class="form-group form-group-default form-group-default-select2 required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Cartucho.Id))), Nothing, "has-error"))">
                             <label>Cartucho</label>
                             @Html.DropDownListFor(Function(model) model.Cartucho.Id, New SelectList(ViewBag.Cartuchos, "Id", "Nombre"), "", New With {.class = "full-width select2-offscreen"})
                             @Html.ValidationMessageFor(Function(model) model.Cartucho.Id, Nothing, New With {.class = "help-block"})
                         </div>
                         <div class="form-group form-group-default form-group-default-select2 required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Tema.Id))), Nothing, "has-error"))">
                             @Html.LabelFor(Function(model) model.Tema)
                             @Html.DropDownListFor(Function(model) model.Tema.Id, New SelectList(ViewBag.Temas, "Id", "Tema"), "", New With {.class = "full-width select2-offscreen"})
                             @Html.ValidationMessageFor(Function(model) model.Tema.Id, Nothing, New With {.class = "help-block"})
                         </div>
                         <div class="form-group form-group-default form-group-default-select2 required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.TipoProducto))), Nothing, "has-error"))">
                             @Html.LabelFor(Function(model) model.TipoProducto)
                             @Html.DropDownListFor(Function(model) model.TipoProducto, [Enum].GetValues(GetType(EE.TipoProducto)).Cast(Of EE.TipoProducto)().Select(Function(x) New SelectListItem() With {.Value = Convert.ToInt16(x).ToString(), .Text = DirectCast(x.GetType().GetField(x.ToString()).GetCustomAttributes(GetType(System.ComponentModel.DescriptionAttribute), False)(0), System.ComponentModel.DescriptionAttribute).Description}), New With {.class = "full-width select2-offscreen"})
                             @Html.ValidationMessageFor(Function(model) model.TipoProducto, Nothing, New With {.class = "help-block"})
                         </div>
                         <div class="form-group">
                             <label for="Archivo" class="control-label">Fondo</label>
                             <input type="file" name="Archivo" />
                             @Html.ValidationMessage("Archivo", New With {.class = "help-block"})
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

