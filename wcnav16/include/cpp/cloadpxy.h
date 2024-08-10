#ifndef __CLOADPXY_H
#define __CLOADPXY_H

#include <windows.h>
#include <winsock.h>

// server record structure dependencies
//
// - TNavMsgHeader
// - TUser
// - TNavFullFileRecord

#include "wcnav.h"

BOOL LoadProxyLibrary();
void FreeProxyLibrary();

void CancelCall(SOCKET s);
void CancelByUserData(SOCKET s);
WORD GetMaxServerRequestTypes();
WORD GetServerVersion();
SOCKET LoginUser(HWND hWnd, unsigned int wMsg, const char *name, const char *password);
SOCKET GetTimeLeftOnline(HWND hWnd, unsigned int wMsg);
SOCKET WriteActivityLogEntry(HWND hWnd, unsigned int wMsg, const char *text);
SOCKET KeepAlive(HWND hWnd, unsigned int wMsg);
SOCKET GetSystemInfo(HWND hWnd, unsigned int wMsg);
SOCKET GetObjectFlags(HWND hWnd, unsigned int wMsg, DWORD objectID);
SOCKET GetObjectFlagsByName(HWND hWnd, unsigned int wMsg, const char *objectname);
SOCKET GetObjectInfo(HWND hWnd, unsigned int wMsg, DWORD objectid, DWORD objectclass, const char *objectname);
SOCKET GetServiceByName(HWND hWnd, unsigned int wMsg, const char *name);
SOCKET OpenService(HWND hWnd, unsigned int wMsg, const sockaddr_in *addr, BOOL timeout);
SOCKET GetServerContextHandle(HWND hWnd, unsigned int wMsg);
SOCKET GetServerChallengeString(HWND hWnd, unsigned int wMsg);
SOCKET OpenChannel(HWND hWnd, unsigned int wMsg, const char *name, BOOL timeout);
int WriteChannel(SOCKET chandle, DWORD dest, DWORD userdata, void *data, DWORD datasize);
SOCKET GetPredefinedChatChannels(HWND hWnd, unsigned int wMsg);
SOCKET GetUserList(HWND hWnd, unsigned int wMsg);
SOCKET GetWhosOnline(HWND hWnd, unsigned int wMsg);
SOCKET GetUserInfo(HWND hWnd, unsigned int wMsg, const char *username, DWORD userid);
SOCKET GetNodeInfoByName(HWND hWnd, unsigned int wMsg, const char *username);
SOCKET SearchUserNames(HWND hWnd, unsigned int wMsg, const char *username);
SOCKET GetConferenceCount(HWND hWnd, unsigned int wMsg);
SOCKET GetEffectiveConferenceCount(HWND hWnd, unsigned int wMsg);
SOCKET GetConfDescs(HWND hWnd, unsigned int wMsg, BOOL sorted);
SOCKET ListConferencesByNumber(HWND hWnd, unsigned int wMsg, DWORD start, DWORD count);
SOCKET ListConferencesByName(HWND hWnd, unsigned int wMsg, const char *name, DWORD count);
SOCKET GetVolatileConfInfo(HWND hWnd, unsigned int wMsg);
SOCKET GetVolatileConfInfoEx(HWND hWnd, unsigned int wMsg);
int GetVolatileConfInfo_SetConfs(SOCKET s, DWORD start, DWORD count);
int GetVolatileConfInfo_SetConfsDone(SOCKET s);
SOCKET SetLastRead(HWND hWnd, unsigned int wMsg, DWORD conference, DWORD lastread);
SOCKET GetConferenceGroupCount(HWND hWnd, unsigned int wMsg);
SOCKET GetEffectiveConferenceGroupCount(HWND hWnd, unsigned int wMsg);
SOCKET GetConferenceGroups(HWND hWnd, unsigned int wMsg);
SOCKET GetConferenceGroupAreas(HWND hWnd, unsigned int wMsg, DWORD group);
SOCKET SetConferenceFlags(HWND hWnd, unsigned int wMsg, DWORD conference, DWORD flags);
SOCKET SetMultipleConferenceFlags(HWND hWnd, unsigned int wMsg);
int SetMultipleConferenceFlags_SetData(SOCKET s, DWORD start, DWORD runlength, DWORD flags);
int SetMultipleConferenceFlags_SetAll(SOCKET s, DWORD flags);
int SetMultipleConferenceFlags_SetDone(SOCKET s);
SOCKET MarkMessageRead(HWND hWnd, unsigned int wMsg, DWORD conference, DWORD msgid, DWORD flags);
SOCKET ListMessagesByAreaNumber(HWND hWnd, unsigned int wMsg, DWORD conference, DWORD number, DWORD count, BOOL text, BOOL snoop);
SOCKET ListMessagesByAreaMsgId(HWND hWnd, unsigned int wMsg, DWORD conference, DWORD msgid, DWORD count, BOOL text, BOOL snoop);
SOCKET ListMessagesByAreaDate(HWND hWnd, unsigned int wMsg, DWORD conference, const FILETIME &postedtime, DWORD count, BOOL text, BOOL snoop);
SOCKET ListMessagesBySearch(HWND hWnd, unsigned int wMsg, const char *searchFrom, const char *searchTo, const char *searchSubject, const char *searchBody, DWORD start, DWORD sFlags, BOOL text, BOOL snoop);
SOCKET ListMessagesByUnread(HWND hWnd, unsigned int wMsg, BOOL text, BOOL snoop);
SOCKET ListMessagesBackwardsByMsgId(HWND hWnd, unsigned int wMsg, DWORD conference, DWORD msgid, DWORD count, BOOL text, BOOL snoop);
SOCKET ListMessagesBackwardsByNumber(HWND hWnd, unsigned int wMsg, DWORD conference, DWORD number, DWORD count, BOOL text, BOOL snoop);
SOCKET ListMessagesByAreaNumberEx(HWND hWnd, unsigned int wMsg, DWORD conference, DWORD number, DWORD count, WORD flags);
SOCKET ListMessagesByAreaMsgIdEx(HWND hWnd, unsigned int wMsg, DWORD conference, DWORD msgid, DWORD count, WORD flags);
SOCKET ListMessagesByAreaDateEx(HWND hWnd, unsigned int wMsg, DWORD conference, const FILETIME &postedtime, DWORD count, WORD flags);
SOCKET ListMessagesBySearchEx(HWND hWnd, unsigned int wMsg, const char *searchFrom, const char *searchTo, const char *searchSubject, const char *searchBody, DWORD start, DWORD sFlags, WORD flags);
SOCKET ListMessagesByUnreadEx(HWND hWnd, unsigned int wMsg, WORD flags);
SOCKET ListMessagesBackwardsByMsgIdEx(HWND hWnd, unsigned int wMsg, DWORD conference, DWORD msgid, DWORD count, WORD flags);
SOCKET ListMessagesBackwardsByNumberEx(HWND hWnd, unsigned int wMsg, DWORD conference, DWORD number, DWORD count, WORD flags);
int SearchMessages_SetConfs(SOCKET s, DWORD start, DWORD runlength);
int SearchMessages_SetConfsDone(SOCKET s);
int GetMoreMessages(SOCKET s, DWORD count);
int GetAllMessages(SOCKET s);
SOCKET AddMessage(HWND hWnd, unsigned int wMsg, const TNavMsgHeader &msg);
SOCKET DeleteMessage(HWND hWnd, unsigned int wMsg, const DWORD conference, const DWORD msgid);
SOCKET GetCurrentUser(HWND hWnd, unsigned int wMsg);
SOCKET UpdateCurrentUser(HWND hWnd, unsigned int wMsg, const TUser &user);
SOCKET GetSecurityProfile(HWND hWnd, unsigned int wMsg);
SOCKET GetDownloadStats(HWND hWnd, unsigned int wMsg);
SOCKET GetFileAreaCount(HWND hWnd, unsigned int wMsg);
SOCKET GetEffectiveFileAreaCount(HWND hWnd, unsigned int wMsg);
SOCKET GetFileAreas(HWND hWnd, unsigned int wMsg, BOOL sorted);
SOCKET GetFileGroupCount(HWND hWnd, unsigned int wMsg);
SOCKET GetEffectiveFileGroupCount(HWND hWnd, unsigned int wMsg);
SOCKET GetFileGroups(HWND hWnd, unsigned int wMsg, BOOL sorted);
SOCKET GetFileGroupAreas(HWND hWnd, unsigned int wMsg, DWORD group);
SOCKET ListFilesByName(HWND hWnd, unsigned int wMsg, DWORD count);
SOCKET ListFilesByDate(HWND hWnd, unsigned int wMsg, DWORD count, const FILETIME &startdate);
SOCKET ListFilesBySearch(HWND hWnd, unsigned int wMsg, DWORD count, const char *search);
int GetMoreFiles(SOCKET s, DWORD count);
int GetAllFiles(SOCKET s);
int PauseFileList(SOCKET s);
SOCKET ResolveFileName(HWND hWnd, unsigned int wMsg, const char *filename);
int SetFileArea(SOCKET s, WORD start, WORD runlength);
int SetFileAreaDone(SOCKET s);
SOCKET GetFileDescription(HWND hWnd,unsigned int wMsg, WORD area, const char *fn);
SOCKET UpdateFileInfo(HWND hWnd,
                      unsigned int wMsg,
                      const char *filename,
                      DWORD area,
                      const char *origpassword,
                      const char *description,
                      const char *password,
                      BOOL updatelongdesc,
                      WORD longdescbytes,
                      const char *longdescription);
