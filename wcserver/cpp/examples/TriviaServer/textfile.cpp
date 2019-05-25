//***********************************************************************
// (c) Copyright 1998-2008 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : textfile.cpp
// Subsystem :
// Date      :
// Version   :
// Author    :
//
// Revision History:
// Build    Date      Author  Comments
// -----    --------  ------  -------------------------------------------
//***********************************************************************

#include "common.h"
#pragma hdrstop

#include "textfile.h"

TTextFile::TTextFile()
{
  FileName[0] = '\0';
  h = INVALID_HANDLE_VALUE;
}

TTextFile::TTextFile(LPCTSTR fn, DWORD access, DWORD sharemode, DWORD create)
{
  strcpy(FileName, fn);
  h = ::CreateFile(fn, access, sharemode, NULL, create, FILE_ATTRIBUTE_NORMAL, NULL);
}

TTextFile::TTextFile(HANDLE handle)
 : h(handle)
{
  strcpy(FileName, "(direct)");
  ::SetFilePointer(h, 0, NULL, FILE_BEGIN);
}

TTextFile::~TTextFile()
{
  if (h != INVALID_HANDLE_VALUE) {
    ::CloseHandle(h);
  }
}

BOOL TTextFile::CreateFile(LPCTSTR fn, DWORD access, DWORD sharemode, DWORD create)
{
  if (h == INVALID_HANDLE_VALUE) {
    strcpy(FileName, fn);
    h = ::CreateFile(fn, access, sharemode, NULL, create, FILE_ATTRIBUTE_NORMAL, NULL);
    return IsOk();
  }
  return FALSE;
}

BOOL TTextFile::CloseHandle()
{
  if (::CloseHandle(h)) {
    h = INVALID_HANDLE_VALUE;
    return TRUE;
  }
  return FALSE;
}

DWORD TTextFile::GetFileSize()
{
  return ::GetFileSize(h, NULL);
}

BOOL TTextFile::GetFileTime(FILETIME &ft)
{
  BY_HANDLE_FILE_INFORMATION bhfi;
  if (!GetFileInformationByHandle(h, &bhfi)) {
    return FALSE;
  }
  ft = bhfi.ftLastWriteTime;
  return TRUE;
}

BOOL TTextFile::ReadFile(LPVOID buffer, DWORD requested, LPDWORD read)
{
  return ::ReadFile(h, buffer, requested, read, NULL);
}

BOOL TTextFile::ReadLine(LPVOID buffer, DWORD &bufsize)
{
  DWORD n;
  ReadFile(buffer, bufsize-1, &n);
  if (n == 0) {
    SetLastError(ERROR_HANDLE_EOF);
    return FALSE;
  }
  DWORD i;
  for (i = 0; i < n; i++) {
    BYTE c = ((BYTE *)buffer)[i];
    if (c == '\r') {
      ((BYTE *)buffer)[i] = 0;
      if (i+1 < n && ((BYTE *)buffer)[i+1] == '\n') {
        i++;
      }
      break;
    } else if (c == '\n') {
      ((BYTE *)buffer)[i] = 0;
      break;
    }
  }
  if (i >= n) {
    ((BYTE *)buffer)[i] = 0;
  } else {
    i++;
  }
  SetFilePointer(i - n, FILE_CURRENT);
  if (i >= n) {
    bufsize = i+1;
  } else {
    bufsize = i;
  }
  return TRUE;
}

BOOL TTextFile::SetEndOfFile()
{
  return ::SetEndOfFile(h);
}

DWORD TTextFile::SetFilePointer(LONG dist, DWORD movemethod)
{
  return ::SetFilePointer(h, dist, NULL, movemethod);
}

BOOL TTextFile::SetFileTime(FILETIME &ft)
{
  return ::SetFileTime(h, NULL, NULL, &ft);
}

BOOL TTextFile::WriteFile(LPCVOID buffer, DWORD requested, LPDWORD written)
{
  return ::WriteFile(h, buffer, requested, written, NULL);
}
