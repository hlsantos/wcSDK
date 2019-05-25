// File: TLogonhours.java
// (c) copyright 2002 Santronics Software Inc.
//
//****************************************************
// DO NOT EDIT THIS FILE!!!
// CPP2JAVA GENERATED FROM SOURCE FILE: wctype.h
//****************************************************
//

package COM.winserver.wildcat;

import java.io.IOException;

public class TLogonhours extends WcRecord {
  public int[] day;

  // Total size
  public static final int SIZE = 0+7*4;

  // Constructors
  public TLogonhours()
  {
  }

  public TLogonhours(byte[] x)
  {
    fromByteArray(x);
  }

  // Methods
  protected void writeTo(WcOutputStream out) throws IOException
  {
    super.writeTo(out);
    for (int i = 0; i < 7; i++) {
      if (i < day.length) {
        out.writeInt(day[i]);
      } else {
        out.write(new byte[4]);
      }
    }
  }

  protected void readFrom(WcInputStream in) throws IOException
  {
    super.readFrom(in);
    day = new int[7];
    for (int i = 0; i < 7; i++) {
      day[i] = in.readInt();
    }
  }
}
