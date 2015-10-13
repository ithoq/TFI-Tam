<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
        <meta charset="utf-8" />
        <title class="notranslate">Asahi - Tarjetería Social</title>
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
        <link href="~/Pages/assets/plugins/pace/pace-theme-flash.css" rel="stylesheet" type="text/css" />
        <link href="~/Pages/assets/plugins/boostrapv3/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <link href="~/Pages/assets/plugins/font-awesome/css/font-awesome.css" rel="stylesheet" type="text/css" />
        <link href="~/Pages/assets/plugins/jquery-scrollbar/jquery.scrollbar.css" rel="stylesheet" type="text/css" media="screen" />
        <link href="~/Pages/assets/plugins/bootstrap-select2/select2.css" rel="stylesheet" type="text/css" media="screen" />
        <link href="~/Pages/assets/plugins/switchery/css/switchery.min.css" rel="stylesheet" type="text/css" media="screen" />
        @*<link href="~/Pages/assets/plugins/nvd3/nv.d3.min.css" rel="stylesheet" type="text/css" media="screen" />
        <link href="~/Pages/assets/plugins/mapplic/css/mapplic.css" rel="stylesheet" type="text/css" />
        <link href="~/Pages/assets/plugins/rickshaw/rickshaw.min.css" rel="stylesheet" type="text/css" />*@
        <link href="~/Pages/assets/plugins/bootstrap-datepicker/css/datepicker3.css" rel="stylesheet" type="text/css" media="screen">
        <link href="~/Pages/assets/plugins/jquery-metrojs/MetroJs.css" rel="stylesheet" type="text/css" media="screen" />
        @RenderSection("stylesheets", required:=False)
        <link href="~/Pages/pages/css/pages-icons.css" rel="stylesheet" type="text/css">
        <link class="main-stylesheet" href="~/Pages/pages/css/pages.css" rel="stylesheet" type="text/css" />
        <link href="~/Pages/pages/css/custom.css" rel="stylesheet" type="text/css">
        
        <!--[if lte IE 9]>
            <link href="pages/css/ie9.css" rel="stylesheet" type="text/css" />
        <![endif]-->
        <!--[if lt IE 9]>
            <link href="~/Pages/assets/plugins/mapplic/css/mapplic-ie.css" rel="stylesheet" type="text/css" />
        <![endif]-->
        <script type="text/javascript">
            window.onload = function () {
                // fix for windows 8
                if (navigator.appVersion.indexOf("Windows NT 6.2") != -1)
                    document.head.innerHTML += '<link rel="stylesheet" type="text/css" href="~/Pages/pages/css/windows.chrome.fix.css" />'
            }
        </script>
    </head>
