**************************************************
** Wildcat! Server Protocol Headers for VFP
**************************************************

*!*	The Function InitializeWildcatLibrary() must be the first item 
*!*	called to load the Wildcat API library and to initialize a 
*!*	special class object with customize wrapper functions.  The
*!*	Wrapper Functions are stored in a called called "Wildcat"

#include wcsdk\wctype.h
#define TRUE 		1
#define FALSE 		0

FUNCTION InitializeWildcatLibrary
	do wcsdk\wcserverapidef.prg
	do wcsdk\win32apidef.prg
	PUBLIC oWildcat
	oWildcat=CREATEOBJECT("Wildcat")
ENDFUNC

FUNCTION ReleaseWildcatLibrary
	=owildcat.WildcatLogout()
	RELEASE oWildcat
ENDFUNC

*!***************************************************************
*!* Miscellaneous Helper Functions to work with C based buffers
*!***************************************************************

* return string with NULLS upto size
FUNCTION ZeroMemory
	LPARAMETERS size
	RETURN PADC("",size,chr(0))
ENDFUNC

* return the length of NULL terminated string
FUNCTION StrLen
	LPARAMETERS sz
	LOCAL i
	i = AT(chr(0),sz)
	if i > 0 then
	   i = i - 1
	endif
	RETURN i
ENDFUNC

* Remove final NULL from string
Function RemoveNull
	Lparameter sz
	Local i
	i = AT(chr(0),sz)
	If i > 0 then
    	sz = LEFT(sz,i-1)
	Endif
   	Return sz
Endfunc

* return asciiz (null terminated) string
Function NullStr
	LParameters vfpstring
	return alltrim(vfpstring)+chr(0)
EndFunc

* Returns a 4 byte binary string representing the 4 byte INTEGER
* NOTE: THIS IS NOT A HEX NUMBER, but rather the internal storage
FUNCTION IntToBin
	LPARAMETERS lnNum
	LOCAL i, ntmp, cRes
		cRes = ""
		FOR i = 3 TO 0 STEP -1
			ntmp = INT(lnNum / 256 ^ i)
			lnNum = lnNum - ntmp * (256 ^ i)
			cRes = CHR(ntmp) + cRes
		ENDFOR
	RETURN cRes
ENDFUNC

* Returns a 2 byte binary string representing the 2 byte WORD
FUNCTION WordToBin
	LPARAMETERS lnNum
	LOCAL i, ntmp, cRes
		cRes = ""
		FOR i = 1 TO 0 STEP -1
			ntmp = INT(lnNum / 256 ^ i)
			lnNum = lnNum - ntmp * (256 ^ i)
			cRes = CHR(ntmp) + cRes
		ENDFOR
	RETURN cRes
ENDFUNC

* Returns a HEX string of a number.
FUNCTION HexStr
	LPARAMETERS lnNum
	LOCAL szNum
    szNum = ZeroMemory(9)
	vfpIntToHex(lnNum,@szNum)
	szNum = RemoveNull(szNum)
	RETURN szNum
ENDFUNC

* Convert a 2 byte binary string to a number (WORD 16 bits or 2 bytes)
Function Str2Word
	PARAMETERS m.Wordstr
	private i, m.retval
	m.retval = 0
	for i = 0 to 8 step 8
		m.retval = m.retval + (asc(m.wordstr)*(2^i))
		m.wordstr = RIGHT(m.wordstr, LEN(m.wordstr)-1)
	endfor
EndFunc

* Convert a 4 byte binary string to a number (INTEGER 32 bits or 4 bytes)
Function Str2Int
	PARAMETERS m.Wordstr
	private i, m.retval
	m.retval = 0
	for i = 0 to 24 step 8
		m.retval = m.retval + (asc(m.wordstr)*(2^i))
		m.wordstr = RIGHT(m.wordstr, LEN(m.wordstr)-1)
	endfor
	return m.retval
EndFunc

* Convert a 4 byte string starting at position nPos to a 32 bit number
Function BufferToNumber
	LPARAMETERS cBuffer,nPos
	return Str2Int(substr(cBuffer,nPos,4))
EndFunc

* Convert asciiz buffer string starting at position nPos upto nLen size
* to a VFP string
Function BufferToString
	LPARAMETERS cBuffer,nPos,nLen
	return RemoveNull(substr(cBuffer,nPos,nLen))
EndFunc

* simple integer to string conversion
Function itoa
   LPARAMETERS n
   return AllTrim(str(n))
EndFunc

* simple string to integer conversion
Function atoi
   LPARAMETERS s
   return val(AllTrim(s))
EndFunc

