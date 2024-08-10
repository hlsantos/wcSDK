	
// WildcatServer.h : Declaration of the CWildcatServer

#ifndef __WILDCATSERVER_H_
#define __WILDCATSERVER_H_

#include "resource.h"       // main symbols

/////////////////////////////////////////////////////////////////////////////
// CWildcatServer
class ATL_NO_VTABLE CWildcatServer : 
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CWildcatServer, &CLSID_WildcatServer>,
	public IConnectionPointContainerImpl<CWildcatServer>,
	public IDispatchImpl<IWildcatServer, &IID_IWildcatServer, &LIBID_WCATLLib>
{
public:
	CWildcatServer()
	{
		m_pUnkMarshaler = NULL;
	}

DECLARE_REGISTRY_RESOURCEID(IDR_WILDCATSERVER)
DECLARE_GET_CONTROLLING_UNKNOWN()

DECLARE_PROTECT_FINAL_CONSTRUCT()

BEGIN_COM_MAP(CWildcatServer)
	COM_INTERFACE_ENTRY(IWildcatServer)
	COM_INTERFACE_ENTRY(IDispatch)
	COM_INTERFACE_ENTRY(IConnectionPointContainer)
	COM_INTERFACE_ENTRY_AGGREGATE(IID_IMarshal, m_pUnkMarshaler.p)
END_COM_MAP()
BEGIN_CONNECTION_POINT_MAP(CWildcatServer)
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

// IWildcatServer
public:
};

#endif //__WILDCATSERVER_H_
