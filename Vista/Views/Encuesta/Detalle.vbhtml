@ModelType EE.Encuesta

@Section breadcrumb
    <ul class="breadcrumb">
        <li>
            <a href="@Url.Action("Index", "Encuesta")">Encuestas</a>
        </li>
        <li>
            <a class="active">Detalle</a>
        </li>
    </ul>
End Section

@Section javascripts_vendor
    |
    <script src="~/Pages/assets/plugins/jquery-sparkline/jquery.sparkline.min.js" type="text/javascript"></script>
End Section

<div class="panel panel-transparent ">
    <!-- Nav tabs -->
    <ul class="nav nav-tabs nav-tabs-fillup">
        <li class="active">
            <a data-toggle="tab" href="#tab-fillup1"><span>Información Básica</span></a>
        </li>
        <li>
            <a data-toggle="tab" href="#tab-fillup2"><span>Estadística</span></a>
        </li>
    </ul>
    <!-- Tab panes -->
    <div class="tab-content">
        <div class="tab-pane active" id="tab-fillup1">
            @Html.DisplayNameFor(Function(model) model.Tipo): @Html.DisplayFor(Function(model) model.Tipo)<br />
            @Html.DisplayNameFor(Function(model) model.FechaVigencia): @Html.DisplayFor(Function(model) model.FechaVigencia)<br />
            @Html.DisplayNameFor(Function(model) model.Pregunta): @Html.DisplayFor(Function(model) model.Pregunta)<br />
            <label>Respuestas:</label>
            <ul>
                @Code
                    For Each opcion As EE.Opcion In Model.ListaOpciones
                    @<li>@opcion.Valor</li>
                    Next
                End Code
            </ul>
        </div>
        <div class="tab-pane" id="tab-fillup2">
            <div class="row">
                <div class="col-md-8 col-md-offset-5">
                    <div id="sparkline-pie" class="sparkline-chart"></div>
                </div>
            </div>
        </div>
    </div>
</div>
<p>
    @Code
        If User.IsInRole("EditarEncuesta") Then
        @Html.ActionLink("Editar", "Editar", New With {.id = Model.Id}, New With {.class = "btn btn-primary btn-cons"})
        End If
        If User.IsInRole("EliminarEncuesta") Then
        @<button class="btn btn-primary btn-cons" data-target="#modalStickUpSmall" data-toggle="modal">Eliminar</button>
        End If
        If User.IsInRole("VerEncuestas") Then
        @Html.ActionLink("Volver", "Index", Nothing, New With {.class = "btn btn-default btn-cons"})
        End If
    End Code
</p>

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
                    @Using Html.BeginForm("Eliminar", "Encuesta", New With {.id = Model.Id}, FormMethod.Get)
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


@Section javascripts_custom
    <script type="text/javascript">
        var myvalues = @Html.Raw(ViewBag.ListaSelecciones);
        $('#sparkline-pie').sparkline(myvalues, {
            type: 'pie',
            width: '200px',
            height: '200px',
            sliceColors: ['#5d3092', '#4dc9ec', '#9de49d', '#9074b1', '#66aa00', '#dd4477', '#0099c6', '#990099'],
            borderWidth: 7,
            borderColor: '#f5f5f5',
            tooltipFormat: '<span style="color: {{color}}">&#9679;</span> {{offset:names}} ({{percent.1}}%)',
            tooltipValueLookups: {
                names: @Html.Raw(ViewBag.ListaNombres)
            }
        });
    </script>
End Section
