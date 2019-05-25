//************************************************************************
//*                                                                      *
//*                         -> SecListDlg.h <-                           *
//*                                                                      *
//************************************************************************

class CSecListDlg : public CDialog
    {
    // Construction
    public:
	    CSecListDlg(CWnd* pParent = NULL);	// standard constructor

        // Dialog Data
	        //{{AFX_DATA(CSecListDlg)
	        enum { IDD = IDD_SECLIST_DIALOG };
		    // NOTE: the ClassWizard will add data members here
	    //}}AFX_DATA

	    // ClassWizard generated virtual function overrides
	    //{{AFX_VIRTUAL(CSecListDlg)
	protected:
    	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	    //}}AFX_VIRTUAL

    // Implementation
    protected:
	    HICON m_hIcon;

	    // Generated message map functions
	    //{{AFX_MSG(CSecListDlg)
	    virtual BOOL OnInitDialog();
	    afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	    afx_msg void OnPaint();
	    afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnTest();
	//}}AFX_MSG
	    DECLARE_MESSAGE_MAP()
    };

//************************************************************************
