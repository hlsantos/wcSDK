package COM.winserver.wcnav.chat;

public class WordUtils {
  public static String ExtractWord(String s, int n)
  {
//System.out.println("ExtractWord: "+s+", "+n);
    int i = 0;
    int j;
    do {
      while (i < s.length() && s.charAt(i) == ' ') {
        i++;
      }
      j = i;
      while (i < s.length() && s.charAt(i) != ' ') {
        i++;
      }
      n--;
    } while (n > 0);
    return s.substring(j, i);
  }

  public static int WordPosition(String s, int n)
  {
//System.out.println("WordPosition: "+s+", "+n);
    int i = 0;
    int j;
    do {
      while (i < s.length() && s.charAt(i) == ' ') {
        i++;
      }
      j = i;
      while (i < s.length() && s.charAt(i) != ' ') {
        i++;
      }
      n--;
    } while (n > 0);
    return j;
  }

  public static String ExtractWords(int n, String s)
  {
//System.out.println("ExtractWords: "+n+", "+s);
    StringBuffer t = new StringBuffer();
    for (int i = 1; i <= n; i++) {
      String w = ExtractWord(s, i);
      if (w.length() == 0) {
        break;
      }
      if (i > 1) {
        t.append(" ");
      }
      t.append(w);
    }
    return t.toString();
  }

  public static String UpperLower(String s)
  {
    StringBuffer t = new StringBuffer();
    int i = 1;
    while (true) {
      String w = ExtractWord(s, i);
      if (w.length() == 0) {
        break;
      }
      if (i > 1) {
        t.append(" ");
      }
      w = w.toLowerCase();
      t.append(Character.toUpperCase(w.charAt(0)));
      t.append(w.substring(1));
      i++;
    }
    return t.toString();
  }

  static final String[] Verbs = {
    "be/was",
    "beat/beat",
    "become/became",
    "begin/began",
    "bite/bit",
    "blow/blew",
    "break/broke",
    "bring/brought",
    "build/built",
    "buy/bought",
    "catch/caught",
    "choose/chose",
    "come/came",
    "cost/cost",
    "cut/cut",
    "do/did",
    "draw/drew",
    "drink/drank",
    "drive/drove",
    "eat/ate",
    "fall/fell",
    "feel/felt",
    "fight/fought",
    "find/found",
    "fly/flew",
    "forget/forgot",
    "get/got",
    "give/gave",
    "go/went",
    "grow/grew",
    "hang/hung",
    "have/had",
    "hear/heard",
    "hide/hid",
    "hit/hit",
    "hold/held",
    "hurt/hurt",
    "keep/kept",
    "know/knew",
    "leave/left",
    "lend/lent",
    "let/let",
    "lie/lay",
    "light/lit",
    "lose/lost",
    "make/made",
    "mean/meant",
    "meet/met",
    "pay/paid",
    "put/put",
    "read/read",
    "ride/rode",
    "ring/rang",
    "rise/rose",
    "run/ran",
    "say/said",
    "see/saw",
    "sell/sold",
    "send/sent",
    "shine/shone",
    "shoot/shot",
    "show/showed",
    "shut/shut",
    "sing/sang",
    "sit/sat",
    "sleep/slept",
    "speak/spoke",
    "spend/spent",
    "stand/stood",
    "steal/stole",
    "stomp/stomped",
    "swim/swam",
    "take/took",
    "teach/taught",
    "tear/tore",
    "tell/told",
    "think/thought",
    "throw/threw",
    "understand/understood",
    "wake/woke",
    "wear/wore",
    "win/won",
    "write/wrote"
  };

  public static String Conjugate(String s)
  {
    String t = s + "/";
    for (int i = 0; i < Verbs.length; i++) {
      if (t.length() < Verbs[i].length() && t.equalsIgnoreCase(Verbs[i].substring(0, t.length()))) {
        return Verbs[i].substring(t.length());
      }
    }
    switch (Character.toLowerCase(s.charAt(s.length()-1))) {
      case 'b': case 'd': case 'f': case 'g': case 'm': case 'n': case 'p': case 'r': case 'z':
        return s + s.charAt(s.length()-1) + "ed";
      case 'e':
        return s + 'd';
      case 't':
        if (Character.toLowerCase(s.charAt(s.length()-2)) == 'i') {
          return s + s.charAt(s.length()-1) + "ed";
        } else {
          return s + "ed";
        }
      case 'y':
        return s.substring(0, s.length()-1) + "ied";
    }
    return s + "ed";
  }
}
