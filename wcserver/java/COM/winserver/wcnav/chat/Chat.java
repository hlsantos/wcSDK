package COM.winserver.wcnav.chat;

/*
- toolbar
- change channel menu
- change topic
- about box
*/

/*
import java.awt.*;
import java.io.*;
import java.util.*;
*/

import java.awt.List;
import java.awt.Font;
import java.awt.Label;
import java.awt.Component;
import java.awt.Dimension;
import java.awt.MenuItem;
import java.awt.Event;
import java.awt.Frame;
import java.awt.TextArea;
import java.awt.TextField;
import java.awt.BorderLayout;
import java.awt.Panel;
import java.awt.GridLayout;
import java.awt.Menu;
import java.awt.MenuBar;
import java.awt.FontMetrics;
import java.awt.Color;

import java.io.*;
import java.util.*;

import COM.winserver.wildcat.*;
import COM.winserver.wcnav.*;
import COM.winserver.wcnav.wildsock.*;

class TChatControl extends WcRecord {
  String Name;
  int ChannelId;
  String Text;

  TChatControl()
  {
  }

  TChatControl(byte[] x)
  {
    fromByteArray(x);
  }

  protected void writeTo(WcOutputStream out) throws IOException
  {
    super.writeTo(out);
    out.writeString(Name, 28);
    out.writeInt(ChannelId);
    out.writeString(Text, 80);
  }

  protected void readFrom(WcInputStream in) throws IOException
  {
    super.readFrom(in);
    Name = in.readString(28);
    ChannelId = in.readInt();
    Text = in.readString(80);
  }

  public String toString()
  {
    return "TChatControl[Name="+Name+",ChannelId="+ChannelId+",Text="+Text+"]";
  }
}

class TChatControlSwitch extends TChatControl {
  int NewId;
  String NewText;

  TChatControlSwitch()
  {
  }

  TChatControlSwitch(byte[] x)
  {
    fromByteArray(x);
  }

  protected void writeTo(WcOutputStream out) throws IOException
  {
    super.writeTo(out);
    out.writeInt(NewId);
    out.writeString(NewText, 80);
  }

  protected void readFrom(WcInputStream in) throws IOException
  {
    super.readFrom(in);
    NewId = in.readInt();
    NewText = in.readString(80);
  }
}

class TChatMessage extends WcRecord {
  String From;
  String Text;
  boolean Whisper;

  TChatMessage()
  {
  }

  TChatMessage(byte[] x)
  {
    fromByteArray(x);
  }

  protected void writeTo(WcOutputStream out) throws IOException
  {
    super.writeTo(out);
    out.writeString(From, 28);
    out.writeString(Text, 256);
    out.writeBoolean(Whisper);
  }

  protected void readFrom(WcInputStream in) throws IOException
  {
    super.readFrom(in);
    From = in.readString(28);
    Text = in.readString(256);
    Whisper = in.readBoolean();
  }
}

class TChatAction extends WcRecord {
  String From;
  String Text;
  int Target;
  String TargetText;

  TChatAction()
  {
  }

  TChatAction(byte[] x)
  {
    fromByteArray(x);
  }

  protected void writeTo(WcOutputStream out) throws IOException
  {
    super.writeTo(out);
    out.writeString(From, 28);
    out.writeString(Text, 80);
    out.writeInt(Target);
    out.writeString(TargetText, 80);
  }

  protected void readFrom(WcInputStream in) throws IOException
  {
    super.readFrom(in);
    From = in.readString(28);
    Text = in.readString(80);
    Target = in.readInt();
    TargetText = in.readString(80);
  }
}

class TChatUserInfo extends WcRecord {
  String Name;
  int Id;
  int Channel;
  String Topic;
  //Color Color;
  //boolean Ignoring;

  protected void writeTo(WcOutputStream out) throws IOException
  {
    super.writeTo(out);
    out.writeString(Name, 28);
    out.writeInt(Id);
    out.writeInt(Channel);
    out.writeString(Topic, 40);
    //!!
  }

  protected void readFrom(WcInputStream in) throws IOException
  {
    super.readFrom(in);
    Name = in.readString(28);
    Id = in.readInt();
    Channel = in.readInt();
    Topic = in.readString(40);
  }
}

class WideList extends List {
  public Dimension preferredSize()
  {
    Dimension d = super.preferredSize();
    d.width = 160;
    return d;
  }
}

