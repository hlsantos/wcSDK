//***********************************************************************
// (c) Copyright 1998-2010 Santronics Software, Inc. All Rights Reserved.
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
//***********************************************************************



// File: wcSetServerState.cpp

#include <stdio.h>
#include <afx.h>
#include <conio.h>
#include <wcserver.h>
#include <wcversion.h>

#pragma comment(lib,"wcsrv2.lib")


CString GetStateStr(const DWORD dwState)
{
    char sz[20] = "";
    strcpy(sz,"?");
    switch (dwState) {
      case SERVERSTATE_OFFLINE: strcpy(sz,"OFFLINE"); break; // = 0; // remove server from list
      case SERVERSTATE_DOWN   : strcpy(sz,"DOWN   "); break; // = 1; // red
      case SERVERSTATE_REFUSE : strcpy(sz,"REFUSE "); break; // = 2; // yellow
      case SERVERSTATE_UP     : strcpy(sz,"UP     "); break; // = 3; // green
    }
    return sz;
}


///////////////////////////////////////////////////////////////////////////
//! Server State Functions
///////////////////////////////////////////////////////////////////////////

//BOOL  APIENTRY SetServerState(const char *port, DWORD state);
//BOOL  APIENTRY GetServerState(DWORD index, TServerState &ss);
//BOOL  APIENTRY SetNodeServerState(DWORD node, DWORD state);


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

// don't do this if szService does not exist
//    if (!SetServerState(szService,iState)) {
//       printf("! error %08X = SetServerState(\"%s\",%d) state=%s\n",szService,iState,GetStateStr(iState));
//       return;
//    }
//    ShowWildcatHostServers();
//    return;
//

    //printf("* server: %s | service: %s | state: %s (%d)\n",szServer?szServer:"NULL", szService, szState, iState);

    DWORD SystemControlServerChannel = OpenChannel("System.Control.Server");

    int index = 0;

    TServerState ss;

#if 0
    printf("Cid# State   Computer Port\n");
    printf("---- ------- -------- -----------------\n");
#endif

    while(GetServerState(index++, ss)) {
       if (szServer && stricmp(szServer,ss.Computer)) continue;
       if (stricmp(szService, ss.Port)) continue;

#if 0
        printf("%-4d %-7s %-8s %-8s | %d\n",
                ss.OwnerId,
                GetStateStr(ss.State),
                ss.Computer,
                ss.Port,
                stricmp(szService, ss.Port)
             );
#endif

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

   cprintf("wcServerState %s %s\n",WC_VERSION,WC_COPYRIGHT_LONG);

   if (argc < 3) {
      help();
      return 1;
   }

   char *szService = argv[1];
   char *szState   = argv[2];
   char *szServer  = (argc>2)?argv[3]:NULL;

   int  iState    = -1;

   if (!stricmp(szState,"offline")) iState = SERVERSTATE_OFFLINE;
   if (!stricmp(szState,"refuse"))  iState = SERVERSTATE_REFUSE;
   if (!stricmp(szState,"down"))    iState = SERVERSTATE_DOWN;
   if (!stricmp(szState,"up"))      iState = SERVERSTATE_UP;

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
