Attribute VB_Name = "wcCallBackModule"
Option Explicit

Public PageChannelNumber As Long
Public SystemEventChannel As Long

Public Function WildcatCallBackFunc(ByVal userdata As Long, _
                             ByRef msg As TChannelMessage) _
                             As Long
                             
   Form1.List1.AddItem ("--- CallBack ---")
   
   '---------------------------------------------------
   ' this will force an error when running as an EXE
   ''Form1.List1.AddItem ("Channel: " + Str(msg.Channel))
   ''Exit Function
   '---------------------------------------------------
   
   Form1.List1.AddItem ("Channel: " & msg.Channel & _
                        "  SenderId: " & msg.SenderId & _
                        "  Signal: " & msg.userdata & _
                        "  DataSize: " & msg.datasize)
    
   If (msg.Channel = PageChannelNumber) Then
       Select Case msg.userdata
         Case 1:
           Dim page As TPageMessage
           If GetWildcatPageMessage(msg, page) Then
             Form1.List1.AddItem ("From: " & TrimNull(page.From))
             Form1.List1.AddItem ("Message: " & TrimNull(page.message(1)))
             Form1.List1.AddItem ("Message: " & TrimNull(page.message(2)))
             Form1.List1.AddItem ("Message: " & TrimNull(page.message(3)))
           Else
             Form1.List1.AddItem ("! Mismatch! Expected data size: " & LenB(page))
           End If
         Case 2:
       End Select
   End If
   
   If (msg.Channel = SystemEventChannel) Then
      Dim fevt As TSystemEventFileInfo
      Select Case msg.userdata
        Case SE_FILE_UPLOAD:
             Call GetWildcatSystemEventFileInfo(msg, fevt)
             Form1.List1.AddItem (TrimNull(fevt.szFileName) & " was uploaded")
        Case SE_FILE_DOWNLOAD:
             Call GetWildcatSystemEventFileInfo(msg, fevt)
             Form1.List1.AddItem (TrimNull(fevt.szFileName) & " was downloaded")
        Case SE_FILE_DELETE:
             Call GetWildcatSystemEventFileInfo(msg, fevt)
             Form1.List1.AddItem (TrimNull(fevt.szFileName) & " was deleted")
        Case SE_FILE_UPDATE:
             Call GetWildcatSystemEventFileInfo(msg, fevt)
             Form1.List1.AddItem (TrimNull(fevt.szFileName) & " was updated")
      End Select
   End If


End Function


