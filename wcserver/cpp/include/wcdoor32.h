//***********************************************************************
// (c) Copyright 1998-2025 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : wcdoor32.h
// Subsystem : Wildcat! Door32
// Date      : 01/29/2025
// Version   : 454.16
// Author    : HLS-DS
//
// Revision History:
// Build    Date      Author  Comments
// -----    --------  ------  -------------------------------------------
// 452.5    03/07/08  HLS     - Added WCDOOR_EVENT_XXXXXX
//                            - Added DoorEvent()
//
// 452.6    10/01/08  HLS     - Renamed door32.h to wcdoor32.h
//
// 454.13   02/12/23  HLS     - Added wc prefix to functions
//
// 454.16   10/25/23  HLS-DS  - Replaced const DWORD with #define macros
//                              to resolve C compilation errors (C2099)
//***********************************************************************

#ifndef __WCDOOR32_H
#define __WCDOOR32_H

#define WCDOOR_EVENT_BASE        0
#define WCDOOR_EVENT_FAILED      (WCDOOR_EVENT_BASE + 0)
#define WCDOOR_EVENT_TIMEOUT     (WCDOOR_EVENT_BASE + 1)
#define WCDOOR_EVENT_KEYBOARD    (WCDOOR_EVENT_BASE + 2)
#define WCDOOR_EVENT_OFFLINE     (WCDOOR_EVENT_BASE + 3)

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
