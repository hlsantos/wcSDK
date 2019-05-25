{$V-,F+,O+,D+,L+,I-}

unit FileIO;

interface

uses
  SysUtils,
  Classes,
  bitset;

const
  MaxBufferSize = 8194;
  MaxBitSize    = 65534;

var
  IoError        : Word;

type
  FileIOPtr = ^TFileIo;
  TFileIo = object
    FilePointer    : File;
    RecSize        : Word;
    OffSet         : LongInt;
    SeekSize       : LongInt;
    Records        : LongInt;
    BitsChanged,
    BitSetActive   : Boolean;
    BitBuffer      : TBitSet;
    BitPointer     : ByteArrayPtr;
    MaxPage,
    TotalBits,
    PageSize,
    StartPos,
    MaxBits,
    ActiveBits,
    FirstBit,
    Bytes,
    PageStart,
    LastBit        : LongInt;
    DisplayRoutine : Boolean;

    constructor Open(FileName : PChar; ARecordSize : Word; OpenMode : Word);
    constructor Create(FileName : PChar; ARecordSize, CreateRecords : LongInt);
    destructor  Done; virtual;
    function    ReadRec(RefNr : LongInt; var Data) : Boolean;
    function    ReadDirectRec(ReadSize : LongInt; var Data) : Boolean;
    function    WriteRec(RefNr : LongInt; var Data) : Boolean;
    function    WriteDirectRec(WriteSize : LongInt; var Data) : Boolean;
    function    AddRecord(var Data) : Boolean;
    function    InsertRec(RefNr : LongInt; var Data) : Boolean;
    function    DeleteRec(RefNr : LongInt) : Boolean;
    function    MoveInRecord(Stop : LongInt) : Boolean;
    function    MoveOutRecord(Stop : LongInt) : Boolean;
    function    GetRecords : LongInt;
    function    GetFileSize : LongInt;
    function    AdjustFileAreaSize(NewRecords : LongInt) : Boolean;
    procedure   SetSeekSize(SeekLength : LongInt);
    procedure   SetOffSetSize(OffSize : LongInt);
    function    SeekToRecord(RefNr : LongInt) : Word;
    function    SeekToPos(RefNr : LongInt) : Boolean;
    function    DirectSeek(SeekOffSet : LongInt) : Boolean;
    function    CopyRecord(RecFrom, RecTo : LongInt) : Boolean;
    function    AddBlankField(DataSize : LongInt) : Boolean;
    function    GetRecPosition(RefNr : LongInt) : LongInt;
    function    GetIoResult : Boolean;

    // For handling on Disk BitSets

    function    OpenBitField(StartPosition, FieldBits : LongInt) : Boolean; export;
    procedure   CloseBitField; virtual;
    function    LoadBitPage(BitNumber : LongInt) : Boolean;
    function    SaveBitPage : Boolean;
    function    BitIsSet(BitNumber : LongInt) : Boolean;
    procedure   SetBit(BitNumber : LongInt);
    procedure   ClearBit(BitNumber : LongInt);
    procedure   ToggleBit(BitNumber : LongInt);
    procedure   ClearAllBits;
    procedure   SetAllBits;
end;

implementation

constructor TFileIO.Open(FileName : PChar; ARecordSize : Word; OpenMode : Word);

begin
  BitSetActive := False;
  SeekSize := 0;
  OffSet   := 0;
  RecSize  := ARecordSize;

  AssignFile(FilePointer, FileName);

  FileMode := OpenMode;

  if not GetIoResult then
    begin
      Reset(FilePointer, 1);
      if not GetIoResult then
        begin
          if SizeOf(FilePointer) > 0 then ;
          if IoError = 0 then
            begin
              GetRecords;
              if GetIoResult then
                Fail;
            end
          else
            Fail;
        end
      else
        Fail;
    end
  else
    Fail;
end;


constructor TFileIO.Create(FileName : PChar; ARecordSize, CreateRecords : LongInt);
var
  DataBlock   : Pointer;
  Status      : Boolean;
  BytesWritten,
  Counter     : LongInt;

