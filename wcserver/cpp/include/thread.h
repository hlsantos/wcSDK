//*******************************************************************
// (c) Copyright 1999-2019 Santronics Software, Inc. All Rights Reserved.
//*******************************************************************
//
// File Name : thread.h
// Created   :
// Programmer:
//
// Revision History:
// Build  Date     Author  Comments
// -----  -------- ------  -------------------------------
//*******************************************************************

#ifndef __THREAD_H
#define __THREAD_H

#include <process.h>

//--------------------------------------------------------------
// TTHread Class
// 453.5R9 - updated into single class, seems to help
//           with handle leaves at thread self destruct
//           shutdown.
//--------------------------------------------------------------

// 454.8 - 
#define VH(h) (h != INVALID_HANDLE_VALUE)
// this works but use the original with InterlockedExchangePointer
//#define VH(h) ((h != INVALID_HANDLE_VALUE) && ((int)h != 0) && ((int)h != -1))

#define  WFSO  WaitForSingleObject

class TThread {
public:
   TThread(DWORD flags = 0)
    : TerminateEvent(CreateEvent(NULL,TRUE,FALSE,NULL)),
      hThread(INVALID_HANDLE_VALUE),
      tid(0),
      exitcode(0),
      ShutdownWaitTime(1000),
      StartFlags(flags)
       {
       }

   void Start()
       {
           if (VH(hThread)) {
               Resume();
               return;
           }
           hThread = (HANDLE)_beginthreadex
                     (
                      NULL,                 // security
                      0,                    // stack size
                      ThreadRoutine,        // thread proc
                      this,                 // thread proc arg pointer
                      StartFlags,           // init flags
                      (unsigned int *)&tid  // thread identifier
                     );
       }

protected:
   HANDLE TerminateEvent;
   virtual void Go() = 0;
public:
   DWORD  ShutdownWaitTime;  // 453.5rc1 moved from private
   virtual ~TThread()        // 453.4rc1 moved from protected
       {
           Stop();
           CloseEvent();
           CloseThread();
       }


private:
   HANDLE hThread;
   DWORD  tid;
   DWORD  StartFlags;
   DWORD  exitcode;       // 453.5Q


   static unsigned __stdcall ThreadRoutine(void *p)
      {
          ((TThread *)p)->Go();
          return 0;
      }

   void CloseEvent()
      {
          if (VH(TerminateEvent))
          {
             // 453.5T6 - now uses InterlockedExchanged
             //HANDLE h = (HANDLE)InterlockedExchange((LPLONG)&TerminateEvent, -1);
			 // 454.8 - now uses InterlockedExchangePointer
			 HANDLE h = InterlockedExchangePointer(&TerminateEvent, INVALID_HANDLE_VALUE);
             CloseHandle(h);
          }
      }

   void CloseThread()
      {
         if (VH(hThread)) {
            // 453.5T6 - now uses InterlockedExchanged
            //HANDLE h = (HANDLE)InterlockedExchange((LPLONG)&hThread, -1);
			// 454.8 - now uses InterlockedExchangePointer
			HANDLE h = InterlockedExchangePointer(&hThread, INVALID_HANDLE_VALUE);
			CloseHandle(h);
         }
      }

public:

   HANDLE GetThreadHandle() { return hThread; }
   DWORD GetThreadId() { return tid; }
   void SetShutdownWaitTime(const DWORD msecs) { ShutdownWaitTime = msecs;}  // 453.3
   void SetStartFlags(const DWORD flags) { StartFlags = flags;}              // 453.3
   BOOL Pause()  { return SuspendThread(hThread); }                          // 453.5Q
   BOOL Resume() { return ResumeThread(hThread);  }                          // 453.5Q
   virtual void SetExitCode(const DWORD &ec) {exitcode = ec;}                // 453.5Q
   virtual DWORD GetExitCode()                                               // 453.5Q
       {
          if (exitcode == 0) {
              if (VH(hThread) && GetExitCodeThread(hThread,&exitcode)) {
                  if (exitcode == STILL_ACTIVE){}
              }
          }
          return exitcode;
       }
   virtual void InitiateShutdown() { SetEvent(TerminateEvent); }
   virtual BOOL IsTerminated(const DWORD &waitms = 0) { return WFSO(TerminateEvent,waitms)!=WAIT_TIMEOUT;} // 453.3, 453.5Q added waitms
   virtual BOOL IsRunning()        { return WFSO(hThread,0)==WAIT_TIMEOUT;}    // 453.5Q
   virtual void Stop()
     {
        if (VH(hThread) && GetCurrentThreadId() != tid)
        {
            InitiateShutdown();
            if (WFSO(hThread, ShutdownWaitTime) != WAIT_OBJECT_0)
            {
                Beep(800, 100);
                TerminateThread(hThread, DWORD(-1));
            }
            CloseThread();
        }
      }

};

#undef VH
#undef WFSO

#endif
