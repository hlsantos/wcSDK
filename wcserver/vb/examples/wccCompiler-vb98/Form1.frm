VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "comdlg32.ocx"
Begin VB.Form mainform 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "wccCompiler"
   ClientHeight    =   6285
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   7905
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   6285
   ScaleWidth      =   7905
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  'Windows Default
   Begin MSComDlg.CommonDialog pickFile 
      Left            =   4920
      Top             =   240
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.CommandButton btnFindError 
      Caption         =   "Find Error"
      Height          =   375
      Left            =   1440
      TabIndex        =   13
      Top             =   1080
      Width           =   1095
   End
   Begin VB.CheckBox cbRptFile 
      Caption         =   "Create RPT file"
      Height          =   255
      Left            =   5880
      TabIndex        =   10
      Top             =   960
      Width           =   1695
   End
   Begin VB.CheckBox cbMapFile 
      Caption         =   "Create MAP file"
      Height          =   255
      Left            =   5880
      TabIndex        =   9
      Top             =   720
      Width           =   1695
   End
   Begin VB.CommandButton btnPickWCC 
      Caption         =   "..."
      Height          =   255
      Left            =   3360
      TabIndex        =   8
      Top             =   480
      Width           =   375
   End
   Begin VB.CommandButton btnClear 
      Caption         =   "Clear"
      Height          =   375
      Left            =   6480
      TabIndex        =   7
      Top             =   2280
      Width           =   1335
   End
   Begin VB.ListBox List1 
      Height          =   3375
      Left            =   120
      TabIndex        =   6
      Top             =   2760
      Width           =   7695
   End
   Begin VB.CommandButton CommandCompile 
      Caption         =   "Compile"
      Height          =   375
      Left            =   120
      TabIndex        =   2
      Top             =   1080
      Width           =   1095
   End
   Begin VB.TextBox textMainFile 
      Height          =   285
      Left            =   120
      TabIndex        =   1
      Text            =   "ListUsers.wcc"
      Top             =   480
      Width           =   3135
   End
   Begin VB.Frame Frame1 
      Caption         =   "Compiler Options"
      Height          =   1215
      Left            =   5760
      TabIndex        =   11
      Top             =   360
      Width           =   2055
      Begin VB.CheckBox cbDebug 
         Caption         =   "Debug Compile"
         Height          =   255
         Left            =   120
         TabIndex        =   12
         Top             =   840
         Width           =   1575
      End
   End
   Begin VB.Label Label2 
      Caption         =   "Total Lines:"
      Height          =   255
      Left            =   120
      TabIndex        =   5
      Top             =   2400
      Width           =   855
   End
   Begin VB.Label LabelTotalLines 
      Caption         =   "LabelTotalLines"
      Height          =   255
      Left            =   1080
      TabIndex        =   4
      Top             =   2400
      Width           =   1095
   End
   Begin VB.Label LabelStatus 
      BackColor       =   &H80000018&
      Caption         =   "LabelStatus"
      Height          =   255
      Left            =   120
      TabIndex        =   3
      Top             =   1800
      Width           =   7695
   End
   Begin VB.Label Label1 
      Caption         =   "Mail Compile File"
      Height          =   255
      Left            =   120
      TabIndex        =   0
      Top             =   240
      Width           =   1935
   End
End
Attribute VB_Name = "mainform"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public Function GetFilename(ByVal Caption As String, ByVal Filter As String) As String
  Dim fname As String

  pickFile.DialogTitle = Caption
  pickFile.Filter = Filter
  pickFile.ShowOpen
  fname = pickFile.Filename
  If RTrim(fname) = "" Then
    GetFilename = ""
  Else
    GetFilename = fname
  End If
End Function


