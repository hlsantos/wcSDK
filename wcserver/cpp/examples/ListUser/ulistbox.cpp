//************************************************************************
//*                                                                      *
//*                       -> UserListBox.cpp <-                          *
//*                                                                      *   
//************************************************************************

#include "stdafx.h"
#include "UserList.h"
#include "UListBox.h"
#include "UserDisp.h"

#include "wcType.h"             // wc5 Type header include file
#include "wcServer.h"           // wc5 Server header include file

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

//************************************************************************

#define NOT !
#define AND &&
#define OR  ||

//************************************************************************

CUserListBox::CUserListBox(CWnd* pParent) : CDialog(CUserListBox::IDD, pParent)
    {
	//{{AFX_DATA_INIT(CUserListBox)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
    }

//************************************************************************

void CUserListBox::DoDataExchange(CDataExchange* pDX)
    {
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CUserListBox)
	DDX_Control(pDX, IDC_USERLIST, m_UserList);
	//}}AFX_DATA_MAP
    }

//************************************************************************

BEGIN_MESSAGE_MAP(CUserListBox, CDialog)
	//{{AFX_MSG_MAP(CUserListBox)
	ON_WM_SHOWWINDOW()
	ON_LBN_DBLCLK(IDC_USERLIST, OnDblclkUserlist)
	ON_BN_CLICKED(IDDISPLAY, OnDisplay)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

//************************************************************************

void CUserListBox::OnShowWindow(BOOL bShow, UINT nStatus) 

// This function will show the Window and Load the User names from the 
// Wildcat user database.

    {
	CDialog::OnShowWindow(bShow, nStatus);
    LoadUsers();
    }

//************************************************************************

void CUserListBox::OnDblclkUserlist() 

// This function will handle when the user double clicks on a user name in the 
// listbox and will call the OnDisplay() function to display the users information.

    {
    OnDisplay();
    }

//************************************************************************

void CUserListBox::OnDisplay() 

// This function will find out which user is selected in the listbox and 
// display the user record information in a window.

    {
    int     Selection;
    TUser   User;
    DWORD   UserID;
    CString UserName;

    Selection = m_UserList.GetCurSel();
    if (Selection != LB_ERR)
        {
        m_UserList.GetText(Selection, UserName);
        if (strlen(UserName) > 0)
            {
            if (GetUserByName(UserName, User, UserID) == TRUE)  // Get User By Name from User database
                {
                CUserDisplay dlg(User);
                dlg.DoModal();
                }
            }
        }
    }

//************************************************************************

BOOL CUserListBox::LoadUsers(void)

// This function will load the users from the Wildcat user database into the 
// listbox.  If this function fails it will return a status of FALSE.

    {
    BOOL    Status = FALSE,
            Done = FALSE;
    TUser   User;
    DWORD   UserID;

    if (GetFirstUser(UserLastNameKey, User, UserID) == TRUE)    // Get First User by Lant Name Key
        {
        m_UserList.AddString(User.Info.Name);

        while (NOT Done)
            {
            if (GetNextUser(UserLastNameKey, User, UserID) == TRUE) // Get Next User in database by 
                m_UserList.AddString(User.Info.Name);               // Last Name Key
            else
                Done = TRUE;    
            }

        Status = TRUE;
        }

    return (Status);
    }

//************************************************************************
