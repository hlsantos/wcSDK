unit AddUser;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  Mask, StdCtrls, WcType, WcServer, ComCtrls, Spin, Globals,
  ExtCtrls, ListUser;

type
  TTNewUser = class(TForm)
    Label1: TLabel;
    OpenDialog1: TOpenDialog;
    GroupBox1: TGroupBox;
    PlaySoundBox: TCheckBox;
    SoundFileName: TEdit;
    SoundFileButton: TButton;
    InstantMessage: TCheckBox;
    InstantComment: TMemo;
    SaveUserButton: TButton;
    Button2: TButton;
    LogOffUser: TCheckBox;
    DateCheck: TCheckBox;
    Label2: TLabel;
    Label3: TLabel;
    FromTimeEdit: TMaskEdit;
    ToTimeEdit: TMaskEdit;
    FromTimeButton: TSpinButton;
    ToTimeButton: TSpinButton;
    WatchUser: TCheckBox;
    RemoveAccount: TCheckBox;
    UserEdit: TEdit;
    UserList: TButton;
    Label4: TLabel;
    FromEdit: TEdit;
    procedure Button2Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure SoundFileButtonClick(Sender: TObject);
    procedure PlaySoundBoxClick(Sender: TObject);
    procedure InstantMessageClick(Sender: TObject);
    procedure FromTimeEditKeyDown(Sender: TObject; var Key: Word;
      Shift: TShiftState);
    procedure FromTimeEditKeyPress(Sender: TObject; var Key: Char);
    procedure FromTimeEditKeyUp(Sender: TObject; var Key: Word;
      Shift: TShiftState);
    procedure ToTimeEditKeyDown(Sender: TObject; var Key: Word;
      Shift: TShiftState);
    procedure ToTimeEditKeyPress(Sender: TObject; var Key: Char);
    procedure ToTimeEditKeyUp(Sender: TObject; var Key: Word;
      Shift: TShiftState);
    procedure ToTimeEditEnter(Sender: TObject);
    procedure FromTimeEditEnter(Sender: TObject);
    procedure FromTimeButtonDownClick(Sender: TObject);
    procedure FromTimeButtonUpClick(Sender: TObject);
    procedure ToTimeButtonDownClick(Sender: TObject);
    procedure ToTimeButtonUpClick(Sender: TObject);
    procedure ToTimeButtonEnter(Sender: TObject);
    procedure FromTimeButtonEnter(Sender: TObject);
    procedure DateCheckClick(Sender: TObject);
    procedure SaveUserButtonClick(Sender: TObject);
    procedure FormActivate(Sender: TObject);
    procedure FindUserComboChange(Sender: TObject);
    procedure UserListClick(Sender: TObject);
  private
    { Private declarations }
  public
    ChangeValue     : Boolean;
    SelectPosition  : Word;
    ProcessingUsers : Boolean;
    NameChange      : Boolean;
    TNum            : LongInt;
    function UserInDataBase(Name : String) : Boolean;
    { Public declarations }
  end;

var
  TNewUser: TTNewUser;

type
  TDirection = (dNil, dRight, dLeft, dUp, dDown);
  TTimeField = (tHour, tMinute, tSeconds, tZone);

implementation

{$R *.DFM}

function ArrowKey(VKey : Word; var Direction : TDirection) : Boolean;
begin
  Direction := dNil;
  case VKey of
    $6b,                       // Add Key
    $26 : Direction := dUp;    // Up Key
    $6d,                       // Subtract Key
    $28 : Direction := dDown;  // Down Key
  end;
  ArrowKey := Direction <> dNil;
end;

function UpdateTime(Field : TTimeField; Direction : TDirection; TS : String) : String;
var
  TempStr  : String[20];
  FieldStr : String[4];
  Number   : Word;

