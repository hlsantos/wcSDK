//***********************************************************************
// (c) Copyright 1998-2008 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : echoserv.cpp
// Subsystem : Wildcat! Registered Service
// Version   : 1.1
// Author    : SSI
//
//***********************************************************************


#define WINVER 0x500
#define _CRT_SECURE_NO_WARNINGS

#include <windows.h>
#include <winsock.h>
#include <conio.h>

#include <process.h>
#include <stdio.h>

#include "wcserver.h"
#pragma hdrstop

#pragma comment(lib, "wsock32.lib")
#pragma comment(lib, "wcsrv2.lib")

BOOL     Abort          = FALSE;
SOCKET   serviceSock    = 0;

BOOL zControlHandlerRoutine(DWORD dwCtrlType)
{
   switch (dwCtrlType) {
    case CTRL_C_EVENT:
    case CTRL_BREAK_EVENT:
    case CTRL_CLOSE_EVENT:
    case CTRL_LOGOFF_EVENT:
    case CTRL_SHUTDOWN_EVENT:
       Abort = TRUE;
       SOCKET s = InterlockedExchange((long *)&serviceSock, 0);
       if (s) closesocket(s);
       return TRUE;
       break;
    }
    return FALSE;
}


//  Receive and process all incoming requests on a single socket.
//  Respond by uppercasing all inbound data and returning to
//  the client.

void EchoHandler(void *p)
{
  SOCKET s = (SOCKET)p;
  while (1) {
    char buf[1024] = {0};
    int n = recv(s, buf, sizeof(buf), 0);
    if (n <= 0) {
      break;
    }
    for (int i = 0; i < n; i++) {
      buf[i] = toupper(buf[i]);
    }
    printf("%s", buf);
    send(s, buf, n, 0);
  }
  closesocket(s);
}

//--------------------------------------------------------
// MAIN
//--------------------------------------------------------

int main(int, char *[])
{

  //
  // Connect to the default wildcat server and
  // create a context.
  //

  if (!WildcatServerConnect(NULL)) return 1;
  if (!WildcatServerCreateContext()) return 1;

  //
  // Prepare a control-c, break, window close handler to allow
  // for a graceful exit from the socket listen loop
  //

  SetConsoleCtrlHandler((PHANDLER_ROUTINE)&zControlHandlerRoutine,TRUE);

  //
  // Initialize and load WinSock
  //

  WSAData wsaData;
  WSAStartup(MAKEWORD(1, 1), &wsaData);

  //
  // Create the service Socket
  //

  serviceSock = socket(AF_INET, SOCK_STREAM, 0);
  sockaddr_in sin;
  sin.sin_family = PF_INET;
  sin.sin_addr.s_addr = INADDR_ANY;
  sin.sin_port = 0;
  bind(serviceSock, (sockaddr *)&sin, sizeof(sin));
  int n = sizeof(sin);
  getsockname(serviceSock, (sockaddr *)&sin, &n);

  //
  // Register service with Wildcat! passing it the
  // port for the socket.
  //

  TWildcatService service  = {0};
  strcpy(service.Name,     "Echo");
  strcpy(service.Vendor,   "Santronics Software, Inc.");
  service.Version = 1;
  service.Port = ntohs(sin.sin_port);
  RegisterService(service);

  //
  // Listen for incoming requests
  //

  _cprintf("* Echo service active on %s/%d\n",
              inet_ntoa(*(struct in_addr *)&service.Address),
              ntohs(sin.sin_port));

  _cprintf("* Press ^C to break\n");

  listen(serviceSock, 5);
  while (!Abort) {
     sockaddr_in tin;
     int n = sizeof(tin);
     SOCKET t = accept(serviceSock, (sockaddr *)&tin, &n);
     if (t == 0 || t == INVALID_SOCKET) continue;
     _cprintf("\n==NEW THREAD==\n");
     _beginthread(EchoHandler, 0, (void *)t);
  }

  //
  // Delete the Wildcat! context otherwise you will hear a
  // beep at the Wildcat! Server for non-graceful exits
  //

  WildcatServerDeleteContext();

  _cprintf("* Exiting\n");
  Sleep(1000); // just to show window if running from IDE

  return 0;
}
