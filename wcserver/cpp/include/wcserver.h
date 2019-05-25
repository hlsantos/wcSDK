//*******************************************************************
// (c) Copyright 1999 Santronics Software, Inc. All Rights Reserved.
//*******************************************************************
//
// File Name : wcserver.h
// Created   : 07/02/99 06:40 pm
// Programmer: SSI
//
// Revision History:
// Build  Date     Author  Comments
// -----  -------- ------  -------------------------------
// 447B2  07/02/99 HLS     - cleaned up
//        07/12/99 HLS     - new function: CheckMailIntegrity()
// 450    05/11/00 SMC     - Added BCB support.  Not complete.
//                           Functions dependent on TNodeInfo
//                           and TMenuItem needed to be changed.
// 450.7  04/25/03 HLS     - Removed UNICODE parameters (LPCTCHAR
//                           and WIN32_FIND_DATA)
//
// 454.6  07/24/17 HLS     - Added WcGetGeoIP() function
//*******************************************************************

#ifndef __WCSERVER_H
#define __WCSERVER_H

#include "wctype.h"

#ifdef __cplusplus
extern "C" {
#endif

//+ Group: Client SDK Functions

///////////////////////////////////////////////////////////////////////////
//! The functions to get the Wildcat version and build can be called before
//! WildcatServerConnect.
///////////////////////////////////////////////////////////////////////////

DWORD APIENTRY GetWildcatVersion();
DWORD APIENTRY GetWildcatBuild();

///////////////////////////////////////////////////////////////////////////
//! 449.5 04/30/01
//! The functions to get the Wildcat version and build at the server and
//! can only be called after a context is created
///////////////////////////////////////////////////////////////////////////

DWORD APIENTRY WcGetServerVersion();
DWORD APIENTRY WcGetServerBuild();

////////////////////////////////////////////////////////////////////////////
//! WildcatServerConnect should be called once per application to connect to
//! the Wildcat server.  The window handle is used as the parent window when
//! the server connect dialog box is displayed.  If there is no convenient
//! window handle available, pass NULL.  Console mode applications should
//! also pass NULL.  WildcatServerConnectSpecific can be called if you know
//! the machine name of the server you would like to connect to.
//! WildcatServerDialog allows the user to pick a server from a dialog box.
//!
//! WildcatServerConnectLocal() was added in v5.7 to support connections
//! only to the local computer. Performs no broadcasting.
////////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY WildcatServerConnect(HWND parent);
BOOL  APIENTRY WildcatServerConnectSpecific(HWND parent, const char *computername);
BOOL  APIENTRY WildcatServerConnectLocal(HWND parent);
BOOL  APIENTRY WildcatServerDialog(HWND parent, char *computername, DWORD namesize);
BOOL  APIENTRY SetWildcatErrorMode(BOOL verbose);
// 450.9b2
BOOL  APIENTRY WildcatServerShutdown(const char *pwd, const BOOL force);
//

///////////////////////////////////////////////////////////////////////////
//! GetConnectedServer retrieves the computer name of the connected server
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY GetConnectedServer(char *computername, DWORD namesize);

///////////////////////////////////////////////////////////////////////////
//! These functions start and stop a thread-specific context for this client
//! on the server.  Even if an application only has one thread, the
//! WildcatServerCreateContext function must be called before any other
//! functions will work.
//!
//! WildcatServerCreateContextFromHandle creates a new client context that
//! refers to an existing context on the server.  The handle is generally
//! retrieved using GetWildcatServerContextHandle in one application, and
//! passed to WildcatServerCreateContextFromHandle in another application.
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY WildcatServerCreateContext();
BOOL  APIENTRY WildcatServerCreateContextFromHandle(DWORD context);
BOOL  APIENTRY WildcatServerCreateContextFromChallenge(const char *challenge);
DWORD APIENTRY GetWildcatServerContextHandle();
//DWORD APIENTRY GetWildcatServerContextRefCount(); (deprecated)
BOOL  APIENTRY WildcatServerDeleteContext();

///////////////////////////////////////////////////////////////////////////
//! This function sets up a callback for the client application.
//! Channel messages are presented to the client through this
//! callback mechanism.
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY SetupWildcatCallback(TWildcatCallback cbproc, DWORD userdata);
BOOL  APIENTRY RemoveWildcatCallback();

///////////////////////////////////////////////////////////////////////////
//! This function is used to grant another thread in the same application
//! equivalent access as the thread that calls this function.  It causes the
//! other thread to refer to the same server context.  This is a lightweight
//! version of WildcatServerCreateContextFromHandle.  One difference is that
//! since this function does not create a new client context,
//! WildcatServerDeleteContext must only be called once for this context,
//! even though there may be more than one thread accessing it.
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY GrantThreadAccess(DWORD tid);

///////////////////////////////////////////////////////////////////////////
//! These two functions allow you to more directly manipulate the Wildcat
//! server context associated with the current thread.  Like
//! GrantThreadAccess, the Wildcat server is only aware of one instance of
//! the context, so WildcatServerDeleteContext must only be called once per
//! server context.
///////////////////////////////////////////////////////////////////////////

DWORD APIENTRY GetWildcatThreadContext();
BOOL  APIENTRY SetWildcatThreadContext(DWORD context);

///////////////////////////////////////////////////////////////////////////
//! Returns the current node number, or 0 if no node number has been
//! allocated.
///////////////////////////////////////////////////////////////////////////

DWORD APIENTRY GetNode();

///////////////////////////////////////////////////////////////////////////
//! Set the current node status (nsDown, nsUp, nsSigningOn, nsLoggedIn).
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY SetNodeStatus(DWORD nodestatus);

///////////////////////////////////////////////////////////////////////////
//! Set the node down status (ndNone, ndRefuseLogin, ndDown).
///////////////////////////////////////////////////////////////////////////

//BOOL  APIENTRY SetNodeStatusDown(DWORD node, DWORD downstatus); (deprecated, see SetPortState)

///////////////////////////////////////////////////////////////////////////
//! Get the TMakewild global configuration record.
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY GetMakewild(TMakewild &mw);
BOOL  APIENTRY GetComputerConfig(TComputerConfig &cc);

///////////////////////////////////////////////////////////////////////////
//! Get the challenge string used for MD5 password authentication.
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY GetChallengeString(char *buf, DWORD bufsize);

///////////////////////////////////////////////////////////////////////////
//! Log in to the Wildcat server as the 'system'.  This gives unrestricted
//! access to all aspects of the server.  The computer from which this
//! function is called must have been set up with the Wildcat System
//! password, if any.
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY LoginSystem();

///////////////////////////////////////////////////////////////////////////
//! Look up a user account by name, and return basic account information.
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY LookupName(const char *name, TUserInfo &uinfo);

///////////////////////////////////////////////////////////////////////////
//! Allocate a node for a particular call type.  If a specific node is
//! required, pass it in the 'node' parameter, otherwise pass zero.
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY AllocateNode(DWORD node, DWORD calltype, const char *speed);

///////////////////////////////////////////////////////////////////////////
//! Log in to the userver under a user account.  All further access to the
//! server is checked based on the access profile(s) of the user.  The
//! password can either be plaintext or an MD5 digest string.
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY LoginUser(DWORD userid, const char *password, TUser &user);
BOOL  APIENTRY LoginUserEx(DWORD userid, const char *password, DWORD calltype, const char *speed, TUser &user);
BOOL  APIENTRY LoginRadiusUser(DWORD userid, BYTE chapid, const BYTE *challenge, DWORD challengesize, const BYTE *challresponse, TUser &user);

///////////////////////////////////////////////////////////////////////////
//! Log out of the server.  This is called no matter whether you log in to
//! the server using LoginSystem or LoginUser.
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY LogoutUser();

///////////////////////////////////////////////////////////////////////////
//! Checks to see whether the current context is logged in or not.  Returns
//! the user record if it is logged in as a user.  See clSessionXXXX
//! constants
///////////////////////////////////////////////////////////////////////////

DWORD APIENTRY WildcatLoggedIn(TUser *user);

///////////////////////////////////////////////////////////////////////////
//! Gets the number of users currently online.
///////////////////////////////////////////////////////////////////////////

DWORD APIENTRY GetUsersOnline();

///////////////////////////////////////////////////////////////////////////
//! Get the object flags for a particular access profile.  This may be
//! called before a user is logged in.
///////////////////////////////////////////////////////////////////////////

DWORD APIENTRY GetProfileObjectFlags(const char *profile, DWORD objectid);

///////////////////////////////////////////////////////////////////////////
//! The Wildcat server file API functions are modeled after the Win32 file
//! API functions.  See the Win32 API documentation for details regarding
//! these functions. See WCPATHS.DOC for information regarding the format of
//! the path names that may be used with these functions.
///////////////////////////////////////////////////////////////////////////

BOOL     APIENTRY WcCloseHandle(WCHANDLE h);
BOOL     APIENTRY WcCreateDirectory(const char * dir);
BOOL     APIENTRY WcRemoveDirectory(const char * dir);  // 450.3
WCHANDLE APIENTRY WcCreateFile(const char * fn, DWORD access, DWORD sharemode, DWORD create);
BOOL     APIENTRY WcDeleteFile(const char * fn);
BOOL     APIENTRY WcExistFile(const char * fn);
WCHANDLE APIENTRY WcFindFirstFile(const char * fn, WIN32_FIND_DATAA *fd);
BOOL     APIENTRY WcFindNextFile(WCHANDLE ff, WIN32_FIND_DATAA *fd);
BOOL     APIENTRY WcFindClose(WCHANDLE ff);
DWORD    APIENTRY WcGetFileSize(WCHANDLE h);
BOOL     APIENTRY WcGetFileTime(WCHANDLE h, FILETIME &ft);
BOOL     APIENTRY WcGetFileTimeByName(const char * fn, FILETIME &ft);
BOOL     APIENTRY WcMoveFile(const char * src, const char * dest);
BOOL     APIENTRY WcReadFile(WCHANDLE h, LPVOID buffer, DWORD requested, LPDWORD read);
BOOL     APIENTRY WcReadLine(WCHANDLE h, LPVOID buffer, DWORD buflen);
BOOL     APIENTRY WcSetEndOfFile(WCHANDLE h);
DWORD    APIENTRY WcSetFilePointer(WCHANDLE h, LONG dist, DWORD movemethod);
BOOL     APIENTRY WcSetFileTime(WCHANDLE h, FILETIME &ft);
BOOL     APIENTRY WcWriteFile(WCHANDLE h, LPCVOID buffer, DWORD requested, LPDWORD written);
BOOL     APIENTRY WcRenameFile(const char * from, const char * toname); // 450.3

// 451.8h 07/17/06 07:26 pm
// Internal usage only
BOOL     APIENTRY WcResolvePathName(const char *wfname, DWORD &access, DWORD &share, DWORD &create, char *dest, const DWORD destsize);
//

///////////////////////////////////////////////////////////////////////////
//! Get the connection Id for the current context.  Connection Ids are
//! unique and can reasonably be assumed not to repeat during the time the
//! server is up.
///////////////////////////////////////////////////////////////////////////

DWORD APIENTRY GetConnectionId();

///////////////////////////////////////////////////////////////////////////
//! Get the total number of calls made to the system (not server API calls,
//! user calls). The 'increment' parameter determines whether or not the
//! count is increased by one before returning the result.
///////////////////////////////////////////////////////////////////////////

DWORD APIENTRY GetTotalCalls(BOOL increment);

///////////////////////////////////////////////////////////////////////////
//! This function combines a WcCreateFile, WcReadFile, and WcCloseHandle
//! into one operation.
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY GetText(const char *fn, char *buf, DWORD bufsize, DWORD &retsize);

///////////////////////////////////////////////////////////////////////////
//! The following functions access the security data in the Wildcat server.
//! Each 'securable' object (conference, file area, door, etc) has a unique
//! Object Id stored with it.  Access profiles are tables of Object Ids and
//! access flags. When a user logs in, a composite access table consisting
//! of the logical OR of all the flags in the user' access profiles is
//! created.  These functions access the information in that composite
//! array.
//!
//! Object flags are often simply zero or one to indicate no access or allow
//! access, but the individual bits may mean different things such as
//! Join/Read/Write/Sysop access in a conference area.
///////////////////////////////////////////////////////////////////////////

DWORD APIENTRY GetObjectFlags(DWORD objectid);
BOOL  APIENTRY GetMultipleObjectFlags(const DWORD *objectid, DWORD count, DWORD *flags);
BOOL  APIENTRY GetObjectById(DWORD objectid, TObjectName &objectname);
BOOL  APIENTRY GetMultipleObjectsById(const DWORD *objectid, DWORD count, TObjectName *objectname);
BOOL  APIENTRY GetObjectByName(DWORD classid, const char *name, TObjectName &objectname, DWORD &tid);
BOOL  APIENTRY GetNextObjectByName(TObjectName &objectname, DWORD &tid);
DWORD APIENTRY GetStringObjectId(DWORD objectclass, const char *name);
DWORD APIENTRY GetStringObjectFlags(DWORD objectclass, const char *name);

///////////////////////////////////////////////////////////////////////////
//! These functions access the list of security profiles in the server.
///////////////////////////////////////////////////////////////////////////

DWORD APIENTRY GetSecurityProfileCount();
BOOL  APIENTRY GetSecurityProfileNames(DWORD count, char names[][SIZE_SECURITY_NAME]);
BOOL  APIENTRY GetSecurityProfileByIndex(DWORD index, TSecurityProfile &profile);
BOOL  APIENTRY GetSecurityProfileByName(const char *name, TSecurityProfile &profile);

///////////////////////////////////////////////////////////////////////////
//! These functions access the list of access profile names in the server.
///////////////////////////////////////////////////////////////////////////

DWORD APIENTRY GetAccessProfileCount();
BOOL  APIENTRY GetAccessProfileNames(DWORD count, char names[][SIZE_SECURITY_NAME]);
BOOL  APIENTRY GetAccessProfileName(DWORD index, char name[SIZE_SECURITY_NAME]);

///////////////////////////////////////////////////////////////////////////
//! These functions access the list of conferences (message areas) in
//! the server.
///////////////////////////////////////////////////////////////////////////

DWORD APIENTRY GetConferenceCount();
BOOL  APIENTRY GetConfDesc(DWORD conference, TConfDesc &cd);

///////////////////////////////////////////////////////////////////////////
//! These functions access the list of conference groups in the server.
///////////////////////////////////////////////////////////////////////////

DWORD APIENTRY GetConferenceGroupCount();
BOOL  APIENTRY GetConferenceGroup(DWORD index, TConferenceGroup &cg);

///////////////////////////////////////////////////////////////////////////
//! These functions access the list of file areas in the server.
///////////////////////////////////////////////////////////////////////////

DWORD APIENTRY GetFileAreaCount();
BOOL  APIENTRY GetFileArea(DWORD area, TFileArea &fa);

///////////////////////////////////////////////////////////////////////////
//! These functions access the list of file groups in the server.
///////////////////////////////////////////////////////////////////////////

DWORD APIENTRY GetFileGroupCount();
BOOL  APIENTRY GetFileGroup(DWORD index, TFileGroup &fg);

///////////////////////////////////////////////////////////////////////////
//! These functions access the list of doors in the server.
///////////////////////////////////////////////////////////////////////////

DWORD APIENTRY GetDoorCount();
BOOL  APIENTRY GetDoor(DWORD index, TDoorInfo &di);

///////////////////////////////////////////////////////////////////////////
//! These functions access the list of languages in the server.
///////////////////////////////////////////////////////////////////////////

DWORD APIENTRY GetLanguageCount();
BOOL  APIENTRY GetLanguage(DWORD index, TLanguageInfo &li);

///////////////////////////////////////////////////////////////////////////
//! This function gets a specific modem profile from the server.
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY GetModemProfile(const char *name, TModemProfile &mp);

///////////////////////////////////////////////////////////////////////////
//! Get the current maximum number of nodes that have been allocated.
///////////////////////////////////////////////////////////////////////////

DWORD APIENTRY GetNodeCount();

///////////////////////////////////////////////////////////////////////////
//! Get the maximum number of concurrent users supported by this
//! installation of Wildcat.
///////////////////////////////////////////////////////////////////////////

DWORD APIENTRY GetMaximumUserCount();

///////////////////////////////////////////////////////////////////////////
//! Get a node configuration record for the specified node.  Use
//! by Wconline to start modem nodes.
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY GetNodeConfig(DWORD node, TNodeConfig &nc);

///////////////////////////////////////////////////////////////////////////
//! Get a node information record for a specific node.
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY GetNodeInfo(DWORD node, TwcNodeInfo &ni);

///////////////////////////////////////////////////////////////////////////
//! Get a node information record for a specific connection Id.
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY GetNodeInfoByConnectionId(DWORD id, TwcNodeInfo &ni);

///////////////////////////////////////////////////////////////////////////
//! Get a node information record for a specific name.
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY GetNodeInfoByName(const char *name, TwcNodeInfo &ni);

///////////////////////////////////////////////////////////////////////////
//! Get multiple node information records starting at a specific node.
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY GetNodeInfos(DWORD node, DWORD count, TwcNodeInfo *ni);

///////////////////////////////////////////////////////////////////////////
//! Set the current node's information record.  Only non-critical fields are
//! allowed to be changed by this function.
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY SetNodeInfo(const TwcNodeInfo &ni);

///////////////////////////////////////////////////////////////////////////
//! Set the current activity string for the current node.
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY SetNodeActivity(const char *activity);

///////////////////////////////////////////////////////////////////////////
//! Server State Functions
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY SetServerState(const char *port, DWORD state);
BOOL  APIENTRY GetServerState(DWORD index, TServerState &ss);
BOOL  APIENTRY SetNodeServerState(DWORD node, DWORD state);

///////////////////////////////////////////////////////////////////////////
//! The following functions access the file database in Wildcat.  The
//! functions should be straightforward with the following notes:
//!
//! - GetFileRecByXxx gets a specific record by key.  SearchFileRecByXxx
//!   searches for matching record, or the next record in the database,
//!   based on a key.
//!
//! - FileSearch returns an array of __int64 (64-bit integers).  The high 32
//!   bits indicates the file area of the record, and the low 32 bits
//!   indicates the absolute reference number of the record.
//!   GetFileRecAbsolute gets a specific file record.
//!
//! - Most functions return a TFileRecord which does not contain the long
//!   file description. To retrieve the long file description, use
//!   GetFullFileRec.
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY AddFileRec(TFullFileRecord &f);
BOOL  APIENTRY DeleteFileRec(const TFileRecord &f, BOOL disktoo);
BOOL  APIENTRY FileSearch(const char *s, DWORD &n, unsigned __int64 *&p);
BOOL  APIENTRY GetFileRecAbsolute(DWORD ref, TFileRecord &f);
BOOL  APIENTRY GetFileRecByNameArea(const char *name, DWORD area, TFileRecord &f, DWORD &tid);
BOOL  APIENTRY GetFileRecByAreaName(DWORD area, const char *name, TFileRecord &f, DWORD &tid);
BOOL  APIENTRY GetFileRecByAreaDate(DWORD area, const FILETIME &t, TFileRecord &f, DWORD &tid);
BOOL  APIENTRY GetFileRecByUploader(DWORD id, TFileRecord &f, DWORD &tid);
BOOL  APIENTRY GetFirstFileRec(DWORD keynum, TFileRecord &f, DWORD &tid);
BOOL  APIENTRY GetFullFileRec(TFileRecord &f, TFullFileRecord &full);
BOOL  APIENTRY GetLastFileRec(DWORD keynum, TFileRecord &f, DWORD &tid);
BOOL  APIENTRY GetNextFileRec(DWORD keynum, TFileRecord &f, DWORD &tid);
BOOL  APIENTRY GetPrevFileRec(DWORD keynum, TFileRecord &f, DWORD &tid);
DWORD APIENTRY GetTotalFiles();
DWORD APIENTRY GetTotalFilesInArea(DWORD area);
DWORD APIENTRY GetTotalFilesInGroup(DWORD group);
BOOL  APIENTRY IncrementDownloadCount(TFileRecord &f);
BOOL  APIENTRY SearchFileRecByNameArea(const char *name, DWORD area, TFileRecord &f, DWORD &tid);
BOOL  APIENTRY SearchFileRecByAreaName(DWORD area, const char *name, TFileRecord &f, DWORD &tid);
BOOL  APIENTRY SearchFileRecByAreaDate(DWORD area, const FILETIME &t, TFileRecord &f, DWORD &tid);
BOOL  APIENTRY SearchFileRecByDateArea(const FILETIME &t, DWORD area, TFileRecord &f, DWORD &tid);
BOOL  APIENTRY SearchFileRecByUploader(DWORD id, TFileRecord &f, DWORD &tid);
BOOL  APIENTRY UpdateFileRec(TFileRecord &f);
BOOL  APIENTRY UpdateFullFileRec(TFullFileRecord &f);

///////////////////////////////////////////////////////////////////////////
//! The following functions access the message databases in Wildcat.
//! Messages are identified by there conference number and Id.  Message Ids
//! are assigned when the message is added to the database and never
//! reassigned.  Message Ids are very large numbers, so a separate message
//! 'Number' is provided for convenience.  Message numbers are assigned
//! sequentially within a conference.
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY AddMessage(TMsgHeader &msg, const char *text);
BOOL  APIENTRY DeleteMessage(TMsgHeader &msg);
DWORD APIENTRY GetHighMessageNumber(DWORD conf);
DWORD APIENTRY GetLowMessageNumber(DWORD conf);
BOOL  APIENTRY GetMessageById(DWORD conf, DWORD msgid, TMsgHeader &msg);
//BOOL  APIENTRY GetMessageByRef(DWORD conf, DWORD refid, TMsgHeader &msg);
DWORD APIENTRY GetMsgIdFromNumber(DWORD conf, DWORD number);
DWORD APIENTRY GetMsgNumberFromId(DWORD conf, DWORD msgid);
BOOL  APIENTRY GetNextMessage(TMsgHeader &msg);
BOOL  APIENTRY GetPrevMessage(TMsgHeader &msg);
DWORD APIENTRY GetTotalMessages();
DWORD APIENTRY GetTotalMessagesInConference(DWORD conf);
DWORD APIENTRY GetTotalMessagesInGroup(DWORD group);
BOOL  APIENTRY IncrementReplyCount(TMsgHeader &msg);
BOOL  APIENTRY IncrementReadCount(TMsgHeader &msg);
BOOL  APIENTRY MarkMessageRead(TMsgHeader &msg);
BOOL  APIENTRY MessageSearch(DWORD conf, DWORD msgid, DWORD msflags, const char *text, TMsgHeader &msg);
BOOL  APIENTRY SearchMessageById(DWORD conf, DWORD msgid, TMsgHeader &msg);
BOOL  APIENTRY SetMessagePrivate(TMsgHeader &msg, BOOL pvt);
BOOL  APIENTRY UpdateMessageFidoInfo(TMsgHeader &msg);

//BOOL  APIENTRY MessageSearchEx(DWORD conf,
//                               DWORD msgid,
//                               DWORD msflags,
//                               const char *text,
//                               TMsgHeader &msg,
//                               // RPC_ASYNC_STATE *Async
//                               PVOID Async);

//////////////////////////////////////////////////////////////////////////////
//! Use this function to define a group of conference numbers and to retrieve
//! the highest msgid for each conference.
//////////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY GetHighMessageIds(DWORD count, const DWORD *conferences, DWORD *ids);

// HLS WS 6.0a
BOOL  APIENTRY SetMessageExported(TMsgHeader &msg, BOOL exported);

///////////////////////////////////////////////////////////////////////////
//! The following functions access the user database in Wildcat.  Like the
//! file database, GetUserByXxx gets a specific record, and SearchUserByXxx
//! looks for a matching or the next higher record in the database.
//! GetUserVariable and SetUserVariable can be used to store private
//! application-specific information in a user record.  They are similar in
//! use to the profile functions in the Windows API.
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY AddNewUser(TUser &u);
BOOL  APIENTRY DeleteOtherUser(const TUser &u);
BOOL  APIENTRY GetUserById(DWORD id, TUser &u, DWORD &tid);
BOOL  APIENTRY GetUserByLastName(const char *name, TUser &u, DWORD &tid);
BOOL  APIENTRY GetUserByName(const char *name, TUser &u, DWORD &tid);
BOOL  APIENTRY GetUserBySecurity(const char *security, TUser &u, DWORD &tid);
BOOL  APIENTRY GetUserByLastCall(const FILETIME &ft, TUser &u, DWORD &tid);   // 452.1f
BOOL  APIENTRY GetUserVariable(DWORD id, const char *section, const char *key, const char *def, char *dest, DWORD destsize);
BOOL  APIENTRY GetUserVariables(DWORD id, void *buffer, DWORD requested, DWORD *read);
BOOL  APIENTRY GetFirstUser(DWORD keynum, TUser &u, DWORD &tid);
BOOL  APIENTRY GetLastUser(DWORD keynum, TUser &u, DWORD &tid);
BOOL  APIENTRY GetNextUser(DWORD keynum, TUser &u, DWORD &tid);
BOOL  APIENTRY GetPrevUser(DWORD keynum, TUser &u, DWORD &tid);
DWORD APIENTRY GetTotalUsers();
BOOL  APIENTRY SearchUserById(DWORD id, TUser &u, DWORD &tid);
BOOL  APIENTRY SearchUserByLastName(const char *name, TUser &u, DWORD &tid);
BOOL  APIENTRY SearchUserByName(const char *name, TUser &u, DWORD &tid);
BOOL  APIENTRY SearchUserBySecurity(const char *security, TUser &u, DWORD &tid);
BOOL  APIENTRY SearchUserByLastCall(const FILETIME &ft, TUser &u, DWORD &tid);   // 452.1f
BOOL  APIENTRY SetUserVariable(DWORD id, const char *section, const char *key, const char *data);
BOOL  APIENTRY UpdateUser(TUser &u);

///////////////////////////////////////////////////////////////////////////
//! Convenience functions for accessing the set of conferences that the user
//! can access.  The 'flags' parameter in these functions refers to the
//! user's per-conference read flags.  Using 0 as the 'flags' parameter
//! means ignore it when looking for conferences.
///////////////////////////////////////////////////////////////////////////

DWORD APIENTRY GetEffectiveConferenceGroupCount();
DWORD APIENTRY GetEffectiveConferenceCount(DWORD group, DWORD flags);
long  APIENTRY GetFirstConference(DWORD group, DWORD flags);
long  APIENTRY GetLastConference(DWORD group, DWORD flags);
long  APIENTRY GetNextConference(DWORD group, DWORD flags, DWORD conf);
long  APIENTRY GetPrevConference(DWORD group, DWORD flags, DWORD conf);
long  APIENTRY GetFirstConferenceUnread();
long  APIENTRY GetNextConferenceUnread(DWORD conf);
long  APIENTRY GetPrevConferenceUnread(DWORD conf);
BOOL  APIENTRY IsConferenceInGroup(DWORD group, DWORD conf);

///////////////////////////////////////////////////////////////////////////
//! Convenience functions for accessing the set of file areas that the user
//! can access.  Unlike the conference functions, the 'flags' parameter in
//! these functions refers to the user's access flags in the file area
//! (that is, list/download/upload/sysop).  Using 0 as the 'flags' parameter
//! means ignore it when looking for file areas.
///////////////////////////////////////////////////////////////////////////

DWORD APIENTRY GetEffectiveFileGroupCount();
DWORD APIENTRY GetEffectiveFileAreaCount(DWORD group, DWORD flags);
long  APIENTRY GetFirstFileArea(DWORD group, DWORD flags);
long  APIENTRY GetLastFileArea(DWORD group, DWORD flags);
long  APIENTRY GetNextFileArea(DWORD group, DWORD flags, DWORD area);
long  APIENTRY GetPrevFileArea(DWORD group, DWORD flags, DWORD area);
BOOL  APIENTRY IsFileAreaInGroup(DWORD group, DWORD area);

///////////////////////////////////////////////////////////////////////////
//! Functions to get and set the current user's per-conference information.
///////////////////////////////////////////////////////////////////////////

DWORD APIENTRY GetLastRead(DWORD conf);
DWORD APIENTRY GetFirstUnread(DWORD conf);
DWORD APIENTRY GetConfFlags(DWORD conf);
BOOL  APIENTRY SetLastRead(DWORD conf, DWORD lastread);
BOOL  APIENTRY SetConfFlags(DWORD conf, DWORD flags);

///////////////////////////////////////////////////////////////////////////
//! Functions to get and set an arbitrary user's per-conference information.
///////////////////////////////////////////////////////////////////////////

DWORD APIENTRY GetUserLastRead(DWORD userid, DWORD conf);
DWORD APIENTRY GetUserFirstUnread(DWORD userid, DWORD conf);
DWORD APIENTRY GetUserConfFlags(DWORD userid, DWORD conf);
BOOL  APIENTRY SetUserLastRead(DWORD userid, DWORD conf, DWORD lastread);
BOOL  APIENTRY SetUserConfFlags(DWORD userid, DWORD conf, DWORD flags);

///////////////////////////////////////////////////////////////////////////
//! Write an entry to a log file.  The 'fname' parameter must NOT contain a
//! full path, just a file name.
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY WriteLogEntry(const char *fname, const char *text);

///////////////////////////////////////////////////////////////////////////
//! Write an entry to the current node's activity log file.
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY WriteActivityLogEntry(const char *text);

///////////////////////////////////////////////////////////////////////////
//! Check the spelling of a string based on the server's spelling dictionary.
//! Returns the position and length of the bad word, if any.
//! - Suggest alternate spellings for a misspelled word.
//! - Add a word to the auxiliary dictionary.
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY SpellCheckLine(const char *s, DWORD startpos, DWORD &badpos, DWORD &badlen);
DWORD APIENTRY SpellCheckSuggest(const char *s, TSpellSuggestList &sl);
BOOL  APIENTRY SpellCheckAddWord(const char *s);

///////////////////////////////////////////////////////////////////////////
//! Open a communications channel.  Channels are named, and created on the
//! fly as necessary.  Messages can either be broadcast ('destid'=0), or
//! directed to a specific recipient.  The 'userdata' parameter can be used
//! to distinguish different formats of the message data.
///////////////////////////////////////////////////////////////////////////

DWORD APIENTRY OpenChannel(const char *name);
BOOL  APIENTRY CloseChannel(DWORD chandle);
BOOL  APIENTRY WriteChannel(DWORD chandle, DWORD destid, DWORD userdata, const void *data, DWORD datasize);

///////////////////////////////////////////////////////////////////////////
//! Get the Qwk packet size limits based on the user's reported speed.
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY GetQwkBaudLimits(DWORD &perpacket, DWORD &perconference);

///////////////////////////////////////////////////////////////////////////
//! Retrieve a service record by name.  The service record contains an
//! appropriate IP address and port to pass to connect() to establish
//! communications with the service.  Since the communications with the
//! service does not take place through the Wildcat server, no security or
//! authentication is provided by default.  The
//! GetWildcatServerContextHandle and WildcatServerCreateContextByHandle
//! functions are useful if you need to communicate with the Wildcat server
//! under the context of a logged in user.
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY GetServiceByName(const char *name, TWildcatService &service);

///////////////////////////////////////////////////////////////////////////
//! Register a service with the Wildcat server.  The port number must be
//! filled in before calling this function.  The service remains registered
//! until the process running the service is disconnected from the Wildcat
//! server.
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY RegisterService(TWildcatService &service);
BOOL  APIENTRY CheckNetworkAddress(DWORD clientip);

///////////////////////////////////////////////////////////////////////////
//! These functions are used to arbitrate access to CD-ROM changers and such
//! when files are marked for copy-before-download.  After submitting the
//! pathnames of the files to be retrieved, with a unique Id for each file,
//! GetNextCopyRequest should be called in a loop to determine which file to
//! copy next.  If a positive number is returned, it is the id of a request
//! to copy.  If 0 is returned, there are no more requests.  If -1 is
//! returned there are still requests pending and the application should
//! delay for a short time and keep trying.  When a file has finished
//! copying, RemoveCopyRequest must be called so that other clients may
//! access files they have queued.
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY SubmitCopyRequest(DWORD id, const char *fn);
DWORD APIENTRY GetNextCopyRequest();
BOOL  APIENTRY RemoveCopyRequest(DWORD id);

///////////////////////////////////////////////////////////////////////////
//! Return connection info for the given connectionid or the next higher
//! connectionid. Returns FALSE when there is no higher connectionid.
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY GetConnectionInfo(DWORD connectionid, TConnectionInfo &ci);

///////////////////////////////////////////////////////////////////////////
//! Modify the amount of time the current user has remaining for the day.
//! Negative values are ok.
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY AdjustUserTime(long minutes);

//$SDK(0)
///////////////////////////////////////////////////////////////////////////
//! These functions are for tracking current PPP connections. There is
//! a background thread in Wconline that periodically calls
//! GetValidPPPAddresses so it can close sockets associated with a PPP
//! connection that has been terminated.
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY RegisterPPPAddress(DWORD address);
BOOL  APIENTRY UnregisterPPPAddress(DWORD address);
BOOL  APIENTRY GetValidPPPAddresses(DWORD *addrs, DWORD &addrlen);
//$SDK(1)

//////////////// NEW SERVER FUNCTION BUILD 446 //////////////

// HLS 02/26/99 10:27 pm
BOOL  APIENTRY GetWildcatServerInfo(TWildcatServerInfo &si);

//////////////// NEW SERVER FUNCTION BUILD 447B2 //////////////

// HLS 06/29/99 11:53 pm
BOOL  APIENTRY GetUserByKeyIndex(DWORD keynum, DWORD idx, TUser &u, DWORD &tid);
BOOL  APIENTRY CheckClientAddress(DWORD clientip, const char *szIPFile);
DWORD APIENTRY CheckClientAddressEx(DWORD clientip, const char *szIPFile);
BOOL  APIENTRY CheckMailIntegrity(DWORD conf, DWORD level);

// HLS 447B7 08/25/99 08:35 pm
BOOL  APIENTRY UpdateMessageFlags(TMsgHeader &msg);

// HLS 448B 12/21/99 08:40 pm
BOOL  APIENTRY DeleteMessageAttachment(TMsgHeader &msg);

/////////////////// HELPER FUNCTIONS (NON RPC) /////////////////
// HLS 02/18/99 10:00 pm

///////////////////////////////////////////////////////////////////////////
//! Given computer name, return the server options for the particular machine.
//! If computer name is "" or null, it will turn the default settings for the
//! system wide services.  If you want the current computer server settings,
//! use GetComputerConfig(cc) instead.
///////////////////////////////////////////////////////////////////////////

BOOL  APIENTRY GetComputerConfigEx(char *szComputerName, TComputerConfig &cc);

///////////////////////////////////////////////////////////////////////////
//! User Extended Database/Profile Helper Functions
///////////////////////////////////////////////////////////////////////////

BOOL APIENTRY ProfileDateToFileDate(const char *szInt64, FILETIME &ft);
BOOL APIENTRY GetUserVariableDate(DWORD id,const char *section,const char *key,FILETIME &ft);
BOOL APIENTRY GetUserProfileDate(DWORD id,const char *key,FILETIME &ft);
BOOL APIENTRY GetUserProfileDateStr(DWORD id,const char *key,const char *format,char *dest,DWORD destsize);
BOOL APIENTRY GetUserProfileTimeStr(DWORD id,const char *key,const char *format,char *dest,DWORD destsize);
BOOL APIENTRY SetUserVariableDate(DWORD id,const char *section,const char *key,FILETIME &ft);
BOOL APIENTRY SetUserProfileDate(DWORD id, const char *key, FILETIME &ft);
BOOL APIENTRY SetUserProfileSystemTime(DWORD id,const char *key,SYSTEMTIME &st);

// HLS 447B6
BOOL APIENTRY GetUserProfileBool(DWORD id, const char *key, BOOL &flag);
BOOL APIENTRY SetUserProfileBool(DWORD id, const char *key, BOOL flag);

// HLS 447.5 10/28/99 04:11 pm
BOOL APIENTRY wcCopyFileToTemp(DWORD area, const char *fn);

// HLS 448.5 04/01/00 04:37 pm
BOOL APIENTRY UpdateUserEx(TUser &user, const char *oldpwd, const char *newpwd);

//!
//! 450.3 07/30/02
//! Wildcat! SASL functions for authentication services
//!

BOOL APIENTRY WcSASLGetMethodName(char *szMethod,
                                  const DWORD dwSize,
                                  const DWORD dwIndex);

//!
//! Check the SASL Login credentials (user is logged in)
//!
DWORD APIENTRY WcSASLAuthenticateUser(TWildcatSASLContext *ctx,
                                      const char *szFromClient,
                                      char *szResponse,
                                      const DWORD dwResponseSize,
                                      TUser &u);

//!
//! Check the SASL Login credentials (user is logged in)
//!
DWORD APIENTRY WcSASLAuthenticateUserEx(TWildcatSASLContext *ctx,
                                        const char *szFromClient,
                                        char *szResponse,
                                        const DWORD dwResponseSize,
                                        const DWORD dwCallType,
                                        const char *szSpeed,
                                        TUser &u);

//!
//! 451.2, 451.10  11/17/2006
//! Check the SASL Login credentials (user is not logged in)
//!
DWORD APIENTRY WcSASLCheckAuthentication(TWildcatSASLContext *ctx,
                                         const char *szFromClient,
                                         char *szResponse,
                                         const DWORD dwResponseSize);

//!
//! 450.3 07/30/02
//! Get the wildcat server process running times
//!

BOOL APIENTRY WcGetProcessTimes(TWildcatProcessTimes &pt);

//! 450.7
//! Set the context peer address
//!

BOOL APIENTRY SetContextPeerAddress(const DWORD address);

//! 450.8 06/18/03
//! Wildcat! INI File Functions. These Wildcat! INI file
//! functions work similar to the Win32 equivalent private
//! profile functions. The key difference is that Win32
//! INI files are local to the machine, where these Wildcat!
//! INI functions use server side files using the Wildcat!
//! file naming syntax, i.e., "wc:\data\productxyz.ini"
//!

BOOL APIENTRY WcGetPrivateProfileString
                  (const char *sect,
                   const char *key,
                   const char *defvalue,
                   char *dest,
                   DWORD *destsize,
                   const char *inifile);

BOOL APIENTRY WcWritePrivateProfileString
                  (const char *sect,
                   const char *key,
                   const char *value,
                   const char *inifile);

BOOL APIENTRY WcGetPrivateProfileSection
                  (const char *sect,
                   char *dest,
                   DWORD *destsize,
                   const char *inifile);


//! 451.2 07/18/04
//! Extended WcCreateFileEx() function returns TwcOpenFileInfo
//! structure. Useful when you need to open a file and obtain
//! file information in one single RPC call.

WCHANDLE APIENTRY WcCreateFileEx
                  (const char *fn,
                   DWORD access,
                   DWORD sharemode,
                   DWORD create,
                   TwcOpenFileInfo *pwcofi);

//! 451.5 10/04/05
//! GetConnectionInfoFromChallenge() function returns TConnectionInfo
//! for a given challenge.

BOOL APIENTRY GetConnectionInfoFromChallenge(const char *challenge,
                                             TConnectionInfo &ci);

//! 451.6
//! DeleteUserVariable - delete extended user section or key

BOOL  APIENTRY DeleteUserVariable(DWORD id,
                                  const char *section,
                                  const char *key);

//! 451.9
//! WcCheckUserName - Return FALSE if user name has invalid characters

BOOL APIENTRY WcCheckUserName(const char *szName);

//! 451.9
//! WcSetMessageAttachments - helps prepare attachment field

BOOL APIENTRY WcSetMessageAttachment(TMsgHeader &msg,
                                     const char *szFileName,
                                     const BOOL bCopyTo);

//! WcLocalCopyToServer - copy local side file to server side wc:\ file

BOOL APIENTRY WcLocalCopyToServer(const char *szLocal,
                                  const char *szServer,
                                  const int msSlice);


//! 453.2
//! Domain Server Functions

BOOL  APIENTRY GetMakewildEx(const char *szDomain, const BOOL setdomain, TMakewild &mw);
BOOL  APIENTRY WcSetCurrentDomain(const char *szDomain);
BOOL  APIENTRY WcGetCurrentDomain(char *szDomain, DWORD dwSize);
BOOL  APIENTRY WcGetDefaultDomain(char *szBuffer, const DWORD dwSize);
DWORD APIENTRY WcGetDomainCount();
BOOL  APIENTRY WcGetDomain(const DWORD index, char *szDomain, DWORD dwSize);
BOOL  APIENTRY WcGetDomainConfigString(const char *szDomain, const char *szSection, const char *szKey, char *szValue, const DWORD dwSize, const char *szDefault);
BOOL  APIENTRY WcGetDomainConfigBool(const char *szDomain, const char *szSection, const char *szKey, BOOL *bVal, BOOL bDef);
BOOL  APIENTRY WcGetDomainConfigInt(const char *szDomain, const char *szSection, const char *szKey, DWORD *dwValue, DWORD dwDefault);
BOOL  APIENTRY WcGetDomainConfigSection(const char *szDomain, const char *szSection, char *szBuffer, const DWORD dwBufSize, DWORD *dwSize);
BOOL  APIENTRY WcGetHttpConfigVar(const char *szSection, const char *szKey, char *szValue, const DWORD dwSize, const char *szDefault);
BOOL  APIENTRY WcGetConfigFileVar(const char *szFile, const char *szSection, const char *szKey, char *szValue, const DWORD dwSize, const char *szDefault);

//! 453.3h
BOOL  APIENTRY WcGetVirtualDomainBool(const char *szDomain, const char *szSection, const char *szKey, BOOL *bVal, BOOL bDef);
BOOL  APIENTRY WcGetVirtualDomainVar(const char *szDomain,
                                    const char *szSection,
                                    const char *szKey,
                                    char *szValue,
                                    const DWORD dwSize,
                                    const char *szDefault);

//! 453.3
//! Set Context/Connection Status (activity)

BOOL APIENTRY WcSetConnectionStatus(const char *activity);

//! 453.5T8
//! Get unique server guid across all clients, see structure TWildcatServerGuid
//!

BOOL APIENTRY WcGetWildcatServerGuid(TWildcatServerGuid &wg);

//! 454.2F10
//! Get unique QUEUE guid, see structure TWildcatServerGuid
//!

BOOL APIENTRY WcGetWildcatQueueGuid(const char *qname, TWildcatServerGuid &wg);

//! 454.6 07/24/17 10:01 pm
//! Get Geographical Location Information by IP Address
//!

BOOL APIENTRY WcGetGeoIP(const char *ip, TWildcatGeoIP &geoip, const char *lang);


#ifdef __cplusplus
} // extern "C"
#endif

#endif
