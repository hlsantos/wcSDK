Option Strict On
Option Explicit On

Imports wcSDK.wcServerAPI

Friend Class frmMain

    Inherits System.Windows.Forms.Form

#Region "Form Events ..."

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Try
            WildcatServerDeleteContext()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmMain_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        '//First we attempt to login to WINS

        frmSplash.Show()

        If ConnectToWINS(frmSplash.lblStatus) Then
            '//Filling in the information tab
            f_GetWCInformation()
            frmSplash.Close()
        Else
            frmSplash.Close()
            Me.Close()
        End If

    End Sub

#End Region

#Region "Control Events ..."

    Private Sub cmbFArea_SelectedIndexChanged(ByVal sender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbFArea.SelectedIndexChanged

        s_ReloadFiles()

    End Sub

    Private Sub cmbFGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbFGroup.SelectedIndexChanged

        f_LoadWCFileAreas(CType(cmbFGroup.Items(cmbFGroup.SelectedIndex), clsList).ItemData)

    End Sub

    Private Sub cmbMAreas_SelectedIndexChanged(ByVal sender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbMAreas.SelectedIndexChanged

        s_ReloadMessages()

    End Sub

    Private Sub cmbMGroups_SelectedIndexChanged(ByVal sender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbMGroups.SelectedIndexChanged

        f_LoadWCMSGAreas(CType(cmbMGroups.Items(cmbMGroups.SelectedIndex), clsList).ItemData)

    End Sub

    Private Sub lvwFiles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwFiles.SelectedIndexChanged


        If lvwFiles.SelectedItems.Count > 0 Then
            MouseHour()

            Try
                Dim wFullFile As New TFullFileRecord
                Dim wFile As New TFileRecord
                Dim fID As Integer
                Dim myX As Short

                txtFileDesc.ForeColor = System.Drawing.Color.Red
                txtFileDesc.Text = "(No Long Description Available)"

                If GetFileRecByNameArea(lvwFiles.SelectedItems(0).Text, CInt(lvwFiles.SelectedItems(0).SubItems(1).Text), wFile, fID) Then
                    If wFile.HasLongDescription <> 0 Then
                        If GetFullFileRec(wFile, wFullFile) Then
                            txtFileDesc.Text = ""
                            txtFileDesc.ForeColor = System.Drawing.SystemColors.WindowText
                            For myX = 0 To 14
                                If wFullFile.LongDescription(myX).Description.Trim <> "" Then txtFileDesc.Text = txtFileDesc.Text & RTrim(wFullFile.LongDescription(myX).Description) & Environment.NewLine
                            Next
                        End If
                    End If
                End If
            Catch ex As Exception
                MsgBox("Unexpected Error occurred" & Environment.NewLine & "Error:  " & ex.ToString & Environment.NewLine & "Message:  " & ex.Message, MsgBoxStyle.Critical, "Unexpected Error")
            End Try

            MouseNormal()
        End If

    End Sub

    Private Sub lvwMsgs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwMsgs.SelectedIndexChanged

        If lvwMsgs.SelectedItems.Count = 0 Then
        Else
            Dim tmpString As String
            tmpString = Trim(GetText("wc:\conf(" & lvwMsgs.SelectedItems(0).SubItems(5).Text.Trim & ")\message(" & lvwMsgs.SelectedItems(0).SubItems(4).Text.Trim & ")"))
            txtMSGBody.Text = tmpString.Replace(vbLf, Environment.NewLine)
        End If

    End Sub

    Private Sub miniRptcmdFiles_Click(ByVal sender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFileRefresh.Click, cmdFileOpen.Click

        Select Case CType(sender, Button).Name
            Case Me.cmdFileOpen.Name
                '//Open
                s_LoadFileForm()
            Case Me.cmdFileRefresh.Name
                '//Refresh List
                s_ReloadFiles()
        End Select

    End Sub

    Private Sub miniRptcmdUsers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsersRefresh.Click, cmdUsersOpen.Click

        Select Case CType(sender, Button).Name
            Case Me.cmdUsersOpen.Name
                s_LoadUserForm()
            Case Me.cmdUsersRefresh.Name
                f_LoadWCUsers()
        End Select

    End Sub

    Private Sub miniRptLvws_DblClick(ByVal sender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvwMsgs.DoubleClick, lvwFiles.DoubleClick, lvwUsers.DoubleClick

        Select Case CType(sender, ListView).Name
            Case Me.lvwFiles.Name
                s_LoadFileForm()
            Case Me.lvwMsgs.Name
                s_LoadMsgForm()
            Case Me.lvwUsers.Name
                s_LoadUserForm()
        End Select

    End Sub

    Private Sub miniRptcmdMsgs_Click(ByVal sender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMsgDelete.Click, cmdMsgNew.Click, cmdMsgOpen.Click, cmdMsgRefresh.Click

        Dim myNewMSG As New frmMSG
        Dim wMSG As New TMsgHeader

        Select Case CType(sender, Button).Name
            Case Me.cmdMsgOpen.Name
                '//Open MSG
                s_LoadMsgForm()
            Case Me.cmdMsgRefresh.Name
                '//Refresh Display
                s_ReloadMessages()
            Case Me.cmdMsgNew.Name
                myNewMSG.Conference = CType(cmbMAreas.Items(cmbMAreas.SelectedIndex), clsList).ItemData
                myNewMSG.MsgID = -1
                myNewMSG.MessageType = frmMSG.MsgWindowType.ENUM_NEWMESSAGE
                myNewMSG.PrepForMessage()
                myNewMSG.Show()
            Case Me.cmdMsgDelete.Name
                If lvwMsgs.SelectedItems.Count = 0 Then
                Else
                    Dim questAskSure As MsgBoxResult = MsgBox("Are you sure you wish to delete this message?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.Question, MsgBoxStyle), "Confirm Delete...")
                    If questAskSure = MsgBoxResult.Yes Then
                        If GetMessageById(CInt(lvwMsgs.SelectedItems(0).SubItems(5).Text), CInt(lvwMsgs.SelectedItems(0).SubItems(4).Text), wMSG) Then
                            If DeleteMessage(wMSG) Then
                                lvwMsgs.Items.Remove(lvwMsgs.SelectedItems(0))
                            Else
                                MsgBox("Error removing the selected message", MsgBoxStyle.Information, "WINS Error...")
                            End If
                        Else
                            MsgBox("Error finding the selected message", MsgBoxStyle.Information, "WINS Error...")
                        End If
                    End If
                End If
        End Select

    End Sub

    Private Sub tabMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabMain.SelectedIndexChanged

        My.Application.DoEvents()

        Select Case tabMain.SelectedTab.Tag.ToString
            Case "INFO"
                '//Information
                f_GetWCInformation()
            Case "USERS"
                '//Users
                '//Only load them once when its first accessed
                If lvwUsers.Items.Count = 0 Then f_LoadWCUsers()
            Case "MSGS"
                '//Messages
                If lvwMsgs.Items.Count = 0 Then f_LoadWCMSGGroups()
            Case "FILES"
                '//Files
                If lvwFiles.Items.Count = 0 Then f_LoadWCFileGroups()
        End Select

        My.Application.DoEvents()

    End Sub

#End Region

#Region "Private Functions ..."

    Private Function f_GetWCInformation() As Short

        Try
            Dim myMW As New TMakewild
            If GetMakewild(myMW) Then
                txtSystemName.Text = BBSName.Trim
                txtSysop.Text = BBSSysopName.Trim
                txtFirstCall.Text = myMW.FirstCall.Trim
                txtRegNum.Text = myMW.RegString.Trim
                txtServerBuild.Text = GetWildcatBuild.ToString.Trim
                txtTotalConfs.Text = GetConferenceCount.ToString.Trim
                txtActiveConfs.Text = GetEffectiveConferenceCount(0, 0).ToString.Trim
                txtConfGroups.Text = GetConferenceGroupCount.ToString.Trim
                txtTotalFileAreas.Text = GetFileAreaCount.ToString.Trim
                txtActiveFileAreas.Text = GetEffectiveFileAreaCount(0, 0).ToString.Trim
                txtFileGroups.Text = GetFileGroupCount.ToString.Trim
                txtTotalSecurity.Text = GetSecurityProfileCount.ToString.Trim
                txtDoors.Text = GetDoorCount.ToString.Trim
                txtLanguages.Text = GetLanguageCount.ToString.Trim
                txtTotalMsgs.Text = GetTotalMessages.ToString.Trim
                txtTotalUsersOn.Text = GetUsersOnline.ToString.Trim
                txtTotalFiles.Text = GetTotalFiles.ToString.Trim
                txtTotalUsers.Text = GetTotalUsers.ToString.Trim
                txtTotalCalls.Text = GetTotalCalls(0).ToString.Trim
                txtMaxUserCount.Text = GetMaximumUserCount.ToString.Trim
            Else
                MsgBox("Error pulling the MakeWild information", MsgBoxStyle.Information, "WINServer DLL Error")
            End If
        Catch ex As Exception
            MsgBox("Unexpected Error occurred" & Environment.NewLine & "Error:  " & ex.ToString & Environment.NewLine & "Message:  " & ex.Message, MsgBoxStyle.Critical, "Unexpected Error")
        End Try

    End Function

    Private Function f_LoadWCFileAreas(ByRef lngFGroup As Integer) As Short

        My.Application.DoEvents()

        MouseHour()

        Try
            Dim wFileArea As New TFileArea
            Dim AREA As Integer

            cmbFArea.Items.Clear()
            cmbFArea.Items.Add(New clsList("(None)", -1))

            AREA = GetFirstFileArea(lngFGroup, 0)

            Do While AREA > -1
                If GetFileArea(AREA, wFileArea) Then
                    If Trim(wFileArea.name) = "" Then
                    Else
                        cmbFArea.Items.Add(New clsList(wFileArea.name.Trim, wFileArea.Number))
                    End If
                    AREA = GetNextFileArea(lngFGroup, 0, AREA)
                Else
                    AREA = -1
                End If
            Loop

            cmbFArea.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("Unexpected Error occurred" & Environment.NewLine & "Error:  " & ex.ToString & Environment.NewLine & "Message:  " & ex.Message, MsgBoxStyle.Critical, "Unexpected Error")
        End Try

        MouseNormal()

        My.Application.DoEvents()

    End Function

    Private Function f_LoadWCFileGroups() As Short

        My.Application.DoEvents()

        Try
            Dim myX As Integer
            Dim lngGCount As Integer
            Dim myFGroup As New TFileGroup

            lngGCount = GetFileGroupCount

            For myX = 0 To lngGCount - 1
                If GetFileGroup(myX, myFGroup) Then
                    If Trim(myFGroup.name) <> "" Then
                        cmbFGroup.Items.Add(New clsList(myFGroup.name.Trim, myFGroup.Number))
                    End If
                End If
            Next

            If cmbFGroup.Items.Count > 0 Then cmbFGroup.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("Unexpected Error occurred" & Environment.NewLine & "Error:  " & ex.ToString & Environment.NewLine & "Message:  " & ex.Message, MsgBoxStyle.Critical, "Unexpected Error")
        End Try

        My.Application.DoEvents()

    End Function

    Private Function f_LoadWCFilesByArea(ByRef lngArea As Integer) As Short

        My.Application.DoEvents()

        Try
            Dim wFile As New TFileRecord
            Dim Itmx As System.Windows.Forms.ListViewItem
            Dim fID As Integer
            Dim lngFileCount As Integer

            lvwFiles.Items.Clear()

            lngFileCount = GetTotalFilesInArea(lngArea)

            If lngFileCount > 0 Then
                pbFiles.Maximum = lngFileCount
                If SearchFileRecByAreaName(lngArea, "", wFile, fID) Then
                    pbFiles.Value = pbFiles.Value + 1
                    Itmx = lvwFiles.Items.Add(wFile.name.Trim, 2)
                    Itmx.SubItems.Add(wFile.area.ToString.Trim)
                    Itmx.SubItems.Add(DateToDateString(wFile.FileTime, True).Trim)
                    Itmx.SubItems.Add(wFile.Uploader.name.Trim)
                    Itmx.SubItems.Add(wFile.Description.Trim)
                    Do While GetNextFileRec(FileAreaNameKey, wFile, fID)
                        If pbFiles.Value = pbFiles.Maximum Then
                            Exit Do
                        Else
                            pbFiles.Value = pbFiles.Value + 1
                            Itmx = lvwFiles.Items.Add(wFile.name.Trim, 2)
                            Itmx.SubItems.Add(wFile.area.ToString.Trim)
                            Itmx.SubItems.Add(DateToDateString(wFile.FileTime, True).Trim)
                            Itmx.SubItems.Add(wFile.Uploader.name.Trim)
                            Itmx.SubItems.Add(wFile.Description.Trim)
                        End If
                    Loop
                    If lvwFiles.Items.Count > 0 Then lvwFiles.Items(0).Selected = True
                End If
            End If
            pbFiles.Value = 0
        Catch ex As Exception
            MsgBox("Unexpected Error occurred" & Environment.NewLine & "Error:  " & ex.ToString & Environment.NewLine & "Message:  " & ex.Message, MsgBoxStyle.Critical, "Unexpected Error")
        End Try

        My.Application.DoEvents()

    End Function

    Private Function f_LoadWCMSGAreas(ByRef lngMGroup As Integer) As Short

        My.Application.DoEvents()

        MouseHour()

        Try
            Dim msgCONFD As New TConfDesc
            Dim Conf As Integer

            cmbMAreas.Items.Clear()
            cmbMAreas.Items.Add(New clsList("(None)", -1))

            Conf = GetFirstConference(lngMGroup, 0)

            Do While Conf > -1
                If GetConfDesc(Conf, msgCONFD) Then
                    If Trim(msgCONFD.name) = "" Then
                    Else
                        cmbMAreas.Items.Add(New clsList(msgCONFD.name.Trim, msgCONFD.Number))
                    End If
                    Conf = GetNextConference(lngMGroup, 0, Conf)
                Else
                    Conf = -1
                End If
            Loop
            cmbMAreas.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("Unexpected Error occurred" & Environment.NewLine & "Error:  " & ex.ToString & Environment.NewLine & "Message:  " & ex.Message, MsgBoxStyle.Critical, "Unexpected Error")
        End Try

        MouseNormal()

        My.Application.DoEvents()

    End Function

    Private Function f_LoadWCMSGGroups() As Short

        My.Application.DoEvents()

        Try
            Dim myX As Integer
            Dim lngGCount As Integer
            Dim myCGroup As New TConferenceGroup

            lngGCount = GetConferenceGroupCount

            For myX = 0 To lngGCount - 1
                If GetConferenceGroup(myX, myCGroup) Then
                    If Trim(myCGroup.name) <> "" Then
                        cmbMGroups.Items.Add(New clsList(myCGroup.name.Trim, myCGroup.Number))
                    End If
                End If
            Next

            If cmbMGroups.Items.Count > 0 Then cmbMGroups.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("Unexpected Error occurred" & Environment.NewLine & "Error:  " & ex.ToString & Environment.NewLine & "Message:  " & ex.Message, MsgBoxStyle.Critical, "Unexpected Error")
        End Try

        My.Application.DoEvents()

    End Function

    Private Function f_LoadWCMSGSByArea(ByRef lngArea As Integer) As Short

        My.Application.DoEvents()

        Try
            Dim wMSG As New TMsgHeader
            Dim Itmx As System.Windows.Forms.ListViewItem
            Dim lngMSGID As Integer
            Dim lngMSGCount As Integer

            lvwMsgs.Items.Clear()

            lngMSGCount = GetTotalMessagesInConference(lngArea)

            lngMSGID = 0

            If lngMSGCount > 0 Then
                pbMsgs.Maximum = lngMSGCount
                Do While SearchMessageById(lngArea, lngMSGID, wMSG)
                    If pbMsgs.Value + 1 > pbMsgs.Maximum Then pbMsgs.Maximum = pbMsgs.Value + 1
                    pbMsgs.Value = pbMsgs.Value + 1
                    Itmx = lvwMsgs.Items.Add(wMSG.MsgTo.name.Trim, 1)
                    Itmx.SubItems.Add(wMSG.MsgFrom.Name.Trim)
                    Itmx.SubItems.Add(wMSG.Subject.Trim)
                    Itmx.SubItems.Add(DateToDateString(wMSG.MsgTime, True).Trim)
                    Itmx.SubItems.Add(wMSG.id.ToString.Trim)
                    Itmx.SubItems.Add(wMSG.Conference.ToString.Trim)
                    lngMSGID = wMSG.id + 1
                Loop
            End If
            pbMsgs.Value = 0
        Catch ex As Exception
            MsgBox("Unexpected Error occurred" & Environment.NewLine & "Error:  " & ex.ToString & Environment.NewLine & "Message:  " & ex.Message, MsgBoxStyle.Critical, "Unexpected Error")
        End Try

        My.Application.DoEvents()

    End Function

    Private Function f_LoadWCUsers() As Short

        My.Application.DoEvents()

        Try
            Dim lngTotal As Integer
            Dim wUser As New TUser
            Dim myX As Integer
            Dim Itmx As System.Windows.Forms.ListViewItem
            Dim tID As Integer

            lngTotal = GetTotalUsers
            '//For demo purposes we are just loading
            '//100 Users in the list
            If lngTotal > 100 Then lngTotal = 100

            lvwUsers.Items.Clear()

            If lngTotal > 0 Then
                pbUsers.Maximum = lngTotal
                If GetFirstUser(UserLastNameKey, wUser, tID) Then
                    pbUsers.Value = pbUsers.Value + 1
                    Itmx = lvwUsers.Items.Add("A-" & wUser.Info.id.ToString.Trim, wUser.Info.name.Trim, 0)
                    Itmx.SubItems.Add(wUser.Info.id.ToString.Trim)
                    Itmx.SubItems.Add(wUser.RealName.Trim)
                    Itmx.SubItems.Add(wUser.Security(0).SecurityProfile.Trim)
                    Itmx.SubItems.Add(DateToDateString(wUser.FirstCall, True).Trim)
                    Itmx.SubItems.Add(DateToDateString(wUser.LastCall, True).Trim)
                    For myX = 2 To lngTotal
                        pbUsers.Value = pbUsers.Value + 1
                        If GetNextUser(UserLastNameKey, wUser, tID) Then
                            Itmx = lvwUsers.Items.Add("A-" & wUser.Info.id.ToString.Trim, wUser.Info.name.Trim, 0)
                            Itmx.SubItems.Add(wUser.Info.id.ToString.Trim)
                            Itmx.SubItems.Add(wUser.RealName.Trim)
                            Itmx.SubItems.Add(wUser.Security(0).SecurityProfile.Trim)
                            Itmx.SubItems.Add(DateToDateString(wUser.FirstCall, True).Trim)
                            Itmx.SubItems.Add(DateToDateString(wUser.LastCall, True).Trim)
                        End If
                    Next
                Else
                    MsgBox("Error accessing the user database", MsgBoxStyle.Critical, "User DB Error")
                End If
            End If
            pbUsers.Value = 0
        Catch ex As Exception
            MsgBox("Unexpected Error occurred" & Environment.NewLine & "Error:  " & ex.ToString & Environment.NewLine & "Message:  " & ex.Message, MsgBoxStyle.Critical, "Unexpected Error")
        End Try

        My.Application.DoEvents()

    End Function

#End Region

#Region "Private SubRoutines ..."

    Private Sub s_LoadFileForm()

        Try
            Dim myNewFile As New frmFile
            If lvwFiles.SelectedItems.Count = 0 Then
            Else
                myNewFile.PrepFiles(CType(cmbFArea.Items(cmbFArea.SelectedIndex), clsList).ItemData, lvwFiles.SelectedItems(0).Text)
                myNewFile.Show()
            End If
        Catch ex As Exception
            MsgBox("Unexpected Error occurred" & Environment.NewLine & "Error:  " & ex.ToString & Environment.NewLine & "Message:  " & ex.Message, MsgBoxStyle.Critical, "Unexpected Error")
        End Try

    End Sub

    Private Sub s_LoadMsgForm()

        Try
            Dim myNewMSG As New frmMSG
            If lvwMsgs.SelectedItems.Count = 0 Then
            Else
                myNewMSG.Conference = CInt(lvwMsgs.SelectedItems(0).SubItems(5).Text.Trim)
                myNewMSG.MsgID = CInt(lvwMsgs.SelectedItems(0).SubItems(4).Text.Trim)
                myNewMSG.MessageType = frmMSG.MsgWindowType.ENUM_VIEWONLY
                myNewMSG.PrepForMessage()
                myNewMSG.Show()
            End If
        Catch ex As Exception
            MsgBox("Unexpected Error occurred" & Environment.NewLine & "Error:  " & ex.ToString & Environment.NewLine & "Message:  " & ex.Message, MsgBoxStyle.Critical, "Unexpected Error")
        End Try

    End Sub

    Private Sub s_LoadUserForm()

        Try
            Dim myNewUser As New frmUser
            If lvwUsers.SelectedItems.Count = 0 Then
                '//Checking to make sure there is a selected item
            Else
                myNewUser.UserID = CInt(lvwUsers.SelectedItems(0).SubItems(1).Text)
                myNewUser.LoadUser()
                myNewUser.Show()
            End If
        Catch ex As Exception
            MsgBox("Unexpected Error occurred" & Environment.NewLine & "Error:  " & ex.ToString & Environment.NewLine & "Message:  " & ex.Message, MsgBoxStyle.Critical, "Unexpected Error")
        End Try

    End Sub

    Private Sub s_ReloadFiles()

        My.Application.DoEvents()

        Try
            txtFileDesc.Text = ""
            If CType(cmbFArea.Items(cmbFArea.SelectedIndex), clsList).ItemData = -1 Then
                lvwFiles.Items.Clear()
            Else
                f_LoadWCFilesByArea(CType(cmbFArea.Items(cmbFArea.SelectedIndex), clsList).ItemData)
            End If
        Catch ex As Exception
            MsgBox("Unexpected Error occurred" & Environment.NewLine & "Error:  " & ex.ToString & Environment.NewLine & "Message:  " & ex.Message, MsgBoxStyle.Critical, "Unexpected Error")
        End Try

        My.Application.DoEvents()

    End Sub

    Private Sub s_ReloadMessages()

        My.Application.DoEvents()

        Try
            txtMSGBody.Text = ""

            If CType(cmbMAreas.Items(cmbMAreas.SelectedIndex), clsList).ItemData = -1 Then
                lvwMsgs.Items.Clear()
            Else
                f_LoadWCMSGSByArea(CType(cmbMAreas.Items(cmbMAreas.SelectedIndex), clsList).ItemData)
            End If
        Catch ex As Exception
            MsgBox("Unexpected Error occurred" & Environment.NewLine & "Error:  " & ex.ToString & Environment.NewLine & "Message:  " & ex.Message, MsgBoxStyle.Critical, "Unexpected Error")
        End Try

        My.Application.DoEvents()

    End Sub

#End Region

End Class