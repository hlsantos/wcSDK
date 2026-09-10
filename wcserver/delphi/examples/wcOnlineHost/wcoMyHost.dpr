library wcoMyHost;

uses
  Windows,
  WconlineModule in 'WconlineModule.pas',
  wcoMyHostImpl in 'wcoMyHostImpl.pas';

{$R *.RES}

exports
  // these two MUST match GetProcAddress() calls in wcOnline.cpp
  WcOnlineGetModule   name '_WcOnlineGetModule@0',
  CheckWildcatBuild   name '_CheckWildcatBuild@0',

  // these are undecorated in the header (C exports)
  CheckWildcatBuildEx name 'CheckWildcatBuildEx',
  GetModuleServiceName name 'GetModuleServiceName';

begin
end.
