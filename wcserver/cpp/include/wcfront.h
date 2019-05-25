//*******************************************************************
// (c) Copyright 1999 Santronics Software, Inc. All Rights Reserved.
//*******************************************************************
//
// File Name : wcfront.h
// Created   : 02/21/05
// Programmer: SSI
//
// Revision History:
// Build  Date     Author  Comments
// -----  -------- ------  -------------------------------
//*******************************************************************

#ifndef __WCFRONT_H
#define __WCFRONT_H

#pragma comment(lib,"wcfront.lib")

#define    WC_FE_OK                 0  // Success
#define    WC_FE_INVALID_PID        1  // Process ID invalid
#define    WC_FE_INVALID_HANDLE     2  // Port invalid
#define    WC_FE_INVALID_NODE       3  // Invalid Node (not prepared)
#define    WC_FE_NODE_IN_USE        4  // Node in use

#define    CLBLACK     0x00000000
#define    CLMAROON    0x00000080
#define    CLGREEN     0x00008000
#define    CLOLIVE     0x00008080
#define    CLNAVY      0x00800000
#define    CLPURPLE    0x00800080
#define    CLTEAL      0x00808000
#define    CLGRAY      0x00808080
#define    CLSILVER    0x00C0C0C0
#define    CLRED       0x000000FF
#define    CLLIME      0x0000FF00
#define    CLYELLOW    0x0000FFFF
#define    CLBLUE      0x00FF0000
#define    CLFUCHSIA   0x00FF00FF
#define    CLAQUA      0x00FFFF00
#define    CLLTGRAY    0x00C0C0C0
#define    CLDKGRAY    0x00808080
#define    CLWHITE     0x00FFFFFF
#define    CLNONE      0x1FFFFFFF
#define    CLDEFAULT   0x20000000

#ifdef __cplusplus
extern "C" {
#endif

typedef struct _tagTCallerIdInfo {
    char Number[80];
    char Name[80];
    BYTE Reserved[200];
} TCallerIdInfo;

typedef struct _tagTIEMSIInfo {
    DWORD session;
    char crtdef[256];
    char protocols[256];
    char capabilities[256];
    char requests[256];
    char software[80];
} TIEMSIInfo;

typedef struct _tagTFrontEndInfo {
    DWORD FrontEndPid;
    DWORD PortHandle;
    DWORD Reserved1;
    DWORD ConnectSpeed;
    DWORD ReliableConnect;
    DWORD TimeLeft;
    TCallerIdInfo CallerIdInfo;
    TIEMSIInfo IEMSIInfo;
    char Name[72];
    BYTE Reserved[ 200 ];
} TFrontEndInfo;

//!--------------------------------------------------------------
//! wcFeSetStatus(Node,Status,Color)
//!
//! This function sets the node status (activity) and color
//! for display in the wcOnline monitor.
//!
//! If the status is "" (blank), the line is removed from
//! the WcOnline monitor.
//!
//! returns one of the WC_FE_xxxxx status values.
//!
//!--------------------------------------------------------------

BOOL APIENTRY wcFeSetStatus(
    /* [in] */  DWORD node,
    /* [in] */  const char *status,
    /* [in] */  DWORD color = CLBLUE);

//!--------------------------------------------------------------
//! wcFeConnect(Node,TFrontEndInfo)
//!
//! This function will pass the session to Wildcat!
//!
//! A TFrontEndInfo structure must be properly prepared with
//! the process id, port handle, speed and time limit.
//!
//! returns one of the WC_FE_xxxxx status values.
//!
//!--------------------------------------------------------------

BOOL APIENTRY wcFeConnect(
    /* [in] */  DWORD node,
    /* [in] */  const TFrontEndInfo *fei);

//!--------------------------------------------------------------
//! wcFeIsAvailable()
//!
//! return true if wcOnline is running on same machine
//!
//!--------------------------------------------------------------

BOOL APIENTRY wcFeIsAvailable();


#ifdef __cplusplus
}
#endif

#endif
