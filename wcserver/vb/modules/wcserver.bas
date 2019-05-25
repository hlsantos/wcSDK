Attribute VB_Name = "wcserver" 

'------------------------------------------------------------------------
'Visual Basic Wildcat! SDK API v6.1.451.9
'(c) copyright 1998-2006 by Santronics Software Inc.. All Rights Reserved.
'
'Automatically generated from wcserver.h by CPP2BAS
'------------------------------------------------------------------------

'//! Group: Client SDK Functions

'//! The functions to get the Wildcat version and build can be called before
'//! WildcatServerConnect.

Declare Function GetWildcatVersion Lib "wcsrv2.dll" () As Long
Declare Function GetWildcatBuild Lib "wcsrv2.dll" () As Long

'//! 449.5 04/30/01
'//! The functions to get the Wildcat version and build at the server and
'//! can only be called after a context is created

Declare Function WcGetServerVersion Lib "wcsrv2.dll" () As Long
Declare Function WcGetServerBuild Lib "wcsrv2.dll" () As Long

'//! WildcatServerConnect should be called once per application to connect to
'//! the Wildcat server.  The window handle is used as the parent window when
'//! the server connect dialog box is displayed.  If there is no convenient
'//! window handle available, pass NULL.  Console mode applications should
'//! also pass NULL.  WildcatServerConnectSpecific can be called if you know
'//! the machine name of the server you would like to connect to.
'//! WildcatServerDialog allows the user to pick a server from a dialog box.
'//!
'//! WildcatServerConnectLocal() was added in v5.7 to support connections
'//! only to the local computer. Performs no broadcasting.

Declare Function WildcatServerConnect Lib "wcvb.dll" Alias "vbWildcatServerConnect" (ByVal parent As Long) As Boolean
Declare Function WildcatServerConnectSpecific Lib "wcvb.dll" Alias "vbWildcatServerConnectSpecific" (ByVal parent As Long, ByVal computername As String) As Boolean
Declare Function WildcatServerConnectLocal Lib "wcsrv2.dll" (ByVal parent As Long) As Boolean
Declare Function WildcatServerDialog Lib "wcsrv2.dll" (ByVal parent As Long, ByVal computername As String, ByVal namesize As Long) As Boolean
Declare Function SetWildcatErrorMode Lib "wcsrv2.dll" (ByVal verbose As Long) As Boolean
Declare Function WildcatServerShutdown Lib "wcsrv2.dll" (ByVal pwd As String, ByVal force As Long) As Boolean

'//! GetConnectedServer retrieves the computer name of the connected server

Declare Function GetConnectedServer Lib "wcvb.dll" Alias "vbGetConnectedServer" () As String

'//! These functions start and stop a thread-specific context for this client
'//! on the server.  Even if an application only has one thread, the
'//! WildcatServerCreateContext function must be called before any other
'//! functions will work.
'//!
'//! WildcatServerCreateContextFromHandle creates a new client context that
'//! refers to an existing context on the server.  The handle is generally
'//! retrieved using GetWildcatServerContextHandle in one application, and
'//! passed to WildcatServerCreateContextFromHandle in another application.

Declare Function WildcatServerCreateContext Lib "wcsrv2.dll" () As Boolean
Declare Function WildcatServerCreateContextFromHandle Lib "wcsrv2.dll" (ByVal context As Long) As Boolean
Declare Function WildcatServerCreateContextFromChallenge Lib "wcsrv2.dll" (ByVal challenge As String) As Boolean
Declare Function GetWildcatServerContextHandle Lib "wcsrv2.dll" () As Long
Declare Function WildcatServerDeleteContext Lib "wcsrv2.dll" () As Boolean

'//! This function sets up a callback for the client application.
'//! Channel messages are presented to the client through this
'//! callback mechanism.

Declare Function SetupWildcatCallback Lib "wcsrv2.dll" (ByVal cbproc As Long, ByVal userdata As Long) As Boolean
Declare Function RemoveWildcatCallback Lib "wcsrv2.dll" () As Boolean

'//! This function is used to grant another thread in the same application
'//! equivalent access as the thread that calls this function.  It causes the
'//! other thread to refer to the same server context.  This is a lightweight
'//! version of WildcatServerCreateContextFromHandle.  One difference is that
'//! since this function does not create a new client context,
'//! WildcatServerDeleteContext must only be called once for this context,
'//! even though there may be more than one thread accessing it.

Declare Function GrantThreadAccess Lib "wcsrv2.dll" (ByVal tid As Long) As Boolean

'//! These two functions allow you to more directly manipulate the Wildcat
'//! server context associated with the current thread.  Like
'//! GrantThreadAccess, the Wildcat server is only aware of one instance of
'//! the context, so WildcatServerDeleteContext must only be called once per
'//! server context.

Declare Function GetWildcatThreadContext Lib "wcsrv2.dll" () As Long
Declare Function SetWildcatThreadContext Lib "wcsrv2.dll" (ByVal context As Long) As Boolean

'//! Returns the current node number, or 0 if no node number has been
'//! allocated.

Declare Function GetNode Lib "wcsrv2.dll" () As Long

'//! Set the current node status (nsDown, nsUp, nsSigningOn, nsLoggedIn).

Declare Function SetNodeStatus Lib "wcsrv2.dll" (ByVal nodestatus As Long) As Boolean

'//! Set the node down status (ndNone, ndRefuseLogin, ndDown).

'//! Get the TMakewild global configuration record.

Declare Function GetMakewild Lib "wcvb.dll" Alias "vbGetMakewild" (mw As TMakewild) As Boolean
Declare Function GetComputerConfig Lib "wcvb.dll" Alias "vbGetComputerConfig" (cc As TComputerConfig) As Boolean

'//! Get the challenge string used for MD5 password authentication.

Declare Function GetChallengeString Lib "wcvb.dll" Alias "vbGetChallengeString" () As String

