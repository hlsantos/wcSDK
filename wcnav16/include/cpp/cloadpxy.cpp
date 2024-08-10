#include <afx.h>
#include <assert.h>

#include "cloadpxy.h"

DWORD wcProxyReference    = 0;
HINSTANCE wcProxyInstance = 0;

void   (PASCAL FAR *lpfnCancelCall)(SOCKET) = NULL;
void   (PASCAL FAR *lpfnCancelByUserData)(SOCKET) = NULL;
WORD   (PASCAL FAR *lpfnGetMaxServerRequestTypes)(void) = NULL;
WORD   (PASCAL FAR *lpfnGetServerVersion)(void) = NULL;
SOCKET (PASCAL FAR *lpfnLoginUser)(HWND, unsigned int, const char *, const char *) = NULL;
SOCKET (PASCAL FAR *lpfnGetTimeLeftOnline)(HWND, unsigned int);
SOCKET (PASCAL FAR *lpfnWriteActivityLogEntry)(HWND, unsigned int, const char *);
SOCKET (PASCAL FAR *lpfnKeepAlive)(HWND, unsigned int);
SOCKET (PASCAL FAR *lpfnGetSystemInfo)(HWND, unsigned int) = NULL;
SOCKET (PASCAL FAR *lpfnGetObjectFlags)(HWND, unsigned int, DWORD) = NULL;
SOCKET (PASCAL FAR *lpfnGetObjectFlagsByName)(HWND, unsigned int, const char *) = NULL;
SOCKET (PASCAL FAR *lpfnGetObjectInfo)(HWND, unsigned int, DWORD, DWORD, const char *) = NULL;
SOCKET (PASCAL FAR *lpfnGetServiceByName)(HWND, unsigned int, const char *) = NULL;
SOCKET (PASCAL FAR *lpfnOpenService)(HWND, unsigned int, const sockaddr_in *, BOOL) = NULL;
SOCKET (PASCAL FAR *lpfnGetServerContextHandle)(HWND, unsigned int);
SOCKET (PASCAL FAR *lpfnGetServerChallengeString)(HWND, unsigned int);
SOCKET (PASCAL FAR *lpfnOpenChannel)(HWND, unsigned int, const char *, BOOL) = NULL;
int    (PASCAL FAR *lpfnWriteChannel)(SOCKET, DWORD, DWORD, void *, DWORD) = NULL;
SOCKET (PASCAL FAR *lpfnGetPredefinedChatChannels)(HWND, unsigned int) = NULL;
SOCKET (PASCAL FAR *lpfnGetUserList)(HWND, unsigned int) = NULL;
SOCKET (PASCAL FAR *lpfnGetWhosOnline)(HWND, unsigned int) = NULL;
SOCKET (PASCAL FAR *lpfnGetUserInfo)(HWND, unsigned int, const char *, DWORD) = NULL;
SOCKET (PASCAL FAR *lpfnGetNodeInfoByName)(HWND, unsigned int, const char *) = NULL;
SOCKET (PASCAL FAR *lpfnSearchUserNames)(HWND, unsigned int, const char *) = NULL;
SOCKET (PASCAL FAR *lpfnGetConferenceCount)(HWND, unsigned int) = NULL;
SOCKET (PASCAL FAR *lpfnGetEffectiveConferenceCount)(HWND, unsigned int) = NULL;
SOCKET (PASCAL FAR *lpfnGetConfDescs)(HWND, unsigned int, BOOL) = NULL;
SOCKET (PASCAL FAR *lpfnListConferencesByNumber)(HWND, unsigned int, DWORD, DWORD) = NULL;
SOCKET (PASCAL FAR *lpfnListConferencesByName)(HWND, unsigned int, const char *, DWORD) = NULL;
SOCKET (PASCAL FAR *lpfnGetVolatileConfInfo)(HWND, unsigned int) = NULL;
SOCKET (PASCAL FAR *lpfnGetVolatileConfInfoEx)(HWND, unsigned int) = NULL;
int    (PASCAL FAR *lpfnGetVolatileConfInfo_SetConfs)(SOCKET, DWORD, DWORD) = NULL;
int    (PASCAL FAR *lpfnGetVolatileConfInfo_SetConfsDone)(SOCKET) = NULL;
SOCKET (PASCAL FAR *lpfnSetLastRead)(HWND, unsigned int, DWORD, DWORD) = NULL;
SOCKET (PASCAL FAR *lpfnGetConferenceGroupCount)(HWND, unsigned int) = NULL;
SOCKET (PASCAL FAR *lpfnGetEffectiveConferenceGroupCount)(HWND, unsigned int) = NULL;
SOCKET (PASCAL FAR *lpfnGetConferenceGroups)(HWND, unsigned int) = NULL;
SOCKET (PASCAL FAR *lpfnGetConferenceGroupAreas)(HWND, unsigned int, DWORD) = NULL;
SOCKET (PASCAL FAR *lpfnSetConferenceFlags)(HWND, unsigned int, DWORD, DWORD) = NULL;
SOCKET (PASCAL FAR *lpfnSetMultipleConferenceFlags)(HWND, unsigned int) = NULL;
int    (PASCAL FAR *lpfnSetMultipleConferenceFlags_SetData)(SOCKET, DWORD, DWORD, DWORD) = NULL;
int    (PASCAL FAR *lpfnSetMultipleConferenceFlags_SetAll)(SOCKET, DWORD) = NULL;
int    (PASCAL FAR *lpfnSetMultipleConferenceFlags_SetDone)(SOCKET) = NULL;
SOCKET (PASCAL FAR *lpfnMarkMessageRead)(HWND, unsigned int, DWORD, DWORD, DWORD) = NULL;
SOCKET (PASCAL FAR *lpfnListMessagesByAreaNumber)(HWND, unsigned int, DWORD, DWORD, DWORD, BOOL, BOOL) = NULL;
SOCKET (PASCAL FAR *lpfnListMessagesByAreaMsgId)(HWND, unsigned int, DWORD, DWORD, DWORD, BOOL, BOOL) = NULL;
SOCKET (PASCAL FAR *lpfnListMessagesByAreaDate)(HWND, unsigned int, DWORD, FILETIME, DWORD, BOOL, BOOL) = NULL;
SOCKET (PASCAL FAR *lpfnListMessagesBySearch)(HWND, unsigned int, const char *, const char *, const char *, const char *, DWORD, DWORD, BOOL, BOOL) = NULL;
SOCKET (PASCAL FAR *lpfnListMessagesByUnread)(HWND, unsigned int, BOOL, BOOL) = NULL;
SOCKET (PASCAL FAR *lpfnListMessagesBackwardsByMsgId)(HWND, unsigned int, DWORD, DWORD, DWORD, BOOL, BOOL) = NULL;
SOCKET (PASCAL FAR *lpfnListMessagesBackwardsByNumber)(HWND, unsigned int, DWORD, DWORD, DWORD, BOOL, BOOL) = NULL;
SOCKET (PASCAL FAR *lpfnListMessagesByAreaNumberEx)(HWND, unsigned int, DWORD, DWORD, DWORD, WORD) = NULL;
SOCKET (PASCAL FAR *lpfnListMessagesByAreaMsgIdEx)(HWND, unsigned int, DWORD, DWORD, DWORD, WORD) = NULL;
SOCKET (PASCAL FAR *lpfnListMessagesByAreaDateEx)(HWND, unsigned int, DWORD, FILETIME, DWORD, WORD) = NULL;
SOCKET (PASCAL FAR *lpfnListMessagesBySearchEx)(HWND, unsigned int, const char *, const char *, const char *, const char *, DWORD, DWORD, WORD) = NULL;
SOCKET (PASCAL FAR *lpfnListMessagesByUnreadEx)(HWND, unsigned int, WORD) = NULL;
SOCKET (PASCAL FAR *lpfnListMessagesBackwardsByMsgIdEx)(HWND, unsigned int, DWORD, DWORD, DWORD, WORD) = NULL;
SOCKET (PASCAL FAR *lpfnListMessagesBackwardsByNumberEx)(HWND, unsigned int, DWORD, DWORD, DWORD, WORD) = NULL;
int    (PASCAL FAR *lpfnSearchMessages_SetConfs)(SOCKET, DWORD, DWORD) = NULL;
int    (PASCAL FAR *lpfnSearchMessages_SetConfsDone)(SOCKET) = NULL;
int    (PASCAL FAR *lpfnGetMoreMessages)(SOCKET, DWORD) = NULL;
int    (PASCAL FAR *lpfnGetAllMessages)(SOCKET) = NULL;
SOCKET (PASCAL FAR *lpfnAddMessage)(HWND, unsigned int, const TNavMsgHeader &) = NULL;
SOCKET (PASCAL FAR *lpfnDeleteMessage)(HWND, unsigned int, const DWORD, const DWORD) = NULL;
SOCKET (PASCAL FAR *lpfnGetCurrentUser)(HWND, unsigned int) = NULL;
SOCKET (PASCAL FAR *lpfnUpdateCurrentUser)(HWND, unsigned int, const TUser &) = NULL;
SOCKET (PASCAL FAR *lpfnGetSecurityProfile)(HWND, unsigned int) = NULL;
SOCKET (PASCAL FAR *lpfnGetDownloadStats)(HWND, unsigned int) = NULL;
SOCKET (PASCAL FAR *lpfnGetFileAreaCount)(HWND, unsigned int) = NULL;
SOCKET (PASCAL FAR *lpfnGetEffectiveFileAreaCount)(HWND, unsigned int) = NULL;
SOCKET (PASCAL FAR *lpfnGetFileAreas)(HWND, unsigned int, BOOL) = NULL;
SOCKET (PASCAL FAR *lpfnGetFileGroupCount)(HWND, unsigned int) = NULL;
SOCKET (PASCAL FAR *lpfnGetEffectiveFileGroupCount)(HWND, unsigned int) = NULL;
SOCKET (PASCAL FAR *lpfnGetFileGroups)(HWND, unsigned int, BOOL) = NULL;
SOCKET (PASCAL FAR *lpfnGetFileGroupAreas)(HWND, unsigned int, DWORD) = NULL;
SOCKET (PASCAL FAR *lpfnListFilesByName)(HWND, unsigned int, DWORD) = NULL;
SOCKET (PASCAL FAR *lpfnListFilesByDate)(HWND, unsigned int, DWORD, const FILETIME &) = NULL;
SOCKET (PASCAL FAR *lpfnListFilesBySearch)(HWND, unsigned int, DWORD, const char *) = NULL;
int    (PASCAL FAR *lpfnGetMoreFiles)(SOCKET, DWORD) = NULL;
int    (PASCAL FAR *lpfnGetAllFiles)(SOCKET) = NULL;
int    (PASCAL FAR *lpfnPauseFileList)(SOCKET) = NULL;
SOCKET (PASCAL FAR *lpfnResolveFileName)(HWND, unsigned int, const char *) = NULL;
int    (PASCAL FAR *lpfnSetFileArea)(SOCKET, WORD, WORD) = NULL;
int    (PASCAL FAR *lpfnSetFileAreaDone)(SOCKET) = NULL;
SOCKET (PASCAL FAR *lpfnGetFileDescription)(HWND, unsigned int, WORD, const char *) = NULL;
SOCKET (PASCAL FAR *lpfnUpdateFileInfo)(HWND,
                                        unsigned int,
                                        const char *,
                                        DWORD,
                                        const char *,
                                        const char *,
                                        const char *,
                                        BOOL, WORD,
                                        const char *) = NULL;
