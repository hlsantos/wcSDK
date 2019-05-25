<?php
//--------------------------------------------------------------
// File : pwe-wcNetNodes.php
// Date : 04/01/08 11:38 pm
// About: wcShareNet client example
//
// g:\phpcommon\include\wildcat.php
// g:\phpcommon\include\wildcat.console.inc.php
// g:\phpcommon\include\wildcat.door32.class.php
//
// pwe_virtualconsole.php.3
//
// History:
//--------------------------------------------------------------

require_once("wildcat.php");
uses_wildcat("door32.class");


   // callback function for keyboard events

   function cb_term_keyx($door, $ch)
   {
       $key = ord($ch);
       $door->Writeln("key => [%02X] %s", $key, ($key<32)?" ":$ch);
       if ($key == 27) {
          $door->Writeln("** EXITING **");
          return;
       }
       return true;
   }

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

   function cb_term_idle($door)
   {
      $door->Writeln("<< EVENT TIMEOUT $door->idlesecs >>");
      return true;
   }

//==============================================================
// MAIN
//==============================================================

   // create a wildcat! session

   $cio  = new CWildcatConsole();

   $cio->SetGlobalTimeout(0);  // turn off PHP timeout
   $cio->ClearScreen();

   $cio->Write("@H@Welcome to PWE Virtual Console ({$cio->GetDeviceType()})\n");
   $cio->Write("@B@User      : @A@%s\n",$cio->UserName);
   $cio->Write("@B@Login Node: @A@%d\n",$cio->Node);
   $cio->Write("@B@Door Node : @A@%d\n",wcGetNode());


   $cio->Write("@B@cmd > @A@");
   $s = $cio->Input(30);

   $cio->Bell(2);

   $cio->Writeln("\r\n@N@Press a key or @H@ESCAPE@N@ to quit@L@");

   $options = array(
       ExitKey        => 0, // set 0 if cbKeyEvent handles exit
       cbKeyEvent     => "cb_term_key",
       cbDropEvent    => "cb_term_drop",
       cbIdleEvent    => "cb_term_idle"
     );
   $cio->Terminal($options);

   $cio->Writeln();
   $cio->Writeln("@E@- Elapsed Time: %d secs@L@",$cio->Elapsed());
   $cio->Writeln("@H@- Returning to bbs...@L@");
   $cio->Delay(2);

   print "\nExiting...\n";

?>

