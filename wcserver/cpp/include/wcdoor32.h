//***********************************************************************
// (c) Copyright 1998-2023 Santronics Software, Inc. All Rights Reserved.
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
// 454.13   02/12/23 HLS     - added wc prefix to functions
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

BOOL   APIENTRY wcDoorInitialize();
BOOL   APIENTRY wcDoorShutdown();
BOOL   APIENTRY wcDoorWrite(const void *data, DWORD size);
DWORD  APIENTRY wcDoorRead(void *data, DWORD size);
DWORD  APIENTRY wcDoorReadPeek(void *data, DWORD size);
DWORD  APIENTRY wcDoorCharReady();
HANDLE APIENTRY wcDoorGetAvailableEventHandle();
HANDLE APIENTRY wcDoorGetOfflineEventHandle();
BOOL   APIENTRY wcDoorHangUp();
DWORD  APIENTRY wcDoorEvent(const DWORD timeout);

#ifdef __cplusplus
} // extern "C"
#endif

#endif
