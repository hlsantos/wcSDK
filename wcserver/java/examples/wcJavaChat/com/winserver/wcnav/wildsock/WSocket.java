package COM.winserver.wcnav.wildsock;

import java.io.*;
import java.util.Vector;

public class WSocket {
  int localport;
  int remoteport;
  boolean idlereset;
  int priority;
  boolean active;

  private WSocketInputStream In;
  private OutputStream Out;
  WSocketListener Listener;

  static DataLinkLayer dll;
  static int NextLocalPort = 1024;
  static Vector SocketTable = new Vector();

  public WSocket(int port)
  {
    this(port, true);
  }

  public WSocket(int port, boolean stream)
  {
    localport = getNextLocalPort();
    remoteport = port;
    active = true;
    In = new WSocketInputStream(this);
    Out = new WSocketOutputStream(this);
    addSocket(this);
//System.out.println("Opened "+this);
  }

  protected void finalize()
  {
    close();
  }

  public synchronized void close()
  {
//System.out.println("Closing "+this);
//System.out.println("  thread="+Thread.currentThread());
    if (!active) {
//System.out.println("  !active");
      return;
    }
//System.out.println("  setting active=false");
    active = false;
    if (dll != null) {
//System.out.println("  creating close packet");
      mbuf m = mbuf.getdata(mbuf.MT_HEADER, new PacketHeader(0, localport, remoteport).toByteArray());
//System.out.println("  sending close packet");
      dll.SendMbuf(m, true, idlereset, priority);
    }
//System.out.println("  closing input");
    In.close();
    //In = null;
    //Out = null;
//System.out.println("  removing socket");
    removeSocket(this);
    if (Listener != null) {
//System.out.println("  notifying listener");
      Listener.socketNotify(this);
    }
//System.out.println("  done");
  }

  public InputStream getInputStream()
  {
    return In;
  }

  public int getLocalPort()
  {
    return localport;
  }

  public OutputStream getOutputStream()
  {
    return Out;
  }

  public int getPort()
  {
    return remoteport;
  }

  public synchronized void setListener(WSocketListener listener)
  {
    this.Listener = listener;
  }

  public String toString()
  {
    return super.toString() + "[localport="+localport+",remoteport="+remoteport+",active="+active+"]";
  }

  private boolean receiveHandler(PacketHeader ph, mbuf m)
  {
    int datalen = ph.size - PacketHeader.SIZE;
//System.out.println("WSocket.receiveHandler: datalen="+datalen);
    if (datalen == 0) {
      close();
      return false;
    }
    In.receiveHandler(ph, m, datalen);
    if (Listener != null) {
      Listener.socketNotify(this);
    }
    return idlereset;
  }

  public static synchronized void setDataLinkLayer(DataLinkLayer dll)
  {
//System.out.println("WSocket.setDataLinkLayer("+dll+")");
//System.out.println("  currently dll="+(WSocket.dll == null ? "(null)" : "something"));
    if (dll == null) {
      WSocket.dll = null;
      synchronized (SocketTable) {
        for (int i = 0; i < SocketTable.size(); i++) {
System.out.println("  closing "+SocketTable.elementAt(i));
          ((WSocket)SocketTable.elementAt(i)).close();
        }
        SocketTable.removeAllElements();
      }
System.out.println("  sockets cleaned up");
    } else if (WSocket.dll == null) {
      WSocket.dll = dll;
    }
  }

  static boolean fromDatalink(mbuf m)
  {
    PacketHeader ph = new PacketHeader(m.data);
    WSocket s;
    synchronized (SocketTable) {
      int i = findSocketIndex(ph.localport, true);
//System.out.println("WSocket.fromDatalink: localport="+ph.localport+",i="+i);
      if (i < 0) {
        return false;
      }
      s = (WSocket)SocketTable.elementAt(i);
    }
    return s.receiveHandler(ph, m);
  }

  private static synchronized int getNextLocalPort()
  {
    while (true) {
      if (NextLocalPort >= 65536) {
        NextLocalPort = 1024;
      }
      if (findSocketIndex(NextLocalPort, true) == -1) {
        return NextLocalPort++;
      }
    }
  }

