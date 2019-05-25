//***********************************************************************
// (c) Copyright 1998-2008 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : linestat.cpp/h
// Subsystem : wcOnline
// Date      : 10/02/2008
// Version   : v6.3.452.6
// Author    : HLS/SSI
//
// Note: linestat.cpp/h is standard stuff, nothing really specific
// to WcOnline.  It is simple a class to hold/manage an array of
// connected sessions (Status)
//
// Revision History:
// Build    Date      Author  Comments
// -----    --------  ------  -------------------------------------------
//***********************************************************************

#ifndef __LINESTAT_H
#define __LINESTAT_H

#include "critsect.h"
#include "thread.h"
#include "wctype.h"

//////////////////////////////////////////////////////////
// This fixes situation of having a pure virtual function
// debug dump when applets error out. for example, issueing
// "wconline -remove" when the service is already removed.
#define USE_DELAY_STATUSMANAGER_START
//////////////////////////////////////////////////////////

enum TLineStatus {
    lsInvalid,
    lsDown,
    lsInit,
    lsWaiting,
    lsRing,
    lsConnected,
    lsUserText,
    lsReset
};

typedef struct _TLineStatusEntry {
    DWORD         ConnectionId;
    DWORD         Node;
    char          Port[SIZE_SERVERSTATE_PORT];
    TLineStatus   LineStatus;
    COLORREF      UserColor;
    DWORD         Time;
    DWORD         LastCallerTime;
    char          Info[80];
    TwcNodeInfo   NodeInfo;
    BOOL          Updated;
} TLineStatusEntry;

class TLineStatusManager: public TThread {
public:
    TLineStatusManager();
    int GetCount();
    int GetRealCount();
    virtual void SetLineStatus(DWORD connectionid,
                               DWORD node,
                               const char *port,
                               TLineStatus ls,
                               DWORD time,
                               const char *info = NULL,
                               COLORREF color = RGB(0, 0, 255));
    virtual void RemoveLineStatus(DWORD connectionid);
    BOOL GetLineStatusByIndex(int index, TLineStatusEntry &status);
    HWND hMainWindow;
    BOOL UpdateNow;    // Not Used, Always TRUE in ::Go()
private:
    TCriticalSection Mutex;
    CArray<TLineStatusEntry, const TLineStatusEntry &> Status;
    virtual void Go();
};

#endif
