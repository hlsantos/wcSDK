package COM.winserver.wcnav.wildsock;

import java.io.*;
import java.net.*;
import java.util.*;

class PPP {
  static final int BUFFER_SIZE = 8192;
  static final int HEADER_SIZE = 5;
  static final int FCS_SIZE    = 2;

  static final int ALLSTATIONS   = 0xff;
  static final int UI            = 0x03;
  static final int UI_COMPRESSED = 0x83;
  static final int FLAG          = 0x7e;
  static final int ESCAPE        = 0x7d;
  static final int TRANS         = 0x20;

  static final int WCP = 0x0022;
  static final int ERR = 0x0023;
  static final int LCP = 0xc021;

  static final int INITFCS = 0xffff;
  static final int GOODFCS = 0xf0b8;

  static final int ACK = 1;
  static final int NAK = 2;
  static final int UNNAK = 3;

  static final int MAX_WINDOW = 8;
  static final int MAX_QUEUE = 16;

  static final int CC_IDLE_KICK           = 0x00;
  static final int CC_COMPRESSION_REQUEST = 0x01;
  static final int CC_COMPRESSION_ACK     = 0x02;
  static final int CC_ACKLESS_REQUEST     = 0x03;
  static final int CC_ACKLESS_ACK         = 0x04;
  static final int CC_PROTOCOL_REQUEST    = 0x05;
  static final int CC_PROTOCOL_ACK        = 0x06;

  static final int COMPRESSION_NONE    = 0x00;
  static final int COMPRESSION_ZERORLE = 0x01;

  static final int PACKETHEADER_OLD = 0x00;
  static final int PACKETHEADER_NEW = 0x01;

