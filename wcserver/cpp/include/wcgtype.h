//***********************************************************************
// (c) Copyright 1998-2005 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
// File Name : wcgtype.h
// SubSystem : Wildcat! gateway structures
//
// Revision History:
// Build  Date     Author  Comments
// -----  -------- ------  -------------------------------
////////////////////////////////////////////////////////////////////////

#ifndef __WCGTYPE_H
#define __WCGTYPE_H

#include "wctype.h"

//+ Group: Configuration Gateway Structures

const DWORD SIZE_GATE_HOST_NAME = SIZE_MESSAGE_NETWORK;

////////////////////////////////////////////////////////////

typedef struct tagTAutoResponseName {
    char name[SIZE_USER_NAME];
} TAutoResponseName;

////////////////////////////////////////////////////////////

typedef struct tagTGateQwkHost {
  char Name[SIZE_GATE_HOST_NAME];
  char QwkPath[MAX_PATH];
  char RepPath[MAX_PATH];
  DWORD AttachmentSizeLimit;
  DWORD Packer; // really a char
  BOOL AtFilter;
  BOOL GateTag;
  BOOL AppendRepPackets;
  DWORD Index;
  BYTE Reserved[84];
} TGateQwkHost;

typedef struct tagTGateQwkConf {
  DWORD Conference;
  DWORD HubConference;
  DWORD TaglineId; // really a char
  BOOL ExportPrivateMail;
} TGateQwkConf;

////////////////////////////////////////////////////////////

const DWORD SIZE_GATE_ORGANIZATION = 80;

typedef struct tagTGateUucpConfig {
  char AdministratorName[SIZE_USER_NAME];
  char LocalDomain[SIZE_DOMAIN_NAME];
  char LocalSiteName[SIZE_DOMAIN_NAME];
  char AlternateDomain[SIZE_DOMAIN_NAME];
  char Organization[SIZE_GATE_ORGANIZATION];
  char NewsRequestName[SIZE_USER_NAME];
  char PrimaryProvider[SIZE_GATE_HOST_NAME];
  DWORD Reserved1;
  BOOL BounceInvalidMessages;
  DWORD MaxExportMessageCount;
  BYTE Reserved[72];
} TGateUucpConfig;

const DWORD hfAllowHtmlImport     = 0x00000001;
const DWORD hfDisableEmailImport  = 0x00000010;
const DWORD hfDisableEmailExport  = 0x00000020;
const DWORD hfDisableNewsImport   = 0x00000100;
const DWORD hfDisableNewsExport   = 0x00000200;
const DWORD hfReserved            = 0x00001000;  // 451.6
const DWORD hfLocalHost           = 0x00002000;  // 451.6 if off, Remote Host
const DWORD hfRouteSMTP           = 0x00004000;  // 451.6 if off, Keep in spool

enum {
    htEmailAndNews, // = 0 default (compatible)
    htEmailOnly, 
    htNewsOnly
};

typedef struct tagTGateUucpHost {
  char Name[SIZE_GATE_HOST_NAME];
  char Administrator[SIZE_USER_NAME];
  char Domain[SIZE_DOMAIN_NAME];
  char SiteName[SIZE_DOMAIN_NAME];
  DWORD AttachmentSizeLimit;
  BOOL DeleteFiles;
  BOOL AllowNewsRequests;
  char SpoolPath[MAX_PATH];
  char AdditionalSpoolPath[MAX_PATH];
  DWORD dwHostFlags;      // 449.4, reserved was 24
  DWORD EmailConference;  // 449.4
  DWORD HostType;         // 451.6  see htXXXXXX
  BYTE Reserved[12];
} TGateUucpHost;

enum {teBoth, teImport, teExport};

//
// HLS 01/23/99 12:14 pm
// Field TranslateType was formerly called Type
// renamed for portability to Pascal
//
typedef struct tagTGateTranslateEntry {
  DWORD TranslateType;
  char LocalName[SIZE_USER_NAME];
  char ExternalName[SIZE_USER_NAME];
} TGateTranslateEntry;


typedef struct tagTGateMailingList {
  char Name[SIZE_USER_NAME];
  DWORD Conference;
  BYTE Reserved[52];
} TGateMailingList;

//$SDK(0)
// the following is only used by GateGetAutoResponseText
typedef struct tagTRpcTextData {
  DWORD size;
#ifdef __MIDL__
  [unique, size_is(size)]
#endif
  char *data;
} TRpcTextData;
//$SDK(1)

#endif
