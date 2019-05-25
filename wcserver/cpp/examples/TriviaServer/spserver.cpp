//***********************************************************************
// (c) Copyright 1998-2008 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : spserver.cpp
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

const BYTE DM   = 242;
const BYTE WILL = 251;
const BYTE WONT = 252;
const BYTE DO   = 253;
const BYTE DONT = 254;
const BYTE IAC  = 255;

TSimpleProtocolServer::TSimpleProtocolServer(SOCKET s, TSPDispatch *dispatch)
 : Control(s), Dispatch(dispatch)
{
}

TSimpleProtocolServer::~TSimpleProtocolServer()
{
  SetStopEvent();
  if (Control) {
    closesocket(Control);
  }
  Stop();
}

void TSimpleProtocolServer::Go()
{
  SendWelcome();
  char cmdline[1024];
  while (!Done) {
    LastCommandTime = GetTickCount();
    if (!GetCommand(cmdline, sizeof(cmdline))) {
      break;
    }
    if (!PreprocessLine(cmdline)) {
      if (cmdline[0]) {
        char cmd[1024];
        char *s = strchr(cmdline, ' ');
        char *args;
        if (s) {
          strncpy(cmd, cmdline, s-cmdline);
          cmd[s-cmdline] = 0;
          args = &cmdline[s-cmdline+1];
        } else {
          strcpy(cmd, cmdline);
          args = &cmdline[strlen(cmdline)];
        }
        BOOL ok = FALSE;
        DWORD i = 0;
        while (Dispatch[i].cmd) {
          if (_stricmp(cmd, Dispatch[i].cmd) == 0) {
            ok = (this->*Dispatch[i].f)(args);
            break;
          }
          i++;
        }
        if (!ok) {
          SendCommandError(cmdline);
        }
      }
    }
  }
  Cleanup();
}

void TSimpleProtocolServer::SendCommandError(const char *cmdline)
{
  Send("500 '%s': command not understood\r\n", cmdline);
}

BOOL TSimpleProtocolServer::GetCommand(char *s, DWORD len)
{
  BOOL lastIAC = FALSE;
  DWORD i = 0;
  while (i < len-1) {
    if (recv(Control, &s[i], 1, 0) <= 0) {
      return FALSE;
    }
    if (lastIAC) {
      char t[2];
      t[0] = IAC;
      switch (BYTE(s[i])) {
        case WILL:
        case WONT:
          t[1] = DONT;
          send(Control, t, 2, 0);
          break;
        case DO:
        case DONT:
          t[1] = WONT;
          send(Control, t, 2, 0);
          break;
      }
      lastIAC = FALSE;
    } else {
      switch (BYTE(s[i])) {
        case '\r':
          s[i] = 0;
          return TRUE;
        case '\n':
          // do nothing, ignore
          break;
        case DM:
          // ignore this, probably accompanied by ftp ABOR command
          break;
        case IAC:
          lastIAC = TRUE;
          break;
        default:
          i++;
          break;
      }
    }
  }
  s[i] = 0;
  return TRUE;
}

void TSimpleProtocolServer::Send(const char *s, ...)
{
  va_list args;
  va_start(args, s);
  char buf[1024];
  wvsprintf(buf, s, args);
  send(Control, buf, strlen(buf), 0);
  va_end(args);
}
