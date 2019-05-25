// File: TListFiles_GetMore.java
// (c) copyright 2002 Santronics Software Inc.
//
//****************************************************
// DO NOT EDIT THIS FILE!!!
// CPP2JAVA GENERATED FROM SOURCE FILE: wcgui.h
//****************************************************
//

package COM.winserver.wildcat;

import java.io.IOException;

public class TListFiles_GetMore extends TWildcatRequest {
  public int count;

  // Total size
  public static final int SIZE = TWildcatRequest.SIZE+4;

  // Constructors
  public TListFiles_GetMore()
  {
  }

  public TListFiles_GetMore(byte[] x)
  {
    fromByteArray(x);
  }

  // Methods
  protected void writeTo(WcOutputStream out) throws IOException
  {
    super.writeTo(out);
    out.writeInt(count);
  }

  protected void readFrom(WcInputStream in) throws IOException
  {
    super.readFrom(in);
    count = in.readInt();
  }
}
