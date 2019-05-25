//************************************************************************
//*                                                                      *
//*                         -> UserListDlg.cpp <-                        *
//*                                                                      *   
//************************************************************************

#include "stdafx.h"
#include "UserList.h"
#include "UListDlg.h"
#include "UListBox.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

//************************************************************************

class CAboutDlg : public CDialog
    {
    public:
	    CAboutDlg();

    // Dialog Data
	    //{{AFX_DATA(CAboutDlg)
	    enum { IDD = IDD_ABOUTBOX };
	    //}}AFX_DATA

	    // ClassWizard generated virtual function overrides
	    //{{AFX_VIRTUAL(CAboutDlg)
	protected:
	    virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	    //}}AFX_VIRTUAL

    // Implementation
    protected:
	    //{{AFX_MSG(CAboutDlg)
	    //}}AFX_MSG
	    DECLARE_MESSAGE_MAP()
    };

//************************************************************************

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
    {
	//{{AFX_DATA_INIT(CAboutDlg)
	//}}AFX_DATA_INIT
    }

//************************************************************************

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
    {
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CAboutDlg)
	//}}AFX_DATA_MAP
    }

//************************************************************************

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
	//{{AFX_MSG_MAP(CAboutDlg)
		// No message handlers
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

//************************************************************************

CUserListDlg::CUserListDlg(CWnd* pParent) : CDialog(CUserListDlg::IDD, pParent)
    {
	//{{AFX_DATA_INIT(CUserListDlg)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
    }

//************************************************************************

void CUserListDlg::DoDataExchange(CDataExchange* pDX)
    {
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CUserListDlg)
		// NOTE: the ClassWizard will add DDX and DDV calls here
	//}}AFX_DATA_MAP
    }

//************************************************************************

BEGIN_MESSAGE_MAP(CUserListDlg, CDialog)
	//{{AFX_MSG_MAP(CUserListDlg)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDTEST, OnTest)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

//************************************************************************

BOOL CUserListDlg::OnInitDialog()
    {
	CDialog::OnInitDialog();

	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	CString strAboutMenu;
	strAboutMenu.LoadString(IDS_ABOUTBOX);
	if (!strAboutMenu.IsEmpty())
	    {
		pSysMenu->AppendMenu(MF_SEPARATOR);
		pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
	    }

	SetIcon(m_hIcon, TRUE);
	SetIcon(m_hIcon, FALSE);
	
	return (TRUE);  
    }

//************************************************************************

void CUserListDlg::OnSysCommand(UINT nID, LPARAM lParam)
    {
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	    {
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	    }
	else
		CDialog::OnSysCommand(nID, lParam);
    }

//************************************************************************

void CUserListDlg::OnPaint() 
    {
	if (IsIconic())
	    {
		CPaintDC dc(this);

		SendMessage(WM_ICONERASEBKGND, (WPARAM) dc.GetSafeHdc(), 0);

		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		dc.DrawIcon(x, y, m_hIcon);
	    }
	else
		CDialog::OnPaint();
    }

//************************************************************************

HCURSOR CUserListDlg::OnQueryDragIcon()
    {
    return ((HCURSOR) m_hIcon);
    }

//************************************************************************

void CUserListDlg::OnTest() 
    {
    CUserListBox dlg;
    dlg.DoModal();
    }

//************************************************************************
