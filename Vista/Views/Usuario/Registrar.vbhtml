@ModelType Vista.RegistrarViewModel

@section breadcrumb
    <ul class="breadcrumb">
        <li>
            <p>Inicio</p>
        </li>
        <li>
            <a href="#" class="active">Registrarse</a>
        </li>
    </ul>
end section

<div class="row">
    <div class="col-md-6">
        <!-- START PANEL -->
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="panel-title">
                    Formulario de registro de usuarios
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
                        <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.NombreUsu))), Nothing, "has-error"))">
                            @Html.LabelFor(Function(model) model.NombreUsu)
                            @Html.TextBoxFor(Function(model) model.NombreUsu, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.NombreUsu, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Clave))), Nothing, "has-error"))">
                            @Html.LabelFor(Function(model) model.Clave)
                            @Html.PasswordFor(Function(model) model.Clave, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.Clave, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group form-group-default required @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.ConfirmaClave))), Nothing, "has-error"))">
                            @Html.LabelFor(Function(model) model.ConfirmaClave)
                            @Html.PasswordFor(Function(model) model.ConfirmaClave, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.ConfirmaClave, Nothing, New With {.class = "help-block"})
                        </div>
                         <div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Aceptar))), Nothing, "has-error"))">
                             @Html.CheckBoxFor(Function(model) model.Aceptar)
                             <label for="Aceptar">Acepto <a href="#" data-target="#modalStickUpSmall" data-toggle="modal">términos y condiciones</a></label>
                             @Html.ValidationMessageFor(Function(model) model.Aceptar, Nothing, New With {.class = "help-block"})
                        </div>
                        <button type="submit" class="btn btn-primary btn-cons">Grabar</button>
                    </fieldset>
                End Using
            </div>
        </div>
        <!-- END PANEL -->
    </div>
</div>

