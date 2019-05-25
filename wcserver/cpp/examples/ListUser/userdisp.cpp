//************************************************************************
//*                                                                      *
//*                        -> UserDisplay.cpp <-                         *
//*                                                                      *   
//************************************************************************

#include "stdafx.h"
#include "UserList.h"
#include "UserDisp.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

//************************************************************************

CUserDisplay::CUserDisplay(TUser UserRec, CWnd* pParent) : CDialog(CUserDisplay::IDD, pParent)
    {
	//{{AFX_DATA_INIT(CUserDisplay)
	m_Address1 = _T("");
	m_Address2 = _T("");
	m_City = _T("");
	m_Company = _T("");
	m_From = _T("");
	m_Name = _T("");
	m_Phone = _T("");
	m_RealName = _T("");
	m_Security = _T("");
	m_State = _T("");
	//}}AFX_DATA_INIT

    User = UserRec;
    }

//************************************************************************


void CUserDisplay::DoDataExchange(CDataExchange* pDX)
    {
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CUserDisplay)
	DDX_Text(pDX, IDC_ADDRESS1TXT, m_Address1);
	DDX_Text(pDX, IDC_ADDRESS2TXT, m_Address2);
	DDX_Text(pDX, IDC_CITYTXT, m_City);
	DDX_Text(pDX, IDC_COMPANYTXT, m_Company);
	DDX_Text(pDX, IDC_FROMTXT, m_From);
	DDX_Text(pDX, IDC_NAMETXT, m_Name);
	DDX_Text(pDX, IDC_PHONETXT, m_Phone);
	DDX_Text(pDX, IDC_REALNAMETXT, m_RealName);
	DDX_Text(pDX, IDC_SECURITYTXT, m_Security);
	DDX_Text(pDX, IDC_STATETXT, m_State);
	//}}AFX_DATA_MAP
    }

//************************************************************************


BEGIN_MESSAGE_MAP(CUserDisplay, CDialog)
	//{{AFX_MSG_MAP(CUserDisplay)
	ON_WM_SHOWWINDOW()
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

//************************************************************************

void CUserDisplay::OnShowWindow(BOOL bShow, UINT nStatus) 

// This function will display the Window and copy all of the User variable 
// information into the string for each of the static text boxes.

    {
	CDialog::OnShowWindow(bShow, nStatus);

    m_Name = User.Info.Name;
    m_From = User.From;
    m_Security = User.Security[0];
    m_RealName = User.RealName;
    m_Phone = User.PhoneNumber;
    m_Company = User.Company;
    m_Address1 = User.Address1;
    m_Address2 = User.Address2;
    m_City = User.City;
    m_State = User.State;
    UpdateData(FALSE);
    }

//************************************************************************