class ManagedList {
  private Vector elements = new Vector();
  private List list;

  ManagedList()
  {
    list = new WideList();
  }

  synchronized void addItem(String s, Object el)
  {
    elements.addElement(el);
    // deprecated 451.9 for java v1.5
    //list.addItem(s);
    list.add(s);
  }

  synchronized void clear()
  {
    elements.removeAllElements();
    // deprecated 451.9 for java v1.5
    // list.clear();
    list.removeAll();
  }

  List getList()
  {
    return list;
  }

  synchronized void removeItem(Object el)
  {
    int index = elements.indexOf(el);
    if (index < 0) {
      return;
    }
    // deprecated 451.9 for java v1.5
    //list.delItem(index);
    list.remove(index);
    elements.removeElementAt(index);
  }
}

class PeopleList {
  private Vector people = new Vector();

  synchronized TChatUserInfo add(int id, String name, int channel, String topic)
  {
    for (int i = 0; i < people.size(); i++) {
      TChatUserInfo u = (TChatUserInfo)people.elementAt(i);
      if (u.Id == id) {
        u.Channel = channel;
        return null;
      }
    }
    TChatUserInfo cui = new TChatUserInfo();
    cui.Name = name;
    cui.Id = id;
    cui.Channel = channel;
    cui.Topic = topic;
    people.addElement(cui);
    return cui;
  }

  synchronized void delete(TChatUserInfo u)
  {
    people.removeElement(u);
  }

  synchronized TChatUserInfo findByIndex(int index)
  {
    if (index < 0 || index >= people.size()) {
      return null;
    }
    return (TChatUserInfo)people.elementAt(index);
  }

  synchronized TChatUserInfo findById(int id)
  {
    for (int i = 0; i < people.size(); i++) {
      TChatUserInfo u = (TChatUserInfo)people.elementAt(i);
      if (u.Id == id) {
        return u;
      }
    }
    return null;
  }

  synchronized int findIndexByName(String s, int channelid, boolean everywhere)
  {
    for (int i = 0; i < people.size(); i++) {
      TChatUserInfo u = (TChatUserInfo)people.elementAt(i);
      if ((everywhere || u.Channel == channelid) && s.equalsIgnoreCase(u.Name)) {
        return i;
      }
    }
    int n = -1;
    for (int i = 0; i < people.size(); i++) {
      TChatUserInfo u = (TChatUserInfo)people.elementAt(i);
      if ((everywhere || u.Channel == channelid) && s.length() <= u.Name.length() && s.equalsIgnoreCase(u.Name.substring(0, s.length()))) {
        if (n >= 0) {
          return -2;
        }
        n = i;
      }
    }
    return n;
  }

  synchronized int findIndexByTopic(String s)
  {
    for (int i = 0; i < people.size(); i++) {
      TChatUserInfo u = (TChatUserInfo)people.elementAt(i);
      if (s.equalsIgnoreCase(u.Topic)) {
        return i;
      }
    }
    int n = -1;
    for (int i = 0; i < people.size(); i++) {
      TChatUserInfo u = (TChatUserInfo)people.elementAt(i);
      if (s.length() <= u.Topic.length() && s.equalsIgnoreCase(u.Topic.substring(0, s.length()))) {
        if (n >= 0) {
          return -2;
        }
        n = i;
      }
    }
    return n;
  }
}

class PredefinedChannel {
  int Id;
  String Name;

  PredefinedChannel(int id, String name)
  {
    Id = id;
    Name = name;
  }
}

class PredefinedChannelList {
  Vector channels = new Vector();

  synchronized void add(int id, String name)
  {
    channels.addElement(new PredefinedChannel(id, name));
  }

  synchronized PredefinedChannel findById(int id)
  {
    for (int i = 0; i < channels.size(); i++) {
      PredefinedChannel c = (PredefinedChannel)channels.elementAt(i);
      if (c.Id == id) {
        return c;
      }
    }
    return null;
  }

  synchronized int findIdByName(String s)
  {
    for (int i = 0; i < channels.size(); i++) {
      PredefinedChannel c = (PredefinedChannel)channels.elementAt(i);
      if (s.equalsIgnoreCase(c.Name)) {
        return c.Id;
      }
    }
    int n = -1;
    int id = -1;
    for (int i = 0; i < channels.size(); i++) {
      PredefinedChannel c = (PredefinedChannel)channels.elementAt(i);
      if (s.length() <= c.Name.length() && s.equalsIgnoreCase(c.Name.substring(0, s.length()))) {
        if (n >= 0) {
          return -2;
        }
        n = i;
        id = c.Id;
      }
    }
    return id;
  }
}

