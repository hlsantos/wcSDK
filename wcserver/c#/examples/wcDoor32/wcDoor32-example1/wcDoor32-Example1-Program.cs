//#define USE_CLASS_DOOR
#define USE_DIRECT_DOOR
#define USE_CALLBACK

using System;
using System.Runtime.InteropServices;
using System.Text;
using wcSDK;

#if DEBUG
using System.Collections;
using System.Collections.Generic;
#endif

namespace wcDoor32_example1
{
    class Program
    {
#if USE_DIRECT_DOOR

#if USE_CALLBACK
        #region "Private Delegates ..."
        #endregion
        [DllImport("kernel32.dll")]
        static extern bool SetEvent(IntPtr hEvent);

        private static uint SystemControlNodeChannel = 0;
        public static int WildcatCallBackFunc(int UserData, ref wcServerAPI.TChannelMessage msg)
        {
            Console.WriteLine("msg.Channel: {0} msg.SenderId: {1}, msg.UserData: {2}", msg.Channel,msg.SenderId, msg.UserData);
            if (msg.Channel == SystemControlNodeChannel)
            {
                switch (msg.UserData)
                {
                    case wcServerAPI.SC_DISCONNECT:
                        SetEvent((IntPtr)wcDoor32API.DoorGetOfflineEventHandle());
                        Console.WriteLine("SC_DISCONNECT");
                        break;
                }
            }
            return 0;
        }
#endif    

