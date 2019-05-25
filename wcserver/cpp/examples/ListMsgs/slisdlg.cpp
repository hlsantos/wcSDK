//************************************************************************
//*                                                                      *
//*                         -> SecListDlg.cpp <-                         *
//*                                                                      * 
//************************************************************************

#include "stdafx.h"
#include "SecList.h"
#include "SListDlg.h"
#include "SListBox.h"

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

CSecListDlg::CSecListDlg(CWnd* pParent)	: CDialog(CSecListDlg::IDD, pParent)
    {
	//{{AFX_DATA_INIT(CSecListDlg)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
    }

//************************************************************************

void CSecListDlg::DoDataExchange(CDataExchange* pDX)
    {
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CSecListDlg)
		// NOTE: the ClassWizard will add DDX and DDV calls here
	//}}AFX_DATA_MAP
    }

//************************************************************************

BEGIN_MESSAGE_MAP(CSecListDlg, CDialog)
	//{{AFX_MSG_MAP(CSecListDlg)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(ID_TEST, OnTest)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

//************************************************************************

BOOL CSecListDlg::OnInitDialog()
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

void CSecListDlg::OnSysCommand(UINT nID, LPARAM lParam)
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

void CSecListDlg::OnPaint() 
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

HCURSOR CSecListDlg::OnQueryDragIcon()
    {
	return ((HCURSOR) m_hIcon);
    }

//************************************************************************

void CSecListDlg::OnTest() 
    {
    CSecListBox Dlg;
    Dlg.DoModal();
    }

//************************************************************************
