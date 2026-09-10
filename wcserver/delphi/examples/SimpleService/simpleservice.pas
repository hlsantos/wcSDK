Program SimpleService;

{$APPTYPE CONSOLE}
{$H+,O+,A-}
uses
   wctype,
   wcserver,
   wcserror,
   windows,
   sysutils;

var SystemControlServerChannel : Thandle;

function ChannelCallBack(UserData: DWORD;
                         const Msg : TChannelMessage) : DWord; stdcall;
begin
  if (msg.Channel = SystemControlServerChannel) then
      begin
        case (msg.UserData) of
          SERVERSTATE_DOWN:
            SetServerState('MYAPP',SERVERSTATE_DOWN);
          SERVERSTATE_REFUSE:
            SetServerState('MYAPP',SERVERSTATE_REFUSE);
          SERVERSTATE_UP:
            SetServerState('MYAPP',SERVERSTATE_UP);
        end;
      end;
  result := 0;
end;

var line : string;

Begin
  if Not WildcatServerConnect(0) then exit;
  if Not WildcatServerCreateContext then exit;

  if (not SetupWildcatCallback(ChannelCallback, 0)) then
     begin
       writeln('Error ',IntToHex(GetlastError(),8),' Creating CallBack');
       exit;
     end;

  SystemControlServerChannel := wcserver.OpenChannel('System.Control.Server');
  SetServerState('MYAPP', SERVERSTATE_UP);

  While (True) do
    begin
      writeln('type quit to exit');
      readln(line);
      if (uppercase(line) = 'QUIT') then break;
    end;

  wcserver.CloseChannel(SystemControlServerChannel);
  WildcatServerDeleteContext();

End.

