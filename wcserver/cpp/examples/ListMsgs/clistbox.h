//************************************************************************
//*                                                                      *
//*                         -> ConfListBox.h <-                          *
//*                                                                      *
//************************************************************************

class CConfListBox : public CDialog
    {
    // Construction
    public:
	    CConfListBox(CWnd* pParent = NULL);   // standard constructor

    // Dialog Data
	    //{{AFX_DATA(CConfListBox)
	    enum { IDD = IDD_CONFDLG };
	    CListBox	m_ConfList;
	    //}}AFX_DATA


    // Overrides
	    // ClassWizard generated virtual function overrides
	    //{{AFX_VIRTUAL(CConfListBox)
	protected:
	    virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	    //}}AFX_VIRTUAL

    // Implementation
    protected:

	    // Generated message map functions
	    //{{AFX_MSG(CConfListBox)
	    afx_msg void OnDblclkConflist();
	    afx_msg void OnShowWindow(BOOL bShow, UINT nStatus);
	    virtual void OnOK();
	    //}}AFX_MSG
	    DECLARE_MESSAGE_MAP()

    public:
        DWORD   ConferenceNumber;
    };

//************************************************************************
