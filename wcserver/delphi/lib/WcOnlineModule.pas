unit WconlineModule;

interface

{$A-}  // no alignment padding

uses
  Windows;

type
  // Opaque type for now
  PLineStatusManager = Pointer;

  PWconlineModule = ^TWconlineModule;

  // C++ virtual table shape (MSVC):
  //   ECX = this (Self)
  //   args on stack
  // So these function types do NOT include Self as a parameter.
  TWconlineModuleVTable = packed record
    Initialize    : function(sm: PLineStatusManager): BOOL; stdcall;
    StartServer   : function(server: PChar): BOOL; stdcall;
    DisableServer : function(server: PChar): BOOL; stdcall;
    StopServer    : function(server: PChar): BOOL; stdcall;
    Shutdown      : function: BOOL; stdcall;
  end;
  PWconlineModuleVTable = ^TWconlineModuleVTable;

  // C++ object layout: first field is vptr
  TWconlineModule = packed record
    VTable: PWconlineModuleVTable;
  end;

implementation

end.
