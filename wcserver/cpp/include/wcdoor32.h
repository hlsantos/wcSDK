//***********************************************************************
// (c) Copyright 1998-2008 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : wcdoor32.h
// Subsystem : Wildcat! Door32
// Date      : 03/07/2008
// Version   : 452.5
// Author    : HLS/SSI
//
// Revision History:
// Build    Date      Author  Comments
// -----    --------  ------  -------------------------------------------
// 452.5    03/07/08  HLS     - Added WCDOOR_EVENT_XXXXXX
//                            - Added DoorEvent()
//
// 452.6    10/01/08  HLS     - For consistency and to help reduce
//                              long time conflict with door32.sys,
//                              door32.h was renamed to wcdoor32.h
//
//***********************************************************************

#ifndef __WCDOOR32_H
#define __WCDOOR32_H

const DWORD WCDOOR_EVENT_BASE        = 0;
const DWORD WCDOOR_EVENT_FAILED      = WCDOOR_EVENT_BASE + 0;
const DWORD WCDOOR_EVENT_TIMEOUT     = WCDOOR_EVENT_BASE + 1;
const DWORD WCDOOR_EVENT_KEYBOARD    = WCDOOR_EVENT_BASE + 2;
const DWORD WCDOOR_EVENT_OFFLINE     = WCDOOR_EVENT_BASE + 3;

#ifdef __cplusplus
extern "C" {
#endif

BOOL   APIENTRY DoorInitialize();
BOOL   APIENTRY DoorShutdown();
BOOL   APIENTRY DoorWrite(const void *data, DWORD size);
DWORD  APIENTRY DoorRead(void *data, DWORD size);
DWORD  APIENTRY DoorReadPeek(void *data, DWORD size);
DWORD  APIENTRY DoorCharReady();
HANDLE APIENTRY DoorGetAvailableEventHandle();
HANDLE APIENTRY DoorGetOfflineEventHandle();
BOOL   APIENTRY DoorHangUp();
DWORD  APIENTRY DoorEvent(const DWORD timeout);

#ifdef __cplusplus
} // extern "C"
#endif

#endif