class FontFaceMenuItem extends MenuItem {
  Component target;

  FontFaceMenuItem(String name, Component target)
  {
    super(name);
    this.target = target;
  }

  public boolean postEvent(Event evt)
  {
    if (evt.id == Event.ACTION_EVENT) {
      target.setFont(new Font(getLabel(), Font.PLAIN, target.getFont().getSize()));
      return true;
    }
    return super.postEvent(evt);
  }
}

class FontSizeMenuItem extends MenuItem {
  Component target;

  FontSizeMenuItem(int size, Component target)
  {
    super(Integer.toString(size));
    this.target = target;
  }

  public boolean postEvent(Event evt)
  {
    if (evt.id == Event.ACTION_EVENT) {
      target.setFont(new Font(target.getFont().getName(), Font.PLAIN, Integer.parseInt(getLabel())));
      return true;
    }
    return super.postEvent(evt);
  }
}

class ChatFrame extends Frame implements WSocketListener {
  static final int CHATCTRL_ENTER    = 1;
  static final int CHATCTRL_ENTERACK = 2;
  static final int CHATCTRL_LEAVE    = 3;
  static final int CHATCTRL_SWITCH   = 4;
  static final int CHATCTRL_TOPIC    = 5;
  static final int CHATMSG_TEXT      = 1;
  static final int CHATMSG_ACTION    = 2;

  TextArea chatwindow;
  TextField userwindow;
  ManagedList channelwindow;
  ManagedList peoplewindow;
  Label titlewindow;

  TGetSystemInfo_Response SystemInfo;

  WSocket SystemPageChannel;
  WSocket ChatControl;
  WSocket CurrentChannel;
  int CurrentChannelId;
  TChatUserInfo Our;

  PeopleList People = new PeopleList();
  static final String[] BadWords = {"shit",
                                    "piss",
                                    "fuck",
                                    "cunt",
                                    "cocksucker",
                                    "motherfucker",
                                    "tits"};

  WSocket PredefinedChannelsSocket;
  PredefinedChannelList PredefinedChannels = new PredefinedChannelList();

  ChatFrame()
  {
    super("Chat");
    resize(600, 400);
    setLayout(new BorderLayout());

    chatwindow = new TextArea();
    chatwindow.setEditable(false);
 	 //chatwindow.setBackground(Color.blue);

    add("Center", chatwindow);
    userwindow = new TextField();

    add("South", userwindow);
    {
      Panel channelpeoplepanel = new Panel();
      channelpeoplepanel.resize(100, 400);
      channelpeoplepanel.setLayout(new GridLayout(2, 1));
      {
        Panel channelpanel = new Panel();
        channelpanel.setLayout(new BorderLayout());
        Label channelslabel = new Label("Channels");
        channelpanel.add("North", channelslabel);
        channelwindow = new ManagedList();
        channelwindow.addItem("Main", null);
        channelpanel.add("Center", channelwindow.getList());
        channelpeoplepanel.add(channelpanel);
      }
      {
        Panel peoplepanel = new Panel();
        peoplepanel.setLayout(new BorderLayout());
        Label peoplelabel = new Label("People");
        peoplepanel.add("North", peoplelabel);
        peoplewindow = new ManagedList();
        peoplepanel.add("Center", peoplewindow.getList());
        channelpeoplepanel.add(peoplepanel);
      }
      add("East", channelpeoplepanel);
    }

    titlewindow = new Label();
    add("North", titlewindow);
    titlewindow.setFont(new Font("Times", Font.ITALIC, 16));

    Menu filemenu = new Menu("File");
    filemenu.add(new MenuItem("Exit"));
    Menu viewmenu = new Menu("View");
    viewmenu.add(new MenuItem("Clear"));
    Menu fontfacemenu = new Menu("Font face");
    String[] fontfaces = getToolkit().getFontList();
    for (int i = 0; i < fontfaces.length; i++) {
      fontfacemenu.add(new FontFaceMenuItem(fontfaces[i], chatwindow));
    }
    viewmenu.add(fontfacemenu);
    Menu fontsizemenu = new Menu("Font size");
    for (int i = 8; i <= 30; i += 2) {
      fontsizemenu.add(new FontSizeMenuItem(i, chatwindow));
    }
    viewmenu.add(fontsizemenu);
    MenuBar mbar = new MenuBar();
    mbar.add(filemenu);
    mbar.add(viewmenu);
    setMenuBar(mbar);
  }

