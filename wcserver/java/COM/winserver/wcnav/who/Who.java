package COM.winserver.wcnav.who;

import java.awt.*;
import java.io.*;
import COM.winserver.wildcat.*;
import COM.winserver.wcnav.wildsock.*;

class WhoFrame extends Frame implements Runnable {
  List list;

  WhoFrame()
  {
    super("Who Is Online");
    resize(600, 400);
    setLayout(new BorderLayout());
    list = new List();
    add("Center", list);
    new Thread(this).start();
  }

  public boolean handleEvent(Event evt)
  {
    if (evt.id == Event.WINDOW_DESTROY) {
      dispose();
      return true;
    }
    return super.handleEvent(evt);
  }

  public void run()
  {
    while (true) {
      try {
        list.clear();
        try {
          WSocket ws = new WSocket(1);
          TWildcatRequest r = new TWildcatRequest();
          r.type = WildcatRequest.wrGetWhosOnline;
          ws.getOutputStream().write(r.toByteArray());
          InputStream in = ws.getInputStream();
          byte[] x = new byte[TWhosOnline_Response.SIZE];
          while (true) {
            int n = in.read(x);
            if (n <= 0) {
              break;
            }
            TWhosOnline_Response rsp = new TWhosOnline_Response();
            rsp.fromByteArray(x);
            list.addItem(rsp.NodeInfo.User.Name);
          }
          ws.close();
        } catch (IOException iox) {
          list.addItem("error: "+iox.getMessage());
        }
        Thread.sleep(5000);
      } catch (InterruptedException ix) {
        break;
      }
    }
  }
}

public class Who implements Runnable {
  public void run()
  {
    Frame w = new WhoFrame();
    w.show();
  }
}
