// File: TUploadFile_Request.java
// (c) copyright 2002 Santronics Software Inc.
//
//****************************************************
// DO NOT EDIT THIS FILE!!!
// CPP2JAVA GENERATED FROM SOURCE FILE: wcgui.h
//****************************************************
//

package COM.winserver.wildcat;

import java.io.IOException;

public class TUploadFile_Request extends TWildcatRequest {
  public TFullFileRecord5 file;

  // Total size
  public static final int SIZE = TWildcatRequest.SIZE+TFullFileRecord5.SIZE;

  // Constructors
  public TUploadFile_Request()
  {
    type = WildcatRequest.wrUploadFile;
  }

  public TUploadFile_Request(byte[] x)
  {
    fromByteArray(x);
  }

  // Methods
  protected void writeTo(WcOutputStream out) throws IOException
  {
    super.writeTo(out);
    file.writeTo(out);
  }

  protected void readFrom(WcInputStream in) throws IOException
  {
    super.readFrom(in);
    file = new TFullFileRecord5(); file.readFrom(in);
  }
}
