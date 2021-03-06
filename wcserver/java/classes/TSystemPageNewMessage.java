// File: TSystemPageNewMessage.java
// (c) copyright 2002 Santronics Software Inc.
//
//****************************************************
// DO NOT EDIT THIS FILE!!!
// CPP2JAVA GENERATED FROM SOURCE FILE: wctype.h
//****************************************************
//

package COM.winserver.wildcat;

import java.io.IOException;

public class TSystemPageNewMessage extends WcRecord {
  public int Conference;
  public String ConferenceName;
  public int Id;
  public TUserInfo From;
  public String Subject;

  // Total size
  public static final int SIZE = 0+4+60+4+TUserInfo.SIZE+72;

  // Constructors
  public TSystemPageNewMessage()
  {
  }

  public TSystemPageNewMessage(byte[] x)
  {
    fromByteArray(x);
  }

  // Methods
  protected void writeTo(WcOutputStream out) throws IOException
  {
    super.writeTo(out);
    out.writeInt(Conference);
    out.writeString(ConferenceName, 60);
    out.writeInt(Id);
    From.writeTo(out);
    out.writeString(Subject, 72);
  }

  protected void readFrom(WcInputStream in) throws IOException
  {
    super.readFrom(in);
    Conference = in.readInt();
    ConferenceName = in.readString(60);
    Id = in.readInt();
    From = new TUserInfo(); From.readFrom(in);
    Subject = in.readString(72);
  }
}