begin
  BitSetActive := False;
  SeekSize := 0;
  OffSet   := 0;
  RecSize  := ARecordSize;
  Records  := CreateRecords;

  AssignFile(FilePointer, FileName);

  if not GetIoResult then
    begin
      Rewrite(FilePointer, 1);

      if not GetIoResult then
        begin
          GetMem(DataBlock, RecSize);

          if DataBlock <> nil then
            begin
              FillChar(DataBlock^, RecSize, 0);
              Status := True;

              for Counter := 1 to Records do
                begin
                  BlockWrite(FilePointer, DataBlock^, RecSize, BytesWritten);
                  if (BytesWritten <> RecSize) or GetIoResult then
                    begin
                      Status := False;
                      break;
                    end;
                end;
              FreeMem(DataBlock, RecSize);

              if not Status then
                Fail;
            end
          else
            Fail;
        end
      else
        Fail;
    end
  else
    Fail;
end;

destructor TFileIO.Done;

begin
  if BitSetActive then
    CloseBitField;
  GetIoResult;
  CloseFile(FilePointer);
  GetIoResult;
end;

function TFileIO.ReadRec(RefNr : LongInt; var Data) : Boolean;
var
  BytesRead : LongInt;

begin
  ReadRec := False;
  if RefNr <= Records then
    begin
      if SeekToRecord(RefNr) = 0 then
        begin
          BlockRead(FilePointer, Data, RecSize, BytesRead);
          if not GetIoResult and (BytesRead = RecSize) then
            ReadRec := True;
        end;
    end;
end;

function TFileIO.ReadDirectRec(ReadSize : LongInt; var Data) : Boolean;
var
  BytesRead : LongInt;

begin
  ReadDirectRec := False;
  BlockRead(FilePointer, Data, ReadSize, BytesRead);
  if not GetIoResult and (BytesRead = ReadSize) then
    ReadDirectRec := True;
end;

function TFileIO.WriteRec(RefNr : LongInt; var Data) : Boolean;
var
  BytesWritten : LongInt;

begin
  WriteRec := False;

  if RefNr <= Records then
    begin
      if SeekToRecord(RefNr) = 0 then
        begin
            BlockWrite(FilePointer, Data, RecSize, BytesWritten);
            if not GetIoResult and (BytesWritten = RecSize) then
              WriteRec := True;
          end;
    end;
end;

function TFileIO.WriteDirectRec(WriteSize : LongInt; var Data) : Boolean;
var
  BytesWritten : LongInt;

begin
  WriteDirectRec := False;
  BlockWrite(FilePointer, Data, WriteSize, BytesWritten);
  if not GetIoResult and (BytesWritten = WriteSize) then
    WriteDirectRec := True;
end;

function TFileIO.AddRecord(var Data) : Boolean;
var
  BytesWritten,
  SizeOfFile   : LongInt;

begin
  AddRecord := False;
  SizeOfFile := FileSize(FilePointer);
  Seek(FilePointer, SizeOfFile);

  if not GetIoResult then
    begin
      BlockWrite(FilePointer, Data, RecSize, BytesWritten);
      if (BytesWritten = RecSize) and not GetIoResult then
        begin
          GetRecords;
          if not GetIoResult then
            AddRecord := True;
        end;
    end;
end;

function TFileIO.InsertRec(RefNr : LongInt; var Data) : Boolean;

begin
  InsertRec := False;

  if (RefNr > 0) and (RefNr <= Records) then
    begin
      if MoveInRecord(RefNr) then
        begin
          WriteRec(RefNr, Data);
          if not GetIoResult then
            begin
              if SeekSize > 0 then
                AddBlankField(SeekSize - RecSize);
              InsertRec := True;
            end;
        end;
    end;
end;


function TFileIO.DeleteRec(RefNr : LongInt) : Boolean;
begin
  DeleteRec := False;

  if (RefNr > 0) and (RefNr <= Records) then
    begin
      if RefNr < Records then
        begin
          if MoveOutRecord(RefNr) then
            begin
              if SeekToRecord(Records) = 0 then
                begin
                  Truncate(FilePointer);
                  if not GetIoResult then
                    begin
                      GetRecords;
                      if not GetIoResult then
                        DeleteRec := True;
                    end;
                end;
            end;
        end
      else
        begin
          if SeekToRecord(RefNr) = 0 then
            begin
              Truncate(FilePointer);
              if not GetIoResult then
                begin
                  GetRecords;
                  if not GetIoResult then
                    DeleteRec := True;
                end;
            end;
        end;
    end;
