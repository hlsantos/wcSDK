// File: TWildcatRequest.java
// (c) copyright 2002 Santronics Software Inc.
//
//****************************************************
// DO NOT EDIT THIS FILE!!!
// CPP2JAVA GENERATED FROM SOURCE FILE: wcgui.h
//****************************************************
//

package COM.winserver.wildcat;

import java.io.IOException;

public class TWildcatRequest extends WcRecord {
  public int type;

  // Total size
  public static final int SIZE = 0+2;

  // Constructors
  public TWildcatRequest()
  {
  }

  public TWildcatRequest(int type)
  {
    this.type = type;
  }

  public TWildcatRequest(byte[] x)
  {
    fromByteArray(x);
  }

  // Methods
  protected void writeTo(WcOutputStream out) throws IOException
  {
    super.writeTo(out);
    out.writeShort(type);
  }

  protected void readFrom(WcInputStream in) throws IOException
  {
    super.readFrom(in);
    type = in.readUnsignedShort();
  }
}
