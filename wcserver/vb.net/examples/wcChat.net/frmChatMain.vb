Imports System.Runtime.InteropServices, wcSDK.wcServerAPI

Public Class frmChatMain

#Region "Private Variables ..."

    Private PageEventHandle As Integer
    Private ChatEventHandle As Integer
    Private ChatHandle As Integer
    Private CurrentChannel As Integer = 0
    Private objNodeID As Integer = 0
    Private objUsers As New colChatUser
    Private boolLoaded As Boolean

    Const CHATCTRL_ENTER = 1
    Const CHATCTRL_ENTERACK = 2
    Const CHATCTRL_LEAVE = 3
    Const CHATCTRL_SWITCH = 4
    Const CHATCTRL_TOPIC = 5

    Const CHATMSG_TEXT = 1
    Const CHATMSG_ACTION = 2

    Private Enum ControlMessage
        EN_CHATCTRL_ENTER = 1
        EN_CHATCTRL_ENTERACK = 2
        EN_CHATCTRL_LEAVE = 3
        EN_CHATCTRL_SWITCH = 4
        EN_CHATCTRL_TOPIC = 5
    End Enum

    Private Enum ChatMessage
        EN_CHATMSG_TEXT = 1
        EN_CHATMSG_ACTION = 2
    End Enum

#End Region

#Region "Form Events ..."

    Private Sub frmChatMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If boolLoaded Then
            sendControlMessage(ControlMessage.EN_CHATCTRL_LEAVE, objUser.Info.Name.Trim.ToUpper & " has left the chat room")
            RemoveWildcatCallback()
            CloseChannel(PageEventHandle)
            CloseChannel(ChatEventHandle)
            CloseChannel(ChatHandle)
            LogoutUser()
            WildcatServerDeleteContext()

            If Me.WindowState <> FormWindowState.Normal Then
                My.Settings.WindowState = CInt(Me.WindowState)
            Else
                My.Settings.Left = Me.Left
                My.Settings.Top = Me.Top
                My.Settings.Width = Me.Width
                My.Settings.Height = Me.Height
                My.Settings.WindowState = Me.WindowState
            End If

            My.Settings.ListPanelWidth = scMain.Panel1.Width
            My.Settings.ChatLogHeight = scChat.Panel1.Height

        End If

    End Sub

    Private Sub frmChatMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim objLogin As New frmLogin


        frmLogin.ShowDialog()

        If mvarUserName.Trim <> "" Then
            If ConnectToWINSUser(mvarUserName, mvarPassword) Then
                If SetupWildcatCallback(objCBFunc, 0) Then
                    rtbChatLog.Rtf = My.Resources.RTFString
                    If My.Settings.Width = 0 Then
                    Else
                        Me.Left = My.Settings.Left
                        Me.Top = My.Settings.Top
                        Me.Width = My.Settings.Width
                        Me.Height = My.Settings.Height
                        Me.WindowState = My.Settings.WindowState
                        scMain.SplitterDistance = My.Settings.ListPanelWidth
                        scChat.SplitterDistance = My.Settings.ChatLogHeight
                    End If
                    PageEventHandle = OpenChannel("System.Page")
                    ChatEventHandle = OpenChannel("Chat.Control")
                    ChatHandle = OpenChannel("Chat.0")
                    boolLoaded = True
                    Dim itmX As ListViewItem
                    Dim tmpUser As New clsChatUser
                    tmpUser.Channel = CurrentChannel
                    tmpUser.ID = objNI.Connectionid
                    tmpUser.Name = objUser.Info.Name.Trim.ToUpper
                    tmpUser.Topic = objUser.Info.Name.Trim.ToUpper & "'s channel"
                    objUsers.Add(tmpUser)
                    itmX = lvwUsers.Items.Add(objUser.Info.Name.Trim.ToUpper, 0)
                    itmX.SubItems.Add(objNI.Connectionid.ToString.Trim)
                    itmX.SubItems.Add("Main")
                    GetChatChannels()
                    If lvwUsers.Items.Count > 0 Then lvwUsers.Items(0).Selected = True
                    sendControlMessage(ControlMessage.EN_CHATCTRL_ENTER, objUser.Info.Name.Trim.ToUpper & " has just entered the chat room")
                    txtChatMsg.Focus()
                Else
                    MsgBox("Error setting up the WINServer callback routines...", MsgBoxStyle.Critical, "System Call Back Error")
                    Me.Close()
                End If
            Else
                Me.Close()
            End If
        Else
            Me.Close()
        End If

    End Sub

#End Region

