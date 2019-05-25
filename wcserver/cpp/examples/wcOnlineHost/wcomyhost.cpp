//***********************************************************************
// (c) Copyright 1998-2008 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : wcoMyHost.cpp
// Subsystem : wcOnline Hosting Module
// Date      : 10/02/2008
// Version   : v6.3.452.6
// Author    : HLS/SSI
//
// Revision History:
// Build    Date      Author  Comments
// -----    --------  ------  -------------------------------------------
//***********************************************************************

#include "common.h"
#pragma hdrstop

//----------------------------------------------------------------------
// Your WcOnline Host Interface
//----------------------------------------------------------------------

#define MODSERVICE  "MYHOST"     // Name of your Hoist
#include "WconlineModule.h"      // WcOnline Registration
#include "WcServer.h"            // WcSDK API

class myWcOnlineModule: public WconlineModule {
public:
   myWcOnlineModule() : StatusManager(NULL) {}
public:
   virtual BOOL Initialize(TLineStatusManager *sm);
   virtual BOOL StartServer(const char *server);
   virtual BOOL DisableServer(const char *server);
   virtual BOOL StopServer(const char *server);
   virtual BOOL Shutdown();
protected:

//public:
   TLineStatusManager   *StatusManager;
   TMakewild            Makewild;
   char                 LocalDomain[MAX_PATH];
} Module;

#include "WildcatModuleProtocol.h"

//----------------------------------------------------------------------
// Your Service Implementation
//----------------------------------------------------------------------

//#define USE_WCCONTEXT_FOR_LISTEN

SOCKET   ListenSocket               = 0;
HANDLE   ListenThread               = 0;


DWORD CALLBACK DoListenThread(void *up)
{
    ListenSocket = 1;

#ifdef USE_WCCONTEXT_FOR_LISTEN
    if (!WildcatServerCreateContext()) {
        ListenSocket = 0;
        return 1;
    }

    if (!LoginSystem()) {
        ListenSocket = 0;
        WildcatServerDeleteContext();
        return 1;
    }
#endif

    //
    // Begin Thread Loop
    //

    DWORD nBeats = 0;
    SetEvent(up);
    while (1) {
        Sleep(1000);
        if (ListenSocket) {
            // do something here
            char sz[255];
            sprintf(sz,"- MyHost: %d\n",nBeats++);
            OutputDebugString(sz);
        } else {
            // stopping server
            break;
        }
    } // while

#ifdef USE_WCCONTEXT_FOR_LISTEN
    WildcatServerDeleteContext();
#endif

    return 0;
}

//-----------------------------------------------------------
// Initialize()
//
// This is called one time only to initialize the DLL.  Good
// place to read any globals.  This is where you will
// call StartServer() to create/begin a "listening" thread.
//-----------------------------------------------------------

BOOL myWcOnlineModule::Initialize(TLineStatusManager *sm)
{
    OutputDebugString("* myWcOnlineModule::Initialize()\n");
    StatusManager = sm;          // MUST BE DONE
    GetMakewild(Makewild);
    strcpy(LocalDomain, Makewild.DomainName);
    return StartServer(MODSERVICE);
}

//-----------------------------------------------------------
// StartServer()
//
// This is called by Initialize() the first time, subsequently
// by sending a SERVERSTATE_UP event using WriteChannel:
//
//   TServerState ss  < - get the current state
//   WriteChannel(SystemControlServerChannel,
//                ss.OwnerId,
//                SERVERSTATE_UP,
//                ss.Port,
//                strlen(ss.Port)+1);
//
// By writing to the event, the event propagates from the server
// to wcONLINE who will call this StartServer() function where
// it will finally call:
//
//   SetServerState(servername,SERVERSTATE_UP);
//
// Note: Any client applcation can call this function. The
//       difference by not issueing an event, is that this
//       StartServer() will not be called.  So from the
//       Wildcat! Server point of view, it is UP, but the
//       DLL itself might have missed on startup initializion.
//
//       In short, clients should use the channel events.
//
//-----------------------------------------------------------

BOOL myWcOnlineModule::StartServer(const char *server)
{

    OutputDebugString("* myWcOnlineModule::StartServer()\n");
    if (_stricmp(server, MODSERVICE) != 0) {
        return false;
    }

    GetMakewild(Makewild);
    strcpy(LocalDomain, Makewild.DomainName);

    if (ListenThread) {
        SetServerState(server, SERVERSTATE_UP);
        return true;
    }

    SetServerState(server, SERVERSTATE_DOWN);

    HANDLE up = CreateEvent(NULL, TRUE, FALSE, NULL);
    DWORD tid   = 0;
    DWORD flags = 0;       // CREATE_SUSPENDED;
    ListenThread = CreateThread(NULL, 0, DoListenThread, up, flags, &tid);
    HANDLE a[2];
    a[0] = ListenThread;
    a[1] = up;

    if (flags == CREATE_SUSPENDED) {
        GrantThreadAccess(tid);
        ResumeThread(ListenThread);
    }

    // Wait until DoListenThread() thread is ready
    // when the "up" event must be set.

    WaitForMultipleObjects(2, a, FALSE, INFINITE);

    if (WaitForSingleObject(up, 0) == WAIT_OBJECT_0) {
        SetServerState(server, SERVERSTATE_UP);
    } else {
        StopServer(server);
    }
    CloseHandle(up);

    return true;
}

