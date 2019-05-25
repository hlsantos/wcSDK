unit monwnd;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  ComCtrls, Wctype, Wcserver, ExtCtrls, Menus, Buttons;

type
  TSrvMonForm = class(TForm)
    ConnectionListView: TListView;
    Timer: TTimer;
    MainMenu: TMainMenu;
    Connection1: TMenuItem;
    View1: TMenuItem;
    Help1: TMenuItem;
    About1: TMenuItem;
    ViewStatusBar: TMenuItem;
    StatusBar: TStatusBar;
    cmExit: TMenuItem;
    Update1: TMenuItem;
    UpdateFast: TMenuItem;
    UpdateNormal: TMenuItem;
    UpdateSlow: TMenuItem;
    UpdatePause: TMenuItem;
    N1: TMenuItem;
    LogConnections1: TMenuItem;
    procedure FormCreate(Sender: TObject);
    procedure TimerTimer(Sender: TObject);
    procedure cmExitClick(Sender: TObject);
    procedure ViewStatusBarClick(Sender: TObject);
    procedure UpdateFastClick(Sender: TObject);
    procedure UpdateNormalClick(Sender: TObject);
    procedure UpdateSlowClick(Sender: TObject);
    procedure UpdatePauseClick(Sender: TObject);
    procedure About1Click(Sender: TObject);
    procedure LogConnections1Click(Sender: TObject);
  private
    { Private declarations }
    UpdateDelay: Dword;
    lastall: Dword;
    all: Boolean;
    lastend: Dword;
    count: Dword;
    ci: TConnectionInfo;
    procedure UpdateListItem(var li: TListItem; const ci: TConnectionInfo);
  public
    { Public declarations }
    procedure ResetListView;
    procedure RemoveConnection(const listidx : dword);
  end;

var
  SrvMonForm: TSrvMonForm;

implementation

Uses WcSrvMonAboutMe;

{$R *.DFM}

function Time(ms: Longint): String;
var m: Longint;
    s: String;
begin
  m := ms div 60000;
  Str(m mod 60:2, s);
  if s[1] = ' ' then
    s[1] := '0';
  Result := IntToStr(m div 60) + ':' + s;
end;

procedure TSrvMonForm.ResetListView;
var li: TListItem;
begin
  ConnectionListView.Items.Clear;
  count := 0;
  ci.ConnectionId := 0;
  while GetConnectionInfo(ci.ConnectionId+1, ci) do
    begin
      li := ConnectionListView.Items.Add;
      UpdateListItem(li, ci);
      Inc(count);
    end;
  StatusBar.SimpleText := IntToStr(count) + ' connections';
  lastall := GetTickCount;
  all := False;
  lastend := GetTickCount;
  count := 0;
end;

procedure TSrvMonForm.FormCreate(Sender: TObject);
begin
  LogConnections1.Checked := FALSE;
  ConnectionListView.ViewStyle := vsReport;
  ViewStatusBar.Checked := StatusBar.Visible;
  UpdateDelay := 2000;
  UpdateNormal.Checked := True;
  ResetListView;
end;

procedure TSrvMonForm.RemoveConnection(const listidx : dword);
var
  li: TListItem;
  node : dword;
  line : string;
begin
  li := ConnectionListView.Items[listidx];
  node := StrToInt(li.SubItems[0]);
  if (node > 0) and LogConnections1.Checked then
     begin
       line := Format('- %s | %-15s | %08d | %03d | %-10s | %s',
                      [
                       FormatDateTime('yyyymmdd hh:mm:ss',Now()),
                       li.SubItems[4],            // computer
                       StrToInt(li.caption),      // cid
                       node,                      // node
                       li.SubItems[8],            // speed
                       li.SubItems[7]             // username
                      ]);
       WriteLogEntry('wcsrvmon.log',pchar(line));
     end;
  ConnectionListView.Items.Delete(listidx);
end;

procedure TSrvMonForm.TimerTimer(Sender: TObject);
var lastid: Dword;
    i: Longint;
    li: TListItem;
    line : string;
