// File: TGetConferenceGroupAreas_Request.java
// (c) copyright 2002 Santronics Software Inc.
//
//****************************************************
// DO NOT EDIT THIS FILE!!!
// CPP2JAVA GENERATED FROM SOURCE FILE: wcgui.h
//****************************************************
//

package COM.winserver.wildcat;

import java.io.IOException;

public class TGetConferenceGroupAreas_Request extends TWildcatRequest {
  public int group;

  // Total size
  public static final int SIZE = TWildcatRequest.SIZE+4;

  // Constructors
  public TGetConferenceGroupAreas_Request()
  {
    type = WildcatRequest.wrGetConferenceGroupAreas;
  }

  public TGetConferenceGroupAreas_Request(byte[] x)
  {
    fromByteArray(x);
  }

  // Methods
  protected void writeTo(WcOutputStream out) throws IOException
  {
    super.writeTo(out);
    out.writeInt(group);
  }

  protected void readFrom(WcInputStream in) throws IOException
  {
    super.readFrom(in);
    group = in.readInt();
  }
}
