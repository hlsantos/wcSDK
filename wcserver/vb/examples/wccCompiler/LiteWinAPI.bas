Attribute VB_Name = "LiteWinAPI"
Declare Function GetModuleFileName Lib "kernel32" Alias "GetModuleFileNameA" (ByVal hModule As Long, ByVal lpFileName As String, ByVal nSize As Long) As Long
Declare Function SetCurrentDirectory Lib "kernel32" Alias "SetCurrentDirectoryA" (ByVal lpPathName As String) As Long
Declare Function GetCurrentDirectory Lib "kernel32" Alias "GetCurrentDirectoryA" (ByVal nBufferLength As Long, ByVal lpBuffer As String) As Long
Declare Function GetFullPathName Lib "kernel32" Alias "GetFullPathNameA" (ByVal lpFileName As String, ByVal nBufferLength As Long, ByVal lpBuffer As String, ByVal lpFilePart As String) As Long

Function GetDir() As String
  GetDir = ""
  Dim sz As String * 256
  If GetCurrentDirectory(Len(sz), sz) > 0 Then
    GetDir = sz
  End If
End Function
Function GetProgramPath() As String
  GetProgramPath = ""
  Dim sz As String * 256
  If GetModuleFileName(0, sz, Len(sz)) > 0 Then
    GetProgramPath = sz
  Else
    GetProgramPath = "ERROR"
  End If
End Function

Function SetDir(sp As String) As Boolean
  Dim r As Long
  r = SetCurrentDirectory(sp)
  SetDir = r <> 0
End Function
