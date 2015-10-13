@ModelType NovedadViewModel

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

@section stylesheets
    <link href="~/Pages/assets/plugins/summernote/css/summernote.css" rel="stylesheet" type="text/css" media="screen">
End Section

@section javascripts_custom
    <script type="text/javascript">
        $(document).ready(function () {
            $("#CategoriaId").select2();
            $("#Tipo").select2();

            $('#summernote').summernote({
                height: 200,
                onfocus: function (e) {
                    $('body').addClass('overlay-disabled');
                },
                onblur: function (e) {
                    $('body').removeClass('overlay-disabled');
                }
            });
            $('#formNovedad').submit(function () {
                var sHTML = $('#summernote').code();
                $('#Contenido').val(sHTML);
            });
        });
    </script>
End Section

<div class="row">
    <div class="col-md-12">
        <!-- START PANEL -->
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="panel-title">
                    Novedades
                </div>
            </div>
            <div class="panel-body">
                @Using Html.BeginForm("Crear", "Novedad", Nothing, FormMethod.Post, New With {.id = "formNovedad"})
                    @Html.AntiForgeryToken()
                    @Html.ValidationSummary(True)
                    @<fieldset>
                        <div class="form-group form-group-default form-group-default-select2 required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Tipo))), Nothing, "has-error"))">
                            @Html.LabelFor(Function(model) model.Tipo)
                            @Html.DropDownListFor(Function(model) model.Tipo, New List(Of SelectListItem)() From { _
                                New SelectListItem() With {.Text = "Noticia", .Value = "Noticia"},
                                New SelectListItem() With {.Text = "Novedad", .Value = "Novedad"}
                            }, "", New With {.class = "full-width select2-offscreen"})
                            @Html.ValidationMessageFor(Function(model) model.Tipo, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Titulo))), Nothing, "has-error")) ">
                            @Html.LabelFor(Function(model) model.Titulo)
                            @Html.TextBoxFor(Function(model) model.Titulo, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.Titulo, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group form-group-default form-group-default-select2 required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.CategoriaId))), Nothing, "has-error"))">
                            @Html.LabelFor(Function(model) model.CategoriaId)
                            @Html.DropDownListFor(Function(model) model.CategoriaId, New SelectList(ViewBag.Categorias, "Id", "Nombre"), "", New With {.class = "full-width select2-offscreen"})
                            @Html.ValidationMessageFor(Function(model) model.CategoriaId, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Contenido))), Nothing, "has-error")) ">
                            @Html.LabelFor(Function(model) model.Contenido)
                            <div class="summernote-wrapper">
                                <div id="summernote">

                                </div>
                            </div>
                            @Html.ValidationMessageFor(Function(model) model.Contenido, Nothing, New With {.class = "help-block"})
                        </div>
                        @Html.HiddenFor(Function(model) model.Contenido)
                        <button type="submit" class="btn btn-primary btn-cons">Grabar</button>
                    </fieldset>
                End Using
            </div>
        </div>
        <!-- END PANEL -->
    </div>
</div>

@section javascripts_vendor
    <script src="~/Pages/assets/plugins/summernote/js/summernote.min.js" type="text/javascript"></script>
End Section
