@ModelType IEnumerable(Of EE.Encuesta)

@Section breadcrumb
    <ul class="breadcrumb">
        <li>
            <p>Encuestas</p>
        </li>
        <li>
            <a class="active">Listado</a>
        </li>
    </ul>
End Section

@Section stylesheets
    <link href="~/Pages/assets/plugins/jquery-datatable/media/css/jquery.dataTables.css" rel="stylesheet" type="text/css" />
    <link href="~/Pages/assets/plugins/jquery-datatable/extensions/FixedColumns/css/dataTables.fixedColumns.min.css" rel="stylesheet" type="text/css" />
    <link href="~/Pages/assets/plugins/datatables-responsive/css/datatables.responsive.css" rel="stylesheet" type="text/css" media="screen" />
End Section

<!-- START PANEL -->
<div class="panel panel-transparent">
    <div class="panel-heading">
        <div class="panel-title">
            Listado de Encuestas
        </div>
        <div class="pull-right">
            <div class="col-xs-12">
                <!--<a class="btn btn-primary btn-cons" href="@Url.Action("Crear")"><i class="fa fa-plus"></i> Nuevo</a>-->
                @Code
                    If User.IsInRole("CrearEncuesta") Then
                    @<div class="btn-group">
                        <a href="@Url.Action("Crear")" class="btn btn-primary btn-cons">
                            Nuevo <i class="fa fa-plus"></i>
                        </a>
                    </div>
                    End If
                End Code
            </div>
        </div>
        <div class="clearfix"></div>
    </div>
    <div class="panel-body">
        <table class="table table-hover" id="tablaEncuestas">
            <thead>
                <tr>
                    <th>Fecha Vigencia</th>
                    <th>Tipo</th>
                    <th>Pregunta</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
                @For Each item In Model
                    Dim currentItem = item
                    @<tr>
                        <td>
                            @Html.DisplayFor(Function(modelItem) currentItem.FechaVigencia)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) currentItem.Tipo)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) currentItem.Pregunta)
                        </td>
                        <td class="center">
                            @Code
                            If User.IsInRole("ConsultarEncuesta") Then
                            @Html.ActionLink("Ver", "Detalle", New With {.id = currentItem.Id}, New With {.class = "btn btn-primary btn-cons"})
                            End If
                            End Code
                        </td>
                    </tr>
                Next
        </table>
    </div>
</div>
<!-- END PANEL -->

@Section javascripts_vendor
    <script type="text/javascript" src="~/Pages/assets/plugins/bootstrap-select2/select2.min.js"></script>
    <script type="text/javascript" src="~/Pages/assets/plugins/classie/classie.js"></script>
    <script src="~/Pages/assets/plugins/switchery/js/switchery.min.js" type="text/javascript"></script>
    <script src="~/Pages/assets/plugins/jquery-datatable/media/js/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="~/Pages/assets/plugins/jquery-datatable/extensions/TableTools/js/dataTables.tableTools.min.js" type="text/javascript"></script>
    <script src="~/Pages/assets/plugins/jquery-datatable/extensions/Bootstrap/jquery-datatable-bootstrap.js" type="text/javascript"></script>
    <script type="text/javascript" src="~/Pages/assets/plugins/datatables-responsive/js/datatables.responsive.js"></script>
    <script type="text/javascript" src="~/Pages/assets/plugins/datatables-responsive/js/lodash.min.js"></script>
End Section

@Section javascripts_custom
    <script type="text/javascript">
        var table = $('#tablaEncuestas');

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