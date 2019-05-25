//Here is an example console (not gui) chat monitor.  All it does
//is display all chatting in the main chat channel.  It also
//has an example of using a Control Break call back so that
//you can control-c out of the wait loop.  In a GUI, you won't
//need a Control Break handler. Just use a close button. :-)

Program ChatMonitor;
{$APPTYPE CONSOLE}
{$H+,O+,A-}
uses
   Wctype,
   WcServer,
   windows,
   sysutils;

type TChatMessage = record
  From    : array[0..27] of char;
  stext   : array[0..255] of char;
  Whisper : bool;
end;

//
// Wildcat callback function handler for channels
//

function CallBackFunc(UserData: DWord;
                      const Msg : TChannelMessage) : DWord; stdcall;
var
  newmsg : ^TSystemPageNewMessage;
  cmsg   : ^TChatMessage;

begin
  writeln('--------------------');
  case msg.userdata of
    SP_USER_PAGE:
      begin
      end;
    SP_SYSOP_CHAT:
      begin
        cmsg := @msg.data;
        writeln('From: ',cmsg.from);
        writeln(cmsg.stext);
      end;
    SP_NEW_MESSAGE:
      begin
       newmsg := @msg.data;
       Writeln('Conference     : ',newmsg.Conference);
       Writeln('ConferenceName : ',newmsg.ConferenceName);
       Writeln('Id             : ',newmsg.Id);
       Writeln('From           : ',newmsg.From.name);
       Writeln('Subject        : ',newmsg.Subject);
      end;
  end;
  result := 0;
end;

//
// Control-Break/C Handler
//

Const Quit : boolean = false;

function zControlHandlerRoutine(dwCtrlType : dword):boolean; stdcall;
begin
   result := false;
   case dwCtrlType of
      CTRL_C_EVENT,
      CTRL_BREAK_EVENT,
      CTRL_CLOSE_EVENT,
      CTRL_LOGOFF_EVENT,
      CTRL_SHUTDOWN_EVENT:
         begin
           writeln('*** break ***');
           result := true;
           Quit := true;
         end;
   end;
end;

var hSystemControl : Thandle;

Begin

  //
  // Establish connection with Wildcat Server
  //

  if Not WildcatServerConnect(0) then exit;
  if Not WildcatServerCreateContext then exit;

  //
  // Prepare control-c (break) handler
  //

  SetConsoleCtrlHandler(@zControlHandlerRoutine,TRUE);

  try

    //
    // Prepare Wildcat Channel Callback.  If this was
    // a GUI, pass the main window handle as the second
    // parameter. Then in the call back, you would use
    // the window handle to display the data using
    // SendMessage().
    //

    if not SetupWildcatCallback(@Callbackfunc, 0) then
       begin
         writeln('Error Creating Callback: ',IntToHex(GetlastError(),8));
         exit;
       end;

     //
     // Open the main chat channel "chat.0".
     //

     hSystemControl := Wcserver.OpenChannel('chat.0');

     if hSystemControl = 0 Then
        begin
          writeln('Error opening channel: ',IntToHex(GetlastError(),8));
          exit;
        end;

     //
     // Ok, channel is open. Go into idle mode here, sleeping
     // every 75 msecs. The Channel Callback will get all
     // the messages from the server.  The Quit is set by
     // hitting control-c allowing for a graceful disconnect
     // and shutdown of this application.
     //

     writeln('Channel Open : ',hSystemControl);
     while Not Quit do Sleep(75);

     wcserver.CloseChannel(hSystemControl);
  finally
     WildcatServerDeleteContext;
  end;

End.

