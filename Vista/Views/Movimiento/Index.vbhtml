@ModelType IEnumerable(Of EE.Movimiento)

@section breadcrumb
    <ul class="breadcrumb">
        <li>
            <p>Movimientos</p>
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
    <link href="~/Pages/assets/plugins/bootstrap-datepicker/css/datepicker3.css" rel="stylesheet" type="text/css" media="screen">
End Section

<!-- START PANEL -->
<div class="panel panel-transparent">
    <div class="panel-heading">
        <div class="panel-title">
            Listado de movimientos
        </div>
        <div class="clearfix"></div>
    </div>
    <div class="panel-body">
        <div class="row">
            <div class="col-lg-3">
                <div class="form-group">
                    <label>fecha desde/hasta</label>
                    <div class=" input-daterange input-group" id="datepicker-range">
                        <input type="text" class="form-control filtro" name="start" id="txtDesde" />
                        <span class="input-group-addon">hasta</span>
                        <input type="text" class="form-control filtro" name="end" id="txtHasta" />
                    </div>
                </div>
            </div>
            <div class="col-lg-4">
                <div class="form-group">
                    <label>Tipo</label>
                    <select class="filtro full-width select2-offscreen" name="tipo" id="txtTipo" multiple="multiple">
                        <option value="Factura A">Factura A</option>
                        <option value="Factura B">Factura B</option>
                        <option value="Pago MasterCard">Pago MasterCard</option>
                        <option value="Pago Visa">Pago Visa</option>
                        <option value="Pago American Express">Pago American Express</option>
                        <option value="Nota de Crédito A">Nota de Crédito A</option>
                        <option value="Nota de Débito A">Nota de Débito A</option>
                    </select>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <table class="table table-hover" id="tablaMovimientos">
                    <thead>
                        <tr>
                            <th>Número</th>
                            <th>Tipo</th>
                            <th>Observación</th>
                            <th>Importe</th>
                            <th>Usuario</th>
                            <th>Fecha</th>
                            <th>Acciones</th>
                        </tr>
                    </thead>
                </table>    
                <h3 class="pull-right" id="TotalMovimientos"></h3>
            </div>
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
    <script src="~/Pages/assets/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js" type="text/javascript"></script>
End Section

@Section javascripts_custom
    <script type="text/javascript">
        $(document).ready(function () {
            var settings = {
                "processing": true,
                "serverSide": true,
                "ajax": {
                    "url": "@Url.Action("ListarAjax")",
                    "type": "POST",
                    "data": function (d) {
                        d.desde = $("#txtDesde").val();
                        d.hasta = $("#txtHasta").val();
                        d.tipo = $("#txtTipo").val();
                    }
                },
                "columns": [
                    { "data": "Numero" },
                    { "data": "Tipo" },
                    { "data": "Observacion" },
                    { "data": "Importe" },
                    { "data": "Usuario" },
                    { "data": "Fecha" },
                    {
                        "data": "Acciones", "searchable": false, "orderable": false, "className": "text-center", "render": function (data, type, row) {
                            var parameters = data.split(" ");
                            return "<a href='/Movimiento/GenerarPdf?tipo=" + parameters[0] + "&numero=" + parameters[2] + "&tipoComprobante=" + parameters[1] + "' class='btn btn-primary btn-cons'>Exportar</a>"
                        }
                    }
                ],
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

            var table = $('#tablaMovimientos').DataTable(settings);
            
            table.on("xhr", function () {
                var json = table.ajax.json();
                $("#TotalMovimientos").html("Total: $" + json.total);
            });

            $.fn.datepicker.dates['es'] = {
                days: ["Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado"],
                daysShort: ["Dom", "Lun", "Mar", "Mié", "Jue", "Vie", "Sáb"],
                daysMin: ["Do", "Lu", "Ma", "Mi", "Ju", "Vi", "Sa"],
                months: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
                monthsShort: ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"],
                today: "Hoy",
                clear: "Borrar",
                weekStart: 1,
                format: "dd/mm/yyyy"
            };

            //Date Pickers
            $('#datepicker-range').datepicker({
                language: 'es'
            });

            $("#txtTipo").select2();

            $(".filtro").change(function () {
                table.draw();
            });
  
        });

    </script>
End Section




