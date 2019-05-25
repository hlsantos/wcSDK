<?PHP
//***********************************************************************
// (c) Copyright 1998-2008 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : wildcat.mail.class.php
// Subsystem : PWE
// Date      : 03/19/08 01:51 pm
// Version   : v1.0f
// Author    : HLS/SSI
//
// Usage     :
//
//  $mail  = new CWildcatMail();
//  $areas = new CWildcatMailAreas();
//
//
// Revision History:
// Build    Date      Author  Comments
// -----    --------  ------  -------------------------------------------
//***********************************************************************

require_once("wildcat.php");

class CWildcatMailAreas {

    public $Areas = array();
    function __construct($grp = 0, $flags = 0)
    {
        $cn = wcGetFirstConference($grp,$flags);
        while ($cn > -1) {
           if (wcGetConfDesc($cn,&$cd)) $this->Areas[] = $cd;
           $cn = wcGetNextConference($grp,$flags,$cn);
        }
    }

}

class CWildcatMail implements Iterator {

    public $msg = array();
    public $datefmt    = "%Y/%m/%d";
    public $timefmt    = "%H:%M:%S";
    public $Conference = 0;
    public $var = array();

    public function __construct($cnum = 0)
    {
      if ($cnum >= 0) {
         $Conference = $cnum;
         $this->set("Conference",$cnum);
      }
    }
    public function rewind() {
        //echo "rewinding\n";
        reset($this->var);
    }

    public function current() {
        $var = current($this->var);
        //echo "current: $var\n";
        return $var;
    }

    public function key() {
        $var = key($this->var);
        //echo "key: $var\n";
        return $var;
    }

    public function next() {
        $var = next($this->var);
        //echo "next: {$var}  ------>\n";
        return $var;
    }

    public function prev() {
        $var = prev($this->var);
        //echo "prev: {$var} <------\n";
        return $var;
    }

    public function valid() {
        $var = $this->current() !== false;
        echo "valid: {$var} | {$this->current()}\n";
        return $var;
    }


    function PrevMessage()
    {
      $r = GetPrevMessage(&$this->msg);
      if ($r) $this->var[] = $this->Get("Number");
      return $r;
    }

    function NextMessage()
    {
      $r = GetNextMessage(&$this->msg);
      if ($r) $this->var[] = $this->Get("Number");
      return $r;
    }

    function Set($fld, $val)
    {
       $list = explode(".",$fld);
       if (count($list) == 1) {
          $this->msg[$fld] = $val;
       }
       else
       if (count($list) == 2) {
          $this->msg[$list[0]][$list[1]] = $val;
       }
    }

    function Get($fld)
    {
       $r = "";
       foreach(explode(".",$fld) as $n) {
         if ($r == "") {
            $r = $this->msg[$n];
         } else {
            $r = $r[$n];
         }
       }
       return $r;
    }

    function GetDate($fld)
    {
       return strftime($datefmt,$this->Get($fld));
    }

    function GetTime($fld, $datetoo = true)
    {
       $s = "";
       if ($datetoo) $s = $this->datefmt." ";
       $s .= $this->timefmt;
       return strftime($s,$this->Get($fld));
    }

    function GetTotalMessages()
    {
      return GetTotalMessagesInConference($This->Conference);
    }

}
?>

