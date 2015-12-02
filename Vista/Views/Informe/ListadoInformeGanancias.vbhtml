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
                        <input type="text" class="form-control filtro" name="desde" id="desde" />
                        <span class="input-group-addon">hasta</span>
                        <input type="text" class="form-control filtro" name="hasta" id="hasta" />
                    </div>
                </div>
            </div>
            <div class="col-lg-4">
                <div class="form-group">
                    <input type="button" class="btn btn-primary btn-cons" value="Generar Gráfico" style="margin-top:26px;" id="btngenerar" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div id="divGrafico"></div>
            </div>
        </div>
    </div>
</div>

@Section javascripts_vendor
   <script src="~/Pages/assets/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js" type="text/javascript"></script>
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

        $.ajax({
            data: { categoriaId: $(this).val() },
            url: '@Url.Action("ListarGananciasAjax")',
            type: 'post',
            success: function (ganancias) {
                $("#gananciasPanelBody").html("");
                for (var index in ganancias) {
                    var ganancia = ganancias[index];
                    $("#gananciasPanelBody").append(
                        "<div class='panel bg-success-light text-white'>" +
                            "<div class='panel-default' role='tab' id='heading_" + novedad.Id + "'>" +
                                "<h4 class='panel-title text-black'>" +
                                    "<a data-toggle='collapse' data-parent='#accordion' href='#collapse_" + novedad.Id + "' aria-expanded='true' aria-controls='collapse_" + novedad.Id + "' class=''>" +
                                        novedad.Titulo +
                                    "</a>" +
                                "</h4>" +
                            "</div>" +
                            "<div id='collapse_" + novedad.Id + "' class='panel-collapse collapse in' role='tabpanel' aria-labelledby='heading_" + novedad.Id + "'>" +
                            "<div class='panel-body'>" +
                                novedad.Contenido +
                            "</div>" +
                        "</div>"
                    );
                }
            }
        });

    });
</script>
End Section