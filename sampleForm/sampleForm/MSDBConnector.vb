Imports System.Data.SqlClient
Imports sampleForm

'MSSQL DB에 접속하고 쿼리를 실행합니다
Public Class MSDBConnector : Implements IDBConnector

    Private dbName As String
    Private ip As String
    Private id As String
    Private pw As String

    Public Sub New(dbName As String, ip As String, id As String, pw As String)

        Me.dbName = dbName
        Me.ip = ip
        Me.id = id
        Me.pw = pw

    End Sub

    Public Function SelectTable(tableName As String, columnNames As String()) As DataTable Implements IDBConnector.SelectTable

        Dim dataTable As DataTable = New DataTable()

        Dim query As String = "select "

        Try
            Using conn As SqlConnection = New SqlConnection(GetDBConnectCommand())

                conn.Open()

                Using command As SqlCommand = conn.CreateCommand()

                    query &= StringUtil.GetStringSeperatelyComma(columnNames)
                    query &= " from "
                    query &= tableName

                    command.CommandText = query

                    Dim sqlReader As SqlDataReader = command.ExecuteReader()

                    dataTable.Load(sqlReader)

                End Using

            End Using

        Catch ex As Exception

            Throw ex

        End Try

        Return dataTable

    End Function

    Function GetDBConnectCommand() As String

        Dim str As String = $"Data Source ={ip};"

        str &= $"Initial Catalog={dbName};"
        str &= $"User ID={id};"
        str &= $"Password={pw};"

        Return str

    End Function

    Public Sub InsertTable(tableName As String, insColumnNames() As String, model As ITableModel) Implements IDBConnector.InsertTable
        Dim dataTable As DataTable = New DataTable()

        Dim query As String = $"insert into {tableName} "

        Try
            Using conn As SqlConnection = New SqlConnection(GetDBConnectCommand())

                conn.Open()

                Using command As SqlCommand = conn.CreateCommand()

                    query &= "(" + StringUtil.GetStringSeperatelyComma(insColumnNames) + ")"
                    query &= " values "

                    query &= "("

                    Dim i As Integer = 0
                    Dim matchParamStr As String = ""

                    For Each col As String In insColumnNames

                        If i <> 0 Then
                            query &= ", "
                        End If

                        Dim param As SqlParameter = model.GetSqlParameter(col)

                        matchParamStr = "@param" + i.ToString()

                        query &= matchParamStr

                        command.Parameters.Add(param).ParameterName = matchParamStr

                        i += 1
                    Next

                    query &= ")"

                    command.CommandType = CommandType.Text
                    command.CommandText = query
                    command.ExecuteNonQuery()

                End Using

            End Using

        Catch ex As Exception

            Throw ex

        End Try

    End Sub
End Class
