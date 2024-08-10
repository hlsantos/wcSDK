******************************************
** example Program to connect to Wildcat
******************************************

declare INTEGER WildcatServerConnect in wcsrv ;
   INTEGER parent
declare INTEGER WildcatServerCreateContext in wcsrv 
declare INTEGER WildcatServerDeleteContext in wcsrv 
declare INTEGER LoginSystem in wcsrv 
declare INTEGER LogoutUser in wcsrv 
declare INTEGER GetTotalUsers in wcsrv
declare INTEGER GetEffectiveFileAreaCount in wcsrv;
   INTEGER group, INTEGER flags

IF WildcatServerConnect(0) = 0 then
   RETURN
ENDIF

IF WildcatServerCreateContext() = 0 then
   MESSAGEBOX("Cannot create Wildcat Session",16)
   RETURN
ENDIF

IF LoginSystem() = 0 then
   WildcatServerDeleteContext()
   MESSAGEBOX("Cannot create Wildcat System Login",16)
   RETURN
ENDIF

LOCAL iTotalAreas
iTotalAreas  = GetEffectiveFileAreaCount(0,0)

MESSAGEBOX("Total File Areas: "+Str(iTotalAreas))

WildcatServerDeleteContext()
MESSAGEBOX("SUCCESS")
