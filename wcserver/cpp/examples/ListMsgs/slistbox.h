//************************************************************************
//*                                                                      *
//*                          -> SecListBox.h <-                          *
//*                                                                      *   
//************************************************************************

class CSecListBox : public CDialog
    {
    // Construction
    public:
	    CSecListBox(CWnd* pParent = NULL);   // standard constructor

        // Dialog Data
	    //{{AFX_DATA(CSecListBox)
	enum { IDD = IDD_SECLISTDLG };
	CButton	m_DeselectButton;
	    CButton	m_ToggleButton;
	    CCheckListBox   m_SecList;
	//}}AFX_DATA


        // Overrides
	    // ClassWizard generated virtual function overrides
	    //{{AFX_VIRTUAL(CSecListBox)
	protected:
	    virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	    //}}AFX_VIRTUAL

        // Implementation
    protected:
    	// Generated message map functions
	    //{{AFX_MSG(CSecListBox)
	    afx_msg void OnDrawItem(int nIDCtl, LPDRAWITEMSTRUCT lpDrawItemStruct);
	    afx_msg void OnMeasureItem(int nIDCtl, LPMEASUREITEMSTRUCT lpMeasureItemStruct);
	    afx_msg void OnShowWindow(BOOL bShow, UINT nStatus);
	    afx_msg void OnDblclkSeclist();
	    afx_msg void OnDeselectall();
	    afx_msg void OnSelectall();
	    afx_msg void OnToggle();
	afx_msg void OnSelchangeSeclist();
	//}}AFX_MSG
	    DECLARE_MESSAGE_MAP()

    protected:
        BOOL    LoadSecLevels(void);
    };

//************************************************************************
