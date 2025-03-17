program wcDoorAnsiExample;

{$APPTYPE CONSOLE}

uses
  SysUtils,
  wcdoor32,
  wcserver,
  wctype,
  wcserror,
  AnsiTerm;

var result : byte;

begin
  if not wcDoorInitialize then
  begin
    Writeln('Door initialization failed.');
    Exit;
  end;

  ClrScr;
  TextBold;
  SetFgColor(2); // Green text
  coln('Welcome to ANSI Terminal Demo!'#13#10);

  TextReset;
  coln('Press any key to continue...'#13#10);

  while wcDoorEvent(1000 * 60) <> WCDOOR_EVENT_KEYBOARD do;

  ClrScr;
  GotoXY(10,5);
  TextUnderline;
  SetFgColor(1); // Red
  coln('This is an example positioned at (10,5).');
  TextReset;

  GotoXY(1,7);
  coln('Press ESC to exit.'#13#10);

  repeat until (wcDoorEvent(1000) = WCDOOR_EVENT_KEYBOARD) and
               (wcDoorRead(@Result, 1) = 1) and (Result = 27);

  ClrScr;
  coln('Returning to BBS...'#13#10);
  wcDoorShutdown;
end.
