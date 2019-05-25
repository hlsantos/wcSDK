VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Wildcat! Basic Connection Example"
   ClientHeight    =   4620
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   6225
   LinkTopic       =   "Form1"
   ScaleHeight     =   4620
   ScaleWidth      =   6225
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton btnClearList 
      Caption         =   "Clear"
      Height          =   375
      Left            =   4800
      TabIndex        =   6
      Top             =   1560
      Width           =   1215
   End
   Begin VB.CommandButton btnShowFiles 
      Caption         =   "File Areas"
      Height          =   375
      Left            =   1800
      TabIndex        =   5
      Top             =   120
      Width           =   1215
   End
   Begin VB.ListBox List1 
      BeginProperty Font 
         Name            =   "Courier New"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   2370
      Left            =   120
      TabIndex        =   4
      Top             =   2040
      Width           =   5895
   End
   Begin VB.CommandButton DeleteContextButton 
      Caption         =   "Delete Context"
      Height          =   375
      Left            =   120
      TabIndex        =   3
      Top             =   1560
      Width           =   1455
   End
   Begin VB.CommandButton LoginButton 
      Caption         =   "MwLogin"
      Height          =   375
      Left            =   120
      TabIndex        =   2
      Top             =   1080
      Width           =   1455
   End
   Begin VB.CommandButton CreateContextButton 
      Caption         =   "Create Context"
      Height          =   375
      Left            =   120
      TabIndex        =   1
      Top             =   600
      Width           =   1455
   End
   Begin VB.CommandButton ConnectButton 
      Caption         =   "Server Connect"
      Height          =   375
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   1455
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public wcerr As Integer

Public Sub ShowFileAreas()
  Dim fa As TWildcatServerPrivateFileArea
  Dim i As Integer
  For i = 1 To GetFileAreaCount()
     If MwGetFileAreas(i, 1, fa) And (fa.public.number > 0) Then
        List1.AddItem (Str(fa.public.number) + ": [" + Trim(fa.public.name) + "] Path: " + Trim(fa.Path))
     End If
  Next
 
End Sub


Private Sub btnClearList_Click()
  List1.Clear
End Sub


Private Sub btnShowFiles_Click()
    Call ShowFileAreas
End Sub

Private Sub ConnectButton_Click()
 If WildcatServerConnect(0) Then
   List1.AddItem ("Connected")
   ConnectButton.Enabled = False
   CreateContextButton.Enabled = True
   LoginButton.Enabled = False
   btnShowFiles.Enabled = False
   DeleteContextButton.Enabled = False
   List1.AddItem ("connected string: [" + GetConnectedServer() + "]")
 Else
   MsgBox ("Error Finding Wildcat Server")
 End If
End Sub

Private Sub CreateContextButton_Click()
  If WildcatServerCreateContext() Then
     List1.AddItem ("Session Created")
     CreateContextButton.Enabled = False
     LoginButton.Enabled = True
     DeleteContextButton.Enabled = True
  Else
     MsgBox ("Error Creating Session context")
  End If
End Sub

Private Sub DeleteContextButton_Click()
  If WildcatServerDeleteContext() Then
   CreateContextButton.Enabled = True
   LoginButton.Enabled = False
   DeleteContextButton.Enabled = False
   btnShowFiles.Enabled = False
   List1.AddItem ("Session Deleted")
  End If
End Sub

Private Sub Form_Load()
   ConnectButton.Enabled = True
   CreateContextButton.Enabled = False
   DeleteContextButton.Enabled = False
   btnShowFiles.Enabled = False
   LoginButton.Enabled = False
End Sub

Private Sub Form_Unload(Cancel As Integer)
 wcerr = WildcatServerDeleteContext()
End Sub

Private Sub LoginButton_Click()
   If MwLogin("") <> False Then
       List1.AddItem ("Logged In")
       btnShowFiles.Enabled = True
       LoginButton.Enabled = False
   End If
End Sub
