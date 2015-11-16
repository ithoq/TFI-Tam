@ModelType IEnumerable(Of EE.Producto)
<h3>Tarjetería Social</h3>

<div class="row">
    <div class="col col-lg-12">
        <form method="post" action="@Url.Action("Comparar", "Producto")" id="formComprar">
            <input type="hidden" value="" id="productosId" name="productosId" />
            <input type="submit" value="Comparar" class="btn btn-primary btn-cons">
        </form>
    </div>
</div>
<div class="row">
    <div class="col col-lg-12">
        <div class="gallery">
            @Code
                Dim i As Integer = 1
                For Each producto As EE.Producto In Model
                    If i = 1 Then
                    @<div class="gallery-item first" data-width="1" data-height="1">
                        <!-- START PREVIEW -->
                        <img src="@producto.Fondo" alt="" class="image-responsive-height">
                        <!-- END PREVIEW -->
                        <!-- START ITEM OVERLAY DESCRIPTION -->
                        <div class="overlayer bottom-left full-width">
                            <div class="overlayer-wrapper item-info more-content">
                                <div class="gradient-grey p-l-20 p-r-20 p-t-20 p-b-5">
                                    <div class="">
                                        <h3 class="pull-left bold text-white no-margin">@producto.Nombre</h3>
                                        <h3 class="pull-right semi-bold text-white font-montserrat bold no-margin">$@producto.ObtenerPrecioConIva()</h3>
                                        <div class="clearfix"></div>
                                        <span class="hint-text pull-left text-white">@producto.Tema.Tema</span>
                                        <span class="pull-right"><input type="checkbox" class="comparar" value="@producto.Id" /> Comparar</span>
                                        <div class="clearfix"></div>
                                    </div>
                                    <div class="">
                                        <h5 class="text-white light">@producto.TipoProducto.ToString()</h5>
                                    </div>
                                    <div class="m-t-10">
                                        @*<div class="thumbnail-wrapper d32 circular m-t-5">
                                                <img width="40" height="40" src="assets/img/profiles/avatar.jpg" data-src="assets/img/profiles/avatar.jpg" data-src-retina="assets/img/profiles/avatar2x.jpg" alt="">
                                            </div>*@
                                        <div class="inline m-l-10">
                                            <p class="no-margin text-white fs-12">Valoraciones</p>
                                            <p class="rating">
                                                @Code
                                                            For index = 1 To 5
                                                                If index <= producto.Valoracion Then
                                                    @<i class="fa fa-star rated"></i>
                                                                Else
                                                    @<i class="fa fa-star"></i>
                                                                End If
                                                            Next
                                                End Code
                                            </p>
                                        </div>
                                        <div class="pull-right m-t-10">
                                            <a class="btn btn-white btn-xs btn-mini bold fs-14" href="@Url.Action("Agregar", "Producto", New With {.id = producto.Id})">+</a>
                                        </div>
                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- END PRODUCT OVERLAY DESCRIPTION -->
                    </div>
                    ElseIf i = 2 Then
                    @<div class="gallery-item " data-width="2" data-height="2">
                        <!-- START PREVIEW -->
                        <img src="@producto.Fondo" alt="" class="image-responsive-height">
                        <!-- END PREVIEW -->
                        <!-- START ITEM OVERLAY DESCRIPTION -->
                        <div class="overlayer bottom-left full-width">
                            <div class="overlayer-wrapper item-info more-content">
                                <div class="gradient-grey p-l-20 p-r-20 p-t-20 p-b-5">
                                    <div class="">
                                        <h3 class="pull-left bold text-white no-margin">@producto.Nombre</h3>
                                        <h3 class="pull-right semi-bold text-white font-montserrat bold no-margin">$@producto.ObtenerPrecioConIva()</h3>
                                        <div class="clearfix"></div>
                                        <span class="hint-text pull-left text-white">@producto.Tema.Tema</span>
                                        <span class="pull-right"><input type="checkbox" class="comparar" value="@producto.Id" /> Comparar</span>
                                        <div class="clearfix"></div>
                                    </div>
                                    <div class="">
                                        <h5 class="text-white light">@producto.TipoProducto.ToString()</h5>
                                    </div>
                                    <div class="m-t-10">
                                        @*<div class="thumbnail-wrapper d32 circular m-t-5">
                                                <img width="40" height="40" src="assets/img/profiles/avatar.jpg" data-src="assets/img/profiles/avatar.jpg" data-src-retina="assets/img/profiles/avatar2x.jpg" alt="">
                                            </div>*@
                                        <div class="inline m-l-10">
                                            <p class="no-margin text-white fs-12">Valoraciones</p>
                                            <p class="rating">
                                                @Code
                                                            For index = 1 To 5
                                                                If index <= producto.Valoracion Then
                                                    @<i class="fa fa-star rated"></i>
                                                                Else
                                                    @<i class="fa fa-star"></i>
                                                                End If
                                                            Next
                                                End Code
                                            </p>
                                        </div>
                                        <div class="pull-right m-t-10">
                                            <a class="btn btn-white btn-xs btn-mini bold fs-14" href="@Url.Action("Agregar", "Producto", New With {.id = producto.Id})">+</a>
                                        </div>
                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- END PRODUCT OVERLAY DESCRIPTION -->
                    </div>
                    Else
                    @<div class="gallery-item " data-width="1" data-height="1">
                        <!-- START PREVIEW -->
                        <img src="@producto.Fondo" alt="" class="image-responsive-height">
                        <!-- END PREVIEW -->
                        <!-- START ITEM OVERLAY DESCRIPTION -->
                        <div class="overlayer bottom-left full-width">
                            <div class="overlayer-wrapper item-info more-content">
                                <div class="gradient-grey p-l-20 p-r-20 p-t-20 p-b-5">
                                    <div class="">
                                        <h3 class="pull-left bold text-white no-margin">@producto.Nombre</h3>
                                        <h3 class="pull-right semi-bold text-white font-montserrat bold no-margin">$@producto.ObtenerPrecioConIva()</h3>
                                        <div class="clearfix"></div>
                                        <span class="hint-text pull-left text-white">@producto.Tema.Tema</span>
                                        <span class="pull-right"><input type="checkbox" class="comparar" value="@producto.Id" /> Comparar</span>
                                        <div class="clearfix"></div>
                                    </div>
                                    <div class="">
                                        <h5 class="text-white light">@producto.TipoProducto.ToString()</h5>
                                    </div>
                                    <div class="m-t-10">
                                        @*<div class="thumbnail-wrapper d32 circular m-t-5">
                                                <img width="40" height="40" src="assets/img/profiles/avatar.jpg" data-src="assets/img/profiles/avatar.jpg" data-src-retina="assets/img/profiles/avatar2x.jpg" alt="">
                                            </div>*@
                                        <div class="inline m-l-10">
                                            <p class="no-margin text-white fs-12">Valoraciones</p>
                                            <p class="rating">
                                                @Code
                                                            For index = 1 To 5
                                                                If index <= producto.Valoracion Then
                                                    @<i class="fa fa-star rated"></i>
                                                                Else
                                                    @<i class="fa fa-star"></i>
                                                                End If
                                                            Next
                                                End Code
                                            </p>
                                        </div>
                                        <div class="pull-right m-t-10">
                                            <a class="btn btn-white btn-xs btn-mini bold fs-14" href="@Url.Action("Agregar", "Producto", New With {.id = producto.Id})">+</a>
                                        </div>
                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- END PRODUCT OVERLAY DESCRIPTION -->
                    </div>
                    End If
                    i = i + 1
                Next
            End Code
            <!-- END GALLERY ITEM -->
        </div>
    </div>
    <div class="col col-lg-3">
        @Code
            Html.RenderAction("Responder", "Encuesta", New With {.tipo = "Encuesta"})
        End Code
    </div>
