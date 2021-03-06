//------------------------------------------------------------------------
// Delphi Wildcat! SDK API v6.0.451.1
// Copyright (c) 1998-2004 Santronics Software, Inc. All Rights Reserved.
//
// DO NOT EDIT THIS FILE!!!
// Automatically generated from door32.h by cpp2pas.
//------------------------------------------------------------------------
{$O+,F+,I-,S-,R-}
unit door32;

interface

{$IFDEF WIN32}
uses windows, wctype;
{$ELSE}
uses WinTypes, wctype;
{$ENDIF}


function DoorInitialize: BOOL; stdcall; external 'door32.dll';
function DoorShutdown: BOOL; stdcall; external 'door32.dll';

function DoorWrite(data: Pointer; size: DWORD): BOOL; stdcall; external 'door32.dll';
function DoorRead(data: Pointer; size: DWORD): DWORD; stdcall; external 'door32.dll';

function DoorReadPeek(data: Pointer; size: DWORD): DWORD; stdcall; external 'door32.dll';
function DoorCharReady: DWORD; stdcall; external 'door32.dll';

function DoorGetAvailableEventHandle: THandle; stdcall; external 'door32.dll';
function DoorGetOfflineEventHandle: THandle; stdcall; external 'door32.dll';

function DoorHangUp: BOOL; stdcall; external 'door32.dll';

implementation

end.
