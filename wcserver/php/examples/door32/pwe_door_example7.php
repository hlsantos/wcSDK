<?php
//****************************************************************
// File Name : pwe_door_example7.php
// Subsystem : PWE
//
// Example PWE based DOOR
//
// - Using wildcatdoor.pwc
//
// - Simple Dumb Terminal with I/O events
//
// - Supports a minimum set of the WCT color AT macros.
//
// - Has Idle timeout considerations using a 1 sec
//   event timeout resolution
//
// - Example of terminal options to define call back events
//   allowing you to take application level control of
//   event actions.
//
// - Example of using idle timeout callback
//
// - Now detects Extended keys ANSI escape sequences
//   see wildcat.console.inc.php
//
//****************************************************************

   require_once("wildcat.php");
   uses_wildcat("door32");

   // callback function for keyboard events

   function cb_term_key($door, $s)
   {
       global $AnsiExtendedKeys;

       foreach($AnsiExtendedKeys as $key => $value) {
          if ($value == $s) {
             $door->Writeln("<<Extended Key => $key>>");
             return true;
          }
       }
       //----------------------------------
       $len = strlen($s);
       $bytes = str_split($s);
       foreach($bytes as $i => $b) {
          $key = ord($b);
          $door->Writeln(" - len: %3d [%02X] [%3d] %s",
                       $len,$key,$key,($key<32)?" ":$b);
          if ($key == 27) {
             $door->escapes++;
             if ($door->escapes > 2) {
                $door->Writeln("** EXITING **");
                return;
             }
          } else {
             $door->escapes = 0;
          }
       }
       return true;
   }

   // callback function for line drop event

   function cb_term_drop($door)
   {
      $door->Writeln("<< CLICK >> DISCONNECTED !");
   }

   // callback function for event timeout

   function cb_term_idle($door)
   {
      $door->Writeln("<< EVENT TIMEOUT $door->idlesecs >>");
      return true;
   }

 //----------------------------------------------------------------
 // MAIN BLOCK
 //----------------------------------------------------------------

   $door = new CWildcatDoor();

   //$door->SetGlobalTimeout(0);  // turn off PHP timeout

   $door->ClearScreen();
   $door->Writeln(wcGetText("wc:\\batch\pwe\\pwedoor-hello.bbs"));
   $door->Writeln("@H@Welcome to PWE Door Example");
   $door->Writeln("@B@User      : @A@%s", $door->UserName);
   $door->Writeln("@B@Login Node: @A@%d", $door->Node);
   $door->Writeln("@B@Door Node : @A@%d", wcGetNode());

   $door->Writeln("\r\n@N@Press a key or @H@THREE ESCAPES@N@ to quit@L@");

   $options = array(
        ExitKey        => 0, // set 0 if cbKeyEvent handles exit
        cbKeyEvent     => "cb_term_key",
        cbDropEvent    => "cb_term_drop",
        cbIdleEvent    => "cb_term_idle"
      );

   $door->Terminal($options);

   $door->Writeln();
   $door->Writeln("@E@- Elapsed Time: %d secs@L@",$door->Elapsed());
   $door->Writeln("@H@- Returning to bbs...@L@");
   $door->Delay(2);

?>