end;

function TFileIO.MoveInRecord(Stop : LongInt) : Boolean;
var
  Buffer          : Pointer;
  DataSize,
  BufferSize,
  ReadSize,
  ReadPos,
  WritePos,
  BytesLeft,
  DataBytes,
  CurrentPosition : LongInt;
  Status,
  Finished        : Boolean;

begin
  MoveInRecord := False;

  if SeekSize > 0 then
    DataSize := SeekSize
  else
    DataSize := RecSize;

  BufferSize := DataSize;

  GetMem(Buffer, BufferSize);

  if Buffer = nil then
    Exit;

  Status := True;
  CurrentPosition := Records;

  while (CurrentPosition >= Stop) and (Status = True) and (IoError = 0) do
    begin
      ReadSize  := BufferSize;
      Finished  := False;
      ReadPos   := (CurrentPosition * DataSize) - DataSize - OffSet;
      WritePos  := ReadPos + DataSize;
      BytesLeft := DataSize;

      while not Finished and (IoError = 0) do
        begin
          Seek(FilePointer, ReadPos);
          BlockRead(FilePointer, Buffer^, ReadSize, DataBytes);

          if not GetIoResult and (DataBytes = ReadSize) then
            begin
              Seek(FilePointer, WritePos);
              ReadPos := ReadPos + ReadSize;
              BlockWrite(FilePointer, Buffer^, ReadSize, DataBytes);

              if not GetIoResult and (DataBytes = ReadSize) then
                begin
                  WritePos := WritePos + ReadSize;
                  BytesLeft := BytesLeft - ReadSize;

                  if BytesLeft > 0 then
                    begin
                      if BytesLeft < BufferSize then
                        ReadSize := BytesLeft
                    end
                  else
                    Finished := True;
                end
              else
                begin
                  Finished := True;
                  Status := False;
                end;
             end
          else
            begin
              Finished := True;
              Status := False;
            end;
        end;

      Dec(CurrentPosition);
    end;

  if Status then
    MoveInRecord := True;
  FreeMem(Buffer, BufferSize);
end;


function TFileIO.MoveOutRecord(Stop : LongInt) : Boolean;

var
  Buffer          : Pointer;
  DataSize,
  BufferSize,
  ReadSize,
  ReadPos,
  WritePos,
  BytesLeft,
  DataBytes,
  CurrentPosition : LongInt;
  Status,
  Finished        : Boolean;

begin
  MoveOutRecord := False;

  if SeekSize > 0 then
    DataSize := SeekSize
  else
    DataSize := RecSize;

  BufferSize := DataSize;

  GetMem(Buffer, BufferSize);

  if Buffer = nil then
    Exit;

  Status := True;
  CurrentPosition := Stop;

  while (CurrentPosition < Records) and (Status = True) and (IoError = 0) do
    begin
      ReadSize  := BufferSize;
      Finished  := False;
      WritePos  := (CurrentPosition * DataSize) - DataSize - OffSet;
      ReadPos   := WritePos + DataSize;
      BytesLeft := DataSize;

      while not Finished and (IoError = 0) do
        begin
          Seek(FilePointer, ReadPos);
          BlockRead(FilePointer, Buffer^, ReadSize, DataBytes);

          if not GetIoResult and (DataBytes = ReadSize) then
            begin
              Seek(FilePointer, WritePos);
              ReadPos := ReadPos + ReadSize;
              BlockWrite(FilePointer, Buffer^, ReadSize, DataBytes);

              if not GetIoResult and (DataBytes = ReadSize) then
                begin
                  WritePos := WritePos + ReadSize;
                  BytesLeft := BytesLeft - ReadSize;

                  if BytesLeft > 0 then
                    begin
                      if BytesLeft < BufferSize then
                        ReadSize := BytesLeft
                    end
                  else
                    Finished := True;
                end
              else
                begin
                  Finished := True;
                  Status := False;
                end;
             end
          else
            begin
              Finished := True;
              Status := False;
            end;
        end;

      Inc(CurrentPosition);
    end;
  if Status then
    MoveOutRecord := True;

  FreeMem(Buffer, BufferSize);
