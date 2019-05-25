<?php
//****************************************************************
// File Name : pwe_doorsys_test.php
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
// - Reads and Writes DOOR.SYS dropfile.
//
//   Note: "Run a door.wcx" always create a small style door.sys.
//          WCCONFIG | Doors setup offer both small and large. The
//          docs says a large one include conference info but this
//          is not necessary with PWE.
//
//   A dropfile contains session information read by a door via
//   a standard text file. In this case, door.sys.
//
//   For most doors which is not "Wildcat! Aware", a drop file
//   is nessary to get session information.  However, this is
//   not technically required since PWE has direct Wildcat!
//   API support and can get use the same logic the "Run a door.wcx"
//   application used to create the drop file.  This example
//   will read and dump the file for illustration purposes.
//
//****************************************************************

   require_once("wildcat.php");
   uses_wildcat("door32");

//----------------------------------------------------------------
// MAIN BLOCK
//----------------------------------------------------------------

   $door = new CWildcatDoor();
   $door->SetGlobalTimeout(0);  // turn off PHP timeout
   $door->InitOutputFilter();   // Enable standard PHP output for door
   $door->ClearScreen();

   echo wcGetText("wc:\\batch\pwe\\pwedoor-hello.bbs");

   echo "@H@Welcome to PWE Door Example\n";
   echo "@B@User      : @A@". $door->UserName ."\n";
   echo "@B@Login Node: @A@". $door->Node ."\n";
   echo "@B@Door Node : @A@". wcGetNode() ."\n";
   echo "@B@Graphics  : @A@". $ColorEnabled ."\n";

   print_r($door->DoorSys);
   $door->WaitEnter();

   echo "\n";
   echo "@E@- Elapsed Time: ". $door->Elapsed() ." secs@L@\n";
   echo "@H@- Returning to bbs...@L@";

   $door->Delay(2);


?>

