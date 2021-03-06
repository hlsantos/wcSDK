// File: TModemProfile.java
// (c) copyright 2002 Santronics Software Inc.
//
//****************************************************
// DO NOT EDIT THIS FILE!!!
// CPP2JAVA GENERATED FROM SOURCE FILE: wctype.h
//****************************************************
//

package COM.winserver.wildcat;

import java.io.IOException;

public class TModemProfile extends WcRecord {
  public int Version;
  public boolean UserDefined;
  public String Name;
  public int InitBaud;
  public boolean LockDTE;
  public boolean HardwareFlow;
  public boolean ExitOffHook;
  public int CarrierDelay;
  public int RingDelay;
  public int DropDtrDelay;
  public int PrelogDelay;
  public int ResultDelay;
  public int ResetDelay;
  public int AnswerMethod;
  public int EnableCallerId;
  public String ResetCommand;
  public String AnswerCommand;
  public String OffHook;
  public String RingResult;
  public String ConnectResult;
  public String ErrorFreeResult;
  public String[] ExtraBaudResults;
  public int[] ExtraBaudResultNumbers;
  public String InitCommand;
  public String[] Reserved5;

  // Total size
  public static final int SIZE = 0+4+4+32+4+4+4+4+4+4+4+4+4+4+4+4+64+64+64+64+64+64+64+64+10*64+10*4+64+64+64+3*64+256+128*1;

  // Constructors
  public TModemProfile()
  {
  }

  public TModemProfile(byte[] x)
  {
    fromByteArray(x);
  }

  // Methods
  protected void writeTo(WcOutputStream out) throws IOException
  {
    super.writeTo(out);
    out.writeInt(Version);
    out.writeBoolean(UserDefined);
    out.writeString(Name, 32);
    out.writeInt(InitBaud);
    out.writeBoolean(LockDTE);
    out.writeBoolean(HardwareFlow);
    out.writeBoolean(ExitOffHook);
    out.writeInt(CarrierDelay);
    out.writeInt(RingDelay);
    out.writeInt(DropDtrDelay);
    out.writeInt(PrelogDelay);
    out.writeInt(ResultDelay);
    out.writeInt(ResetDelay);
    out.writeInt(AnswerMethod);
    out.writeInt(EnableCallerId);
    out.writeString(ResetCommand, 64);
    out.writeString(AnswerCommand, 64);
    out.write(new byte[64]);
    out.writeString(OffHook, 64);
    out.writeString(RingResult, 64);
    out.writeString(ConnectResult, 64);
    out.write(new byte[64]);
    out.writeString(ErrorFreeResult, 64);
    for (int i = 0; i < 10; i++) {
      if (i < ExtraBaudResults.length) {
        out.writeString(ExtraBaudResults[i], 64);
      } else {
        out.write(new byte[64]);
      }
    }
    for (int i = 0; i < 10; i++) {
      if (i < ExtraBaudResultNumbers.length) {
        out.writeInt(ExtraBaudResultNumbers[i]);
      } else {
        out.write(new byte[4]);
      }
    }
    out.write(new byte[64]);
    out.writeString(InitCommand, 64);
    out.write(new byte[64]);
    for (int i = 0; i < 3; i++) {
      if (i < Reserved5.length) {
        out.writeString(Reserved5[i], 64);
      } else {
        out.write(new byte[64]);
      }
    }
    out.write(new byte[256]);
    out.write(new byte[128*1]);
  }

  protected void readFrom(WcInputStream in) throws IOException
  {
    super.readFrom(in);
    Version = in.readInt();
    UserDefined = in.readBoolean();
    Name = in.readString(32);
    InitBaud = in.readInt();
    LockDTE = in.readBoolean();
    HardwareFlow = in.readBoolean();
    ExitOffHook = in.readBoolean();
    CarrierDelay = in.readInt();
    RingDelay = in.readInt();
    DropDtrDelay = in.readInt();
    PrelogDelay = in.readInt();
    ResultDelay = in.readInt();
    ResetDelay = in.readInt();
    AnswerMethod = in.readInt();
    EnableCallerId = in.readInt();
    ResetCommand = in.readString(64);
    AnswerCommand = in.readString(64);
    in.skip(64);
    OffHook = in.readString(64);
    RingResult = in.readString(64);
    ConnectResult = in.readString(64);
    in.skip(64);
    ErrorFreeResult = in.readString(64);
    ExtraBaudResults = new String[10];
    for (int i = 0; i < 10; i++) {
      ExtraBaudResults[i] = in.readString(64);
    }
    ExtraBaudResultNumbers = new int[10];
    for (int i = 0; i < 10; i++) {
      ExtraBaudResultNumbers[i] = in.readInt();
    }
    in.skip(64);
    InitCommand = in.readString(64);
    in.skip(64);
    Reserved5 = new String[3];
    for (int i = 0; i < 3; i++) {
      Reserved5[i] = in.readString(64);
    }
    in.skip(256);
    in.skip(128*1);
  }
}
