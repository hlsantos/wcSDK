// File: M:\wc2000\wcchanmon.cpp

#include <stdio.h>
#include <afx.h>
#include <wctype.h>
#include <wcserver.h>
#include <conio.h>

#pragma comment(lib,"wcsrv2.lib")

DWORD SystemPageChannel = 0;

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

CString FormatFileTime(const FILETIME &ft)
{
    char szDate[30] = "";
    strcpy(szDate,"n/a");
    if (ft.dwHighDateTime != 0) {
        SYSTEMTIME st;
        FileTimeToSystemTime(&ft,&st);
        wsprintf(szDate,"%02d/%02d/%04d %02d:%02d:%02d",
                   st.wMonth,
                   st.wDay,
                   st.wYear,
                   st.wHour,
                   st.wMinute,
                   st.wSecond);
    }
    return szDate;
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

BOOL fCheckMail    = FALSE;


DWORD CALLBACK DoCallback(DWORD userdata, const TChannelMessage *msg)
{
  WriteLog("ud: %d ch: %d sid: %d mud: %d datasize: %d\n",
          userdata,
          msg->Channel,
          msg->SenderId,
          msg->UserData,
          msg->DataSize);

  fCheckMail = msg->UserData == SP_NEW_MESSAGE;
  return 0;
}

BOOL doit(const char *name, const char *pwd)
{

    TUser user;
    if (!LookupName(name,user.Info)) {
        printf("user not found: %s\n",name);
        return FALSE;
    }

    if (!LoginUserEx(user.Info.Id,pwd,CALLTYPE_LOCAL,"console", user)) {
        printf("login error %d user: %s\n",GetLastError(),name);
        return FALSE;
    }

    printf("* User logged in: %s\n",name);
    return TRUE;

}

BOOL GetMail()
{
    DWORD dwTotal  = 0;
    DWORD dwUnRead = 0;
    DWORD dwRead = 0;
    DWORD dwPop3 = 0;

    DWORD dwConf = GetFirstConferenceUnread();

    while (dwConf != -1) {
        DWORD dwMid = GetFirstUnread(dwConf);
        printf("* Conf: %d  First Direct Mail Chain Id: %d\n",dwConf,dwMid);
        while (dwMid) {
            TMsgHeader msg;
            if (!GetMessageById(dwConf,dwMid,msg)) {
                break;
            }

            dwTotal++;

            if (msg.Received) {
                dwRead++;
            } else {
                dwUnRead++;
                if (dwConf == 0) dwPop3++;
            }
            printf("#%-5d id: %9d mf: %08X rd: %d %-19s\n",
                     msg.Number,
                     msg.Id,
                     msg.MailFlags,
                     msg.Received,
                     FormatFileTime(msg.ReadTime));

            if (msg.NextUnread && (msg.Id >= msg.NextUnread)) break;

            dwMid = msg.NextUnread;

        }
        dwConf = GetNextConferenceUnread(dwConf);
    }

    printf("\n");

    printf("Total mail chain: %d ",dwTotal);
    printf("total read      : %d ",dwRead);
    printf("total unread    : %d\n",dwUnRead);
    printf("\n")
    ;
    return TRUE;
}

void main(char argc, char *argv[])
{
  if (!WildcatServerConnect(NULL)) return;
  if (!WildcatServerCreateContext()) return;

  __try {


    SetConsoleCtrlHandler((PHANDLER_ROUTINE)&zControlHandlerRoutine,TRUE);

//    if (!doit("hector santos", "doggiedog")) {
    if (!doit("test user1", "test")) {
        return;
    }

    WriteLog("Setting up Wildcat Callback\n");
    SetupWildcatCallback(DoCallback,0);

    WriteLog("Opening System Page Channel\n");
    SystemPageChannel = OpenChannel("system.page");

    while (!Abort) {
        if (kbhit()) {
            int ch = getch();
            if (ch == 27) break;
        }
        if (fCheckMail) {
            fCheckMail = FALSE;
            GetMail();
        }
        Sleep(75);
    }

  } __finally {
    RemoveWildcatCallback();
    WildcatServerDeleteContext();
    WriteLog("\nShutting Down. Done.\n\n");
  }

}

