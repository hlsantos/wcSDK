package COM.winserver.wildcat;

import java.io.*;

public class WcOutputStream extends ByteArrayOutputStream {
  private LittleEndianDataOutputStream ledos;

  public WcOutputStream()
  {
    ledos = new LittleEndianDataOutputStream(this);
  }

  public final void writeBoolean(boolean v) throws IOException
  {
    ledos.writeInt(v ? 1 : 0);
  }

  public final void writeByte(int v) throws IOException
  {
    ledos.writeByte(v);
  }

  public final void writeInt(int v) throws IOException
  {
    ledos.writeInt(v);
  }

  public final void writeLong(long v) throws IOException
  {
    ledos.writeLong(v);
  }

  public final void writeShort(int v) throws IOException
  {
    ledos.writeShort(v);
  }

  public final void writeString(String v, int len) throws IOException
  {
    byte[] buf = new byte[len];
    if (v.length() < len) {
      v.getBytes(0, v.length(), buf, 0);
	  // SMC 447.5 JDK 1.1 fix
      //v.getBytes(new String(buf));
    } else {
      v.getBytes(0, len-1, buf, 0);
	  // SMC 447.5 JDK 1.1 fix
	  //v.getBytes(new String(buf));
    }
    write(buf);
  }
}
