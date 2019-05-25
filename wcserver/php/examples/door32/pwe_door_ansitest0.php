<?php
//****************************************************************
// File Name : pwe_door_ansitest.php
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
//****************************************************************

   require_once("wildcat.php");
   uses_wildcat("door32");

   // callback function for keyboard events


   $escaped  = false;
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
            //$s = "";
            return $key;
         }
         /*
         if ($offset && substr_compare($value,$s,$offset,strlen($value)-1)) {
            //$s = substr($s,strlen($value)-1);
            //printf("- remaining: [%s]\n",$s);
            return $key;
         }
         */
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

      $door->Trace($s);

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
             $door->Writeln("e: $i <<Extended KEY => $key>>");
             switch($key) {
               case "KEY_F1":
                    $door->write("\33[r");
                    return true;
               case "KEY_F2":
                    $door->write("\33[%d;%dr",10,20);
                    return true;
             }
         } else {
             $door->Writeln("@E@<ASSERT> %s @L@",$el[$e]);
         }
      }
      return true;

   }

   function cb_term_keyX($door, $s)
   {
      $len = strlen($s);
      $el  = explode("\33",$s);
      $size = count($el);

      if ($size == 1) {
         $door->Write($s);
         return true;
      }

      if ($len == 1 && $size == 2) {
        $door->Write("<ESC>");
        $door->escapes++;
        if ($door->escapes > 2) {
           // Exit: not returning TRUE allows PHP to handle this.
           return;
        }
         return true;
      }

      for ($i = 1; $i < $size; $i++) {
         $key = GetKeyName($el[$i],1);
         if ($key) {
             //printf("i: $i <<Extended KEY => $key>>\n");
         } else {
             printf("- ASSERT ERROR i: %d [%s]\n",$i,$el[$i]);
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

   $door->ClearScreen();
   $door->Writeln(wcGetText("wc:\\batch\pwe\\pwedoor-hello.bbs"));
   $door->Writeln("@H@Welcome to PWE Door Example");
   $door->Writeln("@B@User      : @A@%s", $door->UserName);
   $door->Writeln("@B@Login Node: @A@%d", $door->Node);
   $door->Writeln("@B@Door Node : @A@%d", wcGetNode());

   $door->Writeln("\r\n@N@Press a key or the @H@^X@N@ key to quit@L@");

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

