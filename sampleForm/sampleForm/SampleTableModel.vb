Imports System.Data.SqlClient
Imports sampleForm

Public Class SampleTableModel : Implements ITableModel

    Private _idx As Integer
    Private _name As String
    Private _score As Integer

    Public Property Idx As Integer
        Get
            Return _idx
        End Get
        Set(value As Integer)
            _idx = value
        End Set
    End Property

    Public Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    Public Property Score As Integer
        Get
            Return _score
        End Get
        Set(value As Integer)
            _score = value
        End Set
    End Property

    Public Sub New(name As String, score As Integer)

        Me.Name = name
        Me.Score = score

    End Sub

    Public Function GetSqlParameter(columnName As String) As SqlParameter Implements ITableModel.GetSqlParameter

        Dim param As SqlParameter = Nothing

        Select Case columnName
            Case "idx"

                param = New SqlParameter()
                param.SqlDbType = SqlDbType.Int
                param.Value = Idx

            Case "name"

                param = New SqlParameter()
                param.SqlDbType = SqlDbType.VarChar
                param.Value = Name

            Case "score"

                param = New SqlParameter()
                param.SqlDbType = SqlDbType.Int
                param.Value = Score

        End Select

        Return param
    End Function
End Class
