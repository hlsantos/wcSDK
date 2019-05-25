<?PHP
//***********************************************************************
// (c) Copyright 1998-2008 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : wildcat.cpp
// Subsystem : PWE
// Date      : 03/21/08 10:08 pm
// Version   : 1.0f2
// Author    : SSI/HLS
//
// Revision History:
// Build    Date      Author  Comments
// -----    --------  ------  -------------------------------------------
//
// 1.0a     02/20/08  HLS     - Initial version
//
// 1.0b     02/23/08  HLS     - Corrections for auto connect/create
//
// 1.0c     02/23/08  HLS     - inline comments
//                            - support wildcat.server
//
// 1.0f     03/21/08  HLS     - Clean up
//                            - Added System and Config context switcher
//                            - Added users_wildcat()
//
// 1.0f2    03/24/08  HLS     - Added htonl
//
//***********************************************************************

function pwe_GetUnitPath($unit, $addpaths="")
{
   $paths = explode(PATH_SEPARATOR, get_include_path().$addpaths);

   foreach ($paths as $path) {
       // Formulate the absolute path
       $fullpath = $path . DIRECTORY_SEPARATOR . $unit;
       if (file_exists($fullpath)) {
           return strtolower($fullpath);
       }
   }
   return false;
}

function uses_wildcat($unit, $addpaths = "")
{
   $unit  = strtolower($unit);
   $parts = pathinfo($unit);

   $fn    = $unit;
   if (strncmp($unit,"wildcat.",8)) {
      $fn = sprintf("wildcat.%s.php",$unit);
   }
   if (!isset($parts['extension'])) {
      $fn = sprintf("wildcat.%s.class.php",$unit);
      $fn = pwe_GetUnitPath($fn,$addpaths);
      if (!$fn) {
         $fn = sprintf("wildcat.%s.inc.php",$unit);
         $fn = pwe_GetUnitPath($fn,$addpaths);
         if (!$fn) {
            die("Wildcat! unit \"$unit\" does not exist! (1)\n");
         }
      }
   } else {
      $fn = pwe_GetUnitPath($fn,$addpaths);
      if (!$fn) {
         die("Wildcat! unit \"$unit\" does not exist! (2)\n");
      }
   }

   $parts = pathinfo($fn);
   require_once($parts['basename']);
}


function PWE_LOAD_MODULE($module = "wildcat")
{
  if (!extension_loaded($module)) {
     dl("php_".$module.".dll");
  }
  return extension_loaded($module);
}

/*-----------------------------------------------------------------------

Debugging functions to dump PWE information.

array PWE_INFO()
array PWE_SESSION_INFO()

------------------------------------------------------------------------*/

function PWE_INFO($funcs = true)
{
   $pweloaded = extension_loaded("wildcat");

   $a = array(
     "title" => "PHP Wildcat! Extension Information",
     "name"  => "php_wildcat.dll",

     "zend" => array(
        "version" => zend_version()
     ),


     "php" => array(
        "version" => phpversion(),
        "sapi" => php_sapi_name(),
        "os" => php_uname()
     ),

     "pwe" => array(
        "loaded" => $pweloaded,
        "options default" => array(
           "wildcat.server" => "",
           "wildcat.autoconnect" => "1",
        )
     )
   );

   if ($pweloaded) {
      $a["pwe"]["options"] = ini_get_all("wildcat");
      if ($funcs) {
         $a["pwe"]["functions"] = get_extension_funcs("wildcat");
      }
   }
   return $a;
}

function PWE_SESSION_INFO()
{
   //$pweloaded = extension_loaded("wildcat");
   $pweloaded = PWE_LOAD_MODULE("wildcat");

   $a = array(
     "title" => "PHP Wildcat! Session Information"
   );
   if ($pweloaded) {
      $a["server"] = wcGetConnectedServer();
      $a["nodeinfo"] = array();
      if (wcGetNodeInfoByConnectionId(wcGetConnectionId(),&$ni)) {
         $a["nodeinfo"] = $ni;
      }
   }

   return $a;
}

/*-----------------------------------------------------------------------

boolean wcInitialize([boolean])

Primarily designed to be called by class Wildcat() constructor, it
may be called separately as well.

This function is designed to follow the logic in PWE DLL when the
php.ini option is wildcat.autoconnect=off to provide a dynamic
script logic to:

    - connect to wcserver, and
    - reestablish logged in section, or
    - create new context

It works in auto extention= loading or manual loading with DL().

Return true if successful, otherwise false;

------------------------------------------------------------------------*/

