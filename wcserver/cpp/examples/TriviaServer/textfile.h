//***********************************************************************
// (c) Copyright 1998-2008 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : textfile.h
// Subsystem :
// Date      :
// Version   :
// Author    :
//
// Revision History:
// Build    Date      Author  Comments
// -----    --------  ------  -------------------------------------------
//***********************************************************************


#ifndef __textfile_h
#define __textfile_h

class TTextFile {
public:
  TTextFile();
  TTextFile(LPCTSTR fn, DWORD access, DWORD sharemode, DWORD create);
  TTextFile(HANDLE handle);
  virtual ~TTextFile();
  BOOL IsOk() { return h != INVALID_HANDLE_VALUE; }
  BOOL CreateFile(LPCTSTR fn, DWORD access, DWORD sharemode, DWORD create);
  BOOL CloseHandle();
  const char *GetName() { return FileName; }
  DWORD GetFileSize();
  BOOL GetFileTime(FILETIME &ft);
  BOOL ReadFile(LPVOID buffer, DWORD requested, LPDWORD read);
  BOOL ReadLine(LPVOID buffer, DWORD &bufsize);
  BOOL SetEndOfFile();
  DWORD SetFilePointer(LONG dist, DWORD movemethod);
  BOOL SetFileTime(FILETIME &ft);
  BOOL WriteFile(LPCVOID buffer, DWORD requested, LPDWORD written);
private:
  HANDLE h;
  char FileName[MAX_PATH];
};

#endif
