*************************************************
** WildFox Helper DLL

Declare INTEGER vfpAddMessage in wcvfp;
      INTEGER dwArea, ;
      INTEGER bPrivate, ;
      STRING szFrom, ;
      STRING szTo, ;
      STRING szSubect, ;
      STRING szMessage, ;
      STRING szAttachment

Declare INTEGER vfpIntToHex in wcvfp;
      INTEGER dw, STRING @sz ;

Declare INTEGER vfpAddNewUser in wcvfp;
      STRING szName, ;
      STRING szPwd, ;
      STRING szSecurity, ;
      STRING szTitle

Declare INTEGER vfpDeleteUser in wcvfp;
      STRING szName

Declare INTEGER vfpAddNewFile in wcvfp;
     String szFromName, ;
     String szSubNum, ;
     String szLocalFileName, ;
     Integer iUploadArea, ;
     String szSendMsg


