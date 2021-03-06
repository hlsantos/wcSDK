// File: TListMessagesBySearch_Request.java
// (c) copyright 2002 Santronics Software Inc.
//
//****************************************************
// DO NOT EDIT THIS FILE!!!
// CPP2JAVA GENERATED FROM SOURCE FILE: wcgui.h
//****************************************************
//

package COM.winserver.wildcat;

import java.io.IOException;

public class TListMessagesBySearch_Request extends TWildcatRequest {
  public String SearchFrom;
  public String SearchTo;
  public String SearchSubject;
  public String SearchBody;
  public int SearchNumber;
  public int sFlags;
  public int flags;

  // Total size
  public static final int SIZE = TWildcatRequest.SIZE+72+72+72+80+4+4+2;

  // Constructors
  public TListMessagesBySearch_Request()
  {
    type = WildcatRequest.wrListMessagesBySearch;
  }

  public TListMessagesBySearch_Request(byte[] x)
  {
    fromByteArray(x);
  }

  // Methods
  protected void writeTo(WcOutputStream out) throws IOException
  {
    super.writeTo(out);
    out.writeString(SearchFrom, 72);
    out.writeString(SearchTo, 72);
    out.writeString(SearchSubject, 72);
    out.writeString(SearchBody, 80);
    out.writeInt(SearchNumber);
    out.writeInt(sFlags);
    out.writeShort(flags);
  }

  protected void readFrom(WcInputStream in) throws IOException
  {
    super.readFrom(in);
    SearchFrom = in.readString(72);
    SearchTo = in.readString(72);
    SearchSubject = in.readString(72);
    SearchBody = in.readString(80);
    SearchNumber = in.readInt();
    sFlags = in.readInt();
    flags = in.readUnsignedShort();
  }
}