'//! Log in to the Wildcat server as the 'system'.  This gives unrestricted
'//! access to all aspects of the server.  The computer from which this
'//! function is called must have been set up with the Wildcat System
'//! password, if any.

Declare Function LoginSystem Lib "wcsrv2.dll" () As Boolean

'//! Look up a user account by name, and return basic account information.

Declare Function LookupName Lib "wcvb.dll" Alias "vbLookupName" (ByVal name As String, uinfo As TUserInfo) As Boolean

'//! Allocate a node for a particular call type.  If a specific node is
'//! required, pass it in the 'node' parameter, otherwise pass zero.

Declare Function AllocateNode Lib "wcsrv2.dll" (ByVal node As Long, ByVal calltype As Long, ByVal speed As String) As Boolean

'//! Log in to the userver under a user account.  All further access to the
'//! server is checked based on the access profile(s) of the user.  The
'//! password can either be plaintext or an MD5 digest string.

Declare Function LoginUser Lib "wcvb.dll" Alias "vbLoginUser" (ByVal userid As Long, ByVal password As String, user As TUser) As Boolean
Declare Function LoginUserEx Lib "wcvb.dll" Alias "vbLoginUserEx" (ByVal userid As Long, ByVal password As String, ByVal calltype As Long, ByVal speed As String, user As TUser) As Boolean
Declare Function LoginRadiusUser Lib "wcvb.dll" Alias "vbLoginRadiusUser" (ByVal userid As Long, ByVal chapid As Byte, challenge As Byte, ByVal challengesize As Long, challresponse As Byte, user As TUser) As Boolean

'//! Log out of the server.  This is called no matter whether you log in to
'//! the server using LoginSystem or LoginUser.

Declare Function LogoutUser Lib "wcsrv2.dll" () As Boolean

'//! Checks to see whether the current context is logged in or not.  Returns
'//! the user record if it is logged in as a user.  See clSessionXXXX
'//! constants

Declare Function WildcatLoggedIn Lib "wcvb.dll" Alias "vbWildcatLoggedIn" (user As TUser) As Long

'//! Gets the number of users currently online.

Declare Function GetUsersOnline Lib "wcsrv2.dll" () As Long

'//! Get the object flags for a particular access profile.  This may be
'//! called before a user is logged in.

Declare Function GetProfileObjectFlags Lib "wcsrv2.dll" (ByVal profile As String, ByVal objectid As Long) As Long

'//! The Wildcat server file API functions are modeled after the Win32 file
'//! API functions.  See the Win32 API documentation for details regarding
'//! these functions. See WCPATHS.DOC for information regarding the format of
'//! the path names that may be used with these functions.

Declare Function WcCloseHandle Lib "wcsrv2.dll" (ByVal h As Long) As Boolean
Declare Function WcCreateDirectory Lib "wcsrv2.dll" (ByVal dir As String) As Boolean
Declare Function WcRemoveDirectory Lib "wcsrv2.dll" (ByVal dir As String) As Boolean
Declare Function WcCreateFile Lib "wcsrv2.dll" (ByVal fn As String, ByVal access As Long, ByVal sharemode As Long, ByVal create As Long) As Long
Declare Function WcDeleteFile Lib "wcsrv2.dll" (ByVal fn As String) As Boolean
Declare Function WcExistFile Lib "wcsrv2.dll" (ByVal fn As String) As Boolean
Declare Function WcFindFirstFile Lib "wcvb.dll" Alias "vbWcFindFirstFile" (ByVal fn As String, fd As WIN32_FIND_DATA) As Long
Declare Function WcFindNextFile Lib "wcvb.dll" Alias "vbWcFindNextFile" (ByVal ff As Long, fd As WIN32_FIND_DATA) As Boolean
Declare Function WcFindClose Lib "wcsrv2.dll" (ByVal ff As Long) As Boolean
Declare Function WcGetFileSize Lib "wcsrv2.dll" (ByVal h As Long) As Long
Declare Function WcGetFileTime Lib "wcsrv2.dll" (ByVal h As Long, ft As FILETIME) As Boolean
Declare Function WcGetFileTimeByName Lib "wcsrv2.dll" (ByVal fn As String, ft As FILETIME) As Boolean
Declare Function WcMoveFile Lib "wcsrv2.dll" (ByVal src As String, ByVal dest As String) As Boolean
Declare Function WcReadFile Lib "wcsrv2.dll" (ByVal h As Long, buffer As Any, ByVal requested As Long, read As Long) As Boolean
Declare Function WcReadLine Lib "wcsrv2.dll" (ByVal h As Long, buffer As Any, ByVal buflen As Long) As Boolean
Declare Function WcSetEndOfFile Lib "wcsrv2.dll" (ByVal h As Long) As Boolean
Declare Function WcSetFilePointer Lib "wcsrv2.dll" (ByVal h As Long, ByVal dist As LONG, ByVal movemethod As Long) As Long
Declare Function WcSetFileTime Lib "wcsrv2.dll" (ByVal h As Long, ft As FILETIME) As Boolean
Declare Function WcWriteFile Lib "wcsrv2.dll" (ByVal h As Long, buffer As Any, ByVal requested As Long, written As Long) As Boolean
Declare Function WcRenameFile Lib "wcsrv2.dll" (ByVal from As String, ByVal toname As String) As Boolean

Declare Function WcResolvePathName Lib "wcsrv2.dll" (ByVal wfname As String, access As Long, share As Long, create As Long, ByVal dest As String, ByVal destsize As Long) As Boolean

'//! Get the connection Id for the current context.  Connection Ids are
'//! unique and can reasonably be assumed not to repeat during the time the
'//! server is up.

Declare Function GetConnectionId Lib "wcsrv2.dll" () As Long

