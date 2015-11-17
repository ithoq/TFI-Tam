@ModelType EE.Usuario

@section breadcrumb
    <ul class="breadcrumb">
        <li>
            <a href="@Url.Action("Index", "Home")">Inicio</a>
        </li>
        <li>
            <a class="active">Mi cuenta</a>
        </li>
    </ul>
end section

@section stylesheets
    <link href="~/Pages/assets/plugins/jquery-datatable/media/css/jquery.dataTables.css" rel="stylesheet" type="text/css" />
    <link href="~/Pages/assets/plugins/jquery-datatable/extensions/FixedColumns/css/dataTables.fixedColumns.min.css" rel="stylesheet" type="text/css" />
    <link href="~/Pages/assets/plugins/datatables-responsive/css/datatables.responsive.css" rel="stylesheet" type="text/css" media="screen" />
End Section

<div class="panel panel-transparent ">
    <!-- Nav tabs -->
    <ul class="nav nav-tabs nav-tabs-fillup">
        <li class="active">
            <a data-toggle="tab" href="#tab-fillup1"><span>Información Básica</span></a>
        </li>
        <li>
            <a data-toggle="tab" href="#tab-fillup2"><span>Cuenta Corriente</span></a>
        </li>
        <li>
            <a data-toggle="tab" href="#tab-fillup3"><span>Mis Pedidos</span></a>
        </li>
    </ul>
    <!-- Tab panes -->
    <div class="tab-content">
        <div class="tab-pane active" id="tab-fillup1">
            @Html.DisplayNameFor(Function(model) model.Nombre): @Html.DisplayFor(Function(model) model.Nombre)<br />
            @Html.DisplayNameFor(Function(model) model.Apellido): @Html.DisplayFor(Function(model) model.Apellido)<br />
            @Html.DisplayNameFor(Function(model) model.Email): @Html.DisplayFor(Function(model) model.Email)<br />
            @Html.DisplayNameFor(Function(model) model.NombreUsuario): @Html.DisplayFor(Function(model) model.NombreUsuario)<br />
            @Html.DisplayNameFor(Function(model) model.Activo): @Html.DisplayFor(Function(model) model.Activo)
        </div>
        <div class="tab-pane" id="tab-fillup2">
            <table class="table table-hover" id="tablaMovimientos">
                <thead>
                    <tr>
                        <th>Tipo</th>
                        <th>Número</th>
                        <th>Observación</th>
                        <th>Importe</th>
                    </tr>
                </thead>
                <tbody>
                    @Code
                        If Model IsNot Nothing Then
                        @For Each item In Model.ListaMovimientos
                            @<tr>
                                <td>
                                    @item.ObtenerTipo
                                </td>
                                <td>
                                    @item.Numero
                                </td>
                                <td>
                                    @item.Observacion
                                </td>
                                <td>
                                    $@item.ObtenerImporte.ToString("0.00")
                                </td>
                            </tr>
                            Next
                        End If
                    End Code
                </tbody>
            </table>
            <div class="pull-right m-t-10">
                <h3>Total: $@Model.TotalCC.ToString("0.00")</h3>
            </div>
        </div>
        <div class="tab-pane" id="tab-fillup3">
            <table class="table table-hover" id="tablaPedidos">
                <thead>
                    <tr>
                        <th>N° de orden</th>
                        <th>Fecha Inicio</th>
                        <th>Fecha Fin</th>
                        <th>Importe</th>
                        <th>Estado</th>
                        <th>Acciones</th>
                    </tr>
                </thead>
                <tbody>
                    @For Each item In Model.ListaPedidos
                        @<tr>
                            <td>
                                @Html.DisplayFor(Function(modelItem) item.Id)
                            </td>
                            <td>
                                @item.FechaInicio
                            </td>
                            <td>
                                @IIf(item.FechaFin = Nothing, "", item.FechaFin)
                            </td>
                            <td>
                                $@item.Importe.ToString("0.00")
                            </td>
                            <td>
                                @Html.DisplayFor(Function(modelItem) item.Estado)
                            </td>
                            <td class="center">
                                @Code
                                If User.IsInRole("ConsultarPedido") Then
                                @Html.ActionLink("Ver", "Detalles", "Pedido", New With {.id = item.Id}, New With {.class = "btn btn-primary btn-cons"})
                                End If
                                End Code
                            </td>
                        </tr>
                    Next
                </tbody>
            </table>
        </div>
    </div>
</div>
<p>
    @Html.ActionLink("Cambiar contraseña", "CambiarClave", New With {.id = Model.Id}, New With {.class = "btn btn-primary btn-cons"})
</p>

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
        var table = $('#tablaMovimientos');
        var table1 = $('#tablaPedidos');

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

        table.DataTable(settings);
        table1.dataTable(settings);
    </script>
End Section




