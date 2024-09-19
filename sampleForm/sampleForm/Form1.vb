Imports System.Data.SqlClient

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim dbConn As IDBConnector = New MSDBConnector("samplePrj", "59.23.195.70", "sa", "m2i_soft")

        Dim columns As String() = {"name", "score"}

        Dim model As SampleTableModel = New SampleTableModel("aaa", 100)
        Dim model2 As SampleTableModel = New SampleTableModel("bbb", 200)

        dbConn.InsertTable("sampleTable", columns, model)
        dbConn.InsertTable("sampleTable", columns, model2)

        'Dim result As DataTable = dbConn.SelectTable("sampleTable", columns)

    End Sub

    Sub InsertTest()

        Dim dbConn As IDBConnector = New MSDBConnector("samplePrj", "59.23.195.70", "sa", "m2i_soft")

        Dim columns As String() = {"name", "score"}

        Dim model As SampleTableModel = New SampleTableModel("aaa", 100)
        Dim model2 As SampleTableModel = New SampleTableModel("bbb", 200)

        dbConn.InsertTable("sampleTable", columns, model)
        dbConn.InsertTable("sampleTable", columns, model2)

    End Sub


End Class