<div class="modal fade stick-up" id="modalStickUpSmall" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-lg">
        <div class="modal-content-wrapper">
            <div class="modal-content">
                <div class="modal-header clearfix text-left">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        <i class="pg-close fs-14"></i>
                    </button>
                    <h5>Términos y Condiciones</h5>
                </div>
                <div class="modal-body">
                    Al acceder o utilizar este Sitio Web, usted acepta estos Términos y Condiciones de Uso y Privacidad. Si usted no acepta los Términos y Condiciones de Uso, usted no puede utilizar este Sitio Web.

                    Registro. Contraseña

                    El titular se reserva el derecho de solicitar la registración del Visitante para la
                    Página Web, toda o parte de ella, que previamente haya sido de libre acceso y, en tal caso, está facultada, en cualquier momento y sin expresión de causa, a denegar al usuario el acceso al área protegida por contraseñas, en particular si el usuario:
                    1) Proporciona datos incorrectos con el fin de registrarse;
                    2) Incumple estos Términos y Condiciones de Uso y Privacidad;
                    3) Incumple cualquier normativa aplicable respecto del acceso o el uso de la presente Página Web.

                    Links

                    Este Sitio Web puede incluir conexiones a otros sitios web operados por otras compañías y/o operados por terceros. Estas conexiones son provistas para su comodidad y como una avenida de acceso adicional para las informaciones contenidas en los mismos. No hemos revisado toda la información contenida en otros sitios y no somos responsables por el contenido de otros sitios web ni por los productos o servicios que pudieran ser ofrecidos a través de otros sitios. Sitios web de terceros pueden contener información con la cual Asahi concuerda o no. Diferentes términos y condiciones pueden resultar aplicables al uso por vuestra parte de cualquiera de dichos sitios web conectados. Por favor tenga en consideración que los términos y condiciones de uso de otros sitios web son sustancialmente diferentes de estos términos y condiciones.

                    Precisión, integridad y actualidad de la Información en este Sitio Web

                    No somos responsables si las informaciones que estuvieran disponibles en este Sitio Web no fueran precisas, completas o actualizadas. El material en este Sitio Web es provisto solamente para información general y no debe ser tomado como base o usado como la única base para tomar decisiones sin antes consultar fuentes de información primaria más precisas, completas y/o actualizadas.
                    Cualquier confianza depositada en el material de este Sitio Web será a su propio riesgo. Este Sitio Web puede contener cierta información histórica. Las informaciones históricas no son necesariamente actualizadas y son provistas únicamente para su referencia. Hacemos reserva del derecho de modificar el contenido de este Sitio Web en cualquier ocasión sin previo aviso. Ud. acuerda que es su responsabilidad monitorear alteraciones o modificaciones en este Sitio
                    Web.

                    Uso de Material de este Sitio Web

                    Este Sitio Web (incluyendo todo su contenido) es propiedad de Invitaciones Asahi de sus licenciantes y está protegido por leyes de derecho de autor y de marcas. Excepto cuando fuera expresamente dispuesto de otro modo, autorizamos a Ud. a consultar este Sitio Web y a
                    imprimir y descargar copias del material del Sitio Web solamente para su uso personal, no comercial, ello en la medida en que Ud. no elimine o remueva cualquier notificación o información de derechos de autor o propiedad intelectual que aparecieran en el material que Ud. imprimiera o descargara. Ud. acuerda que salvo lo expuesto precedentemente, no reproducirá, distribuirá, mostrará o transmitirá cualquier material en el Sitio Web, de cualquier manera y/o por cualquier medio. Ud. también acuerda no modificar, vender, transmitir o
                    distribuir cualquier material en el Sitio Web, de cualquier manera o en cualquier medio, incluyendo la carga del material o de otro modo poner el material disponible en línea.

                    Marcas

                    Este Sitio Web incluye y presenta logos, logotipos y otras marcas comerciales y marcas de servicio que son propiedad de, o son licenciadas a, varias afiliadas de Asahi. El Sitio Web también puede incluir marcas comerciales o marcas de servicio de terceros. Todas esas marcas comerciales son propiedad de sus respectivos titulares y Ud. acuerda no usar o mostrar las mismas de cualquier forma sin la autorización previa por escrito del propietario de la marca comercial en cuestión.

                    Contenido del visitante

                    La Página Web podría permitir el upload de información, datos, textos, software, música, sonido, fotografías, gráficos, video, mensajes u otros materiales ("Contenido"), sea que se fijen públicamente o se transmitan privadamente. En tal caso, dicho Contenido es únicamente responsabilidad de la persona que lo originó. Esto significa que usted (y no Asahi) es enteramente responsable por todo el Contenido que usted cargue, publique, envíe por correo electrónico, transmita o de cualquier forma ponga a disposición a través del Sitio Web.
                    Nosotros no controlamos el Contenido publicado por Ud. a través del Sitio Web y, por tal motivo, no garantizamos su exactitud, integridad o calidad. No obstante, el Sitio Web contará con un moderador (Asahi) que estará facultado a eliminar el Contenido que le parezca impropio. Asimismo, Asahi eliminará todo Contenido ante la denuncia de aquellos terceros que se vean afectados y/o lesionados en sus derechos. Bajo ninguna circunstancia Asahi será responsable en cualquier forma por cualquier Contenido, incluyendo, pero sin limitarse a cualquier error u omisión en cualquier Contenido, o por cualquier pérdida o daño de cualquier tipo ocasionado como resultado del uso de cualquier Contenido publicado, enviado a través de correo electrónico, transmitido o puesto a disposición a través del Sitio Web.
                    Nosotros nos reservamos el derecho de eliminar el acceso y/o uso del Sitio Web a cualquier usuario y/o visitante del mismo (“Visitante”) que no respete los términos y condiciones establecidos en el presente. Asimismo, nosotros nos reservamos el derecho de eliminar cualquier mensaje que:
                    •Sea ilegal, peligroso, amenazante, abusivo, hostigador, tortuoso, difamatorio, vulgar, obsceno, calumnioso, invasivo de la privacidad de terceros, odioso, discriminatorio, o que de cualquier forma viole derechos de terceros y/o disposiciones legales aplicables;
                    •Sea contrario a la moral y las buenas costumbres.
                    •Ofrezca, venda o de cualquier modo comercialice bienes o servicios.
                    •Ofrezca cualquier actividad que sea lucrativa para el Visitante.
                    Usted se obliga a no utilizar el Sitio Web para lo siguiente:
                    •Dañar a menores de edad en cualquier forma;
                    •Hacerse pasar por alguna persona o entidad, incluyendo, pero sin limitarse, a un funcionario o empleado de Asahi o hacer declaraciones falsas, o de cualquier otra forma falsificar su asociación a alguna persona o entidad;
                    •Falsificar encabezados o de cualquier otra forma manipular identificadores para desviar el  origen de algún Contenido transmitido por medio del Sitio Web;
                    •Cargar ("upload"), publicar, enviar por correo electrónico, transmitir, o de cualquier otra forma poner a disposición algún Contenido del cual no tiene el derecho de transmitir por ley o bajo relación contractual o fiduciaria (tal como información interna, de propiedad y confidencial adquirida o entregada como parte de las relaciones de empleo o bajo contratos de confidencialidad);
                    •Cargar, publicar, enviar por correo electrónico, transmitir, o de cualquier otra forma poner a disposición algún Contenido que viole alguna patente, marca, secreto comercial, derecho de autor o cualquier derecho de propiedad ("Derechos") de algún tercero;
                    •Cargar, publicar, enviar por correo electrónico, transmitir o de cualquier otra forma poner a disposición cualquier anuncio no solicitado o no autorizado, materiales promocionales, correo no solicitado ("junk mail", "spam"), cartas en cadena ("chain letters"), esquemas de pirámides
                    ("pyramid schemes") o cualquier otra forma de solicitud, con excepción de aquellas áreas (tales como cuartos de compras, "shopping rooms") que están destinadas para tal propósito
                    •Cargar ("upload"), publicar, enviar por correo electrónico, transmitir, o de cualquier otra forma poner a disposición algún material que contenga virus de software, o cualquier otro código de computadora, archivos o programas diseñados para interrumpir, destruir o limitar el funcionamiento de algún software, hardware o equipo de telecomunicaciones;
                    •Interrumpir el flujo normal de diálogo, hacer que una pantalla se mueva ("scroll") más rápido de lo que otros Visitantes pueden manejar, o de cualquier otra forma actuar de manera que afecte negativamente la habilidad de otros Visitantes para vincularse en intercambios de tiempo reales;
                    •Interferir o interrumpir el Sitio Web, servidores, o redes conectadas al Sitio Web, o desobedecer cualquier requisito, procedimiento, política o regulación de redes conectadas al Sitio Web;
                    •Violar con o sin intención alguna ley local, estatal, nacional o internacional aplicable y cualquier otra regulación;
                    •Acechar o de cualquier otra forma hostigar a un tercero; o
                    •Colectar o guardar datos personales acerca de otros Visitantes.
                    •Publicar datos personales sin el consentimiento de la persona involucrada.
                    Asahi en ningún caso será responsable por la destrucción o eliminación de la información que los Visitantes incluyan en sus mensajes.

                    Privacidad del Visitante

                    Será de aplicación sobre la Privacidad del Visitante lo estipulado en el siguiente
                    link: http://www.invitacionesasahi.com.ar/resource/privacynotice/index.aspx.

                    Datos personales

                    Datos personales es cualquier información que permite identificar a un individuo.
                    Las clases de datos personales que el presente sitio puede recolectar incluyen el nombre y el apellido de la persona, domicilio, número de teléfono, DNI y dirección de correo electrónico (datos no sensibles). El titular de este sitio no recabará ningún dato personal sobre su persona a menos que Ud. voluntariamente lo provea o de otro modo lo permita la normativa aplicable sobre protección de datos personales. En consecuencia, quien provee los datos reconoce que proporciona sus datos en forma absolutamente voluntaria y que los mismos son ciertos.
                    Advertencia (“Phishing”): Asahi no solicita información de tipo financiera ni bancaria. Todo mensaje que solicite dicha información no proviene de Asahi.
                    El ingreso de los datos personales implica el consentimiento del Visitantes a ceder sus datos y ser parte de la base de datos de las distintas marcas de Asahi. Aquellos que deseen tener acceso a sus datos personales y/o eliminarlos de la base de datos, deberán comunicarse a 0800-51950.

                    Otra Información que Ud. envíe

                    Si Ud. usa las características de comunicación de este Sitio Web para proveernos
                    otra información mas allá de su información personal y datos identificatorios, incluyendo sugerencias acerca del Sitio Web, ideas sobre productos y publicidad, y cualquier otra información relacionada, tales informaciones pasan a pertenecer en forma gratuita a nosotros y pueden ser usadas, reproducidas, modificadas, distribuidas y divulgadas por nosotros de cualquier forma que escojamos.

                    DESCARGO DE RESPONSABILIDAD

                    ASAHI NO DECLARA NI GARANTIZA QUE EL CONTENIDO DEL SITIO WEB
                    ES EXACTO Y COMPLETO. ESTE SITIO WEB Y EL MATERIAL, LA
                    INFORMACIÓN, LOS SERVICIOS Y LOS PRODUCTOS EN ESTE SITIO WEB,
                    INCLUYENDO, SIN CARÁCTER LIMITATIVO, EL TEXTO, LOS GRÁFICOS Y LOS
                    ENLACES SE PROPORCIONAN EN EL ESTADO EN QUE SE ENCUENTRAN Y SIN
                    GARANTÍAS DE NINGÚN TIPO, YA SEAN EXPRESAS O IMPLÍCITAS. EN LA
                    MAYOR MEDIDA PERMITIDA CONFORME A LA LEY APLICABLE, ASAHI
                    NIEGA TODA GARANTÍA, EXPRESA O IMPLÍCITA, INCLUYENDO, PERO SIN
                    CARÁCTER LIMITATIVO, TODAS LAS GARATÍAS DE COMERCIALIZACIÓN O DE
                    ADECUACIÓN PARA UN FIN ESPECÍFICO, DE NO VIOLACIÓN, DE PRODUCTO
                    LIBRE DE VIRUS INFORMÁTICOS, Y TODA GARANTÍA QUE SURJA EN EL
                    CURSO DE LA OPERACIÓN O DURANTE EL CUMPLIMIENTO DE LA MISMA.
                    ASAHI NO DECLARA NI GARANTIZA QUE LAS FUNCIONES
                    CONTEMPLADAS EN EL SITIO WEB SERÁN ININTERRUMPIDAS O QUE
                    ESTARÁN LIBRES DE ERRORES, QUE LOS DEFECTOS SERÁN CORREGIDOS O
                    QUE ESTE SITIO WEB O EL SERVIDOR QUE HACE QUE EL SITIO WEB ESTÉ
                    DISPONBILE ESTÁN LIBRES DE VIRUS U OTROS ELEMENTOS DAÑINOS.
                    ASAHI NO EFECTÚA NINGUNA DECLARACIÓN O GARANTÍA RESPECTO
                    DEL USO DEL MATERIAL EN ESTE SITIO WEB EN CUANTO A SI EL MATERIAL
                    ES COMPLETO, CORRECTO, EXACTO, ADECUADO, ÚTIL, OPORTUNO,
                    CONFIABLE. ADEMÁS DE LO PRECEDENTEMENTE MENCIONADO, USTED (Y
                    NO ASAHI) ASUME TODO EL COSTO DE TODOS LOS SERVICIOS,
                    REPARACIONES O CORRECCIONES QUE FUERAN NECESARIOS.

                    LIMITACIÓN DE RESPONSABILIDAD

                    CON EL MAYOR ALCANCE PERMITIDO POR LA LEGISLACIÓN APLICABLE, UD.
                    ENTIENDE Y ACUERDA QUE NI ASAHI NI CUALQUIERA DE SUS
                    RESPECTIVAS SUBSIDIARIAS O AFILIADAS O TERCEROS PROVEDORES DE
                    CONTENIDO SERAN RESPONSABLES POR CUALQUIER DAÑO DIRECTO,
                    INDIRECTO, INCIDENTAL, ESPECIAL, MEDIATO, INMEDIATO, CONSECUENTE,
                    PUNITIVO O CUALQUIER OTRO, RELATIVOS A O RESULTANTES DE SU USO O
                    SU INCAPACIDAD DE USAR ESTE SITIO WEB O CUALQUIER OTRO SITIO WEB
                    QUE UD. ACCEDIERA A TRAVÉS DE UNA CONEXIÓN A PARTIR DE ESTE SITIO
                    WEB O DE CUALQUIER MEDIDA QUE TOMEMOS O DEJEMOS DE TOMAR
                    COMO RESULTADO DE MENSAJES DE CORREO ELECTRONICO QUE UD. NOS
                    ENVIE. ESTOS INCLUYEN DAÑOS POR ERRORES, OMISIONES,
                    INTERRUPCIONES, DEFECTOS, ATRASOS, VÍRUS INFORMÁTICOS, SU LUCRO
                    CESANTE, PERDIDA DE DATOS, ACCESO NO AUTORIZADO A Y ALTERACIÓN
                    DE SUS TRANSMISIONES Y DATOS, Y OTRAS PERDIDAS TANGIBLES E
                    INTANGIBLES.
                    ESTA LIMITACIÓN RESULTA APLICABLE INDEPENDIENTEMENTE DE SI LOS
                    DAÑOS Y PERJUICIOS FUERAN RECLAMADOS EN VIRTUD DE UN CONTRATO,
                    COMO RESULTADO DE NEGLIGENCIA O DE OTRO MODO, E IGUALMENTE SI
                    NOSOTROS O NUESTROS REPRESENTANTES HUBIEREN SIDO NEGLIGENTES
                    O HUBIEREN SIDO INFORMADOS SOBRE LA POSIBILIDAD DE TALES DAÑOS.

                    SU RESPONSABILIDAD

                    SI UD. CAUSARA UNA INTERRUPCIÓN TÉCNICA DE ESTE SITIO WEB O DE LOS
                    SISTEMAS QUE TRANSMIETEN EL SITIO WEB A UD. Y A OTROS, UD. ASUME
                    LAS RESPONSABILIDAD POR TODAS Y CUALQUIER RESPONSABILIDADES,
                    COSTOS Y GASTOS (INCLUYENDO HONORARIOS DE ABOGADOS) QUE
                    SURGIERAN COMO CONSECUENCIA DE DICHA INTERUPCIÓN.

                    Jurisdicción
                    Asahi tiene sede en Argentina y este Sitio Web es operado en Argentina. Ud. acepta en
                    forma irrevocable la jurisdicción de los tribunales de la Ciudad de Buenos Aires, en
                    relación con cualquier acción para la ejecución de estos términos y condiciones.
                    Reconocemos que es posible que Ud. obtenga acceso a este Sitio Web desde cualquier lugar en el mundo, pero no tenemos capacidad práctica para impedir tal acceso. Este Sitio Web fue proyectado para cumplir con las leyes de la República Argentina. Si cualquier material
                    en este Sitio Web, o el uso de este Sitio Web por Ud. fuera contrario a las leyes del
                    lugar en el cual Ud. estuviera al acceder al mismo, el Sitio Web no está destinado
                    a Ud. y le solicitamos que no utilice el Sitio Web. Ud. es responsable por informarse respecto a las leyes de su jurisdicción y por el cumplimiento de las mismas.

                    Terminación

                    Usted acepta que Asahi puede, bajo ciertas circunstancias y sin necesidad de notificación previa, cancelar y terminar inmediatamente su posibilidad de acceso al Sitio Web. Entre las causales de terminación se incluyen, sin limitarse: (a) incumplimientos o violaciones a estos términos y condiciones; (b) requerimientos de autoridades legales o gubernamentales; (c) su solicitud (terminación de cuenta por requerimiento del Visitante); (d) terminación o modificaciones sustanciales al Servicio (o cualquier parte del mismo); (e) problemas técnicos o de seguridad inesperados; (f) períodos de inactividad prolongados. Asimismo, usted acepta que todas las causales de terminación con causa podrán ser invocadas por nosotros a nuestra sola discreción y que no seremos responsables frente a usted ni frente a ningún tercero por cualquier terminación de su cuenta, y las direcciones de correo electrónico asociada o acceso al Sitio Web.

                    Modificaciones a estos Términos

                    Hacemos reserva del derecho, a nuestro exclusivo y completo criterio, de alterar estos términos y condicionas en cualquier ocasión, mediante la muestra en el Sitio Web de nuevos términos y condiciones. Es su responsabilidad verificar periódicamente cualquier alteración que pudiéramos realizar sobre estos términos y condiciones. Su uso continuado de este Sitio Web luego de la presentación de nuevos términos y condiciones implicará y significará su aceptación a las modificaciones introducidas. Gracias por visitar nuestro Sitio Web.

                </div>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>


