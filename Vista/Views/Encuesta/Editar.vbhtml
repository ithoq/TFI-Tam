@ModelType EE.Encuesta

@Section breadcrumb
    <ul class="breadcrumb">
        <li>
            <a href="@Url.Action("Index", "Encuesta")">Encuestas</a>
        </li>
        <li>
            <a class="active">Editar</a>
        </li>
    </ul>
End Section

@section stylesheets
    <link href="~/Pages/assets/plugins/summernote/css/summernote.css" rel="stylesheet" type="text/css" media="screen">
End Section

@Section javascripts_custom
    <script type="text/javascript">
        $(document).ready(function () {
            $("form").validate();
            $("#Tipo").select2();

            $("#agregarOpcion").click(function () {
                var id = guidGenerator();
                $("#respuestas").append(
                    "<div class='form-group'>" +
                        "<input type='hidden' name='ListaOpciones.Index' value='opcion-" + id + "' />" +
                        "<label class='control-label'>Opción</label>" +
                        "<div class='input-group'>" +
                            "<input type='text' class='form-control' name='ListaOpciones[opcion-" + id + "].Valor'>" +
                            "<span class='input-group-btn'>" +
                                "<button type='button' class='btn red eliminarOpcion' type='button'>Quitar</button>" +
                            "</span>" +
                        "</div>" +
                    "</div>"
                );
                $(".eliminarOpcion").click(function () {
                    $(this).parents(".form-group:first").remove();
                });
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

            $('#FechaVigencia').datepicker({
                language: "es",
                autoclose: true
            });

            $(".eliminarOpcion").click(function () {
                $(this).parents(".form-group:first").remove();
            });
        });

        function guidGenerator() {
            var S4 = function () {
                return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
            };
            return (S4() + S4() + "-" + S4() + "-" + S4() + "-" + S4() + "-" + S4() + S4() + S4());
        }
    </script>
End Section

<div class="row">
    <!-- START PANEL -->
    <div class="panel panel-default">
        <div class="panel-heading">
            <div class="panel-title">
                Encuestas
            </div>
        </div>
        <div class="panel-body">
            @Using Html.BeginForm()
                @Html.AntiForgeryToken()
                @Html.ValidationSummary(True)
                @<fieldset>
                    @Html.HiddenFor(Function(model) model.Id)
                    <div class="form-group form-group-default form-group-default-select2 required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Tipo))), Nothing, "has-error")) ">
                        @Html.LabelFor(Function(model) model.Tipo)
                        @Html.DropDownListFor(Function(model) model.Tipo, New List(Of SelectListItem)() From { _
                                New SelectListItem() With {.Text = "Encuesta", .Value = "Encuesta"},
                                New SelectListItem() With {.Text = "Ficha Opinion", .Value = "Ficha Opinion"}
                             }, "", New With {.class = "full-width select2-offscreen"})
                        @Html.ValidationMessageFor(Function(model) model.Tipo, Nothing, New With {.class = "help-block"})
                    </div>
                    <div class="form-group form-group-default input-group required @IIf(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.FechaVigencia))), Nothing, "has-error")">
                        @Html.LabelFor(Function(model) model.FechaVigencia)
                        @Html.TextBoxFor(Function(model) model.FechaVigencia, New With {.class = "form-control", .readonly = "readonly", .Value = Model.FechaVigencia.ToString("dd/MM/yyyy")})
                        <span class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </span>
                    </div>
                    @Html.ValidationMessageFor(Function(model) model.FechaVigencia, Nothing, New With {.class = "error m-b-10"})
                    <div class="form-group form-group-default required @IIf(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Pregunta))), Nothing, "has-error")">
                        @Html.LabelFor(Function(model) model.Pregunta)
                        @Html.TextBoxFor(Function(model) model.Pregunta, New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(model) model.Pregunta, Nothing, New With {.class = "help-block"})
                    </div>
                    <div class="form-group @IIf(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.ListaOpciones))), Nothing, "has-error")">
                        <label>Respuestas:</label>
                        <div id="respuestas">
                            @Code
                            For index = 0 To Model.ListaOpciones.Count() - 1
                            Dim id As String = Guid.NewGuid().ToString()
                            @<div class='form-group'>
                                <input type='hidden' name='ListaOpciones.Index' value='opcion-@id' />
                                <label class='control-label'>Opción</label>
                                <div class='input-group'>
                                    <input type='text' class='form-control' name='ListaOpciones[opcion-@id].Valor' value="@Model.ListaOpciones(index).Valor">
                                    <span class='input-group-btn'>
                                        <button type='button' class='btn red eliminarOpcion'>Quitar</button>
                                    </span>
                                </div>
                            </div>
                            Next
                            End Code
                        </div>
                        @Html.ValidationMessageFor(Function(model) model.ListaOpciones, Nothing, New With {.class = "help-block"})
                        <button type="button" class="btn btn-primary btn-cons" id="agregarOpcion">Agregar Opción...</button>
                    </div>
                    <button type="submit" class="btn btn-primary btn-cons">Grabar</button>
                </fieldset>
            End Using
        </div>
    </div>
    <!-- END PANEL -->
</div>