#Region "Control Events ..."

    Private Sub ContentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContentsToolStripMenuItem.Click

        Dim objHelp As New frmHelp
        objHelp.Show(Me)

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click

        Me.Close()

    End Sub

    Private Sub lvwChannels_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwChannels.DoubleClick

        If lvwChannels.Items.Count > 0 Then
            If lvwChannels.SelectedItems.Count > 0 Then
                Dim intNewChannel As Integer = CInt(lvwChannels.SelectedItems(0).SubItems(2).Text.Trim)
                sendControlMessageSwitch(objUser.Info.Name.Trim.ToUpper & " has switched to another channel.", intNewChannel, objUser.Info.Name.Trim.ToUpper & " has switched to this channel.")
                CloseChannel(ChatHandle)
                ChatHandle = OpenChannel("Chat." & intNewChannel.ToString.Trim)
                CurrentChannel = intNewChannel
            End If
        End If

    End Sub

    Private Sub lvwUsers_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwUsers.DoubleClick

        If lvwUsers.SelectedItems.Count > 0 Then
            If lvwUsers.SelectedItems(0).SubItems(1).Text.Trim <> 0 Then
                sendControlMessageSwitch(objUser.Info.Name.Trim.ToUpper & " has switched to another channel.", CInt(lvwUsers.SelectedItems(0).SubItems(1).Text.Trim), objUser.Info.Name.Trim.ToUpper & " has switched to this channel.")
                CloseChannel(ChatHandle)
                ChatHandle = OpenChannel("Chat." & lvwUsers.SelectedItems(0).SubItems(1).Text.Trim)
                CurrentChannel = CInt(lvwUsers.SelectedItems(0).SubItems(1).Text.Trim)
            End If
        End If
        txtChatMsg.Focus()

    End Sub

    Private Sub lvwServerUsers_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwServerUsers.DoubleClick

        If lvwServerUsers.Items.Count > 0 Then
            If lvwServerUsers.SelectedItems.Count > 0 Then
                txtChatMsg.Text = "/page " & lvwServerUsers.SelectedItems(0).Text.Trim & " "
                txtChatMsg.SelectionStart = txtChatMsg.Text.Length
                txtChatMsg.Focus()
            End If
        End If

    End Sub

    Private Sub rtbChatLog_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles rtbChatLog.LinkClicked

        System.Diagnostics.Process.Start(e.LinkText)

    End Sub

    Private Sub SaveChatLogToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveChatLogToolStripMenuItem.Click

        Dim diagRes As DialogResult
        fsdChat.FileName = "ChatLog-" & Format(Now, "MMddyyyy-HHmm") & ".rtf"
        diagRes = fsdChat.ShowDialog()
        If diagRes = DialogResult.OK Then
            If fsdChat.FileName.Trim = "" Then
            Else
                rtbChatLog.SaveFile(fsdChat.FileName)
            End If
        End If

    End Sub

    Private Sub tabUsers_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabUsers.SelectedIndexChanged

        If tabUsers.SelectedIndex = 2 Then
            GetOnlineServerUsers()
        ElseIf tabUsers.SelectedIndex = 1 Then
            GetChatChannels()
        End If

    End Sub

    Private Sub tsbClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClear.Click

        rtbChatLog.Rtf = My.Resources.RTFString

    End Sub

    Private Sub tsbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExit.Click

        Me.Close()

    End Sub

    Private Sub tsbJoinChannel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbJoinChannel.Click

        If lvwChannels.Items.Count > 0 Then
            If lvwChannels.SelectedItems.Count > 0 Then
                Dim intNewChannel As Integer = CInt(lvwChannels.SelectedItems(0).SubItems(2).Text.Trim)
                sendControlMessageSwitch(objUser.Info.Name.Trim.ToUpper & " has switched to another channel.", intNewChannel, objUser.Info.Name.Trim.ToUpper & " has switched to this channel.")
                CloseChannel(ChatHandle)
                ChatHandle = OpenChannel("Chat." & intNewChannel.ToString.Trim)
                CurrentChannel = intNewChannel
            End If
        End If

    End Sub

    Private Sub tsbJoinPersonalChannel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbJoinPersonalChannel.Click

        If lvwUsers.SelectedItems.Count > 0 Then
            If lvwUsers.SelectedItems(0).SubItems(1).Text.Trim <> 0 Then
                sendControlMessageSwitch(objUser.Info.Name.Trim.ToUpper & " has switched to another channel.", CInt(lvwUsers.SelectedItems(0).SubItems(1).Text.Trim), objUser.Info.Name.Trim.ToUpper & " has switched to this channel.")
                CloseChannel(ChatHandle)
                ChatHandle = OpenChannel("Chat." & lvwUsers.SelectedItems(0).SubItems(1).Text.Trim)
                CurrentChannel = CInt(lvwUsers.SelectedItems(0).SubItems(1).Text.Trim)
            End If
        End If
        txtChatMsg.Focus()

    End Sub

    Private Sub tsbMain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbMain.Click

        sendControlMessageSwitch(objUser.Info.Name.Trim.ToUpper & " has switched to another channel.", 0, objUser.Info.Name.Trim.ToUpper & " has switched to this channel.")
        CloseChannel(ChatHandle)
        ChatHandle = OpenChannel("Chat.0")
        CurrentChannel = 0
        txtChatMsg.Focus()

    End Sub

    Private Sub tsbRefreshChannels_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefreshChannels.Click

        GetChatChannels()

    End Sub

    Private Sub tsbUserPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbUserPage.Click

        If lvwServerUsers.Items.Count > 0 Then
            If lvwServerUsers.SelectedItems.Count > 0 Then
                txtChatMsg.Text = "/page " & lvwServerUsers.SelectedItems(0).Text.Trim & " "
                txtChatMsg.SelectionStart = txtChatMsg.Text.Length
                txtChatMsg.Focus()
            End If
        End If

    End Sub

    Private Sub tsbSendMsg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSendMsg.Click

        ChatMessageParse(txtChatMsg.Text.Trim)

    End Sub

    Private Sub tsbUserRecycle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbUserRecycle.Click

        GetOnlineServerUsers()

    End Sub

    Private Sub txtChatMsg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtChatMsg.KeyPress

        Select Case e.KeyChar
            Case Chr(13)
                e.Handled = True
                ChatMessageParse(txtChatMsg.Text.Trim)
            Case Else
        End Select

    End Sub

#End Region

#Region "Callback Support ..."

#Region "Private Delegates ..."

    Private Delegate Function dWildcatCallBackFunc(ByVal userdata As Integer, ByRef Msg As TChannelMessage) As Integer
    Private Delegate Sub UpdateUIHandler(ByVal msgType As String, ByVal SenderID As Short, ByVal Msg As Object)
    Private objCBFunc As New dWildcatCallBackFunc(AddressOf WildcatCallBackFunc)

