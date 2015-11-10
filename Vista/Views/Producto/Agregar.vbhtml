@ModelType EE.Producto

@Section breadcrumb
    <ul class="breadcrumb">
        <li>
            <a href="@Url.Action("Index", "Producto")">Productos</a>
        </li>
        <li>
            <a class="active">Agregar productos</a>
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
            <a data-toggle="tab" href="#tab-fillup1"><span>Pedido</span></a>
        </li>
    </ul>
    <!-- Tab panes -->
    <div class="tab-content">
        <div class="tab-pane active" id="tab-fillup1">
            <img style="width:60%" src="@Model.Fondo" /><br />
            <label>Nombre:</label>
            @Model.Nombre<br />
            <label>Alto:</label>
            @Model.Alto<br />
            <label>Ancho:</label>
            @Model.Ancho<br />
            <label>Espesor:</label>
            @Model.Papel.Espesor<br />
            <label>Papel:</label>
            @Model.Papel.Nombre<br />
            <label>Tipo de producto:</label>
            @Model.TipoProducto<br />
            <label>Tema:</label>
            @Model.Tema<br />
            <label>Precio:</label>
            @Model.ObtenerPrecio<br />
            @Using Html.BeginForm("Agregar", "Pedido", FormMethod.Post)
                @<div class="col-sm-2 col-sm-offset-8">
                    <div class="form-group form-group-default required">
                        <input type="hidden" name="Producto_Id" value="@Model.Id" />
                        <label>Cantidad</label>
                        <input type="text" name="Cantidad" class="form-control" required="">
                    </div>
                </div>
                @<button type="submit" class="btn btn-primary btn-cons">Agregar Producto</button>
            End Using
        </div>
    </div>
</div>
