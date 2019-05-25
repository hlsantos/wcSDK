Attribute VB_Name = "wcCallBackModuleLib"
Option Explicit

'------------------------------------------------------------------
' VB Helper functions for Wildcat! CallBack system
'-------------------------------------------------------------------

Private Declare Sub CopyMemory Lib "kernel32" Alias "RtlMoveMemory" _
  (dst As Any, _
   src As Any, _
   ByVal bcount As Long)

Public Function TrimNull(item As String)
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

Public Function GetWildcatPageMessage( _
        msg As TChannelMessage, _
        pmsg As TPageMessage _
        ) As Boolean

   GetWildcatPageMessage = False
   If Len(pmsg) = msg.datasize Then
      CopyMemory pmsg, msg.data(1), msg.datasize
      GetWildcatPageMessage = True
   End If

End Function


Public Function GetWildcatChatMessage( _
        msg As TChannelMessage, _
        cmsg As TChatMessage _
        ) As Boolean

   GetWildcatChatMessage = False
   If Len(cmsg) = msg.datasize Then
      CopyMemory cmsg, msg.data(1), msg.datasize
      GetWildcatChatMessage = True
   End If

End Function

Public Function GetWildcatSystemEventFileInfo( _
            msg As TChannelMessage, _
            sfi As TSystemEventFileInfo) As Boolean

   GetWildcatSystemEventFileInfo = False
   If Len(sfi) = msg.datasize Then
      CopyMemory sfi, msg.data(1), msg.datasize
      GetWildcatSystemEventFileInfo = True
   End If

End Function

