//***********************************************************************
// (c) Copyright 1998-2008 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : spserver.h
// Subsystem :
// Date      :
// Version   :
// Author    :
//
// Revision History:
// Build    Date      Author  Comments
// -----    --------  ------  -------------------------------------------
//***********************************************************************


#ifndef __SPSERVER_H
#define __SPSERVER_H

#include "thread.h"

#define SPCMD(cls, cmd, func) {cmd, (BOOL (TSimpleProtocolServer::*)(char *))(&cls::func)}

class TSimpleProtocolServer: public TThread {
public:
  struct TSPDispatch {
    char *cmd;
    BOOL (TSimpleProtocolServer::*f)(char *args);
  };
  TSimpleProtocolServer(SOCKET s, TSPDispatch *dispatch);
  ~TSimpleProtocolServer();
protected:
  virtual void Go();
protected:
  virtual void SendWelcome() {}
  virtual BOOL PreprocessLine(char *s) { return FALSE; }
  virtual void SendCommandError(const char *cmdline);
  virtual void Cleanup() {}
  void Send(const char *s, ...);
  SOCKET Control;
  BOOL Done;
  DWORD LastCommandTime;
private:
  TSPDispatch *Dispatch;
  BOOL GetCommand(char *s, DWORD len);
};

#endif
