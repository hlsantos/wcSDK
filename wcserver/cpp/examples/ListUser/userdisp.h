//************************************************************************
//*                                                                      *
//*                         -> UserDisplay.h <-                          *
//*                                                                      *   
//************************************************************************

#include "wcType.h"             // wc5 Type header include file
#include "wcServer.h"           // wc5 Server header include file

//************************************************************************
class CUserDisplay : public CDialog
    {
    // Construction
    public:
	    CUserDisplay(TUser UserRec, CWnd* pParent = NULL);   // standard constructor

    // Dialog Data
	    //{{AFX_DATA(CUserDisplay)
	    enum { IDD = IDD_USERDISPLAY };
	    CString	m_Address1;
	    CString	m_Address2;
	    CString	m_City;
	    CString	m_Company;
	    CString	m_From;
	    CString	m_Name;
	    CString	m_Phone;
	    CString	m_RealName;
	    CString	m_Security;
	    CString	m_State;
	    //}}AFX_DATA


    // Overrides
	    // ClassWizard generated virtual function overrides
	    //{{AFX_VIRTUAL(CUserDisplay)
	protected:
	    virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	    //}}AFX_VIRTUAL

    // Implementation
    protected:

	    // Generated message map functions
	    //{{AFX_MSG(CUserDisplay)
	    afx_msg void OnShowWindow(BOOL bShow, UINT nStatus);
	    //}}AFX_MSG
	    DECLARE_MESSAGE_MAP()

    private:
        TUser   User;
    };

//************************************************************************
