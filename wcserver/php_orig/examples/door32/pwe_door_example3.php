<?php
//****************************************************************
// File Name : pwe_door_example3.php
// Subsystem : PWE
//
// Example PWE based DOOR
//
// - Using wildcat.door32.class.php
//
// - Simple Dumb Terminal with I/O events
//
// - Supports a minimum set of the WCT color AT macros.
//
// - Has Idle timeout considerations using a 1 sec
//   event timeout resolution
//
//****************************************************************

  require_once("wildcat.php");
  uses_wildcat("door32");

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

  printf("2 ColorEnabled : %s\n",$ColorEnabled?"On":"Off");

  $door->Bell(2);

  $door->Writeln("\r\n@N@Press a key or @H@ESCAPE@N@ to quit@L@");

  $door->Terminal();

  $door->Writeln();
  $door->Writeln("@E@- Elapsed Time: %d secs@L@",$door->Elapsed());
  $door->Writeln("@H@- Returning to bbs...@L@");
  $door->Delay(2);

?>

