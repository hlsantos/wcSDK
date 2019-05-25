// File: D:\wc5beta\wcWriteChannel.cpp

#include <stdio.h>
#include <afx.h>
#include <wctype.h>
#include <wcserver.h>
#include <conio.h>

#pragma comment(lib,"wcsrv2.lib")

//#define SYSTEM_WEB_EVENT_CHANNEL_NAME   "system.event.web"
#define SYSTEM_WEB_EVENT_CHANNEL_NAME   "system.config.web"


///////////////////////////////////////////////////////////////
// GetWildcatClientIdByName()

DWORD GetWildcatClientIdByName(const char *szProgamName)
{
    TConnectionInfo ci;
    ci.ConnectionId = 0;
    while (GetConnectionInfo(ci.ConnectionId+1, ci)) {
        if (stricmp(ci.ProgramName,szProgamName) == 0) {
            return ci.ConnectionId;
        }
    }
    return 0;
}

typedef struct _TMyChannelData {
    char s1[80];
    char s2[80];
} TMyChannelData;

void main(char argc, char *argv[])
{
  if (!WildcatServerConnect(NULL)) return;
  printf("1");getch();
  if (!WildcatServerCreateContext()) return;
  printf("2");getch();

  __try {
    if (!LoginSystem()) return;
    DWORD cid = GetWildcatClientIdByName("wconline.exe");
    DWORD ch  = OpenChannel(SYSTEM_WEB_EVENT_CHANNEL_NAME);
    printf("ch: %d cid: %d\n",ch,cid);
    TMyChannelData cd;
    ZeroMemory(&cd,sizeof(cd));
    strcpy(cd.s1,"Hi There!");
    strcpy(cd.s2,"Can you hear me now!");
    if (!WriteChannel(ch,0,1,&cd,sizeof(cd))) {
        printf("error %08X writechannel(%d,%d,,,,)\n",GetLastError(),ch,cid);
    }
    printf("4");getch();
  } __finally {
    WildcatServerDeleteContext();
    printf("5");getch();
  }

}
