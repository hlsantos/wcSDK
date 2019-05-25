package COM.winserver.wcnav;

import java.io.*;
import COM.winserver.wildcat.*;
import COM.winserver.wcnav.wildsock.*;

public class WcProxy {
  public static WSocket sendRequest(TWildcatRequest request, WSocketListener listener) throws IOException
  {
    WSocket s = new WSocket(1);
    s.setListener(listener);
    s.getOutputStream().write(request.toByteArray());
    return s;
  }

  public static WSocket sendRequest(TWildcatRequest request) throws IOException
  {
    return sendRequest(request, null);
  }

  public static byte[] getResponse(WSocket s, int size) throws IOException
  {
    byte[] x = new byte[size];
    try {
      int n = s.getInputStream().read(x);
//System.out.println("WcProxy.getResponse ("+s+"): size="+size+", n="+n);
      if (n == size) {
        return x;
      }
    } finally {
      s.close();
    }
    throw new IOException("WcProxy.getResponse failed");
  }

  public static TGetSystemInfo_Response getSystemInfo() throws IOException
  {
    WSocket s = sendRequest(new TWildcatRequest(WildcatRequest.wrGetSystemInfo));
    byte[] x = getResponse(s, TGetSystemInfo_Response.SIZE);
    return new TGetSystemInfo_Response(x);
  }

  public static TGetCurrentUser_Response getCurrentUser() throws IOException
  {
    WSocket s = sendRequest(new TWildcatRequest(WildcatRequest.wrGetCurrentUser));
    byte[] x = getResponse(s, TGetCurrentUser_Response.SIZE);
    return new TGetCurrentUser_Response(x);
  }

  public static TWhosOnline_Response getNodeInfoByName(String name) throws IOException
  {
    TGetNodeInfo_Request r = new TGetNodeInfo_Request();
    r.username = name;
    WSocket s = sendRequest(r);
    byte[] x = getResponse(s, TWhosOnline_Response.SIZE);
    return new TWhosOnline_Response(x);
  }
}