        public static int StartDoor()
        {
            if (!wcDoor32API.DoorInitialize())
            {
                int err = Marshal.GetLastWin32Error();
                if (err == 203)
                {
                    // ERROR_ENVVAR_NOT_FOUND no environment, not called by Wildcat! door32 system.
                    // i.e. the exe was called directly
                    Console.WriteLine("! Error {0}: wcDoor32 Environment not found.", err);
                    return 0;
                }
                Console.WriteLine("! Error {0}: DoorInitialize ", err);
                return 0;
            }
#if USE_CALLBACK
            wcServerAPI.TWildcatCallBack myCallBack = new wcServerAPI.TWildcatCallBack(WildcatCallBackFunc);
            wcServerAPI.SetupWildcatCallback(myCallBack, 0);
            string sNode = string.Format("system.control.{0}", wcServerAPI.GetNode());
            SystemControlNodeChannel = (uint)wcServerAPI.OpenChannel(sNode);
            Console.WriteLine("* node: {0} OpenChannel(\"{1}\") : SystemControlNodeChannel: {2}", 
                wcServerAPI.GetNode(), sNode, SystemControlNodeChannel);
#endif
            Console.WriteLine("* DoorInitialize() OK");

            // Get the current user logged in

            wcServerAPI.TUser User = new wcServerAPI.TUser();
            wcServerAPI.WildcatLoggedIn(ref User);

            User.Info.Name = User.Info.Name.Trim();
            wcDoor32API.DoorWrite("=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-\r\n");
            wcDoor32API.DoorWrite("=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-\r\n");
            wcDoor32API.DoorWrite("=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-\r\n");
            wcDoor32API.DoorWrite("=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-\r\n");
            wcDoor32API.DoorWrite("=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-\r\n");
            wcDoor32API.DoorWrite("=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-\r\n");
            wcDoor32API.DoorWrite("=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-\r\n");
            wcDoor32API.DoorWrite("=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-\r\n");
            wcDoor32API.DoorWrite("=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-\r\n");
            wcDoor32API.DoorWrite("=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-\r\n");
            wcDoor32API.DoorWrite("=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-\r\n");
            wcDoor32API.DoorWrite("=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-\r\n");
            wcDoor32API.DoorWrite("=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-\r\n");
            wcDoor32API.DoorWrite("=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-\r\n");
            wcDoor32API.DoorWrite("=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-\r\n");
            wcDoor32API.DoorWrite("=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-\r\n");
            wcDoor32API.DoorWrite("=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-\r\n");
            wcDoor32API.DoorWrite("=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-\r\n");
            wcDoor32API.DoorWrite("=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-\r\n");
            wcDoor32API.DoorWrite("=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-\r\n");
            wcDoor32API.DoorWrite("=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-\r\n");
            wcDoor32API.DoorWrite("=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-\r\n");
            wcDoor32API.DoorWrite("=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-\r\n");
            wcDoor32API.DoorWrite("=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-\r\n");
            wcDoor32API.DoorWrite("=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-\r\n");
            wcDoor32API.DoorWrite("=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-\r\n");
            wcDoor32API.DoorWrite("=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-\r\n");
            wcDoor32API.DoorWrite("=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-\r\n");
            wcDoor32API.DoorWrite("=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-\r\n");
            wcDoor32API.DoorWrite("=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-\r\n");
            wcDoor32API.DoorWrite("@T@Welcome to WcDoor32.Net Example #1, {0}.@N@\r\n", User.Info.Name);
            wcDoor32API.DoorWrite("\r\n@E@nPress ESCAPE or / to quit:@N@\r\n");
            
            wcServerAPI.SetNodeActivity("wcDoor32.Net Example1!");

            int Active = 2;         // When 1 pending idle timeout, when 0 exit
            int idleTimeout = 60*5; // seconds
#if DEBUG
            //idleTimeout = 20; // seconds
            //var myKey = wcConsoleAPI.AnsiExtendedKeys.FirstOrDefault(x => x.Value == stest).Key;
            Dictionary<string, string> akeys = wcConsoleAPI.AnsiExtendedKeys;
            string stest = "";
#endif

            while (Active != 0)
            {
                switch (wcDoor32API.DoorEvent(idleTimeout * 1000))
                {
                    case wcDoor32API.WCDOOR_EVENT_KEYBOARD:
                        Active = 2;
                        byte[] data = new byte[4];
                        int rd = wcDoor32API.DoorRead(data, data.Length);
                        if (rd == 0) continue;
#if DEBUG
                        //---------------
                        stest = "";
                        for (int i = 0; i < rd; i++) { stest += (char)data[i]; }
                        string mykey  = stest;
                        string mykeystr = "";
                        bool found = akeys.TryGetValue(mykey, out mykeystr);
                        //if (akeys.ContainsKey(mykey)) { mykeystr = akeys[stest]; }
                        Console.WriteLine("rd: {0} found: {1} stest: |{2}| mykeystr: |{3}|", rd, found, stest, mykeystr);
                        for (int i = 0; i < rd; i++)
                        {
                            byte c = data[i];
                            Console.WriteLine("{0} ch:| '{1}' {2,3} (0x{3:X}) | '{4}' {5,3} (0x{6:X} <- {7} | {8} |", 
                                "-",
                                (char)c, c, c,
                                (char)c, c, c,
                                mykey,
                                mykeystr
                             );
                            //Console.WriteLine("        public static byte[] KEY_F1 = KEY_ESCAPE {0}+");
                        }
                        //---------------
#endif
                        byte ch = data[0];
                        if (ch == '/') { Active = 0; break; }
                        //if (ch == '1') { Active = 0; break; }
                        if (!wcDoor32API.DoorWrite(data, rd))
                        {
                            Console.WriteLine("!!!!ERROR writing data!");
                        }
                        if (ch == 13) { data[0] = 10; wcDoor32API.DoorWrite(data, 1); }
                        break;

                    case wcDoor32API.WCDOOR_EVENT_OFFLINE:
                        wcDoor32API.DoorWrite("\r\n** FORCE DISCONNECT **\r\n");
                        Console.WriteLine("** WCDOOR_EVENT_OFFLINE - GOODBYE **");
                        Active = 0;
                        break;

                    case wcDoor32API.WCDOOR_EVENT_TIMEOUT:
                        Active--;
                        switch (Active)
                        {
                            case 0:
                                wcDoor32API.DoorWrite("\r\n** IDLE TIMEOUT - GOODBYE **\r\n");
                                break;
                            case 1:
                                wcDoor32API.DoorWrite("\r\n** IDLE TIMEOUT IN {0} SECONDS **\r\n", idleTimeout);
                                break;
                        }
                        break;

                    case wcDoor32API.WCDOOR_EVENT_FAILED:
                        Console.WriteLine("** WCDOOR_EVENT_FAILED - GOODBYE **");
                        Active = 0;
                        break;
                }
            }

            wcDoor32API.DoorWrite("\r\n\r\nReturning to bbs...\r\n");
            wcDoor32API.DoorShutdown();
            return 0;
        }
#endif // USE_DIRECT_DOOR
        static void Main(string[] args)
        {

#if USE_CLASS_DOOR
            
            CWildcatDoor door = new CWildcatDoor();
            Console.WriteLine("door.GetDeviceType(): {0}", door.GetDeviceType());
            Console.WriteLine("Node: {0}", door.Node);
            Console.WriteLine("UserName: {0}", door.UserName);
            Console.WriteLine("User.from: {0}", door.User.from);

            //$door->SetGlobalTimeout(0);  // turn off PHP timeout

            door.ClearScreen();
            door.DisplayHello();
            door.Writeln("@H@Welcome to wcDoor32.Net Example");
            door.Writeln("@B@User      : @A@%s", door.UserName);
            door.Writeln("@B@Login Node: @A@%d", door.Node);
            door.Writeln("@B@Door Node : @A@%d", wcServerAPI.GetNode());
            door.Writeln("\r\n@N@Press a key or @H@THREE ESCAPES@N@ to quit@L@");

#else
#if DEBUG_X
            //var myKey = wcConsoleAPI.AnsiExtendedKeys.FirstOrDefault(x => x.Value == stest).Key;
            Dictionary<string, string> akeys = wcConsoleAPI.AnsiExtendedKeys;
            string svalue = "";
            //string skey = wcConsoleAPI.KEY_END; //"\033[4~";
            string skey = "\x1b[4~";
            
            Console.WriteLine("skey: |{0}| len: {1} skey[0]: '{2}' (0x{3:X})", skey, skey.Length, skey[0], skey[0]);
            Console.WriteLine("TryGetValue(\"{0}\"): found: {1} svalue: | {2} |", skey, akeys.TryGetValue(skey, out svalue), svalue);
            foreach (KeyValuePair<string, string> entry in akeys)

            {
                Console.WriteLine("{0,-5} | Key = |{1,-5}| Value = |{2,-8}| {3}", skey, entry.Key, entry.Value, (skey == entry.Key)?"GOT IT":"");
            }
            Console.Write("<pause>"); Console.ReadKey();
            Environment.Exit(1);

#endif

            Console.WriteLine("* Starting wcDOOR32.Net Door **");
            StartDoor();
            Console.WriteLine("* Ending wcDOOR32.Net Door **");
#endif
            //Console.Write("<pause>"); Console.ReadKey();
            //System.Threading.Thread.Sleep(5000);
        }
    }

}
