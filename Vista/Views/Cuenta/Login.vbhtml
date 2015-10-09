@ModelType Vista.LogInViewModel

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
    <meta charset="utf-8" />
    <title>Asahi</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <link rel="apple-touch-icon" href="pages/ico/60.png">
    <link rel="apple-touch-icon" sizes="76x76" href="pages/ico/76.png">
    <link rel="apple-touch-icon" sizes="120x120" href="pages/ico/120.png">
    <link rel="apple-touch-icon" sizes="152x152" href="pages/ico/152.png">
    <link rel="icon" type="image/x-icon" href="favicon.ico" />
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-touch-fullscreen" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="default">
    <meta content="" name="description" />
    <meta content="" name="author" />
    <link href="~/Pages/assets/plugins/boostrapv3/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="~/Pages/assets/plugins/font-awesome/css/font-awesome.css" rel="stylesheet" type="text/css" />
    <link href="~/Pages/assets/plugins/jquery-scrollbar/jquery.scrollbar.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="~/Pages/assets/plugins/bootstrap-select2/select2.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="~/Pages/assets/plugins/switchery/css/switchery.min.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="~/Pages/pages/css/pages-icons.css" rel="stylesheet" type="text/css">
    <link class="main-stylesheet" href="~/Pages/pages/css/pages.css" rel="stylesheet" type="text/css" />
    <!--[if lte IE 9]>
        <link href="pages/css/ie9.css" rel="stylesheet" type="text/css" />
    <![endif]-->
    <script type="text/javascript">
        window.onload = function () {
            // fix for windows 8
            if (navigator.appVersion.indexOf("Windows NT 6.2") != -1)
                document.head.innerHTML += '<link rel="stylesheet" type="text/css" href="pages/css/windows.chrome.fix.css" />'
        }
    </script>
