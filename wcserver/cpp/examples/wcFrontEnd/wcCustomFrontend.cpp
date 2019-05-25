//***********************************************************************
// (c) Copyright 1998-2004 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : wcCustomFrontend.cpp
// Subsystem : Wildcat! RPC Frontend
// Date      : 02/21/2005
// Author    : HLS
//
// Example of Modem/Port Hosting using the Wildcat! RPC Frontend Framework
//
// This is a sample that demonstrates the essentials of hooking up a front
// end to Wildcat!
//
// To prepare a frontend node, enable the checkbox option "[X] Frontend"
// the each desired node in WCCONFIG | Modem Setup.
//
// Design Notes:
//
// Wildcat! Frontend allows developers to create their own hosting
// server that can hook into the Wildcat! virtual communication node
// system.
//
// Developer must properly prepare COMx devices with the following
// attributes:
//
// - port open with the FILE_FLAG_OVERLAPPED flag,
// - Hardware flow control
//
// If you have a thread listening on the port, it must be suspended
// before handing off the com port to the Wildcat!
//
// This program simply turns auto answer on, then waits for carrier to go
// high.  Since this program does not flush the receive buffer, there will
// be a bunch of junk in the buffer that Wildcat will process.  A real
// front end would read this data before handing off to Wildcat.
//
// Revision History:
// Ver  Build    Date      Author  Comments
// ---  -----    --------  ------  --------------------------------------
// 6.0  451.4    02/21/05  HLS     Example created
//***********************************************************************

#include <windows.h>
#include <stdio.h>
#include <conio.h>

#include "wcfront.h"
#include "wcserver.h"
#pragma comment(lib,"wcsrv2.lib")

void SetDtrLine(HANDLE comm, BOOL on)
{
  EscapeCommFunction(comm, on ? SETDTR : CLRDTR);
}

void SetRtsLine(HANDLE comm, BOOL on)
{
  EscapeCommFunction(comm, on ? SETRTS : CLRRTS);
}

//--------------------------------------------------------

void Help()
{
   printf("Usage: wcCustomFrontend </port:xxxx> [/baud:# /node:#]\n");
   printf("\n");
   printf("/port:xxxx   open device xxxx, i.e., COM1, COM2, etc.\n");
   printf("/baud:#      baud rate (default 57600)\n");
   printf("/node:#      use node #\n");
}

//--------------------------------------------------------
// main block
//--------------------------------------------------------

int DoMain(int argc, char *argv[])
{
   char szPort[80] = "";
   DWORD Node      = 0;
   DWORD Speed     = 57600;

   if (argc < 2) {
       Help();
       return 1;
   }

   for (int i=1; i < argc; i++) {
       if (!strnicmp(argv[i],"/port:com",9)) {
           sprintf(szPort,"\\\\.\\%s",argv[i]+6);
           continue;
       }
       if (!strnicmp(argv[i],"/baud:",6)) {
           Speed = atoi(argv[i]+6);
           continue;
       }
       if (!strnicmp(argv[i],"/node:",6)) {
           Node = atoi(argv[i]+6);
           continue;
       }
   }

   if (szPort[0] == 0) {
       printf("! port not defined\n");
       Help();
       return 1;
   }
   if (Speed == 0) {
       printf("! illegal speed\n");
       Help();
       return 1;
   }
   if (Node == 0) {
       printf("! illegal node\n");
       Help();
       return 1;
   }

   if (!wcFeIsAvailable()) {
       printf("! WcOnline Frontend Server Not Available\n");
       return 1;
   }

   printf("- Node: %d\n",Node);
   printf("- Opening Port %s\n",szPort);

   HANDLE hComm = CreateFile(szPort,
                            GENERIC_READ|GENERIC_WRITE,
                            0,
                            NULL,
                            OPEN_EXISTING,
                            FILE_FLAG_OVERLAPPED,
                            NULL);
   if (hComm == INVALID_HANDLE_VALUE) {
      printf("! Error %d : opening port %s\n",GetLastError(),szPort);
      return 1;
   }

   BOOL done = FALSE;
   while (!done) {
      printf("- initializing modem\n");
      //wcFeSetStatus(Node, "Initializing Modem", CLGREEN);
      
      SetDtrLine(hComm,TRUE);
      char *szString = "ATS0=1\r";
      DWORD n;
      OVERLAPPED ov;
      ZeroMemory(&ov, sizeof(ov));
      WriteFile(hComm, szString, strlen(szString), &n, &ov);

      printf("- waiting for call (press ESC to exit)\n");

      //wcFeSetStatus(Node, "Waiting For Call");
      while (1) {
        if (kbhit() && (getch() == 27)) {
          done = TRUE;
          break;
        }
        Sleep(1000);
        DWORD m;
        GetCommModemStatus(hComm, &m);
        if (m & MS_RLSD_ON) {
             if (!WildcatServerCreateContext()) {
                 printf("! Error %08X WildcatServerCreateContext()\n",GetLastError());
                 break;
             }

            __try {

              if (!AllocateNode(0, CALLTYPE_FRONTEND, "57600")) {
                  printf("! Error %08X AllocateNode()\n",GetLastError());
                  break;
              }

              DWORD dwNode = GetNode();

              wcFeSetStatus(dwNode, "Connecting...", CLYELLOW);
              printf("- Connection Established. Starting Session. Node: %d\n",dwNode);

              TFrontEndInfo fei;
              ZeroMemory(&fei, sizeof(fei));
              fei.FrontEndPid     = GetCurrentProcessId();
              fei.PortHandle      = (DWORD)hComm;
              fei.ConnectSpeed    = Speed;
              fei.ReliableConnect = TRUE;
              fei.TimeLeft        = 90;
              strcpy(fei.IEMSIInfo.software,"wcCustomFrontEnd");

              if (!wcFeIsAvailable()) {
                  printf("! WcOnline Frontend Server Not Available\n");
                  done = TRUE;
                  break;
              }

              if (!wcFeConnect(dwNode, &fei)) {
                  printf("! Error %d wcFeConnect() node: %d\n",GetLastError(),dwNode);
              }

              wcFeSetStatus(dwNode, "",0);
              printf("- Ending Session.\n");
              SetDtrLine(hComm,FALSE);
              Sleep(500);
              break;

            } __finally {
              WildcatServerDeleteContext();
            }
        }
      }
   }

   //wcFeSetStatus(Node, "",0);
   printf("- Closing Port\n");

   CloseHandle(hComm);

   return 0;
}


void main(char argc, char *argv[])
{
  if (!WildcatServerConnect(NULL)) return;
  DoMain(argc, argv);
}