  private static void addSocket(WSocket socket)
  {
    synchronized (SocketTable) {
      int i = findSocketIndex(socket.localport, false);
      SocketTable.insertElementAt(socket, i);
    }
  }

  private static void removeSocket(WSocket socket)
  {
    synchronized (SocketTable) {
      int i = findSocketIndex(socket.localport, true);
      if (i >= 0) {
        SocketTable.removeElementAt(i);
      }
    }
  }

  private static int findSocketIndex(int localport, boolean match)
  {
    synchronized (SocketTable) {
      int l = 0;
      int r = SocketTable.size() - 1;
      while (l <= r) {
        int m = (l + r) / 2;
        int p = ((WSocket)SocketTable.elementAt(m)).localport;
        if (localport == p) {
          return m;
        } else if (localport < p) {
          r = m - 1;
        } else {
          l = m + 1;
        }
      }
      if (match) {
        return -1;
      }
      return r + 1;
    }
  }
}

class WSocketOutputStream extends OutputStream {
  WSocket socket;

  WSocketOutputStream(WSocket socket)
  {
    this.socket = socket;
  }

  public synchronized void write(byte[] b, int off, int len)
  {
    if (!socket.active || socket.dll == null) {
      return;
    }
    mbuf m = mbuf.getdata(mbuf.MT_HEADER, new PacketHeader(len, socket.localport, socket.remoteport).toByteArray());
    m.next = mbuf.getdata(mbuf.MT_DATA, b, off, len);
    socket.dll.SendMbuf(m, false, socket.idlereset, socket.priority);
  }

  public void write(int b)
  {
    byte[] a = new byte[1];
    a[0] = (byte)b;
    write(a, 0, 1);
  }
}

class WSocketInputStream extends InputStream {
  WSocket socket;
  mbuf data;
  mbuf last;
  int index;

  WSocketInputStream(WSocket socket)
  {
    this.socket = socket;
  }

  public synchronized int available() throws IOException
  {
    if (!socket.active) {
      return 0;
    }
    int n = 0;
    mbuf p = data;
    int t = index;
    while (p != null) {
      if (t == 0 && p.type == mbuf.MT_HEADER) {
        t = PacketHeader.SIZE;
      }
      n += p.data.length - t;
      t += n;
      if (t >= p.data.length) {
        t = 0;
        p = p.next;
      }
    }
    return n;
  }

  public synchronized void close()
  {
    notifyAll();
    try {
      super.close();
    } catch (IOException iox) {
    }
  }

  public synchronized int read(byte b[], int off, int len) throws IOException
  {
    while (socket.active && data == null) {
      try {
        wait();
      } catch (InterruptedException ix) {
        throw new IOException(ix.getMessage());
      }
    }
    if (!socket.active && data == null) {
      return -1;
    }
    int read = 0;
    while (len > 0 && data != null) {
      if (index == 0 && data.type == mbuf.MT_HEADER) {
        index = PacketHeader.SIZE;
      }
      int n = data.data.length - index;
      if (n > len) {
        n = len;
      }
      System.arraycopy(data.data, index, b, off, n);
      index += n;
      off += n;
      read += n;
      len -= n;
      if (index >= data.data.length) {
        index = 0;
        data = data.next;
      }
    }
    return read;
  }

  public synchronized int read() throws IOException
  {
    while (socket.active && data == null) {
      try {
        wait();
      } catch (InterruptedException ix) {
        throw new IOException(ix.getMessage());
      }
    }
    if (!socket.active && data == null) {
      return -1;
    }
    if (index == 0 && data.type == mbuf.MT_HEADER) {
      index = PacketHeader.SIZE;
    }
    int r = data.data[index++];
    if (index >= data.data.length) {
      index = 0;
      data = data.next;
    }
    return r;
  }

  synchronized void receiveHandler(PacketHeader ph, mbuf m, int datalen)
  {
//System.out.println("WSocketInputStream.receiveHandler: data="+((data!=null)?data.toString():"(null)")+",datalen="+datalen);
    if (data == null) {
      data = m;
      last = m;
    } else {
      last.next = m;
      last = m;
    }
    notifyAll();
  }
}
