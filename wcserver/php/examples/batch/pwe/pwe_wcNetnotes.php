<?php
//--------------------------------------------------------------
// File : pwe-wcNetNodes.php
// Date : 04/01/08 11:38 pm
// About: wcShareNet client example
//
// g:\phpcommon\include\wildcat.php
// g:\phpcommon\include\wildcat.console.inc.php
// g:\phpcommon\include\wildcat.door32.class.php
//
// History:
//--------------------------------------------------------------

require_once("wildcat.php");
uses_wildcat("filetime.inc");
uses_wildcat("door32.class");

define("DEBUG_POLL",0);
define("DEBUG_SEND",0);

//-------------------------------------------------------------
// int PollNotes(array userdata, [int rid = 0])
//
// Poll for notes, return totals and notes from last request
// id (rid) in json format.
//
// if rid is zero, return totals only
//-------------------------------------------------------------

   function PollNotes($cio, $hosts, $userdata, $rid = 0)
   {
      $data = array(
         cmd => "poll",
         rid => $rid,
         uid => "pweuser",
         uts => GetTime(),
      );

      $data = array_merge($data, $userdata);
      $urldata = http_build_query($data);

if (DEBUG_POLL)
{
      print "---------- DEBUG: PollNotes() -----------\n";
      printf("-- \$hosts --\n%s\n",print_r($hosts,true));
      printf("-- \$data --\n%s\n",print_r($data,true));
      printf("-- \$urldata --\n%s\n",print_r($urldata,true));
      print "-----------------------------------------\n";
      //return;
}
      foreach($hosts as $uri)
      {
          $url = "$uri?$urldata";
          $r = file_get_contents($url);
          $rs = explode("|",$r);

          $rid = $rs[0];
          $new = $rs[1];

          if ($new) {
             //print "Total: $rid  New: $new\n";
             $jrs = json_decode($rs[2],true);
             $cio->write("@A@_____________________________________@L@\n");
             foreach($jrs[notes] as $p) {
                $cio->write("@H@$p[tid],@B@ $p[uid]@L@\n");
                $cio->write(urldecode($p[data])."\n");
             }
          }
      }
      return $rid;
    }

//-------------------------------------------------------------
// int SaveNotes(array userdata,string txt)
//
// Save notes
//-------------------------------------------------------------

   function SendNote($hosts, $userdata, $txt)
   {
      $data = array(
         cmd => "note",
         uid => "pweuser",
         uts => GetTime(),
         txt => $txt,
      );

      $data = array_merge($data, $userdata);
      $urldata = http_build_query($data);

if (DEBUG_SEND)
{
      print "---------- DEBUG: SendNote() -----------\n";
      printf("-- \$hosts --\n%s\n",print_r($hosts,true));
      printf("-- \$data --\n%s\n",print_r($data,true));
      printf("-- \$urldata --\n%s\n",print_r($urldata,true));
      print "-----------------------------------------\n";
      return;
}
      $uri = $hosts[0];
      $url = "$uri?$urldata";
      $r = file_get_contents($url);
      print "result: $r\n";
   }


//==============================================================
// MAIN
//==============================================================

   $cio  = new CWildcatConsole();

   $cio->SetGlobalTimeout(0);  // turn off PHP timeout
   $cio->ClearScreen();

   $cio->Write("@H@Welcome to PWE Virtual Console ({$cio->GetDeviceType()})\n");
   $cio->Write("@B@User      : @A@%s\n",$cio->UserName);
   $cio->Write("@B@Login Node: @A@%d\n",$cio->Node);
   $cio->Write("@B@Door Node : @A@%d\n",wcGetNode());

   //--------------------------------------
   // prepare user data
   //--------------------------------------

   $userdata = array(
      uid => "pweuser"
   );
   if ($cio->UserName) $userdata[uid] = $cio->UserName;

   //--------------------------------------
   // define host url
   //--------------------------------------

   //$hosts[]   = "http://hdev1/public/code/html-wcNetNotes.wcx";
   $hosts[] = "http://beta.winserver.com/public/code/html-wcNetNotes.wcx";

   //--------------------------------------
   // prepare poll/frequency variables
   //--------------------------------------

   $rid       = 0;     // request id
   $freqTime  = 10;     // msecs
   $nextTime  = 0;      // accumulated time
   $sleepTime = 0.100;  // seconds

   //--------------------------------------
   // Get initial totals
   //--------------------------------------

   $rid  = PollNotes($cio, $hosts,$userdata,$rid);

   //--------------------------------------
   // start display loop
   //--------------------------------------

   $PROMPT1 = "@H@[@B@Press @H@[ENTER]@B@ to send note/commands, @H@[ESC]@B@ to Exit@H@]@L@";
   $PROMPT2 = "@H@[@B@Type note to send or command, @H@/?@B@ for HELP@H@]@L@";
   $HELP   = "";
   $HELP  .= "-------------------- Help ---------------------\n";
   $HELP  .= " /?                   - this help\n";
   $HELP  .= " /NAME displayname    - set your display name\n";
   $HELP  .= " /LAST #              - get last # notes\n";
   $HELP  .= " /CLEAR               - clear screen\n";
   $HELP  .= " /QUIT                - Quit/exit\n";
   $HELP  .= "------------------------------------------------\n";

   $cio->Write("\nWelcome $userdata[uid]\n\n");
   $cio->Write($PROMPT1."\n");

   while (1) {
     Delay($sleepTime);
     $nextTime += $sleepTime;
     //---------------------------------
     // Check if key pressed
     //---------------------------------

     if ($cio->CharReady()) {
         $ch = $cio->GetKey();
         if ($ch == chr(27)) break;
         if ($ch == chr(10)) continue;

         $cio->Writeln();
         $cio->Writeln($PROMPT2);
         $cio->Write("> ");
         $s = trim($cio->Input(70));
         $cio->Writeln();
         if ($s) {
            $cmd = explode(" ",$s,2);
            if (strtolower($cmd[0]) == "/q") break;
            switch (strtolower($cmd[0])) {
               case "/?":
                  $cio->Write($HELP."\n");
                  break;
               case "/n":
               case "/name":
                  if ($cmd[1]) {
                     $userdata[uid] = $cmd[1];
                     $cio->Writeln();
                     $cio->Write("- Display Name set to: $cmd[1]\n");
                     $cio->Write("- Note: May be preset at wcShareNet host\n");
                     $cio->Writeln();
                  }
                  break;
               case "/l":
               case "/last":
                   if ($cmd[1]) {
                      $x = (int)$rid - (int)$cmd[1];
                      if ($x > 0) {
                         $rid = PollNotes($cio, $hosts, $userdata, $x);
                      }
                   }
                  break;
               case "/p":
               case "/poll":
                  $nextTime = $freqTime-$sleepTime;
                  break;
               default:
                  SendNote($hosts,$userdata,$s);
                  $nextTime = $freqTime-$sleepTime;
                  break;
            }
         }
         $cio->Write($PROMPT1."\n");
     }

     //---------------------------------
     // Check for next poll time
     //---------------------------------
     if ($nextTime >= $freqTime) {
         $nextTime  = 0;
         $rid = PollNotes($cio, $hosts, $userdata, $rid);
     }
     //---------------------------------
   }

   $cio->Write("\nExiting...\n");

?>

