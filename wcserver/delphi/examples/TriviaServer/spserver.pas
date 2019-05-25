unit spserver;
interface
{$R-}

uses
  WinSock,
  Windows;

const
  spsLF   = 10;
  spsCR   = 13;
  spsDM   = 242;
  spsWILL = 251;
  spsWONT = 252;
  spsDO   = 253;
  spsDONT = 254;
  spsIAC  = 255;

type
  TSimpleProtocolServer = class
  public
    constructor Create(s : TSocket);
    procedure Execute;
  protected
    function DispatchCommand(s : pchar): BOOL; virtual; abstract;
  protected
    Socket : TSocket;
    procedure SendWelcome; virtual;
    function PreProcessLine(s : pchar): BOOL; virtual;
    procedure Cleanup; virtual;
    procedure SendString(s : string);
  private
    function GetCommand(s : pchar; len : DWORD): BOOL;
  end;

implementation

constructor TSimpleProtocolServer.Create(s : TSocket);
begin
  inherited Create;
  Socket := s;
end;

procedure TSimpleProtocolServer.Execute;
var
  cmdline : array[0..1023] of char;
begin
  SendWelcome;
  while (GetCommand(cmdline, sizeof(cmdline)) = TRUE) do begin
    if (not PreProcessLine(cmdline)) then begin
      if (cmdline[0] > char(0)) then begin
        if (DispatchCommand(cmdline) = FALSE) then begin
          SendString('500 '+cmdline+': command not understood');
        end;
      end;
    end;
  end;
  Cleanup;
end;

procedure TSimpleProtocolServer.SendWelcome;
begin
  // do nothing
end;

function TSimpleProtocolServer.PreProcessLine(s : pchar) : BOOL;
begin
  PreProcessLine := FALSE;
end;

procedure TSimpleProtocolServer.Cleanup;
begin
  // do nothing
end;

function TSimpleProtocolServer.GetCommand(s : pchar; len : DWORD): BOOL;
var
  i : DWORD;
  lastIAC : BOOL;
  t : array[0..1] of BYTE;
begin
  i := 0;
  lastIAC := FALSE;
  while (i < len) do begin
    if (recv(Socket, s[i], 1, 0) <= 0) then begin
      GetCommand := FALSE;
      exit;
    end;
    if (lastIAC) then begin
      t[0] := spsIAC;
      case (BYTE(s[i])) of
        spsWILL..spsWONT:
          begin
            t[1] := spsDONT;
            send(Socket, t, 2, 0);
          end;
        spsDO .. spsDONT:
          begin
            t[1] := spsWONT;
            send(Socket, t, 2, 0);
          end;
       end;
    end else begin
      case (BYTE(s[i])) of
        spsCR:
          begin
            s[i] := char(0);
            GetCommand := TRUE;
            exit;
          end;
        spsLF: ; // do nothing
        spsDM: ; // do nothing
        spsIAC: LastIAC := TRUE;
        else begin
          inc(i);
        end;
      end;
    end;
  end;
  s[i] := char(0);
  GetCommand := TRUE;
end;

procedure TSimpleProtocolServer.SendString(s : string);
var
  CrLf : array[0..1] of BYTE;
begin
  CrLf[0] := spsCR;
  CrLF[1] := spsLF;
  Send(Socket, s[1], length(s), 0);
  Send(Socket, CrLf, 2, 0);
end;
end.
