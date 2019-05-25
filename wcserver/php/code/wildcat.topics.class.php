<?php
//***********************************************************************
// (c) Copyright 1998-2008 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : wildcat.topics.class.php
// Subsystem : PWE
// Date      : 03/19/08 01:51 pm
// Version   : v1.0f
// Author    : HLS/SSI
//
// Usage     :
//
//  $topics = new CWildcatMailTopics();
//
//
// Revision History:
// Build    Date      Author  Comments
// -----    --------  ------  -------------------------------------------
//***********************************************************************

require_once("wildcat.php");

define(WCAT_MAX_TOPICS,  25);
define(THREAD_PAGESIZE_MULTIPLIER, 20);

class CWildcatMailTopics {

    private $ReplyChain     = null;  // list as TMsgItem
    private $Topics         = null;  // list as TMsgTopic
    private $nTopics        = 0;
    private $nOrigTopics    = 0;
    private $nLostTopics    = 0;
    private $LastMsg        = null;  // TmsgHeader
    private $TopicsPerPage  = WCAT_MAX_TOPICS;

    public  $MaxMsgs        = 0;
    public  $MsgScanned     = 0;

    function __construct()
    {
       $this->MaxMsgs = WCAT_MAX_TOPICS * THREAD_PAGESIZE_MULTIPLIER;
    }

    public function TopicsPerPage($max = null)
    {
       if ($max === null) {
           return $this->TopicsPerPage;
       }
       $this->TopicsPerPage = $max;
       $this->MaxMsgs = $max * THREAD_PAGESIZE_MULTIPLIER;
       return $max;
    }

    public function Get($i = null)
    {
        if ($i === null) {
           return $this->Topics;
        }
        return $this->Topics[$i];
    }

    public function First()
    {
        return $this->Get(0);
    }

    public function Last()
    {
        return $this->Get($this->GetSize()-1);
    }

    public function IsMore()
    {
       return ($this->GetSize() == $this->TopicsPerPage())
           && wcGetPrevMessage(&$this->LastMsg);
    }

    public Function GetSize()
    {
       return count($this->Topics);
    }

    public Function LostTopicsCount()
    {
       return $this->nLostTopics;
    }

    public Function TopicsCount()
    {
       return count($this->Topics);
    }

    private Function ReplyChainGetCount()
    {
      return count($this->ReplyChain);
    }

    private function AddTopic($msg)
    {
       $mt = array(
              "Msg"          => $msg,
              "LastPostDate" => $msg["MsgTime"]
            );
       $this->Topics[] = $mt;
    }

    private function AddReply($row, $msg)
    {
      $mi = array(
            "Row"       => $row,
            "Id"        => $msg["Id"],
            "Reference" => $msg["Reference"],
            "Number"    => $msg["Number"],
            "Reserved"  => 0,
            "MsgTime"   => $msg["MsgTime"]
          );
      $this->ReplyChain[] = $mi;
    }

    private function CheckReplyChain($id, $bIsLast)
    {
       $total = $this->ReplyChainGetCount();
       for ($i = 0; $i < $total; $i++) {
         $mi = $this->ReplyChain[$i];
         if ($id == $mi["Id"]) {
            $bIsLast = false;
            if ($i == ($total-1)) {
               $bIsLast = true;
            } else {
               $bIsLast = ($mi["Row"] < $this->ReplyChain[$i+i]["Row"]);
            }
            return true;
         }
       }
       return false;
    }

