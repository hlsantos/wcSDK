// File: TComputerConfig.java
// (c) copyright 2002 Santronics Software Inc.
//
//****************************************************
// DO NOT EDIT THIS FILE!!!
// CPP2JAVA GENERATED FROM SOURCE FILE: wctype.h
//****************************************************
//

package COM.winserver.wildcat;

import java.io.IOException;

public class TComputerConfig extends WcRecord {
  public String Name;
  public String DoorPath;
  public String CgiPath;
  public int HttpPort;
  public int FtpPort;
  public String WWWHostname;
  public int Servers;
  public int HttpProxyPort;

  public int  dwVersion;
  public int  dwRevision;
  public TWildcatComputerIpPort ipportHttp;
  public TWildcatComputerIpPort ipportFtp;
  public TWildcatComputerIpPort ipportPop3;
  public TWildcatComputerIpPort ipportTelnet;
  public TWildcatComputerIpPort ipportSmtp;
  public TWildcatComputerIpPort ipportNntp;

  // Total size
  public static final int SIZE = 0+16+260+260+4+4+80+4+4+2+2+TWildcatComputerIpPort.SIZE+TWildcatComputerIpPort.SIZE+TWildcatComputerIpPort.SIZE+TWildcatComputerIpPort.SIZE+TWildcatComputerIpPort.SIZE+TWildcatComputerIpPort.SIZE+340*1;

  // Constructors
  public TComputerConfig()
  {
  }

  public TComputerConfig(byte[] x)
  {
    fromByteArray(x);
  }

  // Methods
  protected void writeTo(WcOutputStream out) throws IOException
  {
    super.writeTo(out);
    out.writeString(Name, 16);
    out.writeString(DoorPath, 260);
    out.writeString(CgiPath, 260);
    out.writeInt(HttpPort);
    out.writeInt(FtpPort);
    out.writeString(WWWHostname, 80);
    out.writeInt(Servers);
    out.writeInt(HttpProxyPort);
    out.writeShort( dwVersion);
    out.writeShort( dwRevision);
    ipportHttp.writeTo(out);
    ipportFtp.writeTo(out);
    ipportPop3.writeTo(out);
    ipportTelnet.writeTo(out);
    ipportSmtp.writeTo(out);
    ipportNntp.writeTo(out);
    out.write(new byte[340*1]);
  }

  protected void readFrom(WcInputStream in) throws IOException
  {
    super.readFrom(in);
    Name = in.readString(16);
    DoorPath = in.readString(260);
    CgiPath = in.readString(260);
    HttpPort = in.readInt();
    FtpPort = in.readInt();
    WWWHostname = in.readString(80);
    Servers = in.readInt();
    HttpProxyPort = in.readInt();
     dwVersion = in.readUnsignedShort();
     dwRevision = in.readUnsignedShort();
    ipportHttp = new TWildcatComputerIpPort(); ipportHttp.readFrom(in);
    ipportFtp = new TWildcatComputerIpPort(); ipportFtp.readFrom(in);
    ipportPop3 = new TWildcatComputerIpPort(); ipportPop3.readFrom(in);
    ipportTelnet = new TWildcatComputerIpPort(); ipportTelnet.readFrom(in);
    ipportSmtp = new TWildcatComputerIpPort(); ipportSmtp.readFrom(in);
    ipportNntp = new TWildcatComputerIpPort(); ipportNntp.readFrom(in);
    in.skip(340*1);
  }
}
