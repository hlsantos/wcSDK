**************************************************
** example Program to connect to Wildcat
**************************************************

Declare INTEGER WildcatServerConnect in wcsrv ;
	INTEGER hParent
Declare INTEGER WildcatServerConnectSpecific in wcsrv ;
	INTEGER hParent, String szServer
Declare INTEGER WildcatServerCreateContext in wcsrv
Declare INTEGER WildcatServerDeleteContext in wcsrv
Declare INTEGER LoginSystem in wcsrv
Declare INTEGER LogoutUser in wcsrv
Declare INTEGER GetTotalUsers in wcsrv
Declare INTEGER GetFileAreaCount in wcsrv
Declare INTEGER GetEffectiveFileAreaCount in wcsrv;
	INTEGER dwGroup, INTEGER dwFlags
Declare INTEGER GetConnectedServer in wcsrv;
	STRING @, INTEGER dwSize

**************************************************
* Start Application
**************************************************

SET CENTURY ON
CLEAR
?"+ Start  "+DMY(DATE())+ " "+TIME()

PUBLIC oWildcat
oWildcat=CREATEOBJECT("Wildcat")
Do MAIN
* DISPLAY DLLS
RELEASE oWildcat
?"+ Done!"

**************************************************
* Main Procedure
**************************************************
Procedure MAIN
    LOCAL iError

	?"+ Connecting to Wildcat Server....."

	If WildcatServerConnectSpecific(0,"SHANE") = 0 then
		Return
	Endif

	?"+ Creating Wildcat Server Session Context ....."
	If WildcatServerCreateContext() = 0 then
		Messagebox("Cannot create Wildcat Session",16)
		Return
	Endif

	?"+Logging in as Wildcat! System account...."
	If LoginSystem() = 0 then
	    iError = GetLastError()
		WildcatServerDeleteContext()
		Messagebox("Error "+DecToHex(iError)+": Cannot create Wildcat System Login",16)
		Return
	Endif

	?"+ Successful Wildcat Session Started"

	?"Total File Areas: "+AllTrim(Str(GetFileAreaCount()))
	?"Total Effective File Areas: "+AllTrim(Str(GetEffectiveFileAreaCount(0,0)))
	?"Connected Server: ["+oWildcat.GetServerName()+"]"

	?"+ Disconnecting Wildcat Session...."
	WildcatServerDeleteContext()
	Return
ENDPROC	


**************************************************
* Wildcat Fox Pro Class
**************************************************

DEFINE CLASS Wildcat as CUSTOM
	* Returns a 4 byte string representing the number
	FUNCTION DecToHex
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

	* Trim and remove final NULL from string	
	FUNCTION CleanString
		* Trim spaces and remove remaining NULL
		LPARAMETER sz
		sz = ALLTRIM(sz)
		sz = LEFT(sz,LEN(sz)-1)
		RETURN sz
	ENDFUNC
	
	* Return Connected Wildcat Server Computer Name	
	FUNCTION GetServerName
		Local sz
		sz = SPACE(256)
		GetConnectedServer(@sz,255)
		sz = This.CleanString(sz)
		return sz
	ENDFUNC

	* Task #1: Add New Wildcat User Account	
	FUNCTION AddUserAccount
		LPARAMETER cUserName, cPassword, cSecurity
		return .T.
	ENDFUNC

	* Task #2: Update Wildcat User Account	
	FUNCTION UpdateUserAccount
		LPARAMETER cUserName, cPassword
		return .T.
	ENDFUNC
	
	* Task #3: Delete Wildcat User Account	
	FUNCTION DeleteUserAccount
		LPARAMETER cUserName
		return .T.
	ENDFUNC
	
	* Task #4: Query for New files

	* Task #5: Process Files
	
	* Task #6.1: Send Confirmation File
	FUNCTION SendUserFile
		LPARAMETER cUserName, cFileName
		return .T.
	ENDFUNC

	* Task #6.2: Send Confirmation Message
	FUNCTION SendUserMessage
		LPARAMETER cUserName, cMessage
		return .T.
	ENDFUNC

	
ENDDEFINE
**************************************************
