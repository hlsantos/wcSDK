// File: SimpleWatchChannels.cpp

#include <stdio.h>
#include <windows.h>
#include <wcserver.h>
#include <conio.h>

#pragma comment(lib,"wcsrv2.lib")

DWORD SystemControlChannel       = 0;
DWORD SystemEventChannel         = 0;
DWORD SystemPageChannel          = 0;

DWORD CALLBACK ChannelCallback(DWORD cbData, const TChannelMessage *msg)
{
    if (msg->Channel == SystemControlChannel) {
      printf("Control: SenderId: %d  Signal: %d",
             msg->SenderId,msg->UserData);
    }


    if (msg->Channel == SystemEventChannel) {
      printf("Event: SenderId: %d  Signal: %d",
             msg->SenderId,msg->UserData);
    }

    if (msg->Channel == SystemPageChannel) {
      printf("Page: SenderId: %d  Signal: %d",
             msg->SenderId,msg->UserData);
    }

    return 0;
}

void main(char argc, char *argv[])
{
  if (!WildcatServerConnect(NULL)) return;
  if (!WildcatServerCreateContext()) return;

  __try {
    if (!LoginSystem()) return;

    printf("* Setting up Wildcat Callback\n");
    SetupWildcatCallback(ChannelCallback,0);

    SystemControlChannel       = OpenChannel("system.control");
    SystemEventChannel         = OpenChannel("system.event");
    SystemPageChannel          = OpenChannel("system.page");

    printf("--- press escape to exit ---\n");
    while (1) {
        if (_kbhit()) {
            int ch = _getch();
            if (ch == 27) break;
        }
        Sleep(13);
    }
  } __finally {
    RemoveWildcatCallback();
    WildcatServerDeleteContext();
    printf("\nShutting Down. Done.\n\n");
  }

}

