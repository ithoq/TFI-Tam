Imports System.Data.SqlClient
Imports System.Configuration
Public Class Datos

    'Private Str As String = "Data Source=.\SQL_UAI;Initial Catalog=TFI;Integrated Security=True"
    'Private Str2 As String = "Data Source=.\SQL_UAI;Initial Catalog=Master;Integrated Security=True"
    Private Str As String = "Data Source=.;Initial Catalog=TFI;Integrated Security=True"
    Private Str2 As String = "Data Source=.;Initial Catalog=Master;Integrated Security=True"

    Private Cnn As New SqlConnection(Str)
    Private CnnMaster As New SqlConnection(Str2)
    Private Tranx As SqlTransaction
    Private Cmd As SqlCommand


    Public Function Leer(ByVal consulta As String, ByVal hdatos As Hashtable) As DataSet

        Dim Ds As New DataSet
        Cmd = New SqlCommand

        Cmd.Connection = Cnn
        Cmd.CommandText = consulta
        Cmd.CommandType = CommandType.StoredProcedure

        If Not hdatos Is Nothing Then

            'si la hashtable no esta vacia, y tiene el dato q busco 
            For Each dato As String In hdatos.Keys
                'cargo los parametros que le estoy pasando con la Hash
                Cmd.Parameters.AddWithValue(dato, hdatos(dato))
            Next
        End If

        Dim Adaptador As New SqlDataAdapter(Cmd)
        Adaptador.Fill(Ds)
        Return Ds


    End Function

    Public Function Escribir(ByVal consulta As String, ByVal hdatos As Hashtable) As Boolean

        If Cnn.State = ConnectionState.Closed Then
            Cnn.ConnectionString = Str
            Cnn.Open()
        End If

        Try
            Tranx = Cnn.BeginTransaction
            Cmd = New SqlCommand
            Cmd.Connection = Cnn
            Cmd.CommandText = consulta
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Transaction = Tranx

            If Not hdatos Is Nothing Then

                For Each dato As String In hdatos.Keys
                    'cargo los parametros que le estoy pasando con la Hash
                    Cmd.Parameters.AddWithValue(dato, hdatos(dato))
                Next
            End If

            Dim respuesta As Integer = Cmd.ExecuteNonQuery
            Tranx.Commit()
            Return True

        Catch ex As Exception
            Tranx.Rollback()
            Return False
        Finally
            Cnn.Close()
        End Try

    End Function

    Public Function BackupBase(ByVal rutaNombre As String) As Boolean
        Try
            If CnnMaster.State = ConnectionState.Closed Then
                CnnMaster.ConnectionString = Str2
                CnnMaster.Open()
            End If

            Dim consulta As String = "BACKUP DATABASE TFI " &
                                     "TO DISK = '" & rutaNombre & "'"

            Cmd = New SqlCommand
            Cmd.Connection = CnnMaster
            Cmd.CommandText = consulta
            Cmd.CommandType = CommandType.Text

            Dim respuesta As Integer = Cmd.ExecuteNonQuery

            Return True
        Catch ex As Exception
            Return False
        Finally
            CnnMaster.Close()
        End Try
    End Function

    Public Function RestaurarBase(ByVal rutaNombre As String) As Boolean
        Try
            If CnnMaster.State = ConnectionState.Closed Then
                CnnMaster.ConnectionString = Str2
                CnnMaster.Open()
            End If

            Dim consulta As String = "Alter Database TFI SET SINGLE_USER With ROLLBACK IMMEDIATE" & vbCrLf &
                                     "RESTORE DATABASE TFI " &
                                     "FROM DISK = '" & rutaNombre & "'" & " WITH REPLACE"

            Cmd = New SqlCommand
            Cmd.Connection = CnnMaster
            Cmd.CommandText = consulta
            Cmd.CommandType = CommandType.Text

            Dim respuesta As Integer = Cmd.ExecuteNonQuery

            Return True
        Catch ex As Exception
            Return False
        Finally
            CnnMaster.Close()
        End Try
    End Function

End Class