** Create a Wildcat FileArea Name
Function MakeWildcatFileAreaName
    LPARAMETERS iArea,cFileName
   	return "wc:\file\area("+itoa(iArea)+")\"+ AllTrim(cFileName) + chr(0)
EndFunc    

* Return the year day number
Function DayNumber
   boy = VAL(SYS(11,"01/01/"+STR(YEAR(DATE()),4)))
   now = VAL(SYS(1))
   return (now-boy)+1
EndFunc

* Return the year day string padded and 0 left filled 
Function DayNumberStr
   return PADL(itoa(DayNumber()),3,"0")
EndFunc

**************************************************
* Wildcat Fox Pro Class
**************************************************

DEFINE CLASS Wildcat as CUSTOM

	*-------------------------------------------------------------------
	* WildcatConnect()
	* Find/Connect with Wildcat Server. This should be the FIRST call
	* made to establish the a "contact" with the Wildcat Server. It is
	* only called once per process.  Return .T. is successful (server 
	* was found).  Return .F. is search was not found or no contact
	* was made.  The cComputerName parameter is optional. If provided,
	* you will speed up the contact by 2 years since it will not have
	* do a network broadcast for any available wildcat servers.  If
	* blank and more than 1 server is found, you will get a Dialog box
	* to select the server.

	FUNCTION WildcatConnect
		LPARAMETERS cComputerName
		Local Success
		cComputerName = NullStr(cComputerName)
		if StrLen(cComputerName) = 0 then
			Success = WildcatServerConnect(0) > 0
		else
			Success = WildcatServerConnectSpecific(0,cComputerName) > 0
		endif
		return Success
	ENDFUNC

	*-------------------------------------------------------------------
	* return the computer name of the connected Wildcat Server
	FUNCTION GetWildcatServerName
		Local sz
		sz = ZeroMemory(SIZE_COMPUTER_NAME)
		GetConnectedServer(@sz,SIZE_COMPUTER_NAME-1)
		return RemoveNull(sz)
	ENDFUNC

	*-------------------------------------------------------------------
	* Check if a session was created. Return .T. 
	FUNCTION IsWildcatSessionStarted
	  return GetWildcatThreadContext() > 0
	ENDFUNC

	*-------------------------------------------------------------------
	* Creates a Wildcat Session (Create Session Context)
    FUNCTION WildcatLogin

    	* Create a session context. Note, each session context
    	* must be deleted when exiting the program

    	If WildcatServerCreateContext() = 0 then
    		Return .F.
    	Endif

    	* Login as the Wildcat System (god)
    	* note: This is not a "user". To login as a user, you
    	* would use "LoginUser()" instead. But as a service
    	* client, you want to create a session with access to
    	* all database function calls and access to all data.
    	
    	if LoginSystem() = 0 then
    		WildcatServerDeleteContext()
    		Return .F.
    	endif
    	
	    oWildcat.WriteLog("********************************************************")
		oWildcat.WriteLog("Starting WARKMON Session")
        return .T.
    ENDFUNC

	*-------------------------------------------------------------------
 	* Logout current session (Delete session context)
 	* This must be called if a session context is created
 	* with WildcatLogin()
    FUNCTION WildcatLogout
        if (GetWildcatThreadContext() > 0) then
			oWildcat.WriteLog("Ending WARKMON Session")
        endif
        return WildcatServerDeleteContext()
    ENDFUNC

	*-------------------------------------------------------------------
	* Add New Wildcat User Account. 
	* Return the wildcat user id (>0 if successful) 

	FUNCTION AddUserAccount
		LPARAMETER cUserName, cPassword, cSecurity, cRealName, ;
		           cLocation, cTitle, cExpireDate, iUserId

		cUserName  	= NullStr(cUserName)		&& required
		cPassword   = NullStr(UPPER(cPassword))	&& required	
		cSecutity 	= NullStr(cSecurity)		&& required
		cTitle 		= NullStr(cTitle)			&& optional
		cRealName 	= NullStr(cRealName)		&& optional
		cLocation	= NullStr(cLocation)		&& optional
		cExpireDate	= NullStr(cExpireDate)		&& optional, MM/DD/YYYY

		iUserId = vfpAddNewUser(cUserName, 	;
								cPassword,	;
								cSecurity,	;
								cRealName, 	;
								cLocation, 	;
								cTitle, 	;
								cExpireDate)
		return iUserId
	ENDFUNC

	*-------------------------------------------------------------------
	* Update Wildcat User Account
	* return .T. if successful
	
	FUNCTION UpdateUserAccount
		LPARAMETER dwUserId, cUserName, cPassword, cSecurity, cRealName, ;
		           cLocation, cTitle

		cUserName  	= NullStr(cUserName)		&& required
		cPassword   = NullStr(UPPER(cPassword))	&& required	
		cSecutity 	= NullStr(cSecurity)		&& required
		cTitle 		= NullStr(cTitle)			&& optional
		cRealName 	= NullStr(cRealName)		&& optional
		cLocation	= NullStr(cLocation)		&& optional
		
		Local ok 
		ok = vfpUpdateUserAccount(dwUserId,   ;
		                        cUserName,  ;
		                        cPassword,  ;
		                        cSecurity,   ;
		                        cRealName,  ;
		                        cLocation,  ;
		                        cTitle)
    	return ok <> 0
	ENDFUNC
	
	*-------------------------------------------------------------------
	* Delete Wildcat User Account by name
	* return .T. if successful

	FUNCTION DeleteUserAccount
		LPARAMETER cUserName
		cUserName = NullStr(cUserName)
		return vfpDeleteUser(cUserName) > 0
	ENDFUNC

	*-------------------------------------------------------------------
	* Send a message to a user
	* return .T. if successful

	FUNCTION SendMessage
		LPARAMETER dwMailArea,dwPrivate, cToName, cFromName, ;
				   cSubject, cMessage, cAttachment
				   
		cToName   	= NullStr(cToName)		&& required
		cFromName 	= NullStr(cFromName)	&& required
		cSubject 	= NullStr(cSubject)		&& optional
		cMessage    = NullStr(cMessage)		&& required
		cAttachment = NullStr(cAttachment)	&& optional
		
		Local Ok
		ok = vfpAddMessage(dwMailArea,	;  && required
						   dwPrivate,	;
						   cFromName, 	;
						   cToName, 		;
						   cSubject,		;
						   cMessage,		;
						  cAttachment)
		return ok <> 0
	ENDFUNC

	*-------------------------------------------------------------------
	* Add cLocalFile to the specifical file area
	* return .T. if successful

	Function AddFileToArea
	    lparameter cOwnerName, iNotifyArea, cLocalFile, cWildcatFile, ;
	    		   cDescription, bDeleteFile
	    
	    cOwnerName		= NullStr(cOwnerName)		&& optional
	    cLocalFile	 	= NullStr(cLocalFile)		&& required
	    cWildcatFile	= NullStr(cWildcatFile)		&& optional
	    cDescription 	= NullStr(cDescription)		&& optional

	    local ok, iError
	    ok  = vfpAddNewFile(cOwnerName, iNotifyArea, ;
	    					   cLocalFile, cWildcatFile, cDescription) > 0
	    					   
        if ok = .T. then
	        if bDeleteFile = .T. then
