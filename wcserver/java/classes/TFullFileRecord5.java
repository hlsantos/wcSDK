// File: TFullFileRecord5.java
// (c) copyright 2002 Santronics Software Inc.
//
//****************************************************
// DO NOT EDIT THIS FILE!!!
// CPP2JAVA GENERATED FROM SOURCE FILE: wctype.h
//****************************************************
//

package COM.winserver.wildcat;

import java.io.IOException;

public class TFullFileRecord5 extends WcRecord {
  public TFileRecord5 Info;
  public String StoredPath;
  public String[] LongDescription;

  // Total size
  public static final int SIZE = 0+TFileRecord5.SIZE+260+15*80;

  // Constructors
  public TFullFileRecord5()
  {
  }

  public TFullFileRecord5(byte[] x)
  {
    fromByteArray(x);
  }

  // Methods
  protected void writeTo(WcOutputStream out) throws IOException
  {
    super.writeTo(out);
    Info.writeTo(out);
    out.writeString(StoredPath, 260);
    for (int i = 0; i < 15; i++) {
      if (i < LongDescription.length) {
        out.writeString(LongDescription[i], 80);
      } else {
        out.write(new byte[80]);
      }
    }
  }

  protected void readFrom(WcInputStream in) throws IOException
  {
    super.readFrom(in);
    Info = new TFileRecord5(); Info.readFrom(in);
    StoredPath = in.readString(260);
    LongDescription = new String[15];
    for (int i = 0; i < 15; i++) {
      LongDescription[i] = in.readString(80);
    }
  }
}
