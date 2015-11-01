@ModelType EE.Idioma

@section breadcrumb
    <ul class="breadcrumb">
        <li>
            <a href="@Url.Action("Index", "Idioma")">Idiomas</a>
        </li>
        <li>
            <a class="active">Crear</a>
        </li>
    </ul>
end section

@section javascripts_custom
    <script type="text/javascript">
        $(document).ready(function () {
            $("#Id").select2();
        });
    </script>
End Section

<div class="row">
    <div class="col-md-12">
        <!-- START PANEL -->
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="panel-title">
                    Idioma
                </div>
            </div>
            <div class="panel-body">
                @Using Html.BeginForm()
                    @Html.AntiForgeryToken()
                    @Html.ValidationSummary(True)
                    @<fieldset>
                        <div class="form-group form-group-default form-group-default-select2 required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Id))), Nothing, "has-error"))">
                            @Html.LabelFor(Function(model) model.Id)
                            @Html.DropDownListFor(Function(model) model.Id, New SelectList(ViewBag.Idiomas, "Id", "Nombre"), "", New With {.class = "full-width select2-offscreen"})
                            @Html.ValidationMessageFor(Function(model) model.Id, Nothing, New With {.class = "help-block"})
                        </div>
                        <button type="submit" class="btn btn-primary btn-cons">Grabar</button>
                    </fieldset>
                End Using
            </div>
        </div>
        <!-- END PANEL -->
    </div>
</div>

