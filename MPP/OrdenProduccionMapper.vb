﻿Imports EE
Imports DAL

Public Class OrdenProduccionMapper

    Private vDatos As Datos

    Sub New()
        Me.vDatos = New Datos
    End Sub

    Public Function Listar() As List(Of OrdenProduccion)
        Dim ds As New DataSet
        Dim lista As New List(Of OrdenProduccion)
        ds = vDatos.Leer("s_ListarOrden", Nothing)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                Dim o As OrdenProduccion = New OrdenProduccion
                o.Id = Item("Id")
                o.Tipo = Item("Tipo")
                If IsDBNull(Item("FechaInicio")) = False Then
                    o.FechaInicio = Item("FechaInicio")
                End If
                If IsDBNull(Item("FechaFin")) = False Then
                    o.FechaFin = Item("FechaFin")
                End If
                o.Cantidad = Item("Cantidad")
                If IsDBNull(Item("Observacion")) = False Then
                    o.Observacion = Item("Observacion")
                End If
                o.Estado = Item("Estado")
                o.Pedido.Usuario.NombreUsuario = Item("NombreUsuario")
                lista.Add(o)
            Next
        End If

        Return lista
    End Function

    Public Function Crear(ByVal entidad As OrdenProduccion) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Tipo", entidad.Tipo)
        parametros.Add("@Estado", entidad.Estado)
        parametros.Add("@Cantidad", entidad.Cantidad)
        parametros.Add("@Producto_Id", entidad.Producto.Id)

        Return vDatos.Escribir("s_AltaOrden", parametros)
    End Function

    Public Function Iniciar(ByVal id As Integer) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", id)

        Return vDatos.Escribir("s_IniciarOrden", parametros)
    End Function

    Public Function Terminar(ByVal id As Integer) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", id)

        Return vDatos.Escribir("s_TerminarOrden", parametros)
    End Function

End Class
