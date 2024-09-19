Public Class StringUtil

    Public Shared Function GetStringSeperatelyComma(names As String())

        Dim arrLen As Integer = names.Length

        Dim str As String = ""

        For i As Integer = 0 To arrLen - 1

            str &= names(i)

            If i <> arrLen - 1 Then

                str &= ", "

            End If

        Next

        Return str

    End Function

End Class
