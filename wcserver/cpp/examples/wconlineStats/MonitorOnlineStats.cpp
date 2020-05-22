//***********************************************************************
// (c) Copyright 1998-2008 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : MonitorOnlineStats.cpp
// Subsystem : WcOnline
// Date      : 10/16/2008
// Version   : 6.3.452.6
// Author    : HLS/SSI
//
// Example of how to read

// 1) the current Wildcat! Server statistics,
//
// 2) the local machine registry to obtain the WcOnline
//    Online Statistics
//
// And display the difference of the statistics every X heart beat
// seconds.
//
// Revision History:
// Build    Date      Author  Comments
// -----    --------  ------  -------------------------------------------
//***********************************************************************

#include <stdio.h>
#include <windows.h>
#include <conio.h>
#include <wctype.h>
#include <wcserver.h>
#include <wclinker.h>

#pragma comment(lib,"advapi32.lib")

#define ESCAPE               27
#define HEARTBEAT_SECS       5

//!
//! The structure TOnlineStats represents the registry
//! REG_BINARY data stored by WCONLINE to record the
//! server TWildcatServerInfo statistics "since" some
//! past point in time.
//!

typedef struct tagTOnlineStats {
  SYSTEMTIME since;
  TWildcatServerInfo wcsi;
} TOnlineStats;


//!
//! Utility function to read REG_BINARY data from the
//! registry.
//!

BOOL GetRegBinary(HKEY hkey,
                  const char *rkey,
                  const char *name,
                  void *data,
                  DWORD datasize)
{
  BOOL ok = FALSE;
  HKEY k;
  LONG ret = RegOpenKeyEx(hkey, rkey, 0, KEY_READ, &k);
  if (ret == ERROR_SUCCESS) {
    DWORD t;
    ret = RegQueryValueEx(k, (char *)name, NULL, &t,
                          (BYTE *)data, &datasize);
    if (ret == ERROR_SUCCESS) ok = t == REG_BINARY;
    RegCloseKey(k);
  }
  return ok;
}

//!
//! ReadOnlineStats() will return the current online
//! statistics since it was last recorded
//!

BOOL ReadOnlineStats(TOnlineStats &wos)
{
   //----------------------------------------------------
   // Then read the last recorded Online stats from
   // the registry
   //----------------------------------------------------

   HKEY hKey    = HKEY_CURRENT_USER;
   char szrKey[MAX_PATH] = "Software\\SSI\\Wildcat\\Wconline\\Servers\\";

   // add connected Wildcat! Server computer name to rkey

   char szServer[80] = {0};
   GetConnectedServer(szServer,sizeof(szServer));

   strcat(szrKey, szServer);

   ZeroMemory(&wos,sizeof(wos));

   if (!GetRegBinary(hKey, szrKey, "OnlineStats",&wos,sizeof(wos))) {
      int err = GetLastError();
      printf("! ERROR %d - GetRegBinary()\n",err);
      return FALSE;
   }
   return TRUE;
}

//!
//! DIFFZERO macro return the difference of two data points,
//! returns 0 for negative differences
//!

#define DIFFZERO(x) (wcsi.x >= wos.wcsi.x)?(wcsi.x-wos.wcsi.x):0

//!
//! ShowOnlineStats() does the actual work
//!

BOOL ShowOnlineStats()
{

   //----------------------------------------------------
   // First Get Online Statistics
   //----------------------------------------------------

   TOnlineStats wos = {0};
   if (!ReadOnlineStats(wos)) {
       return FALSE;
   }

   int dwTicks = GetTickCount();
   while (1) {
      int n = HEARTBEAT_SECS*2;
      int ch = 0;
      while(n > 0) {
        n--;
        Sleep(500);
        if (_kbhit()) {
           ch = _getch();
           break;
        }
      }
      if (ch == ESCAPE) break;

      //----------------------------------------------------
      // Get TWildcatServerInfo stats
      //----------------------------------------------------

      TWildcatServerInfo wcsi;
      if (!GetWildcatServerInfo(wcsi)) {
         int err = GetLastError();
         printf("! ERROR %08X - GetWildcatServerInfo()\n",err);
         return FALSE;
      }

      //----------------------------------------------------
      // Display the results, taken the difference from
      // the current server stats from the last recorded
      // stats in the registry.
      //----------------------------------------------------

      printf("%6d since: %04d-%02d-%02d %02d:%02d:%02d ",
                        (GetTickCount()-dwTicks)/1000,
                        wos.since.wYear,
                        wos.since.wMonth,
                        wos.since.wDay,
                        wos.since.wHour,
                        wos.since.wMinute,
                        wos.since.wSecond);

      printf(" C: %-6d ", DIFFZERO(TotalCalls));
      printf(" U: %-5d ", DIFFZERO(TotalUsers));
      printf(" M: %6d", DIFFZERO(TotalMessages));
      printf(" F: %-6d", DIFFZERO(TotalFiles));
      printf("\r");
   }
   printf("\n\n");

   return TRUE;
}

//!
//! main block, connect to wildcat! server, create
//! context and call ShowStats()
//!

void main(char argc, char *argv[])
{
  if (!WildcatServerConnect(NULL)) return;
  if (!WildcatServerCreateContext()) return;

  ShowOnlineStats();

  WildcatServerDeleteContext();
}