function WcInitialize($quiet = true)
{

   //
   // load PWE if not already loaded
   //

   PWE_LOAD_MODULE("wildcat");

   //
   // connect to server if not already connected
   //

   if (wcGetConnectedServer() == "") {
      $server = ini_get("wildcat.server");
      if ($server != "") {
        if (!$quiet) print "- Connecting to $server\n";
        $result = WildcatServerConnectSpecific(NULL,$server);
      } else {
        if (!$quiet) print "- Connecting to default server\n";
        $result = WildcatServerConnect(NULL);
      }
      if (!$result && !$quiet) {
         printf("! Error %08X:  Connecting to Wildcat! Server: %s\n",
                   wcGetLastError(), $server);
         return false;
      }
   } else {
      if (!$quiet) print "- Already Connected\n";
   }

   //
   // create context, if not already created
   //

   $cid = wcGetConnectionId();
   if ($cid != 0) {
      wcSetNodeActivity("PWE: Session Already Established");
      return true;
   }

   $autoconnect = ini_get("wildcat.autoconnect");
   if (!$quiet) {
       print "- debug: autoconnect: $autoconnect\n";
   }

   if (WildcatServerCreateContextFromChallenge()) {
      if (!$quiet) print "- User Session Reestablished!!\n";
      wcSetNodeActivity("PWE: Session Reestablished");
      return true;
   }
   if (WildcatServerCreateContext(NULL)) {
      if (!$quiet)  print "- New Context Created!\n";
      wcSetNodeActivity("PWE: New Context Created");
      return true;
   }
   if (!$quiet) {
     printf("! Error %08X: Creating new session\n",wcGetLastError());
   }
   return false;
}

function GetHostAddress($ip)
// - convert a network order IP to a host IP address
{
   if (is_string($ip)) {
      $b = explode(".",$ip);
   } else {
      $b = explode(".",long2ip($ip));
   }
   return sprintf("%s.%s.%s.%s",$b[3],$b[2],$b[1],$b[0]);
}

function GetIPAddress($ip)
// - convert a IP address to dot format
{
   return long2ip($ip);
}

function wcGetSessionTypeStr($cltype = null)
{
    if ($cltype === null) $cltype = WildcatLoggedIn();
    switch ($cltype) {
       case clSessionNone:    return "NONE";
       case clSessionUser:    return "USER";
       case clSessionSystem:  return "SYSTEM";
       case clSessionConfig:  return "CONFIG";
    }
    return "";
}

Function IsLocalMode()
{
   return wcGetCallType() == CALLTYPE_LOCAL;
}

//-----------------------------------------------------
// class Wildcat
//-----------------------------------------------------

class CWildcat {

   public $Active = false;
   public $User   = Array();
   public $Cid    = 0;
   public $IniOptions = array();

   function __construct($quiet = true)
   {
      $this->Active = WcInitialize($quiet);

      $this->IniOptions = array(
          "wildcat.autoconnect" => ini_get("wildcat.autoconnect"),
          "wildcat.server"      => ini_get("wildcat.server")
      );

      $this->User   = $this->GetUser();
      $this->Cid    = $this->ConnectionId();
   }

   function __destruct()
   {
     $this->RestoreContext();
     if ($this->Active) {
        WildcatServerDeleteContext();
     }
   }

   function Node()           { return wcGetNode(); }
   function GetUser()        { WildcatLoggedIn(&$u); return $u; }
   function ConnectionId()   { return wcGetConnectionId(); }
   function CallType()       { return wcGetCallType(); }
   function CallTypeStr()    { return wcGetCallTypeStr(); }
   function SessionTypeStr() { return wcGetSessionTypeStr(); }

   /////////////////////////////////////////////////////////////////
   // Switch to a System Context
   /////////////////////////////////////////////////////////////////

   private $SessType = 0;
   private $hContext = 0;

   function LoginSystem()     { return $this->LoginSystemContext(); }
   function LoginConfig($pwd) { return $this->LoginConfigContext($pwd); }

/*
   function LoginRole($min_role, $allow_role = 0, $pwd = "")
   {
      $sesstype = WildcatLoggedIn();

      if ($min_role == WC_ROLE_NONE) {
          if ($st == clSessionNone)  {
             if ($allow_role == WC_ROLE_SYSTEM) return $this->LoginSystem();
             if ($allow_role == WC_ROLE_SYSTEM) return $this->LoginSystem();
             if ($allow_role == WC_ROLE_SYSTEM) return $this->LoginSystem();
             if ($allow_role == WC_ROLE_CONFIG) return $this->LoginConfig($pwd);
          }
      }

      if ($min_role == WC_ROLE_USER) {
          if ($st == clSessionUser) return true;
      }

      if ($min_role == WC_ROLE_SYSTEM) {
          if ($st == clSessionSystem) return true;
      }

      if ($min_role == WC_ROLE_CONFIG) {
          if ($st == clSessionConfig) return true;
      }
      return false;
   }
*/

