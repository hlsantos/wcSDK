<?php
//***********************************************************************
// (c) Copyright 1998-2008 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : wildcat.event.class.php
// Subsystem : PWE
// Date      : 03/19/08 01:51 pm
// Version   : v1.0f
// Author    : HLS/SSI
//
// Usage     :
//
//  $door = new CWildcatDoor();
//
//
// Revision History:
// Build    Date      Author  Comments
// -----    --------  ------  -------------------------------------------
//***********************************************************************


define(WCEVENT_TCHATMESSAGE_FORMAT,  "a27xa255xc");
define(WCEVENT_TPAGEMESSAGE_FORMAT,  "a27xa79xa79xa79xl");

class CWildcatEvent {

   private $SysopName = null;

   function BroadCast($from, $text)
   {
      if (!$from) {
         if (!$this->SysopName) {
            $mw = WcGetMakeWild();
            $this->SysopName = $mw["SysopName"];
         }
         $from = $this->SysopName;
      }
      return $this->Page(0,$from,$text);
   }

   private function PreparePageText($text)
   {
      if (is_string($text)) {
         $s = str_split($text,SIZE_SYSTEMPAGE_TEXT-1);
         $text = array_chunk($s,SIZE_SYSTEMPAGE_LINES-1);
         $text = $text[0];  // first chunk only
      }
      if (is_array($text)) {
         for ($i=0; $i<SIZE_SYSTEMPAGE_LINES; $i++) {
            $message[$i] = $text[$i];
         }
      }
      return $message;
   }

   function Page($destid, $from, $text, $invite = false)
   {
      // see TSystemPageInstantMessage
      $data = array();
      $data["From"]         = $from;
      $data["Text"]         = $this->PreparePageText($text);
      $data["InviteToChat"] = $invite;

      return wcWriteChannelPage($destid,SP_USER_PAGE,$data);
   }

   function PagePack($destid, $from, $text, $invite = false)
   {
      // see TSystemPageInstantMessage
      $data = array();
      $data["From"]         = $from;
      $data["Text"]         = $this->PreparePageText($text);
      $data["InviteToChat"] = $invite;

      $pack = pack(WCEVENT_TPAGEMESSAGE_FORMAT,
              $data["From"],
              $data["Text"][0],
              $data["Text"][1],
              $data["Text"][2],
              $data["InviteToChat"]
              );
      $bytes = str_split($pack);

      $cpage = wcOpenChannel("System.Page");
      return wcWriteChannel($cpage,$destid,SP_USER_PAGE,$bytes);
   }

   function Chat($destid, $from, $text, $whisper = false)
   {
      // see TChatMessage
      $data = array();
      $data["From"]     = $from;
      $data["Text"]     = $text;
      $data["Whisper"]  = $invite;
      return wcWriteChannelChat($destid,SP_USER_CHAT,$data);
   }

   function Write($channel, $destid, $userdata, $data, $datasize = null)
   {
      if ($datasize === null) $datasize = count($data);
      return wcWriteChannel($channel,$destid,$userdata,$data,$datasize);
   }

   function SendControlEvent($node, $event)
   {
      $ch = wcOpenChannel(sprintf("System.Control.%d", $node));
      if (!wcWriteChannel($ch, 0, $event, "", 0)) {
         printf("! Error %08X WriteChannel: %s\n",wcGetLastError(),$s);
      }
      wcCloseChannel($ch);
      return TRUE;
   }

   function DisconnectNode($node)
   {
      return $this->SendControlEvent($node,SC_DISCONNECT);
   }

}

?>
