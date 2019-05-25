//***********************************************************************
// (c) Copyright 1998-2008 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : DorTst32.cpp
// Subsystem : Wildcat! DOOR32
// Date      : 03/06/2008
// Version   : 452.5
// Author    : HLS
// About     :
//
// This is a sample which shows how to use the 32-bit door interface
// (DOOR32.DLL).
//
// Basically you just call DoorInitialize to start up, and
// DoorShutdown to clean up.  Writing to the port is done with
// DoorWrite, no translation of any kind is done, just raw output.
// DoorRead will read characters from the input buffer.  It just
// returns with no characters read if there isn't anything to read
// (it does not block).
//
// The DOOR32.DLL also hooks you up in the user's context in the
// Wildcat! server, so you can call Wildcat server API functions.
// The example here gets the user name.
//
// NOTE:
//
// The files wcDOOR32.DLL/LIB/H replaces DOOR32.DLL/LIB/H files.
// We are using door32.dll and door32.h here to show/test how the
// compatibility door32.lib will reference the new wcdoor32.dll.
//
//***********************************************************************
// Revision History:
// Build    Date      Author  Comments
// -----    --------  ------  -------------------------------------------
// 454.8    05/23/19  HLS     WCSDK v8.0 ready
//***********************************************************************

#define _CRT_SECURE_NO_WARNINGS

#include <windows.h>
#include <stdio.h>
#pragma hdrstop

#include "door32.h"
#include "wcserver.h"

#pragma comment(lib,"door32.lib")
#pragma comment(lib,"wcsrv2.lib")

void Wprintf(const char *s, ...)
{
  va_list args;
  va_start(args, s);
  char buf[256];
  vsprintf(buf, s, args);
  va_end(args);
  DoorWrite((BYTE *)buf, strlen(buf));
}

int main(int, char *[])
{

  if (!DoorInitialize()) {
    printf("Could not initialize door\n\n");
    printf("This program must be run as a 32-bit door from Wildcat.\n");
    Sleep(5000);
    return 0;
  }

  TUser User;
  WildcatLoggedIn(&User);
  Wprintf("Welcome to DOOR32 Test, %s.\r\n\r\n", User.Info.Name);
  Wprintf("Press a key or ESCAPE to quit:\r\n");

  BOOL done = FALSE;
  while (!done) {

    DWORD msTimeout = 1000; // INFINITE
    switch (DoorEvent(msTimeout)) {

      case WCDOOR_EVENT_KEYBOARD:
           BYTE c;
           DoorRead(&c, 1);
           if (c == 27) done = TRUE;
           Wprintf("%c", c);
           if (c==13) Wprintf("\r");
           break;

      case WCDOOR_EVENT_OFFLINE:
           done = TRUE;
           break;

      case WCDOOR_EVENT_FAILED:
           done = TRUE;
           break;

      case WCDOOR_EVENT_TIMEOUT:
           // should never happen when using
           // INFINITE for the DoorEvent() timeout
           Wprintf("*");
           break;

   }
  }
  Wprintf("\r\n\r\nReturning to bbs...\r\n");
  DoorShutdown();
  return 0;
}
