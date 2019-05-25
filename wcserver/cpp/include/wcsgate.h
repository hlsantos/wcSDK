//***********************************************************************
// (c) Copyright 1998-2002 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : wcsgate.h
// Subsystem : header for to access networking structures
// Date      :
// Author    :
//
// Revision History:
// Build  Date      Author  Comments
// -----  --------  ------  ---------------------------------------------
//***********************************************************************

#ifndef __WCSGATE_H
#define __WCSGATE_H

#include "wcgtype.h"

#ifdef __cplusplus
extern "C" {
#endif

//+ Group: Configuration Gateway SDK Functions

DWORD APIENTRY GateGetQwkHostCount();
BOOL  APIENTRY GateGetQwkHostByIndex(DWORD index, TGateQwkHost &host);
BOOL  APIENTRY GateGetQwkHostByName(const char *hostname, TGateQwkHost &host);
BOOL  APIENTRY GateAddQwkHost(const TGateQwkHost &host, DWORD &index);
BOOL  APIENTRY GateUpdateQwkHost(DWORD index, const TGateQwkHost &host);
BOOL  APIENTRY GateRemoveQwkHost(DWORD index);

BOOL  APIENTRY GateGetQwkConf(const char *hostname, DWORD conference, TGateQwkConf &conf);
BOOL  APIENTRY GateGetQwkHubConf(const char *hostname, DWORD hubconference, TGateQwkConf &conf);
BOOL  APIENTRY GateSetQwkConf(const char *hostname, DWORD conference, const TGateQwkConf &conf);
BOOL  APIENTRY GateUnsetQwkConf(const char *hostname, DWORD conference);

DWORD APIENTRY GateGetQwkHighMessage(const char *hostname, DWORD conf);
BOOL  APIENTRY GateSetQwkHighMessage(const char *hostname, DWORD conf, DWORD id);

// returns a maximum of 99 tagline characters
BOOL  APIENTRY GateGetTaglineList(char *taglist, DWORD size);
BOOL  APIENTRY GateGetTagline(char tag, char *tagimport, char *tagexport, DWORD size);
BOOL  APIENTRY GateSetTagline(char tag, const char *tagimport, const char *tagexport);

////////////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY GateGetUucpConfig(TGateUucpConfig &config);
BOOL  APIENTRY GateUpdateUucpConfig(const TGateUucpConfig &config);

DWORD APIENTRY GateGetUucpHostCount();
BOOL  APIENTRY GateGetUucpHost(DWORD index, TGateUucpHost &host);
BOOL  APIENTRY GateAddUucpHost(const TGateUucpHost &host, DWORD &index);
BOOL  APIENTRY GateUpdateUucpHost(DWORD index, const TGateUucpHost &host);
BOOL  APIENTRY GateRemoveUucpHost(DWORD index);

DWORD APIENTRY GateGetUucpHighMessage(DWORD conf);
BOOL  APIENTRY GateSetUucpHighMessage(DWORD conf, DWORD id);

BOOL  APIENTRY GateIsNewsgroupSubscribed(const char *host, const char *newsgroup);
BOOL  APIENTRY GateAddNewsgroup(const char *host, const char *newsgroup);
BOOL  APIENTRY GateRemoveNewsgroup(const char *host, const char *newsgroup);

DWORD APIENTRY GateGetAutoResponseCount();
BOOL  APIENTRY GateGetAutoResponseName(DWORD index, char name[SIZE_USER_NAME]);
BOOL  APIENTRY GateGetAutoResponseText(const char *name, char *&text);
BOOL  APIENTRY GateSetAutoResponse(const char *name, const char *text, DWORD &index);
BOOL  APIENTRY GateRemoveAutoResponse(const char *name);

DWORD APIENTRY GateGetMailingListCount();
BOOL  APIENTRY GateGetMailingList(DWORD index, TGateMailingList &ml);
BOOL  APIENTRY GateAddMailingList(const TGateMailingList &ml, DWORD &index);
BOOL  APIENTRY GateUpdateMailingList(DWORD index, const TGateMailingList &ml);
BOOL  APIENTRY GateRemoveMailingList(DWORD index);

////////////////////////////////////////////////////////////////////////////////

const DWORD WC_QWK_TRANSLATE_BASE  = 0x00010000;
const DWORD WC_UUCP_TRANSLATE_BASE = 0x00020000;
                                        
DWORD APIENTRY GateGetHostTranslateCount(DWORD host);
BOOL  APIENTRY GateGetHostTranslate(DWORD host, DWORD index, TGateTranslateEntry &te);
BOOL  APIENTRY GateAddHostTranslate(DWORD host, const TGateTranslateEntry &te, DWORD &index);
BOOL  APIENTRY GateUpdateHostTranslate(DWORD host, DWORD index, const TGateTranslateEntry &te);
BOOL  APIENTRY GateRemoveHostTranslate(DWORD host, DWORD index);

#ifdef __cplusplus
} // extern "C"
#endif

#endif
