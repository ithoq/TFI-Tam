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

@section stylesheets
    <link href="~/Pages/assets/plugins/jquery-datatable/media/css/jquery.dataTables.css" rel="stylesheet" type="text/css" />
    <link href="~/Pages/assets/plugins/jquery-datatable/extensions/FixedColumns/css/dataTables.fixedColumns.min.css" rel="stylesheet" type="text/css" />
    <link href="~/Pages/assets/plugins/datatables-responsive/css/datatables.responsive.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="~/Pages/assets/plugins/bootstrap-star-rating/css/star-rating.css" rel="stylesheet" type="text/css" />
    <style>
        .star-black {
            color: black;
        }

        .star-gray {
            color: gray;
        }

        .star-white {
            color: white;
        }
    </style>
end section

@Section javascripts_vendor
    <script src="~/Pages/assets/plugins/bootstrap-star-rating/js/star-rating.js" type="text/javascript"></script>
End Section

@section javascripts_custom
    <script type="text/javascript">
        $(document).ready(function () {
            $("#Valoracion").rating();
        });
    </script>
End Section

@Code
    If TempData("error") IsNot Nothing Then
        @<div class="alert alert-danger" role="alert">
            <button class="close" data-dismiss="alert"></button>
            <strong>Error: </strong>@TempData("error").ToString()
        </div>
    End If
End Code
<div class="panel panel-transparent ">
    <!-- Nav tabs -->
    <ul class="nav nav-tabs nav-tabs-fillup">
        <li class="active">
            <a data-toggle="tab" href="#tab-fillup1"><span>Pedido</span></a>
        </li>
        <li>
            <a data-toggle="tab" href="#tab-fillup2"><span>Comentarios</span></a>
        </li>
    </ul>
    <!-- Tab panes -->
    <div class="tab-content">
        <div class="tab-pane active" id="tab-fillup1">
            <img style="width:40%" src="@Model.Fondo" /><br />
            <label>Nombre:</label>
            @Model.Nombre<br />
            <label>Alto(px):</label>
            @Model.Alto<br />
            <label>Ancho(px):</label>
            @Model.Ancho<br />
            <label>Espesor(cm):</label>
            @Model.Papel.Espesor<br />
            <label>Papel:</label>
            @Model.Papel.Nombre<br />
            <label>Tipo de producto:</label>
            @Model.TipoProducto.Tipo<br />
            <label>Tema:</label>
            @Model.Tema.Tema<br />
            <label>Precio:</label>
            $@Model.ObtenerPrecio.ToString("0.00")<br />
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
        <div class="tab-pane" id="tab-fillup2">
            @code

                @For Each item In Model.ListaComentarios
                    @<div class="card share full-width">
                        <div class="card-header clearfix bg-primary">
                            <h5>Valoración:</h5>
                            <p class="rating">
                                @For index = 1 To 5
                                If index <= item.Valoracion Then
                                    @<i class="fa fa-star star-white"></i>
                                Else
                                    @<i class="fa fa-star star-gray"></i>
                                End If
                                Next
                            </p>
                        </div>
                        <div class="card-description">
                            @item.Mensaje
                        </div>
                    </div>
                Next
            End Code


            @Code
                If User IsNot Nothing Then
                    Html.RenderAction("Comentar", "Producto", New With {.productoId = Model.Id})
                End If
            End Code
        </div>
    </div>
</div>