*!*		            iError = GetLastError()
*!*					** Delete the local copy of the notify file
*!*					if vfpDeleteFile(cLocalFile) = 0 then
*!*					   oWildcat.WriteLog("! Error "+HexStr(GetLastError())+" vfpDeleteFile: "+cLocalFile)
*!*					endif 
*!*					SetLastError(iError)
	        endif 
        endif 
		Return ok
	EndFunc

	*-------------------------------------------------------------------
	* Given a user id and file area, return a unique file name for storage

	Function GetUniqueFileAreaName
	    LPARAMETERS dwUserId, dwFileArea
	    LOCAL iCount, cDayNum, cFileName, wcFileName
        iCount = 0
        cDayNum = DayNumberStr()
        do while .T.
            iCount = iCount + 1
            cFileName = itoa(dwUserId) + "-" + itoa(iCount) + "." + cDayNum
            wcFileName = MakeWildcatFileAreaName(dwFileArea,cFileName)
            if WcExistFile(wcFileName) = FALSE then
               exit 
            endif
        enddo
        return cFileName
	EndFunc

	*-------------------------------------------------------------------
	* Given a user name return his wildcat user id
	Function GetUserId
	    LPARAMETERS cUserName
	    cUserName = NullStr(cUserName)
	    return vfpGetUserId(cUserName)
	EndFunc
	
	*-------------------------------------------------------------------
	* Copy source to target
	Function CopyFile
	    LPARAMETERS cSource, cTarget
	    cSource = NullStr(cSource)
	    cTarget = NullStr(cTarget)
	    return vfpCopyFile(cSource,cTarget,0) > 0
	EndFunc

	*-------------------------------------------------------------------
	* Write to WARKMON.LOG file
	Procedure WriteLog
	    LPARAMETERS cLine
	    cLine = TTOC(DATETIME(),1)+": "+cLine+chr(0)
	    WriteLogEntry("WARKMON.LOG",cLine)
	EndProc
	
ENDDEFINE
**************************************************
