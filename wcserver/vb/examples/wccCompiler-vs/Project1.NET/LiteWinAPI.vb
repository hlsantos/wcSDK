Option Strict Off
Option Explicit On
Module LiteWinAPI
	Declare Function GetModuleFileName Lib "kernel32"  Alias "GetModuleFileNameA"(ByVal hModule As Integer, ByVal lpFileName As String, ByVal nSize As Integer) As Integer
	Declare Function SetCurrentDirectory Lib "kernel32"  Alias "SetCurrentDirectoryA"(ByVal lpPathName As String) As Integer
	Declare Function GetCurrentDirectory Lib "kernel32"  Alias "GetCurrentDirectoryA"(ByVal nBufferLength As Integer, ByVal lpBuffer As String) As Integer
	Declare Function GetFullPathName Lib "kernel32"  Alias "GetFullPathNameA"(ByVal lpFileName As String, ByVal nBufferLength As Integer, ByVal lpBuffer As String, ByVal lpFilePart As String) As Integer
	
	Function GetDir() As String
		GetDir = ""
		Dim sz As New VB6.FixedLengthString(256)
		If GetCurrentDirectory(Len(sz.Value), sz.Value) > 0 Then
			GetDir = sz.Value
		End If
	End Function
	
	Function GetProgramPath() As String
		GetProgramPath = ""
		Dim sz As New VB6.FixedLengthString(256)
		If GetModuleFileName(0, sz.Value, Len(sz.Value)) > 0 Then
			GetProgramPath = sz.Value
		Else
			GetProgramPath = "ERROR"
		End If
	End Function
	
	Function SetDir(ByRef sp As String) As Boolean
		Dim r As Integer
		r = SetCurrentDirectory(sp)
		SetDir = r <> 0
	End Function
End Module