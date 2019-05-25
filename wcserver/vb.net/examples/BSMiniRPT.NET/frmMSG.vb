Option Strict On
Option Explicit On

Imports wcSDK.wcServerAPI

Friend Class frmMSG

    Inherits System.Windows.Forms.Form

    Private mvarMSGID As Integer
    Private mvarConference As Integer
    Private mvarEnumType As MsgWindowType

    Private boolCheckValidNames As Boolean

    Public Enum MsgWindowType
        ENUM_NEWMESSAGE = 0
        ENUM_REPLYMESSAGE = 1
        ENUM_EDITMESSAGE = 2
        ENUM_FORWARDMESSAGE = 3
        ENUM_VIEWONLY = 4
    End Enum

    Public Property MsgID() As Integer
        Get
            MsgID = mvarMSGID
        End Get
        Set(ByVal value As Integer)
            mvarMSGID = value
        End Set
    End Property

    Public Property Conference() As Integer
        Get
            Conference = mvarConference
        End Get
        Set(ByVal value As Integer)
            mvarConference = value
        End Set
    End Property

    Public Property MessageType() As MsgWindowType
        Get
            MessageType = mvarEnumType
        End Get
        Set(ByVal value As MsgWindowType)
            mvarEnumType = value
        End Set
    End Property

    Private Function LoadMessageView() As Short

        Try
            Dim wMSG As New TMsgHeader

            If GetMessageById(mvarConference, mvarMSGID, wMSG) Then
                txtMsgTo.Text = wMSG.MsgTo.name.Trim
                txtMsgFrom.Text = wMSG.MsgFrom.Name.Trim
                txtMsgSubject.Text = wMSG.Subject.Trim
                txtMSGBody.Text = GetText("wc:\conf(" & mvarConference.ToString.Trim & ")\message(" & mvarMSGID.ToString.Trim & ")").Trim
                txtMSGBody.Text = txtMSGBody.Text.Replace(vbLf, Environment.NewLine)
                If wMSG.IsPrivate <> 0 Then ToolStripStatusLabel1.Enabled = True
                If wMSG.ReceiptRequested <> 0 Then ToolStripStatusLabel2.Enabled = True
                If wMSG.Received <> 0 Then ToolStripStatusLabel3.Enabled = True
                If mvarEnumType = MsgWindowType.ENUM_VIEWONLY Then
                    picMTools.Visible = False
                    txtMSGBody.Height = stbMsg.Top - txtMSGBody.Top - 5
                End If
            Else
                MsgBox("Error accessing the specified message", MsgBoxStyle.Information, "WINS Error...")
                Me.Dispose()
            End If
        Catch ex As Exception
            MsgBox("Unexpected Error occurred" & Environment.NewLine & "Error:  " & ex.ToString & Environment.NewLine & "Message:  " & ex.Message, MsgBoxStyle.Critical, "Unexpected Error")
            Me.Dispose()
        End Try

    End Function

    Public Function PrepForMessage() As Short

        Try
            Dim wMSG As New TMsgHeader
            Dim wCONF As New TConfDesc

            If GetConfDesc(mvarConference, wCONF) Then
                If wCONF.AllowReturnReceipt <> 0 Then chkRR.Enabled = True
                If wCONF.ValidateNames <> 0 Then boolCheckValidNames = True
                Select Case wCONF.MailType
                    Case mtNormalPublicPrivate, mtNormalPrivate, mtEmailOnly
                        chkPVT.Enabled = True
                    Case Else
                        chkPVT.Enabled = False
                End Select
            End If

            If mvarMSGID = -1 Then
                txtMsgFrom.Text = BBSSysopName
            Else
                picMTools.Visible = True
                Select Case mvarEnumType
                    Case MsgWindowType.ENUM_EDITMESSAGE
                        '//Editing Message
                    Case MsgWindowType.ENUM_FORWARDMESSAGE
                        '//Forwarded Message
                    Case MsgWindowType.ENUM_NEWMESSAGE
                        '//New Message
                    Case MsgWindowType.ENUM_REPLYMESSAGE
                        '//Reply Message
                    Case MsgWindowType.ENUM_VIEWONLY
                        '//Read Only View
                        picMTools.Visible = False
                        LoadMessageView()
                End Select
            End If
        Catch ex As Exception
            MsgBox("Unexpected Error occurred" & Environment.NewLine & "Error:  " & ex.ToString & Environment.NewLine & "Message:  " & ex.Message, MsgBoxStyle.Critical, "Unexpected Error")
        End Try

    End Function

End Class