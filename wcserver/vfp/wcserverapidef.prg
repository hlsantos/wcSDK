***********************************************************
** Wildcat! Server Protocol Headers for Visual Foxpro
***********************************************************


** -----------------------------------------------------------------
** Basic connection/session functions
** -----------------------------------------------------------------

Declare INTEGER WildcatServerConnect in wcsdk\wcsrv2;
	INTEGER hParent
Declare INTEGER WildcatServerConnectSpecific in wcsdk\wcsrv2;
	INTEGER hParent, ;
	STRING szServer
Declare INTEGER WildcatServerCreateContext in wcsdk\wcsrv2
Declare INTEGER WildcatServerDeleteContext in wcsdk\wcsrv2
Declare INTEGER GetWildcatThreadContext in wcsdk\wcsrv2
Declare INTEGER LoginSystem in wcsdk\wcsrv2
Declare INTEGER LogoutUser in wcsdk\wcsrv2
Declare INTEGER GetConnectedServer in wcsdk\wcsrv2;
	STRING @szComputerName, ;
	INTEGER dwSize
Declare INTEGER GetWildcatServerInfo in wcsdk\wcsrv2;
    STRING &szTWildcatServerInfo
    
Declare INTEGER WriteLogEntry in wcsdk\wcsrv2;
    STRING szfname, STRING szLine

** -----------------------------------------------------------------
** User Database Related Functions
** -----------------------------------------------------------------

Declare INTEGER GetTotalUsers in wcsdk\wcsrv2
Declare INTEGER LookupName in wcsdk\wcsrv2;
	STRING szUserName, STRING @szTUserInfo
Declare INTEGER GetFirstUser in wcsdk\wcsrv2;
	INTEGER keynum, STRING @TUser, INTEGER @tid
Declare INTEGER GetLastUser in wcsdk\wcsrv2;
	INTEGER keynum, STRING @TUser, INTEGER @tid
Declare INTEGER GetNextUser  in wcsdk\wcsrv2;
	INTEGER keynum, STRING @TUser, INTEGER @tid
Declare INTEGER GetPrevUser in wcsdk\wcsrv2;
	INTEGER keynum, STRING @TUser, INTEGER @tid

** -----------------------------------------------------------------
** File Database Related Functions
** -----------------------------------------------------------------

Declare INTEGER GetFileAreaCount in wcsdk\wcsrv2

Declare INTEGER GetTotalFiles in wcsdk\wcsrv2

Declare INTEGER GetTotalFilesInArea in wcsdk\wcsrv2;
    INTEGER filearea

Declare INTEGER GetEffectiveFileAreaCount in wcsdk\wcsrv2;
	INTEGER dwGroup, INTEGER dwFlags

Declare INTEGER GetFileRecByNameArea in wcsdk\wcsrv2;
	STRING szFileName, INTEGER area, STRING @TFileRecord, INTEGER @tid
	
Declare INTEGER GetFileRecByAreaName in wcsdk\wcsrv2;
	INTEGER area, STRING szFileName, STRING @TFileRecord, INTEGER @tid

Declare INTEGER GetFileRecByAreaDate in wcsdk\wcsrv2;
	INTEGER area, STRING filetime, STRING @TFileRecord, INTEGER @tid

Declare INTEGER GetFileRecByUploader in wcsdk\wcsrv2;
	INTEGER dwUserId, STRING @TFileRecord, INTEGER @tid
	
Declare INTEGER GetFirstFileRec in wcsdk\wcsrv2;
	INTEGER dwKey, STRING @fRec, INTEGER @tid
Declare INTEGER GetLastFileRec in wcsdk\wcsrv2;
	INTEGER dwKey, STRING @fRec, INTEGER @tid
Declare INTEGER GetNextFileRec in wcsdk\wcsrv2;
	INTEGER dwKey, STRING @fRec, INTEGER @tid
Declare INTEGER GetPrevFileRec in wcsdk\wcsrv2;
	INTEGER dwKey, STRING @fRec, INTEGER @tid

Declare INTEGER IncrementDownloadCount in wcsdk\wcsrv2;
	STRING @TFileRecord 

