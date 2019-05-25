Option Strict On
Option Explicit On

Imports wcSDK.wcServerAPI

Friend Class frmFile

    Inherits System.Windows.Forms.Form

    Public Function PrepFiles(ByVal lngArea As Integer, ByVal strFileName As String) As Short

        Try
            Dim wFile As New TFileRecord
            Dim wFileA As New TFileArea
            Dim fID As Integer

            If GetFileRecByAreaName(lngArea, strFileName, wFile, fID) Then
                If GetFileArea(lngArea, wFileA) Then
                    If WcExistFile("wc:\file\area(" & wFileA.Number.ToString.Trim & ")\" & wFile.name.Trim) Then lblFStatus.Text = "**File Exists On Disk**"
                    txtFileArea.Text = "(" & wFile.area.ToString.Trim & "). " & wFileA.name.Trim
                    txtFileName.Text = wFile.name.Trim
                    txtFileSize.Text = Format(wFile.Size, "###,###,###,###,###,###,###")
                    txtFileUploader.Text = wFile.Uploader.name.Trim
                    txtFilePassword.Text = wFile.Password.Trim
                    txtFileDate.Text = DateToDateString(wFile.FileTime, True).Trim
                    txtFileLastAccess.Text = DateToDateString(wFile.LastAccessed, True).Trim
                    txtFileDownloads.Text = wFile.Downloads.ToString.Trim
                    txtFileDescription.Text = wFile.Description.Trim
                Else
                    MsgBox("Error pulling the area description", MsgBoxStyle.Information, "WINS Error...")
                    Me.Close()
                End If
            Else
                MsgBox("Error pulling the selected file", MsgBoxStyle.Information, "WINS Error...")
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox("Unexpected Error occurred" & Environment.NewLine & "Error:  " & ex.ToString & Environment.NewLine & "Message:  " & ex.Message, MsgBoxStyle.Critical, "Unexpected Error")
        End Try

    End Function

    Private Sub cmdFiles_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFilesClose.Click

        Me.Dispose()

    End Sub

End Class