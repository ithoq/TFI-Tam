@ModelType IdiomaEditarViewModel

@Code
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

@Section javascripts_custom
    <script type="text/javascript">
        $(document).ready(function () {
            $('#IdiomasId').select2();
        });
    </script>
End Section

<div class="row">
    <div class="col-md-6">
        <!-- START PANEL -->
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="panel-title">
                    Editar Idiomas
                </div>
            </div>
            <div class="panel-body">
                @Using Html.BeginForm("Editar", "Idioma", Nothing, FormMethod.Post)
                    @Html.AntiForgeryToken()
                    @Html.ValidationSummary(True)
                    
                    @<div class="form-group">
                        <label>Idiomas Activos</label>
                         @Html.ListBoxFor(Function(model) model.IdiomasId, New MultiSelectList(ViewBag.ListaIdiomas, "Id", "Nombre", Model.IdiomasId), New With {.style = "width: 100%;"})
                    </div>
                    @<div class="form-actions">
                        <button type="submit" class="btn blue">Grabar</button>
                    </div>
                End Using
            </div>
        </div>
        <!-- END PANEL -->
    </div>
</div>