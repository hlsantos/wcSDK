//***********************************************************************
// (c) Copyright 1998-2025 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : wcDoor32-Example1.pas
// Subsystem : Wildcat! DOOR32
// Date      : 03/17/2025
// Version   : 454.16
// Author    : HLS
// About     :
//
// This is a sample which shows how to use the 32-bit door interface
// (WCDOOR32.DLL).
//
// Basically you just call DoorInitialize to start up, and
// DoorShutdown to clean up.  Writing to the port is done with
// DoorWrite, no translation of any kind is done, just raw output.
// DoorRead will read characters from the input buffer.  It just
// returns with no characters read if there isn't anything to read
// (it does not block).
//
// However, this example uses the more efficient wcDoorEvent() function
// which allows you to watch for keystrokes, idle timeouts and
// disconnects!
//
// The WCDOOR32.DLL also hooks you up in the user's context in the
// Wildcat! server, so you can call Wildcat server API functions.
// The example here gets the user name.
//
//***********************************************************************
// Revision History:
// Build    Date      Author  Comments
// -----    --------  ------  -------------------------------------------
// 454.16   03/17/25  HLS     - Updated wcSDK for Delphi
//***********************************************************************

program wcDoor32_example1;

{$APPTYPE CONSOLE}

uses
  SysUtils,
  Windows,
  wcdoor32,
  wcserver,
  wctype,
  wcserror;

var
  SystemControlNodeChannel: DWORD = 0;

procedure co(const ch : char);
  begin
    write(ch);
    wcDoorWrite(@ch,1);
  end;

procedure coln(s : string);
  begin
    s := s + #13#10;
    write(s);
    wcDoorWrite(@s[1],length(s));
  end;

// Callback function to handle SC_DISCONNECT events
function NodeCallback(userdata: DWORD; const msg: TChannelMessage): DWORD; stdcall;
begin
  if msg.Channel = SystemControlNodeChannel then
  begin
    case msg.UserData of
      SC_DISCONNECT: SetEvent(wcDoorGetOfflineEventHandle);
    end;
  end;
  Result := 0;
end;

var
  User: TUser;
  szchNode: string;
  Active: Integer;
  idleTimeout: Integer;
  c: Byte;

begin
  // Initialize the Door
  if not wcDoorInitialize() then
  begin
    WriteLn('! Could not initialize door');
    WriteLn('! This program must be run as a 32-bit door from Wildcat.');
    WriteLn('! Exiting within 5 seconds');
    Sleep(5000);
    Exit;
  end;

  // Setup callback for node system control events
  SetupWildcatCallback(NodeCallback, 0);
  szchNode := Format('system.control.%d', [GetNode]);
  SystemControlNodeChannel := OpenChannel(PAnsiChar(AnsiString(szchNode)));

  // Get current user info
  WildcatLoggedIn(User);

  // Welcome message
  coln(Format('Welcome to wcDoor32 Example1 [%s] Node: %d',[User.Info.Name,GetNode()]));
  coln('Press a key or ESCAPE to quit: ');

  SetNodeActivity('wcDoor32 Example!');

  Active := 2;           // When 1 pending idle timeout, when 0 exit
  idleTimeout := 60;     // seconds

  // Main event loop
  while Active > 0 do
  begin
    case wcDoorEvent(idleTimeout * 1000) of
      WCDOOR_EVENT_KEYBOARD:
        begin
          Active := 2;
          if wcDoorRead(@c, 1) = 1 then
          begin
            if c = 27 then
              Active := 0;
            co(Char(c));
            if c = 13 then co(#10);
          end;
        end;

      WCDOOR_EVENT_OFFLINE:
        begin
          coln('** FORCE DISCONNECT **');
          Active := 0;
        end;

      WCDOOR_EVENT_TIMEOUT:
        begin
          Dec(Active);
          case Active of
            0: coln(#13#10'** IDLE TIMEOUT - GOODBYE **'#13#10);
            1: coln(Format('** IDLE TIMEOUT IN [%d] SECONDS **',[idleTimeout]));
          end;
        end;

      WCDOOR_EVENT_FAILED:
        Active := 0;
    end;
  end;

  coln(#13#10'Returning to bbs...');
  WcDoorShutdown();
  Sleep(1000);
end.
