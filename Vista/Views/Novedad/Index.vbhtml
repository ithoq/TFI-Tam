@ModelType IEnumerable(Of EE.Novedad)

@section breadcrumb
    <ul class="breadcrumb">
        <li>
            <p>Novedades</p>
        </li>
        <li>
            <a class="active">Listado</a>
        </li>
    </ul>
end section

@section stylesheets
    <link href="~/Pages/assets/plugins/jquery-datatable/media/css/jquery.dataTables.css" rel="stylesheet" type="text/css" />
    <link href="~/Pages/assets/plugins/jquery-datatable/extensions/FixedColumns/css/dataTables.fixedColumns.min.css" rel="stylesheet" type="text/css" />
    <link href="~/Pages/assets/plugins/datatables-responsive/css/datatables.responsive.css" rel="stylesheet" type="text/css" media="screen" />
End Section

<!-- START PANEL -->
@code
    If TempData.ContainsKey("Info") Then
    @<div class="alert alert-success" role="alert">
        <button class="close" data-dismiss="alert"></button>
        <strong>Éxito: </strong>@TempData("Info")
    </div>
End If
End Code
<div class="panel panel-transparent">
    <div class="panel-heading">
        <div class="panel-title">
            Listado de Novedades
        </div>
        <div class="clearfix"></div>
    </div>
    <div class="panel-body">
        <table class="table table-hover" id="tablaNovedades">
            <thead>
                <tr>
                    <th>Fecha Creación</th>
                    <th>Tipo</th>
                    <th>Título</th>
                    <th>Categoría</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
                @For Each item In Model
                    Dim currentItem = item
                    @<tr>
                        <td>
                            @Html.DisplayFor(Function(modelItem) currentItem.FechaCreacion)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) currentItem.Tipo)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) currentItem.Titulo)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) currentItem.Categoria.Nombre)
                        </td>
                        <td class="center">
                            @Code
                            If currentItem.Tipo = "Noticia" And User.IsInRole("EnviarNovedad") Then
                            @Html.ActionLink("Enviar", "Enviar", New With {.id = currentItem.Id}, New With {.class = "btn btn-primary btn-cons"})
                            End If

                            If User.IsInRole("ConsultarNovedad") Then
                            @Html.ActionLink("Ver", "Detalles", New With {.id = currentItem.Id}, New With {.class = "btn btn-primary btn-cons"})
                            End If
                            End Code
                        </td>
                    </tr>
                Next
            </tbody>
        </table>
    </div>
</div>
<!-- END PANEL -->
@section javascripts_vendor
    <script type="text/javascript" src="~/Pages/assets/plugins/bootstrap-select2/select2.min.js"></script>
    <script type="text/javascript" src="~/Pages/assets/plugins/classie/classie.js"></script>
    <script src="~/Pages/assets/plugins/switchery/js/switchery.min.js" type="text/javascript"></script>
    <script src="~/Pages/assets/plugins/jquery-datatable/media/js/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="~/Pages/assets/plugins/jquery-datatable/extensions/TableTools/js/dataTables.tableTools.min.js" type="text/javascript"></script>
    <script src="~/Pages/assets/plugins/jquery-datatable/extensions/Bootstrap/jquery-datatable-bootstrap.js" type="text/javascript"></script>
    <script type="text/javascript" src="~/Pages/assets/plugins/datatables-responsive/js/datatables.responsive.js"></script>
    <script type="text/javascript" src="~/Pages/assets/plugins/datatables-responsive/js/lodash.min.js"></script>
End Section

@section javascripts_custom
    <script type="text/javascript">
        var table = $('#tablaNovedades');

        var settings = {
            "sDom": "<'table-responsive't><'row'<p i>>",
            "sPaginationType": "bootstrap",
            "destroy": true,
            "scrollCollapse": true,
            "language": {
                "sProcessing": "Procesando...",
                "sLengthMenu": "Mostrar _MENU_ registros",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                "sInfoPostFix": "",
                "sSearch": "Buscar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                },
                "oAria": {
                    "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                    "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                }
            },
            "iDisplayLength": 10
        };

        table.dataTable(settings);
    </script>
End Section