SOCKET (PASCAL FAR *lpfnDeleteFile)(HWND, unsigned int, WORD, const char *, BOOL) = NULL;
SOCKET (PASCAL FAR *lpfnViewArchive)(HWND, unsigned int, WORD, const char *) = NULL;
SOCKET (PASCAL FAR *lpfnRequestOfflineFiles)(HWND, unsigned int) = NULL;
int    (PASCAL FAR *lpfnRequestOfflineFiles_Submit)(SOCKET, const char *, DWORD) = NULL;
int    (PASCAL FAR *lpfnRequestOfflineFiles_Done)(SOCKET) = NULL;
SOCKET (PASCAL FAR *lpfnDownloadFile)(HWND, unsigned int, const char *, DWORD, DWORD) = NULL;
SOCKET (PASCAL FAR *lpfnUploadFile)(HWND, unsigned int, TNavFullFileRecord &) = NULL;
SOCKET (PASCAL FAR *lpfnUploadFileEx)(HWND, unsigned int, TNavFullFileRecord &, WORD flags) = NULL;
SOCKET (PASCAL FAR *lpfnUploadMessageAttachment)(HWND, unsigned int, DWORD) = NULL;
int    (PASCAL FAR *lpfnSetAttachmentMessage)(SOCKET, WORD, DWORD) = NULL;
int    (PASCAL FAR *lpfnSetAttachmentMessageDone)(SOCKET) = NULL;
int    (PASCAL FAR *lpfnSendFileData)(SOCKET, const void *, WORD) = NULL;
SOCKET (PASCAL FAR *lpfnCopyBeforeDownload)(HWND, unsigned int) = NULL;
int    (PASCAL FAR *lpfnCopyBeforeDownload_Submit)(SOCKET, DWORD, DWORD, const char *) = NULL;
int    (PASCAL FAR *lpfnCopyBeforeDownload_Remove)(SOCKET, DWORD) = NULL;
SOCKET (PASCAL FAR *lpfnGetPackageVersion)(HWND, unsigned int, const char *, const char *) = NULL;
int    (PASCAL FAR *lpfnSendMoreData)(SOCKET, const void *, WORD) = NULL;