#End Region

    Private Sub UpdateUI(ByVal msgType As String, ByVal SenderID As Short, ByVal Msg As Object)

        Try
            Dim uiHandler As New UpdateUIHandler(AddressOf UpdateUI_IMP)
            Dim args() As Object = {msgType, SenderID, Msg}
            Me.BeginInvoke(uiHandler, args)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub UpdateUI_IMP(ByVal msgType As String, ByVal SenderID As Short, ByVal Msg As Object)

        Dim itmX As ListViewItem = Nothing
        Dim tmpUser As New clsChatUser

        Try
            Select Case msgType
                Case "CHATCTRL_ENTER"
                    Dim myMSG As TChatControl = Msg
                    If objNI.Connectionid = SenderID Then
                        ColorizeRTFMessageInitial("Welcome to chat on " & BBSName.Trim & "." & Environment.NewLine)
                        ColorizeRTFMessage("Checking for others...")
                    Else
                        If myMSG.ChannelId = CurrentChannel Then
                            If lvwUsers.Items.Count > 0 Then itmX = lvwUsers.FindItemWithText(SenderID, True, 0)
                            If itmX Is Nothing Then
                                tmpUser.Name = myMSG.Name.Trim
                                tmpUser.Channel = myMSG.ChannelId
                                tmpUser.ID = SenderID
                                tmpUser.Topic = myMSG.Name.Trim & "'s channel"
                                objUsers.Add(tmpUser)
                                itmX = lvwUsers.Items.Add(myMSG.Name.Trim, 0)
                                itmX.SubItems.Add(SenderID.ToString.Trim)
                                If myMSG.ChannelId = 0 Then
                                    itmX.SubItems.Add("Main")
                                Else
                                    itmX.SubItems.Add(GetUserChannelFromCollection(myMSG.ChannelId).Topic.Trim)
                                End If
                                If lvwUsers.Items.Count > 0 Then lvwUsers.Items(0).Selected = True
                            End If
                            ColorizeRTFControl(myMSG.Name.Trim, " has entered the chat room")
                        Else
                            Debug.WriteLine("Msg Channel:  " & myMSG.ChannelId.ToString.Trim)
                        End If
                    End If
                    sendControlMessage(ControlMessage.EN_CHATCTRL_ENTERACK, objUser.Info.Name.Trim.ToUpper & "'s channel")
                Case "CHATCTRL_ENTERACK"
                    Dim myMSG As TChatControl = Msg
                    If SenderID = objNI.Connectionid Then
                    Else
                        itmX = lvwUsers.FindItemWithText(SenderID, True, 0)
                        If itmX Is Nothing Then
                            tmpUser.Name = myMSG.Name.Trim
                            tmpUser.Channel = myMSG.ChannelId
                            tmpUser.ID = SenderID
                            tmpUser.Topic = myMSG.Name.Trim & "'s channel"
                            objUsers.Add(tmpUser)
                            itmX = lvwUsers.Items.Add(myMSG.Name, 0)
                            itmX.SubItems.Add(SenderID.ToString.Trim)
                            If myMSG.ChannelId = 0 Then
                                itmX.SubItems.Add("Main")
                            ElseIf myMSG.ChannelId < 0 Then
                                '//Permanent channel
                                Dim itmX1 As ListViewItem
                                itmX1 = lvwChannels.FindItemWithText(myMSG.ChannelId, True, 0)
                                If itmX1 Is Nothing Then
                                    itmX.SubItems.Add("??????????")
                                Else
                                    itmX.SubItems.Add(itmX1.Text.Trim)
                                End If
                            Else
                                itmX.SubItems.Add(GetUserChannelFromCollection(myMSG.ChannelId).Topic.Trim)
                            End If
                            If lvwUsers.Items.Count > 0 Then lvwUsers.Items(0).Selected = True
                        End If
                    End If
                Case "CHATCTRL_LEAVE"
                    Dim myMSG As TChatControl = Msg
                    ColorizeRTFControl(myMSG.Name.Trim, " has left the chat room...")
                    itmX = lvwUsers.FindItemWithText(SenderID, True, 0)
                    If itmX Is Nothing Then
                    Else
                        itmX.Remove()
                        Dim holdUser As New clsChatUser
                        For Each tmpUser In objUsers
                            If tmpUser.ID = SenderID Then
                                holdUser = tmpUser
                                Exit For
                            End If
                        Next
                        If holdUser.ID <> 0 Then objUsers.Remove(holdUser)
                        If lvwUsers.Items.Count > 0 Then lvwUsers.Items(0).Selected = True
                    End If
                Case "CHATCTRL_SWITCH"
                    Dim myMSG As TChatControlSwitch = Msg
                    Dim addUser As New clsChatUser
                    tmpUser = GetUserFromCollection(SenderID)
                    If tmpUser Is Nothing Then
                        addUser.Channel = myMSG.NewId
                        addUser.ID = SenderID
                        addUser.Name = myMSG.Control.Name
                        addUser.Topic = myMSG.Control.Name & "'s channel"
                        objUsers.Add(addUser)
                        tmpUser = GetUserFromCollection(SenderID)
                    Else
                        tmpUser.Channel = myMSG.NewId
                    End If
                    itmX = lvwUsers.FindItemWithText(SenderID.ToString.Trim, True, 0)
                    If itmX Is Nothing Then
                        itmX = lvwUsers.Items.Add(myMSG.Control.Name.Trim, 0)
                        itmX.SubItems.Add(SenderID.ToString.Trim)
                        If myMSG.NewId = 0 Then
                            itmX.SubItems.Add("Main")
                        Else
                            itmX.SubItems.Add(GetUserChannelFromCollection(myMSG.NewId).Topic.Trim)
                        End If
                        If lvwUsers.Items.Count > 0 Then lvwUsers.Items(0).Selected = True
                    Else
                        If myMSG.NewId = 0 Then
                            itmX.SubItems(2).Text = "Main"
                        ElseIf myMSG.NewId < 0 Then
                            '//Permanent channel
                            Dim itmX1 As ListViewItem
                            itmX1 = lvwChannels.FindItemWithText(myMSG.NewId, True, 0)
                            If itmX1 Is Nothing Then
                                itmX.SubItems(2).Text = "??????????"
                            Else
                                itmX.SubItems(2).Text = itmX1.Text.Trim
                            End If
                        Else
                            itmX.SubItems(2).Text = GetUserChannelFromCollection(myMSG.NewId).Topic.Trim
                        End If
                    End If
                    If myMSG.Control.ChannelId = CurrentChannel Then
                        ColorizeRTFMessage(myMSG.Control.Text.Trim)
                    Else
                        ColorizeRTFMessage(myMSG.NewText)
                    End If
                Case "CHATCTRL_TOPIC"
                    Dim myMSG As TChatControl = Msg
                    tmpUser = GetUserFromCollection(SenderID)
                    If tmpUser Is Nothing Then
                    Else
                        If tmpUser.Channel = CurrentChannel And SenderID <> objUsers(0).ID Then
                            ColorizeRTFMessage(myMSG.Name.Trim & " just changed this channel topic to " & myMSG.Text.Trim)
                            tmpUser.Topic = myMSG.Text.Trim
                        End If
                    End If
                Case "CHATCTRL_VANISH"
                    Dim myMSG As TChatControl = Msg
                    ColorizeRTFControl(myMSG.Name.Trim, " has vanished without a trace...")
                Case "CHATMSG_TEXT"
                    Dim myMSG As TChatMessage = Msg
                    Dim txtWhisper As String = ""
                    If myMSG.Whisper = 255 Then txtWhisper = "[PVT] "
                    ColorizeRTF(SenderID, txtWhisper & myMSG.From, myMSG.Text.Trim)
                Case "CHATMSG_ACTION"
                    Dim myMSG As TChatAction = Msg
                Case "PAGE_MSG"
                    Dim myMSG As TPageMessage = Msg
                    ColorizeRTFPage("Page from " & myMSG.From.Trim & ":", True, False)
                    ColorizeRTFPage(myMSG.Message(0).PageText & myMSG.Message(1).PageText & myMSG.Message(2).PageText, False, True)
            End Select
        Catch ex As Exception
            MsgBox("Error:  " & ex.ToString, MsgBoxStyle.Information, "UpdateUI_IMP Error")
        End Try

    End Sub

    Private Function WildcatCallBackFunc(ByVal UserData As Integer, ByRef msg As TChannelMessage) As Integer

        Try
            If msg.Channel = PageEventHandle Then
                Debug.WriteLine("PageEventHandle:  " & msg.UserData.ToString.Trim)
                Dim myPM As New TPageMessage
                Dim myGC As GCHandle = GCHandle.Alloc(msg.Data, GCHandleType.Pinned)
                ReDim myPM.Message(3)
                myPM = Marshal.PtrToStructure(myGC.AddrOfPinnedObject, myPM.GetType)
                myGC.Free()
                UpdateUI("PAGE_MSG", msg.SenderId, myPM)
            ElseIf msg.Channel = ChatEventHandle Then
                Debug.WriteLine("ChatEventHandle:  " & msg.UserData.ToString.Trim)
                Dim myGC As GCHandle = GCHandle.Alloc(msg.Data, GCHandleType.Pinned)
                Dim myCCM As New TChatControl
                Dim myCCSM As New TChatControlSwitch
                If msg.UserData <> CHATCTRL_SWITCH Then myCCM = Marshal.PtrToStructure(myGC.AddrOfPinnedObject, myCCM.GetType)
                Select Case msg.UserData
                    Case CHATCTRL_ENTER
                        UpdateUI("CHATCTRL_ENTER", msg.SenderId, myCCM)
                    Case CHATCTRL_ENTERACK
                        UpdateUI("CHATCTRL_ENTERACK", msg.SenderId, myCCM)
                    Case CHATCTRL_LEAVE
                        UpdateUI("CHATCTRL_LEAVE", msg.SenderId, myCCM)
                    Case CHATCTRL_SWITCH
                        myCCSM = Marshal.PtrToStructure(myGC.AddrOfPinnedObject, myCCSM.GetType)
                        UpdateUI("CHATCTRL_SWITCH", msg.SenderId, myCCSM)
                    Case CHATCTRL_TOPIC
                        UpdateUI("CHATCTRL_TOPIC", msg.SenderId, myCCM)
                    Case -1
                        UpdateUI("CHATCTRL_VANISH", msg.SenderId, myCCM)
                End Select
                myGC.Free()
            ElseIf msg.Channel = ChatHandle Then
                Debug.WriteLine("ChatHandle:  " & msg.UserData.ToString.Trim)
                Dim myCM As New TChatMessage
                Dim myGC As GCHandle = GCHandle.Alloc(msg.Data, GCHandleType.Pinned)
                myCM = Marshal.PtrToStructure(myGC.AddrOfPinnedObject, myCM.GetType)
                myGC.Free()
                Select Case msg.UserData
                    Case CHATMSG_TEXT
                        UpdateUI("CHATMSG_TEXT", msg.SenderId, myCM)
                    Case CHATMSG_ACTION
                        UpdateUI("CHATMSG_ACTION", msg.SenderId, myCM)
                End Select
            Else
                Debug.WriteLine("Got something, just wasnt what we wanted")
            End If
        Catch ex As Exception
            MsgBox("Error:  " & ex.ToString)
        End Try


    End Function

