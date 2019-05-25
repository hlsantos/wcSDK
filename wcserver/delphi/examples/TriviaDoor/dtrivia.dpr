{$APPTYPE CONSOLE}

program DTrivia;

uses
  Windows,
  WinSock,
  SysUtils,
  WcDoor32,
  wctype,
  wcserver;

const
  CRLF   = #13+#10;
  MAXBUF = 1024;

type
  TBuffer = array[0..1024] of Byte;

var
  UserRec : TUser;
  Sckt    : TSocket;
  Handle  : PWOHandleArray;

procedure SendLine(S : String);
begin
  Write(S);
  DoorWrite(PChar(S), Length(S));
end;

function Long2Str(L : LongInt) : string;
var
  S : string;

begin
  SetLength(S, 40);
  Str(L, S);
  Long2Str := S;
end;

function SendServiceText(Text : String) : Boolean;
var
  Status : LongInt;

begin
  SendServiceText := True;
  Text := Text + CRLF;
  Status := Send(Sckt, Text[1], Length(Text), 0);
  if (Status < Length(Text)) or (Status = SOCKET_ERROR) then
    begin
      SendServiceText := False;
      WriteLn('Error sending to service');
    end;
end;

// This function attempts to get a string from the receive buffer, if it gets
// a string it moves the end of the buffer (EOB) and returns true, it returns
// false when it does not get the end of the string and leaves the buffer intact.

function ExtractLine(var Buffer : TBuffer; var EOB : LongInt; var Line : String) : Boolean;
var
  Count : Word;

begin
  ExtractLine := False;
  Line := '';
  Count := 0;
  if EOB = 0 then
    Exit;
  repeat
    Line := Line + Chr(Buffer[Count]);
    if Buffer[Count] = 10 then
      begin
        Dec(EOB, Count+1);
        if EOB > 0 then
          Move(Buffer[Count+1], Buffer[0], EOB);
        ExtractLine := True;
        break;
      end;
    Inc(Count);
  until (Count > EOB);
end;

// This function fills the buffer with data received from the socket.

function FillBuffer(var Buffer : TBuffer; var EOB : LongInt) : Boolean;
var
  Status : Word;
  slist  : Tfdset;
  tv     : TTimeVal;

begin
  FillBuffer := False;
  slist.fd_count := 1;
  slist.fd_array[0] := Sckt;
  tv.tv_sec := 1;
  tv.tv_usec := 0;
  if select(0, @slist, nil, nil, @tv) > 0 then
    begin
      Status := Recv(Sckt, Buffer[EOB], MAXBUF-EOB, 0);
      if (Status > 0) and (Status <> SOCKET_ERROR) then
        begin
          Inc(EOB, Status);
          FillBuffer := True;
        end;
    end;
end;

// This routine removes the code from the line and determines if there is
// more text waiting.

procedure StripLine(var S : String; CodeNum : String; var More : Boolean);
begin
  CodeNum := Trim(Copy(S, 1, 3));
  More := S[4] = '-';
  S := Copy(S, 5, Length(S));
end;

// Since we are using sockects we get a stream of data, this data can come in
// any size packet, there are no guarantees on how many packes the information
// will come in. Because of this we do a a number of things: 1) We take whatever
// the socket sends and place it in a buffer where we can manipulate it. 2) we
// we check each line we get to see if more info is waiting. 3) we ALWAYS do one
// last check for info before exiting this routines, the ensures thay we will get
// all the sockect info before exiting.

procedure GetServiceText;
var
  EOB    : LongInt;
  More   : Boolean;
  Code,
  St     : String;
  Buffer : TBuffer;

begin
  SetLength(St, 100);
  EOB := 0;       // Set End Of Buffer
  More := False;  // Clear More Flag
  repeat
    if (EOB > 0) or FillBuffer(Buffer, EOB) then  // Check for EOB and if 0 Fill Buffer
      begin
        if ExtractLine(Buffer, EOB, St) then  // Pull Out Current Line Of Text
          begin
             StripLine(St, Code, More);  // Strip Line, Get Line Number Code and set The More Flag
             SendLine(St); // Send Line To User
          end
        else
          FillBuffer(Buffer, EOB);
      end;
  until (EOB = 0) and (not FillBuffer(Buffer, EOB)) and not More; // Check Flags For Exit Conditions
end;

function GetServiceTextLine(var Buffer : TBuffer; var EOB : LongInt; var Text : String; var More : Boolean) : Boolean;
var
  St     : String;
  Tries  : Word;

begin
  GetServiceTextLine := False;
  Text := '';
  Tries := 0;
  EOB := 0;
  repeat
    if (EOB > 0) or FillBuffer(Buffer, EOB) then
      begin
        if ExtractLine(Buffer, EOB, St) then
          begin
            Text := St;
            More := St[4] = '-';
            GetServiceTextLine := True;
          end
        else if EOB > 0 then
          FillBuffer(Buffer, EOB)
      end
    else
      begin
        Inc(Tries);
        Sleep(500);
      end
  until (Tries > 4) or (Text <> '');
end;

function GetServiceQuestion(var Answer, Question : String) : Boolean;
var
  St     : String;
  Buffer : TBuffer;
  EOB    : LongInt;
  More   : Boolean;
  Count  : Word;

