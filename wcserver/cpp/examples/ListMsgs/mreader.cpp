//************************************************************************
//*                                                                      *
//*                         -> MsgReader.cpp <-                          *
//*                                                                      *
//************************************************************************

#include "stdafx.h"
#include "ReadMsg.h"
#include "MReader.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

//************************************************************************

CMsgReader::CMsgReader(DWORD ConfNumber, CWnd* pParent) : CDialog(CMsgReader::IDD, pParent)
    {
	//{{AFX_DATA_INIT(CMsgReader)
	m_ReturnCheck = FALSE;
	m_PrivateCheck = FALSE;
	m_Conf = _T("");
	m_From = _T("");
	m_MsgNum = _T("");
	m_Subject = _T("");
	m_To = _T("");
	//}}AFX_DATA_INIT

    ConferenceNumber = ConfNumber;
    }

//************************************************************************

void CMsgReader::DoDataExchange(CDataExchange* pDX)
    {
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CMsgReader)
	DDX_Control(pDX, IDC_MSGTXT, m_MsgTxt);
	DDX_Check(pDX, IDC_CHECKRETURN, m_ReturnCheck);
	DDX_Check(pDX, IDC_CHECKPRIVATE, m_PrivateCheck);
	DDX_Text(pDX, IDC_CONFTXT, m_Conf);
	DDX_Text(pDX, IDC_FROMTXT, m_From);
	DDX_Text(pDX, IDC_MSGNUMTXT, m_MsgNum);
	DDX_Text(pDX, IDC_SUBJECTTXT, m_Subject);
	DDX_Text(pDX, IDC_TOTXT, m_To);
	//}}AFX_DATA_MAP
    }

//************************************************************************

BEGIN_MESSAGE_MAP(CMsgReader, CDialog)
	//{{AFX_MSG_MAP(CMsgReader)
	ON_BN_CLICKED(ID_NEXT, OnNext)
	ON_BN_CLICKED(ID_PREVIOUS, OnPrevious)
	ON_WM_SHOWWINDOW()
	ON_WM_CREATE()
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

//************************************************************************

void CMsgReader::OnNext() 

// This function tries to get the Next Message, If it can, Then it will 
// Load the message text and then display it.. If it can't then it will 
// display a message informing the user and exit the dialog box.

    {
    if (GetNextMessage(MsgHeader) != FALSE) // Get Next message in this conference
        {
        if (LoadMsg() != FALSE)
            DisplayMsgHeader();
        }
    else
        {
        MessageBox("This is the last message!");
        OnCancel();
        }
    }

//************************************************************************

void CMsgReader::OnPrevious() 

// This function tries to get the Previous Message, If it can, Then it will 
// Load the message text and then display it.. If it can't then it will 
// display a message informing the user and exit the dialog box.

    {
    if (GetPrevMessage(MsgHeader) != FALSE) // Get Previous message in this conference
        {
        if (LoadMsg() != FALSE)
            DisplayMsgHeader();
        }
    else
        {
        MessageBox("This is the first message!");
        OnCancel();
        }
    }

//************************************************************************

void CMsgReader::OnShowWindow(BOOL bShow, UINT nStatus) 

// This function will display the Dialog Box and Load the first message text
// and display it.

    {
    CDialog::OnShowWindow(bShow, nStatus);

    if (LoadMsg() != FALSE)
        DisplayMsgHeader();
    }

//************************************************************************

BOOL    CMsgReader::LoadMsg(void)

// This function will load the message text of a message into the ListBox.

    {
    BOOL        Status = FALSE,
                Done = FALSE;
    CString     FileName;
    char        buf[128];
    WCHANDLE    fp;

    m_MsgTxt.ResetContent();

    // The "FileName" variable is a "WCPATH" path that is used by the server
    // to allow you access to files maintained by the server.  In this example this
    // is how you are able to read the message text of a message.  You simple tell
    // it the conference and the message id that you want the text for and the 
    // server allow you to read this information in a form of a file.

    FileName.Format("wc:\\conf(%d)\\message(%d)", ConferenceNumber, MsgHeader.Id);

    // Open a "WCFILE" handle, This function is very much like CreateFile in Win32.

    fp = WcCreateFile(FileName, GENERIC_READ, FILE_SHARE_READ, OPEN_EXISTING);
    if (fp)
        {
        while (! Done)
            {
            // Read a line of text in from the file handle. 

            if (WcReadLine(fp, buf, sizeof(buf)) != FALSE)
                m_MsgTxt.AddString(buf);
            else
                Done = TRUE;
            }

        // Close the file handle after you are done using it.

        WcCloseHandle(fp);
        Status = TRUE;
        }

    return (Status);
    }

//************************************************************************

void CMsgReader::DisplayMsgHeader()

// This function copies the Message Header information into the fields that
// dialog box will use.

    {
    m_To = MsgHeader.To.Name;
    m_From = MsgHeader.From.Name;
    m_Subject = MsgHeader.Subject;
    m_MsgNum.Format("%d", MsgHeader.Number);
    m_Conf.Format("%d", MsgHeader.Conference);
    m_PrivateCheck = MsgHeader.Private;
    m_ReturnCheck = MsgHeader.ReceiptRequested;
    UpdateData(FALSE);
    }

//************************************************************************

int CMsgReader::OnCreate(LPCREATESTRUCT lpCreateStruct) 

// This function will create the dialog and search for the first message.  If 
// found then everything will be ok, But if SearchMessageById(...); fails then
// this function will fail also.

    {
    DWORD   MsgId = 0;

    // Find the first message in this confernece
    if (SearchMessageById(ConferenceNumber, MsgId, MsgHeader) == TRUE)
        {
	    if (CDialog::OnCreate(lpCreateStruct) == -1)
		    return (-1);
        }	
    else
        {
        MessageBox("There are no messages in this conference!");
        return (-1);
        }
	
	return (0);
    }

//************************************************************************