  static int fcstab[] = {
    0x0000, 0x1189, 0x2312, 0x329b, 0x4624, 0x57ad, 0x6536, 0x74bf,
    0x8c48, 0x9dc1, 0xaf5a, 0xbed3, 0xca6c, 0xdbe5, 0xe97e, 0xf8f7,
    0x1081, 0x0108, 0x3393, 0x221a, 0x56a5, 0x472c, 0x75b7, 0x643e,
    0x9cc9, 0x8d40, 0xbfdb, 0xae52, 0xdaed, 0xcb64, 0xf9ff, 0xe876,
    0x2102, 0x308b, 0x0210, 0x1399, 0x6726, 0x76af, 0x4434, 0x55bd,
    0xad4a, 0xbcc3, 0x8e58, 0x9fd1, 0xeb6e, 0xfae7, 0xc87c, 0xd9f5,
    0x3183, 0x200a, 0x1291, 0x0318, 0x77a7, 0x662e, 0x54b5, 0x453c,
    0xbdcb, 0xac42, 0x9ed9, 0x8f50, 0xfbef, 0xea66, 0xd8fd, 0xc974,
    0x4204, 0x538d, 0x6116, 0x709f, 0x0420, 0x15a9, 0x2732, 0x36bb,
    0xce4c, 0xdfc5, 0xed5e, 0xfcd7, 0x8868, 0x99e1, 0xab7a, 0xbaf3,
    0x5285, 0x430c, 0x7197, 0x601e, 0x14a1, 0x0528, 0x37b3, 0x263a,
    0xdecd, 0xcf44, 0xfddf, 0xec56, 0x98e9, 0x8960, 0xbbfb, 0xaa72,
    0x6306, 0x728f, 0x4014, 0x519d, 0x2522, 0x34ab, 0x0630, 0x17b9,
    0xef4e, 0xfec7, 0xcc5c, 0xddd5, 0xa96a, 0xb8e3, 0x8a78, 0x9bf1,
    0x7387, 0x620e, 0x5095, 0x411c, 0x35a3, 0x242a, 0x16b1, 0x0738,
    0xffcf, 0xee46, 0xdcdd, 0xcd54, 0xb9eb, 0xa862, 0x9af9, 0x8b70,
    0x8408, 0x9581, 0xa71a, 0xb693, 0xc22c, 0xd3a5, 0xe13e, 0xf0b7,
    0x0840, 0x19c9, 0x2b52, 0x3adb, 0x4e64, 0x5fed, 0x6d76, 0x7cff,
    0x9489, 0x8500, 0xb79b, 0xa612, 0xd2ad, 0xc324, 0xf1bf, 0xe036,
    0x18c1, 0x0948, 0x3bd3, 0x2a5a, 0x5ee5, 0x4f6c, 0x7df7, 0x6c7e,
    0xa50a, 0xb483, 0x8618, 0x9791, 0xe32e, 0xf2a7, 0xc03c, 0xd1b5,
    0x2942, 0x38cb, 0x0a50, 0x1bd9, 0x6f66, 0x7eef, 0x4c74, 0x5dfd,
    0xb58b, 0xa402, 0x9699, 0x8710, 0xf3af, 0xe226, 0xd0bd, 0xc134,
    0x39c3, 0x284a, 0x1ad1, 0x0b58, 0x7fe7, 0x6e6e, 0x5cf5, 0x4d7c,
    0xc60c, 0xd785, 0xe51e, 0xf497, 0x8028, 0x91a1, 0xa33a, 0xb2b3,
    0x4a44, 0x5bcd, 0x6956, 0x78df, 0x0c60, 0x1de9, 0x2f72, 0x3efb,
    0xd68d, 0xc704, 0xf59f, 0xe416, 0x90a9, 0x8120, 0xb3bb, 0xa232,
    0x5ac5, 0x4b4c, 0x79d7, 0x685e, 0x1ce1, 0x0d68, 0x3ff3, 0x2e7a,
    0xe70e, 0xf687, 0xc41c, 0xd595, 0xa12a, 0xb0a3, 0x8238, 0x93b1,
    0x6b46, 0x7acf, 0x4854, 0x59dd, 0x2d62, 0x3ceb, 0x0e70, 0x1ff9,
    0xf78f, 0xe606, 0xd49d, 0xc514, 0xb1ab, 0xa022, 0x92b9, 0x8330,
    0x7bc7, 0x6a4e, 0x58d5, 0x495c, 0x3de3, 0x2c6a, 0x1ef1, 0x0f78
  };

  static int FCS(int fcs, int b)
  {
    return ((fcs >> 8) & 0xFF) ^ fcstab[(fcs ^ b) & 0xFF];
  }
}

class Seq {
  static int next(int seq)
  {
    if (seq == 0xff) {
      return 1;
    } else {
      return seq + 1;
    }
  }

  static int prev(int seq)
  {
    if (seq == 1) {
      return 0xff;
    } else {
      return seq - 1;
    }
  }

  static int diff(int y, int x)
  {
    if (y >= x) {
      return y - x;
    } else {
      return (y - x - 1) & 0xff;
    }
  }
}

class PacketOutputStream extends ByteArrayOutputStream {
  private int fcs = PPP.INITFCS;

  void add(byte[] b)
  {
    for (int i = 0; i < b.length; i++) {
      add(b[i]);
    }
  }

  void add(int b)
  {
    b &= 0xff;
    if (b == PPP.FLAG || b == PPP.ESCAPE || b == 0xff) {
      write(PPP.ESCAPE);
      write(b ^ PPP.TRANS);
    } else {
      write(b);
    }
    fcs = PPP.FCS(fcs, b);
  }

  void addFCS()
  {
    int x = fcs ^ 0xFFFF;
    add(x);
    add(x >> 8);
  }
}

public class DataLinkLayer extends Thread {
  private static final boolean TRACEIN = false;
  private static final boolean TRACEOUT = false;

  Socket Sock;
  private OutputStream output;
  private Thread ReceiveThread;

  long turnaround;

  // ui state variables
  private long ui_lastactivity;

