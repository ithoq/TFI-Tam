@ModelType EE.Pedido

@Section breadcrumb
    <ul class="breadcrumb">
        <li>
            <a href="@Url.Action("Index", "Pedido")">Pedidos</a>
        </li>
        <li>
            <a class="active">Detalle</a>
        </li>
    </ul>
End Section

@Section javascripts_vendor
    <script src="~/Pages/assets/plugins/jquery-sparkline/jquery.sparkline.min.js" type="text/javascript"></script>
End Section

<div class="panel panel-transparent ">
    <!-- Nav tabs -->
    <ul class="nav nav-tabs nav-tabs-fillup">
        <li class="active">
            <a data-toggle="tab" href="#tab-fillup1"><span>Información Básica</span></a>
        </li>
    </ul>
    <!-- Tab panes -->
    <div class="tab-content">
        <div class="tab-pane active" id="tab-fillup1">
            Número de orden: @model.Id<br />
            @Html.DisplayNameFor(Function(model) model.FechaInicio): @Model.FechaInicio<br />
            @Html.DisplayNameFor(Function(model) model.FechaFin): @IIf(Model.FechaFin = Nothing, "", Model.FechaFin)<br />
            Importe: $@Model.Importe.ToString("0.00")<br />
            @Html.DisplayNameFor(Function(model) model.Estado): @Html.DisplayFor(Function(model) model.Estado)<br />
            @Html.DisplayNameFor(Function(model) model.Direccion.Descripcion): @Html.DisplayFor(Function(model) model.Direccion.Descripcion)<br />
            @Html.DisplayNameFor(Function(model) model.Usuario.Nombre): @Html.DisplayFor(Function(model) model.Usuario.Nombre)<br />
            @Html.DisplayNameFor(Function(model) model.Usuario.Apellido): @Html.DisplayFor(Function(model) model.Usuario.Apellido)<br />
            @Html.DisplayNameFor(Function(model) model.Usuario.NombreUsuario): @Html.DisplayFor(Function(model) model.Usuario.NombreUsuario)<br />
            @Html.DisplayNameFor(Function(model) model.Usuario.Telefono): @Html.DisplayFor(Function(model) model.Usuario.Telefono)
        </div>
        <table class="table table-hover">
            <thead>
                <tr>
                    <th>Cantidad</th>
                    <th>Precio</th>
                    <th>Producto</th>
                    <th>Total</th>
                </tr>
            </thead>
            <tbody>
                @For Each item In Model.ListaPedidos
                    @<tr>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.Cantidad)
                        </td>
                        <td>
                            $@item.Precio.ToString("0.00")
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.Producto.Nombre)
                        </td>
                        <td>
                            $@item.Total.ToString("0.00")
                        </td>
                    </tr>
                Next
            </tbody>
        </table>
        <h3>Total: $@Model.Importe.ToString("0.00")</h3>
    </div>
</div>
<p>
    @Code
        If User.IsInRole("VerPedidos") Then
        @Html.ActionLink("Volver", "Index", Nothing, New With {.class = "btn btn-default btn-cons"})
        End If
        If User.IsInRole("AnularPedido") And Model.Estado = "Pendiente" Then
        @<button class="btn btn-primary btn-cons" data-target="#modalStickUpSmall" data-toggle="modal">Anular</button>
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
                    <h5>Está seguro que desea anular el pedido?</h5>
                </div>
                <div class="modal-body">
                    <p class="no-margin">Esta operación anulará el pedido y generará una nota de crédito a favor del cliente.</p>
                </div>
                <div class="modal-footer">
                    @Using Html.BeginForm("Anular", "Pedido", New With {.id = Model.Id}, FormMethod.Get)
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

