#include <afx.h>
#include <assert.h>

#include "cloadsys.h"

DWORD WcSystemReference     = 0;
HINSTANCE WcSystemInstance  = 0;

void (PASCAL *lpfnSetConnectionManagerConnected)(BOOL) = NULL;
void (PASCAL *lpfnSetConnectionManagerStarted)(BOOL, HWND, UINT) = NULL;
long (PASCAL *lpfnCloseAllClients)(void) = NULL;
long (PASCAL *lpfnIsConnectionManagerOnline)(void) = NULL;
long (PASCAL *lpfnIsConnectionManagerStarted)(void) = NULL;
long (PASCAL *lpfnConnectionManagerDisconnect)(void) = NULL;
long (PASCAL *lpfnConnectionManagerShouldClose)(void) = NULL;
long (PASCAL *lpfnWildcatNavigatorGetClientCount)(void) = NULL;
long (PASCAL *lpfnWildcatNavigatorGetClientInfo)(long, TClientInfo *);
long (PASCAL *lpfnWildcatNavigatorStartup)(HWND, UINT) = NULL;
void (PASCAL *lpfnWildcatNavigatorCleanup)(HWND) = NULL;               
long (PASCAL *lpfnWildcatNavigatorGetClientFlags)(HWND) = NULL;
long (PASCAL *lpfnWildcatNavigatorSetClientFlags)(HWND, DWORD) = NULL;
long (PASCAL *lpfnWcShowTransferStatus)(void) = NULL;
long (PASCAL *lpfnWcDownloadFileDirect)(const char *, DWORD, const char *, BOOL, const char *) = NULL;
long (PASCAL *lpfnWcDownloadFile)(const char *, WORD, DWORD, const char *, BOOL) = NULL;
long (PASCAL *lpfnWcDownloadAttachment)(const char *, DWORD, DWORD, const char *, BOOL) = NULL;
long (PASCAL *lpfnWcUploadFile)(const char *, const TNavFullFileRecord *) = NULL;
long (PASCAL *lpfnWcUploadFileEx)(const char *, const TNavFullFileRecord *, WORD flags) = NULL;
long (PASCAL *lpfnWcDownloadFileMultiple)(HGLOBAL) = NULL;
long (PASCAL *lpfnWcDownloadAttachmentMultiple)(HGLOBAL) = NULL;
long (PASCAL *lpfnWcUploadFileMultiple)(HGLOBAL) = NULL;
long (PASCAL *lpfnWcUploadFileExMultiple)(HGLOBAL) = NULL;
long (PASCAL *lpfnWcWriteMessage)(const TUserInfo *, const TUserInfo *, const char *) = NULL;
long (PASCAL *lpfnWcReadNewMail)(void) = NULL;
long (PASCAL *lpfnWcWriteUserPage)(const char *, const char *, const char *, DWORD) = NULL;
void (PASCAL *lpfnConfigureNavigatorSounds)(void) = NULL;
void (PASCAL *lpfnRegisterNavigatorSound)(const char *, const char *, const char *) = NULL;
void (PASCAL *lpfnPlayNavigatorSound)(const char *, const char *) = NULL;
long (PASCAL *lpfnWcCheckClientVersion)(const char far *, const char far *) = NULL;
long (PASCAL *lpfnWcGetClientVersion)(char *, const char *, int) = NULL;
long (PASCAL *lpfnWcRunClient)(const char far *, const WcRunClientStructure far *) = NULL;
long (PASCAL *lpfnWcRunClientEx)(const char far *, const WcRunClientStructure far *, DWORD) = NULL;
long (PASCAL *lpfnWcCheckMail)(void) = NULL;
long (PASCAL *lpfnWcAddUserAddress)(HWND, WcAddressBookEntry far *) = NULL;
long (PASCAL *lpfnWcGetRecipientList)(HWND, const char far *, BOOL, HANDLE) = NULL;
HANDLE (PASCAL *lpfnWcGetGroupList)(const char far *, const char far *) = NULL;
long (PASCAL *lpfnWcManageAddressBook)(HWND) = NULL;
void (PASCAL *lpfnSetCurrentSystemDirty)(void);
const char *(PASCAL *lpfnGetCurrentSystemName)(void);
const char *(PASCAL *lpfnGetCurrentSystemRegNo)(void);
BOOL (PASCAL *lpfnIsCustomConnector)(void);