  // transmitter state
  private int send_lastgoodseq;
  private Vector PendingQueue = new Vector();
  private int send_pending;
  private int send_compression;
  private boolean send_ackless;

  // receiver state
  private int recv_lastseq;
  private boolean recv_naked;
  private long recv_timenaked;
  private int recv_compression;
  private boolean recv_ackless;

  public DataLinkLayer(Socket socket) throws IOException
  {
    Sock = socket;
    output = Sock.getOutputStream();

    ui_lastactivity = 0;

    turnaround = 10000;

    send_lastgoodseq = 0;
    send_pending = 0;
    send_compression = PPP.COMPRESSION_NONE;
    send_ackless = false;

    recv_lastseq = 0;
    recv_naked = false;
    recv_timenaked = 0;
    recv_compression = PPP.COMPRESSION_NONE;
    recv_ackless = false;

    ReceiveThread = new Receiver(this);
  }

  public void start()
  {
    WSocket.setDataLinkLayer(this);
    ReceiveThread.start();
    super.start();
    SendConfigureRequest(0, 0);
    //!!SendConfigureRequest(PPP.CC_COMPRESSION_REQUEST, COMPRESSION_ZERORLE);
    SendConfigureRequest(PPP.CC_ACKLESS_REQUEST, 1);
    //!!SendConfigureRequest(PPP.CC_PROTOCOL_REQUEST, PPP.PACKETHEADER_NEW);
  }

  public void run()
  {
    try {
      try {
        while (true) {
          sleep(1000);
          tick();
        }
      } catch (InterruptedException ix) {
      }
    } finally {
      ReceiveThread.stop();
      WSocket.setDataLinkLayer(null);
    }
  }

  private boolean Send(byte[] data, int protocol)
  {
    try {
      PacketOutputStream pos = new PacketOutputStream();
      pos.write(PPP.FLAG);
      pos.add(PPP.ALLSTATIONS);
      pos.add((send_compression != PPP.COMPRESSION_NONE ? PPP.UI_COMPRESSED : PPP.UI));
      pos.add(protocol >> 8);
      pos.add(protocol);
      pos.add(0);
      pos.add(data);
      pos.addFCS();
      pos.write(PPP.FLAG);
      pos.writeTo(output);
      //if (TRACEOUT) {
      //  byte[] xx = pos.toByteArray();
      //  System.out.print("out: ");
      //  for (int i = 0; i < xx.length; i++) {
      //    System.out.print(Integer.toHexString(xx[i]&0xff)+" ");
      //  }
      //  System.out.println();
      //}
    } catch (IOException iox) {
      return false;
    }
    return true;
  }

  private boolean Send(mbuf m, int seq)
  {
    try {
      PacketOutputStream pos = new PacketOutputStream();
      pos.write(PPP.FLAG);
      pos.add(PPP.ALLSTATIONS);
      pos.add((send_compression != PPP.COMPRESSION_NONE ? PPP.UI_COMPRESSED : PPP.UI));
      pos.add(PPP.WCP >> 8);
      pos.add(PPP.WCP);
      pos.add(seq);
      while (m != null) {
        pos.add(m.data);
        m = m.next;
      }
      pos.addFCS();
      pos.write(PPP.FLAG);
      pos.writeTo(output);
      //if (TRACEOUT) {
      //  byte[] xx = pos.toByteArray();
      //  System.out.print("out: ");
      //  for (int i = 0; i < xx.length; i++) {
      //    System.out.print(Integer.toHexString(xx[i]&0xff)+" ");
      //  }
      //  System.out.println();
      //}
    } catch (IOException iox) {
      return false;
    }
    return true;
  }