SOCKET DeleteFile(HWND hWnd, unsigned int wMsg, WORD area, const char *filename, BOOL disktoo);
SOCKET ViewArchive(HWND hWnd, unsigned int wMsg, WORD area, const char *filename);
SOCKET RequestOfflineFiles(HWND hWnd, unsigned int wMsg);
int RequestOfflineFiles_Submit(SOCKET s, const char *fn, DWORD area);
int RequestOfflineFiles_Done(SOCKET s);
SOCKET DownloadFile(HWND hWnd, unsigned int wMsg, const char *fn, DWORD filesize, DWORD crc);
SOCKET UploadFile(HWND hWnd, unsigned int wMsg, TNavFullFileRecord &file);
SOCKET UploadFileEx(HWND hWnd, unsigned int wMsg, TNavFullFileRecord &file, WORD flags);
SOCKET UploadMessageAttachment(HWND hWnd, unsigned int wMsg, DWORD filesize);
int SetAttachmentMessage(SOCKET s, WORD conference, DWORD messageid);
int SetAttachmentMessageDone(SOCKET s);
int SendFileData(SOCKET s, const void *buf, WORD size);
SOCKET CopyBeforeDownload(HWND hWnd, unsigned int wMsg);
int CopyBeforeDownload_Submit(SOCKET s, DWORD id, DWORD area, const char *fn);
int CopyBeforeDownload_Remove(SOCKET s, DWORD id);
SOCKET GetPackageVersion(HWND hWnd, unsigned int wMsg, const char *package, const char *version);
int SendMoreData(SOCKET s, const void *buf, WORD size);

#endif //__CLOADPXY_H