BOOL LoadProxyLibrary()
{
  if (wcProxyReference == 0) {
    wcProxyInstance = LoadLibrary(NAV_WCPROXY_DLL);
    if (wcProxyInstance > HINSTANCE_ERROR) {
      wcProxyReference++;
      (FARPROC&) lpfnCancelCall = GetProcAddress(wcProxyInstance, "CancelCall"); assert(lpfnCancelCall != NULL);
      (FARPROC&) lpfnCancelByUserData = GetProcAddress(wcProxyInstance, "CancelByUserData"); assert(lpfnCancelByUserData != NULL);
      (FARPROC&) lpfnGetMaxServerRequestTypes = GetProcAddress(wcProxyInstance, "GetMaxServerRequestTypes"); assert(lpfnGetMaxServerRequestTypes != NULL);
      (FARPROC&) lpfnGetServerVersion = GetProcAddress(wcProxyInstance, "GetServerVersion"); assert(lpfnGetServerVersion != NULL);
      (FARPROC&) lpfnLoginUser = GetProcAddress(wcProxyInstance, "LoginUser"); assert(lpfnLoginUser != NULL);
      (FARPROC&) lpfnGetTimeLeftOnline = GetProcAddress(wcProxyInstance, "GetTimeLeftOnline"); assert(lpfnGetTimeLeftOnline != NULL);
      (FARPROC&) lpfnWriteActivityLogEntry = GetProcAddress(wcProxyInstance, "WriteActivityLogEntry"); assert(lpfnWriteActivityLogEntry != NULL);
      (FARPROC&) lpfnKeepAlive = GetProcAddress(wcProxyInstance, "KeepAlive"); assert(lpfnKeepAlive != NULL);
      (FARPROC&) lpfnGetSystemInfo = GetProcAddress(wcProxyInstance, "GetSystemInfo"); assert(lpfnGetSystemInfo != NULL);
      (FARPROC&) lpfnGetObjectFlags = GetProcAddress(wcProxyInstance, "GetObjectFlags"); assert(lpfnGetObjectFlags != NULL);
      (FARPROC&) lpfnGetObjectFlagsByName = GetProcAddress(wcProxyInstance, "GetObjectFlagsByName"); assert(lpfnGetObjectFlagsByName != NULL);
      (FARPROC&) lpfnGetObjectInfo = GetProcAddress(wcProxyInstance, "GetObjectInfo"); assert(lpfnGetObjectInfo != NULL);
      (FARPROC&) lpfnGetServiceByName = GetProcAddress(wcProxyInstance, "GetServiceByName"); assert(lpfnGetServiceByName != NULL);
      (FARPROC&) lpfnOpenService = GetProcAddress(wcProxyInstance, "OpenService"); assert(lpfnOpenService != NULL);
      (FARPROC&) lpfnGetServerContextHandle = GetProcAddress(wcProxyInstance, "GetServerContextHandle"); assert(lpfnGetServerContextHandle != NULL);
      (FARPROC&) lpfnGetServerChallengeString = GetProcAddress(wcProxyInstance, "GetServerChallengeString"); assert(lpfnGetServerChallengeString != NULL);
      (FARPROC&) lpfnOpenChannel = GetProcAddress(wcProxyInstance, "OpenChannel"); assert(lpfnOpenChannel != NULL);
      (FARPROC&) lpfnWriteChannel = GetProcAddress(wcProxyInstance, "WriteChannel"); assert(lpfnWriteChannel != NULL);
      (FARPROC&) lpfnGetPredefinedChatChannels = GetProcAddress(wcProxyInstance, "GetPredefinedChatChannels"); assert(lpfnGetPredefinedChatChannels != NULL);
      (FARPROC&) lpfnGetUserList = GetProcAddress(wcProxyInstance, "GetUserList"); assert(lpfnGetUserList != NULL);
      (FARPROC&) lpfnGetWhosOnline = GetProcAddress(wcProxyInstance, "GetWhosOnline"); assert(lpfnGetWhosOnline != NULL);
      (FARPROC&) lpfnGetUserInfo = GetProcAddress(wcProxyInstance, "GetUserInfo"); assert(lpfnGetUserInfo != NULL);
      (FARPROC&) lpfnGetNodeInfoByName = GetProcAddress(wcProxyInstance, "GetNodeInfoByName"); assert(lpfnGetNodeInfoByName != NULL);
      (FARPROC&) lpfnSearchUserNames = GetProcAddress(wcProxyInstance, "SearchUserNames"); assert(lpfnSearchUserNames != NULL);
      (FARPROC&) lpfnGetConferenceCount = GetProcAddress(wcProxyInstance, "GetConferenceCount"); assert(lpfnGetConferenceCount != NULL);
      (FARPROC&) lpfnGetEffectiveConferenceCount = GetProcAddress(wcProxyInstance, "GetEffectiveConferenceCount"); assert(lpfnGetEffectiveConferenceCount != NULL);
      (FARPROC&) lpfnGetConfDescs = GetProcAddress(wcProxyInstance, "GetConfDescs"); assert(lpfnGetConfDescs != NULL);
      (FARPROC&) lpfnListConferencesByNumber = GetProcAddress(wcProxyInstance, "ListConferencesByNumber"); assert(lpfnListConferencesByNumber != NULL);
      (FARPROC&) lpfnListConferencesByName = GetProcAddress(wcProxyInstance, "ListConferencesByName"); assert(lpfnListConferencesByName != NULL);
      (FARPROC&) lpfnGetVolatileConfInfo = GetProcAddress(wcProxyInstance, "GetVolatileConfInfo"); assert(lpfnGetVolatileConfInfo);
      (FARPROC&) lpfnGetVolatileConfInfoEx = GetProcAddress(wcProxyInstance, "GetVolatileConfInfoEx"); assert(lpfnGetVolatileConfInfoEx);
      (FARPROC&) lpfnGetVolatileConfInfo_SetConfs = GetProcAddress(wcProxyInstance, "GetVolatileConfInfo_SetConfs"); assert(lpfnGetVolatileConfInfo_SetConfs);
      (FARPROC&) lpfnGetVolatileConfInfo_SetConfsDone = GetProcAddress(wcProxyInstance, "GetVolatileConfInfo_SetConfsDone"); assert(lpfnGetVolatileConfInfo_SetConfsDone);
      (FARPROC&) lpfnSetLastRead = GetProcAddress(wcProxyInstance, "SetLastRead"); assert(lpfnSetLastRead != NULL);
      (FARPROC&) lpfnGetConferenceGroupCount = GetProcAddress(wcProxyInstance, "GetConferenceGroupCount"); assert(lpfnGetConferenceGroupCount != NULL);
      (FARPROC&) lpfnGetEffectiveConferenceGroupCount = GetProcAddress(wcProxyInstance, "GetEffectiveConferenceGroupCount"); assert(lpfnGetEffectiveConferenceGroupCount != NULL);
      (FARPROC&) lpfnGetConferenceGroups = GetProcAddress(wcProxyInstance, "GetConferenceGroups"); assert(lpfnGetConferenceGroups != NULL);
      (FARPROC&) lpfnGetConferenceGroupAreas = GetProcAddress(wcProxyInstance, "GetConferenceGroupAreas"); assert(lpfnGetConferenceGroupAreas != NULL);
      (FARPROC&) lpfnSetConferenceFlags = GetProcAddress(wcProxyInstance, "SetConferenceFlags"); assert(lpfnSetConferenceFlags != NULL);
      (FARPROC&) lpfnSetMultipleConferenceFlags = GetProcAddress(wcProxyInstance, "SetMultipleConferenceFlags"); assert(lpfnSetMultipleConferenceFlags != NULL);
      (FARPROC&) lpfnSetMultipleConferenceFlags_SetData = GetProcAddress(wcProxyInstance, "SetMultipleConferenceFlags_SetData"); assert(lpfnSetMultipleConferenceFlags_SetData != NULL);
      (FARPROC&) lpfnSetMultipleConferenceFlags_SetAll = GetProcAddress(wcProxyInstance, "SetMultipleConferenceFlags_SetAll"); assert(lpfnSetMultipleConferenceFlags_SetAll != NULL);
      (FARPROC&) lpfnSetMultipleConferenceFlags_SetDone = GetProcAddress(wcProxyInstance, "SetMultipleConferenceFlags_SetDone"); assert(lpfnSetMultipleConferenceFlags_SetDone != NULL);
      (FARPROC&) lpfnMarkMessageRead = GetProcAddress(wcProxyInstance, "MarkMessageRead"); assert(lpfnMarkMessageRead != NULL);
      (FARPROC&) lpfnListMessagesByAreaNumber = GetProcAddress(wcProxyInstance, "ListMessagesByAreaNumber"); assert(lpfnListMessagesByAreaNumber != NULL);
      (FARPROC&) lpfnListMessagesByAreaMsgId = GetProcAddress(wcProxyInstance, "ListMessagesByAreaMsgId"); assert(lpfnListMessagesByAreaMsgId != NULL);
      (FARPROC&) lpfnListMessagesByAreaDate = GetProcAddress(wcProxyInstance, "ListMessagesByAreaDate"); assert(lpfnListMessagesByAreaDate != NULL);
      (FARPROC&) lpfnListMessagesBySearch = GetProcAddress(wcProxyInstance, "ListMessagesBySearch"); assert(lpfnListMessagesBySearch != NULL);
      (FARPROC&) lpfnListMessagesByUnread = GetProcAddress(wcProxyInstance, "ListMessagesByUnread"); assert(lpfnListMessagesByUnread != NULL);
      (FARPROC&) lpfnListMessagesBackwardsByMsgId = GetProcAddress(wcProxyInstance, "ListMessagesBackwardsByMsgId"); assert(lpfnListMessagesBackwardsByMsgId != NULL);
      (FARPROC&) lpfnListMessagesBackwardsByNumber = GetProcAddress(wcProxyInstance, "ListMessagesBackwardsByNumber"); assert(lpfnListMessagesBackwardsByNumber != NULL);
      (FARPROC&) lpfnListMessagesByAreaNumberEx = GetProcAddress(wcProxyInstance, "ListMessagesByAreaNumberEx"); assert(lpfnListMessagesByAreaNumberEx != NULL);
      (FARPROC&) lpfnListMessagesByAreaMsgIdEx = GetProcAddress(wcProxyInstance, "ListMessagesByAreaMsgIdEx"); assert(lpfnListMessagesByAreaMsgIdEx != NULL);
      (FARPROC&) lpfnListMessagesByAreaDateEx = GetProcAddress(wcProxyInstance, "ListMessagesByAreaDateEx"); assert(lpfnListMessagesByAreaDateEx != NULL);
      (FARPROC&) lpfnListMessagesBySearchEx = GetProcAddress(wcProxyInstance, "ListMessagesBySearchEx"); assert(lpfnListMessagesBySearchEx != NULL);
      (FARPROC&) lpfnListMessagesByUnreadEx = GetProcAddress(wcProxyInstance, "ListMessagesByUnreadEx"); assert(lpfnListMessagesByUnreadEx != NULL);
      (FARPROC&) lpfnListMessagesBackwardsByMsgIdEx = GetProcAddress(wcProxyInstance, "ListMessagesBackwardsByMsgIdEx"); assert(lpfnListMessagesBackwardsByMsgIdEx != NULL);
      (FARPROC&) lpfnListMessagesBackwardsByNumberEx = GetProcAddress(wcProxyInstance, "ListMessagesBackwardsByNumberEx"); assert(lpfnListMessagesBackwardsByNumberEx != NULL);
      (FARPROC&) lpfnSearchMessages_SetConfs = GetProcAddress(wcProxyInstance, "SearchMessages_SetConfs"); assert(lpfnSearchMessages_SetConfs != NULL);
      (FARPROC&) lpfnSearchMessages_SetConfsDone = GetProcAddress(wcProxyInstance, "SearchMessages_SetConfsDone"); assert(lpfnSearchMessages_SetConfsDone != NULL);
      (FARPROC&) lpfnGetMoreMessages = GetProcAddress(wcProxyInstance, "GetMoreMessages"); assert(lpfnGetMoreMessages != NULL);
      (FARPROC&) lpfnGetAllMessages = GetProcAddress(wcProxyInstance, "GetAllMessages"); assert(lpfnGetAllMessages != NULL);
      (FARPROC&) lpfnAddMessage = GetProcAddress(wcProxyInstance, "AddMessage"); assert(lpfnAddMessage != NULL);
      (FARPROC&) lpfnDeleteMessage = GetProcAddress(wcProxyInstance, "DeleteMessage"); assert(lpfnDeleteMessage != NULL);
      (FARPROC&) lpfnGetCurrentUser = GetProcAddress(wcProxyInstance, "GetCurrentUser"); assert(lpfnGetCurrentUser != NULL);
      (FARPROC&) lpfnUpdateCurrentUser = GetProcAddress(wcProxyInstance, "UpdateCurrentUser"); assert(lpfnUpdateCurrentUser != NULL);
      (FARPROC&) lpfnGetSecurityProfile = GetProcAddress(wcProxyInstance, "GetSecurityProfile"); assert(lpfnGetSecurityProfile != NULL);
      (FARPROC&) lpfnGetDownloadStats = GetProcAddress(wcProxyInstance, "GetDownloadStats"); assert(lpfnGetDownloadStats != NULL);
      (FARPROC&) lpfnGetFileAreaCount = GetProcAddress(wcProxyInstance, "GetFileAreaCount"); assert(lpfnGetFileAreaCount != NULL);
      (FARPROC&) lpfnGetEffectiveFileAreaCount = GetProcAddress(wcProxyInstance, "GetEffectiveFileAreaCount"); assert(lpfnGetEffectiveFileAreaCount != NULL);
      (FARPROC&) lpfnGetFileAreas = GetProcAddress(wcProxyInstance, "GetFileAreas"); assert(lpfnGetFileAreas != NULL);
      (FARPROC&) lpfnGetFileGroupCount = GetProcAddress(wcProxyInstance, "GetFileGroupCount"); assert(lpfnGetFileGroupCount != NULL);
      (FARPROC&) lpfnGetEffectiveFileGroupCount = GetProcAddress(wcProxyInstance, "GetEffectiveFileGroupCount"); assert(lpfnGetEffectiveFileGroupCount != NULL);
      (FARPROC&) lpfnGetFileGroups = GetProcAddress(wcProxyInstance, "GetFileGroups"); assert(lpfnGetFileGroups != NULL);
      (FARPROC&) lpfnGetFileGroupAreas = GetProcAddress(wcProxyInstance, "GetFileGroupAreas"); assert(lpfnGetFileGroupAreas != NULL);
      (FARPROC&) lpfnListFilesByName = GetProcAddress(wcProxyInstance, "ListFilesByName"); assert(lpfnListFilesByName != NULL);
      (FARPROC&) lpfnListFilesByDate = GetProcAddress(wcProxyInstance, "ListFilesByDate"); assert(lpfnListFilesByDate != NULL);
      (FARPROC&) lpfnListFilesBySearch = GetProcAddress(wcProxyInstance, "ListFilesBySearch"); assert(lpfnListFilesBySearch != NULL);
      (FARPROC&) lpfnGetMoreFiles = GetProcAddress(wcProxyInstance, "GetMoreFiles"); assert(lpfnGetMoreFiles != NULL);
      (FARPROC&) lpfnGetAllFiles = GetProcAddress(wcProxyInstance, "GetAllFiles"); assert(lpfnGetAllFiles != NULL);
      (FARPROC&) lpfnPauseFileList = GetProcAddress(wcProxyInstance, "PauseFileList"); assert(lpfnPauseFileList != NULL);
      (FARPROC&) lpfnResolveFileName = GetProcAddress(wcProxyInstance, "ResolveFileName"); assert(lpfnResolveFileName != NULL);
      (FARPROC&) lpfnSetFileArea = GetProcAddress(wcProxyInstance, "SetFileArea"); assert(lpfnSetFileArea != NULL);
      (FARPROC&) lpfnSetFileAreaDone = GetProcAddress(wcProxyInstance, "SetFileAreaDone"); assert(lpfnSetFileAreaDone != NULL);
      (FARPROC&) lpfnGetFileDescription = GetProcAddress(wcProxyInstance, "GetFileDescription"); assert(lpfnGetFileDescription != NULL);
      (FARPROC&) lpfnUpdateFileInfo = GetProcAddress(wcProxyInstance, "UpdateFileInfo"); assert(lpfnUpdateFileInfo != NULL);
      (FARPROC&) lpfnDeleteFile = GetProcAddress(wcProxyInstance, "DeleteFile"); assert(lpfnDeleteFile != NULL);
      (FARPROC&) lpfnViewArchive = GetProcAddress(wcProxyInstance, "ViewArchive"); assert(lpfnViewArchive != NULL);
      (FARPROC&) lpfnRequestOfflineFiles = GetProcAddress(wcProxyInstance, "RequestOfflineFiles"); assert(lpfnRequestOfflineFiles != NULL);
      (FARPROC&) lpfnRequestOfflineFiles_Submit = GetProcAddress(wcProxyInstance, "RequestOfflineFiles_Submit"); assert(lpfnRequestOfflineFiles_Submit != NULL);
      (FARPROC&) lpfnRequestOfflineFiles_Done = GetProcAddress(wcProxyInstance, "RequestOfflineFiles_Done"); assert(lpfnRequestOfflineFiles_Done != NULL);
      (FARPROC&) lpfnDownloadFile = GetProcAddress(wcProxyInstance, "DownloadFile"); assert(lpfnDownloadFile != NULL);
      (FARPROC&) lpfnUploadFile = GetProcAddress(wcProxyInstance, "UploadFile"); assert(lpfnUploadFile != NULL);
      (FARPROC&) lpfnUploadFileEx = GetProcAddress(wcProxyInstance, "UploadFileEx"); assert(lpfnUploadFileEx != NULL);
      (FARPROC&) lpfnUploadMessageAttachment = GetProcAddress(wcProxyInstance, "UploadMessageAttachment"); assert(lpfnUploadMessageAttachment != NULL);
      (FARPROC&) lpfnSetAttachmentMessage = GetProcAddress(wcProxyInstance, "SetAttachmentMessage"); assert(lpfnSetAttachmentMessage != NULL);
      (FARPROC&) lpfnSetAttachmentMessageDone = GetProcAddress(wcProxyInstance, "SetAttachmentMessageDone"); assert(lpfnSetAttachmentMessageDone != NULL);
      (FARPROC&) lpfnSendFileData = GetProcAddress(wcProxyInstance, "SendFileData"); assert(lpfnSendFileData != NULL);
      (FARPROC&) lpfnCopyBeforeDownload = GetProcAddress(wcProxyInstance, "CopyBeforeDownload"); assert(lpfnCopyBeforeDownload != NULL);
      (FARPROC&) lpfnCopyBeforeDownload_Submit = GetProcAddress(wcProxyInstance, "CopyBeforeDownload_Submit"); assert(lpfnCopyBeforeDownload_Submit != NULL);
      (FARPROC&) lpfnCopyBeforeDownload_Remove = GetProcAddress(wcProxyInstance, "CopyBeforeDownload_Remove"); assert(lpfnCopyBeforeDownload_Remove != NULL);
      (FARPROC&) lpfnGetPackageVersion = GetProcAddress(wcProxyInstance, "GetPackageVersion"); assert(lpfnGetPackageVersion != NULL);
      (FARPROC&) lpfnSendMoreData = GetProcAddress(wcProxyInstance, "SendMoreData"); assert(lpfnSendMoreData != NULL);
      return TRUE;
    }
    return FALSE;
  }
  wcProxyReference++;
  return TRUE;
}