  private synchronized void tick()
  {
    mbuf m;
    synchronized (PendingQueue) {
      if (send_pending >= PPP.MAX_WINDOW || send_pending >= PendingQueue.size()) {
        return;
      }
      if (TRACEOUT) System.out.println("sending pending "+send_pending);
      m = (mbuf)PendingQueue.elementAt(send_pending);
    }
    m.senttime = System.currentTimeMillis();
    send_pending++;
    int seq = send_lastgoodseq;
    for (int i = 0; i < send_pending; i++) {
      seq = Seq.next(seq);
    }
    if (TRACEOUT) System.out.println("  seq "+seq);
    m.priority = 0;
    if (Send(m, seq)) {
      if (send_ackless) {
        GotAck(seq);
      }
    } else {
      send_pending--;
    }
  }

  boolean SendMbuf(mbuf m, boolean forcequeue, boolean dotimeout, int priority)
  {
    synchronized (PendingQueue) {
      try {
        while (!forcequeue && PendingQueue.size() >= PPP.MAX_QUEUE) {
//System.out.println("DataLinkLayer.SendMbuf: PendingQueue.size()="+PendingQueue.size());
          PendingQueue.wait();
        }
      } catch (InterruptedException ix) {
        return false;
      }
      m.priority = priority;
      int i = PendingQueue.size();
      while (i > send_pending && ((mbuf)PendingQueue.elementAt(i-1)).priority > priority) {
        i--;
      }
      PendingQueue.insertElementAt(m, i);
      if (dotimeout) {
        ui_lastactivity = System.currentTimeMillis();
      }
      if (!forcequeue) { // this check helps ensure we don't get into a circular lock
        tick();
      }
    }
    return true;
  }

  private void SendConfigureRequest(int cflags, int csubopt)
  {
    byte[] packet = new byte[4];
    packet[0] = 1;
    packet[1] = (byte)cflags;
    packet[2] = (byte)csubopt;
    Send(packet, PPP.LCP);
  }

  private void SendControl(int err, int seq)
  {
    byte[] p = new byte[2];
    if (err == PPP.NAK) {
      recv_naked = true;
      recv_timenaked = System.currentTimeMillis();
    }
    p[0] = (byte)err;
    p[1] = (byte)seq;
    Send(p, PPP.ERR);
  }

  private void SendAck(int seq)
  {
    SendControl(PPP.ACK, seq);
  }

  synchronized void SendNak()
  {
    SendControl(PPP.NAK, recv_lastseq);
  }

  private void SendUNNak()
  {
    SendControl(PPP.UNNAK, 0);
  }

  private synchronized void GotAck(int seq)
  {
    if (TRACEIN) System.out.println("Got ack for "+seq);
    if (send_pending == 0) {
      if (TRACEIN) System.out.println("  \u0007weird, no outstanding packets (lastgoodseq="+send_lastgoodseq+")");
      return;
    }
    if (seq != Seq.next(send_lastgoodseq)) {
      if (TRACEIN) System.out.println("  \u0007not the right packet, looking for "+Seq.next(send_lastgoodseq));
      return;
    }
    synchronized (PendingQueue) {
      mbuf m = (mbuf)PendingQueue.elementAt(0);
      long t = System.currentTimeMillis() - m.senttime;
      if (t < turnaround) {
        turnaround = (99*turnaround + t) / 100;
      } else {
        turnaround = t;
      }
      if (TRACEIN) System.out.println("  ack time="+t+", new turnaround="+turnaround);
      PendingQueue.removeElementAt(0);
      send_pending--;
      send_lastgoodseq = seq;
      PendingQueue.notifyAll();
    }
  }

  private void GotNak(int seq)
  {
    if (TRACEIN) System.out.println("\u0007got nak for "+seq);
    if (send_pending == 0) {
      if (TRACEIN) System.out.println("  none pending, send unnak");
      SendUNNak();
      return;
    }
    send_pending = 0;
  }

