// File: TNavigatorDownload.java
// (c) copyright 2002 Santronics Software Inc.
//
//****************************************************
// DO NOT EDIT THIS FILE!!!
// CPP2JAVA GENERATED FROM SOURCE FILE: wcgui.h
//****************************************************
//

package COM.winserver.wildcat;

import java.io.IOException;

public class TNavigatorDownload extends WcRecord {
  public int Cookie;
  public String FileName;
  public int FileSize;

  // Total size
  public static final int SIZE = 0+4+16+4;

  // Constructors
  public TNavigatorDownload()
  {
  }

  public TNavigatorDownload(byte[] x)
  {
    fromByteArray(x);
  }

  // Methods
  protected void writeTo(WcOutputStream out) throws IOException
  {
    super.writeTo(out);
    out.writeInt(Cookie);
    out.writeString(FileName, 16);
    out.writeInt(FileSize);
  }

  protected void readFrom(WcInputStream in) throws IOException
  {
    super.readFrom(in);
    Cookie = in.readInt();
    FileName = in.readString(16);
    FileSize = in.readInt();
  }
}