</head>
<body class="fixed-header   ">
    <!-- START PAGE-CONTAINER -->
    <div class="login-wrapper ">
        <!-- START Login Background Pic Wrapper-->
        <div class="bg-pic">
            <!-- START Background Pic-->
            <!--<img src="/Pages/assets/img/fondos/partes-e-invitaciones2-1024x745.png" data-src="/Pages/assets/img/fondos/partes-e-invitaciones2-1024x745.png" data-src-retina="/Pages/assets/img/fondos/partes-e-invitaciones2-1024x745.png" alt="" class="lazy"> -->      
            <img src="/Pages/assets/img/fondos/correveidile.png" data-src="/Pages/assets/img/fondos/correveidile.png" data-src-retina="/Pages/assets/img/fondos/correveidile.png" alt="" class="lazy" style="width:65.5%;">                    
            <!-- END Background Pic-->
            <!-- START Background Caption-->
            <div class="bg-caption pull-bottom sm-pull-bottom text-white p-l-20 m-b-20">
                <h2 class="semi-bold text-white">
                    <!--Acá va el texto-->
                </h2>
                <p class="small">
                    <!--Acá va el texto-->
                </p>
            </div>
            <!-- END Background Caption-->
        </div>
        <!-- END Login Background Pic Wrapper-->
        <!-- START Login Right Container-->
        <div class="login-container bg-white">
            <div class="p-l-50 m-l-20 p-r-50 m-r-20 p-t-50 m-t-30 sm-p-l-15 sm-p-r-15 sm-p-t-40">
                <img src="/Pages/assets/img/logoAsahi.png" alt="logo" data-src="/Pages/assets/img/logoAsahi.png" data-src-retina="/Pages/assets/img/logoAsahi.png" width="130" height="40">
                <p class="p-t-35">
                    @Code
                        If Html.ViewData.ModelState.IsValid = False Then
                        @<div class="alert alert-danger" role="alert">
                            <button class="close" data-dismiss="alert"></button>
                            <span>@Html.ValidationSummary(False)</span>
                        </div>
                        End If
                    End Code
                </p>
                <!-- START Login Form -->
                @Using (Html.BeginForm("LogIn", "Cuenta", Nothing, FormMethod.Post, New With {.class = "p-t-15", .role = "form", .id = "form-login"}))
                    @<!-- START Form Control-->
                    @<div class="form-group form-group-default">
                        @Html.LabelFor(Function(model) model.NombreUsuario)
                        <div class="controls">
                        @Html.TextBoxFor(Function(model) model.NombreUsuario, New With {.class = "form-control", .required = ""})                            
                        </div>
                    </div>
                    @<!-- END Form Control-->
                    @<!-- START Form Control-->
                    @<div class="form-group form-group-default">
                        @Html.LabelFor(Function(model) model.Clave)
                        <div class="controls">
                            @Html.PasswordFor(Function(model) model.Clave, New With {.class = "form-control", .required=""})
                        </div>
                    </div>
                    @<!-- START Form Control-->
                    @<div class="row">
                        <div class="col-md-6 no-padding">
                                @Html.CheckBoxFor(Function(model) model.Recordarme)
                                @Html.LabelFor(Function(model) model.Recordarme)
                        </div>
                        <div class="col-md-6 text-right">
                            <a href="#" id="btnOlvideClave" class="text-info small">Olvidé mi contraseña</a>
                        </div>
                    </div>
                    @<!-- END Form Control-->
                    @<button class="btn btn-primary btn-cons m-t-10" type="submit">Iniciar sesión</button>
                End Using
                <!--END Login Form-->

                @Using (Html.BeginForm("EnviarClave", "Usuario", Nothing, FormMethod.Post, New With {.class = "m-t-15 hide", .role = "form", .id = "form-forget"}))
                    @<div class="form-group form-group-default required">
                        <label>Email</label>
                        <div class="controls">
                            <input type="email" name="email" id="email" class="form-control" required />                           
                        </div>
                    </div>
                    @<button class="btn btn-primary btn-cons m-t-10" type="submit">Aceptar</button>
                End Using
            </div>
        </div>
        <!-- END Login Right Container-->
    </div>
    <!-- END PAGE CONTAINER -->
    <!-- BEGIN VENDOR JS -->
    <script src="~/Pages/assets/plugins/jquery/jquery-1.11.1.min.js" type="text/javascript"></script>
    <script src="~/Pages/assets/plugins/modernizr.custom.js" type="text/javascript"></script>
    <script src="~/Pages/assets/plugins/jquery-ui/jquery-ui.min.js" type="text/javascript"></script>
    <script src="~/Pages/assets/plugins/boostrapv3/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="~/Pages/assets/plugins/jquery/jquery-easy.js" type="text/javascript"></script>
    <script src="~/Pages/assets/plugins/jquery-unveil/jquery.unveil.min.js" type="text/javascript"></script>
    <script src="~/Pages/assets/plugins/jquery-bez/jquery.bez.min.js"></script>
    <script src="~/Pages/assets/plugins/jquery-ios-list/jquery.ioslist.min.js" type="text/javascript"></script>
    <script src="~/Pages/assets/plugins/jquery-actual/jquery.actual.min.js"></script>
    <script src="~/Pages/assets/plugins/jquery-scrollbar/jquery.scrollbar.min.js"></script>
    <script type="text/javascript" src="~/Pages/assets/plugins/bootstrap-select2/select2.min.js"></script>
    <script type="text/javascript" src="~/Pages/assets/plugins/classie/classie.js"></script>
    <script src="~/Pages/assets/plugins/switchery/js/switchery.min.js" type="text/javascript"></script>
    <script src="~/Pages/assets/plugins/jquery-validation/js/jquery.validate.min.js" type="text/javascript"></script>
    <!-- END VENDOR JS -->
    <!-- BEGIN CORE TEMPLATE JS -->
    <script src="~/Pages/pages/js/pages.min.js"></script>
    <!-- END CORE TEMPLATE JS -->
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnOlvideClave").click(function () {
                $("#form-forget").removeClass("hide");
                return false;
            })
        });
    </script>
</body>
</html>