#End Region

#Region "Private Functions ..."

    Private Function GetUserChannelFromCollection(ByVal ChannelID As Integer) As clsChatUser

        Dim tmpUser As clsChatUser = Nothing

        GetUserChannelFromCollection = tmpUser

        For Each tmpUser In objUsers
            If tmpUser.Channel = ChannelID Then
                GetUserChannelFromCollection = tmpUser
                Exit For
            End If
        Next

    End Function

    Private Function GetUserFromCollection(ByVal ID As Integer) As clsChatUser

        Dim tmpUser As clsChatUser = Nothing

        GetUserFromCollection = tmpUser

        For Each tmpUser In objUsers
            If tmpUser.ID = ID Then
                GetUserFromCollection = tmpUser
                Exit For
            End If
        Next

    End Function

    Private Function GetUserFromCollectionByName(ByVal Name As String) As clsChatUser

        Dim tmpUser As clsChatUser = Nothing

        GetUserFromCollectionByName = tmpUser

        For Each tmpUser In objUsers
            If tmpUser.Name.Trim.ToUpper = Name.Trim.ToUpper Then
                GetUserFromCollectionByName = tmpUser
                Exit For
            End If
        Next

    End Function

    Private Function sendChatMessage(ByVal Dest As Integer, ByVal ChatMsg As ChatMessage, ByVal Message As String, ByVal Whisper As Boolean) As Boolean

        Dim cMsg As TChatMessage
        cMsg.From = objUser.Info.Name.Trim.ToUpper
        cMsg.Text = Message
        cMsg.Whisper = Whisper
        sendChatMessage = WriteChannel(ChatHandle, Dest, ChatMsg, cMsg, Marshal.SizeOf(cMsg))
        txtChatMsg.Focus()

    End Function

    Private Function sendControlMessage(ByVal CntrlMessage As ControlMessage, ByVal Message As String) As Boolean

        Dim ccMsg As TChatControl
        ccMsg.Name = objUser.Info.Name.Trim.ToUpper
        ccMsg.ChannelId = CurrentChannel
        ccMsg.Text = Message
        sendControlMessage = WriteChannel(ChatEventHandle, 0, CntrlMessage, ccMsg, Marshal.SizeOf(ccMsg))

        txtChatMsg.Focus()

    End Function

    Private Function sendControlMessageSwitch(ByVal Text As String, ByVal NewID As Integer, ByVal NewText As String) As Boolean

        Dim ccsMsg As TChatControlSwitch
        ccsMsg.Control.Name = objUser.Info.Name.ToUpper
        ccsMsg.Control.ChannelId = CurrentChannel
        ccsMsg.Control.Text = Text
        ccsMsg.NewId = NewID
        ccsMsg.NewText = NewText
        sendControlMessageSwitch = WriteChannel(ChatEventHandle, 0, CHATCTRL_SWITCH, ccsMsg, Marshal.SizeOf(ccsMsg))
        txtChatMsg.Focus()

    End Function

