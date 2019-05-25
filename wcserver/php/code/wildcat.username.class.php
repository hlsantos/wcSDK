<?php
//***********************************************************************
// (c) Copyright 1998-2008 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : wildcat.username.class.php
// Subsystem :
// Date      :
// Version   :
// Author    :
//
// class: CUserName
//
// This class prepares a user name for Wildcat! login and
// email ids. It will break it up into First, Middle and Last
// parts.
//
// Examples:
//
// You can pass the name via the constructor
//
//   $name = new CUserName("Joe");
//   $name = new CUserName("Joe Public");
//   $name = new CUserName("Joe", "Public");
//   $name = new CUserName("Joe Q. Public");
//
// or initialize it with Init()
//
//   $name->Init("Barack Hussien Obama");
//
// Revision History:
// Build    Date      Author  Comments
// -----    --------  ------  -------------------------------------------
//***********************************************************************

class CUserName
{
   var $Name;
   var $First;
   var $Middle;
   var $Last;

   function __construct()
   {
      $names = func_get_args();
      $this->Init($names);
   }

   function Init($a = null)
   {
      $names = is_array($a) ? $a : func_get_args();
      $this->Name  = join(" ",$names);
      $names       = explode(" ",$this->Name);
      if (count($names)) {
         $this->First = reset($names);
         if (count($names) > 2) $this->Middle = next($names);
         if (count($names) > 1) $this->Last  = end($names);
      }
      $this->Names = $names;
   }

   private function dot($s)
   {
      $s = str_replace(".","_",$s);
      $s = str_replace(" ",".",$s);
      return $s;
   }

   function EmailId($mhs = false)
   {
     $s = strtolower($this->Name);
     if ($mhs) {
        $s  = substr($this->First,0,1);
        $s .= $this->Last;
     } else {
        $s  = $this->First;
        $s .= " ";
        $s .= $this->Last;
     }
     return $this->dot(strtolower($s));
   }

   //----------------------------------------
   // Create list of possible email ids
   //----------------------------------------

   function EmailIds()
   {

     $f  = strtolower($this->First);
     $m  = strtolower($this->Middle);
     $l  = strtolower($this->Last);
     $fi = substr($f,0,1);
     $mi = substr($m,0,1);
     $li = substr($l,0,1);

     $s[] = $f;                             //  first@domain
     if ($l) {
        $s[] = $this->dot(trim($f." ".$l)); //  first.last@domain
        $s[] = $fi . $l;                    //  flast@domain ala MHS
        $s[] = $f .  $li;                   //  firstl@domain
        $s[] = $l  . $fi;                   //  lastf@domain
     }
     if ($mi) {
        $s[] = $fi . $mi . $l;              //  fmlast@domain
        $s[] = $l  . $fi . $mi;             //  lastfm@domain
     }

     return  array_unique($s);
   }
}

?>