'//! Get the total number of calls made to the system (not server API calls,
'//! user calls). The 'increment' parameter determines whether or not the
'//! count is increased by one before returning the result.

Declare Function GetTotalCalls Lib "wcsrv2.dll" (ByVal increment As Long) As Long

'//! This function combines a WcCreateFile, WcReadFile, and WcCloseHandle
'//! into one operation.

Declare Function GetText Lib "wcvb.dll" Alias "vbGetText" (byval fn As String) As String

'//! The following functions access the security data in the Wildcat server.
'//! Each 'securable' object (conference, file area, door, etc) has a unique
'//! Object Id stored with it.  Access profiles are tables of Object Ids and
'//! access flags. When a user logs in, a composite access table consisting
'//! of the logical OR of all the flags in the user' access profiles is
'//! created.  These functions access the information in that composite
'//! array.
'//!
'//! Object flags are often simply zero or one to indicate no access or allow
'//! access, but the individual bits may mean different things such as
'//! Join/Read/Write/Sysop access in a conference area.

Declare Function GetObjectFlags Lib "wcsrv2.dll" (ByVal objectid As Long) As Long
Declare Function GetMultipleObjectFlags Lib "wcsrv2.dll" (objectid As Long, ByVal count As Long, flags As Long) As Boolean
Declare Function GetObjectById Lib "wcvb.dll" Alias "vbGetObjectById" (ByVal objectid As Long, objectname As TObjectName) As Boolean
Declare Function GetMultipleObjectsById Lib "wcvb.dll" Alias "vbGetMultipleObjectsById" (objectid As Long, ByVal count As Long, objectname As TObjectName) As Boolean
Declare Function GetObjectByName Lib "wcvb.dll" Alias "vbGetObjectByName" (ByVal classid As Long, ByVal name As String, objectname As TObjectName, tid As Long) As Boolean
Declare Function GetNextObjectByName Lib "wcvb.dll" Alias "vbGetNextObjectByName" (objectname As TObjectName, tid As Long) As Boolean
Declare Function GetStringObjectId Lib "wcsrv2.dll" (ByVal objectclass As Long, ByVal name As String) As Long
Declare Function GetStringObjectFlags Lib "wcsrv2.dll" (ByVal objectclass As Long, ByVal name As String) As Long

'//! These functions access the list of security profiles in the server.

Declare Function GetSecurityProfileCount Lib "wcsrv2.dll" () As Long
Declare Function GetSecurityProfileNames Lib "wcvb.dll" Alias "vbGetSecurityProfileNames" () As Variant
Declare Function GetSecurityProfileByIndex Lib "wcvb.dll" Alias "vbGetSecurityProfileByIndex" (ByVal index As Long, profile As TSecurityProfile) As Boolean
Declare Function GetSecurityProfileByName Lib "wcvb.dll" Alias "vbGetSecurityProfileByName" (ByVal name As String, profile As TSecurityProfile) As Boolean

'//! These functions access the list of access profile names in the server.

Declare Function GetAccessProfileCount Lib "wcsrv2.dll" () As Long
Declare Function GetAccessProfileNames Lib "wcvb.dll" Alias "vbGetAccessProfileNames" () As Variant
Declare Function GetAccessProfileName Lib "wcvb.dll" Alias "vbGetAccessProfileName" (ByVal index As Long) As String

'//! These functions access the list of conferences (message areas) in
'//! the server.

Declare Function GetConferenceCount Lib "wcsrv2.dll" () As Long
Declare Function GetConfDesc Lib "wcvb.dll" Alias "vbGetConfDesc" (ByVal conference As Long, cd As TConfDesc) As Boolean

'//! These functions access the list of conference groups in the server.

Declare Function GetConferenceGroupCount Lib "wcsrv2.dll" () As Long
Declare Function GetConferenceGroup Lib "wcvb.dll" Alias "vbGetConferenceGroup" (ByVal index As Long, cg As TConferenceGroup) As Boolean

'//! These functions access the list of file areas in the server.

Declare Function GetFileAreaCount Lib "wcsrv2.dll" () As Long
Declare Function GetFileArea Lib "wcvb.dll" Alias "vbGetFileArea" (ByVal area As Long, fa As TFileArea) As Boolean

'//! These functions access the list of file groups in the server.

Declare Function GetFileGroupCount Lib "wcsrv2.dll" () As Long
Declare Function GetFileGroup Lib "wcvb.dll" Alias "vbGetFileGroup" (ByVal index As Long, fg As TFileGroup) As Boolean

'//! These functions access the list of doors in the server.

Declare Function GetDoorCount Lib "wcsrv2.dll" () As Long
Declare Function GetDoor Lib "wcvb.dll" Alias "vbGetDoor" (ByVal index As Long, di As TDoorInfo) As Boolean

'//! These functions access the list of languages in the server.

Declare Function GetLanguageCount Lib "wcsrv2.dll" () As Long
Declare Function GetLanguage Lib "wcvb.dll" Alias "vbGetLanguage" (ByVal index As Long, li As TLanguageInfo) As Boolean

'//! This function gets a specific modem profile from the server.

Declare Function GetModemProfile Lib "wcvb.dll" Alias "vbGetModemProfile" (ByVal name As String, mp As TModemProfile) As Boolean

'//! Get the current maximum number of nodes that have been allocated.

Declare Function GetNodeCount Lib "wcsrv2.dll" () As Long

'//! Get the maximum number of concurrent users supported by this
'//! installation of Wildcat.

Declare Function GetMaximumUserCount Lib "wcsrv2.dll" () As Long

'//! Get a node configuration record for the specified node.  Use
'//! by Wconline to start modem nodes.

Declare Function GetNodeConfig Lib "wcvb.dll" Alias "vbGetNodeConfig" (ByVal node As Long, nc As TNodeConfig) As Boolean

'//! Get a node information record for a specific node.

