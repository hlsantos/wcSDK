//************************************************************************
//*                                                                      *
//*                          -> MsgReader.h <-                           *
//*                                                                      *
//************************************************************************

#include "wcType.h"                 // wc5 Type header include file
#include "wcServer.h"               // wc5 Server header include file

class CMsgReader : public CDialog
    {
    // Construction
    public:
	    CMsgReader(DWORD ConfNumber, CWnd* pParent = NULL);   // standard constructor

    // Dialog Data
	    //{{AFX_DATA(CMsgReader)
	enum { IDD = IDD_MESSAGEDLG };
	CListBox	m_MsgTxt;
	    BOOL	m_ReturnCheck;
	    BOOL	m_PrivateCheck;
	    CString	m_Conf;
	    CString	m_From;
	    CString	m_MsgNum;
	    CString	m_Subject;
	    CString	m_To;
	//}}AFX_DATA

    // Overrides
    	// ClassWizard generated virtual function overrides
	    //{{AFX_VIRTUAL(CMsgReader)
	protected:
	    virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

    // Implementation
    protected:

	    // Generated message map functions
	    //{{AFX_MSG(CMsgReader)
	    afx_msg void OnNext();
	    afx_msg void OnPrevious();
	    afx_msg void OnShowWindow(BOOL bShow, UINT nStatus);
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	//}}AFX_MSG
    	DECLARE_MESSAGE_MAP()

    private:
        DWORD ConferenceNumber;
        DWORD MsgNum;
        TMsgHeader MsgHeader;

    protected:
        BOOL    LoadMsg(void);
        void    DisplayMsgHeader(void);
    };

//************************************************************************
