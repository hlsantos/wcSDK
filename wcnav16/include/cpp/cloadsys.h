#ifndef __CLOADSYS_h
#define __CLOADSYS_h

// server record structure dependencies
//
// - TUserInfo
// - TNavFullFileRecord

#include "wcnavsys.h"

BOOL LoadWcSystemLibrary();
void FreeWcSystemLibrary();

void PASCAL SetConnectionManagerConnected(BOOL value);
void PASCAL SetConnectionManagerStarted(BOOL value, HWND wnd, UINT wMsg);
long PASCAL CloseAllClients();

long PASCAL IsConnectionManagerOnline();
long PASCAL IsConnectionManagerStarted();
long PASCAL ConnectionManagerDisconnect();
long PASCAL ConnectionManagerShouldClose();

long PASCAL WildcatNavigatorGetClientCount();
long PASCAL WildcatNavigatorGetClientInfo(long nIndex, TClientInfo *ci);

long PASCAL WildcatNavigatorStartup(HWND hWnd, UINT wMsg);
long PASCAL WildcatNavigatorStartupEx(HWND hWnd, UINT wMsg, DWORD flags);
void PASCAL WildcatNavigatorCleanup(HWND hWnd);

long PASCAL WildcatNavigatorGetClientFlags(HWND hWnd);
long PASCAL WildcatNavigatorSetClientFlags(HWND hWnd, DWORD flags);

long PASCAL WcShowTransferStatus();

long PASCAL WcDownloadFileDirect(const char *filename, DWORD expected = 0, const char *downloadpath = NULL, BOOL downloadAndRun = FALSE, const char *downloadName = NULL);
long PASCAL WcDownloadFile(const char *filename, WORD area, DWORD expected = 0, const char *downloadpath = NULL, BOOL downloadAndRun = FALSE);
long PASCAL WcDownloadAttachment(const char *filename, DWORD msgid, DWORD conf, const char *downloadPath = NULL, BOOL downloadAndRun = FALSE);

long PASCAL WcUploadFile(const char *filename, const TNavFullFileRecord *file);
long PASCAL WcUploadFileEx(const char *filename, const TNavFullFileRecord *file, WORD flags);

long PASCAL WcDownloadFileMultiple(HGLOBAL info);
long PASCAL WcDownloadAttachmentMultiple(HGLOBAL info);
long PASCAL WcUploadFileMultiple(HGLOBAL info);
long PASCAL WcUploadFileExMultiple(HGLOBAL info);

long PASCAL WcWriteMessage(const TUserInfo *touser, const TUserInfo *fromuser = NULL, const char *subject = NULL);
long PASCAL WcReadNewMail();

long PASCAL WcWriteUserPage(const char *touser, const char *fromuser, const char *message, DWORD flags);

void PASCAL ConfigureNavigatorSounds();
void PASCAL RegisterNavigatorSound(const char *app, const char *event, const char *defsound);
void PASCAL PlayNavigatorSound(const char *app, const char *event);

long PASCAL WcCheckClientVersion(const char far *clientname, const char far *version);
long PASCAL WcGetClientVersion(char *clientversion, const char *clientname, int maxlen);
long PASCAL WcRunClient(const char far *clientname, const WcRunClientStructure far *sendinfo);
long PASCAL WcRunClientEx(const char far *clientname, const WcRunClientStructure far *sendinfo, DWORD flags);
long PASCAL WcCheckMail();

long PASCAL WcAddUserAddress(HWND parent, WcAddressBookEntry far *entry);
long PASCAL WcGetRecipientList(HWND parent, const char far *addresstype, BOOL carboncopy, HANDLE list);
HANDLE PASCAL WcGetGroupList(const char far *group, const char far *addresstype);
long PASCAL WcManageAddressBook(HWND parent);

void SetCurrentSystemDirty();
const char *GetCurrentSystemName();
const char *GetCurrentSystemRegNo();
BOOL PASCAL IsCustomConnector();
#endif