begin
  UpdateTime := TS;
  Number := 0;
  case Field of
    tHour   : begin
                FieldStr := Trim(Copy(TS, 0, 2));
                Str2Word(FieldStr, Number);
                if Direction = dUp then
                  begin
                    Inc(Number);
                    if Number > 12 then
                      Number := 1;
                  end
                else
                  begin
                    Dec(Number);
                    if Number < 1 then
                      Number := 12;
                  end;
                FieldStr := LeftPadCh(Long2Str(Number), ' ', 2);
                UpdateTime := FieldStr+Copy(TS, 3, Length(TS));
              end;
    tMinute : begin
                FieldStr := Trim(Copy(TS, 4, 2));
                Str2Word(FieldStr, Number);
                if Direction = dUp then
                  begin
                    Inc(Number);
                    if Number > 59 then
                      Number := 0;
                  end
                else
                  begin
                    if Number > 0 then
                      Dec(Number)
                    else
                      Number := 59;
                  end;
                FieldStr := LeftPadCh(Long2Str(Number), '0', 2);
                UpdateTime := Copy(TS, 1, 3)+FieldStr+Copy(TS, 6, Length(TS));
              end;
    tSeconds: begin
                FieldStr := Trim(Copy(TS, 7, 2));
                Str2Word(FieldStr, Number);
                if Direction = dUP then
                  begin
                    Inc(Number);
                    if Number > 59 then
                      Number := 0;
                  end
                else
                  begin
                    if Number > 0 then
                      Dec(Number)
                    else
                      Number := 59;
                  end;
                FieldStr := LeftPadCh(Long2Str(Number), '0', 2);
                UpdateTime := Copy(TS, 1, 7)+FieldStr+Copy(TS, 9, 2);
              end;
    tZone   : begin
                FieldStr := Trim(Copy(TS, 9, 2));
                if UpCase(FieldStr[1]) = 'A' then
                  FieldStr := 'PM'
                else
                  FieldStr := 'AM';
                TempStr := Copy(TS, 1, 8);
                UpdateTime := Copy(TS, 1, 8)+FieldStr;
              end;
  end;
end;

procedure EditKeyPress(var TimeEdit : TMaskEdit; Sender: TObject; var Key: Char);
var
  SaveKey : Char;
  TempStr : String[4];
  Num     : Word;

begin
  case TimeEdit.SelStart of
    0,1: begin
           TempStr := Copy(TimeEdit.Text, 0, 2);
           if TimeEdit.SelStart = 0 then
             begin
               SaveKey := TempStr[1];
               TempStr[1] := Key
             end
           else
             begin
               SaveKey := TempStr[2];
               TempStr[2] := Key;
             end;
           Str2Word(TempStr, Num);
           if (Num < 1) or (Num > 12) then
             Key := SaveKey;
         end;
    3,4: begin
           TempStr := Trim(Copy(TimeEdit.Text, 4, 2));
           if TimeEdit.SelStart = 3 then
             begin
               SaveKey := TempStr[1];
               TempStr[1] := Key
             end
           else
             begin
               SaveKey := TempStr[2];
               TempStr[2] := Key;
             end;
           Str2Word(TempStr, Num);
           if (Num > 59) then
             Key := SaveKey;
         end;
    6,7: begin
           TempStr := Trim(Copy(TimeEdit.Text, 7, 2));
           if TimeEdit.SelStart = 6 then
             begin
               SaveKey := TempStr[1];
               TempStr[1] := Key
             end
           else
             begin
               SaveKey := TempStr[2];
               TempStr[2] := Key;
             end;
           Str2Word(TempStr, Num);
           if (Num > 59) then
             Key := SaveKey;
         end;
    8,9: begin
           if TimeEdit.SelStart = 8 then
             begin
               if (UpCase(Key) <> 'A') or (UpCase(Key) <> 'P') then
                   Key := TimeEdit.Text[9];
             end
           else
             Key := TimeEdit.Text[10];
         end;
  end;
end;

procedure EditKeyDown(var TimeEdit : TMaskEdit; Sender: TObject; var Key: Word; Shift: TShiftState);
var
  Direction : TDirection;
  Selected  : Word;

begin
  if ArrowKey(Key, Direction) then
     begin
       if TNewUser.ChangeValue then
         Selected := TNewUser.SelectPosition
       else
         begin
           TnewUser.SelectPosition := TimeEdit.SelStart;
           Selected := TimeEdit.SelStart;
           if (Direction = dUP) or (Direction = dDown) then
             TNewUser.ChangeValue := True;
         end;
       case Selected of
         0,1: begin
                if (Direction = dUP) or (Direction = dDown) then
                  TimeEdit.Text := UpdateTime(tHour, Direction, TimeEdit.Text);
              end;
         3,4: begin
                if (Direction = dUP) or (Direction = dDown) then
                  TimeEdit.Text := UpdateTime(tMinute, Direction, TimeEdit.Text);
              end;
         6,7: begin
                if (Direction = dUP) or (Direction = dDown) then
                  TimeEdit.Text := UpdateTime(tSeconds, Direction, TimeEdit.Text);
              end;
         8,9: begin
                if (Direction = dUP) or (Direction = dDown) then
                  TimeEdit.Text := UpdateTime(tZone, Direction, TimeEdit.Text);
              end;
       end;
    end;
