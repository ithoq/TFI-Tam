﻿@ModelType Vista.ComprarViewModel

@Section breadcrumb
    <ul class="breadcrumb">
        <li>
            <a href="@Url.Action("Index", "Home")">Home</a>
        </li>
        <li>
            <a class="active">Pedido</a>
        </li>
    </ul>
End Section

@Section javascripts_custom
    <script type="text/javascript">
        $(document).ready(function () {

            var aNumero = function (valor) {
                if (valor != "" && typeof valor != "undefined") {
                    var conPunto = valor.replace(",", ".");
                    //var sinPesos = conPunto.replace("$", "");
                    var decimal = parseFloat(conPunto);
                    var dosDecimalTexto = decimal.toFixed(2);
                    return parseFloat(dosDecimalTexto);
                }
                return 0;
            };

            var aTexto = function (valor) {
                var conComa = valor.toFixed(2).replace(".", ",");
                //var conPesos = "$" + conComa;
                return conComa;
            };


            $("#TarjetaNombre").select2();
            $("#TarjetaCuotas").select2();
            $("#ClienteCondicion").select2();

            $("#ClienteCondicion").change(function () {
                if ($(this).val() == "Responsable Inscripto") {
                    $("#FacturacionTipoComprobante").val("A");
                    $("#ClienteCuit").attr("disabled", false);
                } else {
                    $("#FacturacionTipoComprobante").val("B");
                    $("#ClienteCuit").val("").attr("disabled", true);
                }
            });

            $("#PagoConNC").change(function () {
                var importeTotal = aNumero($("#ImporteTotal").val());
                if ($(this).is(":checked")) {
                    var saldoAFavor = aNumero($("#SaldoAFavor").val());
                    var importeTarjeta = importeTotal - saldoAFavor;
                    if (importeTarjeta <= 0) {
                        $("#TarjetaImporte").val(0);
                        $("#CampoTarjeta").hide();
                    } else {
                        $("#TarjetaImporte").val(aTexto(importeTarjeta));
                        $("#CampoTarjeta").show();
                    }
                } else {
                    $("#TarjetaImporte").val(aTexto(importeTotal));
                    $("#CampoTarjeta").show();
                }
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
                format: "mm/yyyy"
            };

            $('.date-picker').datepicker({
                language: "es",
                autoclose: true,
                format: "mm/yyyy",
                startView: "months",
                minViewMode: "months"
            });

            $("#ClienteCondicion").trigger("change");
            $("#PagoConNC").trigger("change");

            var saldoAFavor = $("#SaldoAFavor").val();
            if (saldoAFavor = "0") {
                $("#campoPagoNC").hide();
            }
        });
    </script>
End Section
@Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)
    
    @<div class="panel panel-transparent">
        <div class="panel-heading">
            <div class="panel-title">
                Nuevo Pedido
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-6">
                    <div class="panel panel-default bg-success" style="color: #626262;">
                        <div class="panel-heading separator">
                            <div class="panel-title">
                                Información de Cliente
                            </div>
                        </div>
                        <div class="panel-body">
                            <fieldset>
                                <div class="form-group form-group-default required m-t-20 @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.ClienteCondicion))), Nothing, "has-error"))">
                                    <label class="">Condición frente al IVA:</label>
                                    @Html.DropDownListFor(Function(model) model.ClienteCondicion, New List(Of SelectListItem)() From { _
                                                New SelectListItem() With {.Text = "Responsable Inscripto", .Value = "Responsable Inscripto"},
                                                New SelectListItem() With {.Text = "Monotributista", .Value = "Monotributista"},
                                                New SelectListItem() With {.Text = "Consumidor Final", .Value = "Consumidor Final"}
                                                }, "", New With {.class = "form-control"})
                                    @Html.ValidationMessageFor(Function(model) model.ClienteCondicion, Nothing, New With {.class = "help-block"})
                                </div>
                                <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.ClienteCuit))), Nothing, "has-error"))">
                                    <label class="">CUIT:</label>
                                    @Html.TextBoxFor(Function(model) model.ClienteCuit, New With {.class = "form-control", .placeholder = "XX-XXXXXXXX-X"})
                                    @Html.ValidationMessageFor(Function(model) model.ClienteCuit, Nothing, New With {.class = "help-block"})
                                </div>
                                <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.ClienteNombre))), Nothing, "has-error"))">
                                    <label class="">Nombre:</label>
                                    @Html.TextBoxFor(Function(model) model.ClienteNombre, New With {.class = "form-control"})
                                    @Html.ValidationMessageFor(Function(model) model.ClienteNombre, Nothing, New With {.class = "help-block"})
                                </div>
                                <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.ClienteTelefono))), Nothing, "has-error"))">
                                    <label class="">Teléfono:</label>
                                    @Html.TextBoxFor(Function(model) model.ClienteTelefono, New With {.class = "form-control"})
                                    @Html.ValidationMessageFor(Function(model) model.ClienteTelefono, Nothing, New With {.class = "help-block"})
                                </div>
                                <div class="form-group form-group-default">
                                    <label class="">Email:</label>
                                    @Html.TextBoxFor(Function(model) User.Email, New With {.class = "form-control", .disabled = "disabled"})
                                </div>
                            </fieldset>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="panel panel-default bg-complete" style="color: #626262;">
                        <div class="panel-heading separator">
                            <div class="panel-title">
                                Dirección de Envío
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="form-group form-group-default required m-t-20 @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.DireccionCalle))), Nothing, "has-error"))">
                                <label class="">Calle:</label>
                                @Html.TextBoxFor(Function(model) model.DireccionCalle, New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.DireccionCalle, Nothing, New With {.class = "help-block"})
                            </div>
                            <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.DireccionNumero))), Nothing, "has-error"))">
                                <label class="">Número:</label>
                                @Html.TextBoxFor(Function(model) model.DireccionNumero, New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.DireccionNumero, Nothing, New With {.class = "help-block"})
                            </div>
                            <div class="form-group form-group-default @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.DireccionDptoPiso))), Nothing, "has-error"))">
                                <label class="">Dpto/Piso:</label>
                                @Html.TextBoxFor(Function(model) model.DireccionDptoPiso, New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.DireccionDptoPiso, Nothing, New With {.class = "help-block"})
                            </div>
                            <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.DireccionLocalidad))), Nothing, "has-error"))">
                                <label class="">Localidad:</label>
                                @Html.TextBoxFor(Function(model) model.DireccionLocalidad, New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.DireccionLocalidad, Nothing, New With {.class = "help-block"})
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="panel panel-default">
                        <div class="panel-heading separator">
                            <div class="panel-title">
                                Pago
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="row" id="campoPagoNC">
                                <div class="col-md-6 col-sm-12">
                                    <div class="form-group form-group-default m-t-20 @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.PagoConNC))), Nothing, "has-error"))">
                                        @Html.CheckBoxFor(Function(model) model.PagoConNC) Pagar con notas de crédito?
                                        @Html.ValidationMessageFor(Function(model) model.PagoConNC, Nothing, New With {.class = "help-block"})
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-12">
                                    <div class="form-group form-group-default required m-t-20 @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.SaldoAFavor))), Nothing, "has-error"))">
                                        <label class="">Saldo a favor:</label>
                                        @Html.TextBoxFor(Function(model) model.SaldoAFavor, New With {.class = "form-control", .disabled = "disabled"})
                                        @Html.ValidationMessageFor(Function(model) model.SaldoAFavor, Nothing, New With {.class = "help-block"})
                                    </div>
                                </div>
                            </div>
                            <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.TarjetaImporte))), Nothing, "has-error"))">
                                <label class="">Importe a pagar en tarjeta:</label>
                                @Html.TextBoxFor(Function(model) model.TarjetaImporte, New With {.class = "form-control", .disabled = "disabled"})
                                @Html.ValidationMessageFor(Function(model) model.TarjetaImporte, Nothing, New With {.class = "help-block"})
                            </div>
                            <hr />
                            <div id="CampoTarjeta">
                                <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.TarjetaTitular))), Nothing, "has-error"))">
                                    <label class="">Nombre del titular:</label>
                                    @Html.TextBoxFor(Function(model) model.TarjetaTitular, New With {.class = "form-control"})
                                    @Html.ValidationMessageFor(Function(model) model.TarjetaTitular, Nothing, New With {.class = "help-block"})
                                </div>
                                <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.TarjetaNombre))), Nothing, "has-error"))">
                                    <label class="">Medio de pago:</label>
                                    @Html.DropDownListFor(Function(model) model.TarjetaNombre, New List(Of SelectListItem)() From { _
                                                New SelectListItem() With {.Text = "Visa", .Value = "Visa"},
                                                New SelectListItem() With {.Text = "MasterCard", .Value = "MasterCard"},
                                                New SelectListItem() With {.Text = "AmericanExpress", .Value = "AmericanExpress"}
                                                }, "", New With {.class = "form-control"})
                                    @Html.ValidationMessageFor(Function(model) model.TarjetaNombre, Nothing, New With {.class = "help-block"})
                                </div>
                                <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.TarjetaCuotas))), Nothing, "has-error"))">
                                    <label class="">Cuotas:</label>
                                    @Html.DropDownListFor(Function(model) model.TarjetaCuotas, New List(Of SelectListItem)() From { _
                                                New SelectListItem() With {.Text = "1", .Value = "1"},
                                                New SelectListItem() With {.Text = "3", .Value = "3"},
                                                New SelectListItem() With {.Text = "6", .Value = "6"},
                                                New SelectListItem() With {.Text = "12", .Value = "12"}
                                                }, "", New With {.class = "form-control"})
                                    @Html.ValidationMessageFor(Function(model) model.TarjetaCuotas, Nothing, New With {.class = "help-block"})
                                </div>
                                <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.TarjetaNumero))), Nothing, "has-error"))">
                                    <label class="">Número:</label>
                                    @Html.TextBoxFor(Function(model) model.TarjetaNumero, New With {.class = "form-control", .placeholder = "XXXXXXXXXXXXXXXX"})
                                    @Html.ValidationMessageFor(Function(model) model.TarjetaNumero, Nothing, New With {.class = "help-block"})
                                </div>
                                <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.TarjetaCodigoSeguridad))), Nothing, "has-error"))">
                                    <label class="">Código de Seguridad:</label>
                                    @Html.TextBoxFor(Function(model) model.TarjetaCodigoSeguridad, New With {.class = "form-control", .placeholder = "XXX"})
                                    @Html.ValidationMessageFor(Function(model) model.TarjetaCodigoSeguridad, Nothing, New With {.class = "help-block"})
                                </div>
                                <div class="form-group form-group-default required @IIf(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.TarjetaFechaVencimiento))), Nothing, "has-error")">
                                    <label class="">Fecha de Vencimiento:</label>
                                    <div class="input-group date date-picker" data-date-format="mm/yyyy" data-date-start-date="+0d">
                                        @Html.TextBoxFor(Function(model) model.TarjetaFechaVencimiento, New With {.class = "form-control", .readonly = "readonly", .Value = Model.TarjetaFechaVencimiento.ToString("MM/yyyy")})
                                        <span class="input-group-btn">
                                            <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                        </span>
                                    </div>

                                    @Html.ValidationMessageFor(Function(model) model.TarjetaFechaVencimiento, Nothing, New With {.class = "help-block"})
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="panel panel-default bg-primary" style="color: #626262;">
                        <div class="panel-heading separator">
                            <div class="panel-title">
                                Facturación
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="form-group form-group-default m-t-20 @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.FacturacionTipoComprobante))), Nothing, "has-error"))">
                                <label>Tipo de Factura:</label>
                                @Html.TextBoxFor(Function(model) model.FacturacionTipoComprobante, New With {.class = "form-control", .disabled = "disabled"})
                                @Html.ValidationMessageFor(Function(model) model.FacturacionTipoComprobante, Nothing, New With {.class = "help-block"})
                            </div>
                            <div class="form-group form-group-default">
                                <label class="">Subtotal:</label>
                                <input type="text" value="@Model.Pedido.Subtotal" class="form-control" disabled />
                            </div>
                            <div class="form-group form-group-default">
                                <label class="">Iva:</label>
                                <input type="text" value="@Model.Pedido.Iva" class="form-control" disabled />
                            </div>
                            <div class="form-group form-group-default">
                                <label class="">Total:</label>
                                <input type="text" id="ImporteTotal" value="@Model.Pedido.Importe" class="form-control" disabled />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <div class="panel panel-default">
                        <div class="panel-heading separator">
                            <div class="panel-title">
                                Detalle del Pedido
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive m-t-20">
                                <table class="table table-hover table-bordered table-striped">
                                    <thead>
                                        <tr>
                                            <th>Producto</th>
                                            <th>Cantidad</th>
                                            <th>Precio Unitario</th>
                                            <th>Iva</th>
                                            <th>Total</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        @Code
                                            If Model IsNot Nothing Then
                                                For Each item In Model.Pedido.ListaPedidos
                                            @<tr>
                                                <td>
                                                    @item.Producto.Nombre
                                                </td>
                                                <td>
                                                    @item.Cantidad
                                                </td>
                                                <td>
                                                    $@item.Producto.ObtenerPrecio()
                                                </td>
                                                <td>
                                                    $@item.Producto.ObtenerIva()
                                                </td>
                                                <td>
                                                    $@item.Total
                                                </td>
                                            </tr>
                                                Next
                                            End If
                                        End Code
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <input type="submit" class="btn btn-cons btn-success" value="Comprar" />
                </div>
            </div>
        </div>
    </div>
End Using