//***********************************************************************
// (c) Copyright 1998-2019 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : wctypemw.h
// Subsystem : header for to access configuration structures
// Date      :
// Author    :
//
// Revision History:
// Build  Date      Author  Comments
// -----  --------  ------  ---------------------------------------------
//***********************************************************************

#ifndef __WCTYPEMW_H
#define __WCTYPEMW_H

#include "wctype.h"

#if !defined(WIN32) && !defined(__MIDL__)

#undef BOOL
#define BOOL long

const DWORD MAX_PATH = 260;

#ifndef _FILETIME_
struct FILETIME {
  DWORD dwLowDateTime;
  DWORD dwHighDateTime;
};
#endif

#endif // WIN32

//+ Group: Configuration Structures

//!---------------------------------------------------------
//! TConferencePaths provides the various directory setups
//! per mail confeference
//!---------------------------------------------------------

typedef struct tagTConferencePaths {
  char Display[MAX_PATH];
  char Bulletin[MAX_PATH];
  char Help[MAX_PATH];
  char Menu[MAX_PATH];
  char Questionnaire[MAX_PATH];
  char MsgDatabase[MAX_PATH];
  char Attach[MAX_PATH];
} TConferencePaths;

//!---------------------------------------------------------
//! TWildcatServerPrivateConfig is the configuration "MakeWild"
//! structure. The public field is exposed to normal
//! SDK clients.
//!---------------------------------------------------------

typedef struct tagTWildcatServerPrivateConfig {
  TMakewild Public;
  char FileDatabasePath[MAX_PATH];
  char UserDatabasePath[MAX_PATH];
  TConferencePaths DefaultConferencePaths;
  char SystemPassword[SIZE_ENCODED_PASSWORD];
  char MakewildPassword[SIZE_ENCODED_PASSWORD];
  char LanguagePath[MAX_PATH];
  char BatchFilePath[MAX_PATH];
  DWORD dwServerOptions;                    //! see srvXXXXX bits
} TWildcatServerPrivateConfig;

const DWORD srvFingerServer  = 0x00000001;  //! Enable Finger Server
const DWORD srvWcxMwLogin    = 0x00000002;  //! Allow WCX MwLogin
const DWORD srvWcxIpCheck    = 0x00000004;  //! Check WCX Peer Address
const DWORD srvOnlyLocalRPC  = 0x00000008;  //! Local RPC Only (v5.7)
const DWORD srvEnableGeoIP   = 0x00000010;  //! Open GeoIP database

//!---------------------------------------------------------
//! TWildcatServerPrivateConfDesc defines a mail conference
//! setup.
//!---------------------------------------------------------

typedef struct tagTWildcatServerPrivateConfDesc {
  TConfDesc Public;
  TConferencePaths Paths;
} TWildcatServerPrivateConfDesc;

//$SDK(0)
//---------------------------------------------------------
// TWildcatServerInternalConfDesc is used internally by
// the wildcat! server. Excluded from SDK
//---------------------------------------------------------

typedef struct tagTWildcatServerInternalConfDesc {
  TConfDesc Public;
  DWORD DisplayPathIndex;
  DWORD BulletinPathIndex;
  DWORD HelpPathIndex;
  DWORD MenuPathIndex;
  DWORD QuestionnairePathIndex;
  DWORD MsgDatabasePathIndex;
  DWORD AttachPathIndex;
} TWildcatServerInternalConfDesc;
//$SDK(1)

//!---------------------------------------------------------
//! TWildcatServerPrivateConfDesc defines a mail conference
//! setup.
//!---------------------------------------------------------

typedef struct tagTWildcatServerPrivateFileArea {
  TFileArea Public;
  char Path[MAX_PATH];
  BYTE Reserved[40];
} TWildcatServerPrivateFileArea;

//!---------------------------------------------------------
//! TWildcatServerPrivateFileVolumec provides CD volume
//! setup information.
//!---------------------------------------------------------

typedef struct tagTWildcatServerPrivateFileVolume {
  char Name[SIZE_SHORT_FILE_NAME];            // 450 12/17/01
  char VolumeLabel[SIZE_SHORT_FILE_NAME];     // 450 12/17/01
  char UniqueFile[MAX_PATH];
  char Path[MAX_PATH];
  BOOL Offline;
  BYTE Reserved[84];
} TWildcatServerPrivateFileVolume;

#if !defined(WIN32) && !defined(__MIDL__)
#undef BOOL
#define BOOL int
#endif

#endif