Declare Function GetNodeInfo Lib "wcvb.dll" Alias "vbGetNodeInfo" (ByVal node As Long, ni As TwcNodeInfo) As Boolean

'//! Get a node information record for a specific connection Id.

Declare Function GetNodeInfoByConnectionId Lib "wcvb.dll" Alias "vbGetNodeInfoByConnectionId" (ByVal id As Long, ni As TwcNodeInfo) As Boolean

'//! Get a node information record for a specific name.

Declare Function GetNodeInfoByName Lib "wcvb.dll" Alias "vbGetNodeInfoByName" (ByVal name As String, ni As TwcNodeInfo) As Boolean

'//! Get multiple node information records starting at a specific node.

Declare Function GetNodeInfos Lib "wcvb.dll" Alias "vbGetNodeInfos" (ByVal node As Long, ByVal count As Long, ni As TwcNodeInfo) As Boolean

'//! Set the current node's information record.  Only non-critical fields are
'//! allowed to be changed by this function.

Declare Function SetNodeInfo Lib "wcvb.dll" Alias "vbSetNodeInfo" (ni As TwcNodeInfo) As Boolean

'//! Set the current activity string for the current node.

Declare Function SetNodeActivity Lib "wcsrv2.dll" (ByVal activity As String) As Boolean

'//! Server State Functions

Declare Function SetServerState Lib "wcsrv2.dll" (ByVal port As String, ByVal state As Long) As Boolean
Declare Function GetServerState Lib "wcvb.dll" Alias "vbGetServerState" (ByVal index As Long, ss As TServerState) As Boolean
Declare Function SetNodeServerState Lib "wcsrv2.dll" (ByVal node As Long, ByVal state As Long) As Boolean

'//! The following functions access the file database in Wildcat.  The
'//! functions should be straightforward with the following notes:
'//!
'//! - GetFileRecByXxx gets a specific record by key.  SearchFileRecByXxx
'//!   searches for matching record, or the next record in the database,
'//!   based on a key.
'//!
'//! - FileSearch returns an array of __int64 (64-bit integers).  The high 32
'//!   bits indicates the file area of the record, and the low 32 bits
'//!   indicates the absolute reference number of the record.
'//!   GetFileRecAbsolute gets a specific file record.
'//!
'//! - Most functions return a TFileRecord which does not contain the long
'//!   file description. To retrieve the long file description, use
'//!   GetFullFileRec.

Declare Function AddFileRec Lib "wcvb.dll" Alias "vbAddFileRec" (f As TFullFileRecord) As Boolean
Declare Function DeleteFileRec Lib "wcvb.dll" Alias "vbDeleteFileRec" (f As TFileRecord, ByVal disktoo As Long) As Boolean
Declare Function FileSearch Lib "wcvb.dll" Alias "vbFileSearch" (byval s As String) As Variant
Declare Function GetFileRecAbsolute Lib "wcvb.dll" Alias "vbGetFileRecAbsolute" (ByVal ref As Long, f As TFileRecord) As Boolean
Declare Function GetFileRecByNameArea Lib "wcvb.dll" Alias "vbGetFileRecByNameArea" (ByVal name As String, ByVal area As Long, f As TFileRecord, tid As Long) As Boolean
Declare Function GetFileRecByAreaName Lib "wcvb.dll" Alias "vbGetFileRecByAreaName" (ByVal area As Long, ByVal name As String, f As TFileRecord, tid As Long) As Boolean
Declare Function GetFileRecByAreaDate Lib "wcvb.dll" Alias "vbGetFileRecByAreaDate" (ByVal area As Long, t As FILETIME, f As TFileRecord, tid As Long) As Boolean
Declare Function GetFileRecByUploader Lib "wcvb.dll" Alias "vbGetFileRecByUploader" (ByVal id As Long, f As TFileRecord, tid As Long) As Boolean
Declare Function GetFirstFileRec Lib "wcvb.dll" Alias "vbGetFirstFileRec" (ByVal keynum As Long, f As TFileRecord, tid As Long) As Boolean
Declare Function GetFullFileRec Lib "wcvb.dll" Alias "vbGetFullFileRec" (f As TFileRecord, full As TFullFileRecord) As Boolean
Declare Function GetLastFileRec Lib "wcvb.dll" Alias "vbGetLastFileRec" (ByVal keynum As Long, f As TFileRecord, tid As Long) As Boolean
Declare Function GetNextFileRec Lib "wcvb.dll" Alias "vbGetNextFileRec" (ByVal keynum As Long, f As TFileRecord, tid As Long) As Boolean
Declare Function GetPrevFileRec Lib "wcvb.dll" Alias "vbGetPrevFileRec" (ByVal keynum As Long, f As TFileRecord, tid As Long) As Boolean
Declare Function GetTotalFiles Lib "wcsrv2.dll" () As Long
Declare Function GetTotalFilesInArea Lib "wcsrv2.dll" (ByVal area As Long) As Long
Declare Function GetTotalFilesInGroup Lib "wcsrv2.dll" (ByVal group As Long) As Long
Declare Function IncrementDownloadCount Lib "wcvb.dll" Alias "vbIncrementDownloadCount" (f As TFileRecord) As Boolean
Declare Function SearchFileRecByNameArea Lib "wcvb.dll" Alias "vbSearchFileRecByNameArea" (ByVal name As String, ByVal area As Long, f As TFileRecord, tid As Long) As Boolean
Declare Function SearchFileRecByAreaName Lib "wcvb.dll" Alias "vbSearchFileRecByAreaName" (ByVal area As Long, ByVal name As String, f As TFileRecord, tid As Long) As Boolean
Declare Function SearchFileRecByAreaDate Lib "wcvb.dll" Alias "vbSearchFileRecByAreaDate" (ByVal area As Long, t As FILETIME, f As TFileRecord, tid As Long) As Boolean
Declare Function SearchFileRecByDateArea Lib "wcvb.dll" Alias "vbSearchFileRecByDateArea" (t As FILETIME, ByVal area As Long, f As TFileRecord, tid As Long) As Boolean
Declare Function SearchFileRecByUploader Lib "wcvb.dll" Alias "vbSearchFileRecByUploader" (ByVal id As Long, f As TFileRecord, tid As Long) As Boolean
Declare Function UpdateFileRec Lib "wcvb.dll" Alias "vbUpdateFileRec" (f As TFileRecord) As Boolean
Declare Function UpdateFullFileRec Lib "wcvb.dll" Alias "vbUpdateFullFileRec" (f As TFullFileRecord) As Boolean