  boolean start()
  {
    try {
//System.out.println("WcProxy.getSystemInfo()");
      SystemInfo = WcProxy.getSystemInfo();
      setTitle("Chat - "+SystemInfo.BBSName);
//System.out.println("WcProxy.getCurrentUser()");
      TGetCurrentUser_Response ur = WcProxy.getCurrentUser();
      Our = new TChatUserInfo();
      Our.Name = WordUtils.UpperLower(ur.User.Info.Name);
//System.out.println("WcProxy.getNodeInfoByName("+ur.User.Info.Name+")");
      TWhosOnline_Response wr = WcProxy.getNodeInfoByName(ur.User.Info.Name);
      Our.Id = wr.NodeInfo.ConnectionId;
      Our.Topic = Our.Name+"'s channel";
//System.out.println("openChannel(System.Page)");
      SystemPageChannel = openChannel("System.Page");
//System.out.println("openChannel(Chat.Control)");
      ChatControl = openChannel("Chat.Control");
//System.out.println("openChannel(Chat.0)");
      CurrentChannel = openChannel("Chat.0");
      CurrentChannelId = 0;
      sendControlMessage(CHATCTRL_ENTER, Our.Name+" has just entered the chat room.");
      PredefinedChannelsSocket = WcProxy.sendRequest(new TWildcatRequest(WildcatRequest.wrGetPredefinedChatChannels), this);
      titlewindow.setText(getChannelName(CurrentChannelId));
    } catch (IOException iox) {
      System.out.println("Startup error: "+iox.getMessage());
      return false;
    }
    return true;
  }

  public void dispose()
  {
    try {
      sendControlMessage(CHATCTRL_LEAVE, Our.Name+" has just left the chat room.");
      SystemPageChannel.close();
      ChatControl.close();
      CurrentChannel.close();
    // SMC 447.5 JDK 1.1 fix
    //} catch (IOException ix) {
    } catch (Exception e){
    }
    super.dispose();
  }

  public boolean handleEvent(Event evt)
  {
    //System.out.println("handleEvent: "+evt);
    if (evt.target == this && evt.id == Event.WINDOW_DESTROY) {
      dispose();
      return true;
    }
    return super.handleEvent(evt);
  }

  public boolean action(Event evt, Object what)
  {
    if (evt.target == channelwindow.getList()) {
      String s = (String)what;
      doJoin(s);
    } else if (evt.target == userwindow) {
      String s = userwindow.getText();
      if (s.length() > 0) {
        processUserInput(s);
        userwindow.setText("");
      }
      return true;
    } else if (evt.target instanceof MenuItem) {
      String s = (String)what;
      if (s.equals("Exit")) {
        dispose();
      } else if (s.equals("Clear")) {
        chatwindow.setText("");
      }
      return true;
    }
    return super.action(evt, what);
  }

  WSocket openChannel(String name)
  {
    WSocket s = new WSocket(2);
    s.setListener(this);
    try {
      ByteArrayOutputStream tout = new ByteArrayOutputStream();
      byte[] x = new byte[name.length()];
      name.getBytes(0, name.length(), x, 0);
      tout.write(x);
      tout.write(0);
      s.getOutputStream().write(tout.toByteArray());
    } catch (IOException ix) {
    }
    return s;
  }

  void writeChannel(WSocket socket, int dest, int msg, WcRecord data)
  {
    TGuiChannelMessage cmsg = new TGuiChannelMessage();
    cmsg.DestId = dest;
    cmsg.UserData = msg;
    byte[] a = data.toByteArray();
    cmsg.DataSize = a.length;
    cmsg.Data = a;
    try {
      socket.getOutputStream().write(cmsg.toByteArray());
    } catch (IOException iox) {
    }
  }

  void sendControlMessage(int msg, String text)
  {
    TChatControl cmsg = new TChatControl();
    cmsg.Name = Our.Name;
    cmsg.ChannelId = CurrentChannelId;
    cmsg.Text = text;
    writeChannel(ChatControl, 0, msg, cmsg);
  }

