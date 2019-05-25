<?php
//--------------------------------------------------------------
// File : wildcat.filetime.inc.php
// Date : 02/27/08 11:05 pm
// About:
//
// History:
//--------------------------------------------------------------

function FmtTicks($t)
{
   $t = $t / 1000;
   $secs  = $t%60;
   $mins  = $t/60;
   $hrs   = $mins/60;
   $mins  = $mins%60;
   return sprintf("%02d:%02d:%02d",$hrs,$mins,$secs);
}


Function DateTimeString1($dt, $dfmt = "MM/dd/yy", $tfmt = "HH:mmt", $flags = 0)
{
  $s = DateString($dt,$dfmt);
  if ($s != "") $s .= " " . TimeString($dt,$tfmt,$flags);
  return $s;
}

Function DateTimeString2($dt,
                        $opts = "{'datefmt':'MM/dd/yy',
                                  'timefmt':'HH:mmt',
                                  'flags':0}")
{
  $opts = json_decode($opts);
  $s = DateString($dt,$dfmt);
  if ($s != "") $s .= " " . TimeString($dt,$tfmt,$flags);
  return $s;
}

Function DateTimeString($dt, $newopts = null)

{
  $opts = array(
     "datefmt" => "MM/dd/yy",
     "timefmt" => "HH:mmt",
     "flags"   => 0
     );
  if (is_array($newopts)) {
     $opts = array_merge($opts,$newopts);
  }
  else if (is_string($newopts)) {
     $newopts = str_replace("'","\"",$newopts);
     $opts = array_merge($opts,json_decode($newopts,true));
  }
  $s = DateString($dt,$opts["datefmt"]);
  if ($s != "") $s .= " " . TimeString($dt,$opts["timefmt"],$opts["flags"]);
  return $s;
}

Function Now()
{
   $gd = getdate();
   $gd = $gd["0"];
   FileTimeToLocalFileTime(&$gd);
   return $gd;
}

class CFileTime {

    private $ft = null;

    function _construct($ft = null)
    {
       $this->ft = $ft;
    }

    function uts()
    {
        return FileTimeToUnixTime($this->ft);
    }
}

?>

