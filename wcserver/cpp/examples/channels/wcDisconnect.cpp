// File: wcDisconnect.cpp

#include <stdio.h>
//#include <afx.h>
#include <windows.h>
#include <wcserver.h>
#include <wcLinker.h>

#pragma comment(lib,"wcsrv.lib")

BOOL SendControlEvent(DWORD node, DWORD event)
{
    char buf[30];
    sprintf(buf, "System.Control.%d", node);
    DWORD ch = OpenChannel(buf);
    if (!WriteChannel(ch, 0, event, "", 0)) {
        printf("Error %08X Opening %s\n",GetLastError(), buf);
    }
    CloseChannel(ch);
    return TRUE;
}

void main(char argc, char *argv[])
{
  if (argc < 2) {
      printf("wcDisconnect node#\n");
      return;
  }


  if (!WildcatServerConnect(NULL)) {
      printf("! connect error %08X\n",GetLastError());
      return;
  }
  if (!WildcatServerCreateContext()) {
      printf("! create context error %08X\n",GetLastError());
      return;
  }

  DWORD node = atoi(argv[1]);

  __try {
    //if (!LoginSystem()) {
    //   printf("! loginsystem error %08X\n",GetLastError());
    //   return;
    //}
    if (SendControlEvent(node,SC_DISCONNECT)) {
        printf("disconnect signal sent to node %d\n",node);
    } else {
        printf("! error %08X sending disconnect signal to node %d\n",GetLastError(), node);
    }
  } __finally {
    WildcatServerDeleteContext();
  }

}
