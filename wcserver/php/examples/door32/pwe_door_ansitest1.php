<?php
//****************************************************************
// File Name : pwe_door_ansitest1.php
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
// - Supports Extended Keys with exploration of different
//   logic to compensate for missed sequences.  This is
//   due to attempting to buffer in the keys rather than
//   process one key at a time which would be slower.
//
// - Early attempt to create a scrolling region
//
//****************************************************************

   require_once("wildcat.php");
   uses_wildcat("door32");

   // callback function for keyboard events

   function GetKeyName($s, $offset = 0)
   {
      global $AnsiExtendedKeys;
      switch($s) {
        case KEY_DELETE: return "KEY_DELETE";
        case KEY_BSPACE: return "KEY_BSPACE";
      }
      foreach($AnsiExtendedKeys as $key => $value) {
         if (($value == $s) ||
             ($offset && (substr($value,$offset) == $s))) {
            return $key;
         }
      }
      return null;
   }

   $escaped = false;
   function cb_term_key($door, $s)
   {
      global $escaped;

      $len  = strlen($s);
      $el   = explode("\33",$s);
      $size = count($el);

      if ($size == 1 && !$escaped) {
         $door->Write($s);
         return true;
      }

      if ($len == 1 && $size == 2) {
        $door->Writeln("@E@<ESC>@L@");
        $escaped = true;
        return true;
      }
      $escaped = false;

      if ($size == 1 && $len == 1) {
         $door->Write($s);
         return true;
      }

      for ($e = 1; $e < $size; $e++) {
         $key = GetKeyName($el[$e],1);
         if ($key) {
             //$door->Writeln("e: $i <<Extended KEY => $key>>");
             switch($key) {
               case "KEY_BREAK":
                    return;
               case "KEY_F1":
                    $door->write("\33[r");
                    return true;
              case "KEY_F2";
                    $door->write("\33[%d;%dr",2,22);
                    return true;
             }
         } else {
             $door->Writeln("@E@<ASSERT> %s @L@",$el[$e]);
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
      //$door->Writeln("<< EVENT TIMEOUT $door->idlesecs >>");
      return true;
   }

//----------------------------------------------------------------
// MAIN BLOCK
//----------------------------------------------------------------

   $door = new CWildcatDoor();

   //$door->SetGlobalTimeout(0);  // turn off PHP timeout

   $sTop = 2;
   $sBot = 23;
   $hLine = str_repeat("-",80);

   $door->ClearScreen();

   $door->Write("\33[1;1H\33[33;44m\33[KPWE Jabber v1.0 User: %s", $door->UserName);
   $door->Write("\33[%d;1H@H@%s@L@",$sTop,$hLine);
   $door->Write("\33[%d;1H@H@%s@L@",$sBot,$hLine);
   $door->write("\33[%d;%dr",$sTop+1,$sBot-1);
   $door->write("\33[%d;1H",$sTop+1);

   $door->Writeln("@N@Press @H@^X@N@ to exit@L@");

   $options = array(
       ExitKey        =>  0x18, // set ctrl X for exit
       cbKeyEvent     => "cb_term_key",
       cbDropEvent    => "cb_term_drop",
       cbIdleEvent    => "cb_term_idle"
     );
   $door->InputBufferSize  = 0;
   $door->Terminal($options);


   $door->Writeln();
   $door->Writeln("@E@- Elapsed Time: %d secs@L@",$door->Elapsed());
   $door->Writeln("@H@- Returning to bbs...@L@");
   $door->Delay(2);

?>