'//! The following functions access the message databases in Wildcat.
'//! Messages are identified by there conference number and Id.  Message Ids
'//! are assigned when the message is added to the database and never
'//! reassigned.  Message Ids are very large numbers, so a separate message
'//! 'Number' is provided for convenience.  Message numbers are assigned
'//! sequentially within a conference.

Declare Function AddMessage Lib "wcvb.dll" Alias "vbAddMessage" (msg As TMsgHeader, ByVal text As String) As Boolean
Declare Function DeleteMessage Lib "wcvb.dll" Alias "vbDeleteMessage" (msg As TMsgHeader) As Boolean
Declare Function GetHighMessageNumber Lib "wcsrv2.dll" (ByVal conf As Long) As Long
Declare Function GetLowMessageNumber Lib "wcsrv2.dll" (ByVal conf As Long) As Long
Declare Function GetMessageById Lib "wcvb.dll" Alias "vbGetMessageById" (ByVal conf As Long, ByVal msgid As Long, msg As TMsgHeader) As Boolean
Declare Function GetMsgIdFromNumber Lib "wcsrv2.dll" (ByVal conf As Long, ByVal number As Long) As Long
Declare Function GetMsgNumberFromId Lib "wcsrv2.dll" (ByVal conf As Long, ByVal msgid As Long) As Long
Declare Function GetNextMessage Lib "wcvb.dll" Alias "vbGetNextMessage" (msg As TMsgHeader) As Boolean
Declare Function GetPrevMessage Lib "wcvb.dll" Alias "vbGetPrevMessage" (msg As TMsgHeader) As Boolean
Declare Function GetTotalMessages Lib "wcsrv2.dll" () As Long
Declare Function GetTotalMessagesInConference Lib "wcsrv2.dll" (ByVal conf As Long) As Long
Declare Function GetTotalMessagesInGroup Lib "wcsrv2.dll" (ByVal group As Long) As Long
Declare Function IncrementReplyCount Lib "wcvb.dll" Alias "vbIncrementReplyCount" (msg As TMsgHeader) As Boolean
Declare Function IncrementReadCount Lib "wcvb.dll" Alias "vbIncrementReadCount" (msg As TMsgHeader) As Boolean
Declare Function MarkMessageRead Lib "wcvb.dll" Alias "vbMarkMessageRead" (msg As TMsgHeader) As Boolean
Declare Function MessageSearch Lib "wcvb.dll" Alias "vbMessageSearch" (ByVal conf As Long, ByVal msgid As Long, ByVal msflags As Long, ByVal text As String, msg As TMsgHeader) As Boolean
Declare Function SearchMessageById Lib "wcvb.dll" Alias "vbSearchMessageById" (ByVal conf As Long, ByVal msgid As Long, msg As TMsgHeader) As Boolean
Declare Function SetMessagePrivate Lib "wcvb.dll" Alias "vbSetMessagePrivate" (msg As TMsgHeader, ByVal pvt As Long) As Boolean
Declare Function UpdateMessageFidoInfo Lib "wcvb.dll" Alias "vbUpdateMessageFidoInfo" (msg As TMsgHeader) As Boolean

'//! Use this function to define a group of conference numbers and to retrieve
'//! the highest msgid for each conference.

Declare Function GetHighMessageIds Lib "wcsrv2.dll" (ByVal count As Long, conferences As Long, ids As Long) As Boolean

Declare Function SetMessageExported Lib "wcvb.dll" Alias "vbSetMessageExported" (msg As TMsgHeader, ByVal exported As Long) As Boolean

'//! The following functions access the user database in Wildcat.  Like the
'//! file database, GetUserByXxx gets a specific record, and SearchUserByXxx
'//! looks for a matching or the next higher record in the database.
'//! GetUserVariable and SetUserVariable can be used to store private
'//! application-specific information in a user record.  They are similar in
'//! use to the profile functions in the Windows API.