Declare INTEGER SearchFileRecByNameArea in wcsdk\wcsrv2;
    STRING filename, INTEGER area, STRING @TFileRecord, INTEGER @tid

Declare INTEGER SearchFileRecByAreaName in wcsdk\wcsrv2;
    INTEGER area, STRING filename, STRING @TFileRecord, INTEGER @tid

Declare INTEGER SearchFileRecByAreaDate in wcsdk\wcsrv2;
    INTEGER area, STRING @filetime, STRING @TFileRecord, INTEGER @tid

Declare INTEGER SearchFileRecByDateArea in wcsdk\wcsrv2;
    STRING filetime, INTEGER area, STRING @frec, INTEGER @tid

Declare INTEGER SearchFileRecByUploader in wcsdk\wcsrv2;
	INTEGER dwUserId, STRING @TFileRecord, INTEGER @tid

Declare INTEGER UpdateFileRec in wcsdk\wcsrv2;
	STRING @TFileRecord

Declare INTEGER UpdateFullFileRec in wcsdk\wcsrv2;
    STRING @TFullFileRecord

** -----------------------------------------------------------------
** Message Database Related Functions
** -----------------------------------------------------------------
	
Declare INTEGER GetHighMessageNumber in wcsdk\wcsrv2;
    INTEGER dwArea
Declare INTEGER GetLowMessageNumber in wcsdk\wcsrv2;
    INTEGER dwArea
Declare INTEGER GetMsgIdFromNumber in wcsdk\wcsrv2;
    INTEGER dwArea, INTEGER dwMsgNumber
Declare INTEGER GetMsgNumberFromId in wcsdk\wcsrv2;
    INTEGER dwArea, INTEGER dwMsgId

** -----------------------------------------------------------------
** Wilcat File I/O Functions
** -----------------------------------------------------------------
*!*	BOOL     APIENTRY WcCloseHandle(WCHANDLE h);
*!*	BOOL     APIENTRY WcCreateDirectory(LPCTSTR dir);
*!*	WCHANDLE APIENTRY WcCreateFile(LPCTSTR fn, DWORD access, DWORD sharemode, DWORD create);
*!*	BOOL     APIENTRY WcDeleteFile(LPCTSTR fn);
*!*	BOOL     APIENTRY WcExistFile(LPCTSTR fn);
*!*	WCHANDLE APIENTRY WcFindFirstFile(LPCTSTR fn, WIN32_FIND_DATA *fd);
*!*	BOOL     APIENTRY WcFindNextFile(WCHANDLE ff, WIN32_FIND_DATA *fd);
*!*	BOOL     APIENTRY WcFindClose(WCHANDLE ff);
*!*	DWORD    APIENTRY WcGetFileSize(WCHANDLE h);
*!*	BOOL     APIENTRY WcGetFileTime(WCHANDLE h, FILETIME &ft);
*!*	BOOL     APIENTRY WcGetFileTimeByName(LPCTSTR fn, FILETIME &ft);
*!*	BOOL     APIENTRY WcMoveFile(LPCTSTR src, LPCTSTR dest);
*!*	BOOL     APIENTRY WcReadFile(WCHANDLE h, LPVOID buffer, DWORD requested, LPDWORD read);
*!*	BOOL     APIENTRY WcReadLine(WCHANDLE h, LPVOID buffer, DWORD buflen);
*!*	BOOL     APIENTRY WcSetEndOfFile(WCHANDLE h);
*!*	DWORD    APIENTRY WcSetFilePointer(WCHANDLE h, LONG dist, DWORD movemethod);
*!*	BOOL     APIENTRY WcSetFileTime(WCHANDLE h, FILETIME &ft);
*!*	BOOL     APIENTRY WcWriteFile(WCHANDLE h, LPCVOID buffer, DWORD requested, LPDWORD written);
*!* BOOL 	 APIENTRY wcCopyFileToTemp(DWORD area, const char *fn)

Declare INTEGER wcCopyFileToTemp in wcsdk\wcsrv2;
	INTEGER area, STRING szFileName

Declare INTEGER WcMoveFile in wcsdk\wcsrv2;
     STRING szSource, ;
     STRING szTarget
    
