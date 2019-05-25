<?php

   require_once("wildcat.php");
   uses_wildcat("door32");

//---------------------------------------------------------------
// main
//---------------------------------------------------------------

   $door = new CWildcatDoor();
   $door->SetGlobalTimeout(0);  // turn off PHP timeout
   $door->InitOutputFilter();   // Enable standard PHP output for door
   $door->ClearScreen();

   $World = simplexml_load_file("gameworld.xml");
   $CurrentPos = 0;
   $Done = 0;
   print "\n";

   printplace() ;

   function printplace() {
       GLOBAL $World, $CurrentPos;

       $Room = $World->ROOM[$CurrentPos];
       $Name = $Room->NAME;
       $Desc = wordwrap((string)$Room->DESC);

       print "\n@H@$Name\n";
       print str_repeat('-', strlen($Name));
       print "\n@N@$Desc\n\n@L@";

       if ((string)$Room->NORTH != '-') {
           $index = (int)$Room->NORTH;
           print "@H@North:@B@ {$World->ROOM[$index]->NAME}\n";
       }

       if ((string)$Room->SOUTH != '-') {
           $index = (int)$Room->SOUTH;
           print "@H@South:@B@ {$World->ROOM[$index]->NAME}\n";
       }

       if ((string)$World->ROOM[$CurrentPos]->WEST != '-') {
           $index = (int)$Room->WEST;
           print "@H@West:@B@ {$World->ROOM[$index]->NAME}\n";
       }

       if ((string)$World->ROOM[$CurrentPos]->EAST != '-') {
           $index = (int)$Room->EAST;
           print "@H@East:@B@ {$World->ROOM[$index]->NAME}\n";
       }

       print "\n";
   }

   $cmds[NORTH]  = array(key => "n", action => "");
   $cmds[EAST]   = array(key => "e", action => "");
   $cmds[SOUTH]  = array(key => "s", action => "");
   $cmds[WEST]   = array(key => "w", action => "");
   $cmds[QUIT]   = array(key => "q", action => "");
   $cmds[LOOK]   = array(key => "l", action => "");

   while (!$Done) {

       print "@H@> @L@";
       $input = $door->Input();

       print "\n"; // add another line break after the user input

       $input = split(' ', $input);

       switch(strtolower(trim($input[0]))) {
           case 'north':
           case 'n':
               if ((string)$World->ROOM[$CurrentPos]->NORTH != '-') {
                   $CurrentPos = (int)$World->ROOM[$CurrentPos]->NORTH;
                   printplace() ;
               } else {
                   print "You cannot go north!\n";
               }
               break;
           case 'south':
           case 's':
               if ((string)$World->ROOM[$CurrentPos]->SOUTH != '-') {
                   $CurrentPos = (int)$World->ROOM[$CurrentPos]->SOUTH;
                   printplace() ;
               } else {
                   print "You cannot go south!\n";
               }
               break;
           case 'west':
           case 'w':
               if ((string)$World->ROOM[$CurrentPos]->WEST != '-') {
                   $CurrentPos = (int)$World->ROOM[$CurrentPos]->WEST;
                   printplace() ;
               } else {
                   print "You cannot go west!\n";
               }
               break;
           case 'east':
           case 'e':
               if ((string)$World->ROOM[$CurrentPos]->EAST != '-') {
                   $CurrentPos = (int)$World->ROOM[$CurrentPos]->EAST;
                   printplace() ;
               } else {
                   print "You cannot go east!\n";
               }
               break;

           case 'look':
           case 'l':
               printplace() ;
               break;

           case 'quit':
           case 'q':
               $Done = 1;
               break;
       }
   }

   print "\n@B@Thanks for playing!@L@\n\n";

   Delay(2);

?>

