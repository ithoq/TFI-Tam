@Section breadcrumbs
    <ul class="breadcrumb">
        <li>
            <a href="@Url.Action("Index", "Home")">Inicio</a>
        </li>
        <li>
            <a class="active">Error</a>
        </li>
    </ul>
End Section

<div class="container-xs-height full-height">
    <div class="row-xs-height">
        <div class="col-xs-height col-middle">
            <div class="error-container text-center">
                <h1 class="error-number">500</h1>
                <h2 class="semi-bold">Se produjo un error al intentar procesar su solicitud.</h2>
                <p>
                    Vuelva a intentar en unos minutos
                </p>
            </div>
        </div>
    </div>
</div>