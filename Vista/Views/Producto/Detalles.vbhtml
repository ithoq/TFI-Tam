@ModelType EE.Producto

@Section breadcrumb
    <ul class="breadcrumb">
        <li>
            <a href="@Url.Action("Index", "Producto")">Productos</a>
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
            <img style="width:40%" src="@Model.Fondo"/><br />
            @Html.DisplayNameFor(Function(model) model.Nombre): @Html.DisplayFor(Function(model) model.Nombre)<br />
            @Html.DisplayNameFor(Function(model) model.Alto): @Html.DisplayFor(Function(model) model.Alto)<br />
            @Html.DisplayNameFor(Function(model) model.Ancho): @Html.DisplayFor(Function(model) model.Ancho)<br />
            @Html.DisplayNameFor(Function(model) model.Papel.Espesor): @Html.DisplayFor(Function(model) model.Papel.Espesor)<br />
            @Html.DisplayNameFor(Function(model) model.Papel.Nombre): @Html.DisplayFor(Function(model) model.TipoProducto)<br />
            @Html.DisplayNameFor(Function(model) model.Tema): @Html.DisplayFor(Function(model) model.Tema)<br />
            @Model.ObtenerCosto<br />
            @Model.ObtenerPrecio
        </div>
    </div>
</div>
<p>
    @Code
        If User.IsInRole("EditarProducto") Then
        @Html.ActionLink("Editar", "Editar", New With {.id = Model.Id}, New With {.class = "btn btn-primary btn-cons"})
        End If
        If User.IsInRole("EliminarProducto") Then
        @<button class="btn btn-primary btn-cons" data-target="#modalStickUpSmall" data-toggle="modal">Eliminar</button>
        End If
        If User.IsInRole("VerProductos") Then
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
                    @Using Html.BeginForm("Eliminar", "Producto", New With {.id = Model.Id}, FormMethod.Get)
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


