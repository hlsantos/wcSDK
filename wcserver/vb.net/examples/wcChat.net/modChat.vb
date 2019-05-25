Option Strict On
Option Explicit On

Imports System.Runtime.InteropServices, wcSDK.wcServerAPI

Module modChat

    Public BBSServerName As String = "ntbbs"
    Public BBSName As String = ""
    Public BBSReg As String = ""
    Public BBSSysOpName As String = ""
    Public mvarUserName As String = ""
    Public mvarPassword As String = ""
    Public mvarNodeID As Integer = 0
    Public objNI As New TwcNodeInfo
    Public objUser As New TUser


    Public Function CenterForm(ByRef frmWhatForm As System.Windows.Forms.Form) As Integer

        frmWhatForm.Left = CInt((System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - frmWhatForm.Width) / 2)
        frmWhatForm.Top = CInt((System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - frmWhatForm.Height) / 2)

    End Function

    Public Function MouseHour() As Short

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

    End Function

    Public Function MouseNormal() As Short

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

    End Function

    Public Function ConnectToWINS(Optional ByVal objStatus As Object = Nothing) As Boolean

        Dim myMW As New TMakewild
        Dim RetVal As Integer = 0

        ConnectToWINS = True

        If objStatus Is Nothing Then
        Else
            CType(objStatus, System.Windows.Forms.Label).Text = "Finding WINS Server..."
            CType(objStatus, System.Windows.Forms.Label).Refresh()
        End If

        If WildcatServerConnectSpecific(0, BBSServerName) Then
            If objStatus Is Nothing Then
            Else
                CType(objStatus, System.Windows.Forms.Label).Text = "Creating Context..."
                CType(objStatus, System.Windows.Forms.Label).Refresh()
            End If
            If WildcatServerCreateContext() Then
                If objStatus Is Nothing Then
                Else
                    CType(objStatus, System.Windows.Forms.Label).Text = "Logging in as SYSTEM..."
                    CType(objStatus, System.Windows.Forms.Label).Refresh()
                End If
                If LoginSystem() Then
                Else
                    WildcatServerDeleteContext()
                    MsgBox("Unable to login as system" & Environment.NewLine & "Error:  " & WildcatError(Err.LastDllError), MsgBoxStyle.Critical, "Can't login")
                    ConnectToWINS = False
                End If
                If objStatus Is Nothing Then
                Else
                    CType(objStatus, System.Windows.Forms.Label).Text = "Please Wait (continuing)..."
                    CType(objStatus, System.Windows.Forms.Label).Refresh()
                End If
            Else
                MsgBox("Unable to create context" & Environment.NewLine & "Error:  " & WildcatError(Err.LastDllError), MsgBoxStyle.Critical, "Unable to create context")
                ConnectToWINS = False
            End If
        Else
            MsgBox("Unable to connect to server" & Environment.NewLine & "Error:  " & WildcatError(Err.LastDllError), MsgBoxStyle.Critical, "Unable to connect")
            ConnectToWINS = False
        End If

        GetMakewild(myMW)

        BBSName = myMW.BBSName.Trim
        BBSReg = myMW.RegString.Trim
        BBSSysOpName = myMW.SysopName.Trim

    End Function

    Public Function ConnectToWINSUser(ByVal UserName As String, ByVal Password As String, Optional ByVal objStatus As Object = Nothing) As Boolean

        Dim myMW As New TMakewild
        Dim RetVal As Integer = 0
        Dim objUserInfo As New TUserInfo

        ConnectToWINSUser = True

        If objStatus Is Nothing Then
        Else
            CType(objStatus, System.Windows.Forms.Label).Text = "Finding WINS Server..."
            CType(objStatus, System.Windows.Forms.Label).Refresh()
        End If

        If WildcatServerConnectSpecific(0, BBSServerName) Then
            If objStatus Is Nothing Then
            Else
                CType(objStatus, System.Windows.Forms.Label).Text = "Creating Context..."
                CType(objStatus, System.Windows.Forms.Label).Refresh()
            End If
            If WildcatServerCreateContext() Then
                If objStatus Is Nothing Then
                Else
                    CType(objStatus, System.Windows.Forms.Label).Text = "Logging you in..."
                    CType(objStatus, System.Windows.Forms.Label).Refresh()
                End If
                If LookupName(UserName.Trim, objUserInfo) Then
                    If LoginUserEx(objUserInfo.ID, Password.Trim, 0, "Local", objUser) Then
                        SetNodeActivity("wcChat .NET")
                        mvarNodeID = GetNode()
                        GetNodeInfo(mvarNodeID, objNI)
                    Else
                        WildcatServerDeleteContext()
                        MsgBox("Error logging you into the WINServer system" & Environment.NewLine & "Error:  " & WildcatError(Err.LastDllError), MsgBoxStyle.Critical, "User login failed")
                        ConnectToWINSUser = False
                    End If
                Else
                    MsgBox("Error logging you into the WINServer system" & Environment.NewLine & "Error:  " & WildcatError(Err.LastDllError), MsgBoxStyle.Critical, "User login failed")
                    ConnectToWINSUser = False
                End If
                If objStatus Is Nothing Then
                Else
                    CType(objStatus, System.Windows.Forms.Label).Text = "Please Wait (continuing)..."
                    CType(objStatus, System.Windows.Forms.Label).Refresh()
                End If
            Else
                MsgBox("Unable to create context" & Environment.NewLine & "Error:  " & WildcatError(Err.LastDllError), MsgBoxStyle.Critical, "Unable to create context")
                ConnectToWINSUser = False
            End If
        Else
            MsgBox("Unable to connect to server" & Environment.NewLine & "Error:  " & WildcatError(Err.LastDllError), MsgBoxStyle.Critical, "Unable to connect")
            ConnectToWINSUser = False
        End If

        GetMakewild(myMW)

        BBSName = myMW.BBSName.Trim
        BBSReg = myMW.RegString.Trim
        BBSSysOpName = myMW.SysopName.Trim

    End Function

    Function WildcatError(ByRef DLLError As Integer) As String
        Select Case DLLError
            Case WC_STATUS_BASE
                WildcatError = "WINS (Base Error)"
            Case WC_UNSUPPORTED_VERSION
                WildcatError = "WINS (Unsupported Version)"
            Case WC_CONTEXT_NOT_INITIALIZED
                WildcatError = "WIN (Server Context not initialized)"
            Case WC_INVALID_NODE_NUMBER
                WildcatError = "WINS (Invalid Node Number)"
            Case WC_USER_NOT_FOUND
                WildcatError = "WINS (User was not found)"
            Case WC_INCORRECT_PASSWORD
                WildcatError = "WINS (Incorrect Password)"
            Case WC_USER_NOT_LOGGED_IN
                WildcatError = "WINS (User is not logged in)"
            Case WC_INVALID_INDEX
                WildcatError = "WINS (Invalid Index)"
            Case WC_INVALID_OBJECT_ID
                WildcatError = "WINS (Invalid Object ID)"
            Case WC_GROUP_ALREADY_EXISTS
                WildcatError = "WINS (Group Already Exists)"
            Case WC_GROUP_NOT_FOUND
                WildcatError = "WINS (Group Not Found)"
            Case WC_OBJECTID_ALREADY_EXISTS
                WildcatError = "WINS (ObjectID already Exists)"
            Case WC_NAME_NOT_FOUND
                WildcatError = "WINS (Name Not Found)"
            Case WC_NAME_ALREADY_EXISTS
                WildcatError = "WINS (Name Already exists)"
            Case WC_ALREADY_LOGGED_IN
                WildcatError = "WINS (Wildcat already logged in)"
            Case WC_ITEM_NOT_FOUND
                WildcatError = "WINS (Item Not Found)"
            Case WC_ITEM_REQUIRES_NAME
                WildcatError = "WINS (Item Requires a name)"
            Case WC_ITEM_ALREADY_EXISTS
                WildcatError = "WINS (Item Already Exists)"
            Case WC_ITEM_NAME_DIFFERENT
                WildcatError = "WINS (Item Name is Different)"
            Case WC_RECORD_NOT_FOUND
                WildcatError = "WINS (Record Not Found)"
            Case WC_ACCESS_DENIED
                WildcatError = "WINS (Access is DENIED)"
            Case WC_NODE_ALREADY_IN_USE
                WildcatError = "WINS (Node is already is use)"
            Case WC_USER_ALREADY_LOGGED_IN
                WildcatError = "WINS (Users already logged in)"
            Case WC_INVALID_CONNECTION_ID
                WildcatError = "WINS (Invalid Connection ID)"
            Case WC_INVALID_CONFERENCE
                WildcatError = "WINS (Invalid Conference)"
            Case WC_INVALID_CONFERENCEGROUP
                WildcatError = "WINS (Invalid Conference Group)"
            Case WC_INVALID_FILEAREA
                WildcatError = "WINS (Invalid File Area)"
            Case WC_INVALID_FILEGROUP
                WildcatError = "WINS (Invalid File Group)"
            Case WC_DUPLICATE_RECORD
                WildcatError = "WINS (Duplicate Record)"
            Case WC_NO_ACTION_TAKEN
                WildcatError = "WINS (No Action Taken)"
            Case WC_ACCOUNT_LOCKED_OUT
                WildcatError = "WINS (Account has been locked out)"
            Case WC_FILE_SEARCH_SYNTAX
                WildcatError = "WINS (File Search Sytax Error)"
            Case WC_REQUEST_NOT_ADDED
                WildcatError = "WINS (Request was not added)"
            Case WC_CONTEXT_MULTI_REFS
                WildcatError = "WINS (Mutlpile references - Context)"
            Case WC_CONTEXT_ALREADY_INITIALIZED
                WildcatError = "WINS (Context has already been initialized)"
            Case WC_NO_NODES_AVAILABLE
                WildcatError = "WINS (There are no nodes available)"
            Case Else
                WildcatError = "Application (Unspecified Error - " & DLLError.ToString.Trim & ") ---- " & ErrorToString(DLLError).Trim
        End Select
    End Function

End Module
