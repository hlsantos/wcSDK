unit wcoMyHostImpl;

interface

{$A-}
{$H+}

uses
  Windows, SysUtils, wcserver, wctype, WconlineModule;

function WcOnlineGetModule: PWconlineModule; stdcall;
function CheckWildcatBuild: Integer; stdcall;
function CheckWildcatBuildEx: Integer; stdcall;
function GetModuleServiceName: PChar; stdcall;

implementation

const
  // wcOnline expected this in your popup
  WILDCAT_FRAMEWORK_BUILD = 500;

type
  PMyModule = ^TMyModule;
  TMyModule = packed record
    Base: TWconlineModule;  // vptr must be first
    StatusManager: Pointer;
    ListenThread: THandle;
    ListenFlag: BOOL;
  end;

var
  GModule: TMyModule;

const
  // Guaranteed null-terminated ANSI C-string
  MODSERVICE_BUF: array[0..6] of Char = ('M','Y','H','O','S','T',#0);

function ModServiceP: PChar;
begin
  Result := @MODSERVICE_BUF[0];
end;

Const crlf     : string[5] = #13#10;

//procedure Dbg(const S: PChar);
procedure Dbg(const S: string);
begin
  OutputDebugString(pchar(S+crlf));
end;


function HexPtr(p: Pointer): string;
begin
  Result := IntToHex(Integer(p), 8);
end;

// Safe conversion of PChar to string without StrPas blowing up on bad pointers
function SafePCharToString(p: PChar): string;
var
  n: Integer;
begin
  if p = nil then
  begin
    Result := '(nil)';
    Exit;
  end;

  // avoid runaway if pointer is bad or not terminated
  // lstrlen will AV on truly invalid pointers; you can wrap in try/except
  try
    n := lstrlenA(p);
    if n > 128 then n := 128; // cap for logging
    SetString(Result, p, n);
  except
    Result := '(bad ptr)';
  end;
end;

function SameService(server: PChar): BOOL;
var
  s: string;
begin
  s := 'SameService: serverPtr=$' + HexPtr(server) +
       ' server="' + SafePCharToString(server) +
       '" MODSERVICE="' + SafePCharToString(ModServiceP) + '"';
  Dbg(s);

  if server = nil then
  begin
    Result := FALSE;
    Exit;
  end;

  Result := (lstrcmpiA(server, ModServiceP) = 0);
end;

//
// REAL IMPLEMENTATIONS (explicit Self)
//


function StartServer_Impl(Self: Pointer; server: PChar): BOOL; stdcall;
var
  M: PMyModule;
begin
  Dbg('StartServer_Impl: Self=$' + HexPtr(Self) +
      ' serverPtr=$' + HexPtr(server) +
      ' server="' + SafePCharToString(server) + '"');

  if not SameService(server) then
  begin
    Result := FALSE;
    Exit;
  end;

  M := PMyModule(Self);

  if M^.ListenThread <> 0 then
  begin
    SetServerState(server, SERVERSTATE_UP);
    Dbg('StartServer_Impl ListThread <> 0');
    Result := TRUE;
    Exit;
  end;

  SetServerState(server, SERVERSTATE_UP);

  M^.ListenFlag := TRUE;
  M^.ListenThread := 1; // sentinel
  Dbg('StartServer_Impl complete');
  Result := TRUE;
end;

function Initialize_Impl(Self: Pointer; sm: PLineStatusManager): BOOL; stdcall;
var
  M: PMyModule;
begin
  Dbg('Initialize_Impl: Self=$' + HexPtr(Self));
  M := PMyModule(Self);
  M^.StatusManager := sm;

  // IMPORTANT: Do NOT call through the vtable from Delphi.
  // Call the Impl directly.
  Result := StartServer_Impl(Self, ModServiceP);
end;

function DisableServer_Impl(Self: Pointer; server: PChar): BOOL; stdcall;
begin
  Dbg('DisableServer_Impl: server="' + SafePCharToString(server) + '"');

  if not SameService(server) then
  begin
    Result := FALSE;
    Exit;
  end;

  SetServerState(server, SERVERSTATE_REFUSE);

  Result := TRUE;
end;

function StopServer_Impl(Self: Pointer; server: PChar): BOOL; stdcall;
var
  M: PMyModule;
begin
  Dbg('StopServer_Impl: server="' + SafePCharToString(server) + '"');

  if not SameService(server) then
  begin
    Result := FALSE;
    Exit;
  end;

  M := PMyModule(Self);
  M^.ListenFlag := FALSE;
  M^.ListenThread := 0;
  SetServerState(server, SERVERSTATE_DOWN);

  Result := TRUE;
end;

function Shutdown_Impl(Self: Pointer): BOOL; stdcall;
begin
  Dbg('Shutdown_Impl');

  // IMPORTANT: do NOT go through vtable from Delphi
  Result := StopServer_Impl(Self, ModServiceP);
end;

//
// THUNKS (vtable targets) : MSVC thiscall (ECX=this) -> stdcall(Self,...)
//

function Thunk_Initialize(sm: PLineStatusManager): BOOL; stdcall;
var
  SelfPtr: Pointer;
begin
  asm
    mov SelfPtr, ecx
  end;
  Result := Initialize_Impl(SelfPtr, sm);
end;

function Thunk_StartServer(server: PChar): BOOL; stdcall;
var
  SelfPtr: Pointer;
begin
  asm
    mov SelfPtr, ecx
  end;
  Result := StartServer_Impl(SelfPtr, server);
end;

function Thunk_DisableServer(server: PChar): BOOL; stdcall;
var
  SelfPtr: Pointer;
begin
  asm
    mov SelfPtr, ecx
  end;
  Result := DisableServer_Impl(SelfPtr, server);
end;

function Thunk_StopServer(server: PChar): BOOL; stdcall;
var
  SelfPtr: Pointer;
begin
  asm
    mov SelfPtr, ecx
  end;
  Result := StopServer_Impl(SelfPtr, server);
end;

function Thunk_Shutdown: BOOL; stdcall;
var
  SelfPtr: Pointer;
begin
  asm
    mov SelfPtr, ecx
  end;
  Result := Shutdown_Impl(SelfPtr);
end;
var
  GVTable: TWconlineModuleVTable =
  (
    Initialize    : Thunk_Initialize;
    StartServer   : Thunk_StartServer;
    DisableServer : Thunk_DisableServer;
    StopServer    : Thunk_StopServer;
    Shutdown      : Thunk_Shutdown
  );

procedure EnsureInit;
begin
  if GModule.Base.VTable = nil then
  begin
    FillChar(GModule, SizeOf(GModule), 0);
    GModule.Base.VTable := @GVTable;
  end;
end;

//
// EXPORTS
//

function WcOnlineGetModule: PWconlineModule; stdcall;
begin
  EnsureInit;
  Dbg('WcOnlineGetModule: modulePtr=$' + HexPtr(@GModule.Base) +
      ' vtblPtr=$' + HexPtr(GModule.Base.VTable));
  Result := @GModule.Base;
end;

function CheckWildcatBuild: Integer; stdcall;
begin
  Result := WILDCAT_FRAMEWORK_BUILD;
end;

function CheckWildcatBuildEx: Integer; stdcall;
begin
  Result := WILDCAT_FRAMEWORK_BUILD;
end;

function GetModuleServiceName: PChar; stdcall;
begin
  Result := ModServiceP;
end;

initialization
  EnsureInit;

end.
