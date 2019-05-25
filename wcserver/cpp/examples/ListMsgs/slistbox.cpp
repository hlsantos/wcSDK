//************************************************************************
//*                                                                      *
//*                          -> SecListBox.cpp <-                        *
//*                                                                      *   
//************************************************************************

#include "stdafx.h"
#include "SecList.h"
#include "SListBox.h"

#include "wcType.h"         // wc5 Type header include file
#include "wcServer.h"       // wc5 Server header include file

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

//************************************************************************

CSecListBox::CSecListBox(CWnd* pParent)	: CDialog(CSecListBox::IDD, pParent)
    {
	//{{AFX_DATA_INIT(CSecListBox)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
    }

//************************************************************************

void CSecListBox::DoDataExchange(CDataExchange* pDX)
    {
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CSecListBox)
	DDX_Control(pDX, IDC_DESELECTALL, m_DeselectButton);
	DDX_Control(pDX, IDC_TOGGLE, m_ToggleButton);
	DDX_Control(pDX, ID_SECLIST, m_SecList);
	//}}AFX_DATA_MAP
    }

//************************************************************************

BEGIN_MESSAGE_MAP(CSecListBox, CDialog)
	//{{AFX_MSG_MAP(CSecListBox)
	ON_WM_DRAWITEM()
	ON_WM_MEASUREITEM()
	ON_WM_SHOWWINDOW()
	ON_LBN_DBLCLK(ID_SECLIST, OnDblclkSeclist)
	ON_BN_CLICKED(IDC_DESELECTALL, OnDeselectall)
	ON_BN_CLICKED(IDC_SELECTALL, OnSelectall)
	ON_BN_CLICKED(IDC_TOGGLE, OnToggle)
	ON_LBN_SELCHANGE(ID_SECLIST, OnSelchangeSeclist)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

//************************************************************************

void CSecListBox::OnDrawItem(int nIDCtl, LPDRAWITEMSTRUCT lpDrawItemStruct) 
    {
	CDialog::OnDrawItem(nIDCtl, lpDrawItemStruct);
    }

//************************************************************************

void CSecListBox::OnMeasureItem(int nIDCtl, LPMEASUREITEMSTRUCT lpMeasureItemStruct) 
    {
	CDialog::OnMeasureItem(nIDCtl, lpMeasureItemStruct);
    }

//************************************************************************

void CSecListBox::OnShowWindow(BOOL bShow, UINT nStatus) 
    {
	CDialog::OnShowWindow(bShow, nStatus);
    LoadSecLevels();
    m_ToggleButton.EnableWindow(FALSE);
    m_DeselectButton.EnableWindow(FALSE);
    }

//************************************************************************

void CSecListBox::OnDblclkSeclist() 

// This function will toggle the state of the check box when you double check
// on an item in the ListBox.

    {
    int Selection,
        CheckState;

    Selection = m_SecList.GetCurSel();
    if (Selection != LB_ERR)
        {
        CheckState = m_SecList.GetCheck(Selection);
        switch (CheckState)
            {
            case 0:
                CheckState = 1;
                break;

            case 1:
                CheckState = 0;
                break;
            }

        m_SecList.SetCheck(Selection, CheckState);
        m_SecList.SetSel(Selection, FALSE);
        OnSelchangeSeclist();
        }
    }

//************************************************************************

void CSecListBox::OnDeselectall() 

// This function will De-Select all items in the listbox.

    {
    int Counter = 0,
        Items;

    Items = m_SecList.GetCount();
    if (Items != LB_ERR)
        {
        while (Counter < Items)
            m_SecList.SetSel(Counter++, FALSE);

        OnSelchangeSeclist();
        }
    }

//************************************************************************

void CSecListBox::OnSelectall() 

// This function will Select all items in the listbox.

    {
    int Counter = 0,
        Items;

    Items = m_SecList.GetCount();
    if (Items != LB_ERR)
        {
        while (Counter < Items)
            m_SecList.SetSel(Counter++, TRUE);

        OnSelchangeSeclist();
        }
    }

//************************************************************************

void CSecListBox::OnToggle() 

// This function toggles the state of all selected check listbox items. 
// (ie: If the checkbox is checked then it will be unchecked, If its unchecked
// it will be checked.)

    {
    int Counter = 0,
        Items,
        CheckState;

    Items = m_SecList.GetCount();
    if (Items != LB_ERR)
        {
        while (Counter < Items)
            {
            if (m_SecList.GetSel(Counter))
                {
                CheckState = m_SecList.GetCheck(Counter);
                switch (CheckState)
                    {
                    case 0:
                        CheckState = 1;
                        break;

                    case 1:
                        CheckState = 0;
                        break;
                    }
                m_SecList.SetCheck(Counter, CheckState);
                }
            Counter++;
            }
        }
    }

//************************************************************************

BOOL CSecListBox::LoadSecLevels(void)

// This function loads the Security Profile into the listbox.  If there are
// no Security Profile to load this function will return the statue of FALSE
// else it return TRUE.

    {
    BOOL    Status = FALSE;
    DWORD   Counter = 0,
            NumberOfProfiles;
    CString str;
    TSecurityProfile    Sec;
    
    NumberOfProfiles = GetSecurityProfileCount();   // Gets the number of Security Profile
    if (NumberOfProfiles > 0)
        {
        while (Counter < NumberOfProfiles)
            {
            if (GetSecurityProfileByIndex(Counter, Sec) != FALSE)   // Gets the Security Profile
                {                                                   // by its numberic index
                str = CString(Sec.Name);
                m_SecList.AddString(str);       // Add Profile Name to ListBox
                }
            Counter++;
            }

        Status = TRUE;
        }

    return (Status);
    }

//************************************************************************

void CSecListBox::OnSelchangeSeclist() 

// This function simply watches for items to be selected in the listbox, So it
// can Enable the Toggle Button and the Deselect Button, If there are no items 
// selected in the listbox it will Disable the Toggle Button and the Deselect Button.

    {
    if (m_SecList.GetSelCount() > 0)
        {
        m_ToggleButton.EnableWindow(TRUE);
        m_DeselectButton.EnableWindow(TRUE);
        }
    else
        {
        m_ToggleButton.EnableWindow(FALSE);
        m_DeselectButton.EnableWindow(FALSE);
        }
    }

//************************************************************************
