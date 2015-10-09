@ModelType IEnumerable(Of EE.Usuario)

@section breadcrumb
    <ul class="breadcrumb">
        <li>
            <p>Usuarios</p>
        </li>
        <li>
            <a href="#" class="active">Listado</a>
        </li>
    </ul>
end section

@section stylesheets
    <link href="~/Pages/assets/plugins/jquery-datatable/media/css/jquery.dataTables.css" rel="stylesheet" type="text/css" />
    <link href="~/Pages/assets/plugins/jquery-datatable/extensions/FixedColumns/css/dataTables.fixedColumns.min.css" rel="stylesheet" type="text/css" />
    <link href="~/Pages/assets/plugins/datatables-responsive/css/datatables.responsive.css" rel="stylesheet" type="text/css" media="screen" />
End Section

<!-- START PANEL -->
<div class="panel panel-transparent">
    <div class="panel-heading">
        <div class="panel-title">
            Listado de Usuarios
        </div>
        <div class="pull-right">
            <div class="col-xs-12">
                <!--<a class="btn btn-primary btn-cons" href="@Url.Action("Crear")"><i class="fa fa-plus"></i> Nuevo</a>-->
                @Code
                    If User.IsInRole("CrearUsuario") Then
                    @<div class="btn-group">
                         <a href="@Url.Action("Crear")" class="btn btn-primary btn-cons">
                             Nuevo <i class="fa fa-plus"></i>
                         </a>
                    </div>
                    End If
                End Code
            </div>
        </div>
        <div class="clearfix"></div>
    </div>
    <div class="panel-body">
        <table class="table table-hover" id="tablaUsuarios">
            <thead>
                <tr>
                    <th>Nombre</th>
                    <th>Apellido</th>
                    <th>Email</th>
                    <th>Nombre de Usuario</th>
                    <th>Activo</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
                @For Each item In Model
                    Dim currentItem = item
                @<tr>
                    <td>
                        @Html.DisplayFor(Function(modelItem) currentItem.Nombre)
                    </td>
                    <td>
                        @Html.DisplayFor(Function(modelItem) currentItem.Apellido)
                    </td>
                    <td>
                        @Html.DisplayFor(Function(modelItem) currentItem.Email)
                    </td>
                    <td>
                        @Html.DisplayFor(Function(modelItem) currentItem.NombreUsuario)
                    </td>
                    <td>
                        @Html.DisplayFor(Function(modelItem) currentItem.Activo)
                    </td>
                    <td class="center">
                    @Code   
                    If User.IsInRole("ConsultarUsuario") Then
                        @Html.ActionLink("Ver", "Detalles", New With {.id = currentItem.Id}, New With {.class = "btn btn-primary btn-cons"})    
                    End If
                    End Code
                    </td>
                </tr>
                Next
        </table>
    </div>
</div>
<!-- END PANEL -->

@section javascripts_vendor
    <script type="text/javascript" src="~/Pages/assets/plugins/bootstrap-select2/select2.min.js"></script>
    <script type="text/javascript" src="~/Pages/assets/plugins/classie/classie.js"></script>
    <script src="~/Pages/assets/plugins/switchery/js/switchery.min.js" type="text/javascript"></script>
    <script src="~/Pages/assets/plugins/jquery-datatable/media/js/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="~/Pages/assets/plugins/jquery-datatable/extensions/TableTools/js/dataTables.tableTools.min.js" type="text/javascript"></script>
    <script src="~/Pages/assets/plugins/jquery-datatable/extensions/Bootstrap/jquery-datatable-bootstrap.js" type="text/javascript"></script>
    <script type="text/javascript" src="~/Pages/assets/plugins/datatables-responsive/js/datatables.responsive.js"></script>
    <script type="text/javascript" src="~/Pages/assets/plugins/datatables-responsive/js/lodash.min.js"></script>
End Section

@section javascripts_custom
    <script type="text/javascript">
        var table = $('#tablaUsuarios');

        var settings = {
            "sDom": "<'table-responsive't><'row'<p i>>",
            "sPaginationType": "bootstrap",
            "destroy": true,
            "scrollCollapse": true,
            "oLanguage": {
                "sLengthMenu": "_MENU_ ",
                "sInfo": "Mostrando <b>_START_ a _END_</b> de _TOTAL_ registros"
            },
            "iDisplayLength": 10
        };

        table.dataTable(settings);
    </script>
End Section
