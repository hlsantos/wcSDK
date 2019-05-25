program wcsrvmon;

uses
  Forms,
  monwnd in 'monwnd.pas' {SrvMonForm},
  wcserver,
  wcSrvMonAboutMe in 'wcSrvMonAboutMe.pas' {FormAboutBox};

{$R *.RES}

begin
  Application.Initialize;
  Application.Title := 'Wildcat! Server Monitor';
  if not WildcatServerConnect(0) or not WildcatServerCreateContext or not LoginSystem then begin
    exit;
  end;
  Application.CreateForm(TSrvMonForm, SrvMonForm);
  Application.Run;
  WildcatServerDeleteContext;
end.
