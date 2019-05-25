<?PHP
//***********************************************************************
// (c) Copyright 1998-2008 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : wildcat.user.class.cpp
// Subsystem : PWE
// Date      : 02/27/08 12:47 am
// Version   : 1.0d
// Author    : SSI/HLS
//
// Revision History:
// Build    Date      Author  Comments
// -----    --------  ------  -------------------------------------------
//
// 1.0d     02/27/08  HLS     - Initial version
//
//***********************************************************************

require_once("wildcat.php");
require_once("inilib.inc.php");


class CWildcatUserProfile {

   private $user    = null;
   public $data = null;

   function __construct($user = null)
   {
      $this->user = $user;
   }

   function __get($v)
   {
      print "__get()\n";
      print_r(func_get_args());
   }

   function __put()
   {
      print "__put()\n";
      print_r(func_get_args());
   }

   function Update()
   {
      if ($this->user == null) {
         return false;
      }
      return wcUpdateUser(&$this->user);
   }

   function Set($fld, $val)
   {
      $list = explode(".",$fld);
      if (count($list) == 1) {
         $this->user[$fld] = $val;
      }
      else
      if (count($list) == 2) {
         $this->user[$list[0]][$list[1]] = $val;
      }
   }

   function Get($fld)
   {
      $r = "";
      foreach(explode(".",$fld) as $n) {
        if ($r == "") {
           $r = $this->user[$n];
        } else {
           $r = $r[$n];
        }
      }
      return $r;
   }

   function User($fld = null)
   {
     if ($fld == null) return $this->user;
     return $this->Get(Trim($fld));
   }

   Function UserId()
   {
     return $this->Get("Info.Id");
   }

   function GetVariables()
   {
     if ($this->UserId() > 0) {
        return ini2array(wcGetUserVariables($this->UserId()));
     }
     return null;
   }

   function SetVariables($vars)
   {
     if ($this->UserId() > 0) {
        $ini = ini2array(vars);
        wcSetUserVariables($this->UserId(),$ini);
     }
   }

   function Variable($sect, $key, $def = "")
   {
     return wcGetUserVariable($this->UserId(), $sect,$key,$def);
   }

   function SetVariable($sect, $key, $val)
   {
     return wcSetUserVariable($this->UserId(), $sect, $key, $val);
   }

   function Profile($key, $def = "")
   {
     return $this->Variable("Profile",$key,$def);
   }

   function SetProfile($key, $val)
   {
      return $this->SetVariable("Profile",$key,$val);
   }

}

class CWildcatUser extends CWildcatUserProfile {

   Private $sortkey = UserIdKey;
   private $user    = null;
   private $tid     = 0;
   private $search  = null;

   function __construct($user = null)
   {
     $this->user = $user;
     $this->tid  = 0;
   }

   function SortKey($key = null)
   {
     if ($key == null) {
        return $this->sortkey;
     }
     $this->sortkey = $key;
   }

   function Update()
   {
      if ($this->user == null) {
         return false;
      }
      return wcUpdateUser(&$this->user);
   }

   function First()
   {
     $this->user = null;
     $this->tid  = 0;
     if (wcGetFirstUser($this->sortkey,&$this->user,&$this->tid)) {
        return $this->user;
     }
     return null;
   }

   function Last()
   {
     $this->user = null;
     $this->tid  = 0;
     if (wcGetLastUser($this->sortkey,&$this->user,&$this->tid)) {
        return $this->user;
     }
     return null;
   }

   function Prev()
   {
     if ($this->user == null) $this->tid  = 0;
     if (wcGetPrevUser($this->sortkey,&$this->user,&$this->tid)) {
        return $this->user;
     }
     $this->search = null;
     return null;
   }

   function Next()
   {
     if ($this->user == null) $this->tid  = 0;
     if (wcGetNextUser($this->sortkey,&$this->user,&$this->tid)) {
        return $this->user;
     }
     $this->search = null;
     return null;
   }

