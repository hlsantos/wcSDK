<title> wcMailTopics </title>
<style>
body {
   margin-left: 2%;
   margin-right: 2%;
   color: blue;
   font-size: 10pt;
}
h3 {
   background: Cyan;
   border: 1px solid black;
   color: Blue;
   padding: 4pt;
}
h4 {
   background: yellow;
   border: 1px solid blue;
   padding: 4pt;
}
a {
	text-decoration: none;
}
a:hover {
   color:white;
   background-color: blue;
}
.msglist {
   color:Blue;
   background-color: oldlace;
}
.msgrow{
}

.msgsubj {
   color:Blue;
}
.msgfrom {
   color:green;
   font-weight: bold;
}
.msgdate {
   color:purple;
}
.msgrep {
   color:blue;
   font-weight: bold;
}
table {
   border-collapse: collapse;
   font-size: 12pt;
}
th { background-color: silver;}
th { padding: 2pt; }
td { padding: 2pt; }

#pageButtons form {
   display:inline;
}

</style>

<?php
   require_once("getparam.inc.php");
   require_once("wildcat.php");
   uses_wildcat("filetime.inc");
   uses_wildcat("topics.class");
   uses_wildcat("mail.class");

   //-------------------------------------------------
   // Main
   //--------------------------------------------------

   $wcat = new CWildcat();

   //--------------------------------------------------
   // Get variables from URL arguments
   //--------------------------------------------------
   // cn  => conference #, 0
   // cg  => conference group, 0
   // cf  => conference flags, 0
   // pg  => page number, 0
   //--------------------------------------------------

   $cnum = GetParamInt("cn",$wcat->User["Conference"]);
   $cgrp = GetParamInt("cg",0);
   $cflg = GetParamInt("cf",0);
   $page = GetParamInt("pg",1);
   $nmid = GetParamInt("ni",0);
   $dir  = GetParamInt("dir",0);
   $pmid = $_REQUEST["pages"][$page];


   //--------------------------------------------------
   // Create Conference Select pull down list
   //--------------------------------------------------

   $confs = new CWildcatMailAreas($cgrp,$cflg);

   print "<form method='get' action=''>\n";
   print "<select name='cn'>\n";
   foreach($confs->Areas as $cd) {
     $cn = $cd["Number"];
     $selected = "";
     if ($cnum == $cn) $selected = "selected";
     printf("<option value=\"%d\" %s>%d - %s</option>\n",
          $cn,
          $selected,
          $cn,
          $cd["Name"] . " (" . wcGetTotalMessagesInConference($cn). ")"
          );
   }
   print "</select>\n";
   print "<input type='submit' value='Switch Forum' />\n";
   print "</form>\n";

   //--------------------------------------------------
   // Get current conference info
   //--------------------------------------------------

   if (!wcGetConfDesc($cnum,&$cd)) {
     printf("! Error %08X: wcGetConfDesc()\n",wcGetLastError());
     exit();
   }

   //--------------------------------------------------
   // Display Topics (non-replies)
   //--------------------------------------------------

   printf("<h3>Topics - Conference: %s</h3>\n",$cd["Name"]);

   $MsgTopics = new CWildcatMailTopics();
   $MsgTopics->GetPageTopics($cnum, $pmid, $nmid, $dir);

   print "<pre>";
   printf("Total Scanned: %d\n",$MsgTopics->MsgScanned);
   printf("Page: %d Total Messages: %d  Topics: %d  Purged: %d\n",
               $page,
               wcGetTotalMessagesInConference($cnum),
               $MsgTopics->TopicsCount(),
               $MsgTopics->LostTopicsCount());
   print "</pre>";

   echo "<hr>";

   print "<div class='msglist'>";
   print "<pre>";
   if ($MsgTopics->GetSize()) {
      foreach ($MsgTopics->Get() as $idx => $mt) {

         if ($idx >= WCAT_MAX_TOPICS) break;

         $msg = $mt["Msg"];
         $nReplies = $MsgTopics->GetTopicReplyCount(&$mt);

         printf("<a href='ShowMailTopic.php?mid=%d.%d'>",$msg["Conference"],$msg["Id"]);
         printf("%-3d |",$idx+1);

         //printf("%-8d |",$msg["Id"]);
         printf("%-5d |",$msg["Number"]);
         $dt = $msg["MsgTime"];  //$dt = $mt["LastPostDate"];
         printf(" <span class='msgdate'>%s</span> |",DateTimeString($dt));
         if ($nReplies == 0) $nReplies = "  -";
         printf("%3s | ",$nReplies);
         printf("<span class='msgfrom'>%-20s</span>",$msg["From"]["Name"]);
         printf(" %s",$mt["Msg"]["Subject"]);
         printf("</a>");
         printf("\n");
      }
   }
   print "</pre>";
   print "</div>";
   echo "<hr>\n";

   //---------------------------------------------
   // Create Navigation Bar
   //---------------------------------------------

   $more         = $MsgTopics->IsMore();
   $fmsg         = $MsgTopics->First();
   $lmsg         = $MsgTopics->Last();
   $pages[$page] = $fmsg["Msg"]["Id"];
   $nmid         = $lmsg["Msg"]["Id"];

   $npage = $page;
   if ($more) $npage = $page + 1;
   $ppage = $page - 1;
   if ($ppage <= 0) $ppage = 1;

   print "<div id='pageButtons'>";

   // First Page Button

   print "<form method='get' action=''>\n";
   print "<input type='hidden' name='cn' value='$cnum'/>\n";
   print "<input type='submit' value='First Page'/>\n";
   print "</form>\n";

   // Prev Page Button

   print "<form method='post' action=''>\n";
   print "<input type='hidden' name='cn' value='$cnum'/>\n";
   print "<input type='hidden' name='pg' value='$ppage'/>\n";
   print "<input type='hidden' name='ni' value='$nmid'/>\n";
   print "<input type='hidden' name='dir' value='-1'/>\n";
   foreach($pages as $p => $id) {
       print "<input type='hidden' name='pages[$p]' value='$id'/>\n";
   }
   $disabled = "disabled";
   if ($page > 1) $disabled = "";
   print "<input type='submit' $disabled value='Prev Page'/>\n";
   print "</form>\n";

   // Next Page Button

   print "<form method='post' action=''>\n";
   print "<input type='hidden' name='cn' value='$cnum'/>\n";
   print "<input type='hidden' name='pg' value='$npage'/>\n";
   print "<input type='hidden' name='ni' value='$nmid'/>\n";
   print "<input type='hidden' name='dir' value='1'/>\n";
   foreach($pages as $p => $id) {
       print "<input type='hidden' name='pages[$p]' value='$id'/>\n";
   }
   $disabled = "disabled";
   if ($more) $disabled = "";
   print "<input type='submit' $disabled value='Next Page'/>\n";
   print "</form>\n";

   print "</div>";

   echo "<hr>";

/*
   print "<pre>";
   print "page: $page  prev: $ppage  next: $npage\n";
   print_r($pages);
   print "</pre>";
*/

?>

