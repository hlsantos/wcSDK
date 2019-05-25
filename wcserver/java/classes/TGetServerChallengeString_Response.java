// File: TGetServerChallengeString_Response.java
// (c) copyright 2002 Santronics Software Inc.
//
//****************************************************
// DO NOT EDIT THIS FILE!!!
// CPP2JAVA GENERATED FROM SOURCE FILE: wcgui.h
//****************************************************
//

package COM.winserver.wildcat;

import java.io.IOException;

public class TGetServerChallengeString_Response extends TWildcatRequest {
  public int len;
  public String data;

  // Total size
  public static final int SIZE = TWildcatRequest.SIZE+4+80;

  // Constructors
  public TGetServerChallengeString_Response()
  {
  }

  public TGetServerChallengeString_Response(byte[] x)
  {
    fromByteArray(x);
  }

  // Methods
  protected void writeTo(WcOutputStream out) throws IOException
  {
    super.writeTo(out);
    out.writeInt(len);
    out.writeString(data, 80);
  }

  protected void readFrom(WcInputStream in) throws IOException
  {
    super.readFrom(in);
    len = in.readInt();
    data = in.readString(80);
  }
}
