package COM.winserver.wcnav.wildsock;

class mbuf {
  static final int MT_FREE = 0;
  static final int MT_DATA = 1;
  static final int MT_HEADER = 2;

  mbuf next;
  byte[] data;
  int type;
  int priority;
  long senttime;

  static mbuf getdata(int type, byte[] data)
  {
    return getdata(type, data, 0, data.length);
  }

  static mbuf getdata(int type, byte[] data, int off, int len)
  {
    if (type == MT_FREE || data == null || len <= 0) {
      return null;
    }
    mbuf m = new mbuf();
    m.data = new byte[len];
    System.arraycopy(data, off, m.data, 0, len);
    m.type = type;
    return m;
  }
}
