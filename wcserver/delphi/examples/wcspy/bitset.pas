unit bitset;

interface

type
  ByteArrayPtr = ^ByteArray;    {General memory mask}
  ByteArray    = array[0..65520] of Byte;

const
  MaxBitCount = 65534;              {Max bits in a bitset}
  NoMoreBits = $FFFFFFFF;           {Constant indicating no more bits}

type
  BitSetPtr = ^TBitSet;
  TBitSet = class
      biMax : LongInt;              {Maximum element number}
      biBase : ByteArrayPtr;        {Pointer to data area}

      constructor Init(Max : LongInt);
        {-Allocate space for elements}
      destructor Done; virtual;
        {-Deallocate data area}
      procedure ClearAll; virtual;
        {-Clear all bits}
      procedure SetAll; virtual;
        {-Set all bits}
      function MaxBits : LongInt;
        {-Return capacity of bitset}

      procedure SetBit(Element : LongInt); virtual;
        {-Set bit}
      procedure ClearBit(Element : LongInt); virtual;
        {-Clear bit}
      procedure ToggleBit(Element : LongInt);
        {-Toggle bit}
      procedure ControlBit(Element : LongInt; State : Boolean);
        {-Set or clear bit depending on State}
      function TestSetBit(Element : LongInt) : Boolean;
        {-Return current state of bit and set it}
      function TestClearBit(Element : LongInt) : Boolean;
        {-Return current state of bit and clear it}

      function BitIsSet(Element : LongInt) : Boolean; virtual;
        {-Return True if bit is set}
      procedure SetBitPtr(var BitPtr : ByteArrayPtr);        

    {$IFDEF UseStreams}
      constructor Load(var S : IdStream);
        {-Load a bitset from a stream}
      procedure Store(var S : IdStream);
        {-Store a bitset to a stream}
    {$ENDIF}
    end;

implementation


  procedure TBitSet.SetBitPtr(var BitPtr : ByteArrayPtr);
  begin
    BitPtr := biBase;
  end;


  procedure SetByteFlag(var Flags : Byte; FlagMask : Byte); assembler;
  asm
    mov edi, Flags
    mov al, Flagmask
    or  [edi], al
  end;

  procedure ClearByteFlag(var Flags : Byte; FlagMask : Byte); assembler;
  asm
    mov edi, Flags
    mov al, FlagMask
    not al
    and [edi], al
  end;

  function ByteFlagIsSet(Flags, FlagMask : Byte) : Boolean; assembler;
  asm
    mov dl, Flags
    mov al, FlagMask
    and al, dl
    jz  @Exit
    mov al, 1
    @Exit:
  end;

  function GetMemCheck(Data : Pointer; Size : LongInt) : Boolean;
  begin
    GetMem(Data, Size);
    GetMemCheck := Data <> nil;
  end;

  function FreeMemCheck(Data : Pointer; Size : LongInt) : Boolean;
  begin
    FreeMem(Data, Size);
    FreeMemCheck := Data <> nil;
  end;


  constructor TBitSet.Init(Max : LongInt);
    {-Allocate space for elements}
  begin
    biBase := nil;
    biMax := Max;
    //if not Root.Init then
    //  Fail;
    if Max = 0 then
      Exit;
    if Max > MaxBitCount then begin
      //Done;
      //InitStatus := epFatal+ecBadParam;
      Fail;
    end;
    if not GetMemCheck(biBase, (Max+8) shr 3) then begin
      //Done;
      //InitStatus := epFatal+ecOutOfMemory;
      Fail;
    end;
    ClearAll;
  end;

  destructor TBitSet.Done;
    {-Deallocate data area}
  begin
    FreeMemCheck(biBase, (biMax+8) shr 3);
    //Root.Done;
  end;

  procedure TBitSet.ClearAll;
    {-Clear all bits}
  begin
    FillChar(biBase^, (biMax+8) shr 3, 0);
  end;

  procedure TBitSet.SetAll;
    {-Set all bits}
  begin
    FillChar(biBase^, (biMax+8) shr 3, $FF);
  end;

  procedure TBitSet.SetBit(Element : LongInt);
    {-Set bit}
  begin
    if (Element >= 0) and (Element <= biMax) then
      SetByteFlag(biBase^[Element shr 3], 1 shl (Element and 7));
  end;

  procedure TBitSet.ClearBit(Element : LongInt);
    {-Clear bit}
  begin
    if (Element >= 0) and (Element <= biMax) then
      ClearByteFlag(biBase^[Element shr 3], 1 shl (Element and 7));
  end;

  procedure TBitSet.ToggleBit(Element : LongInt);
    {-Toggle bit}
  begin
    if BitIsSet(Element) then
      ClearBit(Element)
    else
      SetBit(Element);
  end;

  procedure TBitSet.ControlBit(Element : LongInt; State : Boolean);
    {-Set or clear bit depending on State}
  begin
    if State then
      SetBit(Element)
    else
      ClearBit(Element);
  end;

  function TBitSet.TestSetBit(Element : LongInt) : Boolean;
    {-Return current state of bit and set it}
  begin
    TestSetBit := BitIsSet(Element);
    SetBit(Element);
  end;

  function TBitSet.TestClearBit(Element : LongInt) : Boolean;
    {-Return current state of bit and clear it}
  begin
    TestClearBit := BitIsSet(Element);
    ClearBit(Element);
  end;

  function TBitSet.BitIsSet(Element : LongInt) : Boolean;
    {-Return True if bit is set}
  begin
    if (Element >= 0) and (Element <= biMax) then
      BitIsSet := ByteFlagIsSet(biBase^[Element shr 3], 1 shl (Element and 7))
    else
      BitIsSet := False;
  end;

  function TBitSet.MaxBits : LongInt;
    {-Return capacity of bitset}
  begin
    MaxBits := biMax;
  end;

end.
