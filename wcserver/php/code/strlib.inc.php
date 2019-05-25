<?PHP
//--------------------------------------------------
// File  : strlib.inc.php
// Date  : 01/16/08 09:20 pm
// Author: HLS
//--------------------------------------------------

//--------------------------------------------------
// splitPath(string, delimter)
//
// return index array of path parts
//
//--------------------------------------------------

function splitPath($s,  $del = "/")
{
   $list = array();
   $tok = strtok($s, $del);
   while ($tok !== false) {
       $list[] = $tok;
       $tok = strtok($del);
   }
   return $list;
}

// --------------------------------------------------------
// Note: The following functions use BASE 0 for string
//       results;
// --------------------------------------------------------

function instr($offset,$s,$c=null)
{
   if ($c == null) {
      $c = $s;
      $s = $offset;
      $offset = null;
   }
   $i = stripos($s,$c,$offset);
   if ($i === false) $i = -1;
   return $i;
}

function mid($s,$start,$len = null)
{
   if ($len != null) return substr($s,$start,$len);
   return substr($s,$start);
}

function left($s,$len)
{
   return substr($s,0,$len);
}

function right($s,$len)
{
   $c = count($s);
   return substr($s,$c-$len-1);
}

function lcase($s)
{
   return strtolower($s);
}

function ucase($s)
{
   return strtoupper($s);
}


?>