  void sendControlMessageSwitch(int oldchannel, String text, int newid, String newtext)
  {
    TChatControlSwitch cmsg = new TChatControlSwitch();
    cmsg.Name = Our.Name;
    cmsg.ChannelId = oldchannel;
    cmsg.Text = text;
    cmsg.NewId = newid;
    cmsg.NewText = newtext;
    writeChannel(ChatControl, 0, CHATCTRL_SWITCH, cmsg);
  }

  void sendChatMessage(int dest, int msg, String text, boolean whisper)
  {
    TChatMessage cmsg = new TChatMessage();
    cmsg.From = Our.Name;
    cmsg.Text = text;
    cmsg.Whisper = whisper;
    writeChannel(CurrentChannel, dest, msg, cmsg);
  }

  void sendChatAction(int dest, String text, int target, String targettext)
  {
    TChatAction cmsg = new TChatAction();
    cmsg.From = Our.Name;
    cmsg.Text = text;
    cmsg.Target = target;
    cmsg.TargetText = targettext;
    writeChannel(CurrentChannel, dest, CHATMSG_ACTION, cmsg);
  }

  String getChannelName(int channel)
  {
    if (channel == 0) {
      return "Main Channel";
    }
    if (channel > 0) {
      TChatUserInfo u = People.findById(channel);
      if (u == null) {
        return "(Private channel)";
      }
      return u.Topic;
    }
    PredefinedChannel c = PredefinedChannels.findById(channel);
    if (c == null) {
      return "(Private channel)";
    }
    return c.Name;
  }

  // SMC 447.5 word wrap long lines.
  // getmaxstringlength figures out how many characters in
  // a string will fit into the chatwindow, and return that
  // number
  int getMaxStringLength(String text){
        if((chatwindow.size()).width<1)return text.length();
        FontMetrics fm = chatwindow.getFontMetrics(chatwindow.getFont());
        for (int i = 0;i<text.length();i++)
            if ((fm.stringWidth(text.substring(0,i)) > ((chatwindow.size()).width - fm.stringWidth("W") * 4))) return i; // 4 character safeguard
        return text.length();
  }

  // wrapit handles the line wrapping.  columns are variable length
  // due to font metrics, which is figured out above.
  void wrapit(String msg, String who)
  {
      //Dimension size=chatwindow.getPreferredSize();
      int col;
      int len;
      String s = msg;

      if (who.length()>0)s = who + s;
      len = s.length();
      col = getMaxStringLength(s);

      if (len <= col) {
          chatwindow.appendText(s);
      } else {
        int space = col;
        while (col < len) {
          space = s.lastIndexOf(' ', space);
          // if no space previous, we have to break at
          // the next line
          if (space == -1) space = s.indexOf(' ');
          // if no space at all, or end of line,
          // we'll just print the line 'asis'
          if (space == -1) {
              break;
          }
          chatwindow.appendText(s.substring(0,space+1)+"\n");
          s = s.substring(space+1, len);
          if (who.length()>0)s = who + s;
          len = s.length();
          col = getMaxStringLength(s);
          space = col;
        }
        chatwindow.appendText(s);
      }
  }

  void wrapit(String msg)
  {
      wrapit(msg, "");
  }

  void doJoin(String args)
  {
    int newchannel;
    String msg;
    if (args == null) {
      if (CurrentChannelId != Our.Id) {
        newchannel = Our.Id;
        msg = "You just switched to your personal channel.";
      } else {
        newchannel = 0;
        msg = "You just switched to the main channel.";
      }
    } else if (args.equalsIgnoreCase("main")) {
      newchannel = 0;
      msg = "You just switched to the main channel.";
    } else {
      synchronized (People) {
        int n = People.findIndexByName(args, CurrentChannelId, true);
        if (n == -1) {
          n = People.findIndexByTopic(args);
        }
        if (n == -1) {
          int chid = PredefinedChannels.findIdByName(args);
          if (chid == -1) {
            wrapit("There is no user by the name of \""+args+"\" in chat at this time, and no channel was found.\n");
            return;
          } else if (chid == -2) {
            wrapit("The name \""+args+"\" matches more than one chat channel.\n");
            return;
          }
          newchannel = chid;
          PredefinedChannel c = PredefinedChannels.findById(chid);
          msg = "You just switched to the "+c.Name+" channel.";
        } else if (n == -2) {
          wrapit("The name \""+args+"\" matches more than one chat user.\n");
          return;
        } else {
          TChatUserInfo u = People.findByIndex(n);
          newchannel = u.Id;
          msg = "You just switched to "+u.Name+"'s private channel.";
        }
      }
    }
    if (newchannel == CurrentChannelId) {
      wrapit("You are already in that channel.\n");
      return;
    }
    CurrentChannel.close();
    CurrentChannel = openChannel("Chat."+newchannel);
    int oldchannel = CurrentChannelId;
    CurrentChannelId = newchannel;
    sendControlMessageSwitch(oldchannel, Our.Name+" has switched to another channel.", newchannel, Our.Name+" has switched to this channel.");
    chatwindow.setText("");
    wrapit(msg+"\n");
    titlewindow.setText(getChannelName(CurrentChannelId));
  }