end;

procedure EditKeyUp(var TimeEdit : TMaskEdit; Sender: TObject; var Key: Word;
  Shift: TShiftState);
var
  Direction : TDirection;

begin
  if ArrowKey(Key, Direction) and ((Direction = dUP) or (Direction = dDown))
  or TNewUser.ChangeValue then
    begin
      TimeEdit.SelStart := TNewUser.SelectPosition;
      Key := $10;
    end;
  TnewUser.ChangeValue := False;
end;

procedure TimeButtonDownClick(var TimeEdit : TMaskEdit; Sender: TObject);
var
  CurPos : Word;

begin
  CurPos := TimeEdit.SelStart;
  case TimeEdit.SelStart of
    0,1: TimeEdit.Text := UpdateTime(tHour, dDown, TimeEdit.Text);
    3,4: TimeEdit.Text := UpdateTime(tMinute, dDown, TimeEdit.Text);
    6,7: TimeEdit.Text := UpdateTime(tSeconds, dDown, TimeEdit.Text);
    8,9: TimeEdit.Text := UpdateTime(tZone, dDown, TimeEdit.Text);
  end;
  TimeEdit.SelStart := CurPos;
  TimeEdit.SetFocus;
end;

procedure TimeButtonUpClick(var TimeEdit : TMaskEdit; Sender: TObject);
var
  CurPos : Word;

begin
  CurPos := TimeEdit.SelStart;
  case TimeEdit.SelStart of
    0,1: TimeEdit.Text := UpdateTime(tHour, dUP, TimeEdit.Text);
    3,4: TimeEdit.Text := UpdateTime(tMinute, dUP, TimeEdit.Text);
    6,7: TimeEdit.Text := UpdateTime(tSeconds, dUP, TimeEdit.Text);
    8,9: TimeEdit.Text := UpdateTime(tZone, dUP, TimeEdit.Text);
  end;
  TimeEdit.SelStart := CurPos;
  TimeEdit.SetFocus;
end;

function TTNewUser.UserInDataBase(Name : String) : Boolean;
var
  Count : Word;
  Temp  : TSpyRecord;

begin
  UserInDataBase := False;
  for Count := 1 to SpyFile.Records do
    begin
      SpyFile.ReadRec(Count, Temp);
      if Name = Temp.UserName then
        begin
          UserInDataBase := True;
          Exit;
        end;
    end;
end;

procedure TTNewUser.Button2Click(Sender: TObject);
begin
  Close;
end;

procedure TTNewUser.Button1Click(Sender: TObject);
var
  TempUserRec : TUserInfo;

begin
  if UserEdit.Text <> '' then
    begin
      if not EditingUser and UserInDataBase(UserEdit.Text) then
        Application.MessageBox('User already exists in wcSPY database', 'wcSPY Error', mb_OK)
      else if LookUpName(PChar(UserEdit.Text), TempUserRec) then
        UserEdit.Font.Style := [fsUnderLine]
      else
        Application.MessageBox('Username not found on system', 'wcSPY Error', mb_OK);
    end
  else
    UserEdit.SetFocus;
end;

procedure TTNewUser.SoundFileButtonClick(Sender: TObject);
const
  LastDir  : String = '';
var
  WaveFile : String;

begin
  OpenDialog1.Filter := '*.WAV';
  OpenDialog1.InitialDir := LastDir;
  if OpenDialog1.Execute then
    begin
      WaveFile := OpenDialog1.FileName;
      if AnsiUpperCase(Copy(WaveFile, Length(WaveFile) - 2, 3)) <> 'WAV' then
        Application.MessageBox('wcSPY can only play .WAV files', 'wcSPY Error', mb_OK)
      else
        begin
          LastDir := WaveFile;
          SoundFileName.Text := WaveFile;
          PlaySoundBox.Checked  := True;
        end;
    end;
end;

procedure TTNewUser.PlaySoundBoxClick(Sender: TObject);
begin
  if PlaySoundBox.Checked then
    begin
      SoundFileName.Enabled := True;
      SoundFileButton.Enabled := True;
    end
  else
    begin
      SoundFileName.Enabled := False;
      SoundFileButton.Enabled := False;
    end;
