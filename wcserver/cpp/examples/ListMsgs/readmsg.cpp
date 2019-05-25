//************************************************************************
//*                                                                      *
//*                          -> ReadMsg.cpp <-                           *
//*                                                                      *
//************************************************************************

#include "stdafx.h"
#include "ReadMsg.h"
#include "RMsgDlg.h"

#include "wcServer.h"       // WCSERVER API header include file

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

//************************************************************************

BEGIN_MESSAGE_MAP(CReadMsgApp, CWinApp)
	//{{AFX_MSG_MAP(CReadMsgApp)
		// NOTE - the ClassWizard will add and remove mapping macros here.
		//    DO NOT EDIT what you see in these blocks of generated code!
	//}}AFX_MSG
	ON_COMMAND(ID_HELP, CWinApp::OnHelp)
END_MESSAGE_MAP()

//************************************************************************

CReadMsgApp::CReadMsgApp()
    {
    }

//************************************************************************

CReadMsgApp theApp;

//************************************************************************

BOOL CReadMsgApp::InitInstance()
{
	BOOL    Status;

	Enable3dControls();
	SetDialogBkColor();

	// Connects to a Wildcat Server
	//
	// Note: if the environment string WILDCATSERVER is defined
	//       this will be used as the wildcat! server computer.
	//
	//       To look for a specific Wildcat! Server, use the 
	//       following command instead:
	//
	//       WildcatServerConnectSpecific(NULL,computer_name);
	//

	Status = WildcatServerConnect(NULL);            

	if (Status != FALSE) {
		Status = WildcatServerCreateContext();      // Create Wildcat Server Context Thread
		if (Status != FALSE) {
			Status = LoginSystem();                 // Logs your application into the server
			if (Status != FALSE) {
				CReadMsgDlg dlg;
				m_pMainWnd = &dlg;
				dlg.DoModal();
				LogoutUser();                       // Logs your application out of the server
			}
			WildcatServerDeleteContext();           // Deletes the Wildcat Server Context Thread for your application
		}
	}
	return (FALSE);
}

//************************************************************************
