//////////////////////////////////////////////////////////////////////////////
//
// This is a sample that demonstrates the essentials of hooking up a front
// end to Wildcat.
//
// Note that the communications handle MUST be opened with the
// FILE_FLAG_OVERLAPPED flag, otherwise Wildcat won't be able to communicate.
// You also must stop any threads that may be waiting for input from the
// port, as this will also interfere with Wildcat.
//
// This program simply turns auto answer on, then waits for carrier to go
// high.  Since this program does not flush the receive buffer, there will
// be a bunch of junk in the buffer that Wildcat will process.  A real
// front end would read this data before handing off to Wildcat.
//
//////////////////////////////////////////////////////////////////////////////

#include <windows.h>
#include <stdio.h>
#pragma hdrstop

#include "wcfront.h"

int main(int, char *[])
{
  HANDLE comm = CreateFile("COM1", GENERIC_READ|GENERIC_WRITE, 0, NULL, OPEN_EXISTING, FILE_FLAG_OVERLAPPED, NULL);
  if (comm == INVALID_HANDLE_VALUE) {
    printf("could not open COM1\n");
    return 1;
  }
  wcFeSetStatus(2, "Test", RGB(0, 255, 255));
  EscapeCommFunction(comm, SETDTR);
  DWORD n;
  OVERLAPPED ov;
  ZeroMemory(&ov, sizeof(ov));
  WriteFile(comm, "ATS0=1\r", 7, &n, &ov);
  while (1) {
    Sleep(1000);
    DWORD m;
    GetCommModemStatus(comm, &m);
    if (m & MS_RLSD_ON) {
      break;
    }
  }
  TFrontEndInfo fei;
  ZeroMemory(&fei, sizeof(fei));
  fei.FrontEndPid = GetCurrentProcessId();
  fei.PortHandle = (DWORD)comm;
  fei.ConnectSpeed = 19200;
  fei.ReliableConnect = TRUE;
  fei.TimeLeft = 90;
  wcFeConnect(2, &fei);
  CloseHandle(comm);
  return 0;
}