end;

procedure TTNewUser.InstantMessageClick(Sender: TObject);
begin
  if InstantMessage.Checked then
    InstantComment.Enabled := True
  else
    InstantComment.Enabled := False;
end;

procedure TTNewUser.FromTimeEditKeyDown(Sender: TObject; var Key: Word;
  Shift: TShiftState);
begin
  EditKeyDown(FromTimeEdit, Sender, Key, Shift);
end;

procedure TTNewUser.FromTimeEditKeyPress(Sender: TObject; var Key: Char);
begin
  EditKeyPress(FromTimeEdit, Sender, Key);
end;

procedure TTNewUser.FromTimeEditKeyUp(Sender: TObject; var Key: Word;
  Shift: TShiftState);
begin
  EditKeyUp(FromTimeEdit, Sender, Key, Shift);
end;

procedure TTNewUser.ToTimeEditKeyDown(Sender: TObject; var Key: Word;
  Shift: TShiftState);
begin
  EditKeyDown(ToTimeEdit, Sender, Key, Shift);
end;

procedure TTNewUser.ToTimeEditKeyPress(Sender: TObject; var Key: Char);
begin
  EditKeyPress(ToTimeEdit, Sender, Key);
end;

procedure TTNewUser.ToTimeEditKeyUp(Sender: TObject; var Key: Word;
  Shift: TShiftState);
begin
  EditKeyUp(ToTimeEdit, Sender, Key, Shift);
end;

procedure TTNewUser.ToTimeEditEnter(Sender: TObject);
begin
  TNewUser.ChangeValue := False;
end;

procedure TTNewUser.FromTimeEditEnter(Sender: TObject);
begin
  TNewUser.ChangeValue := False;
end;

procedure TTNewUser.FromTimeButtonDownClick(Sender: TObject);
begin
  TimeButtonDownClick(FromTimeEdit, Sender);
end;

procedure TTNewUser.FromTimeButtonUpClick(Sender: TObject);
begin
  TimeButtonUpClick(FromTimeEdit, Sender);
end;

procedure TTNewUser.ToTimeButtonDownClick(Sender: TObject);
begin
  TimeButtonDownClick(ToTimeEdit, Sender);
end;

procedure TTNewUser.ToTimeButtonUpClick(Sender: TObject);
begin
  TimeButtonUpClick(ToTimeEdit, Sender);
end;

procedure TTNewUser.ToTimeButtonEnter(Sender: TObject);
begin
  TNewUser.ChangeValue := False;
end;

procedure TTNewUser.FromTimeButtonEnter(Sender: TObject);
begin
  TNewUser.ChangeValue := False;
end;

procedure TTNewUser.DateCheckClick(Sender: TObject);
begin
  if DateCheck.Checked then
    begin
      FromTimeEdit.Enabled   := True;
      FromTimeButton.Enabled := True;
      ToTimeEdit.Enabled     := True;
      ToTimeButton.Enabled   := True;
    end
  else
    begin
      FromTimeEdit.Enabled   := False;
      FromTimeButton.Enabled := False;
      ToTimeEdit.Enabled     := False;
      ToTimeButton.Enabled   := False;
    end;
end;

// Once the save button is click we take all the info from the window controls
// put it into our structure and return using the ModalResult so the calling
// routine knows that we Hit OK

procedure TTNewUser.SaveUserButtonClick(Sender: TObject);
var
  TempUserRec : TUserInfo;
  UserRec     : TUser;
  TempStr     : String;
  Cnt         : Word;
  TID         : DWord;
  DTime       : Double;

