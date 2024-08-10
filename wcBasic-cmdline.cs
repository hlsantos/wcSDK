//***********************************************************************
// (c) Copyright 1998-2020 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : CmdLine.cs
// Subsystem : Wildcat! SDK for c#
// Version   : 8.0.454.10
// Author    : SSI
// About     :
//
// Revision History:
// Build    Date      Author  Comments
// -----    --------  ------  -------------------------------------------
// 454.10   05/18/20  SSI     - Created
//***********************************************************************

using System;
using System.Runtime.InteropServices;

using wcSDK.wcSystem;

namespace wcSDK.wcBASIC
{
    public class VirtualKeys
    {

        public const int VK_RETURN = 0x0D;
        public const int VK_SHIFT = 0x10;
        public const int VK_CONTROL = 0x11;
        public const int VK_ESCAPE = 0x1B;
        public const int VK_SPACE = 0x20;
        public const int VK_PRIOR = 0x21;
        public const int VK_NEXT = 0x22;
        public const int VK_END = 0x23;
        public const int VK_HOME = 0x24;
        public const int VK_LEFT = 0x25;
        public const int VK_UP = 0x26;
        public const int VK_RIGHT = 0x27;
        public const int VK_DOWN = 0x28;
        public const int VK_SELECT = 0x29;
        public const int VK_PRINT = 0x2A;
        public const int VK_INSERT = 0x2D;
        public const int VK_DELETE = 0x2E;
        public const int VK_HELP = 0x2F;
        public const int VK_NUMPAD0 = 0x60;
        public const int VK_NUMPAD1 = 0x61;
        public const int VK_NUMPAD2 = 0x62;
        public const int VK_NUMPAD3 = 0x63;
        public const int VK_NUMPAD4 = 0x64;
        public const int VK_NUMPAD5 = 0x65;
        public const int VK_NUMPAD6 = 0x66;
        public const int VK_NUMPAD7 = 0x67;
        public const int VK_NUMPAD8 = 0x68;
        public const int VK_NUMPAD9 = 0x69;
        public const int VK_MULTIPLY = 0x6A;
        public const int VK_ADD = 0x6B;
        public const int VK_SEPARATOR = 0x6C;
        public const int VK_SUBTRACT = 0x6D;
        public const int VK_DECIMAL = 0x6E;
        public const int VK_DIVIDE = 0x6F;
        public const int VK_F1 = 0x70;
        public const int VK_F2 = 0x71;
        public const int VK_F3 = 0x72;
        public const int VK_F4 = 0x73;
        public const int VK_F5 = 0x74;
        public const int VK_F6 = 0x75;
        public const int VK_F7 = 0x76;
        public const int VK_F8 = 0x77;
        public const int VK_F9 = 0x78;
        public const int VK_F10 = 0x79;
        public const int VK_F11 = 0x7A;
        public const int VK_F12 = 0x7B;
        public const int VK_F13 = 0x7C;
        public const int VK_F14 = 0x7D;
        public const int VK_F15 = 0x7E;
        public const int VK_F16 = 0x7F;
        public const int VK_F17 = 0x80;
        public const int VK_F18 = 0x81;
        public const int VK_F19 = 0x82;
        public const int VK_F20 = 0x83;
        public const int VK_F21 = 0x84;
        public const int VK_F22 = 0x85;
        public const int VK_F23 = 0x86;
        public const int VK_F24 = 0x87;
        public const int VK_NUMLOCK = 0x90;
        public const int VK_SCROLL = 0x91;
        public const int VK_LSHIFT = 0xA0;
        public const int VK_RSHIFT = 0xA1;
        public const int VK_LCONTROL = 0xA2;
        public const int VK_RCONTROL = 0xA3;


        public const int KEY_HOME = 0x100 | VK_HOME;
        public const int KEY_UP = 0x100 | VK_UP;
        public const int KEY_PGUP = 0x100 | VK_PRIOR;
        public const int KEY_LEFT = 0x100 | VK_LEFT;
        public const int KEY_RIGHT = 0x100 | VK_RIGHT;
        public const int KEY_END = 0x100 | VK_END;
        public const int KEY_DOWN = 0x100 | VK_DOWN;
        public const int KEY_PGDN = 0x100 | VK_NEXT;
        public const int KEY_INS = 0x100 | VK_INSERT;
        public const int KEY_DEL = 0x100 | VK_DELETE;
        public const int KEY_CTRL_LEFT = 0x200 | VK_LEFT;
        public const int KEY_CTRL_RIGHT = 0x200 | VK_RIGHT;
        public const int KEY_CTRL_END = 0x200 | VK_END;
        public const int KEY_CTRL_PGDN = 0x200 | VK_NEXT;
        public const int KEY_CTRL_HOME = 0x200 | VK_HOME;
        public const int KEY_CTRL_PGUP = 0x200 | VK_PRIOR;
    }

