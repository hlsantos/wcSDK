﻿//***********************************************************************
// (c) Copyright 1998-2020 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
// File Name : wcDoor32-Example2
// Subsystem : wcSDK .NET C# 
// Date      : 05/10/20
// Version   : 8.0.454.10
// Author    : HLS/SSI
//
// Revision History:
// Build    Date      Author  Comments
// -----    --------  ------  -------------------------------------------
// 454.10   05/10/20  HLS     wcDoor32 Example #2
//***********************************************************************

using System;
using System.Runtime.InteropServices;
using System.Text;
using wcSDK;

#if DEBUG
using System.Collections;
using System.Collections.Generic;
#endif

namespace wcDoor32_example2
{
    class Program
    {
        public static int StartDoor()
        {
            Console.WriteLine("* Starting wcDOOR32.Net CWildcatDoor Example #2**");

            CWildcatDoor door = new CWildcatDoor();

            Console.WriteLine("door.GetDeviceType(): {0}", door.GetDeviceType());
            Console.WriteLine("Node: {0}", door.Node);
            Console.WriteLine("UserName: {0}", door.UserName);
            Console.WriteLine("User.from: {0}", door.User.From);

            door.SetGlobalTimeout(0);  // turn off timeout
            door.PrepareCallBack();    // Allow for disconnect events to be captured.

            wcServerAPI.SetNodeActivity("wcDoor32.Net Example2!");
            door.ClearScreen();
            door.Write(1, 1, "@H@Welcome to WcDoor32.Net Example #2, '{0}'.@N@", door.User.Info.Name);
            door.CursorSave();
            door.Write(1, 3, "@B@User        : @A@{0}", door.UserName);
            door.Write(1, 4, "@B@Login Node  : @A@{0}", door.Node);
            door.Write(1, 5, "@B@Door Node   : @A@{0}", wcServerAPI.GetNode());
            door.Write(1, 7, "@E@Press / to quit:@N@");
            door.Writeln();
            door.CursorRestore();
            door.Writeln("expected to be at line 2 after CursorRestore()");

            #region Primitive Dumb Terminal

            //------------------------------------------------------------
            // Primitive Dumb Terminal
            //------------------------------------------------------------

            int Active = 2;           // When 1 pending idle timeout, when 0 exit
            int idleTimeout = 60 * 1; // seconds

            while (Active != 0)
            {
                switch (door.Event(idleTimeout * 1000))
                {
                    case wcDoor32API.WCDOOR_EVENT_KEYBOARD:
                        Active = 2;
                        byte[] data = new byte[4];
                        int rd = door.Read(ref data, data.Length);
                        if (rd == 0) continue;

#if DEBUG
                        string mykey = "";
                        string mykeystr = "";
                        for (int i = 0; i < rd; i++)
                        {
                            byte c = data[i];
                            Console.WriteLine(
                                "{0} ch:| '{1}' {2,3} (0x{3:X}) | '{4}' {5,3} (0x{6:X} <- {7} | {8} | rd: {9}",
                                "-",
                                (c < 32) ? ' ' : (char)c, c, c,
                                (c < 32) ? ' ' : (char)c, c, c,
                                mykey,
                                mykeystr,
                                rd
                             );
                        }
#endif

                        // -------------------------------------
                        // Check first byte for escape/exit key
                        byte ch = data[0];
                        if (ch == '/') { Active = 0; break; }
                        //if (ch == wcConsoleAPI.KEY_ESCAPE) { Active = 0; break; }
                        // -------------------------------------

                        // IBM Keyboard Scan Codes will come from a wcBASIC 
                        // login to run the door.
                        if (ch == 0)
                        {
                            if (rd == 1)
                            {
                                ch = (byte)door.ReadKey();  // need to read extra key
                            }
                            else if (rd == 2) ch = data[1];

                            switch (ch)
                            {
                                case (byte)'H': door.CursorUp(); break;
                                case (byte)'P': door.CursorDown(); break;
                                case (byte)'K': door.CursorLeft(); break;
                                case (byte)'M': door.CursorRight(); break;
                            }
                            continue;
                        }

                        if (!door.Write(data, rd))
                        {
                            Console.WriteLine("!!!!ERROR writing data!");
                        }
                        if (ch == wcConsoleAPI.KEY_CR)
                        {
                            data[0] = (byte)wcConsoleAPI.KEY_LF;
                            door.Write(data, 1);
                        }
                        break;

                    case wcDoor32API.WCDOOR_EVENT_OFFLINE:
                        door.Write("\r\n** FORCE DISCONNECT **\r\n");
                        Console.WriteLine("** WCDOOR_EVENT_OFFLINE - GOODBYE **");
                        Active = 0;
                        break;

                    case wcDoor32API.WCDOOR_EVENT_TIMEOUT:
                        Active--;
                        switch (Active)
                        {
                            case 0:
                                door.Write("\r\n** IDLE TIMEOUT - GOODBYE **\r\n");
                                break;
                            case 1:
                                door.Write("\r\n** IDLE TIMEOUT IN {0} SECONDS **\r\n", idleTimeout);
                                break;
                        }
                        break;

                    case wcDoor32API.WCDOOR_EVENT_FAILED:
                        Console.WriteLine("** WCDOOR_EVENT_FAILED - GOODBYE **");
                        Active = 0;
                        break;
                }
            }
            #endregion

            door.Writeln("\r\n\r\nReturning to bbs...");
            door.Flush();
            return 0;
        }

        static void Main(string[] args)
        {
#if DEBUG
            // Use this to Attach Process for debugger
            //Console.Write("<pause START>"); Console.ReadKey();
#endif
            StartDoor();
#if DEBUG
            //Console.Write("<pause END>"); Console.ReadKey();
#endif
        }


    }
}