void FreeProxyLibrary()
{
  if (wcProxyReference == 1) {
    if (wcProxyInstance > HINSTANCE_ERROR) {
      lpfnCancelCall = NULL;
      lpfnCancelByUserData = NULL;
      lpfnGetMaxServerRequestTypes = NULL;
      lpfnGetServerVersion = NULL;
      lpfnLoginUser = NULL;
      lpfnGetTimeLeftOnline = NULL;
      lpfnWriteActivityLogEntry = NULL;
      lpfnKeepAlive = NULL;
      lpfnGetSystemInfo = NULL;
      lpfnGetObjectFlags = NULL;
      lpfnGetObjectFlagsByName = NULL;
      lpfnGetObjectInfo = NULL;
      lpfnGetServiceByName = NULL;
      lpfnOpenService = NULL;
      lpfnGetServerContextHandle = NULL;
      lpfnGetServerChallengeString = NULL;
      lpfnOpenChannel = NULL;
      lpfnWriteChannel = NULL;
      lpfnGetPredefinedChatChannels = NULL;
      lpfnGetUserList = NULL;
      lpfnGetWhosOnline = NULL;
      lpfnGetUserInfo = NULL;
      lpfnGetNodeInfoByName = NULL;
      lpfnSearchUserNames = NULL;
      lpfnGetConferenceCount = NULL;
      lpfnGetEffectiveConferenceCount = NULL;
      lpfnGetConfDescs = NULL;
      lpfnListConferencesByNumber = NULL;
      lpfnListConferencesByName = NULL;
      lpfnGetVolatileConfInfo = NULL;
      lpfnGetVolatileConfInfoEx = NULL;
      lpfnGetVolatileConfInfo_SetConfs = NULL;
      lpfnGetVolatileConfInfo_SetConfsDone = NULL;
      lpfnSetLastRead = NULL;
      lpfnGetConferenceGroupCount = NULL;
      lpfnGetEffectiveConferenceGroupCount = NULL;
      lpfnGetConferenceGroups = NULL;
      lpfnGetConferenceGroupAreas = NULL;
      lpfnSetConferenceFlags = NULL;
      lpfnSetMultipleConferenceFlags = NULL;
      lpfnSetMultipleConferenceFlags_SetData = NULL;
      lpfnSetMultipleConferenceFlags_SetAll = NULL;
      lpfnSetMultipleConferenceFlags_SetDone = NULL;
      lpfnMarkMessageRead = NULL;
      lpfnListMessagesByAreaNumber = NULL;
      lpfnListMessagesByAreaMsgId = NULL;
      lpfnListMessagesByAreaDate = NULL;
      lpfnListMessagesBySearch = NULL;
      lpfnListMessagesByUnread = NULL;
      lpfnListMessagesBackwardsByMsgId = NULL;
      lpfnListMessagesBackwardsByNumber = NULL;
      lpfnListMessagesByAreaNumberEx = NULL;
      lpfnListMessagesByAreaMsgIdEx = NULL;
      lpfnListMessagesByAreaDateEx = NULL;
      lpfnListMessagesBySearchEx = NULL;
      lpfnListMessagesByUnreadEx = NULL;
      lpfnListMessagesBackwardsByMsgIdEx = NULL;
      lpfnListMessagesBackwardsByNumberEx = NULL;
      lpfnSearchMessages_SetConfs = NULL;
      lpfnSearchMessages_SetConfsDone = NULL;
      lpfnGetMoreMessages = NULL;
      lpfnGetAllMessages = NULL;
      lpfnAddMessage = NULL;
      lpfnDeleteMessage = NULL;
      lpfnGetCurrentUser = NULL;
      lpfnUpdateCurrentUser = NULL;
      lpfnGetSecurityProfile = NULL;
      lpfnGetDownloadStats = NULL;
      lpfnGetFileAreaCount = NULL;
      lpfnGetEffectiveFileAreaCount = NULL;
      lpfnGetFileAreas = NULL;
      lpfnGetFileGroupCount = NULL;
      lpfnGetEffectiveFileGroupCount = NULL;
      lpfnGetFileGroups = NULL;
      lpfnGetFileGroupAreas = NULL;
      lpfnListFilesByName = NULL;
      lpfnListFilesByDate = NULL;
      lpfnListFilesBySearch = NULL;
      lpfnGetMoreFiles = NULL;
      lpfnGetAllFiles = NULL;
      lpfnPauseFileList = NULL;
      lpfnResolveFileName = NULL;
      lpfnSetFileArea = NULL;
      lpfnSetFileAreaDone = NULL;
      lpfnGetFileDescription = NULL;
      lpfnUpdateFileInfo = NULL;
      lpfnDeleteFile = NULL;
      lpfnViewArchive = NULL;
      lpfnRequestOfflineFiles = NULL;
      lpfnRequestOfflineFiles_Submit = NULL;
      lpfnRequestOfflineFiles_Done = NULL;
      lpfnDownloadFile = NULL;
      lpfnUploadFile = NULL;
      lpfnUploadFileEx = NULL;
      lpfnUploadMessageAttachment = NULL;
      lpfnSetAttachmentMessage = NULL;
      lpfnSetAttachmentMessageDone = NULL;
      lpfnSendFileData = NULL;
      lpfnCopyBeforeDownload = NULL;
      lpfnCopyBeforeDownload_Submit = NULL;
      lpfnCopyBeforeDownload_Remove = NULL;
      lpfnGetPackageVersion = NULL;
      lpfnSendMoreData = NULL;
      FreeLibrary(wcProxyInstance);
    }
  }
  wcProxyReference--;
}

