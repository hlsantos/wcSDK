<?php

//----------------------------------------------------------------
// Functions to handle both CONSOLE vs WEB requests, to
// attempt to make it 'somewhat' consistent with WCBASIC
//-----------------------------------------------------------------

// PHP7 CGI compat: php.exe (CLI) does not auto-parse CGI environment
// variables into $_GET/$_POST/$_REQUEST the way php-cgi.exe does.
// When wcohttp invokes php.exe as a CGI script, QUERY_STRING and POST
// body are in the environment/stdin but $_REQUEST is empty.
// Initialize superglobals here so all GetParam*() calls work correctly.

if (empty($_REQUEST) && !empty($_SERVER['REQUEST_METHOD'])) {
   if (!empty($_SERVER['QUERY_STRING'])) {
      parse_str($_SERVER['QUERY_STRING'], $_GET);
   }
   if ($_SERVER['REQUEST_METHOD'] == 'POST') {
      $raw = file_get_contents('php://input');
      if ($raw) parse_str($raw, $_POST);
   }
   $_REQUEST = array_merge($_GET, $_POST);
}

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
   $val = stripslashes($parms[$key] ?? "");
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
