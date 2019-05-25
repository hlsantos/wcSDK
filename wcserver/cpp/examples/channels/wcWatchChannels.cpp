// File: D:\wc5beta\wcWatchChannels.cpp

#include <stdio.h>
#include <afx.h>
#include <wctype.h>
#include <wcserver.h>
#include <conio.h>

#pragma comment(lib,"wcsrv2.lib")


const DWORD SC_CHANNEL_CLOSE = WORD(-1);

typedef struct tagTChannel {
    DWORD Number;
    char  Name[80];
} TChannel;

DWORD TotalChannels = 0;
const DWORD MaxTotalChannels = 20;
TChannel Channels[MaxTotalChannels] = {0};


DWORD SystemControlChannel       = 0;
DWORD SystemControlServerChannel = 0;
DWORD SystemEventChannel         = 0;
DWORD SystemPageChannel          = 0;

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
    wvsprintf(buf, format, args);
    printf(buf);
    //OutputDebugString(buf);
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

const CString GetEventName(const TChannelMessage *msg)
{
    CString s;
    if ((short)msg->UserData == SC_CHANNEL_CLOSE) {
        s = "SC_CHANNEL_CLOSE";
    } else {
        s.Format("%2d",(short)msg->UserData);
    }

    //return s;

    if (msg->Channel == SystemControlChannel) {
        switch (msg->UserData) {
        case SC_WATCH_REQUEST:      return "SC_WATCH_REQUEST";
        case SC_DISCONNECT:         return "SC_DISCONNECT";
        case SC_CHANNEL_CLOSE:      return "SC_CHANNEL_CLOSE";
        }
    }

    if (msg->Channel == SystemControlServerChannel) {
        switch (msg->UserData) {
        case SC_WATCH_REQUEST:         return "SC_WATCH_REQUEST";
        case SC_DISPLAY_UPDATE:        return "SC_DISPLAY_UPDATE";
        case SC_PUSH_KEY:              return "SC_PUSH_KEY";
        case SC_DISCONNECT:            return "SC_DISCONNECT";
        case SC_SECURITY_CHANGE:       return "SC_SECURITY_CHANGE";
        case SC_USER_RECORD_CHANGE:    return "SC_USER_RECORD_CHANGE";
        case SC_CHANNEL_CLOSE:      return "SC_CHANNEL_CLOSE";
        }
    }

    if (msg->Channel == SystemEventChannel) {
        switch (msg->UserData) {
        case SE_FILE_UPLOAD:            return "SE_FILE_UPLOAD";
        case SE_FILE_DOWNLOAD:          return "SE_FILE_DOWNLOAD";
        case SE_FILE_DELETE:            return "SE_FILE_DELETE";
        case SE_FILE_UPDATE:            return "SE_FILE_UPDATE";
        case SE_SHUTDOWN_REQUEST:       return "SE_SHUTDOWN_REQUEST";
        case SE_RESTART:                return "SE_RESTART";
        case SE_CONFIG_CHANGE:          return "SE_CONFIG_CHANGE";
        case SE_POPCONNECT:             return "SE_POPCONNECT";
        case SE_SERVER_STATE_CHANGE:    return "SE_SERVER_STATE_CHANGE";
        case SE_NODE_STATE_CHANGE:      return "SE_NODE_STATE_CHANGE";
        case SE_MAILSERVER_UPDATE:      return "SE_MAILSERVER_UPDATE";
        case SC_CHANNEL_CLOSE:          return "SC_CHANNEL_CLOSE";
       }
    }

    if (msg->Channel == SystemPageChannel) {
        switch (msg->UserData) {
        case SP_USER_PAGE:              return "SP_USER_PAGE";
        case SP_SYSOP_CHAT:             return "SP_SYSOP_CHAT";
        case SP_NEW_MESSAGE:            return "SP_NEW_MESSAGE";
        case SC_CHANNEL_CLOSE:          return "SC_CHANNEL_CLOSE";
        }
    }
    return s;
}

const CString GetSenderName(const DWORD cid)
{
    CString s;

#if 1 // use this for now, showing programname causes screen wrap
    s.Format("%3d",cid);
#else
    TConnectionInfo ci;
    if (GetConnectionInfo(cid,ci)) {
        s.Format("%s",ci.ProgramName);
    } else {
        s.Format("%3d",cid);
    }
#endif
    return s;
}

// NOTE:
//
// EUREKA! Wcsrv2.dll wire handler will fault if the callback
// faults! We need to be able to prepare the wire handler
// to decide how to handle fault, auto-continue or abort
// as determined by the client.

void InfoPrint(DWORD userdata, const TChannelMessage *msg)
{
   SYSTEMTIME st;
   GetSystemTime(&st);
   SystemTimeToTzSpecificLocalTime(NULL,&st,&st);
   WriteLog("%02d:%02d:%02d|%s|%02d:%-25s %02d:%s\n",
          st.wHour,st.wMinute,st.wSecond,
          GetSenderName(msg->SenderId),
          //msg->DataSize,
          msg->Channel,
          GetChannelName(msg->Channel),
          (short)msg->UserData,
          GetEventName(msg)
          );
}

DWORD CALLBACK DoCallback(DWORD userdata, const TChannelMessage *msg)
{
    RawPrint(userdata,msg);
    InfoPrint(userdata,msg);
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

    SystemControlChannel       = AddChannel("system.control");
    SystemControlServerChannel = AddChannel("system.control.server");
    SystemEventChannel         = AddChannel("system.event");
    SystemPageChannel          = AddChannel("system.page");

    printf("--- press escape to exit ---\n");
    while (!Abort) {
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