  synchronized void ProcessBuffer(byte[] Buffer, int BufferSize)
  {
    if (BufferSize < PPP.HEADER_SIZE) {
      if (TRACEIN) System.out.println("\u0007received short frame");
      return;
    }
    int address = Buffer[0] & 0xff;
    int control = Buffer[1] & 0xff;
    int protocol = ((Buffer[2] & 0xff) << 8) | (Buffer[3] & 0xff);
    int curseq = Buffer[4] & 0xff;
    if (curseq != 0) {
      if (TRACEIN) System.out.println("received frame, seq="+curseq);
      if (recv_naked) {
        if (curseq != Seq.next(recv_lastseq)) {
          if (TRACEIN) System.out.println("  \u0007naked, not the right packet (looking for "+Seq.next(recv_lastseq)+")");
          return;
        }
        if (TRACEIN) System.out.println("  naked, got the right packet");
        recv_naked = false;
      }
      if (curseq != Seq.next(recv_lastseq)) {
        if (TRACEIN) System.out.println("  \u0007not the right sequence number (looking for "+Seq.next(recv_lastseq)+")");
        if (Seq.diff(recv_lastseq, curseq) <= PPP.MAX_WINDOW*3) {
          if (TRACEIN) System.out.println("  \u0007duplicate packet acked (distance "+Seq.diff(recv_lastseq, curseq)+")");
          SendAck(curseq);
        }
        return;
      }
    }
    if (address != PPP.ALLSTATIONS) {
      if (TRACEIN) System.out.println("  \u0007allstations error");
      SendNak();
      return;
    }
    if (control != PPP.UI && control != PPP.UI_COMPRESSED) {
      if (TRACEIN) System.out.println("  \u0007ui error");
      SendNak();
      return;
    }
    if (TRACEIN) System.out.println("  recv seq "+curseq);
    int datasize = BufferSize - PPP.HEADER_SIZE - PPP.FCS_SIZE;
    byte[] data = new byte[PPP.BUFFER_SIZE];
    if (control == PPP.UI_COMPRESSED) {
      return; //!!
      //if (recv_compression == COMPRESSION_ZERORLE) {
      //  //!!
      //} else {
      //  SendNak();
      //  return;
      //}
    } else {
      System.arraycopy(Buffer, PPP.HEADER_SIZE, data, 0, datasize);
    }
    switch (protocol) {
      case PPP.LCP:
        switch (data[1]) {
          case PPP.CC_IDLE_KICK:
            if (TRACEIN) System.out.println("got idle kick");
            ui_lastactivity = System.currentTimeMillis();
            break;
          case PPP.CC_COMPRESSION_REQUEST:
            if (TRACEIN) System.out.println("got compression request: "+data[2]);
            //!!if (data[2] == COMPRESSION_ZERORLE) {
            //  SendConfigureRequest(CC_COMPRESSION_ACK, data[2]);
            //  recv_compression = data[2];
            //}
            break;
          case PPP.CC_COMPRESSION_ACK:
            if (TRACEIN) System.out.println("got compression ack: "+data[2]);
            //!!if (data[2] == COMPRESSION_ZERORLE) {
            //  send_compression = data[2];
            //}
            break;
          case PPP.CC_ACKLESS_REQUEST:
            if (TRACEIN) System.out.println("got ackless request: "+data[2]);
            if (data[2] != 0) {
              SendConfigureRequest(PPP.CC_ACKLESS_ACK, data[2]);
              recv_ackless = data[2] != 0;
            }
            break;
          case PPP.CC_ACKLESS_ACK:
            if (TRACEIN) System.out.println("got ackless ack: "+data[2]);
            if (data[2] != 0) {
              while (send_pending > 0) {
                GotAck(Seq.next(send_lastgoodseq));
              }
              send_ackless = data[2] != 0;
            }
            break;
          case PPP.CC_PROTOCOL_REQUEST:
            if (TRACEIN) System.out.println("got protocol request: "+data[2]);
            //!!if (data[2] == PPP.PACKETHEADER_NEW) {
            //  SendConfigureRequest(PPP.CC_PROTOCOL_ACK, data[2]);
            //}
            break;
          case PPP.CC_PROTOCOL_ACK:
            if (TRACEIN) System.out.println("got protocol ack: "+data[2]);
            //!!if (data[2] == PPP.PACKETHEADER_NEW) {
            //  SendNewPacketHeader = true;
            //}
            break;
        }
        break;
      case PPP.WCP:
        if (!recv_ackless) {
          SendAck(curseq);
        }
        recv_lastseq = curseq;
        mbuf m = mbuf.getdata(mbuf.MT_HEADER, data, 0, datasize);
//System.out.println("DataLinkLayer.ProcessBuffer: thread="+Thread.currentThread());
        if (WSocket.fromDatalink(m)) {
          ui_lastactivity = System.currentTimeMillis();
        }
        break;
      case PPP.ERR:
        switch (data[0]) {
          case PPP.ACK:
            GotAck(data[1]);
            break;
          case PPP.NAK:
            GotNak(data[1]);
            break;
          case PPP.UNNAK:
            recv_naked = false;
            break;
        }
        break;
    }
  }
}

