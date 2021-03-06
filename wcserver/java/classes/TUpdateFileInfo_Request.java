// File: TUpdateFileInfo_Request.java
// (c) copyright 2002 Santronics Software Inc.
//
//****************************************************
// DO NOT EDIT THIS FILE!!!
// CPP2JAVA GENERATED FROM SOURCE FILE: wcgui.h
//****************************************************
//

package COM.winserver.wildcat;

import java.io.IOException;

public class TUpdateFileInfo_Request extends TWildcatRequest {
  public int area;
  public String filename;
  public String origpassword;
  public String description;
  public String password;
  public int updatelongdesc;
  public int longdescbytes;
  public String longdescription;

  // Total size
  public static final int SIZE = TWildcatRequest.SIZE+4+16+32+76+32+4+2+MAX_FILE_LONGDESC_LINES*SIZE_FILE_LONGDESC;

  // Constructors
  public TUpdateFileInfo_Request()
  {
    type = WildcatRequest.wrUpdateFileInfo;
  }

  public TUpdateFileInfo_Request(byte[] x)
  {
    fromByteArray(x);
  }

  // Methods
  protected void writeTo(WcOutputStream out) throws IOException
  {
    super.writeTo(out);
    out.writeInt(area);
    out.writeString(filename, 16);
    out.writeString(origpassword, 32);
    out.writeString(description, 76);
    out.writeString(password, 32);
    out.writeInt(updatelongdesc);
    out.writeShort(longdescbytes);
    out.writeString(longdescription, MAX_FILE_LONGDESC_LINES*SIZE_FILE_LONGDESC);
  }

  protected void readFrom(WcInputStream in) throws IOException
  {
    super.readFrom(in);
    area = in.readInt();
    filename = in.readString(16);
    origpassword = in.readString(32);
    description = in.readString(76);
    password = in.readString(32);
    updatelongdesc = in.readInt();
    longdescbytes = in.readUnsignedShort();
    longdescription = in.readString(MAX_FILE_LONGDESC_LINES*SIZE_FILE_LONGDESC);
  }
}
