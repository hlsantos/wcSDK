Option Strict On
Option Explicit On

Imports wcSDK.wcServerAPI

Friend Class frmUser

    Inherits System.Windows.Forms.Form

    Private mvarUID As Integer

    Public Property UserID() As Integer
        Get
            UserID = mvarUID
        End Get
        Set(ByVal value As Integer)
            mvarUID = value
        End Set
    End Property

    Public Function LoadUser() As Short

        Try
            Dim wUser As New TUser
            Dim uID As Integer

            If GetUserById(mvarUID, wUser, uID) Then
                txtUserName.Text = wUser.Info.name.Trim
                txtUserID.Text = wUser.Info.id.ToString.Trim
                txtUserRealName.Text = wUser.RealName.Trim
                txtUserFrom.Text = wUser.From.Trim
                txtUserAddress1.Text = wUser.Address1.Trim
                txtUserAddress2.Text = wUser.Address2.Trim
                txtUserCity.Text = wUser.City.Trim
                txtUserState.Text = wUser.State.Trim
                txtUserZip.Text = wUser.Zip.Trim
                txtUserCountry.Text = wUser.Country.Trim
                txtUserPhone.Text = wUser.PhoneNumber.Trim
                txtUserDataPhone.Text = GetUserVariable(wUser.Info.id, "Profile", "DataNumber", "")
            Else
                MsgBox("Error accessing the selected user", MsgBoxStyle.Information, "WINS Error...")
                Me.Dispose()
            End If
        Catch ex As Exception
            MsgBox("Unexpected Error occurred" & Environment.NewLine & "Error:  " & ex.ToString & Environment.NewLine & "Message:  " & ex.Message, MsgBoxStyle.Critical, "Unexpected Error")
            Me.Dispose()
        End Try

    End Function

    Private Sub cmdUsers_Click(ByVal sender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUserCancel.Click, cmdUserUpdate.Click

        Dim uID As Integer
        Dim wUser As New TUser

        Select Case CType(sender, Button).Name
            Case Me.cmdUserUpdate.Name
                '//Update user information
                If txtUserName.Text.Trim = "" Then
                    '//Make sure AT LEAST the name is filled in
                    MsgBox("You must have a Name filled in", MsgBoxStyle.Information, "Entry Error...")
                Else
                    '//Searching for the user to fill out the complete
                    '//User information variable... Then update what we
                    '//need to change
                    If GetUserById(CInt(txtUserID.Text), wUser, uID) Then
                        wUser.Info.Name = txtUserName.Text.Trim
                        wUser.RealName = txtUserRealName.Text.Trim
                        wUser.From = txtUserFrom.Text.Trim
                        wUser.Address1 = txtUserAddress1.Text.Trim
                        wUser.Address2 = txtUserAddress2.Text.Trim
                        wUser.City = txtUserCity.Text.Trim
                        wUser.State = txtUserState.Text.Trim
                        wUser.Zip = txtUserZip.Text.Trim
                        wUser.Country = txtUserCountry.Text.Trim
                        wUser.PhoneNumber = txtUserPhone.Text.Trim
                        SetUserVariable(CInt(txtUserID.Text.Trim), "Profile", "DataNumber", txtUserDataPhone.Text.Trim)
                        If UpdateUser(wUser) Then
                        Else
                            MsgBox("Error updating the specified user", MsgBoxStyle.Information, "WINS Error...")
                        End If
                    Else
                        MsgBox("Error accessing the specified user record", MsgBoxStyle.Information, "WINS Error...")
                    End If
                End If
            Case Me.cmdUserCancel.Name
                '//Unload form
                Me.Dispose()
        End Select

    End Sub

End Class