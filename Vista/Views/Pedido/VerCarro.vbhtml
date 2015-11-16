@ModelType EE.Pedido

@Section breadcrumb
    <ul class="breadcrumb">
        <li>
            <p>Pedidos</p>
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
            Pedido
        </div>
        <div class="clearfix"></div>
    </div>
    <div class="panel-body">
        <table class="table table-hover" id="tablaPedidos">
            <thead>
                <tr>
                    <th>Imagen</th>
                    <th>Producto</th>
                    <th>Cantidad</th>
                    <th>Precio Unitario</th>
                    <th>Total</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
                @Code
                    If Model IsNot Nothing Then
                @For Each item In Model.ListaPedidos
                    @<tr>
                        <td>
                            <img class="img-responsive" style="width: 100px; height: 100px;" src="@item.Producto.Fondo" />
                        </td>
                        <td>
                            @item.Producto.Nombre
                        </td>
                        <td>
                            @item.Cantidad
                        </td>
                        <td>
                            $@item.Producto.ObtenerPrecioConIva()
                        </td>
                        <td>
                            $@item.Total
                        </td>
                        <td class="center">
                            @Code
                                @Html.ActionLink("Quitar", "Quitar", "Pedido", New With {.id = item.Producto.Id}, New With {.class = "btn btn-primary btn-cons"})
                            End Code
                        </td>
                    </tr>
                    Next
                    End If
                End Code
            </tbody>
        </table>
        <div class="pull-right m-t-10">
            <h3>Total: $@Model.Importe</h3>
        </div>
        <br />
        <div class="pull-right m-t-10">
            @If User IsNot Nothing Then
                @Html.ActionLink("Comenzar Compra", "Comprar", "Pedido", New With {.class = "btn btn-primary btn-cons pull-right"})
            End If
        </div>
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
        var table = $('#tablaPedidos');

        var settings = {
            "sDom": "<'table-responsive't>",
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
            "iDisplayLength": 10000000000000
        };

        table.dataTable(settings);
    </script>
End Section
