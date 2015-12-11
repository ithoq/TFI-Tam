@ModelType EE.Encuesta

@Code
    If Model IsNot Nothing Then
        If Model.Tipo = "Encuesta" Then
            @<div class="panel panel-default">
                <div class="panel-heading">
                    <div class="panel-title">
                        @Model.Tipo
                    </div>
                </div>
                <div class="panel-body">
                    @Model.Pregunta
                    <br />
                    <br />
                    @Code
                                Dim total As Double = 0
                                For Each o As EE.Opcion In Model.ListaOpciones
                                    total += o.Selecciones
                                Next
                                For Each o As EE.Opcion In Model.ListaOpciones
                                    Dim porcentaje As Double = o.Selecciones * 100 / total
                        @<p class="small hint-text">@o.Valor (@Math.Round(porcentaje, 2)% - Votos: @o.Selecciones)</p>
                        @<div class="progress ">
                            <div class="progress-bar progress-bar-primary" style="width: @Math.Round(porcentaje)%;"></div>
                        </div>
                                Next
                    End Code
                </div>
            </div>
        Else
            @<a href="@Url.Action("Index", "Home")" class="btn btn-primary btn-cons m-t-25">Volver al inicio</a>
        End If
    End If
End Code

