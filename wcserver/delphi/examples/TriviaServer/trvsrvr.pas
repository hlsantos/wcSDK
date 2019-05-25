unit TrvSrvr;

interface

Uses
  WinSock;

function ListenThread(s : TSocket) : integer;

implementation

Uses
  Globals,
  Windows,
  SysUtils,
  SpServer;

function GetTriviaQuestion(index : integer; var s : String) : BOOL;
var
  SetEOF : BOOL;
Begin
  result := FALSE;
  SetEOF := FALSE;
  EnterCriticalSection(DataFileMutex);
  while (TRUE) do begin
    if EoF(DataFile) then begin
      if (not SetEOF) then begin
        SetEOF := TRUE;
        CloseFile(DataFile);
        Assign(DataFile, 'wctrivia.dat'); // hack!!!
        Reset(DataFile);
        if IoResult <> 0 then ;
      end else begin
        result := FALSE;
        break;
      end;
    end;
    ReadLn(DataFile, S);
    if (IoResult = 0) and (Length(S) > 0) and (S[1] <> ';') then begin
      result := TRUE;
      break;
    end;
  end;
  LeaveCriticalSection(DataFileMutex);
End;

// TTriviaServer

const Version : String = '1.00';

type
  TTriviaServer = class(TSimpleProtocolServer)
  public
    constructor Create(s : TSocket);
  protected
    procedure SendWelcome; override;
    function DispatchCommand(s : pchar): BOOL; override;
  protected
    function tsBYE: BOOL;
    function tsUSER(s : pchar): BOOL;
    function tsVER: BOOL;
    function tsNEXT: BOOL;
  end;

constructor TTriviaServer.Create(s : TSocket);
begin
  inherited Create(s);
end;

procedure TTriviaServer.SendWelcome;
begin
  SendString('220-Welcome to the Wildcat! Trivia Service');
  SendString('220-Copyright (c) 1996-2004, Santronics Software, Inc. All rights reserved.');
  SendString('220-This is an example of a Wildcat! Trivia Service. This service');
  SendString('220-demonstrates how a Wildcat! Service can be used to provide');
  SendString('220-specific information to callers using a dialup or telnet terminal');
  SendString('220 connection, Dynamic HTML, or the Wildcat! Navigator.');
end;

function TTriviaServer.DispatchCommand(s : pchar): BOOL;
begin
  if (StrLIComp(s, 'BYE', 3) = 0) then begin
    DispatchCommand := tsBYE; exit;
  end else
  if (StrLIComp(s, 'NEXT', 4) = 0) then begin
    DispatchCommand := tsNEXT; exit;
  end else
  if (StrLIComp(s, 'USER', 4) = 0) then begin
    DispatchCommand := tsUSER(nil); exit;
  end else
  if (StrLIComp(s, 'VER', 3) = 0) then begin
    DispatchCommand := tsVER; exit;
  end;
  DispatchCommand := FALSE;
end;

function TTriviaServer.tsBYE: BOOL;
begin
  SendString('221 Goodbye');
  closesocket(socket);
  tsBYE := TRUE;
end;

function TTriviaServer.tsNEXT: BOOL;
var
  S : String;
begin
  if (GetTriviaQuestion(0, s)) then begin
    SendString('200 '+S);
  end else begin
    SendString('500 Error');
  end;
  tsNEXT := TRUE;
end;

function TTriviaServer.tsUSER(s : pchar): BOOL;
begin
  SendString('230 User logged in successfully.');
  tsUSER := TRUE;
end;

function TTriviaServer.tsVER: BOOL;
begin
  SendString('200 wcTriva Version '+Version);
  tsVER := TRUE;
end;

// TriviaThread

function TriviaThread(s : TSocket) : integer;
var
  Server : TTriviaServer;
begin
  //MessageBox(0, 'Starting Thread', '', mb_OK);
  InterlockedIncrement(integer(ActiveConnections));
  Server := TTriviaServer.Create(s);
  Server.Execute;
  Server.Destroy;
  closesocket(s);
  InterlockedDecrement(integer(ActiveConnections));
  result := 0;
end;

// ListenThread

function ListenThread(s : TSocket) : integer;
var
  sin          : TSockAddrIn;
  sinlen       : integer;
  acceptSocket : TSocket;
  THID         : DWORD;
begin
  listen(s, 5);
  while (TRUE) do begin
    sinlen := sizeof(sin);
    acceptSocket := accept(s,
                           @sin,
                           @sinlen);
    BeginThread(nil, 0, @TriviaThread, pointer(acceptSocket), 0, THID);
  end;
end;

end.
