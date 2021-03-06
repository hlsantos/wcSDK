// File: TWildcatNNTP.java
// (c) copyright 2002 Santronics Software Inc.
//
//****************************************************
// DO NOT EDIT THIS FILE!!!
// CPP2JAVA GENERATED FROM SOURCE FILE: wctype.h
//****************************************************
//

package COM.winserver.wildcat;

import java.io.IOException;

public class TWildcatNNTP extends WcRecord {
  public int  dwVersion;
  public int  dwRevision;
  public int dwPort;
  public boolean  AllowAnonymous;
  public int MaxCrossPost;
  public TWildcatLogOptions LogOptions;

  // Total size
  public static final int SIZE = 0+2+2+4+4+4+TWildcatLogOptions.SIZE+80;

  // Constructors
  public TWildcatNNTP()
  {
  }

  public TWildcatNNTP(byte[] x)
  {
    fromByteArray(x);
  }

  // Methods
  protected void writeTo(WcOutputStream out) throws IOException
  {
    super.writeTo(out);
    out.writeShort( dwVersion);
    out.writeShort( dwRevision);
    out.writeInt(dwPort);
    out.writeBoolean( AllowAnonymous);
    out.writeInt(MaxCrossPost);
    LogOptions.writeTo(out);
    out.write(new byte[80]);
  }

  protected void readFrom(WcInputStream in) throws IOException
  {
    super.readFrom(in);
     dwVersion = in.readUnsignedShort();
     dwRevision = in.readUnsignedShort();
    dwPort = in.readInt();
     AllowAnonymous = in.readBoolean();
    MaxCrossPost = in.readInt();
    LogOptions = new TWildcatLogOptions(); LogOptions.readFrom(in);
    in.skip(80);
  }
}