Declare Function AddNewUser Lib "wcvb.dll" Alias "vbAddNewUser" (u As TUser) As Boolean
Declare Function DeleteOtherUser Lib "wcvb.dll" Alias "vbDeleteOtherUser" (u As TUser) As Boolean
Declare Function GetUserById Lib "wcvb.dll" Alias "vbGetUserById" (ByVal id As Long, u As TUser, tid As Long) As Boolean
Declare Function GetUserByLastName Lib "wcvb.dll" Alias "vbGetUserByLastName" (ByVal name As String, u As TUser, tid As Long) As Boolean
Declare Function GetUserByName Lib "wcvb.dll" Alias "vbGetUserByName" (ByVal name As String, u As TUser, tid As Long) As Boolean
Declare Function GetUserBySecurity Lib "wcvb.dll" Alias "vbGetUserBySecurity" (ByVal security As String, u As TUser, tid As Long) As Boolean
Declare Function GetUserVariable Lib "wcvb.dll" Alias "vbGetUserVariable" (ByVal id As Long, byval section As String, byval key As String, byval def As String) As String
Declare Function GetUserVariables Lib "wcvb.dll" Alias "vbGetUserVariables" (ByVal id As Long) As String
Declare Function GetFirstUser Lib "wcvb.dll" Alias "vbGetFirstUser" (ByVal keynum As Long, u As TUser, tid As Long) As Boolean
Declare Function GetLastUser Lib "wcvb.dll" Alias "vbGetLastUser" (ByVal keynum As Long, u As TUser, tid As Long) As Boolean
Declare Function GetNextUser Lib "wcvb.dll" Alias "vbGetNextUser" (ByVal keynum As Long, u As TUser, tid As Long) As Boolean
Declare Function GetPrevUser Lib "wcvb.dll" Alias "vbGetPrevUser" (ByVal keynum As Long, u As TUser, tid As Long) As Boolean
Declare Function GetTotalUsers Lib "wcsrv2.dll" () As Long
Declare Function SearchUserById Lib "wcvb.dll" Alias "vbSearchUserById" (ByVal id As Long, u As TUser, tid As Long) As Boolean
Declare Function SearchUserByLastName Lib "wcvb.dll" Alias "vbSearchUserByLastName" (ByVal name As String, u As TUser, tid As Long) As Boolean
Declare Function SearchUserByName Lib "wcvb.dll" Alias "vbSearchUserByName" (ByVal name As String, u As TUser, tid As Long) As Boolean
Declare Function SearchUserBySecurity Lib "wcvb.dll" Alias "vbSearchUserBySecurity" (ByVal security As String, u As TUser, tid As Long) As Boolean
Declare Function SetUserVariable Lib "wcsrv2.dll" (ByVal id As Long, ByVal section As String, ByVal key As String, ByVal data As String) As Boolean
Declare Function UpdateUser Lib "wcvb.dll" Alias "vbUpdateUser" (u As TUser) As Boolean

'//! Convenience functions for accessing the set of conferences that the user
'//! can access.  The 'flags' parameter in these functions refers to the
'//! user's per-conference read flags.  Using 0 as the 'flags' parameter
'//! means ignore it when looking for conferences.

Declare Function GetEffectiveConferenceGroupCount Lib "wcsrv2.dll" () As Long
Declare Function GetEffectiveConferenceCount Lib "wcsrv2.dll" (ByVal group As Long, ByVal flags As Long) As Long
Declare Function GetFirstConference Lib "wcsrv2.dll" (ByVal group As Long, ByVal flags As Long) As Long
Declare Function GetLastConference Lib "wcsrv2.dll" (ByVal group As Long, ByVal flags As Long) As Long
Declare Function GetNextConference Lib "wcsrv2.dll" (ByVal group As Long, ByVal flags As Long, ByVal conf As Long) As Long
Declare Function GetPrevConference Lib "wcsrv2.dll" (ByVal group As Long, ByVal flags As Long, ByVal conf As Long) As Long
Declare Function GetFirstConferenceUnread Lib "wcsrv2.dll" () As Long
Declare Function GetNextConferenceUnread Lib "wcsrv2.dll" (ByVal conf As Long) As Long
Declare Function GetPrevConferenceUnread Lib "wcsrv2.dll" (ByVal conf As Long) As Long
Declare Function IsConferenceInGroup Lib "wcsrv2.dll" (ByVal group As Long, ByVal conf As Long) As Boolean

'//! Convenience functions for accessing the set of file areas that the user
'//! can access.  Unlike the conference functions, the 'flags' parameter in
'//! these functions refers to the user's access flags in the file area
'//! (that is, list/download/upload/sysop).  Using 0 as the 'flags' parameter
'//! means ignore it when looking for file areas.

Declare Function GetEffectiveFileGroupCount Lib "wcsrv2.dll" () As Long
Declare Function GetEffectiveFileAreaCount Lib "wcsrv2.dll" (ByVal group As Long, ByVal flags As Long) As Long
Declare Function GetFirstFileArea Lib "wcsrv2.dll" (ByVal group As Long, ByVal flags As Long) As Long
Declare Function GetLastFileArea Lib "wcsrv2.dll" (ByVal group As Long, ByVal flags As Long) As Long
Declare Function GetNextFileArea Lib "wcsrv2.dll" (ByVal group As Long, ByVal flags As Long, ByVal area As Long) As Long
Declare Function GetPrevFileArea Lib "wcsrv2.dll" (ByVal group As Long, ByVal flags As Long, ByVal area As Long) As Long
Declare Function IsFileAreaInGroup Lib "wcsrv2.dll" (ByVal group As Long, ByVal area As Long) As Boolean

'//! Functions to get and set the current user's per-conference information.

Declare Function GetLastRead Lib "wcsrv2.dll" (ByVal conf As Long) As Long
Declare Function GetFirstUnread Lib "wcsrv2.dll" (ByVal conf As Long) As Long
Declare Function GetConfFlags Lib "wcsrv2.dll" (ByVal conf As Long) As Long
Declare Function SetLastRead Lib "wcsrv2.dll" (ByVal conf As Long, ByVal lastread As Long) As Boolean
Declare Function SetConfFlags Lib "wcsrv2.dll" (ByVal conf As Long, ByVal flags As Long) As Boolean

'//! Functions to get and set an arbitrary user's per-conference information.

Declare Function GetUserLastRead Lib "wcsrv2.dll" (ByVal userid As Long, ByVal conf As Long) As Long
Declare Function GetUserFirstUnread Lib "wcsrv2.dll" (ByVal userid As Long, ByVal conf As Long) As Long
Declare Function GetUserConfFlags Lib "wcsrv2.dll" (ByVal userid As Long, ByVal conf As Long) As Long
Declare Function SetUserLastRead Lib "wcsrv2.dll" (ByVal userid As Long, ByVal conf As Long, ByVal lastread As Long) As Boolean
Declare Function SetUserConfFlags Lib "wcsrv2.dll" (ByVal userid As Long, ByVal conf As Long, ByVal flags As Long) As Boolean

