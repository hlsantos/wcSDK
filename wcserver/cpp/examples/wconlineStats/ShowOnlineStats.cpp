//***********************************************************************
// (c) Copyright 1998-2008 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : ShowOnlineStats.cpp
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
// And display the difference of the statistics.
//
// Revision History:
// Build    Date      Author  Comments
// -----    --------  ------  -------------------------------------------
//***********************************************************************

#include <stdio.h>
#include <afx.h>
#include <wctype.h>
#include <wcserver.h>

#pragma comment(lib,"wcsrv2.lib")
#pragma comment(lib,"advapi32.lib")

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
   // First read the last recorded Online stats from
   // the registry
   //----------------------------------------------------

   HKEY hKey    = HKEY_CURRENT_USER;
   CString rKey = "Software\\SSI\\Wildcat\\Wconline\\Servers\\";

   // add connected Wildcat! Server computer name to rkey

   char szConnectedServer[80] = {0};
   GetConnectedServer(szConnectedServer,sizeof(szConnectedServer));
   rKey += szConnectedServer;

   TOnlineStats wos = {0};
   if (!GetRegBinary(hKey, rKey, "OnlineStats",&wos,sizeof(wos))) {
      int err = GetLastError();
      printf("! ERROR %d - GetRegBinary()\n",err);
      return FALSE;
   }

   //----------------------------------------------------
   // Then Get the current TWildcatServerInfo stats
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

   printf("* Connected Server: %s\n",szConnectedServer);
   printf("* Since : %04d-%02d-%02d %02d:%02d:%02d\n",
                     wos.since.wYear,
                     wos.since.wMonth,
                     wos.since.wDay,
                     wos.since.wHour,
                     wos.since.wMinute,
                     wos.since.wSecond);

   printf("* Calls : %d\n", DIFFZERO(TotalCalls));
   printf("* Users : %d\n", DIFFZERO(TotalUsers));
   printf("* Msgs  : %d\n", DIFFZERO(TotalMessages));
   printf("* Files : %d\n", DIFFZERO(TotalFiles));
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


