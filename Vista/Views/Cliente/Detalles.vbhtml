@ModelType EE.Usuario

@section breadcrumb
    <ul class="breadcrumb">
        <li>
            <a href="@Url.Action("Index", "Cliente")">Clientes</a>
        </li>
        <li>
            <a class="active">Detalles</a>
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
    </ul>
    <!-- Tab panes -->
    <div class="tab-content">
        <div class="tab-pane active" id="tab-fillup1">
            @Html.DisplayNameFor(Function(model) model.Nombre): @Html.DisplayFor(Function(model) model.Nombre)<br />
            @Html.DisplayNameFor(Function(model) model.Apellido): @Html.DisplayFor(Function(model) model.Apellido)<br />
            @Html.DisplayNameFor(Function(model) model.Email): @Html.DisplayFor(Function(model) model.Email)<br />
            @Html.DisplayNameFor(Function(model) model.NombreUsuario): @Html.DisplayFor(Function(model) model.NombreUsuario)<br />
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
                                @item.ObtenerImporte
                            </td>
                        </tr>
                        Next
                        End If
                    End Code
                </tbody>
            </table>
            <div class="pull-right m-t-10">
                Total: $
            </div>
        </div>
    </div>
    <p>
        @Code
            If Model.NombreUsuario <> "admin" And User.IsInRole("EditarCliente") Then
        @Html.ActionLink("Editar", "Editar", New With {.id = Model.Id}, New With {.class = "btn btn-primary btn-cons"})
            End If
            If Model.NombreUsuario <> "admin" And User.IsInRole("EliminarCliente") Then
        @<button class="btn btn-primary btn-cons" data-target="#modalStickUpSmall" data-toggle="modal">Eliminar</button>
            End If
            If User.IsInRole("VerClientes") Then
        @<br />
        @Html.ActionLink("Volver", "Index", Nothing, New With {.class = "btn btn-default btn-cons"})
            End If
        End Code
    </p>
</div>

<div class="modal fade stick-up" id="modalStickUpSmall" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-sm">
        <div class="modal-content-wrapper">
            <div class="modal-content">
                <div class="modal-header clearfix text-left">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        <i class="pg-close fs-14"></i>
                    </button>
                    <h5>Está seguro que desea eliminar el registro?</h5>
                </div>
                <div class="modal-body">
                    <p class="no-margin">Esto eliminará permanentemente el registro.</p>
                </div>
                <div class="modal-footer">
                    @Using Html.BeginForm("Eliminar", "Usuario", New With {.id = Model.Id}, FormMethod.Get)
                        @Html.AntiForgeryToken()
                        @<button type="submit" class="btn btn-primary btn-cons pull-left inline">Aceptar</button>
                        End Using
                    <button type="button" class="btn btn-default btn-cons no-margin pull-left inline" data-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>

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
    </script>
End Section
