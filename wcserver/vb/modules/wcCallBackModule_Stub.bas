Attribute VB_Name = "wcCallBackModule_Stub"
Option Explicit

Private Declare Sub CopyMemory Lib "kernel32" Alias "RtlMoveMemory" _
  (dst As Any, _
   src As Any, _
   ByVal bcount As Long)

Private Function TrimNull(item As String)
   Dim pos As Integer
   pos = InStr(item, Chr$(0))
   If pos Then
         TrimNull = Left$(item, pos - 1)
   Else: TrimNull = item
   End If
End Function

Public Function FARPROC(ByVal pfn As Long) As Long
  FARPROC = pfn
End Function

Public Function WildcatCallBackFunc(ByVal userdata As Long, _
                             ByRef msg As TChannelMessage) _
                             As Long

   ' .... add your channel code here ...

End Function


