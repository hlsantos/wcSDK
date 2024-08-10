<?php
//****************************************************************
// File Name : pwe_door_example2.php
// Subsystem : PWE
//
// Example PWE based DOOR:
//
// - Using direct WCDOOR32 API functions (no classes)
//
// - Simple Dumb Terminal with I/O events
//
// - Has Idle timeout considerations using a 1 sec
//   event timeout resolution
//
//****************************************************************

  @dl("php_wildcat.dll");

  function delay($msec)  { usleep($msec*1000); }

//----------------------------------------------------------------
// MAIN BLOCK
//----------------------------------------------------------------

  $GlobalTimeoutSecs   = 60*5;
  $IdleTimeoutSecs     = 60;
  $startsecs           = time();

  set_time_limit($GlobalTimeoutSecs);

  if (!wcDoorInitialize()) {
     die("Door intialization Failed!");
  }

  // Get user/node information:

  WildcatLoggedIn(&$User);
  $UserName = $User[Info][Name];
  $DoorNode = getenv("WCNODEID");

  // Present Welcome!

  wcDoorWrite("Welcome to PWE Door Example\r\n");
  wcDoorWrite("User      : $UserName\r\n");
  wcDoorWrite("Door Node : $DoorNode\r\n");
  wcDoorWrite("Press a key or ESCAPE to quit\r\n");

  // flush any garbage in input queue

  while (wcDoorRead(&$c));

  // use events to provide an efficient dump terminal

  $done     = false;
  $idlesecs = 0;

  while (!$done) {
    switch (wcDoorEvent(1000)) {
      //-------------------------------------
      // TIMEOUT SIGNAL
      //-------------------------------------
      case WCDOOR_EVENT_TIMEOUT:
        $idlesecs++;
        if ($idlesecs >= ($IdleTimeoutSecs+60)) {
            wcDoorWrite("\r\nTIMEOUT!\r\n");
            $done = true;
        }
        if ($idlesecs == $IdleTimeoutSecs) {
            wcDoorWrite("\r\nWARNING! Timeout in 60 seconds\r\n");
        }
        break;

      //-------------------------------------
      // KEYBOARD SIGNAL
      //-------------------------------------
      case WCDOOR_EVENT_KEYBOARD:
        $n = wcDoorRead(&$c);
        delay(15);
        if ($n > 0) {
            $idlesecs = 0;
            if ($c == chr(27)) {
               $done = true;
               break;
            }
            wcDoorWrite($c);
            // add linefeed if carriage is seen
            if ($c == chr(13)) wcDoorWrite(chr(10));
        }
        break;

      //-------------------------------------
      // TERMINATE SIGNAL
      //-------------------------------------
      case WCDOOR_EVENT_OFFLINE:
        wcDoorWrite("\r\nWILDCAT! SYSTEM TERMINATED\r\n");
        delay(1000);
        $done = true;
        exit();

      //-------------------------------------
      // FUNCTION FAILED
      //-------------------------------------
      case WCDOOR_EVENT_FAILED:
        wcDoorWrite("\r\nWAIT_FAILED\r\n");
        delay(1000);
        $done = true;
        break;
    }
  }

  $elapsed = time() - $startsecs;
  wcDoorWrite("\r\nElapsed Time: $elapsed secs .\r\n");
  wcDoorWrite("\r\nReturning to bbs...\r\n");
  delay(1000);

?>
