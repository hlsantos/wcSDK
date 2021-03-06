// File: TGetFileGroups_Response.java
// (c) copyright 2002 Santronics Software Inc.
//
//****************************************************
// DO NOT EDIT THIS FILE!!!
// CPP2JAVA GENERATED FROM SOURCE FILE: wcgui.h
//****************************************************
//

package COM.winserver.wildcat;

import java.io.IOException;

public class TGetFileGroups_Response extends TWildcatRequest {
  public TFileGroup fg;

  // Total size
  public static final int SIZE = TWildcatRequest.SIZE+TFileGroup.SIZE;

  // Constructors
  public TGetFileGroups_Response()
  {
  }

  public TGetFileGroups_Response(byte[] x)
  {
    fromByteArray(x);
  }

  // Methods
  protected void writeTo(WcOutputStream out) throws IOException
  {
    super.writeTo(out);
    fg.writeTo(out);
  }

  protected void readFrom(WcInputStream in) throws IOException
  {
    super.readFrom(in);
    fg = new TFileGroup(); fg.readFrom(in);
  }
}
