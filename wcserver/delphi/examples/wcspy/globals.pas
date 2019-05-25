{$A-,H+,F+,I-}

unit Globals;

interface

uses
  SysUtils,
  wcTYPE,
  Windows,
  FileIo;

// Main record structure for storing the users info

type
  TSpyRecord = record
    UserName      : String[30];
    SoundFile     : String[128];
    MessageBytes  : Word;
    MessageText   : array[1..6] of String[80];
    FromName      : String[30];
    SetActiveTime : Boolean;
    FromTime      : TFileTime;
    ToTime        : TFileTime;
    UserLastOn    : TFileTime;
    LoguserOff    : Boolean;
    PlaySound     : Boolean;
    WatchUser     : Boolean;
    RemoveAccount : Boolean;
    Reserved      : array[1..500] of Byte;
  end;

// Wildcat's page record, used for sending user pages

  TPageMessage = record
    From  : Array[0..27] of char;
    Text  : Array[1..3] of Array[0..79] of char;
    InviteToChat : LongInt;
  end;

// WcSpy's global variables

const
  USERMAX = 100;  // Limit of Users to check for

var
  SpyFile             : TFileIO;
  SpyUserRecord       : TSpyRecord;
  EditingUser         : Boolean;
  SpySelectName       : String;
  SystemControlHandle : DWord;
  NInfo               : TwcNodeInfo;

// Globally used functions to make things easier in Delphi

procedure SpyError(S : String; ErrorType : LongInt);
function Long2Str(L : LongInt) : string;
function ConvertDelphiTimeToWCTime(DTime : TDateTime) : TFILETIME;
function ConvertWCTimeToDelphiTime(FTime : TFileTime) : TDateTime;
function CompStructs(var Sr, Ds; Len : Word) : Boolean;
function Str2Word(S : string; var I : Word) : Boolean;
function LeftPadCh(S : string; Ch : Char; Len : Byte) : string;
procedure SpyLog(S : String);

implementation

function Long2Str(L : LongInt) : string;
var
  S : string;

begin
  SetLength(S, 40);
  Str(L, S);
  Long2Str := S;
end;

function ConvertDelphiTimeToWCTime(DTime : TDateTime) : TFILETIME;
var
  STime : TSystemTime;
  FTime : TFileTime;

begin
  DecodeDate(DTime, STime.wYear, STime.wMonth, STime.wDay);
  DecodeTime(DTime, STime.wHour, STime.wMinute, STime.wSecond, STime.wMilliSeconds);
  SystemTimeToFileTime(STime, FTime);
  ConvertDelphiTimeToWCTime := FTime;
end;

function ConvertWCTimeToDelphiTime(FTime : TFileTime) : TDateTime;
var
  STime : TSystemTime;
  DTime : TDateTime;

begin
  FileTimeToSystemTime(FTime, STime);
  DTime := EncodeDate(STime.wYear, STime.wMonth, STime.wDay)
          +EncodeTime(STime.wHour, STime.wMinute, STime.wSecond, STime.wMilliSeconds);
  ConvertWCTimeToDelphiTime := DTime;
end;

function CompStructs(var Sr, Ds; Len : Word) : Boolean;
type
  Pnt = array[0..65534] of Byte;
var
  Count : Word;
  Src   : Pnt absolute Sr;
  Dest  : Pnt absolute Ds;

begin
  Count := 0;
  while (Src[Count] = Dest[Count]) and (Count <= Len) do
    Inc(Count);
  CompStructs :=  Src[Count] <> Dest[Count];
end;


function Str2Word(S : string; var I : Word) : Boolean;
var
  SLen,
  code : Integer;

begin
  Str2Word := False;
  SLen := Length(S);
  if SLen = 0 then
    Exit;
  while S[SLen] = ' ' do
    Dec(SLen);
  if (SLen > 1) and (Upcase(S[SLen]) = 'H') then
    begin
      Move(S[1], S[2], SLen-1);
      S[1] := '$';
    end
  else if (SLen > 2) and (S[1] = '0') and (Upcase(S[2]) = 'X') then
    begin
      Dec(SLen);
      Move(S[3], S[2], SLen-1);
      S[1] := '$';
    end;
  Val(S, I, code);
  if code <> 0 then
    begin
      I := code;
      Str2Word := False;
    end
  else
    Str2Word := True;
end;

function LeftPadCh(S : string; Ch : Char; Len : Byte) : string;
var
  o : string;

begin
  if Length(S) >= Len then
    LeftPadCh := S
  else if Len < 255 then
    begin
      SetLength(o, Len);
      FillChar(O[1], Len, Ch);
      Move(S[1], O[(Len- Length(S))+1], Length(S));
      LeftPadCh := o;
    end;
end;

procedure SpyError(S : String; ErrorType : LongInt);
begin
   MessageBox(0, PChar(S+#10+'Error: '+Long2Str(ErrorType)), 'wcSPY Error', MB_OK);
end;

procedure SpyLog(S : String);
var
  Err : Word;
  F   : Text;

begin
  AssignFile(F, 'WCSPY.LOG');
  Append(F);
  if IoResult <> 0 then
    begin
      Rewrite(F);
      Err := IoResult;
      if Err <> 0 then
        begin
          SpyError('Error creating WCSPY.LOG', Err);
          Halt;
        end;
    end;
   WriteLn(F, S);
   CloseFile(F);
   if IoResult <> 0 then ;
end;

end.
