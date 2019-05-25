VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   6885
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   6225
   LinkTopic       =   "Form1"
   ScaleHeight     =   6885
   ScaleWidth      =   6225
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox Text2 
      Height          =   375
      Left            =   3120
      MaxLength       =   5
      TabIndex        =   10
      Text            =   "3"
      Top             =   1080
      Width           =   615
   End
   Begin VB.CommandButton btnListArea 
      Caption         =   "List Area"
      Height          =   375
      Left            =   1800
      TabIndex        =   9
      Top             =   1080
      Width           =   1215
   End
   Begin VB.TextBox Text1 
      Height          =   375
      Left            =   3120
      TabIndex        =   8
      Text            =   "autorun.zip"
      Top             =   600
      Width           =   2895
   End
   Begin VB.CommandButton btnFindFile 
      Caption         =   "Find File"
      Height          =   375
      Left            =   1800
      TabIndex        =   7
      Top             =   600
      Width           =   1215
   End
   Begin VB.CommandButton btnClearList 
      Caption         =   "Clear"
      Height          =   375
      Left            =   4800
      TabIndex        =   6
      Top             =   2040
      Width           =   1215
   End
   Begin VB.CommandButton btnShowFiles 
      Caption         =   "Show Files"
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
      Height          =   4050
      Left            =   120
      TabIndex        =   4
      Top             =   2520
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
      Caption         =   "Login"
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

Public Sub FBCGetFileRecords()
  Dim Fr As TFileRecord
  Dim tid As Long
  
  Dim FNext As Boolean
  FNext = GetFirstFileRec(FileAreaNameKey, Fr, tid)
  Do While FNext
    List1.AddItem (Str(Fr.area) + ": " + Fr.name)
    FNext = GetNextFileRec(FileAreaNameKey, Fr, tid)
  Loop

End Sub


Private Sub btnClearList_Click()
  List1.Clear
End Sub

Private Sub btnFindFile_Click()
  Dim fname As String
  fname = LCase(Text1.text)
  List1.AddItem ("Searching for " + fname)
  
  Dim Fr As TFileRecord
  Dim FullFr As TFullFileRecord
  Dim tid As Long
  Dim FNext As Boolean
  Dim i As Long
  Dim AreaNo As Integer
  
  AreaNo = 0
  FNext = SearchFileRecByNameArea(fname, AreaNo, Fr, tid)
  Do While FNext
    List1.AddItem (Str(Fr.area) + ": " + Fr.name)
    FNext = GetNextFileRec(FileNameAreaKey, Fr, tid)
    FNext = FNext And (LCase(Fr.name) = fname)
  Loop
   
End Sub

Private Sub btnListArea_Click()
  Dim AreaNo As Integer
  Dim Fr As TFileRecord
  Dim tid As Long
  Dim FNext As Boolean
  Dim fname As String
  
  tid = 0
  AreaNo = Val(Text2.text)
  fname = "*"
  List1.AddItem ("Listing files in file area: " + Str(AreaNo))
  
  FNext = SearchFileRecByAreaName(AreaNo, fname, Fr, tid)
  Dim err As Integer
  err = GetLastError
  List1.AddItem ("Last Error: " + Hex(err))
  
  Do While FNext
    List1.AddItem (Str(Fr.area) + ": [" + Trim(Fr.name) + "]")
    FNext = GetNextFileRec(FileAreaNameKey, Fr, tid) And (Fr.area = AreaNo)
  Loop
  
End Sub

Private Sub btnShowFiles_Click()
    Call FBCGetFileRecords
End Sub

Private Sub ConnectButton_Click()
 If WildcatServerConnect(0) = False Then
   MsgBox ("Error Finding Wildcat Server")
 Else
   List1.AddItem ("Connected")
   ConnectButton.Enabled = False
   CreateContextButton.Enabled = True
   LoginButton.Enabled = False
   btnShowFiles.Enabled = False
   DeleteContextButton.Enabled = False
 End If
End Sub

Private Sub CreateContextButton_Click()
  If WildcatServerCreateContext() = False Then
     MsgBox ("Error Creating Session context")
 Else
   List1.AddItem ("Session Created")
   CreateContextButton.Enabled = False
   LoginButton.Enabled = True
   DeleteContextButton.Enabled = True
  End If
End Sub

Private Sub DeleteContextButton_Click()
  If WildcatServerDeleteContext() <> False Then
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
   If LoginSystem() <> False Then
       List1.AddItem ("Logged In")
       btnShowFiles.Enabled = True
   End If
End Sub
