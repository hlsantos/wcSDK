//***********************************************************************
// (c) Copyright 1998-2019 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : wconlinemodule.h
// Subsystem : wcOnline
//
// Revision History:
// Build    Date      Author  Comments
// -----    --------  ------  -------------------------------------------
// 454.8    05/09/19  SSI     - ready for v8.0 wcSDK
//***********************************************************************

#ifndef __WCONLINEMODULE_H
#define __WCONLINEMODULE_H

#include "linestat.h"           // WcOnline Line Status Class

// class abstract, each function must be implemented

class WconlineModule {
public:
  virtual BOOL Initialize(TLineStatusManager *sm) = 0;
  virtual BOOL StartServer(const char *server) = 0;
  virtual BOOL DisableServer(const char *server) = 0;
  virtual BOOL StopServer(const char *server) = 0;
  virtual BOOL Shutdown() = 0;
};

#endif
