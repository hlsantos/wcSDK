{$APPTYPE CONSOLE}
{$H+,O+,A-}
Uses wcserver,
     Windows,
     SysUtils;

type
  TPageMessage = record
    From  : Array[0..27] of char;
    Text  : Array[1..3] of Array[0..79] of char;
    InviteToChat : LongInt;
  end;

Var
   pmsg  : TPageMessage;

(*
Procedure ShowServerLoginError(const err : integer);
var note : string;
  begin
    MessageBeep(0);
    note := 'Check to see if WCSERVER is loaded';
    case err of
      WC_INCORRECT_PASSWORD:
        note := 'Check System Password';
    end;

    Writeln('Wilcat! Server Login Failure');
    writeln(Format('Server Error (%8X) %s'#13#13,[err,GetWildcatErrorStr(err)]));
    writeln(Note);
  end;
*)

Function ParamLineRaw:String;
(* return the entire command line minus program name *)
begin
  ParamLineRaw := '';
  if pos(' ',CmdLine) = 0 then exit;
  ParamLineRaw := Copy(CmdLine,Pos(' ',Cmdline)+1,length(cmdline));
end;


Begin
  if ParamCount=0 then
     begin
       writeln('wcYell v8.0 (c) copyright 1998-2019 Santronics Software');
       writeln('syntax: wcYell <broadcast message>');
       writeln;
       writeln('wcYell will broadcast a message to all nodes. The maximum');
       writeln('length of the message is 78 characters');
       writeln;
       writeln('example: wcYell Please Log off! System Maintenance begins in 1 min');
       exit;
     end;

  if not WildcatServerConnect(0) then
     begin
       //ShowServerLoginError(GetLastError());
       exit;
     end;

  try
     if not WildcatServerCreateContext() then
        begin
          //ShowServerLoginError(GetLastError());
          writeln('Error Wildcat! Create Context Error: ',GetLastError());
          exit;
        end;

     LoginSystem();

     fillchar(pmsg,sizeof(pmsg),#0);
     pmsg.From := 'SYSOP';
     strPcopy(pmsg.Text[1],copy(ParamLineRaw,1,78));

     WriteChannel(wcserver.OpenChannel('System.Page'),
                   0,
                   0,
                   @pmsg,
                   sizeof(pmsg));
  finally
     WildcatServerDeleteContext();
  end;

End.
