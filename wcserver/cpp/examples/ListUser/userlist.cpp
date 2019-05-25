//************************************************************************
//*                                                                      *
//*                         -> UserList.cpp <-                           *
//*                                                                      *
//************************************************************************

#include "stdafx.h"
#include "UserList.h"
#include "UListDlg.h"

#include "wcType.h"             // wc5 Type header include file
#include "wcServer.h"           // wc5 Server header include file

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

//************************************************************************

BEGIN_MESSAGE_MAP(CUserListApp, CWinApp)
	//{{AFX_MSG_MAP(CUserListApp)
		// NOTE - the ClassWizard will add and remove mapping macros here.
		//    DO NOT EDIT what you see in these blocks of generated code!
	//}}AFX_MSG
	ON_COMMAND(ID_HELP, CWinApp::OnHelp)
END_MESSAGE_MAP()

//************************************************************************

CUserListApp::CUserListApp()
    {
	// TODO: add construction code here,
	// Place all significant initialization in InitInstance
    }

//************************************************************************

CUserListApp theApp;

//************************************************************************

BOOL CUserListApp::InitInstance()
    {
    BOOL    Status;

	Enable3dControls();
    SetDialogBkColor();

    Status = WildcatServerConnect(NULL);        // Connects to a Wildcat Server
    if (Status != FALSE)
        {
        Status = WildcatServerCreateContext();  // Create Wildcat Server Context Thread
        if (Status != FALSE)
            {
            Status = LoginSystem();             // Logs your application into the server
            if (Status != FALSE)
                {
            	CUserListDlg dlg;
	            m_pMainWnd = &dlg;
                dlg.DoModal();

                LogoutUser();                   // Logs your application out of the server
                }
            WildcatServerDeleteContext();       // Deletes the Wildcat Server Context Thread for your application
            }
        }

	return (FALSE);
    }

//************************************************************************
