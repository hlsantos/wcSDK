// File: TWildcatRequest.java
// (c) copyright 1999 Santronics Software Inc.
//
//****************************************************
// DO NOT EDIT THIS FILE!!!
// CPP2JAVA GENERATED FROM SOURCE FILE: wcgui.h
//****************************************************
//

package COM.winserver.wildcat;

import java.io.IOException;

public class TWildcatRequest extends WcRecord {
  // Constants
  public static final int NAV_STATUS_BASE                   = 0x40000000;
  public static final int NAV_SUCCESS                       = NAV_STATUS_BASE + 0;
  public static final int NAV_DOWNLOAD_OVER_DAILY_KBYTE     = NAV_STATUS_BASE + 1;
  public static final int NAV_DOWNLOAD_OVER_DAILY_COUNT     = NAV_STATUS_BASE + 2;
  public static final int NAV_DOWNLOAD_OVER_KBYTE_RATIO     = NAV_STATUS_BASE + 3;
  public static final int NAV_DOWNLOAD_OVER_DOWNLOAD_RATIO  = NAV_STATUS_BASE + 4;
  public static final int NAV_DOWNLOAD_INSUFFICIENT_BALANCE = NAV_STATUS_BASE + 5;
  public static final int NAV_USER_OUT_OF_TIME              = NAV_STATUS_BASE + 6;
  public static final int NAV_REQUEST_OUT_OF_ORDER          = NAV_STATUS_BASE + 7;
  public static final int NAV_USER_NOT_FOUND                = NAV_STATUS_BASE + 8;
  public static final int SIZE_FILE_DATA_BLOCK = 1024;

  // Members
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
