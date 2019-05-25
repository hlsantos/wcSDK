//************************************************************************
//*                                                                      *
//*                        -> ConfListBox.cpp <-                         *
//*                                                                      *
//************************************************************************

#include "stdafx.h"
#include "ReadMsg.h"
#include "CListBox.h"

#include "wcType.h"                 // wc5 Type header include file
#include "wcServer.h"               // wc5 Server header include file

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif
//************************************************************************

CConfListBox::CConfListBox(CWnd* pParent) : CDialog(CConfListBox::IDD, pParent)
    {
	//{{AFX_DATA_INIT(CConfListBox)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
    }

//************************************************************************

void CConfListBox::DoDataExchange(CDataExchange* pDX)
    {
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CConfListBox)
	DDX_Control(pDX, IDC_CONFLIST, m_ConfList);
	//}}AFX_DATA_MAP
    }

//************************************************************************

BEGIN_MESSAGE_MAP(CConfListBox, CDialog)
	//{{AFX_MSG_MAP(CConfListBox)
	ON_LBN_DBLCLK(IDC_CONFLIST, OnDblclkConflist)
	ON_WM_SHOWWINDOW()
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

//************************************************************************

void CConfListBox::OnDblclkConflist() 
    {
    OnOK();
    }

//************************************************************************

void CConfListBox::OnShowWindow(BOOL bShow, UINT nStatus) 

// This function will display with Dialog Box window and also load the conferences
// into the ListBox.

    {
    TConfDesc   ConfDesc;       // Confernece Description structure
    DWORD       Counter = 0,
                Items;
    CString     str;
    char        ConfNum[20];

	CDialog::OnShowWindow(bShow, nStatus);
    
    Items = GetConferenceCount();       // Get the number of conferneces
    while (Counter <= Items)
        {
        if (GetConfDesc(Counter, ConfDesc) == TRUE) // Get the conference information
            {
            if (strlen(ConfDesc.Name) > 0)      // Check to see if there is a name for this conference
                {
                wsprintf(ConfNum, "%d", Counter);
                str = CString(ConfNum) + "  -  " + CString(ConfDesc.Name);
                m_ConfList.AddString(str);
                }
            }
        Counter++;
        }
    }

//************************************************************************

void CConfListBox::OnOK() 

// When the user make his/her selection of the item in the List Box this function
// is called to find out what selection they made and to return the conference number.

    {
    int Selection,
        Pos;
    CString TmpStr,
            NumStr;

	CDialog::OnOK();

    Selection = m_ConfList.GetCurSel();
    if (Selection != LB_ERR)
        {
        m_ConfList.GetText(Selection, TmpStr);
        Pos = TmpStr.Find('-');
        NumStr = TmpStr.Left(Pos - 1);
        ConferenceNumber = (DWORD)atol(NumStr);
        }
    }

//************************************************************************