    public class CmdLine   // consider putting this under wcConsoleAPI
    {
        private const uint NO_INPUT_NUMBER = 0x80000000;
        private const int MAX_BUFFER_SIZE = 80; //1024;
        private const int INFINITE = -1;
        private const int INPUT_TIMEOUT = 1;
        private string CurrentCmdLine = "";


        private bool AutoWrapMode { get; set; }
        private bool AutoWrapped { get; set; }
        private bool EchoStars { get; set; }
        private bool FlushAllChannels { get; set; }
        private bool IdleTimeoutLogoff { get; set; }  // = true
        private bool NoTrim { get; set; }
        private bool SuppressBrackets { get; set; }
        private bool SuppressInitialSpace { get; set; }
        private bool UseHotKeysAnyway { get; set; }
        private int HotKeyDelay { get; set; }
        private int IdleTimeoutSeconds { get; set; }
        private int MaxLength { get; set; }
        private int SystemPageChannel { get; set; }
        private string InitialString { get; set; }

        private void InitStateVariables()
        {
            AutoWrapMode = false;
            AutoWrapped = false;
            EchoStars = false;
            FlushAllChannels = false;
            HotKeyDelay = 0;
            IdleTimeoutLogoff = true;
            InitialString = "";
            MaxLength = 0;
            NoTrim = false;
            SuppressBrackets = false;
            SuppressInitialSpace = false;
            SystemPageChannel = 0;
            UseHotKeysAnyway = false;
            SetDefaultIdleTimeout();
        }

        private CmdLine()
        {
            InitStateVariables();
        }

        public void PushCommand(string cmd) { InitialString = cmd; }
        public void SetEchoStars() { EchoStars = true; }
        public void SetUseHotKeysAnyway() { UseHotKeysAnyway = true; }
        public void SetHotKeyDelay(int hkdelay) { HotKeyDelay = hkdelay; }
        public void SetAutoWrapMode() { AutoWrapMode = true; }
        public void SetSuppressInitialSpace() { SuppressInitialSpace = true; }
        public void SetSuppressBrackets() { SuppressBrackets = true; }
        public void SetInitialString(string s) { InitialString = s; }
        public void SetInitialDate(DateTime dt)
        {
            throw new NotImplementedException();
#if false
          if (dt.High > 0) {
            // Force a YYYY date format
            SetInitialString(DateString(dt,GetDateMask(2)))
          }
#endif
        }
        public void SetNoTrim() { NoTrim = true; }
        public void SetFlushAllChannels() { FlushAllChannels = true; }
        public void SetIdleTimeoutSecs(int secs) { IdleTimeoutSeconds = secs; }

        public void SetIdleTimeoutMins(int mins) { IdleTimeoutSeconds = mins * 60; }
        private void SetDefaultIdleTimeout() { IdleTimeoutSeconds = wcGlobal.Makewild.Timeouts.Telnet * 60; }
        public void SetIdleTimeoutLogoff(bool onoff) { IdleTimeoutLogoff = onoff; }

