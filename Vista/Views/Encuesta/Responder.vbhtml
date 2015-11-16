@ModelType EE.Encuesta

@*<style>
        .radio input[type="radio"] {
            margin-left: 0px !important;
        }
    </style>*@
@Code
    If Model IsNot Nothing Then
    @<div class="panel panel-default">
        <div class="panel-heading">
            <div class="panel-title">
                @Model.Tipo
            </div>
        </div>
        <div class="panel-body">
            @Using Html.BeginForm()
                @Html.HiddenFor(Function(model) model.Id)
                @Model.Pregunta
                @<br />
                @<br />
                @For index = 0 To Model.ListaOpciones.Count() - 1
                        Dim i As Integer = index
                    @Html.RadioButtonFor(Function(model) model.Respuesta, Model.ListaOpciones(i).Id) @:&nbsp; @Model.ListaOpciones(i).Valor
                    @<br />
                    Next
                @<br />
                @<button type="submit" class="btn blue" id="btnResponderEncuesta" disabled>Votar</button>
                End Using
        </div>
    </div>
End If
End Code