   function Search($var, $key = null)
   {
     if ($key !== null) {
        $this->sortkey = $var;
        $var = $key;
     }
     $this->search = $var;
     $proc = "wcSearchUserBy";
     switch($this->sortkey) {
       case UserIdKey:        $proc .= "Id";        break;
       case UserLastNameKey:  $proc .= "LastName";  break;
       case UserNameKey:      $proc .= "Name";      break;
       case UserSecurityKey:  $proc .= "Security";  break;
       case UserLastCallKey:  $proc .= "LastCall";  break;
     }
     if ($proc($var, &$this->user, &$this->tid)) {
        return $this->user;
     }
     return null;
   }

   function SearchUserById($var)
   {
      return $this->Search(UserIdKey,$var);
   }

   function SearchUserByLastName($var)
   {
      return $this->Search(UserLastNameKey,$var);
   }

   function SearchUserByName($var)
   {
      return $this->Search(UserNameKey,$var);
   }

   function SearchUserBySecurity($var)
   {
      return $this->Search(UserSecurityKey,$var);
   }

   function SearchUserByLastCall($var)
   {
      return $this->Search(UserLastCallKey,$var);
   }

   function GetUserById($var)    {
      if (wcGetUserById($var,&$this->user,&$this->tid)) {
         return $this->user;
      }
      return null;
   }

   function GetUserByLastName($var) {
      if (wcGetUserByLastName($var,&$this->user,&$this->tid)) {
         return $this->user;
      }
      return null;
   }

   function GetUserByName($var) {
      if (wcGetUserByName($var,&$this->user,&$this->tid)) {
         return $this->user;
      }
      return null;
   }

   function GetUserBySecurity($var) {
      if (wcGetUserBySecurity($var,&$this->user,&$this->tid)) {
         return $this->user;
      }
      return null;
   }
   function GetUserByLastCall($var) {
      if (wcGetUserByLastCall($var,&$this->user,&$this->tid)) {
         return $this->user;
      }
      return null;
   }

   function LookupName($name)
   {
      $ui = wcLookupName($name);
      if ($ui != false) {
          if (wcGetUserById($ui["Id"],&$this->user,&$this->tid)) {
             //return $this->user["Info"];
             return true;
          }
      }
      return false;
   }

   function Set($fld, $val)
   {
      $list = explode(".",$fld);
      if (count($list) == 1) {
         $this->user[$fld] = $val;
      }
      else
      if (count($list) == 2) {
         $this->user[$list[0]][$list[1]] = $val;
      }
   }

   function Get($fld)
   {
      $r = "";
      foreach(explode(".",$fld) as $n) {
        if ($r == "") {
           $r = $this->user[$n];
        } else {
           $r = $r[$n];
        }
      }
      return $r;
   }

   function User($fld = null)
   {
     if ($fld == null) return $this->user;
     return $this->Get(Trim($fld));
   }

   Function UserId()
   {
     return $this->Get("Info.Id");
   }

   function GetVariables()
   {
     if ($this->UserId() > 0) {
        return ini2array(wcGetUserVariables($this->UserId()));
     }
     return null;
   }

   function SetVariables($vars)
   {
     if ($this->UserId() > 0) {
        $ini = ini2array(vars);
        wcSetUserVariables($this->UserId(),$ini);
     }
   }

   function Variable($sect, $key, $def = "")
   {
     return wcGetUserVariable($this->UserId(), $sect,$key,$def);
   }

   function SetVariable($sect, $key, $val)
   {
     return wcSetUserVariable($this->UserId(), $sect, $key, $val);
   }

   function Profile($key, $def = "")
   {
     return $this->Variable("Profile",$key,$def);
   }

   function SetProfile($key, $val)
   {
      return $this->SetVariable("Profile",$key,$val);
   }

///----------------------

   function Columnize($flds, $tag = "td", $attr = "")
   {
      /*
        printf("<td>%d</td><td>%s</td><td>%s</td>\n",
                       $wcusers->User("Info.Id"),
                       $wcusers->User("Security.0"),
                       $wcusers->User("Info.Name")
                       );
      */
      if ($tag === null) $tag = "td";
      $s = "";
      foreach(explode(",",$flds) as $f) {
        $s .= sprintf("<%s %s>%s</%s>\n",
                 $tag,$attr,
                 $this->User($f),
                 $tag);
      }
      return $s;
   }

}


?>

