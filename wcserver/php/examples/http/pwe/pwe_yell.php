<?php
//--------------------------------------------------------------
// (c) copyright 2008 Santronics Software, Inc.
// File : V:\wc5beta\pwe_yell.php
// Date : 03/10/08 08:23 am
// About:
//
// Illustrates how to use Wildcat.Event.class.php for sending
// a broadcast.
//
// History:
//--------------------------------------------------------------

//--------------------------------------------------------------
// MAIN
//--------------------------------------------------------------

   require_once("wildcat.php");
   uses_wildcat("event.class");

   $wcat  = new CWildcat();
   $event = new CWildcatEvent();

   // Use the Broadcast($from, $text) method to
   // broadcat a message to all logged in users

   $event->BroadCast("","Please Log off now!\nPronto!");

   // Use the Page($destid, $from, $test) method to page
   // a specific user. Using a $destid=0 is the same as
   // as a broadcast. In fact, the Broadcast() method is
   // use a wrapper around the Page() method.

   $event->Page(0,"Hector","Hi there!");

   // You don't need to use the Event class. The class
   // just wraps the WCSDK Channel functions. The
   // following illustrates how to do a broadcast going
   // directly with the API.  The only thing you need
   // pay attention to when using the API via PHP is that
   // you need to use the pack command using a special
   // WCEVENT_TPAGEMESSAGE_FORMAT exactly how it is shown
   // below.  This is where the wildcat.event class is
   // useful.


   // see TSystemPageInstantMessage
   $page = array();
   $page["From"]      = "Sysop";
   $page["Text"][]    = "Please login now. System Shutdown Pending";
   $page["Text"][]    = "line2";
   $page["Text"][]    = "line3";
   $page["InviteToChat"] = 0;
   $pagepack = pack(WCEVENT_TPAGEMESSAGE_FORMAT,
           $page["From"],
           $page["Text"][0],
           $page["Text"][1],
           $page["Text"][2],
           $page["InviteToChat"]
           );
   $pagebytes = str_split($pagepack);
   wcWriteChannel(wcOpenChannel("System.Page"),  // channel
                  0,                             // destid
                  SP_USER_PAGE,                  // event type
                  $pagebytes,                    // data
                  count($pagebytes));            // data size


?>