Declare INTEGER WcExistFile in wcsdk\wcsrv2;
       STRING filename

Declare INTEGER WcDeleteFile in wcsdk\wcsrv2;
       STRING filename

Declare INTEGER WcCreateFile in wcsdk\wcsrv2;
        STRING filename, ;
        INTEGER accessmode, ;
        INTEGER sharemode, ;
        INTEGER createmode 
        
Declare INTEGER WcReadLine in wcsdk\wcsrv2;
         INTEGER h, ;
         STRING  @buffer, ;
         INTEGER buflen
                 
Declare  INTEGER WcCloseHandle in wcsdk\wcsrv2;
        INTEGER h
       
** -----------------------------------------------------------------
** Wildcat helper DLL (wcsdk\wcvfp.dll) API functions aka "Wrappers"
** to make it easier to interface certain basic functionalities 
** of Wildcat Server within external systems who can't easily handle
** c/c++ typedef structures.
** -----------------------------------------------------------------

Declare INTEGER vfpAddMessage in wcsdk\wcvfp;
    INTEGER dwArea, ;			&& Mail Conference to post, usually 0
    INTEGER bPrivate, ;			&& set 1 for private (Area 0 always private)
    STRING szFrom, ;			&& From: name
    STRING szTo, ;				&& To: Name
    STRING szSubect, ;			&& Subject: 71 characters max
    STRING szMessage, ;			&& body of text or wc:\ file name
    STRING szAttachment			&& optional, local attachment file 

Declare INTEGER vfpIntToHex in wcsdk\wcvfp;
    INTEGER dw, STRING @sz ;

Declare INTEGER vfpAddNewUser in wcsdk\wcvfp;
    STRING szName, ;			&& user name, required
    STRING szPwd, ;				&& password, required
    STRING szSecurity, ;		&& security, optional (default "New User")
    STRING szRealName, ;		&& user's real name, optional
    STRING szLocation, ;		&& user's location, optional
    STRING szTitle, ;			&& user's title (11 characters max), optional
    STRING szExpireDate 		&& optional, MM/DD/YYYY

Declare INTEGER vfpDeleteUser in wcsdk\wcvfp;
    STRING szName				&& user name, required

Declare INTEGER vfpAddNewFile in wcsdk\wcvfp;
   	String szOwnerName,		;	&& optional, user name to assign as owner
   	INTEGER dwUploadArea,   ;	&& required, location to store file
   	String szLocalFullName, ;	&& required, local file name to store
   	String szStorageName, 	;	&& optional, file name to save as
   	String szDescription 	;	&& optional, file description

Declare INTEGER vfpGetUserAccount in wcsdk\wcvfp;
    STRING szUserName, ;
    STRING @szSecurity, ;
    STRING @szRealName, ;
    STRING @szLocation, ;
    STRING @szTitle

Declare INTEGER vfpUpdateUserAccount in wcsdk\wcvfp;
    INTEGER dwUserId, ;  && Wildcat's User Id Number
    STRING szUserName, ;
    STRING szPassword, ;
	STRING szSecurity, ;
    STRING szRealName, ;
    STRING szLocation, ;
    STRING szTitle
      
Declare INTEGER vfpMoveFileRecord in wcsdk\wcvfp;
	INTEGER dwOldArea, ;
	INTEGER dwNewArea, ;
	STRING szFileName

Declare INTEGER vfpCopyFile in wcsdk\wcvfp;
	STRING szSource, STRING szTarget, INTEGER failIfExist

Declare INTEGER vfpAppendFile in wcsdk\wcvfp;
	STRING szSource, STRING szTarget

Declare INTEGER vfpDeleteFile in wcsdk\wcvfp;
	STRING szSource

Declare INTEGER vfpDeleteFileRecord in wcsdk\wcvfp;
	INTEGER dwArea, STRING szFileName, INTEGER disktoo

Declare INTEGER vfpIncrementDownloadCount in wcsdk\wcvfp;
	INTEGER dwArea, STRING szFileName

Declare INTEGER vfpGetUserId in wcsdk\wcvfp;
	STRING szUserName
