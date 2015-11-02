@ModelType IEnumerable(Of EE.Novedad)

@section breadcrumb
    <ul class="breadcrumb">
        <li>
            <a href="@Url.Action("Index", "Home")">Inicio</a>
        </li>
        <li>
            <a class="active">Listado de novedades</a>
        </li>
    </ul>
end section

<div class="row">
    <div class="col col-lg-9">
        <div class="panel panel-default bg-success-light text-white">
            <div class="panel-heading separator">
                <div class="panel-title">
                    <h3>Listado de novedades</h3>
                </div>
                <div class="form-group">
                    <label>Categoria</label>
                    <select class="full-width select2-offscreen filtro" id="cmbCategoria" name="cmbCategoria">
                        <option value=""></option>
                        @For Each Categoria As EE.Categoria In DirectCast(ViewBag.Categorias, IEnumerable(Of EE.Categoria))
                            @<option value="@Categoria.Id">@Categoria.Nombre</option>
                        Next
                    </select>
                </div>
            </div>
            <div class="panel-body" id="novedadesPanelBody">

                @For Each item In Model
                    Dim currentItem = item

                    @<div class="panel bg-success-light text-white">
                        <div class="panel-default" role="tab" id="heading_@currentItem.Id">
                            <h4 class="panel-title text-black">
                                <a data-toggle="collapse" data-parent="#accordion" href="#collapse_@currentItem.Id" aria-expanded="true" aria-controls="collapse_@currentItem.Id" class="">
                                    @currentItem.Titulo
                                </a>
                            </h4>
                        </div>
                        <div id="collapse_@currentItem.Id" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="heading_@currentItem.Id">
                            <div class="panel-body">
                                @Html.Raw(currentItem.Contenido)
                            </div>
                        </div>
                    </div>
                Next

            </div>
        </div>
    </div>
    <div class="col col-lg-3">
        @Code
            Html.RenderAction("Suscribirse", "Novedad")
        End Code
    </div>
</div>



@section javascripts_custom
    <script type="text/javascript">
    $(document).ready(function () {
        $("#ListaCategoriasSeleccionadas").select2();
        $("#cmbCategoria").select2();
        $("#cmbCategoria").change(function () {
            $.ajax({
                data: { categoriaId: $(this).val() },
                url: '@Url.Action("ListarNovedadesAjax")',
                type: 'post',
                success: function (novedades) {
                    $("#novedadesPanelBody").html("");
                    for (var index in novedades) {
                        var novedad = novedades[index];
                        $("#novedadesPanelBody").append(
                            "<div class='panel bg-success-light text-white'>" +
                                "<div class='panel-default' role='tab' id='heading_"+novedad.Id+"'>" +
                                    "<h4 class='panel-title text-black'>" +
                                        "<a data-toggle='collapse' data-parent='#accordion' href='#collapse_"+novedad.Id+"' aria-expanded='true' aria-controls='collapse_"+novedad.Id+"' class=''>" +
                                            novedad.Titulo +
                                        "</a>" +
                                    "</h4>" +
                                "</div>" +
                                "<div id='collapse_"+novedad.Id+"' class='panel-collapse collapse in' role='tabpanel' aria-labelledby='heading_"+novedad.Id+"'>" +
                                "<div class='panel-body'>" +
                                    novedad.Contenido +
                                "</div>" +
                            "</div>"
                        );
                    }
                }
            });
        });

    });
</script>
End Section
