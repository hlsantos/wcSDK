//************************************************************************
//*                                                                      *
//*                            -> ReadMsg.h <-                           *
//*                                                                      *   
//************************************************************************

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

//************************************************************************

class CReadMsgApp : public CWinApp
    {
    public:
	    CReadMsgApp();

    // Overrides
	    // ClassWizard generated virtual function overrides
	    //{{AFX_VIRTUAL(CReadMsgApp)
	public:
	    virtual BOOL InitInstance();
	    //}}AFX_VIRTUAL

    // Implementation

	    //{{AFX_MSG(CReadMsgApp)
		    // NOTE - the ClassWizard will add and remove member functions here.
		    //    DO NOT EDIT what you see in these blocks of generated code !
	    //}}AFX_MSG
	    DECLARE_MESSAGE_MAP()
    };

//************************************************************************