   function LoginSystemContext()
   {
      /////////////////////////////////////////////////////////////////
      // Check session type and only create a new context if none
      /////////////////////////////////////////////////////////////////

      $this->SessType = WildcatLoggedIn();

      if ($this->SessType == clSessionSystem) {
          return true;
      }

      /////////////////////////////////////////////////////////////////
      // Remember the current Context
      // Tech Note: A WCX will always have a context! So this should
      //            never be zero
      /////////////////////////////////////////////////////////////////

      $this->hContext = wcGetWildcatThreadContext();
      if ($this->hContext <= 0) {
          return false;
      }

      /////////////////////////////////////////////////////////////////
      // Disconnect the current user context from the current
      // thread and create a system context.
      //
      // Note: if this succeeds, don't forget to reestablish
      //       the user context before exiting.
      /////////////////////////////////////////////////////////////////

      if ($this->SessType > clSessionNone) {
          if (!wcSetWildcatThreadContext(0)) {
              return false;
          }
          /////////////////////////////////////////////////////////////////
          // Create a basic context
          //
          // Note: if this succeeds, don't forget to delete the context
          //       before restoring the user context before exiting.
          /////////////////////////////////////////////////////////////////

          if (!WildcatServerCreateContext()) {
             // restore user context
             wcSetWildcatThreadContext($this->hContext);
             $this->hContext = 0;
             return false;
          }

          wcSetContextPeerAddress(wcGetCallerId());
      }

      /////////////////////////////////////////////////////////////////
      // Login as System Context
      /////////////////////////////////////////////////////////////////

      if (!wcLoginSystem()) {
          if ($this->SessType > clSessionNone) {
             // delete basic context and restore user context
             WildcatServerDeleteContext();
             wcSetWildcatThreadContext($this->hContext);
          }
          $this->hContext = 0;
          return false;
      }

      return true;
   }

   /////////////////////////////////////////////////////////////////
   // Switch to a Config Context
   /////////////////////////////////////////////////////////////////

   function LoginConfigContext($pwd = "")
   {
      if (!extension_loaded("wcsmw")) dl("php_wcsmw.dll");
      if (!extension_loaded("wcsgate")) dl("php_wcsgate.dll");

      /////////////////////////////////////////////////////////////////
      // Check session type and only create a new context if none
      /////////////////////////////////////////////////////////////////

      $this->SessType = WildcatLoggedIn();

      if ($this->SessType == clSessionConfig) {
          return true;
      }

      /////////////////////////////////////////////////////////////////
      // Remember the current Context
      // Tech Note: A WCX will always have a context! So this should
      //            never be zero
      /////////////////////////////////////////////////////////////////

      $this->hContext = wcGetWildcatThreadContext();
      if ($this->hContext <= 0) {
          return false;
      }

      /////////////////////////////////////////////////////////////////
      // Disconnect the current user context from the current
      // thread and create a system context.
      //
      // Note: if this succeeds, don't forget to reestablish
      //       the user context before exiting.
      /////////////////////////////////////////////////////////////////

      if ($this->SessType > clSessionNone) {
          if (!wcSetWildcatThreadContext(0)) {
              return false;
          }
          /////////////////////////////////////////////////////////////////
          // Create a basic context
          //
          // Note: if this succeeds, don't forget to delete the context
          //       before restoring the user context before exiting.
          /////////////////////////////////////////////////////////////////

          if (!WildcatServerCreateContext()) {
             // restore user context
             wcSetWildcatThreadContext($this->hContext);
             $this->hContext = 0;
             return false;
          }

          wcSetContextPeerAddress(wcGetCallerId());
      }

      /////////////////////////////////////////////////////////////////
      // Login as Config Context
      /////////////////////////////////////////////////////////////////

      if (!wcMwLogin($pwd)) {
          if ($this->SessType > clSessionNone) {
             // delete basic context and restore user context
             WildcatServerDeleteContext();
             wcSetWildcatThreadContext($this->hContext);
          }
          $this->hContext = 0;
          return false;
      }

      return true;
   }

   /////////////////////////////////////////////////////////////////
   // Disconnect system context and restore the user context
   /////////////////////////////////////////////////////////////////

   function RestoreContext()
   {
      $ctx = wcGetWildcatThreadContext();
      $st  = WildcatLoggedIn();

      if ($this->hContext == 0) {
          return $this->SessType != clSessionNone;
      }

      if (($ctx == $this->hContext) && ($st != $this->SessType)) {
         wcLogoutUser();
      }

      if ($ctx != $this->hContext) {
          WildcatServerDeleteContext();
          wcSetWildcatThreadContext($this->hContext);
      }
      return true;
   }

}

?>