begin
  line := Format('+ %9d | %d',[GetTickCount()-lastend,ci.connectionid]) + #13#10;
  OutputDebugString(pchar(line));

  if (UpdateDelay = 0) or ((ci.ConnectionId = 0) and (GetTickCount - lastend < UpdateDelay)) then begin
    exit;
  end;
  lastid := ci.ConnectionId;
  if not GetConnectionInfo(ci.ConnectionId+1, ci) then begin
    StatusBar.SimpleText := IntToStr(count) + ' connections';
    i := 0;
    while i < ConnectionListView.Items.Count do begin
      li := ConnectionListView.Items[i];
      if StrToInt(li.Caption) > lastid then begin
        RemoveConnection(i);
        end
      else begin
        inc(i);
      end;
    end;
    if all then begin
      lastall := GetTickCount;
      all := False;
      end
    else begin
      all := GetTickCount - lastall > 60000;
    end;
    lastend := GetTickCount;
    count := 0;
    exit;
  end;
  //
  i := 0;
  while i < ConnectionListView.Items.Count do begin
    li := ConnectionListView.Items[i];
    if (StrToInt(li.Caption) > lastid) and (StrToInt(li.Caption) < ci.ConnectionId) then
       begin
        RemoveConnection(i);
       end
    else
       begin
        if StrToInt(li.Caption) = ci.ConnectionId then
           begin
             if all or (ci.Calls > StrToInt(li.SubItems[3])) then
                begin
                 UpdateListItem(li, ci);
                end;
             Inc(count);
             break;
           end;
        inc(i);
      end;
  end;
  //
  if i >= ConnectionListView.Items.Count then begin
    li := ConnectionListView.Items.Add;
    UpdateListItem(li, ci);
  end;
end;

procedure TSrvMonForm.UpdateListItem(var li: TListItem; const ci: TConnectionInfo);
var ni: TwcNodeInfo;
    line : string;
    LogIt : Boolean;
begin
  if ci.Node > 0 then
    GetNodeInfo(ci.Node, ni)
  else
    ZeroMemory(@ni, sizeof(ni));
  li.Caption := IntToStr(ci.ConnectionId);
  logit := FALSE;
  if li.SubItems.Count > 0 then begin
    logit := li.SubItems[0] <> IntToStr(ci.Node);
    li.SubItems[0] := IntToStr(ci.Node);
    li.SubItems[1] := Time(ci.Time);
    li.SubItems[2] := Time(ci.IdleTime);
    li.SubItems[3] := IntToStr(ci.Calls);
    li.SubItems[4] := ci.Computer;
    li.SubItems[5] := lowercase(ci.ProgramName);
    li.SubItems[6] := IntToStr(ci.RefCount);
    li.SubItems[7] := ci.User.Name;
    li.SubItems[8] := ni.Speed;
    li.SubItems[9] := ni.Activity;
    end
  else begin
    logit := ci.node > 0;
    li.SubItems.Add(IntToStr(ci.Node));
    li.SubItems.Add(Time(ci.Time));
    li.SubItems.Add(Time(ci.IdleTime));
    li.SubItems.Add(IntToStr(ci.Calls));
    li.SubItems.Add(ci.Computer);
    li.SubItems.Add(lowercase(ci.ProgramName));
    li.SubItems.Add(IntToStr(ci.RefCount));
    li.SubItems.Add(ci.User.Name);
    li.SubItems.Add(ni.Speed);
    li.SubItems.Add(ni.Activity);
  end;
  if logit and LogConnections1.Checked then
     begin
       line := Format('+ %s | %-15s | %08d | %03d | %-10s | %s',
                      [
                       FormatDateTime('yyyymmdd hh:mm:ss',Now()),
                       ci.computer,
                       ci.connectionid,
                       ci.node,
                       ni.Speed,
                       ci.User.Name
                      ]);
       WriteLogEntry('wcsrvmon.log',pchar(line));
     end;
end;

procedure TSrvMonForm.cmExitClick(Sender: TObject);
begin
  Close;
end;

procedure TSrvMonForm.ViewStatusBarClick(Sender: TObject);
begin
  StatusBar.Visible := not StatusBar.Visible;
  ViewStatusBar.Checked := StatusBar.Visible;
end;

procedure TSrvMonForm.UpdateFastClick(Sender: TObject);
begin
  UpdateDelay := 500;
  UpdateFast.Checked := True;
end;

procedure TSrvMonForm.UpdateNormalClick(Sender: TObject);
begin
  UpdateDelay := 2000;
  UpdateNormal.Checked := True;
end;

procedure TSrvMonForm.UpdateSlowClick(Sender: TObject);
begin
  UpdateDelay := 5000;
  UpdateSlow.Checked := True;
end;

procedure TSrvMonForm.UpdatePauseClick(Sender: TObject);
begin
  UpdateDelay := 0;
  UpdatePause.Checked := True;
end;

procedure TSrvMonForm.About1Click(Sender: TObject);
begin
 with TFormAboutBox.Create(self) do
    begin
      ShowModal;
      free;
    end;
end;

procedure TSrvMonForm.LogConnections1Click(Sender: TObject);
begin
  LogConnections1.Checked := not  LogConnections1.Checked;
end;

end.