        public int pos()
        {
            // return (column number)
            return 0;
        }
        public string GetInput(bool crlf, string mask = "")
        {
            bool Warned = false;
            DateTime start;
            GetCurrentDateTime(start);
            TReadStringState rs = new TReadStringState();
            //clear rs
            rs.CrLf = crlf;
            rs.EchoStars = EchoStars;
            rs.HotKeys = (wcGlobal.User.HotKeys != 0) &&
                         ((MaxLength == 1) || (mask.Length == 1) || UseHotKeysAnyway);
            rs.HotKeyDelay = HotKeyDelay;
            rs.AutoWrapMode = AutoWrapMode;
            rs.SuppressInitialSpace = SuppressInitialSpace;
            rs.SuppressBrackets = SuppressBrackets;
            rs.Timeout = 1000;
            rs.MaxLength = MaxLength;
            rs.Mask = mask.ToCharArray();
            rs.Str = InitialString.ToCharArray();
            // 79-pos-2
            if (rs.MaxLength > ((MAX_BUFFER_SIZE - 1) - pos() - 2)) {
                rs.MaxLength = ((MAX_BUFFER_SIZE - 1) - pos() - 2);
            }
            // 450.9b5 09/25/03 05:17 pm
            // - Moved GetObjectFlags() server calls out from the loop
            //   This was causing a high server hit!

            bool bIgnoreIdleTime = (wcServerAPI.GetObjectFlags(wcServerAPI.OBJECTID_IGNORE_IDLE_TIME) != 0);
            bool bIgnoreOnlineTime = (wcServerAPI.GetObjectFlags(wcServerAPI.OBJECTID_IGNORE_TIME_ONLINE) != 0);
            bool bForever = true;
            do
            {
                rs.AutoWrapMode = AutoWrapMode;
                int p = ProcessPageChannel;
                if (p >= 0)
                {
                    rs.Redisplay = true;
                    if (p == wcServerAPI.SP_SYSOP_CHAT)
                    {
                        GetCurrentDateTime(start);
                    }
                }
                ReadString(rs);
                switch (rs.Result)
                {
                    case INPUT_TIMEOUT:
#if false
                        if not Local and (not bIgnoreIdleTime) and (IdleTimeoutSeconds>0) then
                          dim now as DateTime
                          GetCurrentDateTime(now)
                          select case GetSecondsSince(start)
                            case is >= IdleTimeoutSeconds
                              print
                              print
                              if IdleTimeoutLogoff then
                                 if not DisplayFile("InactiveLogoff") then
                                    print [LogOffInactivity "@N@Sorry, you have been automatically logged off for inactivity."]
                                    print
                                 end if
                                 hangup(False)
                              else
                                 if not DisplayFile("InactiveAbort") then
                                    print [AbortInactivity "@N@Sorry, this process has automatically terminated for inactivity."]
                                    print
                                 end if
                                 end
                              end if
                              exit do
                            case is >= (IdleTimeoutSeconds-60)
                              if not Warned and ((IdleTimeoutSeconds-60)>0) then
                                print
                                print
                                print chr(7);chr(7);chr(7);
                                if IdleTimeoutLogoff then
                                 if not DisplayFile("InactiveLogoffWarning") then
                                    print [LogOffInactivityWarning "@F@CAUTION! @N@You will be logged off if you do not continue within 60 seconds."]
                                 end if
                                else
                                 if not DisplayFile("InactiveAbortWarning") then
                                   print [AbortInactivityWarning "@F@CAUTION! @N@This process will terminate if you do not continue within 60 seconds."]
                                 end if
                                end if
                                print
                                Warned = True
                              end if
                          end select
                        end if
                        if GetMinutesRemaining = 0 and (Not bIgnoreOnlineTime) then
                          print
                          print
                          print [LogOffOutOfTime "@N@Sorry, you are out of time for today."]
                          print
                          hangup(False)
                          exit do
                        end if
#endif
                    default:
#if false
                        if (GetMinutesRemaining() == 0 && (!bIgnoreOnlineTime)) {
                            print
                            print[LogOffOutOfTime "@N@Sorry, you are out of time for today."]
                            print
                            hangup(False)
                            bForever = false;
                            break;
                        }
#endif
                        bForever = false;
                        break;
                }
            } while (bForever);
            AutoWrapped = rs.AutoWrapMode;
            InitStateVariables();
            return wcTools.GetString(rs.Str);
        }

        public string GetNextWord(bool remove)
        {
            int i = 1;
            string result = "";
            while (CurrentCmdLine[i] == ' ') i++;
            char t;
            if (CurrentCmdLine[i] == '"')
            {
                t = '"';
                i++;
            } else
            {
                t = ' ';
            }
            int j = 0;
            while (((i + j) <= CurrentCmdLine.Length) && CurrentCmdLine[i + j] != t) j++;
            result = CurrentCmdLine.Substring(i, j);
            if (remove) CurrentCmdLine = CurrentCmdLine.Substring(i + j + 1);
            return result;
        }


        public string InputString(int maxlen, bool wait = true, bool crlf = true )
        {
            string s;
            string result;
            s = CurrentCmdLine;
            CurrentCmdLine = "";
            if (maxlen > 0)
            {
                // s = left(s, maxlen)
                s = s.Substring(0, maxlen);
            }
            bool ntrim = NoTrim;
            if (ntrim)
            {
                result = s;
            } else
            {
                result = s.Trim();
            }
            if (s != "" || !wait)
            {
                return result;
            }
            MaxLength = maxlen;
            s = GetInput(crlf);
            if (ntrim)
            {
                result = s;
            }
            else
            {
                result = s.Trim();
            }
            return result;
        }
        public string InputMask(string mask, bool crlf = true)
        {
            return GetInput(crlf, mask);
        }
        public string InputWord(int maxlen, bool wait = true, bool crlf = true)
        {
            string s;
            string result;
            s = GetNextWord(true);
            if (maxlen > 0) {
                //s = left(s, maxlen);
                s = s.Substring(0, maxlen);
            }
            result = s;
            if (s != "" || !wait) {
                return result;
            }
            MaxLength = maxlen;
            CurrentCmdLine = GetInput(crlf);
            result = GetNextWord(true);
            return result; 
        }

