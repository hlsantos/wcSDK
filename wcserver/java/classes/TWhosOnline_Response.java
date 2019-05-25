// File: TWhosOnline_Response.java
// (c) copyright 2002 Santronics Software Inc.
//
//****************************************************
// DO NOT EDIT THIS FILE!!!
// CPP2JAVA GENERATED FROM SOURCE FILE: wcgui.h
//****************************************************
//

package COM.winserver.wildcat;

import java.io.IOException;

public class TWhosOnline_Response extends TWildcatRequest {
  public TwcNodeInfo NodeInfo;

  // Total size
  public static final int SIZE = TWildcatRequest.SIZE+TwcNodeInfo.SIZE;

  // Constructors
  public TWhosOnline_Response()
  {
  }

  public TWhosOnline_Response(byte[] x)
  {
    fromByteArray(x);
  }

  // Methods
  protected void writeTo(WcOutputStream out) throws IOException
  {
    super.writeTo(out);
    NodeInfo.writeTo(out);
  }

  protected void readFrom(WcInputStream in) throws IOException
  {
    super.readFrom(in);
    NodeInfo = new TwcNodeInfo(); NodeInfo.readFrom(in);
  }
}