'//! Write an entry to a log file.  The 'fname' parameter must NOT contain a
'//! full path, just a file name.

Declare Function WriteLogEntry Lib "wcsrv2.dll" (ByVal fname As String, ByVal text As String) As Boolean

'//! Write an entry to the current node's activity log file.

Declare Function WriteActivityLogEntry Lib "wcsrv2.dll" (ByVal text As String) As Boolean

'//! Check the spelling of a string based on the server's spelling dictionary.
'//! Returns the position and length of the bad word, if any.
'//! - Suggest alternate spellings for a misspelled word.
'//! - Add a word to the auxiliary dictionary.

Declare Function SpellCheckLine Lib "wcsrv2.dll" (ByVal s As String, ByVal startpos As Long, badpos As Long, badlen As Long) As Boolean
Declare Function SpellCheckSuggest Lib "wcvb.dll" Alias "vbSpellCheckSuggest" (ByVal s As String, sl As TSpellSuggestList) As Long
Declare Function SpellCheckAddWord Lib "wcsrv2.dll" (ByVal s As String) As Boolean

'//! Open a communications channel.  Channels are named, and created on the
'//! fly as necessary.  Messages can either be broadcast ('destid'=0), or
'//! directed to a specific recipient.  The 'userdata' parameter can be used
'//! to distinguish different formats of the message data.

Declare Function OpenChannel Lib "wcsrv2.dll" (ByVal name As String) As Long
Declare Function CloseChannel Lib "wcsrv2.dll" (ByVal chandle As Long) As Boolean
Declare Function WriteChannel Lib "wcsrv2.dll" (ByVal chandle As Long, ByVal destid As Long, ByVal userdata As Long, data As Any, ByVal datasize As Long) As Boolean

'//! Get the Qwk packet size limits based on the user's reported speed.

Declare Function GetQwkBaudLimits Lib "wcsrv2.dll" (perpacket As Long, perconference As Long) As Boolean

'//! Retrieve a service record by name.  The service record contains an
'//! appropriate IP address and port to pass to connect() to establish
'//! communications with the service.  Since the communications with the
'//! service does not take place through the Wildcat server, no security or
'//! authentication is provided by default.  The
'//! GetWildcatServerContextHandle and WildcatServerCreateContextByHandle
'//! functions are useful if you need to communicate with the Wildcat server
'//! under the context of a logged in user.

Declare Function GetServiceByName Lib "wcvb.dll" Alias "vbGetServiceByName" (ByVal name As String, service As TWildcatService) As Boolean

'//! Register a service with the Wildcat server.  The port number must be
'//! filled in before calling this function.  The service remains registered
'//! until the process running the service is disconnected from the Wildcat
'//! server.

Declare Function RegisterService Lib "wcvb.dll" Alias "vbRegisterService" (service As TWildcatService) As Boolean
Declare Function CheckNetworkAddress Lib "wcsrv2.dll" (ByVal clientip As Long) As Boolean

'//! These functions are used to arbitrate access to CD-ROM changers and such
'//! when files are marked for copy-before-download.  After submitting the
'//! pathnames of the files to be retrieved, with a unique Id for each file,
'//! GetNextCopyRequest should be called in a loop to determine which file to
'//! copy next.  If a positive number is returned, it is the id of a request
'//! to copy.  If 0 is returned, there are no more requests.  If -1 is
'//! returned there are still requests pending and the application should
'//! delay for a short time and keep trying.  When a file has finished
'//! copying, RemoveCopyRequest must be called so that other clients may
'//! access files they have queued.

Declare Function SubmitCopyRequest Lib "wcsrv2.dll" (ByVal id As Long, ByVal fn As String) As Boolean
Declare Function GetNextCopyRequest Lib "wcsrv2.dll" () As Long
Declare Function RemoveCopyRequest Lib "wcsrv2.dll" (ByVal id As Long) As Boolean

'//! Return connection info for the given connectionid or the next higher
'//! connectionid. Returns FALSE when there is no higher connectionid.

Declare Function GetConnectionInfo Lib "wcvb.dll" Alias "vbGetConnectionInfo" (ByVal connectionid As Long, ci As TConnectionInfo) As Boolean

'//! Modify the amount of time the current user has remaining for the day.
'//! Negative values are ok.

Declare Function AdjustUserTime Lib "wcsrv2.dll" (ByVal minutes As Long) As Boolean

Declare Function GetWildcatServerInfo Lib "wcsrv2.dll" (si As TWildcatServerInfo) As Boolean

Declare Function GetUserByKeyIndex Lib "wcvb.dll" Alias "vbGetUserByKeyIndex" (ByVal keynum As Long, ByVal idx As Long, u As TUser, tid As Long) As Boolean
Declare Function CheckClientAddress Lib "wcsrv2.dll" (ByVal clientip As Long, ByVal szIPFile As String) As Boolean
Declare Function CheckMailIntegrity Lib "wcsrv2.dll" (ByVal conf As Long, ByVal level As Long) As Boolean

Declare Function UpdateMessageFlags Lib "wcvb.dll" Alias "vbUpdateMessageFlags" (msg As TMsgHeader) As Boolean

Declare Function DeleteMessageAttachment Lib "wcvb.dll" Alias "vbDeleteMessageAttachment" (msg As TMsgHeader) As Boolean

'//! Given computer name, return the server options for the particular machine.
'//! If computer name is "" or null, it will turn the default settings for the
'//! system wide services.  If you want the current computer server settings,
'//! use GetComputerConfig(cc) instead.

Declare Function GetComputerConfigEx Lib "wcvb.dll" Alias "vbGetComputerConfigEx" (ByVal szComputerName As String, cc As TComputerConfig) As Boolean

'//! User Extended Database/Profile Helper Functions

