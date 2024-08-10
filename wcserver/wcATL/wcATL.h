

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 6.00.0361 */
/* at Sun Oct 05 02:20:21 2008
 */
/* Compiler settings for D:\local\wc5\wcsdk\wcserver\wcATL\wcATL.idl:
    Oicf, W1, Zp8, env=Win32 (32b run)
    protocol : dce , ms_ext, c_ext, robust
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
//@@MIDL_FILE_HEADING(  )

#pragma warning( disable: 4049 )  /* more than 64k source lines */


/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 475
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif // __RPCNDR_H_VERSION__

#ifndef COM_NO_WINDOWS_H
#include "windows.h"
#include "ole2.h"
#endif /*COM_NO_WINDOWS_H*/

#ifndef __wcATL_h__
#define __wcATL_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __IConnectServer_FWD_DEFINED__
#define __IConnectServer_FWD_DEFINED__
typedef interface IConnectServer IConnectServer;
#endif 	/* __IConnectServer_FWD_DEFINED__ */


#ifndef ___IConnectServerEvents_FWD_DEFINED__
#define ___IConnectServerEvents_FWD_DEFINED__
typedef interface _IConnectServerEvents _IConnectServerEvents;
#endif 	/* ___IConnectServerEvents_FWD_DEFINED__ */


#ifndef __ConnectServer_FWD_DEFINED__
#define __ConnectServer_FWD_DEFINED__

#ifdef __cplusplus
typedef class ConnectServer ConnectServer;
#else
typedef struct ConnectServer ConnectServer;
#endif /* __cplusplus */

#endif 	/* __ConnectServer_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"

#ifdef __cplusplus
extern "C"{
#endif 

void * __RPC_USER MIDL_user_allocate(size_t);
void __RPC_USER MIDL_user_free( void * ); 

#ifndef __IConnectServer_INTERFACE_DEFINED__
#define __IConnectServer_INTERFACE_DEFINED__

/* interface IConnectServer */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IConnectServer;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("BD252A3F-27C7-4E84-A2E1-F6AB078D6431")
    IConnectServer : public IDispatch
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct IConnectServerVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IConnectServer * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IConnectServer * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IConnectServer * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IConnectServer * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IConnectServer * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IConnectServer * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IConnectServer * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } IConnectServerVtbl;

    interface IConnectServer
    {
        CONST_VTBL struct IConnectServerVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IConnectServer_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IConnectServer_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IConnectServer_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IConnectServer_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IConnectServer_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IConnectServer_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IConnectServer_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IConnectServer_INTERFACE_DEFINED__ */



#ifndef __WCATLLib_LIBRARY_DEFINED__
#define __WCATLLib_LIBRARY_DEFINED__

/* library WCATLLib */
/* [helpstring][version][uuid] */ 


EXTERN_C const IID LIBID_WCATLLib;

#ifndef ___IConnectServerEvents_DISPINTERFACE_DEFINED__
#define ___IConnectServerEvents_DISPINTERFACE_DEFINED__

/* dispinterface _IConnectServerEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__IConnectServerEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("DE087F4E-1AD1-40C1-9086-57F5C56CE26F")
    _IConnectServerEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _IConnectServerEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _IConnectServerEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _IConnectServerEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _IConnectServerEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _IConnectServerEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _IConnectServerEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _IConnectServerEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _IConnectServerEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _IConnectServerEventsVtbl;

    interface _IConnectServerEvents
    {
        CONST_VTBL struct _IConnectServerEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _IConnectServerEvents_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define _IConnectServerEvents_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define _IConnectServerEvents_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define _IConnectServerEvents_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define _IConnectServerEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define _IConnectServerEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define _IConnectServerEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___IConnectServerEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_ConnectServer;

#ifdef __cplusplus

class DECLSPEC_UUID("0D74A3FD-0794-449B-A09F-48B7019B07A0")
ConnectServer;
#endif
#endif /* __WCATLLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