end;


function TFileIO.GetRecords : LongInt;

begin
  if SeekSize > 0 then
    Records := GetFileSize div SeekSize - OffSet
  else
    Records := GetFileSize div RecSize - OffSet;
  GetIoResult;
  GetRecords := Records;
end;

function TFileIO.GetFileSize : LongInt;

begin
  GetFileSize := FileSize(FilePointer);
  IoError := IoResult;
end;


function TFileIO.AdjustFileAreaSize(NewRecords : LongInt) : Boolean;

var
  CreateRecs,
  BytesWritten,
  Counter       : LongInt;
  Status        : Boolean;
  DataBlock     : Pointer;

begin
  AdjustFileAreaSize := True;
  GetRecords;

  if Records <> NewRecords then
    begin
      AdjustFileAreaSize := False;
      if NewRecords > Records then
        begin
          CreateRecs := NewRecords - Records;

          Seek(FilePointer, Records * RecSize);   { Move To End Of File First }

          if not GetIoResult then
            begin
              GetMem(DataBlock, RecSize);

              if DataBlock <> nil then
                begin
                  FillChar(DataBlock^, RecSize, 0);
                  Status := True;

                  for Counter := 1 to CreateRecs do
                    begin
                      BlockWrite(FilePointer, DataBlock^, RecSize, BytesWritten);
                      if (BytesWritten <> RecSize) or GetIoResult then
                        begin
                          Status := False;
                          break;
                        end;
                    end;

                  if Status then
                    AdjustFileAreaSize := True;

                  FreeMem(DataBlock, RecSize);
                end
            end;
        end
      else
        begin
          Seek(FilePointer, NewRecords * RecSize);
          if not GetIoResult then
            Truncate(FilePointer);
            if not GetIoResult then
              AdjustFileAreaSize := True;
        end;
    end;
end;

procedure TFileIO.SetSeekSize(SeekLength : LongInt);

begin
  SeekSize := SeekLength;
  GetRecords;
end;

procedure TFileIO.SetOffSetSize(OffSize : LongInt);

begin
  OffSet  := OffSize;
  GetRecords;
end;

function TFileIO.DirectSeek(SeekOffSet : LongInt) : Boolean;

begin
 DirectSeek := False;
 Seek(FilePointer, FilePos(FilePointer) + SeekOffSet);
 if not GetIoResult then
   DirectSeek := True;
end;

function TFileIO.SeekToPos(RefNr : LongInt) : Boolean;

begin
  SeekToPos := False;
  Seek(FilePointer, RefNr);
  if not GetIoResult then
    SeekToPos := True;
end;

function TFileIO.SeekToRecord(RefNr : LongInt) : Word;
var
  Position : LongInt;

begin
  If SeekSize > 0 then
    Position := (RefNr * SeekSize) - SeekSize
  else
    Position := (RefNr * RecSize) - RecSize;

  Seek(FilePointer, Position);
  SeekToRecord := IoResult;
end;


function TFileIO.CopyRecord(RecFrom, RecTo : LongInt) : Boolean;
var
  Buffer          : Pointer;
  DataSize,
  BufferSize,
  ReadSize,
  ReadPos,
  WritePos,
  BytesLeft,
  DataBytes       : LongInt;
  Status,
  Finished        : Boolean;