  void doTopic(String args)
  {
    if (CurrentChannelId != Our.Id) {
      wrapit("You cannot change the topic in this channel.\n");
      return;
    }
    if (args == null) {
      args = Our.Name+"'s channel";
    }
    Our.Topic = args;
    sendControlMessage(CHATCTRL_TOPIC, args);
    wrapit("You just changed your channel topic to "+args+".\n");
  }

  void doWhisper(String args)
  {
    synchronized (People) {
      int w = 0;
      int nn;
      int n = -1;
      do {
        nn = n;
        w++;
        String t = WordUtils.ExtractWords(w, args);
        if (WordUtils.ExtractWords(w-1, args).equals(t)) {
          break;
        }
        n = People.findIndexByName(t, CurrentChannelId, false);
      } while (n != -1);
      switch (nn) {
        case -2:
          wrapit("The name \""+WordUtils.ExtractWords(w-1, args)+"\" matches more than one user.\n");
          break;
        case -1:
          wrapit("There is no user by the name of \""+WordUtils.ExtractWords(1, args)+"\" in chat at this time.\n");
          break;
        default:
          TChatUserInfo u = People.findByIndex(nn);
          String t = args.substring(WordUtils.WordPosition(args, w));
          sendChatMessage(u.Id, CHATMSG_TEXT, t, true);
          wrapit(t+"\n",Our.Name+" (whispered to "+u.Name+"): ");
      }
    }
  }

  void doAction(String action, String args)
  {
    if (action.length() == 0) {
      return;
    }
    synchronized (People) {
      int nn;
      if (args == null) {
        nn = -1;
        args = "";
      } else {
        int w = 0;
        int n = -1;
        do {
          nn = n;
          w++;
          String t = WordUtils.ExtractWords(w, args);
          if (WordUtils.ExtractWords(w-1, args).equals(t)) {
            break;
          }
          if (t.equalsIgnoreCase("all")) {
            n = 99999;
          } else {
            n = People.findIndexByName(t, CurrentChannelId, false);
          }
        } while (n != -1);
        if (nn == -2) {
          wrapit("The name \""+WordUtils.ExtractWords(w-1, args)+"\" matches more than one user.\n");
          return;
        } else if (nn >= 0) {
          args = args.substring(WordUtils.WordPosition(args, w));
        }
        if (args.length() > 0) {
          args = " " + args;
        }
      }
      String actioned = WordUtils.Conjugate(action);
      if (nn < 0) {
        sendChatAction(0, Our.Name+" just "+actioned+args+"!", 0, "");
        wrapit("You just "+actioned+args+"!\n");
      } else if (nn == 99999) {
        sendChatAction(0, Our.Name+" just "+actioned+" everybody"+args+"!", 0, "");
        wrapit("You just "+actioned+" everybody"+args+"!\n");
      } else {
        TChatUserInfo u = People.findByIndex(nn);
        sendChatAction(0, Our.Name+" just "+actioned+" "+u.Name+args+"!", u.Id, Our.Name+" just "+actioned+" you"+args+"!");
        wrapit("You just "+actioned+" "+u.Name+args+"!\n");
      }
    }
  }

