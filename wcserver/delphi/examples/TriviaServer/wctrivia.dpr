program wcTrivia;

uses
  Forms,
  wcserver in 'wcserver.pas',
  Windows,
  mainfrm in 'mainfrm.pas' {Form1},
  spserver in 'Spserver.pas',
  Globals in 'Globals.pas',
  TrvSrvr in 'TrvSrvr.pas';

{$R *.RES}

begin
  if not WildcatServerConnect(0) then
    begin
      Application.MessageBox('Could not connect to server', '', mb_OK);
      Halt;
    end;

  if not WildcatServerCreateContext then
    begin
      Application.MessageBox('Could not create server context', '', mb_OK);
      Halt;
    end;

  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
  WildcatServerDeleteContext;
end.
