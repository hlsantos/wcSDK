Public Class frmLogin

    ' 500.3 26.10.17 Server field, prefilled from /server:name
    Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        txtServer.Text = BBSServerName
        If txtServer.Text <> "" Then txtName.Select()

    End Sub

    Private Sub cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogin.Click, cmdCancel.Click

        Select Case CType(sender, Button).Name
            Case Me.cmdLogin.Name
                If txtName.Text.Trim = "" Or txtPassword.Text.Trim = "" Then
                    MsgBox("You must enter a username and password to continue", MsgBoxStyle.Information, "Invalid Login")
                Else
                    BBSServerName = txtServer.Text.Trim
                    mvarUserName = txtName.Text.ToUpper.Trim
                    mvarPassword = txtPassword.Text.Trim
                    Me.Close()
                End If
            Case Me.cmdCancel.Name
                Me.Close()
        End Select

    End Sub

End Class