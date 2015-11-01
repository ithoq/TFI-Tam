@ModelType EE.Perfil

@Code
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

@Section breadcrumb
    <ul class="breadcrumb">
        <li>
            <a href="@Url.Action("Index", "Perfil")">Perfiles</a>
        </li>
        <li>
            <a class="active">Editar</a>
        </li>
    </ul>
End Section

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

<div class="row">
    <div class="col-md-6">
        <!-- START PANEL -->
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="panel-title">
                    Edición de perfil
                </div>
            </div>
            <div class="panel-body">
                @Using Html.BeginForm()
                    @Html.AntiForgeryToken()
                    @Html.ValidationSummary(True)
                    
                    @<fieldset>
                        @Html.HiddenFor(Function(model) model.Id)
                        <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Nombre))),Nothing,"has-error")) ">
                            @Html.LabelFor(Function(model) model.Nombre)
                            @Html.TextBoxFor(Function(model) model.Nombre, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.Nombre, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group form-group-default">
                            @Html.LabelFor(Function(model) model.ListaPermisos, New With {.class = "control-label"})
                            <ul id="tree" class="ztree"></ul>
                            <input type="hidden" id="ListaPermisos" name="ListaPermisos" />
                        </div>
                        <button id="btnSubmit" type="submit" class="btn btn-primary btn-cons">Grabar</button>
                        @Html.ActionLink("Volver", "Index", Nothing, New With {.class = "btn btn-default btn-cons"})
                    </fieldset>
                End Using
            </div>
        </div>
        <!-- END PANEL -->
    </div>
</div>