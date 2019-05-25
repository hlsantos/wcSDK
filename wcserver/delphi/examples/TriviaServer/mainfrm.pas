unit mainfrm;

{$I+}

interface

uses
  Windows,
  Messages,
  SysUtils,
  Classes,
  Graphics,
  Controls,
  Forms,
  Dialogs,
  StdCtrls,
  WinSock, ExtCtrls;

type
  TForm1 = class(TForm)
    GroupBox1: TGroupBox;
    Button1: TButton;
    Label1: TLabel;
    Connections: TLabel;
    Label2: TLabel;
    ServerName: TLabel;
    Label3: TLabel;
    IPAddress: TLabel;
    UpdateTimer: TTimer;
    procedure Button1Click(Sender: TObject);
    procedure FormActivate(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure OnUpdateTimer(Sender: TObject);
  private
    ListenSocket : TSocket;
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

Uses
//  TextFile,
  TrvSrvr,
  Globals,
  WcType,
  WcServer;

{$R *.DFM}

function itoa(const n : integer) : string;
var
  s : String;
begin
  Str(n, s);
  result := s;
end;

function atoi(const s : pchar) : integer;
var
  n : integer;
  c : integer;
begin
  Val(s, n, c);
  result := n;
end;

///////////////////////////////////////////////////////////////////////////////

procedure TForm1.Button1Click(Sender: TObject);
begin
  Close;
end;

procedure TForm1.FormActivate(Sender: TObject);
VAR
  wsData       : TWSAData;
  sin          : TSockAddrIn;
  sinlen       : integer;
  Service      : TWildcatService;
  listenSocket : TSocket;
  THID         : DWORD;
  ComputerName : array[0..MAX_COMPUTERNAME_LENGTH] of char;
begin
  Application.Minimize;
  ServerName.Caption := '';
  IPAddress.Caption  := '';
  Connections.Caption := '0';

  AssignFile(DataFile, 'wcTrivia.dat');
  Reset(DataFile);
  if (IoResult <> 0) then
    begin
      Application.MessageBox('Unable to open wcTrivia.dat', 'Wildcat! Trivia Service', MB_OK or MB_ICONHAND);
      Close;
    end
  else
    begin
      InitializeCriticalSection(DataFileMutex);
    end;

  if (WSAStartUp($101, wsData) <> 0) then begin
    Application.MessageBox('Unable to initialize WinSock', 'Wildcat! Trivia Service', MB_OK or MB_ICONHAND);
    Close;
  end;

  listenSocket := socket(AF_INET, SOCK_STREAM, 0);
  sin.sin_family := PF_INET;
  sin.sin_addr.s_addr := INADDR_ANY;
  sin.sin_port := 0;
  bind(listenSocket, sin, sizeof(sin));
  sinlen := sizeof(sin);
  getsockname(listenSocket, sin, sinlen);

  if GetConnectedServer(ComputerName, sizeof(ComputerName)) then begin
    FillChar(Service, sizeof(Service), 0);
    Service.Name := 'wcTrivia Service';
    Service.Vendor := 'Santronics Software, Inc.';
    Service.Version := 1;
    Service.Port := ntohs(sin.sin_port);
    RegisterService(Service);
    ServerName.Caption := ComputerName;
    IPAddress.Caption  := strpas(inet_ntoa(TInAddr(Service.Address)))+':'+itoa(ntohs(sin.sin_port));
    BeginThread(nil, 0, @ListenThread, pointer(ListenSocket), 0, THID);
  end else begin
    ServerName.Caption := '<None>';
    IPAddress.Caption  := 'Port '+itoa(ntohs(sin.sin_port));
    BeginThread(nil, 0, @ListenThread, pointer(ListenSocket), 0, THID);
  end;
end;

procedure TForm1.FormClose(Sender: TObject; var Action: TCloseAction);
var
  s : TSocket;
begin
  s := InterlockedExchange(integer(ListenSocket), INVALID_SOCKET);
  if (s <> INVALID_SOCKET) then begin
    CloseSocket(s);
  end;
  WSACleanUp();

  CloseFile(DataFile);
  if (IoResult <> 0) then begin
    // do nothing
  end;
  DeleteCriticalSection(DataFileMutex);

{  if (DataFile.IsOk) then begin
    DataFile.CloseHandle;
    DeleteCriticalSection(DataFileMutex);
  end; }
end;

procedure TForm1.OnUpdateTimer(Sender: TObject);
begin
  Connections.Caption := itoa(ActiveConnections);
end;

end.
