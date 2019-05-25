<?php
//--------------------------------------------------------------
// (c) copyright 2008 Santronics Software, Inc.
// File : pwe-who.php
// Date : 03/17/08 07:57 am
// About: A simple Who's Online
//
// Allowed to run in:
//
//  - non-authenticated local mode (non-http), or
//  - authenticated web mode.
//
//--------------------------------------------------------------

//==============================================================
// MAIN
//==============================================================

   require_once("wildcat.php");
   uses_wildcat("filetime.inc");

   // create a wildcat! session

   $wcat = new cWildcat();

   // If already logged in, ok. otherwise only login
   // as system if in local mode (not HTTP)
   $localmode =  IsLocalMode();

   if (!$wcat->Node()) {
       if (!$localmode || !$wcat->LoginSystem()) {
          printf("! ERROR %08X Not logged in\n",wcGetLastError());
          die();
       }
   }

   wcSetNodeActivity("PWE: Who's Online");

   if (!$localmode) print "<pre>";

   // start display loop

   while (1) {

      // get a "snap shot" of all nodes so far

      $nodes = wcGetNodeInfos();

      print "---------------------------------------------------\n";
      printf("* Current CID          : %d\n",wcGetConnectionId());
      printf("* Current Node         : %d\n",wcGetNode());
      printf("* Node Count           : %d\n",wcGetNodeCount());
      printf("* Users Online         : %d\n",wcGetUsersOnline());
      printf("\n");

      // display the nodes with a connection id only

      foreach($nodes as $ni) {
         if ($ni[ConnectionId]) {
             $tc = $ni[TimeCalled];
             $ct = $ni[CurrentTime];
             $it = FileTimeToUnixTime($ct)-FileTimeToUnixTime($tc);

             $calltype = wcGetCallType($ni[ConnectionId]);

             printf("%4d | %3d | %4d | %s | %-6s | %-20s | %s\n",
                    $ni[ConnectionId],
                    $ni[NodeNumber],
                    $ni[MinutesLeft],
                    FmtTicks($it*1000),
                    wcGetCallTypeStr($calltype),
                    $ni[User][Name],
                    $ni[Activity]
                    );
         }
      }

      // wait for keystroke and loop to show again
      // press escape to exit. if not local mode, break out.

      if (!$localmode) break;
      print "\nPress key to continue or ESCAPE to Exit: ";
      if (wcReadKey() == 27) break;
      print "\r";

   }
   if (!$localmode) print "</pre>";

?>

