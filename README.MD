Wildcat! SDK/API
(c) Copyright 1998-2020 Santronics Software, Inc. All Rights Reserved.

Version   : 8.0
Build     : 454.10 (beta)
Date      : 05/16/20 01:46 am

WCSDK Website: http://www.winserver.com/public/wcsdk

------
About:
------

WINSERVER - Wildcat! Interactive Net Server or Wildcat! for short, is an
advanced  RPC client/server hosting platform. The client API to the
server is available for the following languages:

    - Microsoft C/C++
    - Microsoft .Net Languages,
      - C#
      - VB.NET
      - Managed C++
      - COM/ATL
    - wcBASIC
    - PHP
    - Java
    - Delphi
    - VB

Legacy Languages: Obsolete and is no longer supported.

    - Microsoft C/C++ v4.0 for 16 bit.
    - Visual Fox Pro
    - Delphi 16 bit.

-------------------
32 vs 64 bit Notes:
-------------------

- Wildcat! originated as a pure 32bit client/server system.  Starting with
  v8.0, a 64 bit server is available along with 64 bit client side tools.
  All client-side modules related to hosting and running WCX applications
  remain in 32 bit only until 32 bit inline asm is replaced for 64bit op
  code processing.

- Any .Net application written in VB.NET or C# much be compiled to target
  32 bit or Any CPU since the imported *.dll are 32 bit.


------------------
Future Projects:
------------------

- Create .Net DLL library to target 64 bit.

- Provide projects using other compilers such as the community edition
  of Visual Studio..

-----------------
Revision History:
-----------------

Build    Date      Author  Comments
-----    --------  ------  -------------------------------------------
454.8    04/29/19  SSI     - Start of V8.0
454.10   04/24/20  SSI     - Add c#A wcDoor32.cs include file
                           - WinserveAPI.dll includes the name spaces:
                             wcSDK.wcServerAPI
                             wcSDK.wcDoor32API

         05/16/20  SSI     - Updated the wcDoor32 API for c#
                           - Updated the pwe trivia door examples.
-----    --------  ------  -------------------------------------------
