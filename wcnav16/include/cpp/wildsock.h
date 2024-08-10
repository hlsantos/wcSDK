/* wildsock.h */

#ifndef _WILDSOCK_H
#define _WILDSOCK_H

#define VSOCK_PUMP_BUFFER_SIZE 10240 // HLS 448.1

#ifndef _WINSOCKAPI_
#define _WINSOCKAPI_ 
#if defined(_DEBUG) && defined(WIN32)
#include <afx.h>
#include <winsock.h>
#define new DEBUG_NEW
#else
#include <windows.h>
#endif
#undef _WINSOCKAPI_
#else
#if defined(_DEBUG) && defined(WIN32)
#include <afx.h>
#include <winsock.h>
#define new DEBUG_NEW
#else
#include <windows.h>
#endif
#endif

#ifndef WIN32
#define SOCKAPI _far _pascal
#define SOCKAPI2 _far _pascal 
#define EXPORT32
#else
#define SOCKAPI	__stdcall
#define SOCKAPI2 __stdcall	
#define _export
#define EXPORT32 _declspec(dllexport)
//#undef PASCAL
//#define PASCAL
//#undef FAR
//#define FAR
#endif

#if defined(WIN32) && defined(WILDSOCK)
#include "winsockx.h"
#else
#include <winsock.h>
#endif

#ifndef MAKEWORD
#define MAKEWORD(a, b)      ((WORD)(((BYTE)(a)) | ((WORD)((BYTE)(b))) << 8))
#endif

#define WCPORT_GUI  1
#define WCPORT_HTTP 80

#undef AF_MAX

#define AF_WILDCAT 	18
#define AF_MAX 		19

/*
 * Socket address, wildcat style (looks just like sockaddr_in doesn't it?)
 */
struct sockaddr_wc {
        short   swc_family;
        u_short swc_port;
        struct  in_addr swc_addr;
        char    sin_zero[8];
};

#define SO_WC_DISABLETIMERRESET 0x6001    /* turn off the idle timer reset, activity on this socket is not */
                                          /* counted toward timeout calculation                            */

#define SO_WC_PRIORITY          0x6002    /* priority of this socket, valid between 0 and 7                */
                                          /* lower numbers are HIGHER priority                             */
                                          /* can set a socket to a lower priority (higher number) than its */
                                          /* current priority, but not the other way around due to         */
                                          /* complications in the packet buffering code                    */

#define WC_VENDOR_INFO_SIGNATURE 0x43575057

struct wc_vendor_info {
  DWORD Signature;
  BOOL LoadRealWinsock;
};

#ifdef __cplusplus
extern "C" {
#endif

#ifdef WIN32
typedef BOOL (*SocketCallback)(SOCKET s, WORD event, WORD error, DWORD userdata);
#else 
typedef BOOL (CALLBACK _export * SocketCallback)(SOCKET s, WORD event, WORD error, DWORD userdata);
#endif

EXPORT32 int SOCKAPI WSASetCallback(SOCKET s, SocketCallback cb, DWORD data, long lEvent);

EXPORT32 void * SOCKAPI WildStatGetSocket(int nSocket);
EXPORT32 int SOCKAPI WildStatGetNumSockets();

#ifdef __cplusplus
}
#endif

#endif
