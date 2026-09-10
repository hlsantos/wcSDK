program testMyHost;

{$APPTYPE CONSOLE}
{$H+,O+,A-}

uses
  Windows,
  SysUtils,
  wctype,
  wcserver,
  wcserror;

const
  SERVICE_NAME = 'MYHOST'; // what you'll see in wcNode as the Server name

var
  SystemControlServerChannel: THandle;

function ServerStateToStr(State: DWORD): string;
begin
  case State of
    SERVERSTATE_UP:     Result := 'UP';
    SERVERSTATE_REFUSE: Result := 'REFUSE';
    SERVERSTATE_DOWN:   Result := 'DOWN';
  else
    Result := 'UNKNOWN(' + IntToStr(State) + ')';
  end;
end;

// IMPORTANT:
// Match the callback signature expected by SetupWildcatCallback() in your wcserver.pas.
// Your existing SimpleService.pas uses: function (UserData: DWORD; const Msg: TChannelMessage): DWORD; stdcall;
// So we keep that exact signature here.
function ChannelCallback(UserData: DWORD; const Msg: TChannelMessage): DWORD; stdcall;
var
  server: PChar;
begin
  Result := 0;

  if Msg.Channel <> SystemControlServerChannel then
    Exit;

  // In the C loader, msg->Data is treated as a C string "server" :contentReference[oaicite:2]{index=2}
  server := PChar(@Msg.Data[0]);

  Writeln(Format('[System.Control.Server] state=%s  server="%s"',
    [ServerStateToStr(Msg.UserData), string(server)]));

  // If you want to "ack" by setting your own server state to what was requested,
  // you can do it here. (Optional)
  //
  // Example:
  // SetServerState(SERVICE_NAME, Msg.UserData);
end;

procedure FailAndExit(const What: string);
begin
  Writeln('ERROR: ', What, '  GetLastError=$', IntToHex(GetLastError, 8));
  Halt(1);
end;

begin
  try
    Writeln('testMyHost starting...');

    if not WildcatServerConnect(0) then
      FailAndExit('WildcatServerConnect failed');

    if not WildcatServerCreateContext then
      FailAndExit('WildcatServerCreateContext failed');

    if not SetupWildcatCallback(ChannelCallback, 0) then
      FailAndExit('SetupWildcatCallback failed');

    SystemControlServerChannel := OpenChannel('System.Control.Server');
    if SystemControlServerChannel = 0 then
      FailAndExit('OpenChannel("System.Control.Server") failed');

    // Make us visible in wcNode right away.
    SetServerState(SERVICE_NAME, SERVERSTATE_UP);

    Writeln('Watching channel: System.Control.Server');
    Writeln('Service name: ', SERVICE_NAME);
    Writeln('Press ESC to quit.');

    // Simple loop. (No CRT needed; avoids kbhit portability issues.)
    while True do
    begin
      Sleep(50);
      if (GetAsyncKeyState(VK_ESCAPE) and $8000) <> 0 then
        Break;
    end;

    // Clean shutdown
    SetServerState(SERVICE_NAME, SERVERSTATE_DOWN);
    CloseChannel(SystemControlServerChannel);
    WildcatServerDeleteContext();

    Writeln('Done.');
  except
    on E: Exception do
    begin
      Writeln('EXCEPTION: ', E.ClassName, ': ', E.Message);
      Halt(2);
    end;
  end;
end.
