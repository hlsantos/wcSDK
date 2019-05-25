<?php
//-----------------------------------------------------------------
// wcShareNet v1.0j (c) 2008 Santronics Software, Inc.
//-----------------------------------------------------------------

require_once("getparam.inc.php");
require_once("wcsharenet.class.php");

//---------------------------------------------------------
// ReadNotes()
// - Query new notes from channel since requestid (rid)
//---------------------------------------------------------

function ReadNotes($chn, $rid)
{
   $db = new CwcShareNet();
   if ($db->Open()) {
      return $db->ReadData($chn,$rid);
   }
   return FALSE;
}

//---------------------------------------------------------
// SaveNote()
// - Post a note into the channel
//---------------------------------------------------------

function SaveNote($chn, $txt, $uid, $uts)
{
   $db = new CwcShareNet();
   if ($db->Open()) {
      if ($db->SaveData($chn, $txt, $uid, $uts)) {
         return TRUE;
      }
   }
   return FALSE;
}

//---------------------------------------------------------
// MAIN
//---------------------------------------------------------

   $parm[cmd]  = getparamstr("cmd","poll");          // command
   $parm[txt]  = getparamstr("txt");                 // data
   $parm[rid]  = getparamint("rid");                 // request id
   $parm[uts]  = getparamstr("uts");                 // user timestamp
   $parm[uid]  = getparamstr("uid","anonymous");     // user id
   $parm[auth] = getparamstr("auth");                // auth request
   $parm[chn]  = getparamstr("chn","netnotes");      // channel name

   switch(strtolower($parm[cmd])) {
     case "poll";
        ReadNotes($parm[chn],$parm[rid]);
        break;
     case "note";
        SaveNote($parm[chn],$parm[txt],$parm[uid],$parm[uts]);
        break;
   }

   exit();
?>
