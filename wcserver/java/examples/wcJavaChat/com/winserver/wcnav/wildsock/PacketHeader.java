package COM.winserver.wcnav.wildsock;

import java.io.*;
import COM.winserver.wildcat.*;

class PacketHeader {
  static final int SIZE = 20;
  private static final int WCPHOLD_DISABLETIMERRESET = 0x01;

  int size;
  int localport;
  int remoteport;
  boolean disabletimerreset;

  private static int swapshort(int x)
  {
    return ((x << 8) & 0xFF00) | ((x >> 8) & 0xFF);
  }

  PacketHeader(int size, int localport, int remoteport)
  {
    this.size = size;
    this.localport = localport;
    this.remoteport = remoteport;
  }

  PacketHeader(byte[] buf)
  {
    DataInput in = new LittleEndianDataInputStream(new ByteArrayInputStream(buf, 0, SIZE));
    try {
      size = in.readUnsignedShort();
      remoteport = swapshort(in.readUnsignedShort());
      localport = swapshort(in.readUnsignedShort());
      in.skipBytes(4+4+1+1);
      int flags = in.readUnsignedByte();
      disabletimerreset = (flags & WCPHOLD_DISABLETIMERRESET) != 0;
    } catch (IOException iox) {
    }
  }

  byte[] toByteArray()
  {
    ByteArrayOutputStream baos = new ByteArrayOutputStream(2+2+2+4+4+1+1+1+3);
    DataOutput out = new LittleEndianDataOutputStream(baos);
    if (false) {
      //!! new packet header
    } else {
      try {
        out.writeShort(size);
        out.writeShort(swapshort(localport));
        out.writeShort(swapshort(remoteport));
        out.writeInt(0);
        out.writeInt(0);
        out.write(0);
        out.write(0);
        if (disabletimerreset) {
          out.write(WCPHOLD_DISABLETIMERRESET);
        } else {
          out.write(0);
        }
        out.write(0); out.write(0); out.write(0);
      } catch (IOException iox) {
      }
    }
    return baos.toByteArray();
  }
}
