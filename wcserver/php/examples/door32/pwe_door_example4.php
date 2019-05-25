<?php
//****************************************************************
// File Name : pwe_door_example4.php
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
//****************************************************************

  require_once("wildcat.php");
  uses_wildcat("door32");

  // callback function for keyboard events

  function cb_term_key($door, $ch)
  {
      $key = ord($ch);
      $door->Writeln("key => [%02X] %s", $key, ($key<32)?" ":$ch);
      if ($key == 27) {
         $door->Writeln("** EXITING **");
         return;
      }
      return true;
  }

  // callback function for line drop event

  function cb_term_drop($door)
  {
     $door->Writeln("<< CLICK >> DISCONNECTED !");
  }


//----------------------------------------------------------------
// MAIN BLOCK
//----------------------------------------------------------------

  $door = new CWildcatDoor();

  $door->SetGlobalTimeout(0);  // turn off PHP timeout

  $door->ClearScreen();
  $door->Writeln(wcGetText("wc:\\batch\pwe\\pwedoor-hello.bbs"));
  $door->Writeln("@H@Welcome to PWE Door Example");
  $door->Writeln("@B@User      : @A@%s", $door->UserName);
  $door->Writeln("@B@Login Node: @A@%d", $door->Node);
  $door->Writeln("@B@Door Node : @A@%d", wcGetNode());

  $door->Bell(2);

  $door->Writeln("\r\n@N@Press a key or @H@ESCAPE@N@ to quit@L@");

  $options = array(
      ExitKey     => 0,             // set 0 if cbKeyEvent handles exit
      cbKeyEvent  => "cb_term_key",
      cbDropEvent => "cb_term_drop"
    );
  $door->Terminal($options);

  $door->Writeln();
  $door->Writeln("@E@- Elapsed Time: %d secs@L@",$door->Elapsed());
  $door->Writeln("@H@- Returning to bbs...@L@");
  $door->Delay(2);

?>

