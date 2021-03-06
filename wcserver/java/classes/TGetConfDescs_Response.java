// File: TGetConfDescs_Response.java
// (c) copyright 2002 Santronics Software Inc.
//
//****************************************************
// DO NOT EDIT THIS FILE!!!
// CPP2JAVA GENERATED FROM SOURCE FILE: wcgui.h
//****************************************************
//

package COM.winserver.wildcat;

import java.io.IOException;

public class TGetConfDescs_Response extends TWildcatRequest {
  public TGuiConfDesc cd;

  // Total size
  public static final int SIZE = TWildcatRequest.SIZE+TGuiConfDesc.SIZE;

  // Constructors
  public TGetConfDescs_Response()
  {
  }

  public TGetConfDescs_Response(byte[] x)
  {
    fromByteArray(x);
  }

  // Methods
  protected void writeTo(WcOutputStream out) throws IOException
  {
    super.writeTo(out);
    cd.writeTo(out);
  }

  protected void readFrom(WcInputStream in) throws IOException
  {
    super.readFrom(in);
    cd = new TGuiConfDesc(); cd.readFrom(in);
  }
}
