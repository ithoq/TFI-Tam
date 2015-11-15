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
            @Html.DisplayNameFor(Function(model) model.FechaInicio): @Html.DisplayFor(Function(model) model.FechaInicio)<br />
            @Html.DisplayNameFor(Function(model) model.FechaFin): @Html.DisplayFor(Function(model) model.FechaFin)<br />
            @Html.DisplayNameFor(Function(model) model.Importe): @Html.DisplayFor(Function(model) model.Importe)<br />
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
        <h3>Total: $@Model.Total.ToString("0.00")</h3>
    </div>
</div>
<p>
    @Code
        If User.IsInRole("VerPedidos") Then
        @Html.ActionLink("Volver", "Index", Nothing, New With {.class = "btn btn-default btn-cons"})
        End If
    End Code
</p>

