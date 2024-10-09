Public Class FrmAdd

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        If txtName.Text <> "" Then

            If IsNumeric(txtScore.Text) Then
                If MsgBox("등록 하시겠습니까?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    Dim dbConn As MSDBConnector = New MSDBConnector("samplePrj", "59.23.195.70", "sa", "m2i_soft")
                    dbConn.AddData(txtName.Text, txtScore.Text)

                    Me.Close()

                End If

            Else
                MessageBox.Show("점수는 숫자만 입력 가능합니다.")
            End If



        Else

            MessageBox.Show("이름을 입력해주세요.")

        End If



    End Sub

End Class