#End Region

#Region "Private Subroutines ..."

    Private Sub ChatMessageParse(ByVal TypedMessage As String)

        Dim Dest As Integer = CurrentChannel
        Dim Whisper As Boolean = False
        Dim Message As String = ""
        Dim intX As Integer

        If txtChatMsg.Text.Trim = "" Then
        Else
            If txtChatMsg.Text.Substring(0, 1) = "/" Then
                Dim arrCommand() As String = Split(txtChatMsg.Text.Trim, " ")
                Select Case arrCommand(0).ToUpper.Trim
                    Case "/C", "/CHANNELS"
                        ColorizeRTFMessage("--Please check the Channel List")
                        GetChatChannels()
                        Me.tabUsers.SelectTab(1)
                    Case "/L", "/LIST"
                        '//List the users is not needed
                        ColorizeRTFMessage("--Please check the Chat list")
                        Me.tabUsers.SelectTab(0)
                    Case "/J", "/JOIN"
                        If arrCommand.Length = 1 Then
                            '//Joined their own channel
                            Message = ""
                            sendControlMessageSwitch(objUser.Info.Name.Trim.ToUpper & " has switched to another channel.", objUsers(0).ID, objUser.Info.Name.Trim.ToUpper & " has switched to this channel.")
                            CloseChannel(ChatHandle)
                            ChatHandle = OpenChannel("Chat." & objUsers(0).ID.ToString.Trim)
                            CurrentChannel = objUsers(0).ID
                        Else
                            Dim tmpUser As clsChatUser = GetUserFromCollectionByName(arrCommand(1).Trim)
                            If tmpUser Is Nothing And arrCommand.Length > 2 Then
                                tmpUser = GetUserFromCollectionByName(arrCommand(1) & " " & arrCommand(2).Trim)
                                If tmpUser Is Nothing Then
                                    Dim itmX As ListViewItem
                                    For intX = 1 To arrCommand.Length - 1
                                        Message = Message & arrCommand(intX).Trim & " "
                                    Next
                                    itmX = lvwChannels.FindItemWithText(Message.Trim.ToUpper, True, 0)
                                    If itmX Is Nothing Then
                                        Message = ""
                                        ColorizeRTFMessage("--There is no user by the name of " & arrCommand(1).Trim & " " & arrCommand(2).Trim & " in chat at this time, and no channel was found.")
                                    ElseIf itmX.Text.Trim.ToUpper = "MAIN" Then
                                        Message = ""
                                        sendControlMessageSwitch(objUser.Info.Name.Trim.ToUpper & " has switched to another channel.", 0, objUser.Info.Name.Trim.ToUpper & " has switched to this channel.")
                                        CloseChannel(ChatHandle)
                                        ChatHandle = OpenChannel("Chat.0")
                                        CurrentChannel = 0
                                    Else
                                        Message = ""
                                        Dim intNewChannel As Integer = GetStringObjectId(&HFF000000, itmX.Text.Trim)
                                        sendControlMessageSwitch(objUser.Info.Name.Trim.ToUpper & " has switched to another channel.", intNewChannel, objUser.Info.Name.Trim.ToUpper & " has switched to this channel.")
                                        CloseChannel(ChatHandle)
                                        ChatHandle = OpenChannel("Chat." & intNewChannel.ToString.Trim)
                                        CurrentChannel = intNewChannel
                                    End If
                                Else
                                    Message = ""
                                    sendControlMessageSwitch(objUser.Info.Name.Trim.ToUpper & " has switched to another channel.", tmpUser.ID, objUser.Info.Name.Trim.ToUpper & " has switched to this channel.")
                                    CloseChannel(ChatHandle)
                                    ChatHandle = OpenChannel("Chat." & tmpUser.ID.ToString.Trim)
                                    CurrentChannel = tmpUser.ID
                                End If
                            ElseIf tmpUser Is Nothing And arrCommand.Length <= 2 Then
                                Dim itmX As ListViewItem
                                For intX = 1 To arrCommand.Length - 1
                                    Message = Message & arrCommand(intX).Trim & " "
                                Next
                                itmX = lvwChannels.FindItemWithText(Message.Trim.ToUpper, True, 0)
                                If itmX Is Nothing Then
                                    Message = ""
                                    ColorizeRTFMessage("--There is no user by the name of " & arrCommand(1).Trim & " in chat at this time, and no channel was found.")
                                ElseIf itmX.Text.Trim.ToUpper = "MAIN" Then
                                    Message = ""
                                    sendControlMessageSwitch(objUser.Info.Name.Trim.ToUpper & " has switched to another channel.", 0, objUser.Info.Name.Trim.ToUpper & " has switched to this channel.")
                                    CloseChannel(ChatHandle)
                                    ChatHandle = OpenChannel("Chat.0")
                                    CurrentChannel = 0
                                Else
                                    Message = ""
                                    Dim intNewChannel As Integer = GetStringObjectId(&HFF000000, itmX.Text.Trim)
                                    sendControlMessageSwitch(objUser.Info.Name.Trim.ToUpper & " has switched to another channel.", intNewChannel, objUser.Info.Name.Trim.ToUpper & " has switched to this channel.")
                                    CloseChannel(ChatHandle)
                                    ChatHandle = OpenChannel("Chat." & intNewChannel.ToString.Trim)
                                    CurrentChannel = intNewChannel
                                End If
                            Else
                                Message = ""
                                sendControlMessageSwitch(objUser.Info.Name.Trim.ToUpper & " has switched to another channel.", 0, objUser.Info.Name.Trim.ToUpper & " has switched to this channel.")
                                CloseChannel(ChatHandle)
                                ChatHandle = OpenChannel("Chat." & tmpUser.ID.ToString.Trim)
                                CurrentChannel = tmpUser.ID
                            End If
                        End If
                    Case "/M", "/MAIN"
                        '//Joing the main channel
                        sendControlMessageSwitch(objUser.Info.Name.Trim.ToUpper & " has switched to another channel.", 0, objUser.Info.Name.Trim.ToUpper & " has switched to this channel.")
                        CloseChannel(ChatHandle)
                        ChatHandle = OpenChannel("Chat.0")
                        CurrentChannel = 0
                    Case "/P", "/PAGE"
                        '//Page a user
                        If arrCommand.Length > 1 Then
                            Dim objTNI As New TwcNodeInfo
                            Dim objPM As New TPageMessage
                            Dim intHold As Integer = 0
                            ReDim objPM.Message(3)
                            If GetNodeInfoByName(arrCommand(1).Trim.ToUpper, objTNI) Then
                                objPM.From = objUser.Info.Name.Trim
                                objPM.InviteToChat = 0
                                For intX = 2 To arrCommand.Length - 1
                                    Message = Message & arrCommand(intX).Trim & " "
                                Next
                                If Message.Length > 80 Then
                                    intHold = Len(Message) - 80
                                    objPM.Message(0).PageText = Mid(Message, 1, 79) & Chr(0)
                                    If intHold > 80 Then
                                        objPM.Message(1).PageText = Mid(Message, 80, 79) & Chr(0)
                                        objPM.Message(2).PageText = Mid(Message, 159, Len(Message) - 160) & Chr(0)
                                    Else
                                        objPM.Message(1).PageText = Mid(Message, 80, Len(Message) - 79) & Chr(0)
                                    End If
                                Else
                                    objPM.Message(0).PageText = Message.Trim
                                End If
                                WriteChannel(PageEventHandle, objTNI.Connectionid, 0, objPM, Marshal.SizeOf(objPM))
                                ColorizeRTFMessage("--Page sent to " & objTNI.User.Name.Trim)
                            ElseIf GetNodeInfoByName(arrCommand(1).Trim.ToUpper & " " & arrCommand(2).Trim.ToUpper, objTNI) Then
                                objPM.From = objUser.Info.Name.Trim
                                objPM.InviteToChat = 0
                                For intX = 3 To arrCommand.Length - 1
                                    Message = Message & arrCommand(intX).Trim & " "
                                Next
                                If Message.Length > 80 Then
                                    intHold = Len(Message) - 80
                                    objPM.Message(0).PageText = Mid(Message, 1, 79) & Chr(0)
                                    If intHold > 80 Then
                                        objPM.Message(1).PageText = Mid(Message, 80, 79) & Chr(0)
                                        objPM.Message(2).PageText = Mid(Message, 159, Len(Message) - 160) & Chr(0)
                                    Else
                                        objPM.Message(1).PageText = Mid(Message, 80, Len(Message) - 79) & Chr(0)
                                    End If
                                Else
                                    objPM.Message(0).PageText = Message.Trim
                                End If
                                WriteChannel(PageEventHandle, objTNI.Connectionid, 0, objPM, Marshal.SizeOf(objPM))
                                ColorizeRTFMessage("--Page sent to " & objTNI.User.Name.Trim)
                            Else
                                ColorizeRTFMessage("--That user was not found online")
                            End If
                        End If
                        Message = ""
                    Case "/Q", "/QUIT", "/E", "/EXIT", "/X"
                        Dim askSure As MsgBoxResult = MsgBox("Are you sure you want to quit chat?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Exit Chat")
                        If askSure = MsgBoxResult.Yes Then Me.Close()
                    Case "/T", "/TOPIC"
                        If CurrentChannel <> objUsers(0).ID Then
                            ColorizeRTFMessage("You cannot change the topic in this channel.")
                            Message = ""
                        Else
                            If arrCommand.Length = 1 Then
                            Else
                                For intX = 1 To arrCommand.Length - 1
                                    Message = Message & arrCommand(intX).Trim & " "
                                Next
                                objUsers(0).Topic = Message
                            End If
                            sendControlMessage(ControlMessage.EN_CHATCTRL_TOPIC, objUsers(0).Topic)
                            ColorizeRTFMessage("You just changed your channel topic to " & objUsers(0).Topic.Trim)
                            Message = ""
                        End If
                    Case "/W", "/WHO"
                        ColorizeRTFMessage("--Please check the Online list")
                        GetOnlineServerUsers()
                        Me.tabUsers.SelectTab(2)
                    Case "/?", "/H", "/HELP"
                        ColorizeRTFPage("/CHANNELS              -- List available chat channels", True, False)
                        ColorizeRTFPage("/JOIN                  -- Join your own channel", False, False)
                        ColorizeRTFPage("/JOIN <name>           -- Join a channel by user name", False, False)
                        ColorizeRTFPage("/LIST                  -- List users in chat", False, False)
                        ColorizeRTFPage("/MAIN                  -- Go to the main channel", False, False)
                        ColorizeRTFPage("/PAGE <name> <message> -- Page another user with a message", False, False)
                        ColorizeRTFPage("/QUIT or /EXIT         -- Quit chat", False, False)
                        ColorizeRTFPage("/TOPIC                 -- Change channel topic (your channel only)", False, False)
                        ColorizeRTFPage("/WHO                   -- Who is online", False, False)
                        ColorizeRTFPage("!<verb> <name>         -- Action word, ie. !kick rick", False, True)
                    Case Else
                        If arrCommand.Length > 1 Then
                            Dim tmpUser As clsChatUser
                            tmpUser = GetUserFromCollectionByName(arrCommand(0).Substring(1, arrCommand(0).Length - 1))
                            If tmpUser Is Nothing Then
                                tmpUser = GetUserFromCollectionByName(arrCommand(0).Substring(1, arrCommand(0).Length - 1) & " " & arrCommand(1).Trim)
                                If tmpUser Is Nothing Then
                                    Message = txtChatMsg.Text.Trim
                                Else
                                    Dest = tmpUser.Channel
                                    Whisper = True
                                    For intX = 2 To arrCommand.Length - 1
                                        Message = Message & arrCommand(intX).Trim & " "
                                    Next
                                End If
                            Else
                                Dest = tmpUser.Channel
                                Whisper = True
                                For intX = 1 To arrCommand.Length - 1
                                    Message = Message & arrCommand(intX).Trim & " "
                                Next
                            End If
                        Else
                            Message = ""
                        End If
                End Select
                'ElseIf txtChatMsg.Text.Substring(0, 1) = "!" Then

            Else
                Message = TypedMessage
            End If

            If Message.Trim <> "" Then
                If Dest < 0 Then
                    sendChatMessage(0, ChatMessage.EN_CHATMSG_TEXT, Message, Whisper)
                Else
                    sendChatMessage(Dest, ChatMessage.EN_CHATMSG_TEXT, Message, Whisper)
                End If
            End If
        End If

        txtChatMsg.Text = ""
        txtChatMsg.Focus()

    End Sub

    Private Sub ColorizeRTF(ByVal SenderID As Integer, ByVal Name As String, ByVal Message As String)

        If SenderID = objNI.Connectionid Then
            If Name.Substring(0, 5) = "[PVT]" Then
                rtbChatLog.Rtf = rtbChatLog.Rtf.Substring(0, rtbChatLog.Rtf.Length - 3) & "\viewkind4\uc1\pard\cf4\b0\f0\fs18 " & Name.Trim.ToUpper & "\viewkind4\uc1\pard\b0\f0\fs18 : " & Message.Trim & "\cf0\b0\par" & Environment.NewLine & "}"
            Else
                rtbChatLog.Rtf = rtbChatLog.Rtf.Substring(0, rtbChatLog.Rtf.Length - 3) & "\viewkind4\uc1\pard\cf4\b0\f0\fs18 -" & Name.Trim.ToUpper & "\viewkind4\uc1\pard\b0\f0\fs18 : " & Message.Trim & "\cf0\b0\par" & Environment.NewLine & "}"
            End If
            rtbChatLog.SelectionStart = rtbChatLog.Rtf.Length
            rtbChatLog.ScrollToCaret()
        Else
            If Name.Substring(0, 5) = "[PVT]" Then
                rtbChatLog.Rtf = rtbChatLog.Rtf.Substring(0, rtbChatLog.Rtf.Length - 3) & "\viewkind4\uc1\pard\cf1\b0\f0\fs18 " & Name.Trim.ToUpper & "\viewkind4\uc1\pard\b0\f0\fs18 : " & Message.Trim & "\cf0\b0\par" & Environment.NewLine & "}"
            Else
                rtbChatLog.Rtf = rtbChatLog.Rtf.Substring(0, rtbChatLog.Rtf.Length - 3) & "\viewkind4\uc1\pard\cf3\b0\f0\fs18 -" & Name.Trim.ToUpper & "\viewkind4\uc1\pard\b0\f0\fs18 : " & Message.Trim & "\cf0\b0\par" & Environment.NewLine & "}"
            End If
            rtbChatLog.SelectionStart = rtbChatLog.Rtf.Length
            rtbChatLog.ScrollToCaret()
        End If

        rtbChatLog.Height = rtbChatLog.Height + 1
        rtbChatLog.Width = rtbChatLog.Width + 1
        txtChatMsg.Focus()

    End Sub

    Private Sub ColorizeRTFControl(ByVal Name As String, ByVal Message As String)

        rtbChatLog.Rtf = rtbChatLog.Rtf.Substring(0, rtbChatLog.Rtf.Length - 3) & "\viewkind4\uc1\pard\cf5\b0\f0\fs18 --- " & Name.Trim.ToUpper & "\viewkind4\uc1\pard\b0\f0\fs18  " & Message.Trim & "\cf0\b0\par" & Environment.NewLine & "}"
        rtbChatLog.SelectionStart = rtbChatLog.Rtf.Length
        rtbChatLog.ScrollToCaret()

        rtbChatLog.Height = rtbChatLog.Height + 1
        rtbChatLog.Width = rtbChatLog.Width + 1
        txtChatMsg.Focus()

    End Sub

    Private Sub ColorizeRTFMessage(ByVal Message As String)

        rtbChatLog.Rtf = rtbChatLog.Rtf.Substring(0, rtbChatLog.Rtf.Length - 3) & "\viewkind4\uc1\pard\cf5\b0\f0\fs18" & Message.Trim & "\cf0\b0\par" & Environment.NewLine & "\par}"
        rtbChatLog.SelectionStart = rtbChatLog.Rtf.Length
        rtbChatLog.ScrollToCaret()
        rtbChatLog.Height = rtbChatLog.Height + 1
        rtbChatLog.Width = rtbChatLog.Width + 1
        txtChatMsg.Focus()

    End Sub

    Private Sub ColorizeRTFMessageInitial(ByVal Message As String)

        rtbChatLog.Rtf = rtbChatLog.Rtf.Substring(0, rtbChatLog.Rtf.Length - 9) & "\par\par\viewkind4\uc1\pard\cf5\b0\f0\fs18" & Message.Trim & "\cf0\b0\par" & Environment.NewLine & "}"
        rtbChatLog.SelectionStart = rtbChatLog.Rtf.Length
        rtbChatLog.ScrollToCaret()
        rtbChatLog.Height = rtbChatLog.Height + 1
        rtbChatLog.Width = rtbChatLog.Width + 1
        txtChatMsg.Focus()

    End Sub

    Private Sub ColorizeRTFPage(ByVal Message As String, ByVal BeginMsg As Boolean, ByVal EndMsg As Boolean)

        If BeginMsg Then
            '//rtbChatLog.Rtf = rtbChatLog.Rtf.Substring(0, rtbChatLog.Rtf.Length - 3) & "\viewkind4\uc1\pard\cf1\b0\f0\fs18 \cf0\b0\par" & Environment.NewLine & "}"
            rtbChatLog.Rtf = rtbChatLog.Rtf.Substring(0, rtbChatLog.Rtf.Length - 3) & "\viewkind4\uc1\pard\cf1\b0\f0\fs18 " & Message.Trim & "\cf0\b0\par" & Environment.NewLine & "}"
        ElseIf EndMsg Then
            If Message.Trim <> "" Then
                rtbChatLog.Rtf = rtbChatLog.Rtf.Substring(0, rtbChatLog.Rtf.Length - 3) & "\viewkind4\uc1\pard\cf1\b0\f0\fs18 " & Message.Trim & "\cf0\b0\par" & Environment.NewLine & "}"
                rtbChatLog.Rtf = rtbChatLog.Rtf.Substring(0, rtbChatLog.Rtf.Length - 3) & "\viewkind4\uc1\pard\cf1\b0\f0\fs18 \cf0\b0\par" & Environment.NewLine & "}"
            Else
                rtbChatLog.Rtf = rtbChatLog.Rtf.Substring(0, rtbChatLog.Rtf.Length - 3) & "\viewkind4\uc1\pard\cf1\b0\f0\fs18 \cf0\b0\par" & Environment.NewLine & "\par}"
            End If
        Else
            If Message.Trim <> "" Then rtbChatLog.Rtf = rtbChatLog.Rtf.Substring(0, rtbChatLog.Rtf.Length - 3) & "\viewkind4\uc1\pard\cf1\b0\f0\fs18 " & Message.Trim & "\cf0\b0\par" & Environment.NewLine & "}"
        End If
        rtbChatLog.SelectionStart = rtbChatLog.Rtf.Length
        rtbChatLog.ScrollToCaret()

        rtbChatLog.Height = rtbChatLog.Height + 1
        rtbChatLog.Width = rtbChatLog.Width + 1
        txtChatMsg.Focus()

    End Sub

    Private Sub GetChatChannels()

        Try
            lvwChannels.Items.Clear()

            If WcExistFile("wc:\DATA\channels.dat") Then
                Dim chanFile As String = GetText("wc:\DATA\channels.dat")
                Dim arrChan() As String = chanFile.Split(Environment.NewLine)
                Dim itmX As ListViewItem
                Dim intX As Integer = 0

                itmX = lvwChannels.Items.Add("Main", 2)
                itmX.SubItems.Add("MAIN")
                itmX.SubItems.Add("0")

                For intX = 0 To arrChan.Length - 1
                    If GetStringObjectFlags(OBJECTCLASS_CHAT_CHANNEL, arrChan(intX).Trim) <> 0 Then
                        itmX = lvwChannels.Items.Add(arrChan(intX).Trim, 2)
                        itmX.SubItems.Add(arrChan(intX).Trim.ToUpper)
                        itmX.SubItems.Add(GetStringObjectId(&HFF000000, arrChan(intX).Trim).ToString.Trim)
                    End If
                Next
                If lvwChannels.Items.Count > 0 Then lvwChannels.Items(0).Selected = True
            End If
        Catch ex As Exception
            MsgBox("Error:  " & ex.ToString, MsgBoxStyle.Information, "GetChatChannels Error")
        End Try

    End Sub

    Private Sub GetOnlineServerUsers()

        Try
            Dim itmX As ListViewItem
            Dim intCount As Integer = GetNodeCount()
            Dim intNodes As Integer = 0
            Dim objTNI As New TwcNodeInfo

            lvwServerUsers.Items.Clear()

            For intNodes = 1 To intCount
                GetNodeInfo(intNodes, objTNI)
                If objTNI.Connectionid <> 0 And objTNI.User.Name.Trim <> "" Then
                    itmX = lvwServerUsers.Items.Add(objTNI.User.Name.Trim, 1)
                    itmX.SubItems.Add(intNodes.ToString.Trim)
                    itmX.SubItems.Add(objTNI.Activity.Trim)
                End If
            Next
            If lvwServerUsers.Items.Count > 0 Then lvwServerUsers.Items(0).Selected = True
        Catch ex As Exception
            MsgBox("Error:  " & ex.ToString, MsgBoxStyle.Information, "GetOnlineServerUsers Error")
        End Try

    End Sub

#End Region

End Class
