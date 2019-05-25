package COM.winserver.wcnav;

import java.applet.*;
import java.awt.*;
import java.io.*;
import java.net.*;
import java.util.*;
import COM.winserver.wildcat.*;
import COM.winserver.wcnav.wildsock.*;

class ClientInfo {
  String name;
  String classname;

  ClientInfo(String name, String classname)
  {
    this.name = name;
    this.classname = classname;
  }
}

public class Wcnav extends Applet {
  Socket TelnetSocket;
  DataLinkLayer Dll;
  Vector ClientInfos = new Vector();
  Vector RunningClients = new Vector();
  Label info;

  private boolean runClient(String clientClass)
  {
    try {
      Class cclass = Class.forName(clientClass);
      Object client = cclass.newInstance();
      if (client instanceof WcnavClient) {
        WcnavClient wclient = (WcnavClient)client;
        RunningClients.addElement(wclient);
        Thread t = new Thread(wclient);
        t.start();
        return true;
      }
    } catch (Exception x) {
      showStatus(x.getMessage());
    }
    return false;
  }

  private boolean connect(String host)
  {
    try {
      TelnetSocket = new Socket(host, 23);
      Dll = new DataLinkLayer(TelnetSocket);
      try {
        Thread.sleep(1000);
      } catch (InterruptedException ix) {
      }
      Dll.start();
    } catch (IOException iox) {
      return false;
    }
    return true;
  }

  private boolean login(String name, String password)
  {
System.out.println("login("+name+", "+password+")");
    try {
      TLoginUser_Request login = new TLoginUser_Request();
      login.ClientRequestTypes = WildcatRequest.wrMAX;
      login.Name = name;
      login.Password = password != null ? password.toUpperCase() : null;
      WSocket s = WcProxy.sendRequest(login);

System.out.println("login(): sent request");

      byte[] x = WcProxy.getResponse(s, TLoginUser_Response.SIZE);

System.out.println("login(): got response");

      TLoginUser_Response loginr = new TLoginUser_Response();
      loginr.fromByteArray(x);

System.out.println("error = " + loginr.error);
System.out.println("SystemAccess = " + loginr.SystemAccess);
System.out.println("MaxLoginAttempts = " + loginr.MaxLoginAttempts);
System.out.println("Info = " + loginr.Info);
System.out.println("WWWHostname = " + loginr.WWWHostname);
System.out.println("ServerRequestTypes = " + loginr.ServerRequestTypes);
System.out.println("Flags = " + loginr.Flags);

      return true;
    } catch (IOException iox) {
      System.out.println("Login failed: "+iox.getMessage());
      return false;
    }
  }

  private void disconnect()
  {
    Dll.stop();
    try {
      TelnetSocket.close();
    } catch (IOException iox) {
    }
  }

  private void runStandalone()
  {
    try {
      connect("shane");
      login("shane", "shane");
      runClient("COM.winserver.wcnav.chat.Chat");
	  //runClient("COM.winserver.wcnav.who.Who");
      //System.in.read();
     // disconnect();
    } catch (Exception x) {
      System.out.println(x);
    }
  }

  // for running as an applet
  public void init()
  {
System.out.println("init("+this+")");
    //info = new Label();
    //add(info);
    //info.setText("Connecting...");
    add (new Label("Connecting..."));
  }

  public void start()
  {
System.out.println("------------- start()");
    for (int i = 0; i < 99; i++) {
      String s;
      if (i == 0) {
        s = getParameter("client");
      } else {
        s = getParameter("client"+i);
      }
      if (s != null) {
        int j = s.indexOf(":");
        if (j > 0) {
          ClientInfo ci = new ClientInfo(s.substring(0, j).trim(), s.substring(j+1).trim());
          ClientInfos.addElement(ci);
        }
      }
    }

System.out.println("getHost() + "+getDocumentBase().getHost());

    if (connect(getDocumentBase().getHost()) && login(getParameter("context"), null)) {
      //info.setText("Connected. Don't close this window.");
      add (new Label("Connected. Don't close this window."));
      if (ClientInfos.size() > 1) {
        for (int i = 0; i < ClientInfos.size(); i++) {
          ClientInfo ci = (ClientInfo)ClientInfos.elementAt(i);
          add(new Button(ci.name));
        }
      } else {
        ClientInfo ci = (ClientInfo)ClientInfos.elementAt(0);
        runClient(ci.classname);
      }
    } else {
      //info.setText("Error! Could not connect to server.");
      add (new Label("Error! Could not connect to server."));
    }
  }

  public void stop()
  {
System.out.println("---------- stop()");
    for (int i = 0; i < RunningClients.size(); i++) {
      ((WcnavClient)RunningClients.elementAt(i)).stop();
    }
    disconnect();
  }

  public boolean action(Event evt, Object what)
  {
    if (what instanceof String) {
      String clientname = (String)what;
      for (int i = 0; i < ClientInfos.size(); i++) {
        ClientInfo ci = (ClientInfo)ClientInfos.elementAt(i);
        if (clientname.compareTo(ci.name) == 0) {
          runClient(ci.classname);
        }
      }
    }
    return true;
  }

  // for running as an application
  public static void main(String[] args)
  {
    new Wcnav().runStandalone();
  }
}