  String bleepFilter(String s)
  {
    String t = s.toLowerCase();
    for (int i = 0; i < BadWords.length; i++) {
      while (true) {
        int j = t.indexOf(BadWords[i]);
        if (j < 0) {
          break;
        }
        s = s.substring(0, j) + ("**********").substring(0, BadWords[i].length()) + s.substring(j+BadWords[i].length());
        t = t.substring(0, j) + ("**********").substring(0, BadWords[i].length()) + t.substring(j+BadWords[i].length());
      }
    }
    return s;
  }

  void processUserInput(String s)
  {
    if (s.charAt(0) == '!' || s.charAt(0) == '/') {
      while (s.length() > 1 && s.charAt(1) == ' ') {
        s = s.charAt(0) + s.substring(2);
      }
    }
    s = bleepFilter(s);
    String args = null;
    if (s.indexOf(' ') > 0) {
      args = s.substring(s.indexOf(' ')).trim();
    }
    String cmd = WordUtils.ExtractWord(s, 1);
    if (cmd.charAt(0) == '/') {
      if (cmd.equalsIgnoreCase("/j") || cmd.equalsIgnoreCase("/join")) {
        doJoin(args);
      } else if (cmd.equalsIgnoreCase("/m") || cmd.equalsIgnoreCase("/main")) {
        doJoin("main");
      } else if (cmd.equalsIgnoreCase("/t") || cmd.equalsIgnoreCase("/topic")) {
        doTopic(args);
      } else {
        doWhisper(s.substring(1));
      }
    } else if (s.charAt(0) == '!') {
      doAction(cmd.substring(1), args);
    } else {
      sendChatMessage(0, CHATMSG_TEXT, s, false);
    }
  }

  void addPeople(int id, String name, int channel, String topic)
  {
    TChatUserInfo u = People.add(id, name, channel, topic);
    if (u != null) {
      if (channel == CurrentChannelId) {
        //wrapit(name+" has just joined this channel.\n");
        peoplewindow.addItem(name, u);
      }
      channelwindow.addItem(topic, u);
    }
  }

  void deletePeople(TChatUserInfo u)
  {
    People.delete(u);
    channelwindow.removeItem(u);
    if (u != null && u.Channel == CurrentChannelId) {
      peoplewindow.removeItem(u);
    }
  }

  void handleChatControl(TChannelMessage msg)
  {
    TChatControl ctrlmsg = new TChatControl(msg.Data);
//System.out.println("handleChatControl: "+ctrlmsg);
//    chatwindow.appendText("handleChatControl: "+ctrlmsg+"\n");
    TChatUserInfo u = People.findById(msg.SenderId);
    switch (msg.UserData) {
      case CHATCTRL_ENTER:
//        chatwindow.appendText("CHATCTRL_ENTER\n");
        if (msg.SenderId != Our.Id) {
          if (ctrlmsg.ChannelId == CurrentChannelId) {
            wrapit(ctrlmsg.Text+"\n");
          }
//          chatwindow.appendText("addPeople\n");
          addPeople(msg.SenderId, ctrlmsg.Name, ctrlmsg.ChannelId, ctrlmsg.Name+"'s channel");
        }
        sendControlMessage(CHATCTRL_ENTERACK, Our.Topic);
        break;
      case CHATCTRL_ENTERACK:
//        chatwindow.appendText("CHATCTRL_ENTERACK\n");
//        chatwindow.appendText("addPeople\n");
        addPeople(msg.SenderId, ctrlmsg.Name, ctrlmsg.ChannelId, ctrlmsg.Text);
        break;
      case CHATCTRL_LEAVE:
//        chatwindow.appendText("CHATCTRL_LEAVE\n");
//        chatwindow.appendText("deletePeople\n");
        deletePeople(u);
        if (ctrlmsg.ChannelId == CurrentChannelId) {
          wrapit(ctrlmsg.Text+"\n");
        }
        break;
      case CHATCTRL_SWITCH:
//        chatwindow.appendText("CHATCTRL_SWITCH!\n");
        TChatControlSwitch switchmsg = new TChatControlSwitch(msg.Data);
        if (u != null) {
          if (u.Channel == CurrentChannelId && msg.SenderId != Our.Id) {
            wrapit(switchmsg.Text+"\n");
          }
          u.Channel = switchmsg.NewId;
        } else {
//          chatwindow.appendText("addPeople1\n");
          addPeople(msg.SenderId, switchmsg.Name, switchmsg.NewId, switchmsg.Name+"'s channel");
        }
        if (msg.SenderId != Our.Id) {
          if (switchmsg.NewId == CurrentChannelId) {
            wrapit(switchmsg.NewText+"\n");
//            if (switchmsg.ChannelId != CurrentChannelId) {
//              chatwindow.appendText("peoplewindow.addItem2\n");
//              peoplewindow.addItem(u.Name, u);
//            }
          } else {
            if (u != null) {
//              chatwindow.appendText("peoplewindow.removeItem3\n");
              peoplewindow.removeItem(u);
            }
          }
        } //else {
//          chatwindow.appendText("peoplewindow.clear\n");
          peoplewindow.clear();
          synchronized (People) {
            int i = 0;
            while (true) {
              TChatUserInfo tu = People.findByIndex(i);
              if (tu == null) {
                break;
              }
              if (tu.Channel == CurrentChannelId) {
//                chatwindow.appendText("peoplewindow.addItem4\n");
                peoplewindow.addItem(tu.Name, tu);
              }
              i++;
            }
          }
        //}
        break;
      case CHATCTRL_TOPIC:
//        chatwindow.appendText("CHATCTRL_TOPIC\n");
        if (u != null) {
          u.Topic = ctrlmsg.Text;
          if (u.Channel == CurrentChannelId) {
            if (msg.SenderId != Our.Id) {
              wrapit(ctrlmsg.Name+" has just changed this channel topic to "+ctrlmsg.Text+"\n");
            }
            titlewindow.setText(getChannelName(CurrentChannelId));
          }
        }
        break;
      case 0xFFFF:
        if (u != null) {
          if (u.Channel == CurrentChannelId) {
            wrapit(u.Name+" has just vanished without a trace!\n");
          }
          deletePeople(u);
        }
        break;
    }
  }

