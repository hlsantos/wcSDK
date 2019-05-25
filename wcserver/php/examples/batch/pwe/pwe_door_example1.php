<?php
//****************************************************************
// File Name : pwe_door_example1.php
// Subsystem : PWE
//
// Example PWE based DOOR - HELLO WORLD!
//
// Using Direct WCDOO32 API functions.
//
//****************************************************************

  @dl("php_wildcat.dll");        // Make sure PWE is loaded

  wcDoorInitialize();            // Reestablish user session

  // flush input stream, probably a lingering <LF> from a
  // terminal emulator which might issue a <LF> with each <CR>

  while (wcDoorRead(&$ch));

  wcDoorWrite("Hello World!\r\n");
  wcDoorWrite("Press any key to exit => ");

  while (!wcDoorRead(&$ch)) {
     usleep(250*1000);         // sleep for 250 ms
  }

  wcDoorShutDown();            // Clean up
?>