    public function GetTopicReplyCount($mt)
    {
       $ThreadMsgs  = array();
       $nReplies    = 0;
       $row         = 0;
       $k           = 0;

       while(1) {

         //---------------------------------------------
         // get row of replies
         //---------------------------------------------

         $cl = array();
         while ($k < $this->ReplyChainGetCount()) {
            if ($row != $this->ReplyChain[$k]["Row"]) break;
            $cl[] = $this->ReplyChain[$k];
            $k++;
         }
         $row++;

         //---------------------------------------------
         // Got row of replies
         // - check if last entry is topic id
         //    - add to thread msg list (no dupes)
         //    - compare dates
         //    - get total post
         //---------------------------------------------

         $n  = count($cl);
         if ($n == 0) break;

         if ($mt["Msg"]["Id"] == $cl[$n-1]["Id"]) {
           for ($r = 0; $r < $n; $r++) {
              $mi = $cl[$r];
              $t1 = FileTimeToUnixTime($mt["LastPostDate"]);
              $t2 = FileTimeToUnixTime($mi["MsgTime"]);
              if ($t1 < $t2) $mt["LastPostDate"] = $mi["MsgTime"];
              $dupe = false;
              for($i = 0; $i < Count($ThreadMsgs); $i++) {
                 if ($mi["Id"] == $ThreadMsgs[$i]) {
                   $dupe = true;
                   break;
                 }
              }
              if (!$dupe) $ThreadMsgs[] = $mi["Id"];
           }
           $nReplies = count($ThreadMsgs)-1;
         }
       }
       $mt["TotalReplies"] = $nReplies;
       return $nReplies;
    }

    private function Initialize()
    {
       $this->ReplyChain     = null;  // list of TMsgItem
       $this->Topics         = null;  // list of TMsgTopic
       $this->nTopics        = 0;
       $this->nOrigTopics    = 0;
       $this->nLostTopics    = 0;
       $this->LastMsg        = null;  // TmsgHeader
    }

    public Function GetPageTopics($cnum, $pmid, $nmid, $dir = 0)
    {
       //--------------------------------------------------
       // Get message list, skip replies.
       //
       // Reverse traveral, starting at the last message
       // by clearing the TMsgHeader array and setting
       // the conference # only. Technically, the status
       // should be set to zero. However, the function
       // will see the lack of a status as a zero value,
       // hence allowing the prev call to start with the
       // last message.
       //--------------------------------------------------

       $this->Initialize();

       $msg = array("Conference" => $cnum);

       if ($dir > 0) {
          $msg["Status"] = $nmid;
          if (!wcGetPrevMessage(&$msg)) {
             printf("! Warning No messages\n");
          }
       }

       if ($dir < 0) {
          if (!wcGetMessageById($cnum,$pmid,&$msg)) {
             printf("! Warning Prev ID not found: %d\n",$pmid);
          }
       }

       if ($dir == 0) {
          if (!wcGetPrevMessage(&$msg)) {
             printf("! Warning No messages (dir=0)\n");
          }
       }

       $row = 0;
       do {

          $this->MsgScanned++;
          if ($this->MsgScanned >= $this->MaxMsgs) break;
          if ($this->nTopics >= $this->TopicsPerPage) break;

          $ref  = $msg["Reference"];
          $id   = $msg["Id"];
          $num  = $msg["Number"];
          $rc   = $msg["ReplyCount"];

          if ($id == 0) continue;

          if ($ref == 0) {
             $this->nOrigTopics++;
             $this->AddTopic($msg);
             $this->AddReply($row, $msg);
          } else {
    	     $bIsLast = false;
    	     if (false && $this->CheckReplyChain($id,&$bIsLast)) {
    	         if ($bIsLast) {
                    $this->AddTopic($msg);
    	            $this->nLostTopics++;
    	         }
    	     } else {
         	   $this->AddReply($row, $msg);
    		   $omsg = $msg;
    		   $ref  = null; // Tmsgheader
    		   $nReplies = 0;
      	       while ($msg["Reference"] &&
  	                  wcGetMessageById($msg["Conference"],
    	                               $msg["Reference"],&$ref)) {
                  $msg = $ref;
                  if ($msg["Id"] == $msg["Reference"]) break;
    	          $this->AddReply($row, $ref);
    		      $nReplies++;
      	       }
    		   $msg = $omsg;
    		   if ($nReplies == 0) {
            	  $this->AddReply($row, $msg);
                  $this->AddTopic($msg);
    		      $this->nLostTopics++;
    		   }
             }
          }
          $row++;

          $this->nTopics = $this->nOrigTopics + $this->nLostTopics;

       } while (wcGetPrevMessage(&$msg));

       $this->LastMsg = $msg;
    }

}

?>