Declare Function ProfileDateToFileDate Lib "wcsrv2.dll" (ByVal szInt64 As String, ft As FILETIME) As Boolean
Declare Function GetUserVariableDate Lib "wcsrv2.dll" (ByVal id As Long, ByVal section As String, ByVal key As String, ft As FILETIME) As Boolean
Declare Function GetUserProfileDate Lib "wcsrv2.dll" (ByVal id As Long, ByVal key As String, ft As FILETIME) As Boolean
Declare Function GetUserProfileDateStr Lib "wcvb.dll" Alias "vbGetUserProfileDateStr" (ByVal id as Long, ByVal key as string, ByVal format as string) As String
Declare Function GetUserProfileTimeStr Lib "wcvb.dll" Alias "vbGetUserProfileDateStr" (ByVal id as Long, ByVal key as string, ByVal format as string) As String
Declare Function SetUserVariableDate Lib "wcsrv2.dll" (ByVal id As Long, ByVal section As String, ByVal key As String, ft As FILETIME) As Boolean
Declare Function SetUserProfileDate Lib "wcsrv2.dll" (ByVal id As Long, ByVal key As String, ft As FILETIME) As Boolean
Declare Function SetUserProfileSystemTime Lib "wcsrv2.dll" (ByVal id As Long, ByVal key As String, st As SYSTEMTIME) As Boolean

Declare Function GetUserProfileBool Lib "wcsrv2.dll" (ByVal id As Long, ByVal key As String, flag As Long) As Boolean
Declare Function SetUserProfileBool Lib "wcsrv2.dll" (ByVal id As Long, ByVal key As String, ByVal flag As Long) As Boolean

Declare Function wcCopyFileToTemp Lib "wcsrv2.dll" (ByVal area As Long, ByVal fn As String) As Boolean

Declare Function UpdateUserEx Lib "wcvb.dll" Alias "vbUpdateUserEx" (user As TUser, ByVal oldpwd As String, ByVal newpwd As String) As Boolean

'//!
'//! 450.3 07/30/02
'//! Wildcat! SASL functions for authentication services
'//!

Declare Function WcSASLGetMethodName Lib "wcsrv2.dll" (ByVal szMethod As String, ByVal dwSize As Long, ByVal dwIndex As Long) As Boolean

Declare Function WcSASLAuthenticateUser Lib "wcvb.dll" Alias "vbWcSASLAuthenticateUser" (ctx As TWildcatSASLContext, ByVal szFromClient As String, ByVal szResponse As String, ByVal dwResponseSize As Long, u As TUser) As Long

Declare Function WcSASLAuthenticateUserEx Lib "wcvb.dll" Alias "vbWcSASLAuthenticateUserEx" (ctx As TWildcatSASLContext, ByVal szFromClient As String, ByVal szResponse As String, ByVal dwResponseSize As Long, ByVal dwCallType As Long, ByVal szSpeed As String, u As TUser) As Long

'//!
'//! 450.3 07/30/02
'//! Get the wildcat server process running times
'//!

Declare Function WcGetProcessTimes Lib "wcsrv2.dll" (pt As TWildcatProcessTimes) As Boolean

'//! 450.7
'//! Set the context peer address
'//!

Declare Function SetContextPeerAddress Lib "wcsrv2.dll" (ByVal address As Long) As Boolean

'//! 450.8 06/18/03
'//! Wildcat! INI File Functions. These Wildcat! INI file
'//! functions work similar to the Win32 equivalent private
'//! profile functions. The key difference is that Win32
'//! INI files are local to the machine, where these Wildcat!
'//! INI functions use server side files using the Wildcat!
'//! file naming syntax, i.e., "wc:\data\productxyz.ini"
'//!

Declare Function WcGetPrivateProfileString Lib "wcvb.dll" Alias "vbWcGetPrivateProfileString" (byval section As String, byval key As String, byval def As String, byval ini As String) As String

Declare Function WcWritePrivateProfileString Lib "wcsrv2.dll" (ByVal sect As String, ByVal key As String, ByVal value As String, ByVal inifile As String) As Boolean

Declare Function WcGetPrivateProfileSection Lib "wcvb.dll" Alias "vbWcGetPrivateProfileSection" (byval section As String, byval ini As String) As String

'//! 451.2 07/18/04
'//! Extended WcCreateFileEx() function returns TwcOpenFileInfo
'//! structure. Useful when you need to open a file and obtain
'//! file information in one single RPC call.

Declare Function WcCreateFileEx Lib "wcsrv2.dll" (ByVal fn As String, ByVal access As Long, ByVal sharemode As Long, ByVal create As Long, pwcofi As TwcOpenFileInfo) As Long

'//! 451.5 10/04/05
'//! GetConnectionInfoFromChallenge() function returns TConnectionInfo
'//! for a given challenge.

Declare Function GetConnectionInfoFromChallenge Lib "wcvb.dll" Alias "vbGetConnectionInfoFromChallenge" (ByVal challenge As String, ci As TConnectionInfo) As Boolean

'//! 451.6
'//! DeleteUserVariable - delete extended user section or key

Declare Function DeleteUserVariable Lib "wcsrv2.dll" (ByVal id As Long, ByVal section As String, ByVal key As String) As Boolean

'//! 451.9
'//! WcCheckUserName - Return FALSE if user name has invalid characters

Declare Function WcCheckUserName Lib "wcsrv2.dll" (ByVal szName As String) As Boolean

'//! 451.9
'//! WcSetMessageAttachments - helps prepare attachment field

Declare Function WcSetMessageAttachment Lib "wcvb.dll" Alias "vbWcSetMessageAttachment" (msg As TMsgHeader, ByVal szFileName As String, ByVal bCopyTo As Long) As Boolean

'//! WcLocalCopyToServer - copy local side file to server side wc:\ file

Declare Function WcLocalCopyToServer Lib "wcsrv2.dll" (ByVal szLocal As String, ByVal szServer As String, ByVal msSlice As Long) As Boolean

