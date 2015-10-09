@section breadcrumb
    <ul class="breadcrumb">
        <li>
            <p>Inicio</p>
        </li>
        <li>
            <a href="#" class="active">Contacto</a>
        </li>
    </ul>
end section

<div class="row">
    <div class="col-md-6">
        <!-- START PANEL -->
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="panel-title">
                    Contacto
                </div>
            </div>
            <div class="panel-body">
                @Using Html.BeginForm()
                    @Html.AntiForgeryToken()
                    @Html.ValidationSummary(True)
                    @<fieldset>
                        <div class="form-group form-group-default required ">
                            <label>Nombre</label>
                            <input type="text" class="form-control" required="">
                        </div>
                        <div class="form-group form-group-default required ">
                            <label>Apellido</label>
                            <input type="text" class="form-control" required="">
                        </div>
                        <div class="form-group form-group-default required ">
                            <label>Email</label>
                            <input type="email" class="form-control" required="">
                        </div>
                        <div class="form-group form-group-default required ">
                            <label>Teléfono</label>
                            <input type="tel" class="form-control" required="">
                        </div>
                        <div class="form-group form-group-default required ">
                            <label>Asunto</label>
                            <input type="text" class="form-control" required="">
                        </div>
                        <div class="form-group form-group-default required ">
                            <label>Consulta</label>
                            <input type="text" class="form-control" required="">
                        </div>
                        <button type="submit" class="btn btn-primary btn-cons">Enviar</button>
                        @Html.ActionLink("Volver", "Index", Nothing, New With {.class = "btn btn-default btn-cons"})
                    </fieldset>
                End Using
            </div>
        </div>
        <!-- END PANEL -->
    </div>
</div>


