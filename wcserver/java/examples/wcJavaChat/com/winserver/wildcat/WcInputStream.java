package COM.winserver.wildcat;

import java.io.*;

public class WcInputStream extends ByteArrayInputStream {
  private LittleEndianDataInputStream ledis;

  public WcInputStream(byte buf[])
  {
    super(buf);
    ledis = new LittleEndianDataInputStream(this);
  }

  private int arraylen(byte[] x)
  {
    int n = 0;
    while (n < x.length && x[n] != 0) {
      n++;
    }
    return n;
  }

  public final boolean readBoolean() throws IOException
  {
    return ledis.readInt() != 0;
  }

  public final int readInt() throws IOException
  {
    return ledis.readInt();
  }

  public final long readLong() throws IOException
  {
    return ledis.readLong();
  }

  public final String readString(int len) throws IOException
  {
    byte buf[] = new byte[len];
    read(buf);
    return new String(buf, 0, 0, arraylen(buf));
	// SMC 447.5 JDK 1.1 fix
	//return new String(buf);
  }

  public final int readUnsignedByte() throws IOException
  {
    return ledis.readUnsignedByte();
  }

  public final int readUnsignedShort() throws IOException
  {
    return ledis.readUnsignedShort();
  }
}
