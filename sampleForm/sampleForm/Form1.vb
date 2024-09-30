Imports System.Data.SqlClient

Public Class Form1

    Private cPos As Integer
    Private dataSet As DataSet
    Private sqlAdapt As SqlDataAdapter

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'Sub InsertTest()

    '    Dim dbConn As IDBConnector = New MSDBConnector("samplePrj", "59.23.195.70", "sa", "m2i_soft")

    '    Dim columns As String() = {"name", "score"}

    '    Dim model As SampleTableModel = New SampleTableModel("aaa", 100)
    '    Dim model2 As SampleTableModel = New SampleTableModel("bbb", 200)

    '    dbConn.InsertTable("sampleTable", columns, model)
    '    dbConn.InsertTable("sampleTable", columns, model2)

    'End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    '    'DataGridView1.DataSource = Nothing
    '    'DataGridView1.Refresh()

    '    'Dim dbConn As IDBConnector = New MSDBConnector("samplePrj", "59.23.195.70", "sa", "m2i_soft")

    '    ''조회할 컬럼명
    '    'Dim columns As String() = {"name", "score"}

    '    'Dim result As DataTable = dbConn.SelectTable("sampleTable", columns)

    '    'DataGridView1.DataSource = result

    '    DataGridView1.DataSource = Nothing
    '    DataGridView1.Refresh()

    '    Dim dbConn As IDBConnector = New MSDBConnector("samplePrj", "59.23.195.70", "sa", "m2i_soft")

    '    dataSet = dbConn.LoadTable
    '    DataGridView1.DataSource = dataSet.Tables(0)


    'End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        DataGridView1.DataSource = Nothing
        DataGridView1.Refresh()

        Dim dbConn As MSDBConnector = New MSDBConnector("samplePrj", "59.23.195.70", "sa", "m2i_soft")
        dataSet = New DataSet("HR")

        dataSet = dbConn.LoadTable()
        DataGridView1.DataSource = dataSet.Tables(0)

    End Sub

    Private Sub Button2_click(sender As Object, e As EventArgs) Handles Button2.Click

        DataGridView1.DataSource = Nothing
        DataGridView1.Refresh()

        Dim dbConn As MSDBConnector = New MSDBConnector("samplePrj", "59.23.195.70", "sa", "m2i_soft")

        dbConn.AddData(dataSet, sqlAdapt, txtName.Text, txtScore.Text)
        DataGridView1.DataSource = dataSet.Tables(0)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Try
            Dim cRow As DataRow
            cRow = dataSet.Tables("Employee").Rows(cPos)

            'Me.DataGridView1.Rows(cPos).Cells(1).Value = txtName.Text
            'Me.DataGridView1.Rows(cPos).Cells(2).Value = txtScore.Text

            cRow("name") = txtName.Text
            cRow("score") = txtScore.Text

            Dim iResult As Integer = sqlAdapt.Update(dataSet, "Employee")
            MessageBox.Show(iResult.ToString() & "행을 수정했습니다.")

        Catch ex As Exception
            If dataSet.HasChanges Then
                dataSet.RejectChanges()
            End If
        End Try

    End Sub


    Private Sub txtIdx_TextChanged(sender As Object, e As EventArgs) Handles txtIdx.TextChanged

    End Sub

    Private Sub DataGridView1_CurrentCellChanged(sender As Object, e As EventArgs) Handles DataGridView1.CurrentCellChanged

        If Me.DataGridView1.CurrentCell IsNot Nothing Then
            cPos = Me.DataGridView1.CurrentCell.RowIndex
            txtIdx.Text = Me.DataGridView1.Rows(cPos).Cells(0).Value.ToString()
            txtName.Text = Me.DataGridView1.Rows(cPos).Cells(1).Value.ToString()
            txtScore.Text = Me.DataGridView1.Rows(cPos).Cells(2).Value.ToString()
        End If
    End Sub

End Class
