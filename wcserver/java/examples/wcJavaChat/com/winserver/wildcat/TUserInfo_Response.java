// File: TUserInfo_Response.java
// (c) copyright 1999 Santronics Software Inc.
//
//****************************************************
// DO NOT EDIT THIS FILE!!!
// CPP2JAVA GENERATED FROM SOURCE FILE: wcgui.h
//****************************************************
//

package COM.winserver.wildcat;

import java.io.IOException;

public class TUserInfo_Response extends TWildcatRequest {
  public TUserInfo UserInfo;
  public String From;
  public long LastCall;

  // Total size
  public static final int SIZE = TWildcatRequest.SIZE+TUserInfo.SIZE+32+8;

  // Constructors
  public TUserInfo_Response()
  {
  }

  public TUserInfo_Response(byte[] x)
  {
    fromByteArray(x);
  }

  // Methods
  protected void writeTo(WcOutputStream out) throws IOException
  {
    super.writeTo(out);
    UserInfo.writeTo(out);
    out.writeString(From, 32);
    out.writeLong(LastCall);
  }

  protected void readFrom(WcInputStream in) throws IOException
  {
    super.readFrom(in);
    UserInfo = new TUserInfo(); UserInfo.readFrom(in);
    From = in.readString(32);
    LastCall = in.readLong();
  }
}
