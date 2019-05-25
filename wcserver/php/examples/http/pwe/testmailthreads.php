<style>
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
table {
    border-collapse: collapse;
}
td {
    padding-left: 2pt;
    padding-right: 2pt;
}
th {
    padding-left: 2pt;
    padding-right: 2pt;
    background-color: Silver;
}
.tblTopics {
    /*margin-left: 10pt;*/
}
a {
	text-decoration: none;
}
a:hover {
   color:white;
   background-color: blue;
}
</style>

<?php

   require_once("getparam.inc.php");
   require_once("wildcat.php");
   uses_wildcat("filetime.inc");
   uses_wildcat("mail.class");
   uses_wildcat("mailthreads.class");

//---------------------------------------------------------
// MAIN
//---------------------------------------------------------

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

   print "<pre>";

   $PageSize    = 100;
   $TotalMsgs   = $PageSize*THREAD_PAGESIZE_MULTIPLIER;

   $mobj = ConfThreadCreate($cnum,$TotalMsgs);

   if (!$mobj) {
      print "Object Creation Error\n";
      exit();
   }

   printf("<h3>Topics - Conference: %s</h3>",$cd["Name"]);

   printf("* Total Messages: %d  Scanned: %d  Topics: %d\n",
                  count($mobj->messages),
                  $mobj->TotalScanned,
                  $mobj->GetTotalThreads());
   print "<hr>";

   $USE_TABLE = true;

   if ($USE_TABLE) {
      print "<table border='1' class='tblTopics'>";
      print "<tr>\n";
      print "<th>#</th>\n";
      print "<th>Topics by Author</th>\n";
      print "<th>Last Poster</th>\n";
      print "<th align='right'>Replies</th>\n";
      print "<th align='right'>Read</th>\n";
      print "</tr>\n";
   }

   $threadIndex = 0;
   $msgid  = 0;
   $n      = 0;
   while ($msgid = ConfThreadGetThread($mobj,$threadIndex++)) {
     if (wcGetMessageById($cnum,$msgid,&$msg)) {
        $n++;
        //if ($n > 25) break;

        $nChilds  = ConfThreadGetTotalChildren($mobj, $msgid);
        if (!$nChilds) $nChilds = "";
        $lpmsg    = ConfThreadGetLastPost($mobj, $msgid);
        if ($lpmsg == null) $lpmsg = $msg;

        $refurl = "<span class='msgref'>";
        $refurl .= sprintf("<a href='ShowMailTopic.php?mid=%d.%d'>%3s</a>",
                            $msg["Conference"],
                            $msg["Id"],
                            $n);
        $refurl .= "</span>";

        if($USE_TABLE)
        {
            print "<tr valign=top>\n";
            print "<td>$refurl</td>";
            print "<td>";
            print $msg["Subject"] . "<br>by " . $msg["From"]["Name"];
            print "</td>\n";

            print "<td>";
            print  $lpmsg["From"]["Name"] . "<br>";
            print  DateTimeString($lpmsg["MsgTime"]);
            print "</td>\n";

            if (!$nChilds) $nChilds = "&nbsp;";
            print "<td align='right'>$nChilds</td>";
            print "<td align='right'>".$msg["ReadCount"]."</td>";
            print "</tr>\n";
        }
        else
        {
            //printf("%s | %5d | %10d | %10d | %4d | %-20s | %s\n",
            printf("%s | %5d | %3s | %s | %-20s | %s\n",
                      $refurl,
                      $msg["Number"],
                      //$msg["Id"],
                      //$msg["Reference"],
                      $nChilds,
                      DateTimeString($msg["MsgTime"]),
                      $msg["From"]["Name"],
                      $msg["Subject"]);
        }
     } else {
        print "MISSING! $msgid\n";
     }
   }

   if($USE_TABLE) print "</table>";

   print "<hr>";

   ConfThreadDelete(pObj);

   print "</pre>";


?>
