@section breadcrumb
    <ul class="breadcrumb">
        <li>
            <p>Listado</p>
        </li>
        <li>
            <a class="active">Informe de Ganancias</a>
        </li>
    </ul>
end section

@section stylesheets
    <link href="~/Pages/assets/plugins/bootstrap-datepicker/css/datepicker3.css" rel="stylesheet" type="text/css" media="screen">
    <link href="~/Pages/assets/plugins/rickshaw/rickshaw.min.css" rel="stylesheet" type="text/css" />
End Section

<div class="panel panel-transparent">
    <div class="panel-heading">
        <div class="panel-title">
            Informe de Ganancias
        </div>
        <div class="clearfix"></div>
    </div>
    <div class="panel-body" id="gananciasPanelBody">
        <div class="row">
            <div class="col-lg-3">
                <div class="form-group">
                    <label>fecha desde/hasta</label>
                    <div class=" input-daterange input-group" id="datepicker-range">
                        <input type="text" class="form-control filtro" name="desde" id="desde" value="" />
                        <span class="input-group-addon">hasta</span>
                        <input type="text" class="form-control filtro" name="hasta" id="hasta" />
                    </div>
                </div>
            </div>
            <div class="col-lg-4">
                <div class="form-group">
                    <input type="button" class="btn btn-primary btn-cons" value="Generar Gráfico" style="margin-top:26px;" id="btnGenerar" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div id="rickshaw-stacked-bars" class="rickshaw-chart"></div>
            </div>
        </div>
    </div>
</div>

@Section javascripts_vendor
    <script src="~/Pages/assets/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js" type="text/javascript"></script>
    <script src="~/Pages/assets/plugins/nvd3/lib/d3.v3.js" type="text/javascript"></script>
    <script src="~/Pages/assets/plugins/rickshaw/rickshaw.min.js"></script>
End Section

@Section javascripts_custom
<script type="text/javascript">
    $(document).ready(function () {
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

        $("#btnGenerar").click(function () {
            var desde = $("#desde").val(),
                hasta = $("#hasta").val();
            if (desde != "" && typeof desde != "undefined" && hasta != "" && typeof hasta != "undefined") {
                $.ajax({
                    data: { desde: $("#desde").val(), hasta: $("#hasta").val() },
                    url: '@Url.Action("ObtenerGananciasAjax")',
                    type: 'post',
                    success: function (data) {
                        var graph = new Rickshaw.Graph({
                            renderer: 'bar',
                            element: document.querySelector("#rickshaw-stacked-bars"),
                            height: 500,
                            padding: {
                                top: 0.5
                            },
                            series: [{
                                data: data[0],
                                color: $.Pages.getColor('complete-light'), // Get Pages contextual color
                                name: "Ventas"
                            }]

                        });

                        var hoverDetail = new Rickshaw.Graph.HoverDetail({
                            graph: graph,
                            formatter: function (series, x, y) {
                                var date = '<span class="date">' + new Date(x * 1000).toUTCString() + '</span>';
                                var swatch = '<span class="detail_swatch" style="background-color: ' + series.color + '"></span>';
                                var content = swatch + series.name + ": " + parseInt(y) + '<br>' + date;
                                return content;
                            }
                        });
                    }
                });
            }
        });

    });
</script>
End Section