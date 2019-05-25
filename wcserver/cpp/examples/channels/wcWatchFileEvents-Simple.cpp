// File: V:\wc5beta\wcWatchFileEvents.cpp

#include <stdio.h>
#include <afx.h>
#include <wctype.h>
#include <wcserver.h>
#include <conio.h>

#pragma comment(lib,"wcsrv2.lib")

void WriteLog(const char *format, ...)
{
    va_list args;
    va_start(args, format);
    char buf[1024];
    wvsprintf(buf, format, args);
    printf(buf);
    va_end(args);
}

const char *GetEventName(const TChannelMessage *msg)
{
   switch (msg->UserData) {
     case SE_FILE_UPLOAD:    return "SE_FILE_UPLOAD";
     case SE_FILE_DOWNLOAD:  return "SE_FILE_DOWNLOAD";
     case SE_FILE_DELETE:    return "SE_FILE_DELETE";
     case SE_FILE_UPDATE:    return "SE_FILE_UPDATE";
   }
   return "?";
}

void ProcessFileRecord(const TChannelMessage *msg)
{

   // get event file info

   TSystemEventFileInfo *fe = (TSystemEventFileInfo *)(msg->Data);

   WriteLog("%-15s | area: %4d | %s\n",
              GetEventName(msg),
              fe->FileArea,
              fe->szFileName);

   // Get File Record
   // - won't be there if SE_FILE_DELETE

   TFullFileRecord ff;
   DWORD tid = 0;
   if (GetFileRecByAreaName(fe->FileArea,fe->szFileName,ff.Info,tid)) {
       if (GetFullFileRec(ff.Info, ff)) {
          //
          // Do something with File Record
          //
       }
   }
}

DWORD SystemEventChannel  = 0;  // channel we are watching
DWORD CALLBACK DoCallback(DWORD userdata, const TChannelMessage *msg)
{
    if (msg->Channel == SystemEventChannel) {
        switch (msg->UserData) {
        case SE_FILE_UPLOAD:
        case SE_FILE_DOWNLOAD:
        case SE_FILE_DELETE:
        case SE_FILE_UPDATE:
           ProcessFileRecord(msg);
           break;
       }
    }
    return 0;
}

void main(char argc, char *argv[])
{
  if (!WildcatServerConnect(NULL)) return;
  if (!WildcatServerCreateContext()) return;

  __try {

    if (!LoginSystem()) return;
    WriteLog("* Setting up Wildcat Callback\n");

    SetupWildcatCallback(DoCallback,0);
    SystemEventChannel = OpenChannel("system.event");

    printf("--- press escape to exit ---\n");
    while (1) {
        if (kbhit()) {
            int ch = getch();
            if (ch == 27) break;
        }
        Sleep(13);
    }

  } __finally {
    RemoveWildcatCallback();
    WildcatServerDeleteContext();
    WriteLog("\nShutting Down. Done.\n\n");
  }

}

