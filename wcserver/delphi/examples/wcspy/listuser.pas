unit ListUser;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  ExtCtrls, StdCtrls, wcServer, wcType, Globals;

type
  TUserListForm = class(TForm)
    UserList: TListBox;
    UserListEdit: TEdit;
    CancelButton: TButton;
    Label1: TLabel;
    OKButton: TButton;
    UserListTimer: TTimer;
    procedure FormActivate(Sender: TObject);
    procedure UserListEditChange(Sender: TObject);
    procedure OKButtonClick(Sender: TObject);
    procedure UserListTimerTimer(Sender: TObject);
    procedure CancelButtonClick(Sender: TObject);
    procedure UserListDblClick(Sender: TObject);
  private
    { Private declarations }
  public
    ListingUsers : Boolean;
    ChangingName : Boolean;
    UserRec      : TUser;
    TNum         : DWord;
    { Public declarations }
  end;

var
  UserListForm: TUserListForm;

const
  USERLISTMAX = 1000; // Maximum Amount Of Users For Our ListBox

implementation

{$R *.DFM}

procedure TUserListForm.FormActivate(Sender: TObject);
begin
  // Initial Settings For This Window
  ListingUsers := False;
  ChangingName := False;
  UserListEdit.Text := '';
  UserList.Items.Clear;
  UserListEdit.SetFocus;
end;

procedure TUserListForm.UserListEditChange(Sender: TObject);
begin
  ChangingName := True;
end;

procedure TUserListForm.OKButtonClick(Sender: TObject);
begin
  if UserList.SelCount = 0 then
    Application.MessageBox('No username has been selected', 'wcSPY Report', mb_OK)
  else
    begin
      if UserList.SelCount > 0 then
        begin
          SpySelectName := UserList.Items[UserList.ItemIndex]; // Set Selected Name
          Close;
        end
      else
        Application.MessageBox('No username has been selected', 'wcSPY Report', mb_OK);
    end;
end;

function GetStringMatch(Str1, Str2 : String) : Boolean;
var
  Name : String;
  Temp : String;

begin
  Name := StrUpper(PChar(Str1));
  Temp := StrUpper(PChar(Copy(Str2, 1, Length(Str1))));
  GetStringMatch := Name = Temp;
end;

// This procedure loads users on the Timer cycles so that you can type in the
// edit box at the same time and have the list change on the fly

procedure TUserListForm.UserListTimerTimer(Sender: TObject);
var
  Name  : String;

begin
  if ListingUsers or ChangingName then
    begin
      if not ListingUsers then
        ListingUsers := True;
      if ChangingName then
        begin
          ChangingName := False;
          UserList.Items.Clear;
          if UserListEdit.Text <> '' then
            begin
              if SearchUserByName(PChar(UserListEdit.Text), UserRec, TNum) then
                UserList.Items.Add(UserRec.Info.Name);
            end
          else
            ListingUsers := False;
        end
      else
        begin
          Name := UserRec.Info.Name;
          if GetNextUser(UserNameKey, UserRec, TNum) and GetStringMatch(UserListEdit.Text, UserRec.Info.Name) then
            begin
              UserList.Items.Add(UserRec.Info.Name);
            end
          else
            ListingUsers := False;
          if UserList.Items.Count >= USERLISTMAX then
            ListingUsers := False;
        end;
    end;
end;

procedure TUserListForm.CancelButtonClick(Sender: TObject);
begin
  Close;
end;

procedure TUserListForm.UserListDblClick(Sender: TObject);
begin
  SpySelectName := UserList.Items[UserList.ItemIndex]; // Set Selected Name
  Close;
end;

end.
