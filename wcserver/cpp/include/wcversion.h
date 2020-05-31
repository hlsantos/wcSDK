//***********************************************************************
// (c) Copyright 1999-2000 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : wcversion.h
// Subsystem : Product Version definition file
// Date      : 03/20/00 06:32 am
// Updated   : 04/30/05 06:01 am
// Author    : SSI
//
// Modules Used In:
//
// wconline.exe
// wcserver.exe
// wsmw.dll
// wcsrv.dll
//
// Revision History:
// Build  Date      Author  Comments
// -----  --------  ------  ---------------------------------------------
// 448.5  03/20/00  HLS     Added TESTDRIVE KillDate Inline Macro
// 451.5  04/30/05  HLS     Added TESTDRIVE_ARM logic
//***********************************************************************

#ifndef __WCVERSION_H
#define __WCVERSION_H

#if !defined(__WCGLOBAL_H)
#include "wcglobal.h"
#endif

#if !defined(PERSONAL) && !defined(TESTDRIVE)
#define RETAIL_VERSION
#endif

//--------------------------------------------------------------------
// Features to disble/exclude in non RETAIL Version
//--------------------------------------------------------------------

#if !defined(RETAIL_VERSION)
#   define FEATURE_EXCLUDE_WCX          // Only WILDCAT.WCL library
#   define FEATURE_FORCE_REGNUM         // Force 00-0000
#   define FEATURE_EXCLUDE_NETWORK      // Disable Network Advertising
#   define FEATURE_EXCLUDE_MURKWORKS    // Wconline.cpp
#   define FEATURE_EXCLUDE_PPP          // Wconline.cpp
#   define FEATURE_MATCH_CRC32          // Match crc32 distribution
#endif
//--------------------------------------------------------------------

//--------------------------------------------------------------------
// Max Nodes/Users for non RETAIL Version
//--------------------------------------------------------------------

#if defined(PERSONAL)
#   define MAXIMUM_NODES_LIMIT 2
#   define MAXIMUM_USERDB 5
#endif

//--------------------------------------------------------------------
// Max Nodes/Users for Test Drive Version
// NOTE: /D "TESTDRIVE" must be defined at the compiler project level
//--------------------------------------------------------------------

#if defined(TESTDRIVE)
#   define MAXIMUM_NODES_LIMIT         2
#   define MAXIMUM_USERDB              100
//#   define TESTDRIVE_TRIALX           // USE Modem Software Lock API
//#   define TESTDRIVE_SSI              // USE Santronics API
//#   define TESTDRIVE_KILLDATE         // USE Absolute Kill Date
// 451.5a 04/30/05 
#   define TESTDRIVE_ARM              // USE Armadillo 2.85 (g:\armadillo)
#   undef FEATURE_FORCE_REGNUM        // Don't Force 00-0000
#endif
//--------------------------------------------------------------------

//#define BETA_KILLDATE

//--------------------------------------------------------------------
// Called by various places
//--------------------------------------------------------------------

#if defined(TESTDRIVE_KILLDATE) || defined(BETA_KILLDATE)
#define USE_KILLDATE
inline int CHECK_TESTDRIVE_KILLDATE()
{
   SYSTEMTIME _kdst;
   GetSystemTime(&_kdst);
   char *pszCompileDate = __DATE__;
   if ((_kdst.wYear > 2005)&&(_kdst.wMonth > 12)) {
       return 1;
   }
   return 0;
}
#endif

#endif //  __WCVERSION_H
