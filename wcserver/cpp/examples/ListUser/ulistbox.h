//************************************************************************
//*                                                                      *
//*                           -> UserListBox.h <-                        *
//*                                                                      *
//************************************************************************

class CUserListBox : public CDialog
    {
    // Construction
    public:
	    CUserListBox(CWnd* pParent = NULL);   // standard constructor

    // Dialog Data
	    //{{AFX_DATA(CUserListBox)
	    enum { IDD = IDD_USERDLG };
	    CListBox	m_UserList;
	    //}}AFX_DATA


    // Overrides
	    // ClassWizard generated virtual function overrides
	    //{{AFX_VIRTUAL(CUserListBox)
	protected:
	    virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	    //}}AFX_VIRTUAL

    // Implementation
    protected:

	    // Generated message map functions
	    //{{AFX_MSG(CUserListBox)
	    afx_msg void OnShowWindow(BOOL bShow, UINT nStatus);
	    afx_msg void OnDblclkUserlist();
	    afx_msg void OnDisplay();
	    //}}AFX_MSG
	    DECLARE_MESSAGE_MAP()

    protected:
        BOOL    LoadUsers(void);
    };

//************************************************************************