        public uint InputNumber(bool wait = true, bool crlf = true)
        {
            string s;
            uint result;
            s = GetNextWord(true);
            int n = 0;
            Int32.TryParse(s, out n);
            if (s[1] >= '0' && s[1] <= '9')
            {
                result = (uint)n;
            }
            else
            {
                result = NO_INPUT_NUMBER;
            }
            if (n > 0 || !wait)
            {
                return result;
            }
            MaxLength = 9;
            CurrentCmdLine = GetInput(crlf);
            s = GetNextWord(true);
            if (s[1] >= '0' && s[1] <= '9')
            {
                result = (uint)n;
            }
            else
            {
                result = NO_INPUT_NUMBER;
            }
            return result;

        }
        public bool InputYesNo(string prompt, bool def = true)
        {
#if false
  dim s as string
  s = ucase(GetNextWord(True))
  if s(1) = Language.SubcommandChars(LSC_YES) then
    InputYesNo = True
    exit function
  elseif s(1) = Language.SubcommandChars(LSC_NO) then
    InputYesNo = False
    exit function
  else
    CurrentCmdLine = ""
  end if
  dim done as boolean
  do
    done = True
    print prompt;
    select case default
      case True
        print [YesNoDefaultYes " @N@[@H@Y@N@/@F@n@N@]?"];
        InitialString = Language.SubcommandChars(LSC_YES)
      case False
        print [YesNoDefaultNo " @N@[@H@y@N@/@F@N@N@]?"];
        InitialString = Language.SubcommandChars(LSC_NO)
      case else
        print [YesNoDefaultNone " @N@[@H@y@N@/@F@n@N@]?"];
    end select
    s = ucase(InputMask("!"))
    if s(1) = Language.SubcommandChars(LSC_YES) then
      InputYesNo = True
    elseif s(1) = Language.SubcommandChars(LSC_NO) then
      InputYesNo = False
    elseif s = "" and default <> 1 then
      InputYesNo = default
    else
      print
      print [YesNoPickOne "Please answer Yes or No."]
      print
      done = False
    end if
  loop until Done
#endif
            return false;
        }
        public bool GetAutoWrapped() { return AutoWrapped; }
        public int GetSystemPageChannelId() { return SystemPageChannel; }

        public bool InputDate(ref DateTime dt)
        {
            //return DateStringToDateTime(InputDateString(dt), dt);
            return true;
        }
        // InputeDateString forces a YYYY date input.
        // returns "" if the input is invalid
        public string InputDateString(ref DateTime dt)
        {
#if false
  dim s as string
  dim tempdt as datetime
  InputDateString = ""
  SetInitialDate(dt)
  s = InputMask(GetDateInputMask)
  if DateStringToDateTime(s, tempdt) then
     InputDateString = s
     exit function
  end if
#endif
            return "";
        }

#if false
declare sub ProcessPageChannelMessage lib "cmdline" (cmsg as TChannelMessage, byval allowchat as boolean = False)
declare function ProcessPageChannel lib "cmdline" (byval allowchat as boolean = True) as integer
#endif

        public static class THost
        {
            //BOOL expandatcodes = TRUE, DWORD *actionflags = NULL
            public static uint Write(string s, bool expandatcodes = true)
            {
                uint actionflags = 0;
                return actionflags;
            }
            public static uint Write(byte[] d, bool expandatcodes = true)
            {
                uint actionflags = 0;
                return actionflags;
            }
            public static uint Write(char[] d, bool expandatcodes = true)
            {
                uint actionflags = 0;
                return actionflags;
            }
            public static uint Write(char ch)
            {
                uint actionflags = 0;
                return actionflags;
            }
            public static void Write(bool expandatcodes, string fmt, params object[] v)
            {
                if (fmt == null) return;
                String s = "";
                if (v.Length == 0) s = fmt;
                s = String.Format(fmt, v);
                Write(s, expandatcodes);
            }
            public static int ReadKey(int timeout = INFINITE)
            {
                return 0;
            }
            public static int GetCursorX()
            {
                return 0;
            }
        }
        private class TBUF
        {
            private byte[] buffer = null;

            public TBUF()
            {
            }
            public TBUF(int size)
            {
                buffer = new byte[size];
            }