begin
  if (UserEdit.Text = '') then
    begin
      Application.MessageBox('You must specify a username', 'wcSPY Error', mb_OK);
      UserEdit.SetFocus;
      Exit;
    end
  else if not EditingUser and UserInDataBase(UserEdit.Text) then
    Application.MessageBox('User already exists in wcSPY database', 'wcSPY Error', mb_OK)
  else if not LookUpName(PChar(UserEdit.Text), TempUserRec) then
    begin
      SetLength(TempStr, 100);
      TempStr := '"'+UserEdit.Text+'"  is not a valid username';
      Application.MessageBox(PChar(TempStr), 'wcSPY Error', mb_OK);
      UserEdit.SetFocus;
      Exit;
    end
  else if  not PlaySoundBox.Checked
       and not InstantMessage.Checked
       and not DateCheck.Checked
       and not LogOffUser.Checked
       and not WatchUser.Checked then
    begin
      SetLength(TempStr, 100);
      TempStr := 'You must select an action for '+UserEdit.Text;
      Application.MessageBox(PChar(TempStr), 'wcSPY Error', mb_OK);
      Exit;
    end
  else
    begin
      SpyUserRecord.UserName                := UserEdit.Text;
      GetUserById(TempUserRec.ID, UserRec, TID);
      SpyUserRecord.UserLastOn              := UserRec.LastCall;
      SpyUserRecord.PlaySound := PlaySoundBox.Checked;
      if PlaySoundBox.Checked and (SoundFileName.Text <> '') then
        SpyUserRecord.SoundFile := SoundFileName.Text;
      if InstantMessage.Checked then
        begin
          SpyUserRecord.FromName := FromEdit.Text;
          SpyUserRecord.MessageBytes := 0;
          for Cnt := 1 to 3 do
            begin
              SpyUserRecord.MessageText[Cnt] := InstantComment.Lines[Cnt-1];
              Inc(SpyUserRecord.MessageBytes, Length(SpyUserRecord.MessageText[Cnt]));
            end;
        end;
      SpyUserRecord.SetActiveTime := DateCheck.Checked;
      if DateCheck.Checked then
        begin
           DTime := StrToTime(FromTimeEdit.Text);
           SpyUserRecord.FromTime := ConvertDelphiTimeToWCTime(DTime);

           DTime := StrToTime(ToTimeEdit.Text);
           SpyUserRecord.ToTime := ConvertDelphiTimeToWCTime(DTime);
        end;

      SpyUserRecord.LogUserOff := LogOffUser.Checked;
      SpyUserRecord.WatchUser := WatchUser.Checked;
      SpyUserRecord.RemoveAccount := RemoveAccount.Checked;

      ModalResult := IDOK;
    end;
end;

// When the form is activated we have to fill out all the current user info
// unles we are in new mode then we simply clear all the fields

procedure TTNewUser.FormActivate(Sender: TObject);
var
  Cnt : Word;
  Tmp : String;

begin
  ProcessingUsers := False;
  NameChange      := False;

  if SpyUserRecord.UserName <> '' then
    begin
      UserEdit.Text  := SpyUserRecord.UserName;
      if SpyUserRecord.PlaySound then
        begin
          SoundFileName.Text := SpyUserRecord.SoundFile;
          PlaySoundBox.Checked := True;
        end;
      for Cnt := 1 to 3 do
        begin
           InstantComment.Lines[Cnt-1] := SpyUserRecord.MessageText[Cnt];
           if not InstantMessage.Checked then
             InstantMessage.Checked := InstantComment.Lines[Cnt-1] <> '';
        end;
      FromEdit.Text := SpyUserRecord.FromName;
      if SpyUserRecord.SetActiveTime then
        begin
          DateCheck.Checked := True;
          DateTimeToString(Tmp, 'hh:nn:ssam/pm', ConvertWCTimeToDelphiTime(SpyUserRecord.FromTime));
          FromTimeEdit.Text := Tmp;
          DateTimeToString(Tmp, 'hh:nn:ssam/pm', ConvertWCTimeToDelphiTime(SpyUserRecord.ToTime));
          ToTimeEdit.Text := Tmp;
        end;
       LogOffUser.Checked := SpyUserRecord.LogUserOff;
       WatchUser.Checked := SpyUserRecord.WatchUser;
       RemoveAccount.Checked := SpyUserRecord.RemoveAccount;
    end

  else
    begin
      UserEdit.Text := '';
      FromEdit.Text := '';
      PlaySoundBox.Checked := False;
      SoundFileName.Text := '';
      for Cnt := 0 to 2 do
        InstantComment.Lines[Cnt] := '';
      InstantMessage.Checked := False;
      DateCheck.Checked := False;
      FromTimeEdit.Text := '01:00:00AM';
      ToTimeEdit.Text := '01:00:00AM';
      LogOffUser.Checked := False;
      WatchUser.Checked := False;
      RemoveAccount.Checked := False;
    end;
end;

procedure TTNewUser.FindUserComboChange(Sender: TObject);
begin
  NameChange := True;
end;

procedure TTNewUser.UserListClick(Sender: TObject);
begin
  SpySelectName := UserEdit.Text;
  UserListForm.ShowModal;
  UserEdit.Text := SpySelectName;
end;

end.
