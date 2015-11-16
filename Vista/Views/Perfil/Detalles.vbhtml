@ModelType EE.Perfil

@section breadcrumb
    <ul class="breadcrumb">
        <li>
            <a href="@Url.Action("Index", "Perfil")">Perfiles</a>
        </li>
        <li>
            <a class="active">Detalles</a>
        </li>
    </ul>
end section

@Section stylesheets
    <link href="~/Pages/assets/plugins/zTree/ztree.css" rel="stylesheet" />
End Section

@Section javascripts_vendor
    <script src="~/Pages/assets/plugins/zTree/jquery.ztree.js"></script>
End Section

@Section javascripts_custom
    <script type="text/javascript">
        $(document).ready(function () {
            var setting = {
                check: {
                    enable: true
                },
                data: {
                    key: {
                        children: "ListaPermisos",
                        name: "Descripcion",
                        checked: "Habilitado"
                    },
                    simpleData: {
                        idKey: "Id"
                    }
                }
            };
            var Nodes = @Html.Raw(ViewBag.ListaPermisos);
            $.fn.zTree.init($("#tree"), setting, Nodes);
            var treeObj = $.fn.zTree.getZTreeObj("tree");
            treeObj.expandAll(true);

            $("#btnSubmit").click(function () {
                var nodes = $.fn.zTree.getZTreeObj("tree").getNodes();
                var permissions = JSON.stringify(getPermissions(nodes));
                $("#ListaPermisos").val(permissions);
            });

            function getPermissions(nodes) {
                var permissions = [];
                for (var node in nodes) {
                    var zNode = nodes[node];
                    var permission = {};
                    permission.Id = zNode.Id;
                    permission.Descripcion = zNode.Descripcion;
                    permission.Habilitado = zNode.Habilitado;
                    permission.isParent = zNode.isParent;
                    if(zNode.isParent){
                        permission.ListaPermisos = getPermissions(zNode.ListaPermisos);
                    }
                    permissions.push(permission);
                }
                return permissions;
            }
        });
    </script>
End Section

<div class="panel panel-transparent ">
    <!-- Nav tabs -->
    <ul class="nav nav-tabs nav-tabs-fillup">
        <li class="active">
            <a data-toggle="tab" href="#tab-fillup1"><span>Información Básica</span></a>
        </li>
        <li>
            <a data-toggle="tab" href="#tab-fillup2"><span>Permisos</span></a>
        </li>
    </ul>
    <!-- Tab panes -->
    <div class="tab-content">
        <div class="tab-pane active" id="tab-fillup1">
            <div class="display-label">
                @Html.DisplayNameFor(Function(model) model.Nombre): @Html.DisplayFor(Function(model) model.Nombre)
            </div>
        </div>
        <div class="tab-pane" id="tab-fillup2">
            <ul id="tree" class="ztree"></ul>
        </div>
    </div>
</div>
<p>
    @Code
        If Model.Nombre <> "Administrador" And User.IsInRole("EditarPerfil") Then
        @Html.ActionLink("Editar", "Editar", New With {.id = Model.Id}, New With {.class = "btn btn-primary btn-cons"})
        End If
        If Model.Nombre <> "Administrador" And User.IsInRole("BajaPerfil") Then
        @<button class="btn btn-primary btn-cons" data-target="#modalStickUpSmall" data-toggle="modal">Eliminar</button>
        End If
        If User.IsInRole("VerPerfiles") Then
        @Html.ActionLink("Volver", "Index", Nothing, New With {.class = "btn btn-primary btn-cons"})
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
                    @Using Html.BeginForm("Eliminar", "Perfil", New With {.id = Model.Id}, FormMethod.Get)
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