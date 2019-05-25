#ifndef __WCLLIB_H
#define __WCLLIB_H

//--------------------------------------------------------------
// wildcat.wcl format:
//
// DWORD                :  count
// TCodeLibIndexEntry   :  list
// wcx programs         :  binary stream of sorted wcx files
//--------------------------------------------------------------

#define USE_NEW_WCXENTRY

enum {wtLib,wtProgram};


#ifdef USE_NEW_WCXENTRY
struct TCodeEntryInfo {
  FILETIME ftCreationTime;
  FILETIME ftLastAccessTime;
  FILETIME ftLastWriteTime;
  BOOL     IsLib;
  DWORD    ImageFlags;
  DWORD    FileSize;
  BYTE     reserve[20];
};
#endif

struct TCodeLibIndexEntry {
#ifdef USE_NEW_WCXENTRY
  char Name[MAX_PATH-sizeof(TCodeEntryInfo)];
  TCodeEntryInfo Info;
#else
  char Name[MAX_PATH];
#endif
  DWORD Offset;
  DWORD Size;
};


#endif
