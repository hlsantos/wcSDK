// File: TCopyBeforeDownload_Remove_Request.java
// (c) copyright 2002 Santronics Software Inc.
//
//****************************************************
// DO NOT EDIT THIS FILE!!!
// CPP2JAVA GENERATED FROM SOURCE FILE: wcgui.h
//****************************************************
//

package COM.winserver.wildcat;

import java.io.IOException;

public class TCopyBeforeDownload_Remove_Request extends TWildcatRequest {
  public int id;

  // Total size
  public static final int SIZE = TWildcatRequest.SIZE+4;

  // Constructors
  public TCopyBeforeDownload_Remove_Request()
  {
    type = WildcatRequest.wrCopyBeforeDownload;
  }

  public TCopyBeforeDownload_Remove_Request(byte[] x)
  {
    fromByteArray(x);
  }

  // Methods
  protected void writeTo(WcOutputStream out) throws IOException
  {
    super.writeTo(out);
    out.writeInt(id);
  }

  protected void readFrom(WcInputStream in) throws IOException
  {
    super.readFrom(in);
    id = in.readInt();
  }
}