BOOL LoadWcSystemLibrary()
{
  if (WcSystemReference == 0) {
    WcSystemInstance = LoadLibrary(NAV_WCSYSTEM_DLL);
    if (WcSystemInstance > HINSTANCE_ERROR) {
      WcSystemReference++;
      (FARPROC&) lpfnSetConnectionManagerConnected = GetProcAddress(WcSystemInstance, "SetConnectionManagerConnected"); assert(lpfnSetConnectionManagerConnected != NULL);
      (FARPROC&) lpfnSetConnectionManagerStarted = GetProcAddress(WcSystemInstance, "SetConnectionManagerStarted"); assert(lpfnSetConnectionManagerStarted != NULL);
      (FARPROC&) lpfnCloseAllClients = GetProcAddress(WcSystemInstance, "CloseAllClients"); assert(lpfnCloseAllClients != NULL);
      (FARPROC&) lpfnIsConnectionManagerOnline = GetProcAddress(WcSystemInstance, "IsConnectionManagerOnline"); assert(lpfnIsConnectionManagerOnline != NULL);
      (FARPROC&) lpfnIsConnectionManagerStarted = GetProcAddress(WcSystemInstance, "IsConnectionManagerStarted"); assert(lpfnIsConnectionManagerStarted != NULL);
      (FARPROC&) lpfnConnectionManagerDisconnect = GetProcAddress(WcSystemInstance, "ConnectionManagerDisconnect"); assert(lpfnConnectionManagerDisconnect != NULL);
      (FARPROC&) lpfnConnectionManagerShouldClose = GetProcAddress(WcSystemInstance, "ConnectionManagerShouldClose"); assert(lpfnConnectionManagerShouldClose != NULL);
      (FARPROC&) lpfnWildcatNavigatorGetClientCount = GetProcAddress(WcSystemInstance, "WildcatNavigatorGetClientCount"); //assert(lpfnWildcatNavigatorGetClientCount != NULL);
      (FARPROC&) lpfnWildcatNavigatorGetClientInfo = GetProcAddress(WcSystemInstance, "WildcatNavigatorGetClientInfo"); //assert(lpfnWildcatNavigatorGetClientInfo != NULL);
      (FARPROC&) lpfnWildcatNavigatorStartup = GetProcAddress(WcSystemInstance, "WildcatNavigatorStartup"); assert(lpfnWildcatNavigatorStartup != NULL);
      (FARPROC&) lpfnWildcatNavigatorCleanup = GetProcAddress(WcSystemInstance, "WildcatNavigatorCleanup"); assert(lpfnWildcatNavigatorCleanup != NULL);
      (FARPROC&) lpfnWildcatNavigatorGetClientFlags = GetProcAddress(WcSystemInstance, "WildcatNavigatorGetClientFlags"); assert(lpfnWildcatNavigatorGetClientFlags != NULL);
      (FARPROC&) lpfnWildcatNavigatorSetClientFlags = GetProcAddress(WcSystemInstance, "WildcatNavigatorSetClientFlags"); assert(lpfnWildcatNavigatorSetClientFlags != NULL);
      (FARPROC&) lpfnWcShowTransferStatus = GetProcAddress(WcSystemInstance, "WcShowTransferStatus"); assert(lpfnWcShowTransferStatus != NULL);
      (FARPROC&) lpfnWcDownloadFileDirect = GetProcAddress(WcSystemInstance, "WcDownloadFileDirect"); assert(lpfnWcDownloadFileDirect != NULL);
      (FARPROC&) lpfnWcDownloadFile = GetProcAddress(WcSystemInstance, "WcDownloadFile"); assert(lpfnWcDownloadFile != NULL);
      (FARPROC&) lpfnWcDownloadAttachment = GetProcAddress(WcSystemInstance, "WcDownloadAttachment"); assert(lpfnWcDownloadAttachment != NULL);
      (FARPROC&) lpfnWcUploadFile = GetProcAddress(WcSystemInstance, "WcUploadFile"); assert(lpfnWcUploadFile != NULL);
      (FARPROC&) lpfnWcUploadFileEx = GetProcAddress(WcSystemInstance, "WcUploadFileEx"); assert(lpfnWcUploadFileEx != NULL);
      (FARPROC&) lpfnWcDownloadFileMultiple = GetProcAddress(WcSystemInstance, "WcDownloadFileMultiple"); assert(lpfnWcDownloadFileMultiple != NULL);
      (FARPROC&) lpfnWcDownloadAttachmentMultiple = GetProcAddress(WcSystemInstance, "WcDownloadAttachmentMultiple"); assert(lpfnWcDownloadAttachmentMultiple != NULL);
      (FARPROC&) lpfnWcUploadFileMultiple = GetProcAddress(WcSystemInstance, "WcUploadFileMultiple"); assert(lpfnWcUploadFileMultiple != NULL);
      (FARPROC&) lpfnWcUploadFileExMultiple = GetProcAddress(WcSystemInstance, "WcUploadFileExMultiple"); assert(lpfnWcUploadFileExMultiple != NULL);
      (FARPROC&) lpfnWcWriteMessage = GetProcAddress(WcSystemInstance, "WcWriteMessage"); assert(lpfnWcWriteMessage != NULL);
      (FARPROC&) lpfnWcReadNewMail = GetProcAddress(WcSystemInstance, "WcReadNewMail"); assert(lpfnWcReadNewMail != NULL);
      (FARPROC&) lpfnWcWriteUserPage = GetProcAddress(WcSystemInstance, "WcWriteUserPage"); assert(lpfnWcWriteUserPage != NULL);
      (FARPROC&) lpfnConfigureNavigatorSounds = GetProcAddress(WcSystemInstance, "ConfigureNavigatorSounds"); assert(lpfnConfigureNavigatorSounds != NULL);
      (FARPROC&) lpfnRegisterNavigatorSound = GetProcAddress(WcSystemInstance, "RegisterNavigatorSound"); assert(lpfnRegisterNavigatorSound != NULL);
      (FARPROC&) lpfnPlayNavigatorSound = GetProcAddress(WcSystemInstance, "PlayNavigatorSound"); assert(lpfnPlayNavigatorSound != NULL);
      (FARPROC&) lpfnWcCheckClientVersion = GetProcAddress(WcSystemInstance, "WcCheckClientVersion"); assert(lpfnWcCheckClientVersion != NULL);
      (FARPROC&) lpfnWcGetClientVersion = GetProcAddress(WcSystemInstance, "WcGetClientVersion"); assert(lpfnWcGetClientVersion != NULL);
      (FARPROC&) lpfnWcRunClient = GetProcAddress(WcSystemInstance, "WcRunClient"); assert(lpfnWcRunClient != NULL);
      (FARPROC&) lpfnWcRunClientEx = GetProcAddress(WcSystemInstance, "WcRunClientEx"); /*assert(lpfnWcRunClientEx != NULL);*/
      (FARPROC&) lpfnWcCheckMail = GetProcAddress(WcSystemInstance, "WcCheckMail"); assert(lpfnWcCheckMail != NULL);
      (FARPROC&) lpfnWcAddUserAddress = GetProcAddress(WcSystemInstance, "WcAddUserAddress"); assert(lpfnWcAddUserAddress != NULL);
      (FARPROC&) lpfnWcGetRecipientList = GetProcAddress(WcSystemInstance, "WcGetRecipientList"); assert(lpfnWcGetRecipientList != NULL);
      (FARPROC&) lpfnWcGetGroupList = GetProcAddress(WcSystemInstance, "WcGetGroupList"); assert(lpfnWcGetGroupList != NULL);
      (FARPROC&) lpfnWcManageAddressBook = GetProcAddress(WcSystemInstance, "WcManageAddressBook"); assert(lpfnWcManageAddressBook != NULL);
      (FARPROC&) lpfnSetCurrentSystemDirty = GetProcAddress(WcSystemInstance, "SetCurrentSystemDirty"); assert(lpfnSetCurrentSystemDirty != NULL);
      (FARPROC&) lpfnGetCurrentSystemName = GetProcAddress(WcSystemInstance, "GetCurrentSystemName"); assert(lpfnGetCurrentSystemName != NULL);
      (FARPROC&) lpfnGetCurrentSystemRegNo = GetProcAddress(WcSystemInstance, "GetCurrentSystemRegNo"); assert(lpfnGetCurrentSystemRegNo != NULL);
      (FARPROC&) lpfnIsCustomConnector = GetProcAddress(WcSystemInstance, "IsCustomConnector"); assert(lpfnIsCustomConnector != NULL);
      return TRUE;
    }
    return FALSE;
  }
  WcSystemReference++;
  return TRUE;
}

