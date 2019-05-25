unit SpyUnit;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs, WcType,
  WcServer, ExtCtrls, StdCtrls, ComCtrls, AddUser, Globals, Menus, MMSystem;

const
  WM_WCNOTIFY = WM_USER + 123; // Constant for the notify message from Wildcat!

type
  TForm1 = class(TForm)
    SpyStatsBox: TGroupBox;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    GroupBox2: TGroupBox;
    Label4: TLabel;
    Label5: TLabel;
    Label6: TLabel;
    Label7: TLabel;
    GroupBox3: TGroupBox;
    AddUserButton: TButton;
    CloseButton: TButton;
    RemoveUserButton: TButton;
    Timer1: TTimer;
    Label8: TLabel;
    Label9: TLabel;
    Label10: TLabel;
    Label11: TLabel;
    SystemStatsBox: TLabel;
    Label13: TLabel;
    Label14: TLabel;
    UsersList: TListView;
    Label15: TLabel;
    Label16: TLabel;
    PopupMenu1: TPopupMenu;
    EditUser1: TMenuItem;
    RemoverUser1: TMenuItem;
    procedure FormCreate(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure CloseButtonClick(Sender: TObject);
    procedure UpdateStats;
    procedure Timer1Timer(Sender: TObject);
    procedure RemoveUserButtonClick(Sender: TObject);
    procedure AddUserButtonClick(Sender: TObject);
    procedure UsersListDblClick(Sender: TObject);
    procedure EditUser1Click(Sender: TObject);
    procedure RemoverUser1Click(Sender: TObject);
  private
    { Private declarations }
    TimeCount  : Word;
    BBSName   : String;
    procedure AddToListBox;
    procedure LoadNameBox;
    procedure WcNotify(var msg: TMessage); message WM_WCNOTIFY;
  public
    { Public declarations }
  end;

type
  TNameRec = record
    Name   : String[30];
    Node   : Word;
   end;

var
  Form1: TForm1;
  LastUserDate: TDateTime;
  StartTime : TDateTime;
  LastUser: String;
  UserQueue: Word;
  Names : array[1..USERMAX+1] of TNameRec;

implementation

{$R *.DFM}

procedure TForm1.UpdateStats;
begin
  Label11.Caption := Long2Str(GetUsersOnline);
  SystemStatsBox.Caption := Long2Str(GetNodeCount-GetUsersOnline);
  Label13.Caption := Long2Str(GetTotalMessages);
  Label14.Caption := Long2Str(GetTotalFiles);
  Label9.Caption  := Long2Str(UserQueue);
  Label16.Caption := BBSName;
  if LastUser <> '' then
    Label10.Caption := LastUser
  else
    Label10.Caption := 'N/A';
end;

procedure TForm1.FormCreate(Sender: TObject);
var
  MwConfig : TMakeWild;

begin
  EditingUser    := False;
  TimeCount      := 0;
  Caption        := 'wcSPY Version 2.0 wcSERVER Version: '+Long2Str(GetWildcatVersion());
  StartTime      := Now;             // Set Starting Time
  LastUser       := '';              // Clear Last User Field
  LastUserDate   := 0;               // Clear Last User Date
  UserQueue      := 0;               // Clear The Users Queue
  if not GetMakeWild(MwConfig) then  // Get Makewilds Record from the server
    begin
      SpyError('Error getting Makewild Record', GetLastError);
      Close;
    end;
  BBSName := MwConfig.BBSName;       // Set The Global BBS Name
  UpdateStats;                       // Update Stats for the first time

  if not FileExists('WCSPYUSERS.DAT') then
    begin
      if not SpyFile.Create('WCSPYUSERS.DAT', SizeOf(TSpyRecord), 0) then
        begin
          SpyError('Could not create WCSPYUSERS.DAT, Error: '+Long2Str(GetLastError()), MB_IconError + MB_OK);
          Close;
        end;
      SpyFile.Done;
    end;

  if not SpyFile.Open('WCSPYUSERS.DAT', SizeOf(TSpyRecord), FileMode) then
    begin
      SpyError('Could not open WCSPYUSERS.DAT, Error: '+Long2Str(GetLastError()), MB_IconError + MB_OK);
      Close;
    end;
  AddToListBox;                // Add All The Users To The List Box
  LoadNameBox;                 // Load All The Users Into The Name Array
  if SpyFile.Records > USERMAX then // if we have 100 or more records turn off the Add Button
    AddUserButton.Visible := False;
  Timer1.Enabled := True;      // Turn On Timer Events Now That We Are Setup
end;

procedure TForm1.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  SpyFile.Done;
end;

procedure TForm1.CloseButtonClick(Sender: TObject);
begin
  Close;
end;

procedure TForm1.Timer1Timer(Sender: TObject);
begin
  Label8.Caption := FormatDateTime('hh:mm:ss', Now-StartTime); // Update Clock
  Inc(TimeCount);
  if TimeCount > 10 then                // If 10 seconds then update stats
    begin
      TimeCount := 0;
      UpdateStats;
    end;
end;

procedure TForm1.RemoveUserButtonClick(Sender: TObject);
var
  TempRec : TSpyRecord;
  TempStr : String;

begin
  if UsersList.Selected <> nil then // Make sure we have a field selected
    begin
      SpyFile.ReadRec(UsersList.Selected.Index+1, TempRec);
      TempStr := 'Delete User: "'+TempRec.UserName+'"';
      if Application.MessageBox(PChar(TempStr), 'wcSPY Report', mb_OKCancel+MB_ICONQUESTION) = IDOK then
        begin
          SpyFile.DeleteRec(UsersList.Selected.Index+1); // Delete User From DataBase
          AddToListBox; // Reload List Box
          LoadNameBox;  // Reload Internal Name List
        end;
    end;
end;

procedure TForm1.AddUserButtonClick(Sender: TObject);
var
  ModResult : Integer;

begin
  FillChar(SpyUserRecord, SizeOf(TSpyRecord), 0);
  ModResult := TNewUser.ShowModal;
  if ModResult = IDOK then
    begin
      SpyFile.AddRecord(SpyUserRecord);
      Names[SpyFile.Records].Name := SpyUserRecord.UserName;
      Names[SpyFile.Records].Node := 0;
      AddToListBox;                               // Reload List Box
      LoadNameBox;                                // Reload Internal Name List
      if SpyFile.Records > USERMAX then           // We Only Allow 100 Records
        AddUserButton.Visible := False;
    end;
end;

procedure TForm1.LoadNameBox;
var
  Count : Word;
  TempRec : TSpyRecord;

begin
  UserQueue := 0;
  FillChar(Names, SizeOf(Names), 0); // Clear Our Current List
  for Count := 1 to SpyFile.Records do
    begin
      if Count < USERMAX then  // Do NOT Add Past The End Of the Array No Matter What! (BOOM!)
        begin
          SpyFile.ReadRec(Count, TempRec);
          Names[Count].Name := TempRec.UserName;
          Inc(UserQueue);
        end;
    end;
  UpdateStats;  
end;

function UserInList(Name : String) : LongInt;
var
  Count : Word;

begin
  UserInList := -1;
  for Count := 1 to USERMAX do
    if Names[Count].Name = Name then
      begin
        UserInList := Count;
        break;
      end;
end;

procedure TForm1.AddToListBox;
var
  Count    : LongInt;
  Temp     : TSpyRecord;
  ListItem : TListItem;
  TmpStr   : String;

begin
  Count := 1;
  UsersList.Items.Clear;
  while Count <= SpyFile.GetRecords do
    begin
      SpyFile.ReadRec(Count, Temp);      // Get Record
      ListItem := UsersList.Items.Add;   // Add New Item To ListView
      ListItem.Caption := Temp.UserName; // Set the Caption Field
      DateTimeToString(TmpStr, ShortDateFormat + ' ' + ShortTimeFormat, ConvertWCTimeToDelphiTime(Temp.UserLastOn));
      ListItem.SubItems.Add(TmpStr);     // Add Our First SubField
      if Temp.SoundFile <> '' then
        TmpStr := 'SN '
      else
        TmpStr := '   ';
      if Temp.MessageBytes > 0 then
        TmpStr := TmpStr + 'MG '
      else
        TmpStr := TmpStr + '   ';
      if Temp.SetActiveTime then
        TmpStr := TmpStr + 'TM '
      else
        TmpStr := TmpStr + '   ';
      if Temp.WatchUser then
        TmpStr := TmpStr + 'VW '
      else
        TmpStr := TmpStr + '   ';
      if Temp.LogUserOff then
        TmpStr := TmpStr + 'LG';
      ListItem.SubItems.Add(TmpStr);     // Add Our Second SubField
      Inc(Count);
    end;
end;

procedure TForm1.UsersListDblClick(Sender: TObject);
var
  TempRec : TSpyRecord;

begin
  if UsersList.Selected <> nil then // Make sure we have a field selected
    begin
      SpyFile.ReadRec(UsersList.Selected.Index+1, SpyUserRecord);
      TempRec := SpyUserRecord;
      EditingUser := True; // Tell the AddUser Unit We Are Only Editing
      // If the user selected ok compare the structures and if different then
      // save the new contents
      if (TNewUser.ShowModal = IDOK) and CompStructs(TempRec, SpyUserRecord, SizeOf(SpyUserRecord)) then
        begin
          SpyFile.WriteRec(UsersList.Selected.Index+1, SpyUserRecord);
          AddToListBox;
        end;
      EditingUser := False;
    end;
end;

procedure TForm1.EditUser1Click(Sender: TObject);
var
  TempRec : TSpyRecord;

begin
  if UsersList.Selected <> nil then // Make sure we have a field selected
    begin
      SpyFile.ReadRec(UsersList.Selected.Index+1, SpyUserRecord);
      TempRec := SpyUserRecord;
      EditingUser := True; // Tell the AddUser Unit We Are Only Editing
      // If the user selected ok compare the structures and if different then
      // save the new contents
      if (TNewUser.ShowModal = IDOK) and CompStructs(TempRec, SpyUserRecord, SizeOf(SpyUserRecord)) then
        begin
          SpyFile.WriteRec(UsersList.Selected.Index+1, SpyUserRecord);
          AddToListBox;
        end;
      EditingUser := False;
    end;
end;

procedure TForm1.RemoverUser1Click(Sender: TObject);
var
  TempRec : TSpyRecord;
  TempStr : String;

begin
  if UsersList.Selected <> nil then
    begin
      SpyFile.ReadRec(UsersList.Selected.Index+1, TempRec);
      TempStr := 'Delete User: "'+TempRec.UserName+'"';
      // Check with user BEFORE deleting record
      if Application.MessageBox(PChar(TempStr), 'wcSPY Report', mb_OKCancel+MB_ICONQUESTION) = IDOK then
        begin
          SpyFile.DeleteRec(UsersList.Selected.Index+1);
          AddToListBox;
          LoadNameBox;
        end;
    end;
end;

// This function checks the spy record to see if we can bother the user
// at this time.

function OkToBother(SpyRec : TSpyRecord) : Boolean;
var
  StartTime,
  EndTime : TDateTime;

begin
  OkToBother := True;
  if SpyRec.SetActiveTime then
    begin
      // We have to convert from Delphi's TDATETIME to Wildcats TFILETIME Before
      // We Check, We Add The Current Date So The Only Thing We Are Checking Is
      // The Current Time.
      StartTime := ConvertWCTimeToDelphiTime(SpyRec.FromTime)+Date;
      EndTime   := ConvertWCTimeToDelphiTime(SpyRec.ToTime)+Date;
      if (StartTime > Now) or (EndTime < Now) then
        OkToBother := False;
    end;
end;

// This is the routine that is called when we get a WM_WCNOTIFY message passed
// back to us from the Wildcat! Server, we have to process the message as quickly
// as possible and drop out of this routine so we don't let the messages back up.

procedure TForm1.WcNotify(var msg: TMessage);
var
  Data     : ^TChannelMessage;
  RefNr    : LongInt;
  TempRec  : TSpyRecord;
  UserRec  : TUser;
  Startup  : TStartupInfo;
  Prc      : TProcessInformation;
  TempStr  : String;
  CInfo    : TConnectionInfo;
  ServerNm : AnsiString;
  HChan    : DWord;
  Pmsg     : TPageMessage;
  Count    : Word;
  TID      : DWord;

begin
  Data := Pointer(Msg.LParam); // Msg Pointer to the TChannelMessage Structure
  if (Data.Channel = SystemControlHandle) then begin // Is This Our Channel Message?
    if GetNodeInfoByConnectionId(Data.SenderID, NInfo) and (NInfo.NodeStatus = nsLoggedIn) then
      begin
        // We Get the NodeInfo Record and Check to Make sure that the user
        // logged in, if not then we simply drop on through without making
        // any changes, this happens when a user logs off the system.
        RefNr := UserInList(NInfo.User.Name); // Is UserName In Our Spy List
        if RefNr <> -1 then
          begin
            if SpyFile.ReadRec(RefNr, TempRec) and OkToBother(TempRec) then
              begin
                SpyLog('User '+NInfo.User.Name+' logged on at '+DateTimeToStr(NOW));
                if TempRec.PlaySound then
                  begin
                    SpyLog('Played wav file: '+TempRec.SoundFile);
                    TempStr := TempRec.SoundFile;
                    SndPlaySound(PChar(TempStr), SND_ASYNC);
                    // We play the wave file with the SND_ASYNC option so that
                    // the routine does not hang on waiting for the file to play
                  end;

                if TempRec.WatchUser then
                  begin
                    // In order to run wcVIEW we need to know the users current
                    // node number,  GetConnectionInfo returns this. BUT we must
                    // make sure that is returned the correct connectionID
                    SpyLog('Started wcVIEW');
                    if GetConnectionInfo(Data.SenderID, CInfo) and (CInfo.ConnectionID = Data.SenderID) then
                      begin
                        SetLength(ServerNm, 80);
                        FillChar(Prc, SizeOf(Prc), 0);
                        FillChar(Startup, SizeOf(Startup), 0);
                        // This specifies our current server so that when starting
                        // up, wcVIEW will not ask which server to use.
                        if not GetConnectedServer(PChar(ServerNM), 80) then
                          ServerNM := '';
                        if CreateProcess(NIL, PChar('D:\WC5\WCVIEW.EXE '+Long2Str(CInfo.Node)+' /s'+ServerNM), NIL, NIL, FALSE, 0, NIL, NIL, Startup, Prc) then
                          begin
                            CloseHandle(Prc.hThread);
                            CloseHandle(Prc.hProcess);
                          end
                        else
                          SpyError('Error:'+Long2Str(GetLastError), 0);
                      end
                    else
                      SpyError('Error:'+Long2Str(GetLastError), 0);
                  end;

                if TempRec.MessageBytes > 0 then
                  begin
                    SpyLog('Sent Page To User');
                    // In order to send a user page we Open a channel to
                    // SYSTEM.PAGE, fill out the PMsg stucture, call
                    // WriteChannel and then call Close Channel to clean
                    // everything up.
                    HChan := OpenChannel('SYSTEM.PAGE');
                    if HChan <> 0 then
                      begin
                        FillChar(PMsg, SizeOf(PMsg), 0);
                        for Count := 1 to 3 do
                          begin
                            Move(TempRec.MessageText[Count][1], pmsg.Text[Count][0], Length(TempRec.MessageText[Count]));
                            pmsg.Text[Count][Length(TempRec.MessageText[Count])+1] := #0;
                          end;
                        Move(TempRec.FromName[1], Pmsg.From[0], Length(TempRec.FromName));
                        Pmsg.From[Length(TempRec.FromName)+1] := #0;
                        WriteChannel(hChan, Data.SenderID, 0, @pMsg, sizeof(pmsg));
                        CloseChannel(hchan);
                      end;
                  end;

                if TempRec.LogUserOff then
                  begin
                    SpyLog('Logged User Off System');
                    // To log off a user we follow the same steps as above except
                    // we send the flag to the system control channel of that node.
                    if GetConnectionInfo(Data.SenderID-1, CInfo) and (CInfo.ConnectionID = Data.SenderID) then
                      begin
                        TempStr := 'SYSTEM.CONTROL.'+Long2Str(CInfo.Node);
                        HChan := OpenChannel(PChar(TempStr));
                        if HChan <> 0 then
                          begin
                            WriteChannel(HChan, 0, SC_DISCONNECT, NIL, 0);
                            CloseChannel(Hchan);
                          end;
                      end;
                  end;

                if TempRec.RemoveAccount then
                  begin
                    SpyFile.DeleteRec(RefNr);
                    AddToListBox;
                    LoadNameBox;
                  end
                else
                  begin
                    if GetUserById(NInfo.User.ID, UserRec, TID) then
                      begin
                        TempRec.UserLastOn := UserRec.LastCall;
                        SpyFile.WriteRec(RefNr, TempRec);
                      end;
                  end;
                SpyLog('-------------------------------------------');  
              end;
          end;
      end;
  end;
  msg.Result := 0;
end;

end.
