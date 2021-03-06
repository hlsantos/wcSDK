// File: TLanguageInfo.java
// (c) copyright 2002 Santronics Software Inc.
//
//****************************************************
// DO NOT EDIT THIS FILE!!!
// CPP2JAVA GENERATED FROM SOURCE FILE: wctype.h
//****************************************************
//

package COM.winserver.wildcat;

import java.io.IOException;

public class TLanguageInfo extends WcRecord {
  public String Name;
  public String Description;
  public String SubcommandChars;

  // Total size
  public static final int SIZE = 0+12+72+100+72*1;

  // Constructors
  public TLanguageInfo()
  {
  }

  public TLanguageInfo(byte[] x)
  {
    fromByteArray(x);
  }

  // Methods
  protected void writeTo(WcOutputStream out) throws IOException
  {
    super.writeTo(out);
    out.writeString(Name, 12);
    out.writeString(Description, 72);
    out.writeString(SubcommandChars, 100);
    out.write(new byte[72*1]);
  }

  protected void readFrom(WcInputStream in) throws IOException
  {
    super.readFrom(in);
    Name = in.readString(12);
    Description = in.readString(72);
    SubcommandChars = in.readString(100);
    in.skip(72*1);
  }
}