begin
  CopyRecord := False;

  if RecFrom = RecTo then
    begin
      CopyRecord := True;
      Exit;
    end;

  if SeekSize > 0 then
    DataSize := SeekSize
  else
    DataSize := RecSize;

  BufferSize := DataSize;

  GetMem(Buffer, BufferSize);

  if Buffer = nil then
    Exit;

  Status := True;
  ReadSize  := BufferSize;
  Finished  := False;
  ReadPos   := (RecFrom * DataSize) - DataSize - OffSet;
  WritePos  := (RecTo * DataSize) - DataSize - OffSet;
  BytesLeft := DataSize;

  while not Finished and (IoError = 0) do
    begin
      Seek(FilePointer, ReadPos);
      BlockRead(FilePointer, Buffer^, ReadSize, DataBytes);

      if not GetIoResult and (DataBytes = ReadSize) then
        begin
          Seek(FilePointer, WritePos);
          ReadPos := ReadPos + ReadSize;
          BlockWrite(FilePointer, Buffer^, ReadSize, DataBytes);

          if not GetIoResult and (DataBytes = ReadSize) then
            begin
              WritePos := WritePos + ReadSize;
              BytesLeft := BytesLeft - ReadSize;

              if BytesLeft > 0 then
                begin
                  if BytesLeft < BufferSize then
                    ReadSize := BytesLeft
                end
              else
                Finished := True;
            end
          else
            begin
              Finished := True;
              Status := False;
           end;
        end
      else
        begin
          Finished := True;
          Status := False;
        end;
    end;

  if Status then
    CopyRecord := True;

  FreeMem(Buffer, BufferSize);
end;

function TFileIO.AddBlankField(DataSize : LongInt) : Boolean;

var
  Buffer          : Pointer;
  BufferSize,
  BytesWritten ,
  DataBytes       : LongInt;
  Status          : Boolean;

begin
  AddBlankField := False;

  BufferSize := DataSize;

  GetMem(Buffer, BufferSize);

  if Buffer = nil then
    Exit;

  Status       := True;
  BytesWritten := DataSize;

  FillChar(Buffer^, BufferSize, 0);

  while (BytesWritten > 0) and (Status = True) and (IoError = 0) do
    begin
      if BytesWritten > BufferSize then
        begin
          BlockWrite(FilePointer, Buffer^, BufferSize, DataBytes);
          if GetIoResult or (DataBytes <> BufferSize) then
            Exit;
          Dec(BytesWritten, BufferSize);
        end
      else
        begin
          BlockWrite(FilePointer, Buffer^, BytesWritten, DataBytes);
          if GetIoResult or (DataBytes <> BytesWritten) then
            Exit;
          BytesWritten := 0;
        end;
    end;

  if Status then
    AddBlankField := True;

  FreeMem(Buffer, BufferSize);
end;

function TFileIO.GetRecPosition(RefNr : LongInt) : LongInt;

begin
  if SeekSize > 0 then
    GetRecPosition := (RefNr * SeekSize) - SeekSize
  else
    GetRecPosition := (RefNr * RecSize) - RecSize;
end;

function TFileIO.OpenBitField(StartPosition, FieldBits : LongInt) : Boolean;

begin
  BitSetActive := True;
  OpenBitField := False;
  BitsChanged  := False;

  StartPos     := StartPosition;
  PageStart    := StartPosition;
  FirstBit     := 0;
  TotalBits    := FieldBits;
  MaxBits      := TotalBits;
  MaxPage      := ((TotalBits) - 1) div 8 + 1;

  if TotalBits > MaxBitSize then
    ActiveBits := MaxBitSize
  else
    ActiveBits := TotalBits;

  LastBit  := ActiveBits;

  PageSize := ((ActiveBits) - 1) div 8 + 1;

  Bytes    := PageSize;

  BitBuffer := TBitSet.Init(ActiveBits); //This Works

  //BitBuffer.Init(ActiveBits);

  if BitBuffer = nil then
    Exit;

  BitBuffer.SetBitPtr(BitPointer);

  FillChar(BitPointer^, Bytes, 0); {Clear Before We Use}

  Seek(FilePointer, StartPos);

  if GetIoResult then
    begin
      CloseBitField;
      Exit;
    end;

  if not ReadDirectRec(PageSize, BitPointer^) then
    begin
      CloseBitField;
      Exit;
    end;

  OpenBitField := True;
end;

procedure TFileIO.CloseBitField;

begin
  if BitsChanged then
    SaveBitPage;
  BitSetActive := False;
  BitBuffer.Done;
end;

function TFileIO.LoadBitPage(BitNumber : LongInt) : Boolean;
var
  FirstTemp : LongInt;

