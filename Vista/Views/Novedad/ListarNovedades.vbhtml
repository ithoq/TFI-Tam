@ModelType IEnumerable(Of EE.Novedad)

@section breadcrumb
    <ul class="breadcrumb">
        <li>
            <p>Novedad</p>
        </li>
        <li>
            <a href="#" class="active">Listado</a>
        </li>
    </ul>
end section

<div class="panel panel-default bg-success-light text-white">
    <div class="panel-heading separator">
        <div class="panel-title">
            <h3>Listado de novedades</h3>
        </div>
    </div>
    <div class="panel-body">

        @For Each item In Model
            Dim currentItem = item

            @<div class="panel bg-success-light text-white">
                <div class="panel-default" role="tab" id="heading_@currentItem.Id">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse_@currentItem.Id" aria-expanded="true" aria-controls="collapse_@currentItem.Id" class="">
                            @currentItem.Titulo
                        </a>
                    </h4>
                </div>
                 <div id="collapse_@currentItem.Id" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="heading_@currentItem.Id">
                     <div class="panel-body">
                         @Html.Raw(currentItem.Contenido)
                     </div>
                 </div>
            </div>
        Next

    </div>
</div>