//-----------------------------------------------------------
// DisableServer()
//
// This called by sending a SERVERSTATE_REFUSE event using
// WriteChannel:
//
//   TServerState ss  < - get the current state
//   WriteChannel(SystemControlServerChannel,
//                ss.OwnerId,
//                SERVERSTATE_REFUSE,
//                ss.Port,
//                strlen(ss.Port)+1);
//
// By writing to the event, the event propagates from the server
// to wcONLINE who will call this DisableServer() function where
// it will finally call:
//
//   SetServerState(servername,SERVERSTATE_REFUSE);
//
// Note: Any client applcation can call this function. The
//       difference by not issueing an event, is that this
//       DisableServer() will not be called.  So from the
//       Wildcat! Server point of view, it is in a REFUSE state,
//       but the  DLL itself might have missed on any temporary
//       blocks or locks.
//
//       In short, clients should use the channel events.
//
//-----------------------------------------------------------

BOOL myWcOnlineModule::DisableServer(const char *server)
{
    OutputDebugString("* myWcOnlineModule::DisableServer()\n");
    if (_stricmp(server, MODSERVICE) != 0) {
        return false;
    }
    if (!ListenThread) {
        return false;
    }
    SetServerState(server, SERVERSTATE_REFUSE);
    return true;
}

//-----------------------------------------------------------
// StopServer()
//
// This called by sending a SERVERSTATE_DOWN event using
// WriteChannel:
//
//   TServerState ss  < - get the current state
//   WriteChannel(SystemControlServerChannel,
//                ss.OwnerId,
//                SERVERSTATE_DOWN,
//                ss.Port,
//                strlen(ss.Port)+1);
//
// By writing to the event, the event propagates from the server
// to wcONLINE who will call this StopServer() function where
// it will finally call:
//
//   SetServerState(servername,SERVERSTATE_DOWN);
//
// Note: Any client applcation can call this function. The
//       difference by not issueing an event, is that this
//       StopServer() will not be called.  So from the
//       Wildcat! Server point of view, it is in a DOWN state,
//       but the  DLL itself might have missed on any cleanup.
//
//       In short, clients should use the channel events.
//
//-----------------------------------------------------------

BOOL myWcOnlineModule::StopServer(const char *server)
{
    OutputDebugString("* myWcOnlineModule::StopServer()\n");
    if (_stricmp(server, MODSERVICE) != 0) {
        return false;
    }
    if (ListenSocket) {
        OutputDebugString("- setting ListenSocket to zero\n");
        //SOCKET s = InterlockedExchange((long *)&ListenSocket, 0);
        //closesocket(s);
        ListenSocket = 0;
    }

    if (ListenThread) {
        OutputDebugString("- waiting for ListenThread to exit\n");
        if (WaitForSingleObject(ListenThread, 5000) != WAIT_OBJECT_0) {
            TerminateThread(ListenThread, 0);
            Beep(3000, 200);
        }
        OutputDebugString("- closing ListenThread handle\n");
        CloseHandle(ListenThread);
        ListenThread = 0;
    }

    SetServerState(server, SERVERSTATE_DOWN);
    return true;
}

//-----------------------------------------------------------
// ShutDown()
//
// This called by sending a SERVERSTATE_OFFLINE event using
// WriteChannel:
//
//   TServerState ss  < - get the current state
//   WriteChannel(SystemControlServerChannel,
//                ss.OwnerId,
//                SERVERSTATE_OFFINE,
//                ss.Port,
//                strlen(ss.Port)+1);
//
// By writing to the event, the event propagates from the server
// to wcONLINE who will call this ShutDown() function where
// it will finally call:
//
//   SetServerState(servername,SERVERSTATE_DOWN);
//
// Note: Any client applcation can call this function. The
//       difference by not issueing an event, is that this
//       ShutDown() will not be called.  So from the
//       Wildcat! Server point of view, it is in a OFFLINE state,
//       but the  DLL itself might have missed on any cleanup.
//
//       In short, clients should use the channel events.
//
//-----------------------------------------------------------

BOOL myWcOnlineModule::Shutdown()
{
    OutputDebugString("* myWcOnlineModule::ShutDown()\n");
    return StopServer(MODSERVICE);
}



BOOL WINAPI DllMain(HINSTANCE hinstDLL, DWORD dwReason, LPVOID /*lpvReserved*/)
{
    switch (dwReason) {
    case DLL_PROCESS_ATTACH:
        if (!DisableThreadLibraryCalls(hinstDLL)) {
            ASSERT(0);
        }
        WSADATA wd;
        return WSAStartup(MAKEWORD(1, 1), &wd) == 0;
    case DLL_THREAD_ATTACH:
        break;
    case DLL_THREAD_DETACH:
        break;
    case DLL_PROCESS_DETACH:
        WSACleanup();
        break;
    }
    return TRUE;
}