void CancelCall(SOCKET s)
{
  if (lpfnCancelCall == NULL) {
    assert(FALSE);
    return;
  }
  lpfnCancelCall(s);
}

void CancelByUserData(SOCKET s)
{
  if (lpfnCancelByUserData == NULL) {
    assert(FALSE);
    return;
  }
  lpfnCancelByUserData(s);
}

WORD GetMaxServerRequestTypes()
{
  if (lpfnGetMaxServerRequestTypes == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnGetMaxServerRequestTypes();
}

WORD GetServerVersion()
{
  if (lpfnGetServerVersion == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnGetServerVersion();
}

SOCKET LoginUser(HWND hWnd, unsigned int wMsg, const char *name, const char *password)
{
  if (lpfnLoginUser == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnLoginUser(hWnd, wMsg, name, password);
}

SOCKET GetTimeLeftOnline(HWND hWnd, unsigned int wMsg)
{
  if (lpfnGetTimeLeftOnline == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnGetTimeLeftOnline(hWnd, wMsg);
}

SOCKET WriteActivityLogEntry(HWND hWnd, unsigned int wMsg, const char *text)
{
  if (lpfnWriteActivityLogEntry == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnWriteActivityLogEntry(hWnd, wMsg, text);
}

SOCKET KeepAlive(HWND hWnd, unsigned int wMsg)
{
  if (lpfnKeepAlive == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnKeepAlive(hWnd, wMsg);
}

SOCKET GetSystemInfo(HWND hWnd, unsigned int wMsg)
{
  if (lpfnGetSystemInfo == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnGetSystemInfo(hWnd, wMsg);
}

SOCKET GetObjectFlags(HWND hWnd, unsigned int wMsg, DWORD objectID)
{
  if (lpfnGetObjectFlags == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnGetObjectFlags(hWnd, wMsg, objectID);
}

SOCKET GetObjectFlagsByName(HWND hWnd, unsigned int wMsg, const char *objectname)
{
  if (lpfnGetObjectFlagsByName == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnGetObjectFlagsByName(hWnd, wMsg, objectname);
}
                
SOCKET GetObjectInfo(HWND hWnd, unsigned int wMsg, DWORD objectid, DWORD objectclass, const char *objectname)
{
  if (lpfnGetObjectInfo == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnGetObjectInfo(hWnd, wMsg, objectid, objectclass, objectname);
}
                
SOCKET GetServiceByName(HWND hWnd, unsigned int wMsg, const char *name)
{
  if (lpfnGetServiceByName == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnGetServiceByName(hWnd, wMsg, name);
}

SOCKET OpenService(HWND hWnd, unsigned int wMsg, const sockaddr_in *addr, BOOL timeout)
{                                               
  if (lpfnOpenService == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnOpenService(hWnd, wMsg, addr, timeout);
}
                  
SOCKET GetServerContextHandle(HWND hWnd, unsigned int wMsg)
{
  if (lpfnGetServerContextHandle == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnGetServerContextHandle(hWnd, wMsg);
}                  

SOCKET GetServerChallengeString(HWND hWnd, unsigned int wMsg)
{
  if (lpfnGetServerChallengeString == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }                     
  return lpfnGetServerChallengeString(hWnd, wMsg);
}
                                                                                
SOCKET OpenChannel(HWND hWnd, unsigned int wMsg, const char *name, BOOL timeout)
{
  if (lpfnOpenChannel == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnOpenChannel(hWnd, wMsg, name, timeout);
}

int WriteChannel(SOCKET chandle, DWORD dest, DWORD userdata, void *data, DWORD datasize)
{
  if (lpfnWriteChannel == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnWriteChannel(chandle, dest, userdata, data, datasize);
}
                
SOCKET GetPredefinedChatChannels(HWND hWnd, unsigned int wMsg)
{
  if (lpfnGetPredefinedChatChannels == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }                     
  return lpfnGetPredefinedChatChannels(hWnd, wMsg);
}
                
SOCKET GetUserList(HWND hWnd, unsigned int wMsg)
{
  if (lpfnGetUserList == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnGetUserList(hWnd, wMsg);
}

SOCKET GetWhosOnline(HWND hWnd, unsigned int wMsg)
{
  if (lpfnGetWhosOnline == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnGetWhosOnline(hWnd, wMsg);
}

SOCKET GetUserInfo(HWND hWnd, unsigned int wMsg, const char *username, DWORD userid)
{
  if (lpfnGetUserInfo == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnGetUserInfo(hWnd, wMsg, username, userid);
}

SOCKET GetNodeInfoByName(HWND hWnd, unsigned int wMsg, const char *username)
{
  if (lpfnGetNodeInfoByName == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnGetNodeInfoByName(hWnd, wMsg, username);
}

SOCKET SearchUserNames(HWND hWnd, unsigned int wMsg, const char *username)
{
  if (lpfnSearchUserNames == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnSearchUserNames(hWnd, wMsg, username);
}

SOCKET GetConferenceCount(HWND hWnd, unsigned int wMsg)
{
  if (lpfnGetConferenceCount == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnGetConferenceCount(hWnd, wMsg);
}

SOCKET GetEffectiveConferenceCount(HWND hWnd, unsigned int wMsg)
{
  if (lpfnGetEffectiveConferenceCount == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnGetEffectiveConferenceCount(hWnd, wMsg);
}

SOCKET GetConfDescs(HWND hWnd, unsigned int wMsg, BOOL sorted)
{
  if (lpfnGetConfDescs == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnGetConfDescs(hWnd, wMsg, sorted);
}

SOCKET ListConferencesByNumber(HWND hWnd, unsigned int wMsg, DWORD start, DWORD count)
{
  if (lpfnListConferencesByNumber == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnListConferencesByNumber(hWnd, wMsg, start, count);
}

SOCKET ListConferencesByName(HWND hWnd, unsigned int wMsg, const char *name, DWORD count)
{
  if (lpfnListConferencesByName == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnListConferencesByName(hWnd, wMsg, name, count);
}

SOCKET GetVolatileConfInfo(HWND hWnd, unsigned int wMsg)
{
  if (lpfnGetVolatileConfInfo == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnGetVolatileConfInfo(hWnd, wMsg);
}

SOCKET GetVolatileConfInfoEx(HWND hWnd, unsigned int wMsg)
{
  if (lpfnGetVolatileConfInfoEx == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnGetVolatileConfInfoEx(hWnd, wMsg);
}

int GetVolatileConfInfo_SetConfs(SOCKET s, DWORD start, DWORD count)
{
  if (lpfnGetVolatileConfInfo_SetConfs == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnGetVolatileConfInfo_SetConfs(s, start, count);
}

int GetVolatileConfInfo_SetConfsDone(SOCKET s)
{
  if (lpfnGetVolatileConfInfo_SetConfsDone == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnGetVolatileConfInfo_SetConfsDone(s);
}

SOCKET SetLastRead(HWND hWnd, unsigned int wMsg, DWORD conference, DWORD lastread)
{
  if (lpfnSetLastRead == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnSetLastRead(hWnd, wMsg, conference, lastread);
}

SOCKET GetConferenceGroupCount(HWND hWnd, unsigned int wMsg)
{
  if (lpfnGetConferenceGroupCount == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnGetConferenceGroupCount(hWnd, wMsg);
}

SOCKET GetEffectiveConferenceGroupCount(HWND hWnd, unsigned int wMsg)
{
  if (lpfnGetEffectiveConferenceGroupCount == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnGetEffectiveConferenceGroupCount(hWnd, wMsg);
}

SOCKET GetConferenceGroups(HWND hWnd, unsigned int wMsg)
{
  if (lpfnGetConferenceGroups == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnGetConferenceGroups(hWnd, wMsg);
}

SOCKET GetConferenceGroupAreas(HWND hWnd, unsigned int wMsg, DWORD group)
{
  if (lpfnGetConferenceGroupAreas == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnGetConferenceGroupAreas(hWnd, wMsg, group);
}

SOCKET SetConferenceFlags(HWND hWnd, unsigned int wMsg, DWORD conference, DWORD flags)
{
  if (lpfnSetConferenceFlags == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnSetConferenceFlags(hWnd, wMsg, conference, flags);
}

SOCKET SetMultipleConferenceFlags(HWND hWnd, unsigned int wMsg)
{
  if (lpfnSetMultipleConferenceFlags == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnSetMultipleConferenceFlags(hWnd, wMsg);
}

int SetMultipleConferenceFlags_SetData(SOCKET s, DWORD start, DWORD runlength, DWORD flags)
{
  if (lpfnSetMultipleConferenceFlags_SetData == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnSetMultipleConferenceFlags_SetData(s, start, runlength, flags);
}

int SetMultipleConferenceFlags_SetAll(SOCKET s, DWORD flags)
{
  if (lpfnSetMultipleConferenceFlags_SetAll == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnSetMultipleConferenceFlags_SetAll(s, flags);
}

int SetMultipleConferenceFlags_SetDone(SOCKET s)
{
  if (lpfnSetMultipleConferenceFlags_SetDone == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnSetMultipleConferenceFlags_SetDone(s);
}

SOCKET MarkMessageRead(HWND hWnd, unsigned int wMsg, DWORD conference, DWORD msgid, DWORD flags)
{
  if (lpfnMarkMessageRead == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnMarkMessageRead(hWnd, wMsg, conference, msgid, flags);
}

SOCKET ListMessagesByAreaNumber(HWND hWnd, unsigned int wMsg, DWORD conference, DWORD number, DWORD count, BOOL text, BOOL snoop)
{
  if (lpfnListMessagesByAreaNumber == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnListMessagesByAreaNumber(hWnd, wMsg, conference, number, count, text, snoop);
}

SOCKET ListMessagesByAreaMsgId(HWND hWnd, unsigned int wMsg, DWORD conference, DWORD msgid, DWORD count, BOOL text, BOOL snoop)
{
  if (lpfnListMessagesByAreaMsgId == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnListMessagesByAreaMsgId(hWnd, wMsg, conference, msgid, count, text, snoop);
}

SOCKET ListMessagesByAreaDate(HWND hWnd, unsigned int wMsg, DWORD conference, const FILETIME &postedtime, DWORD count, BOOL text, BOOL snoop)
{
  if (lpfnListMessagesByAreaDate == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnListMessagesByAreaDate(hWnd, wMsg, conference, postedtime, count, text, snoop);
}

SOCKET ListMessagesBySearch(HWND hWnd, unsigned int wMsg, const char *searchFrom, const char *searchTo, const char *searchSubject, const char *searchBody, DWORD start, DWORD sFlags, BOOL text, BOOL snoop)
{
  if (lpfnListMessagesBySearch == NULL) {                                                                                                                                                                      
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnListMessagesBySearch(hWnd, wMsg, searchFrom, searchTo, searchSubject, searchBody, start, sFlags, text, snoop);
}

SOCKET ListMessagesByUnread(HWND hWnd, unsigned int wMsg, BOOL text, BOOL snoop)
{
  if (lpfnListMessagesByUnread == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnListMessagesByUnread(hWnd, wMsg, text, snoop);
}
                   
SOCKET ListMessagesBackwardsByMsgId(HWND hWnd, unsigned int wMsg, DWORD conference, DWORD msgid, DWORD count, BOOL text, BOOL snoop)
{
  if (lpfnListMessagesBackwardsByMsgId == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnListMessagesBackwardsByMsgId(hWnd, wMsg, conference, msgid, count, text, snoop);
}

SOCKET ListMessagesBackwardsByNumber(HWND hWnd, unsigned int wMsg, DWORD conference, DWORD number, DWORD count, BOOL text, BOOL snoop)
{
  if (lpfnListMessagesBackwardsByNumber == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnListMessagesBackwardsByNumber(hWnd, wMsg, conference, number, count, text, snoop);
}
                   
SOCKET ListMessagesByAreaNumberEx(HWND hWnd, unsigned int wMsg, DWORD conference, DWORD number, DWORD count, WORD flags)
{
  if (lpfnListMessagesByAreaNumber == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnListMessagesByAreaNumberEx(hWnd, wMsg, conference, number, count, flags);
}

SOCKET ListMessagesByAreaMsgIdEx(HWND hWnd, unsigned int wMsg, DWORD conference, DWORD msgid, DWORD count, WORD flags)
{
  if (lpfnListMessagesByAreaMsgId == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnListMessagesByAreaMsgIdEx(hWnd, wMsg, conference, msgid, count, flags);
}

SOCKET ListMessagesByAreaDateEx(HWND hWnd, unsigned int wMsg, DWORD conference, const FILETIME &postedtime, DWORD count, WORD flags)
{
  if (lpfnListMessagesByAreaDate == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnListMessagesByAreaDateEx(hWnd, wMsg, conference, postedtime, count, flags);
}

SOCKET ListMessagesBySearchEx(HWND hWnd, unsigned int wMsg, const char *searchFrom, const char *searchTo, const char *searchSubject, const char *searchBody, DWORD start, DWORD sFlags, WORD flags)
{
  if (lpfnListMessagesBySearch == NULL) {                                                                                                                                                                      
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnListMessagesBySearchEx(hWnd, wMsg, searchFrom, searchTo, searchSubject, searchBody, start, sFlags, flags);
}

SOCKET ListMessagesByUnreadEx(HWND hWnd, unsigned int wMsg, WORD flags)
{
  if (lpfnListMessagesByUnread == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnListMessagesByUnreadEx(hWnd, wMsg, flags);
}

SOCKET ListMessagesBackwardsByMsgIdEx(HWND hWnd, unsigned int wMsg, DWORD conference, DWORD msgid, DWORD count, WORD flags)
{
  if (lpfnListMessagesBackwardsByMsgIdEx == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnListMessagesBackwardsByMsgIdEx(hWnd, wMsg, conference, msgid, count, flags);
}

SOCKET ListMessagesBackwardsByNumberEx(HWND hWnd, unsigned int wMsg, DWORD conference, DWORD number, DWORD count, WORD flags)
{
  if (lpfnListMessagesBackwardsByNumberEx == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnListMessagesBackwardsByNumberEx(hWnd, wMsg, conference, number, count, flags);
}
  
int SearchMessages_SetConfs(SOCKET s, DWORD start, DWORD runlength)
{
  if (lpfnSearchMessages_SetConfs == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnSearchMessages_SetConfs(s, start, runlength);
}

int SearchMessages_SetConfsDone(SOCKET s)
{
  if (lpfnSearchMessages_SetConfsDone == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnSearchMessages_SetConfsDone(s);
}

int GetMoreMessages(SOCKET s, DWORD count)
{
  if (lpfnGetMoreMessages == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnGetMoreMessages(s, count);
}

int GetAllMessages(SOCKET s)
{
  if (lpfnGetAllMessages == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnGetAllMessages(s);
}

SOCKET AddMessage(HWND hWnd, unsigned int wMsg, const TNavMsgHeader &msg)
{
  if (lpfnAddMessage == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnAddMessage(hWnd, wMsg, msg);
}

SOCKET DeleteMessage(HWND hWnd, unsigned int wMsg, const DWORD conference, const DWORD msgid)
{
  if (lpfnDeleteMessage == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnDeleteMessage(hWnd, wMsg, conference, msgid);
}

SOCKET GetCurrentUser(HWND hWnd, unsigned int wMsg)
{
  if (lpfnGetCurrentUser == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnGetCurrentUser(hWnd, wMsg);
}

SOCKET UpdateCurrentUser(HWND hWnd, unsigned int wMsg, const TUser &user)
{
  if (lpfnUpdateCurrentUser == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnUpdateCurrentUser(hWnd, wMsg, user);
}

SOCKET GetSecurityProfile(HWND hWnd, unsigned int wMsg)
{
  if (lpfnGetSecurityProfile == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnGetSecurityProfile(hWnd, wMsg);
}

SOCKET GetDownloadStats(HWND hWnd, unsigned int wMsg)
{
  if (lpfnGetDownloadStats == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnGetDownloadStats(hWnd, wMsg);
}

SOCKET GetFileAreaCount(HWND hWnd, unsigned int wMsg)
{
  if (lpfnGetFileAreaCount == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnGetFileAreaCount(hWnd, wMsg);
}

SOCKET GetEffectiveFileAreaCount(HWND hWnd, unsigned int wMsg)
{
  if (lpfnGetEffectiveFileAreaCount == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnGetEffectiveFileAreaCount(hWnd, wMsg);
}

SOCKET GetFileAreas(HWND hWnd, unsigned int wMsg, BOOL sorted)
{
  if (lpfnGetFileAreas == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnGetFileAreas(hWnd, wMsg, sorted);
}

SOCKET GetFileGroupCount(HWND hWnd, unsigned int wMsg)
{
  if (lpfnGetFileGroupCount == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnGetFileGroupCount(hWnd, wMsg);
}

SOCKET GetEffectiveFileGroupCount(HWND hWnd, unsigned int wMsg)
{
  if (lpfnGetEffectiveFileGroupCount == NULL) {
    return SOCKET_ERROR;
    assert(FALSE);
  }
  return lpfnGetEffectiveFileGroupCount(hWnd, wMsg);
}

SOCKET GetFileGroups(HWND hWnd, unsigned int wMsg, BOOL sorted)
{
  if (lpfnGetFileGroups == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnGetFileGroups(hWnd, wMsg, sorted);
}

SOCKET GetFileGroupAreas(HWND hWnd, unsigned int wMsg, DWORD group)
{
  if (lpfnGetFileGroupAreas == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnGetFileGroupAreas(hWnd, wMsg, group);
}

SOCKET ListFilesByName(HWND hWnd, unsigned int wMsg, DWORD count)
{
  if (lpfnListFilesByName == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnListFilesByName(hWnd, wMsg, count);
}

SOCKET ListFilesByDate(HWND hWnd, unsigned int wMsg, DWORD count, const FILETIME &startdate)
{
  if (lpfnListFilesByDate == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnListFilesByDate(hWnd, wMsg, count, startdate);
}

SOCKET ListFilesBySearch(HWND hWnd, unsigned int wMsg, DWORD count, const char *search)
{
  if (lpfnListFilesBySearch == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnListFilesBySearch(hWnd, wMsg, count, search);
}

int GetMoreFiles(SOCKET s, DWORD count)
{
  if (lpfnGetMoreFiles == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnGetMoreFiles(s, count);
}

int GetAllFiles(SOCKET s)
{
  if (lpfnGetAllFiles == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnGetAllFiles(s);
}

int PauseFileList(SOCKET s)
{
  if (lpfnPauseFileList == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnPauseFileList(s);
}

SOCKET ResolveFileName(HWND hWnd, unsigned int wMsg, const char *filename)
{
  if (lpfnResolveFileName == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnResolveFileName(hWnd, wMsg, filename);
}

int SetFileArea(SOCKET s, WORD start, WORD runlength)
{
  if (lpfnSetFileArea == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnSetFileArea(s, start, runlength);
}

int SetFileAreaDone(SOCKET s)
{
  if (lpfnSetFileAreaDone == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnSetFileAreaDone(s);
}

SOCKET GetFileDescription(HWND hWnd, unsigned int wMsg, WORD area, const char *fn)
{
  if (lpfnGetFileDescription == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnGetFileDescription(hWnd, wMsg, area, fn);
}

SOCKET UpdateFileInfo(HWND hWnd,
                      unsigned int wMsg,
                      const char *filename,
                      DWORD area,
                      const char *origpassword,
                      const char *description,
                      const char *password,
                      BOOL updatelongdesc,
                      WORD longdescbytes,
                      const char *longdescription)
{
  if (lpfnUpdateFileInfo == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnUpdateFileInfo(hWnd, wMsg, filename, area, origpassword, description, password, updatelongdesc, longdescbytes, longdescription);
}

SOCKET DeleteFile(HWND hWnd, unsigned int wMsg, WORD area, const char *filename, BOOL disktoo)
{
  if (lpfnDeleteFile == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnDeleteFile(hWnd, wMsg, area, filename, disktoo);
}

SOCKET ViewArchive(HWND hWnd, unsigned int wMsg, WORD area, const char *filename)
{
  if (lpfnViewArchive == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnViewArchive(hWnd, wMsg, area, filename);
}

SOCKET RequestOfflineFiles(HWND hWnd, unsigned int wMsg)
{
  if (lpfnRequestOfflineFiles == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnRequestOfflineFiles(hWnd, wMsg);
}

int RequestOfflineFiles_Submit(SOCKET s, const char *fn, DWORD area)
{
  if (lpfnRequestOfflineFiles_Submit == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnRequestOfflineFiles_Submit(s, fn, area);
}

int RequestOfflineFiles_Done(SOCKET s)
{
  if (lpfnRequestOfflineFiles_Done == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnRequestOfflineFiles_Done(s);
}

SOCKET DownloadFile(HWND hWnd, unsigned int wMsg, const char *fn, DWORD filesize, DWORD crc)
{
  if (lpfnDownloadFile == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnDownloadFile(hWnd, wMsg, fn, filesize, crc);
}

SOCKET UploadFile(HWND hWnd, unsigned int wMsg, TNavFullFileRecord &file)
{
  if (lpfnUploadFile == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnUploadFile(hWnd, wMsg, file);
}

SOCKET UploadFileEx(HWND hWnd, unsigned int wMsg, TNavFullFileRecord &file, WORD flags)
{
  if (lpfnUploadFileEx == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnUploadFileEx(hWnd, wMsg, file, flags);
}

SOCKET UploadMessageAttachment(HWND hWnd, unsigned int wMsg, DWORD filesize)
{
  if (lpfnUploadMessageAttachment == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnUploadMessageAttachment(hWnd, wMsg, filesize);
}

int SetAttachmentMessage(SOCKET s, WORD conference, DWORD messageid)
{
  if (lpfnSetAttachmentMessage == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnSetAttachmentMessage(s, conference, messageid);
}

int SetAttachmentMessageDone(SOCKET s)
{
  if (lpfnSetAttachmentMessageDone == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnSetAttachmentMessageDone(s);
}

int SendFileData(SOCKET s, const void *buf, WORD size)
{
  if (lpfnSendFileData == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnSendFileData(s, buf, size);
}

SOCKET CopyBeforeDownload(HWND hWnd, unsigned int wMsg)
{
  if (lpfnCopyBeforeDownload == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnCopyBeforeDownload(hWnd, wMsg);
}

int CopyBeforeDownload_Submit(SOCKET s, DWORD id, DWORD area, const char *fn)
{
  if (lpfnCopyBeforeDownload_Submit == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnCopyBeforeDownload_Submit(s, id, area, fn);
}

int CopyBeforeDownload_Remove(SOCKET s, DWORD id)
{ 
  if (lpfnCopyBeforeDownload_Remove == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnCopyBeforeDownload_Remove(s, id);
}

SOCKET GetPackageVersion(HWND hWnd, unsigned int wMsg, const char *package, const char *version)
{
  if (lpfnGetPackageVersion == NULL) {
    assert(FALSE);
    return SOCKET_ERROR;
  }
  return lpfnGetPackageVersion(hWnd, wMsg, package, version);
}

int SendMoreData(SOCKET s, const void *buf, WORD size)
{
  if (lpfnSendMoreData == NULL) {
    assert(FALSE);
    return 0;
  }
  return lpfnSendMoreData(s, buf, size);
}
