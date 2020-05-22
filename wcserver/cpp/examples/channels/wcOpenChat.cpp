// File: wcOpenChat.cpp

#include <stdio.h>
#include <windows.h>
#include <wctype.h>
#include <wcserver.h>
#include <wclinker.h>
#include <conio.h>

const int CHATMSG_TEXT      = 1;
const int CHATMSG_ACTION    = 2;

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
  sprintf(buf, format, args);
  printf(buf);
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
    sprintf(buf, "chat.%d",dwChatChannel);
    ChatChannel        = OpenChannel("chat.0");
    ChatControlChannel = OpenChannel("chat.control");
    SystemPageChannel  = OpenChannel("system.page");
    if (ChatChannel == 0) {
       WriteLog("Error %d OpenChannel(%s)\n",GetLastError(),buf);
       return;
    }
    while (!Abort) {
        if (_kbhit()) {
            int ch = _getch();
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

