; CLW file contains information for the MFC ClassWizard

[General Info]
Version=1
LastClass=CConfListBox
LastTemplate=CDialog
NewFileInclude1=#include "stdafx.h"
NewFileInclude2=#include "readmsg.h"
LastPage=0

ClassCount=7
Class1=CConfListBox
Class2=CMsgReader
Class3=CReadMsgApp
Class4=CAboutDlg
Class5=CReadMsgDlg
Class6=CSecListDlg
Class7=CSecListBox

ResourceCount=4
Resource1=IDD_READMSG_DIALOG
Resource2=IDD_ABOUTBOX
Resource3=IDD_CONFDLG
Resource4=IDD_MESSAGEDLG

[CLS:CConfListBox]
Type=0
BaseClass=CDialog
HeaderFile=clistbox.h
ImplementationFile=clistbox.cpp
LastObject=CConfListBox

[CLS:CMsgReader]
Type=0
BaseClass=CDialog
HeaderFile=mreader.h
ImplementationFile=mreader.cpp

[CLS:CReadMsgApp]
Type=0
BaseClass=CWinApp
HeaderFile=readmsg.h
ImplementationFile=readmsg.cpp

[CLS:CAboutDlg]
Type=0
BaseClass=CDialog
HeaderFile=rmsgdlg.cpp
ImplementationFile=rmsgdlg.cpp

[CLS:CReadMsgDlg]
Type=0
BaseClass=CDialog
HeaderFile=rmsgdlg.h
ImplementationFile=rmsgdlg.cpp

[CLS:CSecListDlg]
Type=0
BaseClass=CDialog
HeaderFile=slistdlg.h
ImplementationFile=slisdlg.cpp

[CLS:CSecListBox]
Type=0
BaseClass=CDialog
HeaderFile=slistbox.h
ImplementationFile=slistbox.cpp

[DLG:IDD_CONFDLG]
Type=1
Class=CConfListBox
ControlCount=3
Control1=IDOK,button,1342242817
Control2=IDCANCEL,button,1342242816
Control3=IDC_CONFLIST,listbox,1353777409

[DLG:IDD_MESSAGEDLG]
Type=1
Class=CMsgReader
ControlCount=17
Control1=IDCANCEL,button,1342242816
Control2=ID_NEXT,button,1342242816
Control3=ID_PREVIOUS,button,1342242816
Control4=IDC_STATICTO,static,1342308491
Control5=IDC_STATIC,button,1342177287
Control6=IDC_STATICFROM,static,1342308491
Control7=IDC_STATICSUBJECT,static,1342308491
Control8=IDC_TOTXT,static,1342312588
Control9=IDC_FROMTXT,static,1342312588
Control10=IDC_SUBJECTTXT,static,1342312588
Control11=IDC_STATICCONF,static,1342308491
Control12=IDC_CONFTXT,static,1342312588
Control13=IDC_STATICMSGNUM,static,1342308491
Control14=IDC_MSGNUMTXT,static,1342312588
Control15=IDC_CHECKPRIVATE,button,1342242851
Control16=IDC_CHECKRETURN,button,1342242851
Control17=IDC_MSGTXT,listbox,1353777408

[DLG:IDD_ABOUTBOX]
Type=1
Class=CAboutDlg
ControlCount=4
Control1=IDC_STATIC,static,1342177283
Control2=IDC_STATIC,static,1342308480
Control3=IDC_STATIC,static,1342308352
Control4=IDOK,button,1342373889

[DLG:IDD_READMSG_DIALOG]
Type=1
Class=CReadMsgDlg
ControlCount=5
Control1=IDOK,button,1342242817
Control2=IDCANCEL,button,1342242816
Control3=IDTEST,button,1342242816
Control4=IDC_STATIC,button,1342177287
Control5=IDC_STATIC,static,1342308352

[DLG:IDD_SECLIST_DIALOG]
Type=1
Class=CSecListDlg

[DLG:IDD_SECLISTDLG]
Type=1
Class=CSecListBox

