////////////////////////////////////////////////////////////////////////////
//
// This is a PASCAL sample which shows how to use the 32-bit door
// interface (DOOR32.DLL).
//
// Basically you just call DoorInitialize to start up, and DoorShutdown
// to clean up.  Writing to the port is done with DoorWrite, no
// translation of any kind is done, just raw output.  DoorRead will
// read characters from the input buffer.  It just returns with no
// characters read if there isn't anything to read (it does not block).
//
// The Wildcat version of DOOR32.DLL also hooks you up in the user's
// context in the Wildcat server, so you can call Wildcat server
// API functions.  The example here gets the user name.
//
////////////////////////////////////////////////////////////////////////////

{$APPTYPE CONSOLE}
{$H-,O+,A-}

program dortst32;
uses
   sysutils,
   windows,
   door32,
   wctype,
   wcserver;

procedure co(const ch : char);
  begin
    write(ch);
    DoorWrite(@ch,1);
  end;

procedure coln(s : string);
  begin
    s := s + #13#10;
    write(s);
    DoorWrite(@s[1],length(s));
  end;

function CharReady1 : boolean;
var a : thandle;
  begin
    a := DoorGetAvailableEventHandle();
    Result :=  (WaitForSingleObject(a, 0) = WAIT_OBJECT_0);
    Sleep(15);
  end;

function CharPeek : Char;
var ch: char;
  begin
    Result :=  #0;
    if (DoorReadPeek(@ch,1) > 0) then Result :=  ch;
    Sleep(15);
  end;


function CharReady : boolean;
var n : dword;
  begin
    n := DoorCharReady();
    if (n > 0) then begin
        coln('peek char: '+CharPeek());
    end;
    Result :=  n > 0;
    Sleep(15);
  end;

function CarrierDetect : boolean;
var a : thandle;
  begin
    a := DoorGetOffLineEventHandle();
    Result :=  not (WaitForSingleObject(a, 0) = (WAIT_OBJECT_0+1));
    Sleep(15);
  end;

var
    User       : Tuser;
    done       : boolean;
    ch         : char;
    ich        : integer;

begin

 if Not DoorInitialize() then
    begin
      writeln('ERROR: Could not initialize door ',GetLastError);
      readln;
      halt;
    end;

  try
    WildcatLoggedIn(User);
    coln('Version: 2.0');
    coln(Format('Welcome to Doortest [%s] Node: %d',[User.Info.Name,GetNode()]));
    coln('Press a key or ESCAPE to quit: ');

    done := FALSE;
    while not done  do
      begin
        if (not CarrierDetect()) then break;
        while CharReady() do begin
           while (DoorRead(@ch, 1) > 0) do begin
              done := ch = #27;
              if (not done) then
                 begin
                   ich := ord(ch);
                   //coln(format('%02X %03d %c',[ich,ich,ch]));
                   //coln(format('%02X %03d %c',[ich,ich,ch]));
                   coln(format('%02X %03d',[ich,ich]));
                   //co(ch);
                 end;
           end;
        end;
      end;

  finally
    coln('Returning to bbs..');
    DoorShutdown();
  end;
end.