<body class="fixed-header menu-behind">
    <!-- BEGIN SIDEBPANEL-->
    <nav class="page-sidebar" data-pages="sidebar">
        <!-- BEGIN SIDEBAR MENU TOP TRAY CONTENT-->
        @*<div class="sidebar-overlay-slide from-top" id="appMenu">
            <div class="row">
                <div class="col-xs-6 no-padding">
                    <a href="#" class="p-l-40">
                        <img src="/Pages/assets/img/demo/social_app.svg" alt="socail">
                    </a>
                </div>
                <div class="col-xs-6 no-padding">
                    <a href="#" class="p-l-10">
                        <img src="/Pages/assets/img/demo/email_app.svg" alt="socail">
                    </a>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-6 m-t-20 no-padding">
                    <a href="#" class="p-l-40">
                        <img src="/Pages/assets/img/demo/calendar_app.svg" alt="socail">
                    </a>
                </div>
                <div class="col-xs-6 m-t-20 no-padding">
                    <a href="#" class="p-l-10">
                        <img src="/Pages/assets/img/demo/add_more.svg" alt="socail">
                    </a>
                </div>
            </div>
        </div>*@
        <!-- END SIDEBAR MENU TOP TRAY CONTENT-->
        <!-- BEGIN SIDEBAR MENU HEADER-->
        <div class="sidebar-header">
            <img src="/Pages/assets/img/logoAsahi.png" alt="logo" class="brand" data-src="/Pages/assets/img/logoAsahi.png" data-src-retina="/Pages/assets/img/logoAsahi.png" width="110" height="40">
            <div class="sidebar-header-controls">
                <button type="button" class="btn btn-xs sidebar-slide-toggle btn-link m-l-20" data-pages-toggle="#appMenu">
                    <i class="fa fa-angle-down fs-16"></i>
                </button>
                <button type="button" class="btn btn-link visible-lg-inline" data-toggle-pin="sidebar">
                    <i class="fa fs-12"></i>
                </button>
            </div>
        </div>
        <!-- END SIDEBAR MENU HEADER-->
        <!-- START SIDEBAR MENU -->
        <div class="sidebar-menu">
            <!-- BEGIN SIDEBAR MENU ITEMS-->
            <ul class="menu-items" style="margin-top:20px !important">
                <li>
                    <a href="@Url.Action("Index", "Home")">
                        <span class="title">Inicio</span>
                    </a>
                    <span class="icon-thumbnail">I</span>
                </li>
                @Html.MenuVertical()
            </ul>
            <div class="clearfix"></div>
        </div>
        <!-- END SIDEBAR MENU -->
    </nav>
    <!-- END SIDEBAR -->
    <!-- END SIDEBPANEL-->
    <!-- START PAGE-CONTAINER -->
    <div class="page-container">
        <!-- START HEADER -->
        <div class="header ">
            <!-- START MOBILE CONTROLS -->
            <!-- LEFT SIDE -->
            <div class="pull-left full-height visible-sm visible-xs">
                <!-- START ACTION BAR -->
                <div class="sm-action-bar">
                    <a href="#" class="btn-link toggle-sidebar" data-toggle="sidebar">
                        <span class="icon-set menu-hambuger"></span>
                    </a>
                </div>
                <!-- END ACTION BAR -->
            </div>
            <!-- RIGHT SIDE -->
            @Code
                If IsNothing(User) = False Then
                    @<div class="pull-right full-height visible-sm visible-xs">
                    <!-- START ACTION BAR -->
                    <div class="sm-action-bar">
                        <a href="#" class="btn-link" data-toggle="quickview" data-toggle-element="#quickview">
                            <span class="icon-set menu-hambuger-plus"></span>
                        </a>
                    </div>
                    <!-- END ACTION BAR -->
                </div>
                End If
            End Code
            <!-- END MOBILE CONTROLS -->
            <div class=" pull-left sm-table">
                <div class="header-inner">
                    <div class="brand inline">
                        <img src="/Pages/assets/img/logoAsahi.png" alt="logo" data-src="/Pages/assets/img/logoAsahi.png" data-src-retina="/Pages/assets/img/logoAsahi.png" width="130" height="40">
                    </div>
                    <!-- START NOTIFICATION LIST -->
                    <ul class="notification-list no-margin hidden-sm hidden-xs b-grey b-l b-r no-style p-l-30 p-r-20">
                        <li class="p-r-15 inline">
                            <a href="@Url.Action("QuienesSomos", "Home")" class="clip ">Quienes Somos?</a>
                        </li>
                        <li class="p-r-15 inline">
                            <a href="@Url.Action("Crear", "Contacto")" class="grid-box">Contáctenos</a>
                        </li>
                        <li class="p-r-15 inline" style="height: 22px;">
                            <input type="text" id="txtBuscarEnMenu" class="form-control input-sm" placeholder="Buscar...">
                        </li>
                    </ul>
                            <!-- END NOTIFICATIONS LIST -->
                            @*<a href="#" class="search-link" data-toggle="search"><i class="pg-search"></i>Buscar en el <span class="bold">menú</span></a>*@
                </div>
            </div>
            @Code
                If IsNothing(User) = False Then
                    @<div class=" pull-right">
                        <div class="header-inner">
                            <a href="#" class="btn-link icon-set menu-hambuger-plus m-l-20 sm-no-margin hidden-sm hidden-xs" data-toggle="quickview" data-toggle-element="#quickview"></a>
                        </div>
                    </div>
                End If
            End Code
            <div class=" pull-right">
                <!-- START User Info-->
                <div class="visible-lg visible-md m-t-10">
                    @Html.DropdownLenguaje()
                    @Code
                        If IsNothing(User) Then
                            @<a href="@Url.Action("Registrar", "Usuario")" class="btn btn-primary btn-cons" style="color: white; margin-top: 3px;">Registrarse</a>
                            @<a href="@Url.Action("LogIn", "Cuenta")" class="btn btn-primary btn-cons" style="color: white; margin-top: 3px;">Iniciar Sesión</a>
                        Else
                            @<div class="pull-left p-r-10 p-t-10 fs-16 font-heading">
                                <input type="hidden" id="loggedUserId" value="@User.UsuarioId" />
                                <span class="semi-bold notranslate">@User.Nombre</span>
                            </div>
                            @<div class="dropdown pull-right">
                                <button class="profile-dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    <span class="thumbnail-wrapper d32 circular inline m-t-5">
                                        <img src="/Pages/assets/img/profiles/generic_female_avatar.jpg" alt="" data-src="/Pages/assets/img/profiles/generic_female_avatar.jpg" data-src-retina="/Pages/assets/img/profiles/generic_female_avatar.jpg" width="32" height="32">
                                    </span>
                                </button>
                                <ul class="dropdown-menu profile-dropdown" role="menu">
                                    <li>
                                        <a href="@Url.Action("MiCuenta", "Usuario")"><i class="pg-settings_small"></i> Mi Cuenta</a>
                                    </li>
                                    @*<li>
                                        <a href="#"><i class="pg-outdent"></i> Feedback</a>
                                    </li>
                                    <li>
                                        <a href="#"><i class="pg-signals"></i> Help</a>
                                    </li>*@
                                    <li class="bg-master-lighter">
                                        <a href="@Url.Action("LogOut", "Cuenta")" class="clearfix">
                                            <span class="pull-left">Logout</span>
                                            <span class="pull-right"><i class="pg-power"></i></span>
                                        </a>
                                    </li>
                                </ul>
                            </div>   
                        End If
                    End Code
                </div>
                <!-- END User Info-->
            </div>
        </div>
        <!-- END HEADER -->
        <!-- START PAGE CONTENT WRAPPER -->
        <div class="page-content-wrapper">
            <!-- START PAGE CONTENT -->
            <div class="content sm-gutter">
                <div class="container-fluid container-fixed-lg">
                    @RenderSection("breadcrumb", required:=False)
                    @RenderSection("page_title", required:=False)
                </div>
                <!-- START CONTAINER FLUID -->
                <div class="container-fluid container-fixed-lg m-t-20">
                    @RenderBody()
                </div>
                <!-- END CONTAINER FLUID -->
            </div>
            <!-- END PAGE CONTENT -->
            <!-- START COPYRIGHT -->
            <!-- START CONTAINER FLUID -->
            <div class="container-fluid container-fixed-lg footer">
                <div class="copyright sm-text-center">
                    <p class="small no-margin pull-left sm-pull-reset">
                        <span class="hint-text">Copyright © 2015 </span>
                        <span class="font-montserrat">ASAHI</span>.
                        <span class="hint-text">Todos los derechos reservados. </span>
                        <span class="sm-block"><a href="/Home/PoliticaPrivacidad" class="m-l-10">Políticas de Privacidad</a></span>
                    </p>
                    <div class="clearfix"></div>
                </div>
            </div>
            <!-- END COPYRIGHT -->
        </div>
        <!-- END PAGE CONTENT WRAPPER -->
    </div>
    <!-- END PAGE CONTAINER -->
    <!--START QUICKVIEW -->
    <div id="quickview" class="quickview-wrapper" data-pages="quickview">
        <!-- Nav tabs -->
        <ul class="nav nav-tabs">
            <li class="active">
                <a href="#quickview-chat" data-toggle="tab">Chat</a>
            </li>
        </ul>
        <a class="btn-link quickview-toggle" data-toggle-element="#quickview" data-toggle="quickview"><i class="pg-close"></i></a>
        <!-- Tab panes -->
        <div class="tab-content">
            <div class="tab-pane fade in active no-padding" id="quickview-chat">
                <div class="view-port clearfix" id="chat">
                    <div class="view bg-white">
                        <!-- BEGIN View Header !-->
                        <div class="navbar navbar-default">
                            <div class="navbar-inner">
                                <!-- BEGIN Header Controler !-->
                                @*<a href="javascript:;" class="inline action p-l-10 link text-master" data-navigate="view" data-view-port="#chat" data-view-animation="push-parrallax">
                                    <i class="pg-plus"></i>
                                </a>*@
                                <!-- END Header Controler !-->
                                <div class="view-heading">
                                    Usuarios Conectados
                                    @*<div class="fs-11">Show All</div>*@
                                </div>
                                <!-- BEGIN Header Controler !-->
                                @*<a href="#" class="inline action p-r-10 pull-right link text-master">
                                    <i class="pg-more"></i>
                                </a>*@
                                <!-- END Header Controler !-->
                            </div>
                        </div>
                        <!-- END View Header !-->
                        <div data-init-list-view="ioslist" class="list-view boreded no-top-border">
                            <div class="list-view-group-container">
                                <div class="list-view-group-header text-uppercase">
                                    &nbsp;
                                </div>
                                <ul id="ulOnlineUsers">
                                    <!-- BEGIN Chat User List Item  !-->
                                    
                                    <!-- END Chat User List Item  !-->
                                </ul>
                            </div>
                        </div>
                    </div>
                    <!-- BEGIN Conversation View  !-->
                    <div class="view chat-view bg-white clearfix" id="chatView" data-nombregrupo="" data-usuarioid="">
                        <!-- BEGIN Header  !-->
                        <div class="navbar navbar-default">
                            <div class="navbar-inner">
                                <a href="javascript:;" class="link text-master inline action p-l-10 p-r-10" data-navigate="view" data-view-port="#chat" data-view-animation="push-parrallax">
                                    <i class="pg-arrow_left"></i>
                                </a>
                                <div class="view-heading">
                                </div>
                                @*<a href="#" class="link text-master inline action p-r-10 pull-right ">
                                    <i class="pg-more"></i>
                                </a>*@
                            </div>
                        </div>
                        <!-- END Header  !-->
                        <!-- BEGIN Conversation  !-->
                        <div class="chat-inner" id="my-conversation">
                        </div>
                        <!-- BEGIN Conversation  !-->
                        <!-- BEGIN Chat Input  !-->
                        <div class="b-t b-grey bg-white clearfix p-l-10 p-r-10">
                            <div class="row">
                                @*<div class="col-xs-1 p-t-15">
                        <a href="#" class="link text-master"><i class="fa fa-plus-circle"></i></a>
                    </div>*@
                                <div class="col-xs-12 no-padding">
                                    <input type="text" class="form-control chat-input" data-chat-input="" data-chat-conversation="#my-conversation" placeholder="Escribe algo...">
                                </div>
                                @*<div class="col-xs-2 link text-master m-l-10 m-t-15 p-l-10 b-l b-grey col-top">
                        <a href="#" class="link text-master"><i class="pg-camera"></i></a>
                    </div>*@
                            </div>
                        </div>
                        <!-- END Chat Input  !-->
                    </div>
                    <!-- END Conversation View  !-->
                </div>
            </div>
        </div>
    </div>
    <!-- END QUICKVIEW-->
    <!-- START OVERLAY -->
    @*<div class="overlay hide" data-pages="search">
        <!-- BEGIN Overlay Content !-->
        <div class="overlay-content has-results m-t-20">
            <!-- BEGIN Overlay Header !-->
            <div class="container-fluid">
                <!-- BEGIN Overlay Logo !-->
                <img class="overlay-brand" src="/Pages/assets/img/logo.png" alt="logo" data-src="/Pages/assets/img/logo.png" data-src-retina="/Pages/assets/img/logo_2x.png" width="78" height="22">
                <!-- END Overlay Logo !-->
                <!-- BEGIN Overlay Close !-->
                <a href="#" class="close-icon-light overlay-close text-black fs-16">
                    <i class="pg-close"></i>
                </a>
                <!-- END Overlay Close !-->
            </div>
            <!-- END Overlay Header !-->
            <div class="container-fluid">
                <!-- BEGIN Overlay Controls !-->
                <input id="overlay-search" class="no-border overlay-search bg-transparent" placeholder="Search..." autocomplete="off" spellcheck="false">
                <br>
                <div class="inline-block">
                    <div class="checkbox right">
                        <input id="checkboxn" type="checkbox" value="1" checked="checked">
                        <label for="checkboxn"><i class="fa fa-search"></i> Search within page</label>
                    </div>
                </div>
                <div class="inline-block m-l-10">
                    <p class="fs-13">Press enter to search</p>
                </div>
                <!-- END Overlay Controls !-->
            </div>
            <!-- BEGIN Overlay Search Results, This part is for demo purpose, you can add anything you like !-->
            <div class="container-fluid">
                <span>
                    <strong>suggestions :</strong>
                </span>
                <span id="overlay-suggestions"></span>
                <br>
                <div class="search-results m-t-40">
                    <p class="bold">Pages Search Results</p>
                    <div class="row">
                        <div class="col-md-6">
                            <!-- BEGIN Search Result Item !-->
                            <div class="">
                                <!-- BEGIN Search Result Item Thumbnail !-->
                                <div class="thumbnail-wrapper d48 circular bg-success text-white inline m-t-10">
                                    <div>
                                        <img width="50" height="50" src="/Pages/assets/img/profiles/avatar.jpg" data-src="/Pages/assets/img/profiles/avatar.jpg" data-src-retina="/Pages/assets/img/profiles/avatar2x.jpg" alt="">
                                    </div>
                                </div>
                                <!-- END Search Result Item Thumbnail !-->
                                <div class="p-l-10 inline p-t-5">
                                    <h5 class="m-b-5"><span class="semi-bold result-name">ice cream</span> on pages</h5>
                                    <p class="hint-text">via john smith</p>
                                </div>
                            </div>
                            <!-- END Search Result Item !-->
                            <!-- BEGIN Search Result Item !-->
                            <div class="">
                                <!-- BEGIN Search Result Item Thumbnail !-->
                                <div class="thumbnail-wrapper d48 circular bg-success text-white inline m-t-10">
                                    <div>T</div>
                                </div>
                                <!-- END Search Result Item Thumbnail !-->
                                <div class="p-l-10 inline p-t-5">
                                    <h5 class="m-b-5"><span class="semi-bold result-name">ice cream</span> related topics</h5>
                                    <p class="hint-text">via pages</p>
                                </div>
                            </div>
                            <!-- END Search Result Item !-->
                            <!-- BEGIN Search Result Item !-->
                            <div class="">
                                <!-- BEGIN Search Result Item Thumbnail !-->
                                <div class="thumbnail-wrapper d48 circular bg-success text-white inline m-t-10">
                                    <div>
                                        <i class="fa fa-headphones large-text "></i>
                                    </div>
                                </div>
                                <!-- END Search Result Item Thumbnail !-->
                                <div class="p-l-10 inline p-t-5">
                                    <h5 class="m-b-5"><span class="semi-bold result-name">ice cream</span> music</h5>
                                    <p class="hint-text">via pagesmix</p>
                                </div>
                            </div>
                            <!-- END Search Result Item !-->
                        </div>
                        <div class="col-md-6">
                            <!-- BEGIN Search Result Item !-->
                            <div class="">
                                <!-- BEGIN Search Result Item Thumbnail !-->
                                <div class="thumbnail-wrapper d48 circular bg-info text-white inline m-t-10">
                                    <div>
                                        <i class="fa fa-facebook large-text "></i>
                                    </div>
                                </div>
                                <!-- END Search Result Item Thumbnail !-->
                                <div class="p-l-10 inline p-t-5">
                                    <h5 class="m-b-5"><span class="semi-bold result-name">ice cream</span> on facebook</h5>
                                    <p class="hint-text">via facebook</p>
                                </div>
                            </div>
                            <!-- END Search Result Item !-->
                            <!-- BEGIN Search Result Item !-->
                            <div class="">
                                <!-- BEGIN Search Result Item Thumbnail !-->
                                <div class="thumbnail-wrapper d48 circular bg-complete text-white inline m-t-10">
                                    <div>
                                        <i class="fa fa-twitter large-text "></i>
                                    </div>
                                </div>
                                <!-- END Search Result Item Thumbnail !-->
                                <div class="p-l-10 inline p-t-5">
                                    <h5 class="m-b-5">Tweats on<span class="semi-bold result-name"> ice cream</span></h5>
                                    <p class="hint-text">via twitter</p>
                                </div>
                            </div>
                            <!-- END Search Result Item !-->
                            <!-- BEGIN Search Result Item !-->
                            <div class="">
                                <!-- BEGIN Search Result Item Thumbnail !-->
                                <div class="thumbnail-wrapper d48 circular text-white bg-danger inline m-t-10">
                                    <div>
                                        <i class="fa fa-google-plus large-text "></i>
                                    </div>
                                </div>
                                <!-- END Search Result Item Thumbnail !-->
                                <div class="p-l-10 inline p-t-5">
                                    <h5 class="m-b-5">Circles on<span class="semi-bold result-name"> ice cream</span></h5>
                                    <p class="hint-text">via google plus</p>
                                </div>
                            </div>
                            <!-- END Search Result Item !-->
                        </div>
                    </div>
                </div>
            </div>
            <!-- END Overlay Search Results !-->
        </div>
        <!-- END Overlay Content !-->
    </div>*@
    <!-- END OVERLAY -->
    <!-- BEGIN VENDOR JS -->
    @*<script src="~/Pages/assets/plugins/pace/pace.min.js" type="text/javascript"></script>*@
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
    @*<script src="~/Pages/assets/plugins/nvd3/lib/d3.v3.js" type="text/javascript"></script>
        <script src="~/Pages/assets/plugins/nvd3/nv.d3.min.js" type="text/javascript"></script>
        <script src="~/Pages/assets/plugins/nvd3/src/utils.js" type="text/javascript"></script>
        <script src="~/Pages/assets/plugins/nvd3/src/tooltip.js" type="text/javascript"></script>
        <script src="~/Pages/assets/plugins/nvd3/src/interactiveLayer.js" type="text/javascript"></script>
        <script src="~/Pages/assets/plugins/nvd3/src/models/axis.js" type="text/javascript"></script>
        <script src="~/Pages/assets/plugins/nvd3/src/models/line.js" type="text/javascript"></script>
        <script src="~/Pages/assets/plugins/nvd3/src/models/lineWithFocusChart.js" type="text/javascript"></script>*@
    @*<script src="~/Pages/assets/plugins/mapplic/js/hammer.js"></script>
        <script src="~/Pages/assets/plugins/mapplic/js/jquery.mousewheel.js"></script>*@
    @*<script src="~/Pages/assets/plugins/mapplic/js/mapplic.js"></script>*@
    @*<script src="~/Pages/assets/plugins/rickshaw/rickshaw.min.js"></script>*@
    <script src="~/Pages/assets/plugins/jquery-metrojs/MetroJs.min.js" type="text/javascript"></script>
    <script src="~/Pages/assets/plugins/jquery-sparkline/jquery.sparkline.min.js" type="text/javascript"></script>
    <script src="~/Pages/assets/plugins/skycons/skycons.js" type="text/javascript"></script>
    <script src="~/Pages/assets/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js" type="text/javascript"></script>
    <script src="~/Pages/assets/plugins/jquery-validation/js/jquery.validate.js" type="text/javascript"></script>
    @RenderSection("javascripts_vendor", required:=False)
    <!-- END VENDOR JS -->
    <!-- BEGIN CORE TEMPLATE JS -->
    <script src="~/Scripts/jquery.signalR-2.2.0.js" type="text/javascript"></script>
    <script src="/signalr/hubs" type="text/javascript"></script>
    <script src="~/Pages/pages/js/pages.js" type="text/javascript"></script>
    <!-- END CORE TEMPLATE JS -->
    <!-- BEGIN PAGE LEVEL JS -->
    @*<script src="~/Pages/assets/js/dashboard.js" type="text/javascript"></script>*@
    <script src="~/Pages/assets/js/scripts.js" type="text/javascript"></script>
    <!-- END PAGE LEVEL JS -->
    <script>
        $(document).ready(function () {
            $("#txtBuscarEnMenu").keyup(function () {
                var that = this;
                $("ul.menu-items").find("li").removeClass("hide")
                $("ul.menu-items").find("li").removeClass("tomado");
                $("ul.menu-items").find("span.title").each(function () {
                    if ($(this).text().toLowerCase().indexOf($(that).val().trim().toLowerCase()) >= 0) {
                        $(this).parents("li").removeClass("hide").addClass("tomado");
                    }
                    else {
                        $(this).parents("li").each(function () {
                            if ($(this).hasClass("tomado") == false) {
                                $(this).addClass("hide");
                            }
                        });
                    }
                });
            });

            $('.cambiar-lenguaje').click(function () {
                var lang = $(this).data('lang');
                var $frame = $('.goog-te-menu-frame:first');
                if (!$frame.size()) {
                    alert("Error: Could not find Google translate frame.");
                    return false;
                }
                $frame.contents().find('.goog-te-menu2-item span.text').each(function () {
                    if ($(this).text().toLowerCase() == lang.toLowerCase()) {
                        $(this).get(0).click();
                    }
                });
                return false;
            });
        });
    </script>
    @RenderSection("javascripts_custom", required:=False)
</body>

</html>