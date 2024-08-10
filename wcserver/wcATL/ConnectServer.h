	
// ConnectServer.h : Declaration of the CConnectServer

#ifndef __CONNECTSERVER_H_
#define __CONNECTSERVER_H_

#include "resource.h"       // main symbols

/////////////////////////////////////////////////////////////////////////////
// CConnectServer
class ATL_NO_VTABLE CConnectServer : 
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CConnectServer, &CLSID_ConnectServer>,
	public IConnectionPointContainerImpl<CConnectServer>,
	public IDispatchImpl<IConnectServer, &IID_IConnectServer, &LIBID_WCATLLib>
{
public:
	CConnectServer()
	{
		m_pUnkMarshaler = NULL;
	}

DECLARE_REGISTRY_RESOURCEID(IDR_CONNECTSERVER)
DECLARE_GET_CONTROLLING_UNKNOWN()

DECLARE_PROTECT_FINAL_CONSTRUCT()

BEGIN_COM_MAP(CConnectServer)
	COM_INTERFACE_ENTRY(IConnectServer)
	COM_INTERFACE_ENTRY(IDispatch)
	COM_INTERFACE_ENTRY(IConnectionPointContainer)
	COM_INTERFACE_ENTRY_AGGREGATE(IID_IMarshal, m_pUnkMarshaler.p)
END_COM_MAP()
BEGIN_CONNECTION_POINT_MAP(CConnectServer)
END_CONNECTION_POINT_MAP()


	HRESULT FinalConstruct()
	{
		return CoCreateFreeThreadedMarshaler(
			GetControllingUnknown(), &m_pUnkMarshaler.p);
	}

	void FinalRelease()
	{
		m_pUnkMarshaler.Release();
	}

	CComPtr<IUnknown> m_pUnkMarshaler;

// IConnectServer
public:
};

#endif //__CONNECTSERVER_H_
