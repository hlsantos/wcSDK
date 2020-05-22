// File: wcWatchFileEvents.cpp

#include <stdio.h>
#include <windows.h>
#include <wctype.h>
#include <wcserver.h>
#include <wclinker.h>
#include <conio.h>

const DWORD SC_CHANNEL_CLOSE = WORD(-1);

typedef struct tagTChannel {
    DWORD Number;
    char  Name[80];
} TChannel;

DWORD TotalChannels = 0;
const DWORD MaxTotalChannels = 20;
TChannel Channels[MaxTotalChannels] = {0};
DWORD SystemEventChannel         = 0;
DWORD dwCid                      = 0;


BOOL Abort    = FALSE;
BOOL Busy     = FALSE;
BOOL zControlHandlerRoutine(DWORD dwCtrlType)
{
   switch(dwCtrlType) {
    case CTRL_C_EVENT:
    case CTRL_BREAK_EVENT:
    case CTRL_CLOSE_EVENT:
    case CTRL_LOGOFF_EVENT:
    case CTRL_SHUTDOWN_EVENT:
       Abort = TRUE;
       return TRUE;
       break;
    }
    return FALSE;
}

void WriteLog(const char *format, ...)
{
    va_list args;
    va_start(args, format);
    char buf[1024];
    sprintf(buf, format, args);
    printf(buf);
    va_end(args);
}

const char *GetChannelName(const DWORD number)
{
    for (DWORD i=0; i<TotalChannels;i++) {
        if (number == Channels[i].Number) {
            return Channels[i].Name;
        }
    }
    return "unknown";
}

void RawPrint(DWORD userdata, const TChannelMessage *msg)
{
  WriteLog("<%c> ud: %1d sid: %3d evt: %2d ds: %-4d (%d:%s)\n",
          (msg->SenderId == dwCid)?'=':' ',
          userdata,
          msg->SenderId,
          (short)msg->UserData,
          msg->DataSize,
          msg->Channel,
          GetChannelName(msg->Channel)
          );
}

DWORD CALLBACK DoCallback(DWORD userdata, const TChannelMessage *msg)
{
    RawPrint(userdata,msg);
    return 0;
}

DWORD AddChannel(const char *sz)
{
    if (TotalChannels+1 < MaxTotalChannels) {
        DWORD cn = ::OpenChannel(sz);
        if (cn > 0) {
            Channels[TotalChannels].Number = cn;
            strcpy(Channels[TotalChannels].Name,sz);
            TotalChannels++;
            WriteLog("+ Open Channel: %d [%s]\n",cn,sz);
            return cn;
        } else {
            printf("- Error %08X opening %s\n",GetLastError(),sz);
        }
    } else {
        printf("- Too Many Channels!");
    }
    return 0;
}

void main(char argc, char *argv[])
{
  if (!WildcatServerConnect(NULL)) return;
  if (!WildcatServerCreateContext()) return;


  SetConsoleCtrlHandler((PHANDLER_ROUTINE)&zControlHandlerRoutine,TRUE);
  __try {
    dwCid = GetConnectionId();
    printf("- Connection Id: %d\n",dwCid);
    char szServer[MAX_PATH] = "";
    if (GetConnectedServer(szServer, sizeof(szServer))) {
       printf("* Connected Server: %s\n",szServer);
    }
    if (!LoginSystem()) return;

    WriteLog("* Setting up Wildcat Callback\n");
    SetupWildcatCallback(DoCallback,0);

    SystemEventChannel         = AddChannel("system.event");

    printf("--- press escape to exit ---\n");
    while (!Abort) {
        if (_kbhit()) {
            int ch = _getch();
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

