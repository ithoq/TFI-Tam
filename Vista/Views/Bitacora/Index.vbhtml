@section breadcrumb
    <ul class="breadcrumb">
        <li>
            <p>Bitácora</p>
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
            Listado de Eventos
        </div>
        <div class="pull-right">
            <div class="col-xs-12">
                <input type="text" id="search-table" class="form-control pull-right" placeholder="Buscar">
            </div>
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
            <div class="col-lg-3">
                <div class="form-group">
                    <label>tipo</label>
                    <select class="full-width select2-offscreen filtro" id="cmbTipo">
                        <option value=""></option>
                        <option value="0">Advertencia</option>
                        <option value="1">Fallo</option>
                        <option value="2">Información</option>
                    </select>
                </div>
            </div>
            <div class="col-lg-3">
                <div class="form-group">
                    <label>desripcion</label>
                    <input type="text" class="form-control filtro" id="txtDescripcion" />
                </div>
            </div>
            <div class="col-lg-3">
                <div class="form-group">
                    <label>usuario</label>
                    <input type="text" class="form-control filtro" id="txtUsuario" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <table class="table table-hover" id="tablaBitacora">
                    <thead>
                        <tr>
                            <th>Fecha/Hora</th>
                            <th>Tipo</th>
                            <th>Descripción</th>
                            <th>Usuario</th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
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
        <script src="~/Pages/assets/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js" type="text/javascript"></script>
    End Section

    @section javascripts_custom
        <script type="text/javascript">
            var settings = {
                "processing": true,
                "serverSide": true,
                "ajax": {
                    "url": "@Url.Action("ListarAjax")",
                    "type": "POST",
                    "data": function (d) {
                        d.desde = $("#txtDesde").val();
                        d.hasta = $("#txtHasta").val();
                        d.tipoEvento = $("#cmbTipoEvento").val();
                        d.descripcion = $("#txtDescripcion").val();
                        d.usuario = $("#txtUsuario").val();
                    }
                },
                "columns": [
                    { "data": "FechaHora" },
                    { "data": "Tipo" },
                    { "data": "Descripcion" },
                    { "data": "Usuario" }
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

            var table = $('#tablaBitacora').DataTable(settings);

            $('#search-table').keyup(function () {
                table.search($(this).val()).draw();
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

            $('#cmbTipo').select2();

            $(".filtro").change(function () {
                table.draw();
            });

        </script>
    End Section
