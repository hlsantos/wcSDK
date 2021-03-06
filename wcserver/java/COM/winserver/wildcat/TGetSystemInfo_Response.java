// File: TGetSystemInfo_Response.java
// (c) copyright 1999 Santronics Software Inc.
//
//****************************************************
// DO NOT EDIT THIS FILE!!!
// CPP2JAVA GENERATED FROM SOURCE FILE: wcgui.h
//****************************************************
//

package COM.winserver.wildcat;

import java.io.IOException;

public class TGetSystemInfo_Response extends TWildcatRequest {
  // Constants
  public static final int guiShowPasswordFiles = 0x01;
  public static final int guiWindowsCharset    = 0x02;
  public static final int guiNAVSMTP           = 0x04;

  // Members
  public String BBSName;
  public String SysopName;
  public String RegString;
  public String PacketId;
  public int Flags;

  // Total size
  public static final int SIZE = TWildcatRequest.SIZE+52+28+8+12+4;

  // Constructors
  public TGetSystemInfo_Response()
  {
  }

  public TGetSystemInfo_Response(byte[] x)
  {
    fromByteArray(x);
  }

  // Methods
  protected void writeTo(WcOutputStream out) throws IOException
  {
    super.writeTo(out);
    out.writeString(BBSName, 52);
    out.writeString(SysopName, 28);
    out.writeString(RegString, 8);
    out.writeString(PacketId, 12);
    out.writeInt(Flags);
  }

  protected void readFrom(WcInputStream in) throws IOException
  {
    super.readFrom(in);
    BBSName = in.readString(52);
    SysopName = in.readString(28);
    RegString = in.readString(8);
    PacketId = in.readString(12);
    Flags = in.readInt();
  }
}
