Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class mainform
	Inherits System.Windows.Forms.Form
	'UPGRADE_NOTE: Filter was upgraded to Filter_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Public Function GetFilename(ByVal Caption As String, ByVal Filter_Renamed As String) As String
		Dim fname As String
		
		pickFileOpen.Title = Caption
		'UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		pickFileOpen.Filter = Filter_Renamed
		pickFileOpen.ShowDialog()
		fname = pickFileOpen.FileName
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
			srcName = My.Application.Info.DirectoryPath & "\" & srcName
		End If
		GetSourceFileName = srcName
	End Function
	
	Function GetObjectFileName(ByRef srcName As String) As String
		'
		' prepare the object (wcx) output file name
		'
		Dim objName As String
		Dim dot As Short
		
		objName = srcName
		dot = InStr(srcName, ".")
		If dot > 0 Then objName = VB.Left(srcName, dot - 1)
		objName = objName & ".wcx"
		GetObjectFileName = objName
	End Function
	
	Function GetCompilerOptions() As Integer
		Dim Options As Integer
		
		Options = Options + WCC_OUTPUT_WCX
		If (cbMapFile.CheckState = 1) Then Options = Options + WCC_OUTPUT_MAP + WCC_OUTPUT_OPCODE
		If (cbRptFile.CheckState = 1) Then Options = Options + WCC_OUTPUT_REPORT
		
		GetCompilerOptions = Options
	End Function
	
	Function GetCompilerDefines() As String
		Dim s As String
		s = ""
		If (cbDebug.CheckState = 1) Then s = "DEBUG"
		GetCompilerDefines = s
	End Function
	
	Function StartCompile(ByRef objAddress As Integer) As Boolean
		StartCompile = False
		
		Dim sc As Integer
		'UPGRADE_WARNING: Arrays in structure st may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim st As TScriptCompilerStatus
		Dim ei As TScriptCompilerError
		Dim srcName As String
		Dim objName As String
		Dim Options As Integer
		Dim Defines As String
		
		Options = GetCompilerOptions()
		Defines = GetCompilerDefines()
		srcName = GetSourceFileName()
		objName = GetObjectFileName(srcName)
		
		List1.Items.Add(("WCC: " & srcName))
		List1.Items.Add(("WCX: " & objName))
		
		sc = wccInit(st, 0, "", srcName, objName, Options)
		If (sc = 0) Then
			MsgBox("Error")
			Exit Function
		End If
		
		If Defines <> "" Then
			If wccSetDefines(sc, Defines) = 0 Then
			End If
		End If
		
		List1.Items.Clear()
		LabelTotalLines.Text = ""
		
		Dim nlines As Short
		Dim LastFile As String
		nlines = 0
		LastFile = ""
		While (wccProcess(sc, st) <> 0)
			nlines = nlines + 1
			If (nlines > 15) Then
				nlines = 0
				'UPGRADE_WARNING: Couldn't resolve default property of object TrimNull(st.status). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If TrimNull(st.status) <> LabelStatus.Text Then
					'UPGRADE_WARNING: Couldn't resolve default property of object TrimNull(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					LabelStatus.Text = TrimNull(st.status)
					LabelStatus.Refresh()
				End If
				LabelTotalLines.Text = Str(st.TotalLines)
				LabelTotalLines.Refresh()
			End If
			'UPGRADE_WARNING: Couldn't resolve default property of object TrimNull(st.CurrentFile). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If (LastFile <> TrimNull(st.CurrentFile)) Then
				'UPGRADE_WARNING: Couldn't resolve default property of object TrimNull(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LastFile = TrimNull(st.CurrentFile)
				List1.Items.Add((LastFile & " (" & Str(st.CurrentLine) & ")"))
				List1.Refresh()
			End If
		End While
		
		If (st.ErrorNumber = errNone) Then
			If st.CurrentLine = 0 Then
				List1.Items.Add(("NO LINES COMPILED!"))
			Else
				List1.Items.Add(("- WCX Created: " & objName))
				List1.Items.Add(("* Successful Compile"))
				LabelTotalLines.Text = Str(st.TotalLines)
				LabelStatus.Text = ""
			End If
			StartCompile = True
			If (objAddress <> 0) Then
				If wccFindError(sc, ei, objAddress) <> 0 Then
					List1.Items.Add(("FindError: 0x" & HexStr(objAddress, 4)))
					'UPGRADE_WARNING: Couldn't resolve default property of object TrimNull(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					List1.Items.Add(("ei.Filename   : " + TrimNull(ei.Filename)))
					List1.Items.Add(("ei.LineNumber : " & Str(ei.LineNumber)))
					List1.Refresh()
				Else
					MsgBox("Error Location Not Found")
				End If
			End If
		Else
			If (wccGetError(sc, ei) <> 0) Then
				StartCompile = False
				'UPGRADE_WARNING: Couldn't resolve default property of object TrimNull(ei.String). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				List1.Items.Add(("! Error " & Str(st.ErrorNumber) & " : " + TrimNull(ei.String_Renamed)))
				'UPGRADE_WARNING: Couldn't resolve default property of object TrimNull(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				List1.Items.Add(("! " + TrimNull(ei.Filename) + " Line: " + Str(ei.LineNumber)))
			End If
		End If
		
		wccDone(sc)
		
	End Function
	
	Private Sub btnClear_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnClear.Click
		List1.Items.Clear()
	End Sub
	
	Private Sub btnFindError_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnFindError.Click
		Dim ErrorNo As String
		ErrorNo = InputBox("Enter Error Code (HEX) Value", "Find Error")
		If ErrorNo <> "" Then
			StartCompile(Val("&H" & ErrorNo))
		End If
	End Sub
	
	Private Sub btnPickWCC_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnPickWCC.Click
		Dim wccfn As String
		wccfn = GetFilename("Select WCC File", "wcBASIC Files (*.wcc) | *.wcc")
		If (wccfn <> "") Then
			If (VB.Left(LCase(wccfn), Len(My.Application.Info.DirectoryPath)) = LCase(My.Application.Info.DirectoryPath)) Then
				wccfn = Mid(wccfn, Len(My.Application.Info.DirectoryPath) + 2)
			End If
			textMainFile.Text = wccfn
		End If
	End Sub
	
	Private Sub CommandCompile_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CommandCompile.Click
		StartCompile(0)
	End Sub
	
	Private Sub mainform_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		'File1.Path = "d:\wc5beta"
		'File1.Pattern = "*.wcc"
		'List1.AddItem ("Form_Load()")
		
		textMainFile.Text = "smtpfilter-example1.wcc"
		LabelStatus.Text = ""
		LabelTotalLines.Text = ""
		List1.Items.Clear()
		
	End Sub
End Class