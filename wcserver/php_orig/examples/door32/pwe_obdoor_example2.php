<?php
//****************************************************************
// File Name : pwe_obdoor_example2.php
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
// - Example of using output buffer filter allowing usage
//   of PHP print commands
//
//****************************************************************

   require_once("wildcat.php");
   uses_wildcat("door32");

//----------------------------------------------------------------
// MAIN BLOCK
//----------------------------------------------------------------

   $ColorEnabled = true;

   $door = new CWildcatDoor();
   $door->SetGlobalTimeout(0);  // turn off PHP timeout
   $door->InitOutputFilter();   // Enable standard PHP output for door
   $door->ClearScreen();

   echo wcGetText("wc:\\batch\pwe\\pwedoor-hello.bbs");

   echo "@H@Welcome to PWE Door Example\n";
   echo "@B@User      : @A@". $door->UserName ."\n";
   echo "@B@Login Node: @A@", $door->Node ."\n";
   echo "@B@Door Node : @A@", wcGetNode() ."\n";

   echo "\n";
   echo "@H@Enter Email Address: @L@";
   $v1 = $door->Input();

   echo "\n";
   echo "@H@Enter Age: @L@";
   $v2 = $door->Input(2);

   echo "\n";
   echo "v1 => [$v1]\n";
   echo "v2 => [$v2]\n";

   $door->WaitEnter();

   echo "\n";
   echo "@E@- Elapsed Time: ". $door->Elapsed() ." secs@L@\n";
   echo "@H@- Returning to bbs...@L@";

   $door->Delay(2);


?>

