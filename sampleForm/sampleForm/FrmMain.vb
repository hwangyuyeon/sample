Imports System.Data.SqlClient

Public Class FrmMain

    Private cPos As Integer
    Private dataSet As DataSet

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboSearch(cboName)
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

        'dataSet = New DataSet("HR")

        Dim dbConn As MSDBConnector = New MSDBConnector("samplePrj", "59.23.195.70", "sa", "m2i_soft")


        dataSet = dbConn.LoadTable(dtpFrom, dtpTo, cboName)
        Try
            DataGridView1.DataSource = dataSet.Tables(0)
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Button2_click(sender As Object, e As EventArgs) Handles Button2.Click

        If MsgBox("등록 하시겠습니까?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            DataGridView1.DataSource = Nothing
            DataGridView1.Refresh()

            Dim dbConn As MSDBConnector = New MSDBConnector("samplePrj", "59.23.195.70", "sa", "m2i_soft")
            dataSet = dbConn.AddData(txtName.Text, txtScore.Text)
            DataGridView1.Refresh()
            DataGridView1.DataSource = dataSet.Tables(0)

        End If

    End Sub

    'Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    '    Try
    '        Dim cRow As DataRow
    '        cRow = dataSet.Tables("Employee").Rows(cPos)

    '        'Me.DataGridView1.Rows(cPos).Cells(1).Value = txtName.Text
    '        'Me.DataGridView1.Rows(cPos).Cells(2).Value = txtScore.Text

    '        cRow("name") = txtName.Text
    '        cRow("score") = txtScore.Text

    '        Dim iResult As Integer = sqlAdapt.Update(dataSet, "Employee")
    '        MessageBox.Show(iResult.ToString() & "행을 수정했습니다.")

    '    Catch ex As Exception
    '        If dataSet.HasChanges Then
    '            dataSet.RejectChanges()
    '        End If
    '    End Try

    'End Sub


    Private Sub txtIdx_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataGridView1_CurrentCellChanged(sender As Object, e As EventArgs) Handles DataGridView1.CurrentCellChanged

        If Me.DataGridView1.CurrentCell IsNot Nothing Then
            cPos = Me.DataGridView1.CurrentCell.RowIndex
            txtName.Text = Me.DataGridView1.Rows(cPos).Cells(1).Value.ToString()
            txtScore.Text = Me.DataGridView1.Rows(cPos).Cells(2).Value.ToString()
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim ds As New DataSet("HR")
        Dim dbConn As MSDBConnector = New MSDBConnector("samplePrj", "59.23.195.70", "sa", "m2i_soft")

        If MsgBox("정말로 삭제 하시겠습니까?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Try
                Using conn As SqlConnection = New SqlConnection(dbConn.GetDBConnectCommand())

                    conn.Open()

                    Dim sqlAdapt = New SqlDataAdapter()

                    sqlAdapt.SelectCommand = New SqlCommand("select * from dbo.sampleTable", conn)

                    Dim cb As New SqlCommandBuilder(sqlAdapt)

                    sqlAdapt.Fill(ds, "Employee")

                    ds.Tables(0).Rows(cPos).Delete()

                    Dim iResult As Integer = sqlAdapt.Update(ds, "Employee")
                    MessageBox.Show("삭제 되었습니다.")

                    DataGridView1.Refresh()
                    DataGridView1.DataSource = ds.Tables(0)

                End Using

            Catch ex As Exception
                If ds.HasChanges Then
                    ds.RejectChanges()
                End If
            End Try

        End If



    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim ds As New DataSet("HR")
        Dim dbConn As MSDBConnector = New MSDBConnector("samplePrj", "59.23.195.70", "sa", "m2i_soft")

        If MsgBox("수정 하시겠습니까?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Try
                Using conn As SqlConnection = New SqlConnection(dbConn.GetDBConnectCommand())

                    Dim cRow As DataRow

                    conn.Open()

                    Dim sqlAdapt = New SqlDataAdapter()

                    sqlAdapt.SelectCommand = New SqlCommand("select * from dbo.sampleTable", conn)

                    Dim cb As New SqlCommandBuilder(sqlAdapt)

                    cRow = dataSet.Tables("Employee").Rows(cPos)
                    cRow("name") = txtName.Text
                    cRow("score") = txtScore.Text

                    Dim iResult As Integer = sqlAdapt.Update(dataSet, "Employee")
                    MessageBox.Show("수정되었습니다.")

                End Using

            Catch ex As Exception
                If ds.HasChanges Then
                    ds.RejectChanges()
                End If
            End Try

        End If

    End Sub

    Public Sub ComboSearch(ByVal c As ComboBox)

        Dim dbConn As MSDBConnector = New MSDBConnector("samplePrj", "59.23.195.70", "sa", "m2i_soft")
        Dim strQry As String = "Select name From dbo.sampleTable"
        Try
            Using conn As SqlConnection = New SqlConnection(dbConn.GetDBConnectCommand())

                conn.Open()

                Dim cmd As New SqlCommand(strQry, conn)
                cmd.CommandType = CommandType.Text
                Dim rs As SqlDataReader = cmd.ExecuteReader
                c.Items.Clear()

                c.Items.Add("전체")
                While (rs.Read())
                    c.Items.Add(rs(0))
                End While
                rs.Close()

            End Using

        Catch ex As Exception

            Throw ex

        End Try

    End Sub

    Private Sub cboName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboName.SelectedIndexChanged

    End Sub
End Class