            public void Format(string fmt, params object[] v)
            {
                if (fmt == null) return;
                String s = "";
                if (v.Length == 0) s = fmt;
                s = String.Format(fmt, v);
                buffer = wcTools.GetBytes(s); 
                return;
            }
            public byte[] GetBuffer()
            {
                return buffer;
            }

            public int Length
            {
                get { return buffer.Length; }
            }
            public byte this[int index]
            {
                get
                {
                    return buffer[index];
                }

                set
                {
                    buffer[index] = value;
                }
            }
        }

        ///////////////////////////////////////////////////////////////////
        // \local\wc8\wccore\readstr.cpp
        // \local\wc8\wccore\readstr.h
        ///////////////////////////////////////////////////////////////////

        public struct TReadStringState
        {
            public bool CrLf;
            public bool EchoStars;
            public bool HotKeys;
            public int HotKeyDelay;
            public bool AutoWrapMode;
            public bool SuppressInitialSpace;
            public bool SuppressBrackets;
            public int Timeout;
            public int MaxLength;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_BUFFER_SIZE)]
            public char[] Str;       // char Str[80];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_BUFFER_SIZE)]
            public char[] Mask;      // char Mask[80];

            public uint Result;
            public bool Redisplay;
            public int Index;
            public bool Continued;
            public bool RealMask;
            public bool ZapFirst;
            public bool EchoInput; // 453.1  // 11/15/16 11:48 pm disabled
        };

        public class TReadString
        {
            const uint INPUT_TIMEOUT = 1;
            
            bool Done { get; set; }

            private static TBUF buf = new TBUF(MAX_BUFFER_SIZE);
            private static TReadStringState RS = new TReadStringState();

            public TReadString() { }
            public TReadString(TReadStringState rs)
            {
                RS = rs;
                RS.Result = 0;
                if (!RS.Continued)
                {
                    RS.RealMask = RS.Mask[0] != 0;
                    RS.ZapFirst = RS.Str[0] != 0;
                    if (RS.MaxLength == 0 || RS.MaxLength >= MAX_BUFFER_SIZE)
                    {
                        RS.MaxLength = MAX_BUFFER_SIZE - 1;
                    }
                    else if (RS.Mask[0] == 0 && !RS.AutoWrapMode)
                    {
                        Fill(ref RS.Mask, 'X', 0, RS.MaxLength);
                        RS.Mask[RS.MaxLength] = (char)0;
                        RS.RealMask = false;
                    }
                }
                if (RS.Timeout == 0)
                {
                    RS.Timeout = INFINITE;
                }
                if (!RS.Continued || RS.Redisplay)
                {
                    if (!RS.SuppressInitialSpace && THost.GetCursorX() > 0)
                    {
                        THost.Write(' ');
                    }
                    if (RS.Mask[0] != 0)
                    {
                        RS.MaxLength = RS.Mask.Length;
                        if (wcGlobal.AnsiDetected)
                        {
                            if (RS.SuppressBrackets)
                            {
                                THost.Write("@U@");
                            }
                            else
                            {
                                THost.Write("@N@[@U@");
                            }
                            unsafe
                            {
                                fixed (char* p = &RS.Str[0])
                                {
                                    int i = 0;
                                    while (RS.Mask[i] != 0)
                                    {
                                        switch (RS.Mask[i])
                                        {
                                            case 'X':
                                            case '!':
                                            case '9':
                                            case '#': // HLS
                                            case '0': // HLS
                                                THost.Write(' ');
                                                break;
                                            default:
                                                THost.Write(RS.Mask[i]);
                                                if (*p != (char)0)
                                                {
                                                    char* RS0 = &RS[0];
                                                    char* t =  strchr(p, RS.Mask[i]);
                                                    fixed(char *t = ) {
                                                        if (*t != (char)0)
                                                        {
                                                            if (i > (t - RS0))
                                                            {
                                                                int n = i - (t - RS0);
                                                                Insert(' ', p, n);
                                                                p = t + n + 1;
                                                            }
                                                            else
                                                            {
                                                                p = t + 1;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            *p = (char)0; // p = null;
                                                        }
                                                    }

                                                }
                                                break;
                                        }
                                        i++;
                                    }
                                }
                            }
                            if (!RS.SuppressBrackets)
                            {
                                THost.Write("@N@]");
                            }
                            THost.Write(true,"\033[%dD", RS.Mask.Length + 1);
                        }
                    }
                    if (RS.AutoWrapMode)
                    {
                        RS.Index = RS.Str.Length;
                    }
                    THost.Write("@U@");
                    if (RS.Str[0] != 0)
                    {
                        THost.Write(RS.Str, false);
                        if (RS.Str.Length > RS.Index)
                        {
                            char[] buf = new char[MAX_BUFFER_SIZE];
                            if (wcGlobal.AnsiDetected)
                            {
                                string s = string.Format("\033[%dD", RS.Str.Length - RS.Index);
                                buf = s.ToCharArray(); // wcTools.GetBytes(s);
                            }
                            else
                            {
                                Fill(ref buf, '\b', 0, RS.Str.Length - RS.Index);
                                buf[RS.Str.Length - RS.Index] = (char)0;
                            }
                            THost.Write(buf);
                        }
                    }
                }

                if (!CallController.Interactive)
                {
                    return;
                }

                RS.Continued = true;
                RS.Redisplay = false;


                CallController.GoAhead();
                CallController.SetFastTelnetTurnaround(true);

                bool IgnoreTimeOnline = wcServerAPI.GetObjectFlags(wcServerAPI.OBJECTID_IGNORE_TIME_ONLINE) != 0;
                bool IgnoreIdleOnline = wcServerAPI.GetObjectFlags(wcServerAPI.OBJECTID_IGNORE_IDLE_TIME) != 0;
                int dwIdleTime = wcGlobal.Makewild.Timeouts.Telnet;
                if (wcGlobal.User.Info.ID == 0)
                {  // use is not logged in yet
                    dwIdleTime = wcGlobal.Makewild.Timeouts.TelnetLogin;
                    IgnoreIdleOnline = false;
                }
                //-------------------------------------------------------

                Done = false;
                FILETIME start = Now();
                while (!Done && Host.Online() &&
                        (IgnoreTimeOnline || (host.TimeOff.dwHighDateTime == 0 || Now() < host.TimeOff))
                      )
                {
                    if (RS.Mask[0] != 0)
                    {
                        int i = RS.Index;
                        while (RS.Mask[i] != 0)
                        {
                            if (RS.Mask[i] == 'X' ||
                                RS.Mask[i] == '!' ||
                                RS.Mask[i] == '9' ||
                                RS.Mask[i] == '#' || 
                                RS.Mask[i] == '0')
                            { 
                                while (RS.Index < i)
                                {
                                    RS.Str[RS.Index] = RS.Mask[RS.Index];
                                    THost.Write(RS.Str[RS.Index]);
                                    RS.Index++;
                                }
                                break;
                            }
                            i++;
                        }
                    }
                    int k = THost.ReadKey(RS.Timeout == INFINITE ? 10000 : RS.Timeout);
                    if (k != 0)
                    {
                        ProcessKey(k);
                    }
                    else if (RS.Timeout != INFINITE)
                    {
                        RS.Result = INPUT_TIMEOUT;
                        Done = true;
                    }
                    else
                    {
                        // 449.5 10/09/2001
                        // fixed idle time via @PAUSE@
                        if (!IgnoreIdleOnline && (dwIdleTime > 0))
                        {
                            if (Now() - start > dwIdleTime * 60)
                            {
                                host.DropCall();
                            }
                        }
                    }
                } // while

                if (RS.AutoWrapMode && RS.Index < RS.MaxLength)
                {
                    RS.AutoWrapMode = false;
                }
                CallController.SetFastTelnetTurnaround(false);

            }

            private void Delete(ref byte[] str, int idx, int amt = 1)
            {
                int iEnd = idx + amt;
                if (iEnd > MAX_BUFFER_SIZE) iEnd = (int)MAX_BUFFER_SIZE;
                for (int i = idx; i < iEnd; i++)
                {
                    str[i] = str[i + 1];
                }
            }
            private void Insert(char ch, ref byte[] str, int idx, int amt = 1)
            {
                // move to right, if allowed
                for (int i = idx; i < str.Length; i++)
                {
                    str[idx] = (byte) ch;
                }
            }
            //Fill(ref RS.Str, (byte)'*', RS.Index, RS.Str.Length-RS.Index);
            public void Fill(ref char[] buf, char ch, int idx, int amt = 1)
            {
                for (int i = idx; i < (idx+amt); i++)
                {
                    buf[i] = ch;
                }
                return;
            }
            public void Fill(ref byte[] buf, char ch, int idx, int amt = 1)
            {
                for (int i = idx; i < (idx + amt); i++)
                {
                    buf[i] = (byte) ch;
                }
                return;
            }

            public void ProcessKey(int k)
            {
                //string buf;
                while (true)
                {
                    switch (k)
                    {
                        case '\b':
                            if (RS.RealMask)
                            {
                                int i = RS.Index;
                                while (i > 0)
                                {
                                    i--;
                                    if (RS.Mask[i] == 'X' ||
                                        RS.Mask[i] == '!' ||
                                        RS.Mask[i] == '9' ||
                                        RS.Mask[i] == '#' ||
                                        RS.Mask[i] == '0')
                                    {
                                        if (i < RS.Index - 1)
                                        {
                                            if (wcGlobal.AnsiDetected)
                                            {
                                                //buf = String.Format("\033[{0}", RS.Index - i - 1);
                                                buf.Format("\033[{0}D", RS.Index - i - 1);
                                            }
                                            else
                                            {
                                                buf.Fill((byte)'\b', RS.Index - i - 1);
                                                buf[(RS.Index - i - 1)] = 0;
                                            }
                                            THost.Write(buf.GetBuffer(), false);
                                        }
                                        THost.Write("\b \b");
                                        RS.Index = i;
                                        RS.Str[RS.Index] = 0;
                                        break;
                                    }
                                }
                            }
                            else if (RS.Index > 0)
                            {
                                RS.Index--;
                                //RS.Str.Remove(RS.Index, 1);
                                Delete(ref RS.Str, RS.Index, 1);
                                if (wcGlobal.AnsiDetected)
                                {
                                    if (RS.EchoStars)
                                    {
                                        buf[0] = (byte)'\b';
                                        //FillMemory(&buf[1], strlen(&RS.Str[RS.Index]), '*');

                                        Fill(ref RS.Str, (byte)'*', RS.Index, RS.Str.Length-RS.Index);
                                        wsprintf(&buf[1 + RS.Str.Substring(RS.Index).Length], " \033[%dD", strlen(&RS.Str[RS.Index]) + 1);
                                    }
                                    else
                                    {
                                        buf = string.Format("\b%s \033[%dD", RS.Str[RS.Index], RS.Str.Substring(RS.Index).Length + 1);
                                    }
                                    THost.Write(buf, false);
                                }
                                else
                                {
                                    Host.Write("\b \b");
                                }
                            }
                            break;
                        case '\r':
                            if (RS.CrLf && CallController.EchoInput())
                            {
                                // 453.1
                                // 11/15/16 11:48 pm disabled
                                // 454.10
                                // 05/18/20 07:03 pm enabled
                                if (RS.EchoInput)
                                {
                                    THost.Write("\r\n");
                                }

                            }
                            THost.GetDisplay()->WriteDirty();
                            Done = true;
                            break;
                        case 0x7f:
                            if (RS.RealMask)
                            {
                                // ??
                            }
                            else if (RS.Index < RS.Str.Length)
                            {
                                RS.Str = RS.Str.Remove(RS.Index, 1);
                                if (wcGlobal.AnsiDetected)
                                {
                                    if (RS.EchoStars)
                                    {
                                        buf = new string('*', RS.Str.Substring(RS.Index).Length);
                                        wsprintf(&buf[strlen(&RS.Str[RS.Index])], " \033[%dD", strlen(&RS.Str[RS.Index]) + 1);
                                    }
                                    else
                                    {
                                        buf = string.Format("%s \033[%dD", RS.Str.Substring(RS.Index), RS.Str.Substring(RS.Index).Length + 1);
                                    }
                                    THost.Write(buf, false);
                                }
                                else
                                {
                                    if (RS.EchoStars)
                                    {
                                        buf = new string('*', RS.Str.Substring(RS.Index).Length);
                                        buf[strlen(&RS.Str[RS.Index])] = 0;
                                    }
                                    else
                                    {
                                        buf = RS.Str.Substring(RS.Index);
                                    }
                                    THost.Write(buf);
                                    THost.Write(" ");
                                    buf = new string('\b', RS.Str.Substring(RS.Index).Length + 1);
                                    buf[strlen(&RS.Str[RS.Index]) + 1] = 0;
                                    THost.Write(buf);
                                }
                            }
                            break;
                        default:
                            if (k >= ' ' && k < 256 && RS.Index < RS.MaxLength)
                            {
                                if (RS.RealMask)
                                {
                                    switch (RS.Mask[RS.Index])
                                    {
                                        case 'X':
                                            break;
                                        case '!':
                                            CharUpperBuff((char*)&k, 1);
                                            break;
                                        // HLS NOTE:
                                        // This is documented in the WCCODE as numbers only, no space.
                                        // We see here, that a space is allowed.  This is what Visual
                                        // BASIC defines it as.
                                        case '9':
                                            if (k != ' ' && (k < '0' || k > '9'))
                                            {
                                                return;
                                            }
                                            break;
                                        case '0':
                                            if ((k < '0' || k > '9'))
                                            {
                                                return;
                                            }
                                            break;
                                        case '#':
                                            if ((k != '-') &&
                                                (k != '+') &&
                                                (k != ' ') &&
                                                (k < '0' || k > '9'))
                                            {
                                                return;
                                            }
                                            break;
                                        default:
                                            return;
                                    }
                                    //--------------------------------------------------------
                                    // HLS: 02/24/99 09:33 pm
                                    // This original code conflicts with logic that
                                    // sets the initial string (i.e, SetInitialString in WCCODE)
                                    RS.Str[RS.Index] = k;
                                    RS.Index++;
                                    ////RS.Str[RS.Index] = 0;
                                    //--------------------------------------------------------
                                }
                                else
                                {
                                    if (RS.ZapFirst && RS.Index == 0)
                                    {
                                        buf = new string(' ', RS.MaxLength);
                                        buf[RS.MaxLength] = 0;
                                        Host.Write(buf);
                                        buf = string.Format("\033[%dD", RS.MaxLength);
                                        Host.Write(buf);
                                        RS.Str = ""; // RS.Str[0] = 0;
                                    }
                                    //Insert(k, &RS.Str[]);
                                    RS.Str = RS.Str.Insert(RS.Index, new string((char)k, 1));
                                    RS.Index++;
                                    RS.Str[RS.MaxLength] = 0;
                                }

                                // HLS NOTE:
                                // Character has been checked at this point
                                //
                                if (CallController.EchoInput())
                                {
                                    // 453.1 11/15/16 disabled
                                    // 454.10 05/18/20 enabled
                                    if (RS.EchoInput)
                                    {
                                        if (RS.EchoStars)
                                        {
                                            THost.Write("*");
                                        }
                                        else
                                        {
                                            THost.Write(k);
                                        }
                                    }
                                }
                                if (wcGlobal.AnsiDetected && (RS.Str[RS.Index] != 0))
                                {
                                    if (RS.EchoStars)
                                    {
                                        buf = new string('*', RS.Str.Substring(RS.Index).Length);
                                        wsprintf(&buf[strlen(&RS.Str[RS.Index])], "\033[%dD", strlen(&RS.Str[RS.Index]));
                                    }
                                    else
                                    {
                                        buf = string.Format("%s\033[%dD", RS.Str.Substring(RS.Index), RS.Str.Substring(RS.Index).Length);
                                    }
                                    THost.Write(buf, false);
                                }
                                if (RS.HotKeys)
                                {
                                    if (RS.HotKeyDelay != 0)
                                    {
                                        k = THost.ReadKey(RS.HotKeyDelay);
                                        if (k != 0)
                                        {
                                            RS.HotKeys = false; 
                                            continue;
                                        }
                                    }
                                    ProcessKey('\r');
                                }
                                if (RS.AutoWrapMode && RS.Index >= RS.MaxLength)
                                {
                                    ProcessKey('\r');
                                }
                            }
                            else if (k >= 256 && wcGlobal.AnsiDetected && !RS.RealMask)
                            {
                                switch (k)
                                {
                                    case VirtualKeys.KEY_HOME:
                                        if (RS.Index > 0)
                                        {
                                            buf = string.Format("\033[%dD", RS.Index);
                                            THost.Write(buf);
                                        }
                                        RS.Index = 0;
                                        break;
                                    case VirtualKeys.KEY_LEFT:
                                        if (RS.Index > 0)
                                        {
                                            THost.Write("\033[D");
                                            RS.Index--;
                                        }
                                        break;
                                    case VirtualKeys.KEY_RIGHT:
                                        if (RS.Str[RS.Index] != 0)
                                        {
                                            if (RS.EchoStars)
                                            {
                                                THost.Write("*");
                                            }
                                            else
                                            {
                                                THost.Write(RS.Str.Substring(RS.Index));
                                            }
                                            RS.Index++;
                                        }
                                        break;
                                    case VirtualKeys.KEY_END:
                                        if (RS.Str.Length > RS.Index)
                                        {
                                            buf = string.Format("\033[%dC", RS.Str.Length - RS.Index);
                                            THost.Write(buf);
                                        }
                                        RS.Index = RS.Str.Length;
                                        break;
                                    case VirtualKeys.KEY_INS:
                                        break;
                                    case VirtualKeys.KEY_DEL:
                                        if (RS.Str[RS.Index] != 0)
                                        {
                                            THost.Write(RS.Str.Substring(RS.Index));
                                            RS.Index++;
                                            ProcessKey('\b');
                                        }
                                        break;
                                }
                            }
                            break;
                    }
                    break;
                }
                RS.ZapFirst = false;
            } // ProcessKey
        }  // class TReadString
    } // class CmdLine
} // namespace


