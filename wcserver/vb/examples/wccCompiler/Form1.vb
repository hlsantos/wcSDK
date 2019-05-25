Public Class form1

    Private Sub btnPickWcc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPickWcc.Click
        OpenFileDialog1.Title = "Select WCC source File"
        ''OpenFileDialog1.RestoreDirectory();

        If OpenFileDialog1.ShowDialog() Then
        End If
    End Sub

    Private Sub form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
