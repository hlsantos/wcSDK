//***********************************************************************
// (c) Copyright 1998-2020 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : wcSetServerState.cpp
// Subsystem :
// Date      : 11/24/10 02:30 pm
// Version   :
// Author    :
// About     :
//
// Revision History:
// Build    Date      Author  Comments
// -----    --------  ------  -------------------------------------------
// 453.5R1  11/24/10  HLS
// 454.10   05/22/20  HLS     - Updated and cleaned for wcSDK
//***********************************************************************

#include <stdio.h>
#include <windows.h>
#include <wctype.h>
#include <wcserver.h>
#include <wclinker.h>
#include <wcversion.h>
#include <conio.h>


#define STATE_OFFLINE   "OFFLINE"
#define STATE_DOWN      "DOWN"
#define STATE_REFUSE    "REFUSE"
#define STATE_UP        "UP"
#define STATE_UNKNOWN   "?"

const char *GetStateStr(const DWORD dwState)
{
    switch (dwState) {
      case SERVERSTATE_OFFLINE: return STATE_OFFLINE; // = 0; // remove server from list
      case SERVERSTATE_DOWN   : return STATE_DOWN;    // = 1; // red
      case SERVERSTATE_REFUSE : return STATE_REFUSE;  // = 2; // yellow
      case SERVERSTATE_UP     : return STATE_UP;      // = 3; // green
    }
    return STATE_UNKNOWN;
}


void ShowWildcatHostServers()
{
    DWORD index = 0;
    TServerState ss = {0};
    printf("Cid# State   Computer         Port\n");
    printf("---- ------- ---------------- -----------------\n");
    while(GetServerState(index++, ss)) {
       printf("%-4d %-7s %-16s %s\n",
          ss.OwnerId,
          GetStateStr(ss.State),
          ss.Computer,
          ss.Port);
    }
}

void doMain(const char *szServer, const char *szService, const char *szState, const int iState)
{

    char szConnectedServer[256]={0};
    GetConnectedServer(szConnectedServer, sizeof(szConnectedServer)-1);
    printf("\n");
    printf("- Connected Server: %s\n",szConnectedServer);

    DWORD SystemControlServerChannel = OpenChannel("System.Control.Server");

    int index = 0;

    TServerState ss;

    while(GetServerState(index++, ss)) {
       if (szServer && _stricmp(szServer,ss.Computer)) continue;
       if (_stricmp(szService, ss.Port)) continue;
       WriteChannel(SystemControlServerChannel,ss.OwnerId,iState,ss.Port,strlen(ss.Port)+1);
       break;
    }

    printf("\n");

    Sleep(250);
    ShowWildcatHostServers();
}

void help()
{
   printf("usage: wcSetServerState <service> <state> [server]\n\n");
   printf("service ->  HTTP, FTP, SMTP, NNTP, POP3, RADIUS, TELNET\n");
   printf("state   ->  OFFLINE, REFUSE, DOWN, UP\n");
}

int main(char argc, char *argv[])
{

   _cprintf("wcServerState %s %s\n",WC_VERSION,WC_COPYRIGHT_LONG);

   if (argc < 3) {
      help();
      return 1;
   }

   char *szService = argv[1];
   char *szState   = argv[2];
   char *szServer  = (argc>2)?argv[3]:NULL;

   int  iState    = -1;

   if (!_stricmp(szState,"offline")) iState = SERVERSTATE_OFFLINE;
   if (!_stricmp(szState,"refuse"))  iState = SERVERSTATE_REFUSE;
   if (!_stricmp(szState,"down"))    iState = SERVERSTATE_DOWN;
   if (!_stricmp(szState,"up"))      iState = SERVERSTATE_UP;

   if (iState == -1) {
      help();
      return 1;
   }

   if (!WildcatServerConnectSpecific(NULL,szServer?szServer:"")) return 1;
   if (!WildcatServerCreateContext()) return 1;

   __try {
     if (!LoginSystem()) return 1;
     doMain(szServer, szService, szState, iState);
   } __finally {
     WildcatServerDeleteContext();
   }

   return 0;
}
