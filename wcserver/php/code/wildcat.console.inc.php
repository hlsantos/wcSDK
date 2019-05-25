<?php
//***********************************************************************
// (c) Copyright 1998-2008 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : wildcat.console.inc.php
// Subsystem : PWE
// Date      : 03/05/08 06:29 pm
// Version   : v1.0f
// Author    : HLS/SSI
//
// Revision History:
// Build    Date      Author  Comments
// -----    --------  ------  -------------------------------------------
//***********************************************************************

$GLOBALS[ColorEnabled]  = TRUE;

$GLOBALS[DefaultColors] = array
    (                            //BYTE DefaultColors[28];
      0x0A,                      //A  Alternate title
      0x0B,                      //B  Border
      0x00,                      //C
      0x00,                      //D
      0x0C,                      //E  Error
      0x0F,                      //F  Fields
      0x00,                      //G
      0x0F,                      //H  Highlight keys
      0x00,                      //I
      0x00,                      //J
      0x00,                      //K
      0x07,                      //L  Lowlight
      0x00,                      //M
      0x0E,                      //N  Normal text
      0x3F,                      //O  Menu title alternate
      0x30,                      //P  Menu title bar
      0x3E,                      //Q  Menu item text
      0x70,                      //R  Reverse
      0x37,                      //S  Menu shadow
      0x0B,                      //T  Title
      0x0F,                      //U  User input
      0x00,                      //V
      0x00,                      //W
      0x00,                      //X
      0x00,                      //Y
      0x00                       //Z
    );

// ANSI KEY CODES
// reference:  http://en.wikipedia.org/wiki/ANSI_escape_code

define(ANSI_CSI,         "\33[");           // Control Sequence Introducer
define(ANSI_CLEAR_PAGE,  ANSI_CSI.'J');     // Control Sequence Introducer
define(ANSI_ERASE_LINE,  ANSI_CSI.'K');     // Control Sequence Introducer

define(KEY_BSPACE ,  "\10");         // ASCII 8
define(KEY_ESCAPE,   "\33");         // ASCII 27
define(KEY_DELETE,   "\177");        // ASCII 126

// EXTENDED ANSI KEY CODES

define(KEY_F1,       "\33OP");
define(KEY_F2,       "\33OQ");
define(KEY_F3,       "\33OR");
define(KEY_F4,       "\33OS");
define(KEY_F5,       "\33[15\176");
define(KEY_F6,       "\33[17\176");
define(KEY_F7,       "\33[18\176");
define(KEY_F8,       "\33[19\176");
define(KEY_F9,       "\33[20\176");
define(KEY_F10,      "\33[21\176");
define(KEY_F11,      "\33[23\176");
define(KEY_F12,      "\33[24\176");
define(KEY_UPARROW,  "\33[A");
define(KEY_RTARROW,  "\33[C");
define(KEY_DNARROW,  "\33[B");
define(KEY_LTARROW,  "\33[D");
define(KEY_INSERT,   "\33[2\176");
define(KEY_HOME,     "\33[1\176");
define(KEY_PGUP,     "\33[5\176");
define(KEY_PGDN,     "\33[6\176");
define(KEY_END,      "\33[4\176");
define(KEY_BREAK,    "\33[P");

//----------------------------------------------------------
// WordStar Control Codes
//----------------------------------------------------------

//define(WS_CTRL_J,    "^J);


// This Array should only contain keys with have an
// ANSI/VT100 sequence that begin with ESCAPE. Don't
// add others because the extended key processor
// functions don't expect it.

$GLOBALS[AnsiExtendedKeys] = array(
    "KEY_F1"         => KEY_F1,
    "KEY_F2"         => KEY_F2,
    "KEY_F3"         => KEY_F3,
    "KEY_F4"         => KEY_F4,
    "KEY_F5"         => KEY_F5,
    "KEY_F6"         => KEY_F6,
    "KEY_F7"         => KEY_F7,
    "KEY_F8"         => KEY_F8,
    "KEY_F9"         => KEY_F9,
    "KEY_F10"        => KEY_F10,
    "KEY_F11"        => KEY_F11,
    "KEY_F12"        => KEY_F12,
    "KEY_UPARROW"    => KEY_UPARROW,
    "KEY_RTARROW"    => KEY_RTARROW,
    "KEY_DNARROW"    => KEY_DNARROW,
    "KEY_LTARROW"    => KEY_LTARROW,
    "KEY_INSERT"     => KEY_INSERT,
    "KEY_HOME"       => KEY_HOME,
    "KEY_PGUP"       => KEY_PGUP,
    "KEY_PGDN"       => KEY_PGDN,
    "KEY_END"        => KEY_END,
    "KEY_BREAK"      => KEY_BREAK,
   );

//-------------------------------------------------------------
// void Delay(floast seconds)
//
// sleep by seconds or fractions of second, i.e; Delay(0.5)
// Same as WCBASIC Delay()
//-------------------------------------------------------------

function Delay($secs)
{
   usleep($secs * 1000000.0);
}

//-------------------------------------------------------------
// float GetTime()
//
// Return millisecs since 1970.
// Same as JavaScript date().getTime()
//-------------------------------------------------------------

function GetTime()
{
   list($usec,$sec) = explode(" ",microtime());
   return ((float)substr($usec,2,3) + (float)$sec*1000);
}


function AnsiColor($c, $deadspace = 0)
{
    $ColorTable = array(0, 4, 2, 6, 1, 5, 3, 7);
    $q = chr(27) . "[0;";
    if ($c & 0x08) $q .= "1;";
    if ($c & 0x80) $q .= "5;";
    $q .= "4";
    $q .= $ColorTable[($c >> 4) & 7];
    $q .= ";3";
    $q .= $ColorTable[$c & 7];
    $q .= "m";
    $deadspace = strlen($q);
    return $q;
}

function TextColor($fg)
{
   global $DefaultColors, $ColorEnabled;
   if (!$ColorEnabled) {
      return "";
   }
   return AnsiColor($DefaultColors[ord($fg)-ord("A")]);
}

function ExpandMacros($b)
{
   if (strpos($b,"@") === false) return $b;

   $lt = range("A","Z");
   foreach($lt as $c) {
     $b = str_replace("@".$c."@",TextColor($c),$b);
     if (strpos($b,"@") === false) return $b;
   }
   return $b;
}

?>