begin
  GetServiceQuestion := False;
  SendServiceText('NEXT');      // Send Request For Question
  EOB      := 0;
  Answer   := '';
  More     := False;
  repeat
    if GetServiceTextLine(Buffer, EOB, St, More) then
      begin
        if More then
          SendLine(St)
        else
          begin
            Count := Pos('","', St);
            Question := Copy(St, 6, Count-6)+' ';
            Answer := Copy(St, Count+3, (Length(St)-Count)-5);
            GetServiceQuestion := True;
          end;
      end;
  until not More;
end;

// This routine gets a line of text from the user, it gets the line character
// by character.

function GetUserLine(var St : String) : Boolean;
var
  Ch      : Char;

begin
  GetUserLine := False;
  St := '';
  repeat
    Handle[0] := DoorGetAvailableEventHandle;
    Handle[1] := DoorGetOfflineEventHandle;
    case WaitForMultipleObjects(2, Handle, FALSE, INFINITE) of // Wait For Door Info Or Carrier Drop
       WAIT_OBJECT_0:         // Door Information
         begin
           DoorRead(Pchar(@ch), 1);
           if (Ch <> #13) and (Ch <> #10) then
             St := St + Ch;
           SendLine(Ch);
           GetUserLine := True;
         end;
       WAIT_OBJECT_0+1: Exit; // User Dropped Carrier
    end;
  until Ch = #13;
end;

function ReadYesNo : Boolean;
var
  St : String;
  Carrier : Boolean;

begin
  repeat
    Carrier := GetUserLine(St);
    if St = '' then
      St := 'N';
  until not Carrier or (UpCase(St[1]) = 'Y') or (UpCase(St[1]) = 'N');
  ReadYesNo := UpCase(St[1]) = 'Y';
end;

function OpenServiceByName(Name : String) : TSocket;
var
  Service : TWildcatService;
  Addr    : TSockAddrIn;
begin
  Result := INVALID_SOCKET;
  if GetServiceByName(PChar(Name), Service) then    // Find Wildcat Service
    begin
      FillChar(Addr, SizeOf(Addr), 0);          // Clear Address Stucture
      Addr.sin_family := AF_INET;               // Set Family Type
      Addr.sin_Port := htons(Service.Port);     // Reverse Port Number
      Addr.sin_addr.s_addr := Service.Address;  // Set Service Address
      Result := Socket(PF_INET, SOCK_STREAM, 0); // Create Socket
      if (Result <> INVALID_SOCKET) then
        begin
          if Connect(Result, Addr, SizeOf(Addr)) <> 0 then // Connect Socket to remote host
            Result := INVALID_SOCKET;
        end;
    end;
end;

var
  Answer,
  Hint,
  Question,
  UserLine : String;
  Count,
  HintIndex : Word;

begin
  if not DoorInitialize() then             // Start Door Communications
    begin
      WriteLn('Could not connect to Wildcat! Server');
      Sleep(10000);
      Halt;
    end;

  Sckt := OpenServiceByName('wcTrivia Service');
  if Sckt = INVALID_SOCKET then
    begin
      WriteLn('Error connecting to WCTRIVIA Server');
      DoorShutDown;
      Sleep(10000);
      Halt;
    end;

  GetMem(Handle, SizeOf(TWOHandleArray));  // Alocate Memory For Event Handles
  if Handle = nil then                     // Make Sure We Got Memory
    begin
      CloseSocket(Sckt);
      WriteLn('Could not allocate Handle memory');
      DoorShutDown;
      Sleep(10000);
      Halt;
    end;

  WildcatLoggedIn(UserRec);                // Get Current User Logged In

  SendLine(CRLF+CRLF);
  GetServiceText;
  SendLine(CRLF+'Welcome to the Trivia Test '+UserRec.Info.Name+CRLF);
  SendLine(CRLF);

  SendLine('Would you like to answer some trivia questions: ');
  if ReadYesNo then
    begin
      repeat
        HintIndex := 0;
        Hint      := '';
        GetServiceQuestion(Answer, Question);
        for Count := 1 to Length(Answer) do
          begin
            if Answer[Count] = ' ' then
              Hint := Hint + ' '
            else
              Hint := Hint + '.';
          end;
        repeat
          SendLine(CRLF);
          if HintIndex > 0 then
            begin
              for Count := 1 to Length(Answer) do
                if Answer[HintIndex] = Answer[Count] then
                  Hint[Count] := Answer[Count];
            end;
          SendLine(CRLF+'Hint: '+Hint+CRLF);
          SendLine(Question);
          GetUserLine(UserLine);
          SendLine(CRLF);
          if UpperCase(UserLine) = UpperCase(Answer) then
            SendLine(CRLF+'"'+Answer+'" is the correct answer!')
          else
            begin
              SendLine(CRLF+'Wrong Answer');
              Inc(HintIndex);
            end;

          if HintIndex = Length(Answer) then
            SendLine(CRLF+'Answer: '+Answer+CRLF);
        until (UpperCase(UserLine) = UpperCase(Answer)) or (HintIndex = Length(Answer));
        SendLine(CRLF+CRLF+'Would you like another question?: ');
      until not ReadYesNo;
    end;

  FreeMem(Handle, SizeOf(TWOHandleArray));  // Free Our Handle Memory
  SendLine(CRLF+'Returning to BBS...'+CRLF);
  DoorShutDown;       // Close Door Connections And Free Resources
  CloseSocket(Sckt);
end.

