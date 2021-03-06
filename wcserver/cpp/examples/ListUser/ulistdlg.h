//************************************************************************
//*                                                                      *
//*                         -> UserListDlg.h <-                          *
//*                                                                      *
//************************************************************************

class CUserListDlg : public CDialog
    {
    // Construction
    public:
	    CUserListDlg(CWnd* pParent = NULL);	// standard constructor

    // Dialog Data
	    //{{AFX_DATA(CUserListDlg)
	    enum { IDD = IDD_USERLIST_DIALOG };
		// NOTE: the ClassWizard will add data members here
	    //}}AFX_DATA

	    // ClassWizard generated virtual function overrides
	    //{{AFX_VIRTUAL(CUserListDlg)
	protected:
	    virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	    //}}AFX_VIRTUAL

    // Implementation
    protected:
	    HICON m_hIcon;

	    // Generated message map functions
	    //{{AFX_MSG(CUserListDlg)
	    virtual BOOL OnInitDialog();
	    afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	    afx_msg void OnPaint();
	    afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnTest();
	//}}AFX_MSG
	    DECLARE_MESSAGE_MAP()
    };

//************************************************************************
