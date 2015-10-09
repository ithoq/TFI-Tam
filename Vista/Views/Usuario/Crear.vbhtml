@ModelType EE.Usuario

@section breadcrumb
    <ul class="breadcrumb">
        <li>
            <p>Usuarios</p>
        </li>
        <li>
            <a href="#" class="active">Crear</a>
        </li>
    </ul>
end section

@section javascripts_custom
    <script type="text/javascript">
        $(document).ready(function () {
            $("#PerfilesId").select2();
        });
    </script>
End Section
<div class="row">
    <div class="col-md-6">
        <!-- START PANEL -->
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="panel-title">
                    Creación de usuario
                </div>
            </div>
            <div class="panel-body">
                @Using Html.BeginForm()
                    @Html.AntiForgeryToken()
                    @Html.ValidationSummary(True)
                    @<fieldset>
                            <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Nombre))),Nothing,"has-error")) ">
                                @Html.LabelFor(Function(model) model.Nombre)
                                @Html.TextBoxFor(Function(model) model.Nombre, New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.Nombre, Nothing, New With {.class = "help-block"})
                            </div>
                            <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Apellido))), Nothing, "has-error")) ">
                                @Html.LabelFor(Function(model) model.Apellido)
                                @Html.TextBoxFor(Function(model) model.Apellido, New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.Apellido, Nothing, New With {.class = "help-block"})
                            </div>
                            <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Email))), Nothing, "has-error")) ">
                                @Html.LabelFor(Function(model) model.Email)
                                @Html.TextBoxFor(Function(model) model.Email, New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.Email, Nothing, New With {.class = "help-block"})
                            </div>
                            <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.NombreUsuario))), Nothing, "has-error"))">
                                @Html.LabelFor(Function(model) model.NombreUsuario)
                                @Html.TextBoxFor(Function(model) model.NombreUsuario, New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.NombreUsuario, Nothing, New With {.class = "help-block"})
                            </div>
                            <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Clave))), Nothing, "has-error"))">
                                @Html.LabelFor(Function(model) model.Clave)
                                @Html.PasswordFor(Function(model) model.Clave, New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.Clave, Nothing, New With {.class = "help-block"})
                            </div>
                             <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.PerfilesId))), Nothing, "has-error"))">
                                 @Html.LabelFor(Function(model) model.PerfilesId)
                                 @Html.ListBoxFor(Function(model) model.PerfilesId, New MultiSelectList(ViewBag.Perfiles, "Id", "Nombre"), New With {.style = "width: 100%"})
                                 @Html.ValidationMessageFor(Function(model) model.PerfilesId, Nothing, New With {.class = "help-block"})
                             </div>
                        <button type="submit" class="btn btn-primary btn-cons">Grabar</button>
                        @Html.ActionLink("Volver", "Index", Nothing, New With {.class = "btn btn-default btn-cons"})
                    </fieldset>
                End Using
            </div>
        </div>
        <!-- END PANEL -->
    </div>
</div>

 <!--AntiForgeryToken: previene ataques de Cross_Site_Request_Forgery--> 


