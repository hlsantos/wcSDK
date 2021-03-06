// File: TAddMessage_Request.java
// (c) copyright 2002 Santronics Software Inc.
//
//****************************************************
// DO NOT EDIT THIS FILE!!!
// CPP2JAVA GENERATED FROM SOURCE FILE: wcgui.h
//****************************************************
//

package COM.winserver.wildcat;

import java.io.IOException;

public class TAddMessage_Request extends TWildcatRequest {
  public TMsgHeader mh;

  // Total size
  public static final int SIZE = TWildcatRequest.SIZE+TMsgHeader.SIZE;

  // Constructors
  public TAddMessage_Request()
  {
    type = WildcatRequest.wrAddMessage;
  }

  public TAddMessage_Request(byte[] x)
  {
    fromByteArray(x);
  }

  // Methods
  protected void writeTo(WcOutputStream out) throws IOException
  {
    super.writeTo(out);
    mh.writeTo(out);
  }

  protected void readFrom(WcInputStream in) throws IOException
  {
    super.readFrom(in);
    mh = new TMsgHeader(); mh.readFrom(in);
  }
}
