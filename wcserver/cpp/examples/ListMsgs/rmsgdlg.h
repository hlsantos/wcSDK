//************************************************************************
//*                                                                      *
//*                           -> ReadMsgDlg.h <-                         *
//*                                                                      *
//************************************************************************

class CReadMsgDlg : public CDialog
    {
    // Construction
    public:
	    CReadMsgDlg(CWnd* pParent = NULL);	// standard constructor

    // Dialog Data
	    //{{AFX_DATA(CReadMsgDlg)
	    enum { IDD = IDD_READMSG_DIALOG };
	    // NOTE: the ClassWizard will add data members here
	    //}}AFX_DATA

	    // ClassWizard generated virtual function overrides
	    //{{AFX_VIRTUAL(CReadMsgDlg)
	protected:
	    virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	    //}}AFX_VIRTUAL

    // Implementation
    protected:
	    HICON m_hIcon;

	    // Generated message map functions
	    //{{AFX_MSG(CReadMsgDlg)
	    virtual BOOL OnInitDialog();
	    afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	    afx_msg void OnPaint();
	    afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnTest();
	//}}AFX_MSG
	    DECLARE_MESSAGE_MAP()
    };

//************************************************************************