</div>

@Section javascripts_vendor
    <script src="~/Pages/assets/plugins/imagesloaded/imagesloaded.pkgd.min.js"></script>
    <script src="~/Pages/assets/plugins/jquery-isotope/isotope.pkgd.min.js" type="text/javascript"></script>
End Section

@Section javascripts_custom
    <script>
        $(document).ready(function () {
            var $gallery = $('.gallery');
            $gallery.imagesLoaded(function () {
                applyIsotope();
            });

            /*  Apply Isotope plugin
                isotope.metafizzy.co
            */
            var applyIsotope = function () {
                $gallery.isotope({
                    itemSelector: '.gallery-item',
                    masonry: {
                        columnWidth: 280,
                        gutter: 10,
                        isFitWidth: true
                    }
                });
            }

            /*
                Show a sliding item using MetroJS
                http://www.drewgreenwell.com/projects/metrojs
            */
            $(".live-tile,.flip-list").liveTile();
            
            $("#formComprar").submit(function (e) {
                var selectedIds = [];

                $(":checked").each(function () {
                    selectedIds.push($(this).val());
                });

                if (selectedIds.length > 0) {
                    $("#productosId").val(selectedIds);
                    return true;
                } else {
                    e.preventDefault();
                    return false;
                }
            });
        });
    </script>
End Section
