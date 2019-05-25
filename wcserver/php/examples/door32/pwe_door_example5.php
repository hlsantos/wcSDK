<?php
//****************************************************************
// File Name : pwe_door_example5.php
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
// - Example of using a line Input
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

  $door->Writeln();
  $door->Write("@H@Enter Email Address: @L@");
  $v1 = $door->Input();

  $door->Writeln();
  $door->Write("@H@Enter Age: @L@");
  $v2 = $door->Input(2);

  $door->Writeln();
  $door->Writeln("v1 => [$v1]");
  $door->Writeln("v2 => [$v2]");
  $door->WaitEnter();

  $door->Writeln();
  $door->Writeln("@E@- Elapsed Time: %d secs@L@",$door->Elapsed());
  $door->Writeln("@H@- Returning to bbs...@L@");
  $door->Delay(2);

?>

