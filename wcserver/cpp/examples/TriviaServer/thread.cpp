//***********************************************************************
// (c) Copyright 1998-2008 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : thread.cpp
// Subsystem :
// Date      :
// Version   :
// Author    :
//
// Revision History:
// Build    Date      Author  Comments
// -----    --------  ------  -------------------------------------------
//***********************************************************************

#include <windows.h>
#pragma hdrstop

#include <process.h>

#include "thread.h"

TThread::TThread(DWORD startflags)
{
  StartFlags = startflags;
  TerminateEvent = CreateEvent(NULL, TRUE, FALSE, NULL);
  ThreadHandle = NULL;
  tid = 0;
}

TThread::~TThread()
{
  Stop();
  CloseHandle(TerminateEvent);
  if (ThreadHandle) {
    CloseHandle(ThreadHandle);
  }
}

void TThread::Start()
{
  if (ThreadHandle) {
    ResumeThread(ThreadHandle);
  } else {
    ThreadHandle = (HANDLE)_beginthreadex(NULL, 0, ThreadRoutine, this, StartFlags, (unsigned int *)&tid);
  }
}

void TThread::Stop()
{
  if (ThreadHandle && GetCurrentThreadId() != tid) {
    SetStopEvent();
    if (WaitForSingleObject(ThreadHandle, 1000) != WAIT_OBJECT_0) {
      TerminateThread(ThreadHandle, 0);
      ThreadHandle = NULL;
      MessageBeep(0);
    }
  }
}

unsigned TThread::ThreadRoutine(void *p)
{
  ((TThread *)p)->Go();
  return 0;
}