void FreeWcSystemLibrary()
{
  if (WcSystemReference == 1) {
    if (WcSystemInstance > HINSTANCE_ERROR) {
      lpfnSetConnectionManagerConnected = NULL;
      lpfnSetConnectionManagerStarted = NULL;
      lpfnCloseAllClients = NULL;
      lpfnIsConnectionManagerOnline = NULL;
      lpfnIsConnectionManagerStarted = NULL;
      lpfnConnectionManagerDisconnect = NULL;
      lpfnConnectionManagerShouldClose = NULL;
      lpfnWildcatNavigatorGetClientCount = NULL;
      lpfnWildcatNavigatorGetClientInfo = NULL;
      lpfnWildcatNavigatorStartup = NULL;
      lpfnWildcatNavigatorCleanup = NULL;
      lpfnWildcatNavigatorGetClientFlags = NULL;
      lpfnWildcatNavigatorSetClientFlags = NULL;
      lpfnWcShowTransferStatus = NULL;
      lpfnWcDownloadFileDirect = NULL;
      lpfnWcDownloadFile = NULL;
      lpfnWcDownloadAttachment = NULL;
      lpfnWcUploadFile = NULL;
      lpfnWcUploadFileEx = NULL;
      lpfnWcDownloadFileMultiple = NULL;
      lpfnWcDownloadAttachmentMultiple = NULL;
      lpfnWcUploadFileMultiple = NULL;
      lpfnWcUploadFileExMultiple = NULL;
      lpfnWcWriteMessage = NULL;
      lpfnWcReadNewMail = NULL;
      lpfnWcWriteUserPage = NULL;
      lpfnConfigureNavigatorSounds = NULL;
      lpfnRegisterNavigatorSound = NULL;
      lpfnPlayNavigatorSound = NULL;
      lpfnWcCheckClientVersion = NULL;
      lpfnWcGetClientVersion = NULL;
      lpfnWcRunClient = NULL;
      lpfnWcRunClientEx = NULL;
      lpfnWcCheckMail = NULL;
      lpfnWcAddUserAddress = NULL;
      lpfnWcGetRecipientList = NULL;
      lpfnWcGetGroupList = NULL;
      lpfnWcManageAddressBook = NULL;
      lpfnSetCurrentSystemDirty = NULL;
      lpfnGetCurrentSystemName = NULL;
      lpfnGetCurrentSystemRegNo = NULL;
      lpfnIsCustomConnector = NULL;
      FreeLibrary(WcSystemInstance);
    }
  }
  WcSystemReference--;
}

