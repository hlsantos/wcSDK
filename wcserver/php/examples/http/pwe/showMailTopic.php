<?php ob_start(); ?>
<html>
<head>
<title>wcTopics</title>
<style>
body {
   margin-left: 10%;
   margin-right: 10%;
}
h3 {
   background: blue;
   border: 1px solid black;
   color: cyan;
   padding: 4pt;
}
h4 {
   background: yellow;
   border: 1px solid blue;
   padding: 4pt;
}
ul {
   background: silver;
   border: 1px solid blue;
   width: 30%;
}
ul a {
	text-decoration: none;
}
ul a:hover {
   color:blue;
   background-color: white;
}

.subhdr {
   background: blue;
   border: 1px solid black;
   color: cyan;
}
.mainhdr {
   background: Green;
   border: 1px solid black;
   color: white;
   font-size: 10pt;
}

.mainmsg {
   background-color: lightyellow;
   border: 1px solid black;
   padding-top: 5pt;
   padding-left: 10pt;
   padding-right: 10pt;
}

.submsg {
   border: 1px solid black;
   padding-top: 5pt;
   padding-left: 10pt;
   padding-right: 10pt;
}

.msgtree {
   background: yellow;
   border: 1px solid black;
   color: black;
}
.msgtreeitem {
   background: yellow;
   color: black;
}

.blank {
   background: white;
   color: silver;
   font-size: 10pt;
   border: 1px solid black;
   /*visibility: hidden;*/
}

.msgref {
   background: orange;
   border: 1px solid black;
   color: black;
   font-size: 10pt;
}

.msguser {
   background: lightyellow;
   border: 1px solid black;
   color: black;
   font-size: 10pt;
}

</style>
</head>
<body>

<?PHP
   require_once("wildcat.php");
   require_once("strlib.inc.php");

//-----------------------------------------------------

function wcMsgFileName($msg)
{
  return sprintf("wc:\\conf(%d)\\message(%d)",
           $msg["Conference"],
           $msg["Id"]);
}

class CWildcatMailReplies {

   public  $EnableTree  = false;
   public  $ReplyList   = null;
   public  $replies     = 0;

   private $TopicFrom   = null;
   private $Messages    = null;
   private $Topic       = null;

   function __construct($msg = null)
   {
      if ($msg) {
         $this->Topic     = $msg;
         $this->TopicFrom = $msg["From"];
         $this->MakeMessageList($msg);
      }
   }

   function MessageCount()
   {
      return count($this->Messages);
   }

   function ReplyCount()
   {
      return count($this->ReplyList);
   }

   function MakeMessageList($msg)
   {
      while (wcGetNextMessage(&$msg)) {
         $this->Messages[] = $msg;
      }
   }

   function GetReplies($level, $i, $msg)
   {
      $rmsg = $msg;
      while ($rmsg=$this->Messages[$i++]) {
        if ($msg["Id"] == $rmsg["Reference"]) {
           $this->ReplyList[] = $rmsg;
           if ($this->EnableTree) {
              $refurl = "";
              if ($rmsg["Reference"]) {
                $cc = "msgref";
                if ($this->TopicFrom["Id"] == $rmsg["From"]["Id"]) {
                   $cc = "msguser";
                }
                $rnum = $rmsg["Number"];
                $refurl = sprintf("<span class='%s'><a href='ShowMailTopic.php?mid=%d.%d'>%d</a></span>",
                                    $cc,
                                    $rmsg["Conference"],
                                    $rmsg["Id"],
                                    $rnum);
              }
              $this->replies++;
              print "<div class='msgtreeitem'>";
              printf("%3d => %s%s\n",$this->replies, str_repeat("- ",$level),$refurl);
              print "</div>";
           }
           $this->GetReplies($level+1, $i, $rmsg);
        }
      }
   }

   function ShowReplies()
   {
      if ($this->ReplyCount() == 0) return;

      foreach($this->ReplyList as $idx => $rmsg) {
        $refurl = "";
        if ($rmsg["Reference"]) {
          $rnum = wcGetMsgNumberFromId($rmsg["Conference"], $rmsg["Reference"]);
          $refurl = sprintf("<span class='msgref'><a href='ShowMailTopic.php?mid=%d.%d'>Reference: %d</a></span>",
                              $rmsg["Conference"],
                              $rmsg["Reference"],
                              $rnum);

        }
        print "<div class='subhdr'>";
        printf("<b>Reply #%d</b>\n",$idx+1);
        printf("%4d - %s (%s %s) %s\n",
               $rmsg["Number"],
               $rmsg["From"]["Name"],
               DateString($rmsg["MsgTime"]),
               TimeString($rmsg["MsgTime"]),
               $refurl
               );
        print "</div>";
        print "<p class='submsg'>";
        $wcfn = wcMsgFileName($rmsg);
        print strip_tags(wcGetText($wcfn));
        print "</p>";
      }
   }

}
//-------------------------------------------------------
// Main
//-------------------------------------------------------

   $wcat = new CWildcat();

   $user = $wcat->User;
   $uid  = $user[Info][Id];
   $cid  = wcGetConnectionId();
   $node = wcGetNode();

   list($cnum,$mid) = explode(".",$_GET["mid"]);

   if ($node == 0 || $mid == 0) {
     $obuf = ob_get_contents();
     header("Location: wcMailTopics.php");
     exit();
   }

   if (!wcGetConfDesc($cnum,&$cd)) {
     printf("! Error %08X: wcGetConfDesc()\n",wcGetLastError());
     exit();
   }

   printf("<h3>Forum: %s</h3>\n",$cd["Name"]);

   echo "<pre>";

   $msg["Conference"] = $cnum;
   $msg["Id"]         = $mid;
   if (wcGetMessageById($cnum,$mid, &$msg)) {
      $refurl = "";
      if ($msg["Reference"]) {
        if (wcGetMessageById($cnum,$msg["Reference"], &$lost)) {
            $refurl = sprintf("<span class='msgref'><a href='ShowMailTopic.php?mid=%d.%d'>Reference: %d</a></span>",
                            $msg["Conference"],
                            $msg["Reference"],
                            wcGetMsgNumberFromId($msg["Conference"],$msg["Reference"])
                            );
        } else {
            $refurl = sprintf("<span class='msgref'>Lost Reference: %d</a></span>",
                            wcGetMsgNumberFromId($msg["Conference"],$msg["Reference"])
                            );
        }
      }

      printf("<center><h2>%s</H2></center>",$msg["Subject"]);
      print "<div class='mainhdr'>";
         printf("%4d - %s (%s %s) %s\n",
                $msg["Number"],
                $msg["From"]["Name"],
                DateString($msg["MsgTime"]),
                TimeString($msg["MsgTime"]),
                $refurl
                );
      print "</div>";
      print "<p class='mainmsg'>";
      $wcfn = wcMsgFileName($msg);
      print strip_tags(wcGetText($wcfn));
      print "</p>";
   }

   $r = new CWildcatMailReplies($msg);

   $r->EnableTree = true;

   if ($r->EnableTree) print "<div class='msgtree'>";
   $r->GetReplies(0,0,$msg);
   if ($r->EnableTree) print "</div>";

   print "<hr>";
   printf("Total Responses: %d\n",$r->ReplyCount());
   print "<hr>";

   $r->ShowReplies();

   print "<hr>";
   echo "</pre>";

?>

</body>
</html>



