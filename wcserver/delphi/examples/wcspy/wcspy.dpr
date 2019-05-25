//{$APPTYPE CONSOLE}
{$HINTS OFF}
{$H+,O+,A-}
program WcSpy;

uses
  Windows,
  Forms,
  wcServer,
  SpyUnit,
  AddUser,
  Globals,
  FileIO,
  wctype,
  ListUser;

{$R *.RES}

// This is the call back function that wcSERVER calls when it has a message for
// us, the routine then sends the messgae to our main window form where it is
// handled by the WcNotify procedure.

function CallBackFunc(UserData: DWord; const Msg : TChannelMessage) : DWord; stdcall;
begin
  SendMessage(UserData, WM_WCNOTIFY, 0, LongInt(@msg));
end;

// When writing Delphi apps this is the best place to create and delete
// your server context, that way no matter how your program exits it will
// always get back to this part of the code and exit cleanly, instead of
// leaving resources open.

begin
  Application.Initialize;
  if not WildcatServerConnect(0) then     // Create Wildcat Context
    Halt;
  if not WildcatServerCreateContext then  // Create Wildcat Server Context
    begin
      MessageBox(0, 'Error Creating Server Context', 'wcSPY', MB_OK);
      Halt;
    end;
  if not LoginSystem then                 // Login As A System Util
    begin
      MessageBox(0, 'Could not log in to server', 'wcSPY', MB_OK);
      Halt;
    end;
  // To Setup the callback we must create our form first
  Application.CreateForm(TForm1, Form1);
  // now we can open our channel with the server and point it to the
  // main window form.
  SystemControlHandle := OpenChannel('System.Control');
  SetupWildcatCallback(Callbackfunc, Form1.Handle);
  Application.Title := 'wcSPY v1.0B';
  Application.CreateForm(TTNewUser, TNewUser);
  Application.CreateForm(TUserListForm, UserListForm);
  SpyLog('Starting WCSPY');

  Application.Run;
  // When we are finished we always close the server context
  WildcatServerDeleteContext;
end.
