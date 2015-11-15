@Section breadcrumb
<ul class="breadcrumb">
    <li>
        <a href="@Url.Action("Index", "Home")">Inicio</a>
    </li>
    <li>
        <a class="active">Éxito</a>
    </li>
</ul>
End Section

<div class="note note-success">
    <h4 class="block">Exito! Su compra se ha procesado correctamente</h4>
    <p>
        Puede revisar el avance de sus pedido desde la sección mis compras.
    </p>
</div>
<div class="row">
    <div class="col col-lg-3">
        @Code
            Html.RenderAction("Responder", "Encuesta", New With {.tipo = "Ficha Opinion"})
        End Code
    </div>
</div>