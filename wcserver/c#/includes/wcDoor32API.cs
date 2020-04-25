//***********************************************************************
// (c) Copyright 1998-2020 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : wcdoor32Api.cs
// Subsystem : Wildcat! Door32 for .NET
// Date      : 04/16/2020
// Version   : 8.0.454.10
// Author    : HLS/SSI
//
// Revision History:
// Build    Date      Author  Comments
// -----    --------  ------  -------------------------------------------
// 452.5    03/07/08  HLS     - Added WCDOOR_EVENT_XXXXXX
//                            - Added DoorEvent()
//
// 452.6    10/01/08  HLS     - For consistency and to help reduce
//                              long time conflict with door32.sys,
//                              door32.h was renamed to wcdoor32.h
//
// 454.10   04/16/20  HLS     - C# version of wcDoor32 header
//***********************************************************************

using System;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace wcSDK
{
    public class wcDoor32API
    {

        #region Credits ...

        // ------------------------------------------------------------------------
        // (c) Copyright 1998-2020 by Santronics Software Inc. All Rights Reserved.
        // Wildcat! Door 32bit API v8.0.454.10
        //
        // CUSTOM/MANUALLY UPDATED
        // ------------------------------------------------------------------------

        #endregion

        #region Public Wildcat! Door32 API Constants ...

        public const int WCDOOR_EVENT_BASE = 0;
        public const int WCDOOR_EVENT_FAILED = WCDOOR_EVENT_BASE + 0;
        public const int WCDOOR_EVENT_TIMEOUT = WCDOOR_EVENT_BASE + 1;
        public const int WCDOOR_EVENT_KEYBOARD = WCDOOR_EVENT_BASE + 2;
        public const int WCDOOR_EVENT_OFFLINE = WCDOOR_EVENT_BASE + 3;

        #endregion

        #region Public Wildcat! Door32  API Structures ...
        #endregion

        #region Public Wildcat! Door32 API DLL Imports ...

        ////!----------------------------------------------------------------
        ////! Group: wcDoor32 API
        ////! DoorInitialize
        ////! Initialize a wcDoor32 application
        ////! returns TRUE if successful, otherwise see extended error
        ////!----------------------------------------------------------------
        [DllImport("wcdoor32.dll", SetLastError = true)]
        public extern static bool DoorInitialize();

        ////!----------------------------------------------------------------
        ////! Group: wcDoor32 API
        ////! DoorShutdown
        ////! Shutdown a wcDoor32 application.
        ////! returns TRUE if successful, otherwise see extended error
        ////!----------------------------------------------------------------
        [DllImport("wcdoor32.dll", SetLastError = true)]
        public extern static bool DoorShutdown();

        ////!----------------------------------------------------------------
        ////! Group: wcDoor32 API
        ////! DoorHangUp
        ////! Disconnect (hangup) communications with user
        ////! returns TRUE if successful, otherwise see extended error
        ////!----------------------------------------------------------------
        [DllImport("wcdoor32.dll", SetLastError = true)]
        public extern static bool DoorHangUp();

        ////!----------------------------------------------------------------
        ////! Group: wcDoor32 API
        ////! DoorCharReady
        ////! Check if a character is available to be read or peeked.
        ////! returns TRUE if successful, otherwise see extended error
        ////!----------------------------------------------------------------
        [DllImport("wcdoor32.dll", SetLastError = true)]
        public extern static int DoorCharReady();


        ////!----------------------------------------------------------------
        ////! Group: wcDoor32 API
        ////! DoorRead
        ////! Read a character from input buffer
        ////! returns number of bytes read otherwise 0
        ////!----------------------------------------------------------------
        [DllImport("wcdoor32.dll", SetLastError = true)]
        public extern static int DoorRead(byte[] data, int size);

        ////!----------------------------------------------------------------
        ////! Group: wcDoor32 API
        ////! DoorPeek
        ////! Read/Peek a character without removing from input buffer.
        ////! returns number of bytes peeked otherwise 0
        ////!----------------------------------------------------------------
        [DllImport("wcdoor32.dll", SetLastError = true)]
        public extern static int DoorReadPeek(byte[] data, int size);

        ////!----------------------------------------------------------------
        ////! Group: wcDoor32 API
        ////! DoorWrite
        ////! Write characters to output buffer
        ////! returns TRUE if data is written, otherwise see extended error
        ////!----------------------------------------------------------------
        [DllImport("wcdoor32.dll", SetLastError = true)]
        public extern static bool DoorWrite(byte[] data, int size);

        ////!----------------------------------------------------------------
        ////! Group: wcDoor32 API
        ////! DoorGetAvailableEventHandle
        ////! get the event handle to process
        ////! returns HANDLE if successful, otherwise see extended error
        ////!----------------------------------------------------------------
        [DllImport("wcdoor32.dll", SetLastError = true)]
        public extern static int DoorGetAvailableEventHandle();

        ////!----------------------------------------------------------------
        ////! Group: wcDoor32 API
        ////! DoorGetOfflineEventHandle
        ////! get the offline handle to process
        ////! returns HANDLE if successful, otherwise see extended error
        ////!----------------------------------------------------------------
        [DllImport("wcdoor32.dll", SetLastError = true)]
        public extern static int DoorGetOfflineEventHandle();

        ////!----------------------------------------------------------------
        ////! Group: wcDoor32 API
        ////! DoorEvent
        ////! Get the event if any with a timeput
        ////! returns event handle if successful, otherwise see extended error
        ////!----------------------------------------------------------------
        [DllImport("wcdoor32.dll", SetLastError = true)]
        public extern static int DoorEvent(int timeout);

        #endregion

        #region "Helper functon"
        /// <summary>
        /// Helper Function:
        /// </summary>
        /// <param name="err">WIldcat! error number</param>
        /// <returns>returns Wildcat! error string</returns>
        public static string WildcatError(int err)
        {
            return "TBD";
        }
        /// <summary>
        /// Helper Function: DoorWrite overload for formating output
        /// </summary>
        /// <param name="fmt">format string</param>
        /// <param name="v">variable arguments</param>
        /// <returns>returns true if successful writing all bytes</returns>

        public static bool DoorWrite(string fmt, params object[] v)
        {
            if (fmt == null) return false;
            String buf = "";
            if (v.Length == 0) buf = fmt;
            buf = String.Format(fmt, v);
            byte[] data = Encoding.ASCII.GetBytes(buf);
            return DoorWrite(data, data.Length);
        }

        #endregion
    } // end of wcDoor32API


    public interface iWildcatConsoleIO
    {
        string GetDeviceType();
        bool Initialize();
        bool ShutDown();
        bool Write(byte[] data, int size);
        bool Writeln(byte[] data, int size);
        bool Writeln(string fmt, params object[] v);
        int Read(byte[] data, int size = 1024);
        int Peek(byte[] data, int size = 1024);
        int CharReady();
        int Event(int msecs);
        void ClearScreen(int v = 2);
    }

    class CWildcatDeviceDoor32 : iWildcatConsoleIO
    {
        public string GetDeviceType() { return "WCDOOR32"; }
        public bool Initialize() { return wcDoor32API.DoorInitialize(); }
        public bool ShutDown() { return wcDoor32API.DoorShutdown(); }
        public bool Write(byte[] data, int size) { return wcDoor32API.DoorWrite(data, size); }
        public bool Writeln(byte[] data, int size) { return wcDoor32API.DoorWrite(data, size); }
        public bool Writeln(string fmt, params object[] v) { return wcDoor32API.DoorWrite(fmt, v); }
        public int Read(byte[] data, int size = 1024) { return wcDoor32API.DoorRead(data, size); }
        public int Peek(byte[] data, int size = 1024) { return wcDoor32API.DoorReadPeek(data, size); }
        public int CharReady() { return wcDoor32API.DoorCharReady(); }
        public int Event(int msecs) { return wcDoor32API.DoorEvent(msecs); }
        public void ClearScreen(int v = 2) { wcDoor32API.DoorWrite("\033[{0}J", v); }

    }

    class CWildcatDeviceCRT32 : iWildcatConsoleIO
    {
        public string GetDeviceType() { return "WCCRT32"; }
        public bool Initialize() { return true; }
        public bool ShutDown() { return true; }
        public bool Write(byte[] data, int size) { Console.WriteLine(data); return true; }
        public bool Writeln(byte[] data, int size) { Console.WriteLine(data); return true; }
        public bool Writeln(string fmt, params object[] v)
        {
            if (fmt == null) return false;
            Console.WriteLine(fmt, v);
            return true;
        }
        public int Read(byte[] data, int size = 1024)
        {
            /*
            $s = "";
            while (wcKeyPressed()) $s.= chr(wcReadKey());
            return strlen($s);
            */
            return 0;
        }

        public int Peek(byte[] data, int size = 1024)
        {
            /*
            $s = "";
            while (wcKeyPressed()) $s.= chr(wcReadKey());
            return strlen($s);
            */
            return 0;
        }

        public int CharReady()
        {
            return 0; // wcKeyPressed();
        }

        public int Event(int msecs)
        {
            /*
            $atime = 0;
            $slice = 15;
            while (1)
            {
                if (wcKeyPressed()) return WCDOOR_EVENT_KEYBOARD;
                usleep($slice * 1000);
                $atime += $slice;
                if ($atime >= $msecs) break;
             }
            */
            return wcDoor32API.WCDOOR_EVENT_TIMEOUT;
        }
        public void ClearScreen(int v = 2) { }

    }

    public class CWildcatConsole : wcServerAPI
    {
        //-----------------
        // Options
        //-----------------

        public int GlobalTimeoutSecs = 0;
        public int IdleTimeoutSecs = 60;
        public int InputBufferSize = 0;

        //-----------------
        // Variables Set by Class
        //-----------------
        public TUser User;
        public string UserName = "";
        public int Node = 0;
        public bool ColorEnabled = false;
        public Dictionary<string, string> DoorSys = new Dictionary<string, string>();

        //-----------------
        // private
        //-----------------

        private bool Active = false;
        private uint StartTime = 0;
        private iWildcatConsoleIO _interface = null;
        //private string interfaceType = "";

        public CWildcatConsole(iWildcatConsoleIO _interface = null)
        {

            if (this._interface == null)
            {
                string sPipe = Environment.GetEnvironmentVariable("wcdoorpipename");
                if (sPipe != null)
                {
                    _interface = new CWildcatDeviceDoor32();
                    //this.interfaceType = "WCDOOR32";
                }
                else
                {
                    _interface = new CWildcatDeviceCRT32();
                    //this.interfaceType = "WCCRT32";
                }
            }
            this._interface = _interface;

            //set_time_limit($this->GlobalTimeoutSecs);
            this.StartTime = 0; // time();
            string sNode = Environment.GetEnvironmentVariable("WCNODEID");
            if (sNode != null) this.Node = Int32.Parse(sNode);

            if (this._interface.Initialize())
            {
                this.Active = true;
                WildcatLoggedIn(ref this.User);
                this.UserName = User.Info.Name.Trim();
                this.DoorSys = this.ReadDoorSys();
                ColorEnabled = this.DoorSys["DisplayMode"] == "GR";
                //this.InitOutputFilter();
                //this.Flush();
                return; // true;
            }
            //$this->InitOutputFilter();
            Console.Write("Could not initialize door!\n");
            Console.Write("Program must run as a 32-bit door from Wildcat!\n");
            //$this->DelayMS(2000);
            return; // false;
        }

        ~CWildcatConsole()
        {
            if (this.Active)
            {
                this._interface.ShutDown();
            }
        }
        //---------------
        // Public
        //---------------
        public string GetDeviceType() { return this._interface.GetDeviceType(); }
        public void ClearScreen(int v = 2) { this._interface.ClearScreen(v); }
        public int Read(byte[] data, int size = 1024) { return this._interface.Read(data, size); }
        public int CharReady() { return this._interface.CharReady(); }
        public int Peek(byte[] data, int size = 1024) { return this._interface.Peek(data, size); }
        //public int ReadKey() { int ch = this.ReadKey(); return ch; };
        public bool Writeln(string fmt, params object[] v) { return this._interface.Writeln(fmt, v); }

        public bool Write()
        {
            //$a = func_get_args();
            //$format = array_shift($a);
            //$s = vsprintf($format, $a);
            //$s = str_replace("\n","\r\n",$s);
            //return $this->interface->Write(ExpandMacros($s));
            return false;
        }

        public bool Writeln()
        {
            //$a = func_get_args();
            //$format = array_shift($a);
            //$s = vsprintf($format, $a);
            //$s = str_replace("\n","\r\n",$s);
            //return $this->interface->Write(ExpandMacros($s)."\r\n");
            return false;
        }

        public bool DisplayHello(string fn = "wcdoor32-hello.bbs")
        {
            if (fn == null) return false;
            //string sBatchPath = makewild.Bath
            return true;
        }
        Dictionary<string, string> ReadDoorSys(string dropfile = null)
        {
            string[] DoorSysFields = {
                    "Port",                   // Port
                    "Speed",                  // Speed
                    "DataBits",               // Data Bits
                    "Node",                   // Node
                    "DteSpeed",               // Dte Speed
                    "ScreenWrite",            // Screen Write
                    "Printer",                // Printer
                    "Page",                   // P`age
                    "Bell",                   // Bell
                    "Name",                   // Name
                    "From",                   // From
                    "PhoneNumber",            // Phone Number
                    "DataNumber",             // Data Number
                    "Password",               // Password
                    "Profile",                // Profile
                    "Calls",                  // Calls
                    "LastCall",               // Last Call
                    "SecondsRemaining",       // Seconds Remaining
                    "MinutesRemaining",       // Minutes Remaining
                    "DisplayMode",            // Display Mode
                    "LinesPerPage",           // Lines Per Page
                    "ExpertMode",             // Expert Mode
                    "Conferences",            // Conferences
                    "ConferenceNumber",       // Conference Number
                    "ExpireDate",             // Expire Date
                    "UserRefNumber",          // User Ref Number
                    "Protocol",               // Protocol
                    "Uploads",                // Uploads
                    "Downloads",              // Downloads
                    "DownloadKToday",         // Download K Today
                    "MaxDownloadKPerDay",     // Max Download K Per Day
                    "Birthdate",              // Birthdate
                    "UserDatabasePath",       // User Database Path
                    "HomePath",               // Home Path
                    "SysopName",              // Sysop Name
                    "AliasName",              // Alias Name
                    "NextEvent",              // Next Event
                    "ReliableConnect",        // Reliable Connect
                    "AnsiDetected",           // Ansi Detected
                    "Network",                // Network
                    "NoIdea1",                 // No Idea
                    "BankedTime",             // Banked Time
                    "LastNewFiles",           // Last New Files
                    "TimeCalled",             // Time Called
                    "PreviousLogoff",         // Previous Logoff
                    "MaxDownloads",           // Max Downloads
                    "DownloadsToday",         // Downloads Today
                    "TotalUploadK",           // Total Upload K
                    "TotalDownloadK",         // Total Download K
                    "CommentField",           // Comment Field
                    "NoIdea2",                 // No Idea
                    "MessagesWritten"         // Messages Written
                 };

            if (dropfile == null)
            {
                string[] args = Environment.GetCommandLineArgs();
                dropfile = (args.Length > 1) ? args[1] : "";
                Console.WriteLine("dropfile: {0}", dropfile);
            }

            Dictionary<string, string> map = new Dictionary<string, string>();
            if (dropfile != null && File.Exists(dropfile))
            {
                string dsyslines = File.ReadAllText(dropfile);
                string[] sep = { "\r\n" };
                string[] DoorSysValues = dsyslines.Split(sep, DoorSysFields.Length, StringSplitOptions.None);
                for (int i = 0; i < DoorSysFields.Length; i++)
                {
                    map.Add(DoorSysFields[i], DoorSysValues[i].Trim());
                }
            }
            return map;
        }


    } // end of CWildcatConsole

    //------------------------------------------------------------
    // Use this class for pure DOO32 operations
    //------------------------------------------------------------

    public class CWildcatDoor : CWildcatConsole
    {
        public CWildcatDoor() : base()
        {
            if (Environment.GetEnvironmentVariable("wcdoorpipename") == "")
            {
                Console.WriteLine("This class is used for WCDOOR32 mode.");
                Environment.Exit(1);  // die;
            }
        }
    }
    //------------------------------------------------------------
    // Use this class for pure CRT32 local mode operations
    //------------------------------------------------------------

    public class CWildcatLocal : CWildcatConsole
    {
        // Call the parent constructor
        public CWildcatLocal() : base()
        {
            if (Environment.GetEnvironmentVariable("wcdoorpipename") != "")
            {
                Console.WriteLine("This class is used for WCCRT32 mode.");
                Environment.Exit(1);  // die;
            }
        }
    }

} //end of root namespace