void PASCAL SetConnectionManagerConnected(BOOL value)
{
  if (lpfnSetConnectionManagerConnected == NULL) {
    assert(FALSE);
    return;
  }
  lpfnSetConnectionManagerConnected(value);
}

void PASCAL SetConnectionManagerStarted(BOOL value, HWND wnd, UINT wMsg)
{
  if (lpfnSetConnectionManagerStarted == NULL) {
    assert(FALSE);
    return;
  }
  lpfnSetConnectionManagerStarted(value, wnd, wMsg);
}

long PASCAL CloseAllClients()
{
  if (lpfnCloseAllClients == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnCloseAllClients();
}

long PASCAL IsConnectionManagerOnline()
{
  if (lpfnIsConnectionManagerOnline == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnIsConnectionManagerOnline();
}

long PASCAL IsConnectionManagerStarted()
{
  if (lpfnIsConnectionManagerStarted == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnIsConnectionManagerStarted();
}

long PASCAL ConnectionManagerDisconnect()
{
  if (lpfnConnectionManagerDisconnect == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnConnectionManagerDisconnect();
}
      
long PASCAL ConnectionManagerShouldClose()
{
  if (lpfnConnectionManagerShouldClose == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnConnectionManagerShouldClose();
}      
      
long PASCAL WildcatNavigatorGetClientCount()
{
  OutputDebugString("CLoadSys::WildcatNavigatorGetClientCount() 1\n");
  if (lpfnWildcatNavigatorGetClientCount == NULL) {
  OutputDebugString("CLoadSys::WildcatNavigatorGetClientCount() Oops!\n");
    assert(FALSE);
    return 0;
  }
  return lpfnWildcatNavigatorGetClientCount();
}

long PASCAL WildcatNavigatorGetClientInfo(long nIndex, TClientInfo *ci)
{
  if (lpfnWildcatNavigatorGetClientInfo == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnWildcatNavigatorGetClientInfo(nIndex, ci);
}

long PASCAL WildcatNavigatorStartup(HWND hWnd, UINT wMsg)
{
  if (lpfnWildcatNavigatorStartup == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnWildcatNavigatorStartup(hWnd, wMsg);
}                                           

void PASCAL WildcatNavigatorCleanup(HWND hWnd)
{
  if (lpfnWildcatNavigatorCleanup == NULL) {
    assert(FALSE);
    return;
  }                                
  lpfnWildcatNavigatorCleanup(hWnd);
}

long PASCAL WildcatNavigatorGetClientFlags(HWND hWnd)
{
  if (lpfnWildcatNavigatorGetClientFlags == NULL) {
    assert(FALSE);
    return 0;
  }        
  return lpfnWildcatNavigatorGetClientFlags(hWnd);
}                                   
                                   
long PASCAL WildcatNavigatorSetClientFlags(HWND hWnd, DWORD flags)
{
  if (lpfnWildcatNavigatorSetClientFlags == NULL) {
    assert(FALSE);
    return 0;
  }        
  return lpfnWildcatNavigatorSetClientFlags(hWnd, flags);
}                                   
                                   
long PASCAL WcShowTransferStatus()
{
  if (lpfnWcShowTransferStatus == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnWcShowTransferStatus();
}

long PASCAL WcDownloadFileDirect(const char *filename, DWORD expected, const char *downloadpath, BOOL downloadAndRun, const char *downloadName)
{
  if (lpfnWcDownloadFileDirect == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnWcDownloadFileDirect(filename, expected, downloadpath, downloadAndRun, downloadName);
}

long PASCAL WcDownloadFile(const char *filename, WORD area, DWORD expected, const char *downloadpath, BOOL downloadAndRun)
{
  if (lpfnWcDownloadFile == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnWcDownloadFile(filename, area, expected, downloadpath, downloadAndRun);
}

long PASCAL WcDownloadAttachment(const char *filename, DWORD msgid, DWORD conf, const char *downloadPath, BOOL downloadAndRun)
{
  if (lpfnWcDownloadAttachment == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnWcDownloadAttachment(filename, msgid, conf, downloadPath, downloadAndRun);
}

long PASCAL WcUploadFile(const char *filename, const TNavFullFileRecord *file)
{
  if (lpfnWcUploadFile == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnWcUploadFile(filename, file);
}

long PASCAL WcUploadFileEx(const char *filename, const TNavFullFileRecord *file, WORD flags)
{
  if (lpfnWcUploadFileEx == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnWcUploadFileEx(filename, file, flags);
}

long PASCAL WcDownloadFileMultiple(HGLOBAL info)
{
  if (lpfnWcDownloadFileMultiple == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnWcDownloadFileMultiple(info);
}

long PASCAL WcDownloadAttachmentMultiple(HGLOBAL info)
{
  if (lpfnWcDownloadAttachmentMultiple == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnWcDownloadAttachmentMultiple(info);
}

long PASCAL WcUploadFileMultiple(HGLOBAL info)
{
  if (lpfnWcUploadFileMultiple == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnWcUploadFileMultiple(info);
}

long PASCAL WcUploadFileExMultiple(HGLOBAL info)
{
  if (lpfnWcUploadFileExMultiple == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnWcUploadFileExMultiple(info);
}

long PASCAL WcWriteMessage(const TUserInfo *touser, const TUserInfo *fromuser, const char *subject)
{
  if (lpfnWcWriteMessage == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnWcWriteMessage(touser, fromuser, subject);
}

long PASCAL WcReadNewMail()
{
  if (lpfnWcReadNewMail == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnWcReadNewMail();
}

long PASCAL WcWriteUserPage(const char *touser, const char *fromuser, const char *message, DWORD flags)
{
  if (lpfnWcWriteUserPage == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnWcWriteUserPage(touser, fromuser, message, flags);
}

void PASCAL ConfigureNavigatorSounds()
{
  if (lpfnConfigureNavigatorSounds == NULL) {
    assert(FALSE);
    return;
  }
  lpfnConfigureNavigatorSounds();
}

void PASCAL RegisterNavigatorSound(const char *app, const char *event, const char *defsound)
{
  if (lpfnRegisterNavigatorSound == NULL) {
    assert(FALSE);
    return;
  }
  lpfnRegisterNavigatorSound(app, event, defsound);
}

void PASCAL PlayNavigatorSound(const char *app, const char *event)
{
  if (lpfnPlayNavigatorSound == NULL) {
    assert(FALSE);
    return;
  }
  lpfnPlayNavigatorSound(app, event);
}

long PASCAL WcCheckClientVersion(const char far *clientname, const char far *version)
{
  if (lpfnWcCheckClientVersion == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnWcCheckClientVersion(clientname, version);
}

long PASCAL WcGetClientVersion(char *clientversion, const char *clientname, int maxlen)
{
  if (lpfnWcGetClientVersion == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnWcGetClientVersion(clientversion, clientname, maxlen);
}

long PASCAL WcRunClient(const char far *clientname, const WcRunClientStructure far *sendinfo)
{
  if (lpfnWcRunClient == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnWcRunClient(clientname, sendinfo);
}

long PASCAL WcRunClientEx(const char far *clientname, const WcRunClientStructure far *sendinfo, DWORD flags)
{
/*if (lpfnWcRunClientEx == NULL) {
    assert(FALSE);
    return 0;
  }*/
  return lpfnWcRunClientEx(clientname, sendinfo, flags);
}

long PASCAL WcCheckMail()
{
  if (lpfnWcCheckMail == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnWcCheckMail();
}

long PASCAL WcAddUserAddress(HWND parent, WcAddressBookEntry far *entry)
{
  if (lpfnWcAddUserAddress == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnWcAddUserAddress(parent, entry);
}

long PASCAL WcGetRecipientList(HWND parent, const char far *addresstype, BOOL carboncopy, HANDLE list)
{
  if (lpfnWcGetRecipientList == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnWcGetRecipientList(parent, addresstype, carboncopy, list);
}

HANDLE PASCAL WcGetGroupList(const char far *group, const char far *addresstype)
{
  if (lpfnWcGetGroupList == NULL) {
    assert(FALSE);
    return NULL;
  }
  return lpfnWcGetGroupList(group, addresstype);
}

long PASCAL WcManageAddressBook(HWND parent)
{
  if (lpfnWcManageAddressBook == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnWcManageAddressBook(parent);
}
 
void SetCurrentSystemDirty()
{
  if (lpfnSetCurrentSystemDirty == NULL) {
    assert(FALSE);
    return;
  }
  lpfnSetCurrentSystemDirty();
} 
 
const char *GetCurrentSystemName()
{
  if (lpfnGetCurrentSystemName == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnGetCurrentSystemName();
}

const char *GetCurrentSystemRegNo()
{
  if (lpfnGetCurrentSystemRegNo == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnGetCurrentSystemRegNo();
}

BOOL PASCAL IsCustomConnector()
{
  if (lpfnIsCustomConnector == NULL) {
    assert(FALSE);
    return 0;
  }          
  return lpfnIsCustomConnector();
}