class Receiver extends Thread {
  private static final boolean TRACE = false;

  private DataLinkLayer dll;
  private InputStream input;
  
  private byte[] Buffer = new byte[PPP.BUFFER_SIZE];
  private int BufferSize = 0;
  private int fcs;
  private boolean escaped;
  private boolean onegoodpacket;

  public Receiver(DataLinkLayer dll) throws IOException
  {
    this.dll = dll;
    input = dll.Sock.getInputStream();
    BufferSize = 0;
    fcs = PPP.INITFCS;
    escaped = false;
    onegoodpacket = false;
  }

  public void run()
  {
    if (TRACE) System.out.println("Receiver: thread start");
    byte[] buf = new byte[PPP.BUFFER_SIZE];
    while (true) {
      int len;
      try {
        len = input.read(buf);
      } catch (IOException iox) {
        if (TRACE) System.out.println("Receiver: IOException bailout");
        break;
      }
      if (TRACE) System.out.println("Receiver: got "+len+" bytes: "+new String(buf, 0, 0, len));
	  // SMC 447.5 JDK1.1 fix
	  //if (TRACE) System.out.println("Receiver: got "+len+" bytes: "+new String(buf));
      if (len <= 0) {
        break;
      }
      for (int i = 0; i < len; i++) {
        switch (buf[i]) {
          case PPP.FLAG:
            if (BufferSize > 0) {
              if (escaped) {
                break;
              }
              if (fcs == PPP.GOODFCS) {
                dll.ProcessBuffer(Buffer, BufferSize);
                onegoodpacket = true;
              } else if (onegoodpacket) {
                if (TRACE) System.out.println("Receiver: bad fcs "+Integer.toHexString(fcs));
                dll.SendNak();
              }
            }
            BufferSize = 0;
            fcs = PPP.INITFCS;
            break;
          case PPP.ESCAPE:
            escaped = true;
            i++;
            if (i >= len) {
              break;
            }
            if (buf[i] == PPP.FLAG) {
              BufferSize = 0;
              break;
            }
            Buffer[BufferSize] = (byte)(buf[i] ^ PPP.TRANS);
            fcs = PPP.FCS(fcs, Buffer[BufferSize++]);
            escaped = false;
            break;
          default:
            if (escaped) {
              if (buf[i] == PPP.FLAG) {
                BufferSize = 0;
                break;
              }
              Buffer[BufferSize] = (byte)(buf[i] ^ PPP.TRANS);
              escaped = false;
            } else {
              Buffer[BufferSize] = buf[i];
            }
            fcs = PPP.FCS(fcs, Buffer[BufferSize++]);
            break;
        }
        if (BufferSize >= PPP.BUFFER_SIZE-1) {
          if (TRACE) System.out.println("Receiver: buffer overflow");
          BufferSize = 0;
        }
      }
    }
  }
}
