﻿Imports System.ComponentModel.DataAnnotations
Public Class Encuesta

    Private vId As Integer
    Public Property Id() As Integer
        Get
            Return vId
        End Get
        Set(ByVal value As Integer)
            vId = value
        End Set
    End Property

    Private vFechaVigencia As Date = Now.Date
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Fecha Vigencia"), DisplayFormat(ApplyFormatInEditMode:=True, DataFormatString:="{0:dd/MM/yyyy}")>
    Public Property FechaVigencia() As Date
        Get
            Return vFechaVigencia
        End Get
        Set(ByVal value As Date)
            vFechaVigencia = value
        End Set
    End Property

    Private vPregunta As String
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Pregunta")>
    Public Property Pregunta() As String
        Get
            Return vPregunta
        End Get
        Set(ByVal value As String)
            vPregunta = value
        End Set
    End Property

    Private vTipo As String
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Tipo")>
    <StringLength(50, ErrorMessage:="Se ha superado la longitud permitida de 50 caracteres.")>
    Public Property Tipo() As String
        Get
            Return vTipo
        End Get
        Set(ByVal value As String)
            vTipo = value
        End Set
    End Property

    Private vListaOpciones As New List(Of Opcion)
    <ListaOpcionesRequired(ErrorMessage:="Debe agregar al menos una opción y completarla")>
    Public Property ListaOpciones() As List(Of Opcion)
        Get
            Return vListaOpciones
        End Get
        Set(ByVal value As List(Of Opcion))
            vListaOpciones = value
        End Set
    End Property

    Private vRespuesta As String
    Public Property Respuesta() As String
        Get
            Return vRespuesta
        End Get
        Set(ByVal value As String)
            vRespuesta = value
        End Set
    End Property

End Class
