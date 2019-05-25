Option Strict On
Option Explicit On

Friend Class frmSplash

    Inherits System.Windows.Forms.Form

    Private Sub frmSplash_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        CenterForm(Me)

        Me.Show()
        Me.Refresh()

    End Sub

End Class