  void handleCurrentChannel(TChannelMessage msg)
  {
    TChatUserInfo p = People.findById(msg.SenderId);
    switch (msg.UserData) {
      case CHATMSG_TEXT:
        TChatMessage chanmsg = new TChatMessage(msg.Data);
        if (chanmsg.Whisper) {
          wrapit(chanmsg.Text+"\n", chanmsg.From+" (Whispered): ");
        } else {
          wrapit(chanmsg.Text+"\n", chanmsg.From+": ");
        }
        break;
      case CHATMSG_ACTION:
        TChatAction actionmsg = new TChatAction(msg.Data);
        if (msg.SenderId != Our.Id) {
          if (actionmsg.Target == Our.Id) {
            wrapit(actionmsg.TargetText+"\n");
          } else {
            wrapit(actionmsg.Text+"\n");
          }
        }
        break;
    }
  }

  public void socketNotify(WSocket socket)
  {
    if (socket == PredefinedChannelsSocket) {
      byte[] x = new byte[TGetPredefinedChatChannels_Response.SIZE];
      try {
        if (socket.getInputStream().read(x) <= 0) {
          PredefinedChannelsSocket.close();
          PredefinedChannelsSocket = null;
          return;
        }
      } catch (IOException ix) {
        wrapit("error: comm error\n");
        return;
      }
      TGetPredefinedChatChannels_Response r = new TGetPredefinedChatChannels_Response(x);
      PredefinedChannels.add(r.Id, r.ChannelName);
      channelwindow.addItem(r.ChannelName, null);
    } else {
      byte[] x = new byte[TChannelMessage.SIZE];
      try {
        if (socket.getInputStream().read(x) <= 0) {
          //wrapit("error: comm broken ("+socket+")\n");
          //wrapit("(SystemPageChannel="+SystemPageChannel+", ChatControl="+ChatControl+", CurrentChannel="+CurrentChannel+")");
          return;
        }
      } catch (IOException ix) {
        wrapit("error: comm error\n");
        return;
      }
      TChannelMessage msg = new TChannelMessage(x);
      if (socket == SystemPageChannel) {
        //??
        // 4519.f Explore
        System.out.println("SystemPageChannel Message!");
        //
      } else if (socket == ChatControl) {
        handleChatControl(msg);
      } else if (socket == CurrentChannel) {
        handleCurrentChannel(msg);
      }
    }
  }
}

public class Chat implements WcnavClient {
  ChatFrame frame;

  public void run()
  {
    frame = new ChatFrame();
    if (frame.start()) {
      frame.show();
      frame.userwindow.requestFocus();
    }
  }

  public void stop()
  {
    frame.dispose();
  }
}
