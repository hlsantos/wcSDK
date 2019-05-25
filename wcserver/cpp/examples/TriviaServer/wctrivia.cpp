//////////////////////////////////////////////////////////////////////////////
// wcTrivia Service
// (c) 1996-2019, Santronics Software, Inc. All rights reserved.
//
// History
// 05/09/2019, v8.0.454.8 ready
//

#include "common.h"
#pragma hdrstop

///////////////////////////////////////////////////////////////////////////////
// CTriviaDialog

class CTriviaDialog: public CDialog {
typedef CDialog inherited;
public:
  CTriviaDialog();
public:
  //{{AFX_DATA(CTriviaDialog)
	enum { IDD = IDD_MAINFRAME };
	CString	Connections;
	CString	IPAddress;
	CString	ServerName;
	//}}AFX_DATA
protected:
  UINT nTimer;
  SOCKET ListenSocket;
  virtual void DoDataExchange(CDataExchange *pDX);
protected:
  //{{AFX_MSG(CTriviaDialog)
	virtual BOOL OnInitDialog();
	afx_msg void OnDestroy();
	afx_msg void OnTimer(UINT nIDEvent);
	//}}AFX_MSG
  DECLARE_MESSAGE_MAP()
};

BEGIN_MESSAGE_MAP(CTriviaDialog, CDialog)
  //{{AFX_MSG_MAP(CTriviaDialog)
	ON_WM_DESTROY()
	ON_WM_TIMER()
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

CTriviaDialog::CTriviaDialog()
 : CDialog(CTriviaDialog::IDD)
{
  //{{AFX_DATA_INIT(CTriviaDialog)
	Connections = _T("");
	IPAddress = _T("");
	ServerName = _T("");
	//}}AFX_DATA_INIT
}

BOOL CTriviaDialog::OnInitDialog()
{
  WSAData wsdata;
  if (WSAStartup(0x101, &wsdata) != 0) {
    MessageBox("Unable to initialize WinSock.", "Wildcat! Trivia Service", MB_OK | MB_ICONHAND);
    PostMessage(WM_COMMAND, IDCANCEL);
    return FALSE;
  }

  DataFile.CreateFile("WCTRIVIA.DAT", GENERIC_READ, FILE_SHARE_READ, OPEN_EXISTING);
  if (!DataFile.IsOk()) {
    MessageBox("Unable to open wcTrivia.dat", "Wildcat! Trivia Service", MB_OK | MB_ICONHAND);
    PostMessage(WM_COMMAND, IDCANCEL);
    return FALSE;
  }
  InitializeCriticalSection(&DataFileMutex);

  nTimer = SetTimer(1, 1000, NULL);

  //
  // Create a listening socket server
  //

  SOCKADDR_IN sin;
  ListenSocket = socket(AF_INET, SOCK_STREAM, 0);
  ZeroMemory(&sin, sizeof(sin));
  sin.sin_family = PF_INET;
  sin.sin_addr.s_addr = INADDR_ANY;
  sin.sin_port = 0;
  bind(ListenSocket, (sockaddr*)&sin, sizeof(sin));
  int sinlen = sizeof(sin);
  getsockname(ListenSocket, (sockaddr*)&sin, &sinlen);

  //
  // Get connected Wildcat! Server and register this TCP service
  // by preparing the TWildcatService structure and calling
  // RegisterService()
  //

  char computername[SIZE_COMPUTER_NAME];
  if (GetConnectedServer(computername, sizeof(computername))) {
    TWildcatService service;
    ZeroMemory(&service, sizeof(service));
    strcpy(service.Name,   "wcTrivia Service");
    strcpy(service.Vendor, "Santronics Software, Inc.");
    service.Version = WCTRIVIA_VERSION;
    service.Port = ntohs(sin.sin_port);
    RegisterService(service);
    ServerName = computername;
    IPAddress.Format("%s:%d", inet_ntoa(*(in_addr*)&service.Address), ntohs(sin.sin_port));
  } else {
    ServerName = "<None>";
    IPAddress.Format("port %d", ntohs(sin.sin_port));
  }

  //
  // Spawn the listening thread server!

  _beginthread(ListenThread, 0, (void*)ListenSocket);
  return inherited::OnInitDialog();
}

void CTriviaDialog::DoDataExchange(CDataExchange *pDX)
{
  inherited::DoDataExchange(pDX);
  //{{AFX_DATA_MAP(CTriviaDialog)
	DDX_Text(pDX, IDC_CONNECTIONS, Connections);
	DDX_Text(pDX, IDC_IPADDRESS, IPAddress);
	DDX_Text(pDX, IDC_SERVERNAME, ServerName);
	//}}AFX_DATA_MAP
}

void CTriviaDialog::OnTimer(UINT nIDEvent)
{
  UpdateData(TRUE);
  Connections.Format("%d", ActiveConnections);
  UpdateData(FALSE);
  inherited::OnTimer(nIDEvent);
}

void CTriviaDialog::OnDestroy()
{
  KillTimer(nTimer);
  SOCKET s = InterlockedExchange((long*)&ListenSocket, INVALID_SOCKET);
  if (s != INVALID_SOCKET) {
    closesocket(s);
  }
  WSACleanup();
  if (DataFile.IsOk()) {
    DataFile.CloseHandle();
  }
  DeleteCriticalSection(&DataFileMutex);
	inherited::OnDestroy();
}

///////////////////////////////////////////////////////////////////////////////
// CTriviaService

class CTriviaService: public CWinApp {
protected:
  virtual BOOL InitInstance();
};

CTriviaService theApp;

BOOL CTriviaService::InitInstance()
{
  if (!WildcatServerConnect(NULL) || !WildcatServerCreateContext()) {
    MessageBox(NULL, "Could not connect to Wildcat! Server.", "Warning", MB_ICONEXCLAMATION | MB_OK);
    return FALSE;
  }
  CTriviaDialog().DoModal();
  WildcatServerDeleteContext();
  return FALSE;
}
