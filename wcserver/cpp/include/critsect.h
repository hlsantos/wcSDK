//************************************************************************
// (c) Copyright 1999-2019 Santronics Software, Inc. All Rights Reserved.
//************************************************************************
//
// File Name : critsect.h
// Created   : 4/15/98
// Programmer:
// Original  : Hector Santos
//
// Revision History:
// Build  Date     Author  Comments
// -----  -------- ------  -------------------------------
//************************************************************************


#ifndef __CRITSECT_H
#define __CRITSECT_H

#ifndef CLASSLIB_THREAD_H

class TCriticalSection {
public:
  TCriticalSection(const char *sztag="");
  ~TCriticalSection();
  void Enter();
  void Leave();
  BOOL Check() const;
  int Count() const;
  class Lock {
  public:
    Lock(TCriticalSection &cs): CS(cs) { CS.Enter(); }
    ~Lock() { CS.Leave(); }
  private:
    TCriticalSection &CS;
  };
private:
  CRITICAL_SECTION cs;
  int InCount;
  TCriticalSection(const TCriticalSection &);
};

inline TCriticalSection::TCriticalSection(const char *sztag)
{
  InitializeCriticalSection(&cs);
  InCount = 0;
}

inline TCriticalSection::~TCriticalSection()
{
//#ifdef __AFX_H__
//  if (In) {
//    AfxDebugBreak();
//  }
//#endif
  DeleteCriticalSection(&cs);
}

inline void TCriticalSection::Enter()
{
  EnterCriticalSection(&cs);
  InCount++;
}

inline void TCriticalSection::Leave()
{
  InCount--;
  LeaveCriticalSection(&cs);
}

inline BOOL TCriticalSection::Check() const
{
  return InCount > 0;
}

inline int TCriticalSection::Count() const
{
  return InCount;
}

#endif // CLASSLIB_THREAD_H

typedef TCriticalSection::Lock TCriticalSectionGrabber;

//class TCriticalSectionGrabber {
//public:
//  TCriticalSectionGrabber(TCriticalSection &cs): CS(cs) { CS.Enter(); }
//  ~TCriticalSectionGrabber() { CS.Leave(); }
//private:
//  TCriticalSection &CS;
//};

class TReaderWriter {
public:
  TReaderWriter();
  ~TReaderWriter();
  void ReaderEnter();
  void ReaderLeave();
  void WriterEnter();
  void WriterLeave();
  BOOL ReadOk() const { return Readers >= 0 || WriterRecursion > 0; } //ReadingActive.Check(); }
  BOOL WriteOk() const { return WriterMutex.Check(); }
  long GetReaders() const { return Readers; }          // 451.5 07/12/05 08:29 pm
  long GetWriters() const { return WriterRecursion; }  // 451.5 07/12/05 08:29 pm
private:
  long Readers;
  long WriterRecursion;
  HANDLE ReadingOk;
  HANDLE ReadingActiveSemaphore;
  TCriticalSection WriterMutex;
  TReaderWriter(const TReaderWriter &) {}
};

inline TReaderWriter::TReaderWriter()
{
  Readers = -1;
  ReadingOk = CreateEvent(NULL, TRUE, TRUE, NULL);
  ReadingActiveSemaphore = CreateSemaphore(NULL, 1, 1, NULL);
  WriterRecursion = 0;
}

inline TReaderWriter::~TReaderWriter()
{
  CloseHandle(ReadingOk);
  CloseHandle(ReadingActiveSemaphore);
}

inline void TReaderWriter::ReaderEnter()
{
  TCriticalSectionGrabber grab(WriterMutex);
  WaitForSingleObject(ReadingOk, INFINITE);
  if (InterlockedIncrement(&Readers) == 0) {
    WaitForSingleObject(ReadingActiveSemaphore, INFINITE);
  }
}

inline void TReaderWriter::ReaderLeave()
{
  if (InterlockedDecrement(&Readers) < 0) {
    ReleaseSemaphore(ReadingActiveSemaphore, 1, NULL);
  }
}

inline void TReaderWriter::WriterEnter()
{
  WriterMutex.Enter();
  WriterRecursion++;
  ResetEvent(ReadingOk);
  if (WriterRecursion == 1) {
    WaitForSingleObject(ReadingActiveSemaphore, INFINITE);
  }
}

inline void TReaderWriter::WriterLeave()
{
  WriterRecursion--;
  if (WriterRecursion == 0) {
    SetEvent(ReadingOk);
    ReleaseSemaphore(ReadingActiveSemaphore, 1, NULL);
  }
  WriterMutex.Leave();
}

class TReaderGrabber {
public:
  TReaderGrabber(TReaderWriter &rw): RW(rw) { RW.ReaderEnter(); }
  ~TReaderGrabber() { RW.ReaderLeave(); }
private:
  TReaderWriter &RW;
};

class TWriterGrabber {
public:
  TWriterGrabber(TReaderWriter &rw): RW(rw) { RW.WriterEnter(); }
  ~TWriterGrabber() { RW.WriterLeave(); }
private:
  TReaderWriter &RW;
};


#endif