begin
  LoadBitPage := False;

  if BitsChanged then
    SaveBitPage;

  if BitNumber > MaxBits then
    Exit;

  if BitNumber < ActiveBits then
    FirstTemp := 0
  else if BitNumber >= (TotalBits - ActiveBits) then
    begin
      PageStart := (BitNumber shr 3);
      FirstTemp := (PageStart * 8) - (ActiveBits div 2);
    end
  else
    FirstTemp := BitNumber - (ActiveBits div 3);

  if (BitNumber < FirstTemp) or (BitNumber > (FirstTemp + ActiveBits)) then
    FirstTemp := BitNumber;

  PageStart := (FirstTemp shr 3);

  FirstBit := (PageStart * 8);

  LastBit  := (FirstBit + ActiveBits) - 1;

  if LastBit > TotalBits then
    LastBit := TotalBits;

  if (PageStart + PageSize) > MaxPage then
    Bytes := PageSize - ((PageStart + PageSize) - MaxPage)
  else
    Bytes := PageSize;

  Inc(PageStart, StartPos);

  Seek(FilePointer, PageStart);

  if GetIoResult then
    Exit;

  if ReadDirectRec(Bytes, BitPointer^) then
    LoadBitPage := True;
end;

function TFileIO.SaveBitPage : Boolean;

begin
  SaveBitPage := False;

  Seek(FilePointer, PageStart);

  GetIoResult;

  if not WriteDirectRec(Bytes, BitPointer^) then
    Exit;

  BitsChanged := False;

  SaveBitPage := True;
end;

procedure TFileIO.SetAllBits;
var
  BitNumber : LongInt;

begin
  BitNumber := 0;

  while BitNumber < TotalBits do
    begin
      LoadBitPage(BitNumber);

      BitBuffer.SetAll;

      SaveBitPage;

      if (FirstBit + ActiveBits) > TotalBits then
        BitNumber := TotalBits
      else
        BitNumber := LastBit + 1;
    end;
end;

procedure TFileIO.ClearAllBits;
var
  BitNumber : LongInt;

begin
  BitNumber := 0;

  while BitNumber < TotalBits do
    begin
      LoadBitPage(BitNumber);

      BitBuffer.ClearAll;

      SaveBitPage;

      if (FirstBit + ActiveBits) > TotalBits then
        BitNumber := TotalBits
      else
        BitNumber := LastBit + 1;
    end;
end;

procedure TFileIO.ToggleBit(BitNumber : LongInt);
var
  CurrentBit : LongInt;

begin
  if (BitNumber > LastBit) or (BitNumber < FirstBit) then
    LoadBitPage(BitNumber);

  CurrentBit := (BitNumber - FirstBit);

  BitsChanged := True;

  BitBuffer.ToggleBit(CurrentBit);
end;

procedure TFileIO.ClearBit(BitNumber : LongInt);
var
  CurrentBit : LongInt;

begin
  if (BitNumber > LastBit) or (BitNumber < FirstBit) then
    LoadBitPage(BitNumber);

  CurrentBit := (BitNumber - FirstBit);

  BitsChanged := True;

  BitBuffer.ClearBit(CurrentBit);
end;

procedure TFileIO.SetBit(BitNumber : LongInt);

var
  CurrentBit : LongInt;

begin
  if (BitNumber > LastBit) or (BitNumber < FirstBit) then
    LoadBitPage(BitNumber);

  CurrentBit := (BitNumber - FirstBit);

  BitsChanged := True;

  BitBuffer.SetBit(CurrentBit);
end;

function TFileIO.BitIsSet(BitNumber : LongInt) : Boolean;
var
  CurrentBit : LongInt;

begin
  if (BitNumber > LastBit) or (BitNumber < FirstBit) then
    LoadBitPage(BitNumber);

  CurrentBit := (BitNumber - FirstBit);

  if BitBuffer.BitIsSet(CurrentBit) then
    BitIsSet := True
  else
    BitIsSet := False;
end;


function TFileIO.GetIoResult : Boolean;
begin
  IoError := IoResult;
  GetIoResult := IoError <> 0;
end;

begin
end.
