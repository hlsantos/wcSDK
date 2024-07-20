//***********************************************************************
// (c) Copyright 1998-2008 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : trvsrvr.cpp
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

#include "spserver.h"

///////////////////////////////////////////////////////////////////////////////
// GetTriviaQuestion

BOOL GetTriviaQuestion(char *buf, DWORD &size)
{
  BOOL result = FALSE;
  EnterCriticalSection(&DataFileMutex);
  if (DataFile.IsOk()) {
    BOOL seteof = FALSE;
    while (TRUE) {
      DWORD read = size;
      if (DataFile.ReadLine(buf, read)) {
        if ((buf[0] != '\0') && (buf[0] != ';')) {
          size = read;
          result = TRUE;
          break;
        }
      } else
      if ((GetLastError() == ERROR_HANDLE_EOF) && (seteof == FALSE)) {
        seteof = TRUE;
        DataFile.SetFilePointer(0, FILE_BEGIN);
      } else {
        result = FALSE;
        break;
      }
    }
  }
  LeaveCriticalSection(&DataFileMutex);
  return result;
}

///////////////////////////////////////////////////////////////////////////////
// TTriviaServer

class TTriviaServer: public TSimpleProtocolServer {
typedef TSimpleProtocolServer inherited;
public:
  TTriviaServer(SOCKET s);
  ~TTriviaServer();
protected:
  virtual void Go();
  virtual void SendWelcome();
private:
  static TSPDispatch Dispatch[];
  BOOL tsHELP(char *args);
  BOOL tsBYE(char *args);
  BOOL tsUSER(char *args);
  BOOL tsVER(char *args);
  BOOL tsNEXT(char *args);
};


TSimpleProtocolServer::TSPDispatch TTriviaServer::Dispatch[] = {
	SPCMD(TTriviaServer, "HELP",  tsHELP),
	SPCMD(TTriviaServer, "BYE",   tsBYE),
	SPCMD(TTriviaServer, "USER",  tsUSER),
	SPCMD(TTriviaServer, "VER",   tsVER),
	SPCMD(TTriviaServer, "NEXT",  tsNEXT),
	{0}
};

TTriviaServer::TTriviaServer(SOCKET s)
 : TSimpleProtocolServer(s, Dispatch)
{
  Done = FALSE;
  InterlockedIncrement((long*)&ActiveConnections);
  Start();
}

TTriviaServer::~TTriviaServer()
{
  InterlockedDecrement((long*)&ActiveConnections);
}

void TTriviaServer::Go()
{
  inherited::Go();
  delete this;
}

void TTriviaServer::SendWelcome()
{
  Send("220-Welcome to the Wildcat! Trivia Service\r\n");
  Send("220-Copyright (c) 1996-2023, Santronics Software, Inc. All rights reserved.\r\n");
  Send("220-This is an example of a Wildcat! Trivia Service. This service\r\n");
  Send("220-demonstrates how a Wildcat! Service can be used to provide\r\n");
  Send("220-specific information to callers using a dialup or telnet terminal\r\n");
  Send("220-connection, Dynamic HTML, or the Wildcat! Navigator.  Client applications\r\n");
  Send("220 can be written in any language supported by the WCSDK!\r\n");
}

BOOL TTriviaServer::tsBYE(char *args)
{
  Send("221 Goodbye\r\n");
  closesocket(Control);
  Done = TRUE;
  return TRUE;
}

BOOL TTriviaServer::tsNEXT(char *args)
{
  char buf[256];
  DWORD size = sizeof(buf);
  if (GetTriviaQuestion(buf, size)) {
    Send("200 %s\r\n", buf);
  } else {
    Send("500 Error\r\n");
  }
  return TRUE;
}

BOOL TTriviaServer::tsUSER(char *args)
{
  Send("230 User logged in successfully.\r\n");
  return TRUE;
}

BOOL TTriviaServer::tsVER(char *args)
{
  Send("200 wcTrivia Version %s\r\n", WCTRIVIA_VERSION_STR);
  return TRUE;
}

BOOL TTriviaServer::tsHELP(char *args)
{
  Send("200------  wcTrivia Available commands ------------\r\n");
  Send("200-HELP   - gets the next trivia question\r\n");
  Send("200-NEXT   - gets the next trivia question\r\n");
  Send("200-USER   - pass the user name, info\r\n");
  Send("200-VER    - shows wcTrivia version\r\n");
  Send("200-BYE    - exits current session\r\n");
  Send("200 End of Commands\r\n");
  return TRUE;
}

////////////////////////////////////////////////////////////
// ListenThread()
//
// This is the main service TCP listening thrad
////////////////////////////////////////////////////////////

void ListenThread(void *p)
{
  SOCKET s = (SOCKET)p;
  listen(s, 5);
  while (1) {
    sockaddr_in tin;
    int n = sizeof(tin);
    SOCKET t = accept(s, (sockaddr *)&tin, &n);
    if (t == INVALID_SOCKET) {
      break;
    }
    new TTriviaServer(t);
  }
}
