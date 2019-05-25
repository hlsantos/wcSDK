// File: M:\wc2000\wcchanmon.cpp

#include <stdio.h>
#include <afx.h>
#include <wctype.h>
#include <wcserver.h>
#include <conio.h>

#include <sstools.cpp>

#pragma comment(lib,"wcsrv2.lib")

const CHATMSG_TEXT      = 1;
const CHATMSG_ACTION    = 2;

/*
typedef struct _TChatMessage {
      char From[28];
      char Text[256];
      BOOL Whisper;
} TChatMessage;
*/

DWORD ChatChannel        = 0;
DWORD ChatControlChannel = 0;
DWORD SystemPageChannel  = 0;

BOOL Abort    = FALSE;
BOOL Busy     = FALSE;
BOOL zControlHandlerRoutine(DWORD dwCtrlType)
{
   switch (dwCtrlType) {
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

BOOL ChatMessage(const char *szMsg, DWORD dest = 0)
{
  TChatMessage cmsg;
  strcpy(cmsg.From,"Anonymous");
  strcpy(cmsg.Text,szMsg);
  cmsg.Whisper = FALSE;
  return WriteChannel(ChatChannel, dest, CHATMSG_TEXT, &cmsg, sizeof(cmsg));
}


DWORD CALLBACK DoCallback(DWORD userdata, const TChannelMessage *msg)
{
  if (msg->Channel == ChatChannel) {
    WriteLog("UserData: %d SenderId: %d  UserData: %d\n",userdata,msg->SenderId,msg->UserData);
    switch (msg->UserData) {
      case SP_SYSOP_CHAT:
          {
            TChatMessage *cmsg = (TChatMessage *)&msg->Data;
            printf("From: %s\n",cmsg->From);
            printf("[%s]\n",cmsg->Text);
            break;
          }
      default:
        break;
    }
    //Sleep(75);
  } else {
    WriteLog("UserData: %d  Channel: %d SenderId: %d  UserData: %d\n",userdata,msg->Channel, msg->SenderId,msg->UserData);
  }
  return 0;
}

void main(char argc, char *argv[])
{
  if (!WildcatServerConnect(NULL)) return;
  if (!WildcatServerCreateContext()) return;

  __try {
    SetConsoleCtrlHandler((PHANDLER_ROUTINE)&zControlHandlerRoutine,TRUE);

    WriteLog("Setting up Wildcat Callback\n");
    SetupWildcatCallback(DoCallback,0);

    WriteLog("Opening Chat Channel\n");
    char buf[80];
    DWORD dwChatChannel = 0;
    wsprintf(buf, "chat.%d",dwChatChannel);
    ChatChannel        = OpenChannel("chat.0");
    ChatControlChannel = OpenChannel("chat.control");
    SystemPageChannel  = OpenChannel("system.page");
    if (ChatChannel == 0) {
       WriteLog("Error %d OpenChannel(%s)\n",GetLastError(),buf);
       return;
    }
    while (!Abort) {
        if (kbhit()) {
            int ch = getch();
            if (ch == 27) break;
            if (ch == 'h') ChatMessage("Hello!");
            if (ch == 'H') ChatMessage("Hello!");
        }
        Sleep(75);
    }

  } __finally {
    RemoveWildcatCallback();
    WildcatServerDeleteContext();
    WriteLog("\nShutting Down. Done.\n\n");
  }

}

