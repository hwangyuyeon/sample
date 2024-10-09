Imports System.Data.SqlClient

Public Class FrmEdit

    Private cPos As Integer = FrmMain.cPos
    Private ds As DataSet = FrmMain.dataSet

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtName.Text = FrmMain.DataGridView1.Rows(cPos).Cells(1).Value.ToString()
        txtScore.Text = FrmMain.DataGridView1.Rows(cPos).Cells(2).Value.ToString()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        ' ds As New DataSet("HR")
        Dim dbConn As MSDBConnector = New MSDBConnector("samplePrj", "59.23.195.70", "sa", "m2i_soft")

        Try
            Using conn As SqlConnection = New SqlConnection(dbConn.GetDBConnectCommand())

                Dim cRow As DataRow

                conn.Open()

                Dim sqlAdapt = New SqlDataAdapter()

                sqlAdapt.SelectCommand = New SqlCommand("select * from dbo.sampleTable", conn)

                Dim cb As New SqlCommandBuilder(sqlAdapt)

                cRow = ds.Tables("Employee").Rows(cPos)
                cRow("name") = txtName.Text
                cRow("score") = txtScore.Text

                Dim iResult As Integer = sqlAdapt.Update(ds, "Employee")
                MessageBox.Show("수정되었습니다.")
                Me.Close()

            End Using

        Catch ex As Exception
            If ds.HasChanges Then
                ds.RejectChanges()
            End If
        End Try

    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged

    End Sub

End Class