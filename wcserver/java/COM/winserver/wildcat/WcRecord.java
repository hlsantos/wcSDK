package COM.winserver.wildcat;

import java.io.IOException;

public abstract class WcRecord {
  protected void writeTo(WcOutputStream out) throws IOException
  {
  }

  protected void readFrom(WcInputStream in) throws IOException
  {
  }

  public final byte[] toByteArray()
  {
    WcOutputStream out = new WcOutputStream();
    try {
      writeTo(out);
    } catch (IOException iox) {
    }
    return out.toByteArray();
  }

  public final void fromByteArray(byte[] buf)
  {
    WcInputStream in = new WcInputStream(buf);
    try {
      readFrom(in);
    } catch (IOException iox) {
    }
  }
}
