@ModelType IEnumerable(Of EE.Producto)
<div class="row m-t-20">
    <div class="col col-lg-3">
        <form method="post" action="@Url.Action("Comparar", "Producto")" id="formComprar">
            <input type="hidden" value="" id="productosId" name="productosId" />
            <input type="submit" value="Comparar" class="btn btn-primary btn-cons m-t-25 m-l-10">
        </form>
    </div>
    <div class="col col-lg-3">
        <div class="form-group">
            <label>Tema</label>
            <select class="filtro full-width select2-offscreen" id="cmbTema">
                <option value=""></option>
                @Code
                    If ViewBag.Temas IsNot Nothing Then
                        For Each t As EE.Tema In ViewBag.Temas
                            @<option value=".@t.Tema.Replace(" ","")">@t.Tema</option>
                        Next
                    End If
                End Code
            </select>
        </div>
    </div>
    <div class="col col-lg-3">
        <div class="form-group">
            <label>Tipo Producto</label>
            <select class="filtro full-width select2-offscreen" id="cmbTipoProducto">
                <option value=""></option>
                @Code
                    If ViewBag.TipoProductos IsNot Nothing Then
                        For Each t As EE.TipoProducto In ViewBag.TipoProductos
                    @<option value=".@t.Tipo.Replace(" ", "")">@t.Tipo</option>
                        Next
                    End If
                End Code
            </select>
        </div>
    </div>
</div>
<div class="row">
    <div class="col col-lg-12">
        <div class="gallery" style="margin-top: 0px;">
            @Code
                Dim i As Integer = 1
                For Each producto As EE.Producto In Model
                    If i = 1 Then
            @<div class="gallery-item first @producto.Tema.Tema.Replace(" ","") @producto.TipoProducto.Tipo.Replace(" ", "")" data-width="1" data-height="1">
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
                    <h5 class="text-white light">@producto.TipoProducto.Tipo</h5>
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
            @<div class="gallery-item @producto.Tema.Tema.Replace(" ","") @producto.TipoProducto.Tipo.Replace(" ", "")" data-width="2" data-height="2">
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
                    <h5 class="text-white light">@producto.TipoProducto.Tipo</h5>
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
            @<div class="gallery-item @producto.Tema.Tema.Replace(" ","") @producto.TipoProducto.Tipo.Replace(" ", "")" data-width="1" data-height="1">
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
                    <h5 class="text-white light">@producto.TipoProducto.Tipo</h5>
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

            $("#cmbTema").select2({
                placeholder: "Seleccione un tema",
                allowClear: true
            });
            $("#cmbTipoProducto").select2({
                placeholder: "Seleccione un tipo de producto",
                allowClear: true
            });

            $(".filtro").change(function () {
                var tema = $("#cmbTema").val();
                var tipo = $("#cmbTipoProducto").val();
                $gallery.isotope({ filter: tema + tipo });
            });
        });
    </script>
End Section
