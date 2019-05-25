<?php

function ini2array($ini)
{
   $uv = array();
   foreach(explode("\n", $ini) as $s) {
     if ($s == "") continue;
     if ($s[0] == ";") continue;
     if ($s[0] == ":") continue;
     if ($s[0] == "#") continue;
     $s = trim($s);
     if (substr($s,0,1) == "[") {
       $section = strtolower(trim($s,"[]"));
     } else {
       list($key,$value) = explode("=",$s,2);
       $key = trim($key);
       if ($key) $uv[$section][strtolower($key)]=$value;
     }
   }
   return $uv;
}

function array2ini($array)
{
    if( !is_array($array)) return $array;
    $ini = "";
    foreach($array as $section => $keys) {
       if(is_array($keys)) {
          $ini .= "[" . $section . "]\n";
          foreach($keys as $key => $value) {
             $ini .= $key . "=" . $value ."\n";
          }
       }
    }
    return $ini;
}

?>
