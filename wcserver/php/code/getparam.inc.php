<?php

//----------------------------------------------------------------
// Functions to handle both CONSOLE vs WEB requests, to
// attempt to make it 'somewhat' consistent with WCBASIC
//-----------------------------------------------------------------

function ParamCount()
{

   $p = $_SERVER['argc'];
   if ($_SERVER["REQUEST_METHOD"] != "") {
      return $p;
   }
   return $p-1;
}

function ParamStr($i = null)
{
   $p[] =   __FILE__;
   if ($_SERVER["REQUEST_METHOD"] != "") {
       foreach($_SERVER['argv'] as $v) {
          $p[] =  $v;
       }
   } else {
       $p = $_SERVER['argv'];
   }
   if ($i === null) return rawurldecode($p);
   return rawurldecode($p[$i]);
}

function GetParam($key, $def = null)
{
   $parms = $_REQUEST;
   $val = stripslashes($parms[$key]);
   if ($val == NULL) $val = $def;
   return $val;
}

function GetParamBool($key, $def = false)
{
   return (bool)GetParam($key,$def);
}

function GetParamStr($key, $def = "")
{
   return (string)GetParam($key,$def);
}

function GetParamInt($key, $def = 0)
{
   return (int)GetParam($key,$def);
}

?>
