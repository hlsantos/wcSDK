//***********************************************************************
// (c) Copyright 1998-2008 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : thread.h
// Subsystem :
// Date      :
// Version   :
// Author    :
//
// Revision History:
// Build    Date      Author  Comments
// -----    --------  ------  -------------------------------------------
//***********************************************************************

#ifndef __THREAD_H
#define __THREAD_H

class TThread {
public:
  TThread(DWORD startflags = 0);
  virtual ~TThread();
  void Start();
  void SetStopEvent() { SetEvent(TerminateEvent); }
  virtual void Stop();
  HANDLE GetThreadHandle() { return ThreadHandle; }
  DWORD GetThreadId() { return tid; }
protected:
  HANDLE TerminateEvent;
  virtual void Go() = 0;
private:
  DWORD StartFlags;
  HANDLE ThreadHandle;
  DWORD tid;
  static unsigned __stdcall ThreadRoutine(void *p);
};

#endif