Function GetSourceFileName() As String
  '
  ' Make sure the source has a path. If no path,
  ' then use the application path
  '
  Dim srcName As String
  srcName = textMainFile.Text
  If (InStr(srcName, "\") = 0) Then
      srcName = App.Path + "\" + srcName
  End If
  GetSourceFileName = srcName
End Function

Function GetObjectFileName(srcName As String) As String
  '
  ' prepare the object (wcx) output file name
  '
  Dim objName As String
  Dim dot As Integer
  
  objName = srcName
  dot = InStr(srcName, ".")
  If dot > 0 Then objName = Left(srcName, dot - 1)
  objName = objName + ".wcx"
  GetObjectFileName = objName
End Function

Function GetCompilerOptions() As Long
  Dim Options As Long
  
  Options = Options + WCC_OUTPUT_WCX
  If (cbMapFile.Value = 1) Then Options = Options + WCC_OUTPUT_MAP + WCC_OUTPUT_OPCODE
  If (cbRptFile.Value = 1) Then Options = Options + WCC_OUTPUT_REPORT
  
  GetCompilerOptions = Options
End Function

Function GetCompilerDefines() As String
  Dim s As String
  s = ""
  If (cbDebug.Value = 1) Then s = "DEBUG"
  GetCompilerDefines = s
End Function

Function StartCompile(objAddress As Long) As Boolean
  StartCompile = False
  
  Dim sc As Long
  Dim st As TScriptCompilerStatus
  Dim ei As TScriptCompilerError
  Dim srcName As String
  Dim objName As String
  Dim Options As Long
  Dim Defines As String
  
  Options = GetCompilerOptions()
  Defines = GetCompilerDefines()
  srcName = GetSourceFileName()
  objName = GetObjectFileName(srcName)
  
  List1.AddItem ("WCC: " + srcName)
  List1.AddItem ("WCX: " + objName)
  
  sc = wccInit(st, 0, "", srcName, objName, Options)
  If (sc = 0) Then
     MsgBox ("Error")
     Exit Function
  End If
  
  If Defines <> "" Then
     If wccSetDefines(sc, Defines) = 0 Then
     End If
  End If
  
  List1.Clear
  LabelTotalLines.Caption = ""
  
  Dim nlines As Integer
  Dim LastFile As String
  nlines = 0
  LastFile = ""
  While (wccProcess(sc, st) <> 0)
     nlines = nlines + 1
     If (nlines > 15) Then
        nlines = 0
        If TrimNull(st.status) <> LabelStatus.Caption Then
            LabelStatus.Caption = TrimNull(st.status)
            LabelStatus.Refresh
        End If
        LabelTotalLines.Caption = Str(st.TotalLines)
        LabelTotalLines.Refresh
     End If
     If (LastFile <> TrimNull(st.CurrentFile)) Then
        LastFile = TrimNull(st.CurrentFile)
        List1.AddItem (LastFile + " (" + Str(st.CurrentLine) + ")")
        List1.Refresh
     End If
  Wend

  If (st.ErrorNumber = errNone) Then
     If st.CurrentLine = 0 Then
        List1.AddItem ("NO LINES COMPILED!")
     Else
        List1.AddItem ("- WCX Created: " + objName)
        List1.AddItem ("* Successful Compile")
        LabelTotalLines.Caption = Str(st.TotalLines)
        LabelStatus.Caption = ""
     End If
     StartCompile = True
     If (objAddress <> 0) Then
        If wccFindError(sc, ei, objAddress) <> 0 Then
            List1.AddItem ("FindError: 0x" + HexStr(objAddress, 4))
            List1.AddItem ("ei.Filename   : " + TrimNull(ei.Filename))
            List1.AddItem ("ei.LineNumber : " + Str(ei.LineNumber))
            List1.Refresh
        Else
            MsgBox ("Error Location Not Found")
        End If
     End If
  Else
     If (wccGetError(sc, ei) <> 0) Then
        StartCompile = False
        List1.AddItem ("! Error " + Str(st.ErrorNumber) + " : " + TrimNull(ei.String))
        List1.AddItem ("! " + TrimNull(ei.Filename) + " Line: " + Str(ei.LineNumber))
     End If
  End If
  
  wccDone (sc)

End Function

Private Sub btnClear_Click()
  List1.Clear
End Sub

Private Sub btnFindError_Click()
  Dim ErrorNo As String
  ErrorNo = InputBox("Enter Error Code (HEX) Value", "Find Error")
  If ErrorNo <> "" Then
    StartCompile (Val("&H" & ErrorNo))
  End If
End Sub

Private Sub btnPickWCC_Click()
  Dim wccfn As String
  wccfn = GetFilename("Select WCC File", "wcBASIC Files (*.wcc) | *.wcc")
  If (wccfn <> "") Then
      If (Left(LCase(wccfn), Len(App.Path)) = LCase(App.Path)) Then
          wccfn = Mid(wccfn, Len(App.Path) + 2)
      End If
      textMainFile.Text = wccfn
  End If
End Sub

Private Sub CommandCompile_Click()
  StartCompile (0)
End Sub

Private Sub Form_Load()
 
  'File1.Path = "d:\wc5beta"
  'File1.Pattern = "*.wcc"
  'List1.AddItem ("Form_Load()")
  
  textMainFile.Text = "smtpfilter-example1.wcc"
  LabelStatus.Caption = ""
  LabelTotalLines.Caption = ""
  List1.Clear
  
End Sub

