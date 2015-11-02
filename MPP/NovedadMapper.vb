﻿Imports DAL
Imports EE
Public Class NovedadMapper

    Private vDatos As Datos

    Sub New()
        Me.vDatos = New Datos
    End Sub

    Public Function Crear(ByVal n As Novedad) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@FechaCreacion", n.FechaCreacion)
        parametros.Add("@Titulo", n.Titulo)
        parametros.Add("@Contenido", n.Contenido)
        parametros.Add("@Tipo", n.Tipo)
        parametros.Add("@Categoria_Id", n.Categoria.Id)

        Return vDatos.Escribir("s_AltaNovedad", parametros)
    End Function

    Public Function Editar(ByVal n As Novedad) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", n.Id)
        parametros.Add("@Titulo", n.Titulo)
        parametros.Add("@Contenido", n.Contenido)
        parametros.Add("@Tipo", n.Tipo)
        parametros.Add("@Categoria_Id", n.Categoria.Id)

        Return vDatos.Escribir("s_ModificacionNovedad", parametros)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", id)

        Return vDatos.Escribir("s_BajaNovedad", parametros)
    End Function

    Public Function Listar() As List(Of Novedad)
        Dim ds As New DataSet
        Dim lista As New List(Of Novedad)
        ds = vDatos.Leer("s_ListarNovedad", Nothing)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                Dim n As Novedad = New Novedad
                n.Id = Item("Id")
                n.FechaCreacion = Item("FechaCreacion")
                n.Titulo = Item("Titulo")
                n.Contenido = Item("Contenido")
                n.Tipo = Item("Tipo")
                n.Categoria.Id = Item("CategoriaId")
                n.Categoria.Nombre = Item("CategoriaNombre")
                lista.Add(n)
            Next
        End If

        Return lista
    End Function

    Public Function ListarNovedades() As List(Of Novedad)
        Dim ds As New DataSet
        Dim lista As New List(Of Novedad)
        ds = vDatos.Leer("s_ListarNovedad", Nothing)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                If Item("Tipo") = "Novedad" Then
                    Dim n As Novedad = New Novedad
                    n.Id = Item("Id")
                    n.FechaCreacion = Item("FechaCreacion")
                    n.Titulo = Item("Titulo")
                    n.Contenido = Item("Contenido")
                    n.Tipo = Item("Tipo")
                    n.Categoria.Id = Item("CategoriaId")
                    n.Categoria.Nombre = Item("CategoriaNombre")
                    lista.Add(n)
                End If
            Next
        End If

        Return lista
    End Function

    Public Function ConsultarPorId(ByVal id As Integer) As Novedad
        Dim parametros As New Hashtable
        Dim ds As New DataSet

        parametros.Add("@Id", id)
        ds = vDatos.Leer("s_ConsultarPorIdNovedad", parametros)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim row As DataRow = ds.Tables(0).Rows(0)
            Dim n As New Novedad
            n.Id = row.Item("Id")
            n.FechaCreacion = row.Item("FechaCreacion")
            n.Titulo = row.Item("Titulo")
            n.Contenido = row.Item("Contenido")
            n.Tipo = row.Item("Tipo")
            n.Categoria.Id = row.Item("Categoria_Id")
            n.Categoria.Nombre = row.Item("Categoria_Nombre")
            Return n
        Else
            Return Nothing
        End If
    End Function

    Public Function Suscribirse(ByVal s As Suscriptor) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Email", s.Email)
        Dim dt As New DataTable()
        dt.Columns.Add("Entidad_Id")
        For Each c As Categoria In s.ListaCategorias
            dt.Rows.Add(c.Id)
        Next
        parametros.Add("@Lista", dt)

        Return vDatos.Escribir("s_SuscribirCategoria", parametros)
    End Function

    Public Function ConsultarEmailsPorCategoria(ByVal categoriaId As Integer) As List(Of String)
        Dim ds As New DataSet
        Dim lista As New List(Of String)
        Dim parametros As New Hashtable

        parametros.Add("@CategoriaId", categoriaId)
        ds = vDatos.Leer("s_ConsultarEmailsPorCategoriaNovedad", parametros)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                lista.Add(Item("Email"))
            Next
        End If

        Return lista
    End Function

End Class
