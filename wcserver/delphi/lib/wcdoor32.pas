//------------------------------------------------------------------------
// Delphi Wildcat! SDK API v8.0.454.16
// Copyright (c) 1998-2025 Santronics Software, Inc. All Rights Reserved.
//
// DO NOT EDIT THIS FILE!!!
//
// Automatically generated from ..\include\wcdoor32.h by cpp2pas.
//------------------------------------------------------------------------
{$O+,F+,I-,S-,R-}
unit wcdoor32;

interface

{$IFDEF WIN32}
uses windows, wctype;
{$ELSE}
uses WinTypes, wctype;
{$ENDIF}


{$DEFINE __WCDOOR32_H}

const WCDOOR_EVENT_BASE                     = 0;
const WCDOOR_EVENT_FAILED                   = (WCDOOR_EVENT_BASE + 0);
const WCDOOR_EVENT_TIMEOUT                  = (WCDOOR_EVENT_BASE + 1);
const WCDOOR_EVENT_KEYBOARD                 = (WCDOOR_EVENT_BASE + 2);
const WCDOOR_EVENT_OFFLINE                  = (WCDOOR_EVENT_BASE + 3);

function wcDoorInitialize: BOOL; stdcall; external 'wcdoor32.dll';
function wcDoorShutdown: BOOL; stdcall; external 'wcdoor32.dll';
function wcDoorWrite(data: Pointer; size: DWORD): BOOL; stdcall; external 'wcdoor32.dll';
function wcDoorRead(data: Pointer; size: DWORD): DWORD; stdcall; external 'wcdoor32.dll';
function wcDoorReadPeek(data: Pointer; size: DWORD): DWORD; stdcall; external 'wcdoor32.dll';
function wcDoorCharReady: DWORD; stdcall; external 'wcdoor32.dll';
function wcDoorGetAvailableEventHandle: THandle; stdcall; external 'wcdoor32.dll';
function wcDoorGetOfflineEventHandle: THandle; stdcall; external 'wcdoor32.dll';
function wcDoorHangUp: BOOL; stdcall; external 'wcdoor32.dll';
function wcDoorEvent(const timeout: DWORD): DWORD; stdcall; external 'wcdoor32.dll';

implementation

end.
