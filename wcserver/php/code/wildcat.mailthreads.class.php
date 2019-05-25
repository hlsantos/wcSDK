<?php
//***********************************************************************
// (c) Copyright 1998-2008 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : wildcat.mailthreads.class.php
// Subsystem : PWE
// Date      : 03/19/08 01:51 pm
// Version   : v1.0f
// Author    : HLS/SSI
//
// Usage     :
//
//  $threads = new CWildcatMsgThread();
//
//
// Revision History:
// Build    Date      Author  Comments
// -----    --------  ------  -------------------------------------------
//***********************************************************************

define(THREAD_PAGESIZE_MULTIPLIER, 20);

class CWildcatMsgThread {

    public $TotalScanned    = 0;
    public $PageSize        = 0;
    public $Conference      = 0;
    public $FirstMsgId      = 0;  // For new zoomer to go directly to start topic
    public $NextLowId       = 0;
    public $FirstOffset     = 0;  // Old zoomer from top to start topic
    public $nTotalNext      = 0;
    public $nTotalPrev      = 0;
    public $nTotalSearch    = 0;

    public $EnableLostMail  = false;  // good for counting, not for mail dumps

//-------------
// private
//-------------

    private $HighMsg        = 0;
    private $LowMsg         = 0;
    public  $messages       = array(); // index list of TMsgHeader
    private $mindex         = array(); // index list of msgid
    public  $Threads        = array(); // index list of replies
    private $ThreadHeadList = array(); // msgid list of topics
    private $findex         = array(); // CArray<int, int>          //flat index
    private $fmindex        = array(); // CMap<int, int, int, int>; //flat index

    public  $ThreadHeadRef  = array();

    function __construct()
    {
        $this->TotalScanned  =   0;
        $this->PageSize      =   100;
        $this->Conference    =   0;
        $this->FirstMsgId    =   0;
        $this->HighMsg       =   0;
        $this->LowMsg        =   0;
        $this->NextLowId     =   0;
        $this->nTotalNext    =   0;
        $this->nTotalPrev    =   0;
        $this->nTotalSearch  =   0;
    }

//-------------
// public
//-------------

    function GetThread($id)
    {
       $nTotal = $this->GetTotalThreads();
       if ($nTotal == 0) return 0;
       if (($id < 0) || ($id >= $nTotal)) return 0;
       return $this->ThreadHeadList[$id];
    }

    function GetTotalThreads()
    {
       return count($this->ThreadHeadList);
    }

    function Msg($id)
    {
      	return $this->messages[$id];
    }

    function GetMsg($id, $msg)
    {
      	$msg = $this->messages[$id];
       	return $msg != null;
    }

    function GetMsgI($id, $msg)
    {
    	$msg = $this->messages[$this->mindex[$id]];
    	return $msg != null;
    }

    function GetChild($id, $child, $msg)
    {
        $msg = array();
        $t = $this->threads[$id];
        if ($t) {
            return $this->GetMsgI($t[$child],&$msg);
        }
        return false;
    }

    function GetChildId($id, $child)
    {
    	$msg = array();
        $t = $this->threads[$id];
        if ($t && $this->GetMsgI($t[$child],&$msg)) {
        	return $msg["Id"];
        }
        return 0;
    }

    function GetNumChildren($fmsg)
    {
    	if ($this->threads[$fmsg]) {
    	    return count($this->threads[$fmsg]);
        }
    	return 0;
    }

    Function GetOriginal($msg)
    {
	   $ref  = null; // Tmsgheader
       while ($msg["Reference"] &&
              wcGetMessageById($msg["Conference"],
                             $msg["Reference"],&$ref)) {
             $msg = $ref;
             if ($msg["Id"] == $msg["Reference"]) break;
 	   }
       return $msg;
    }

    function Load()
    {
        $this->TotalScanned = 0;

        //
        // find the effective low and high
        //

    	$msg = array();
        $msg["Conference"] = $this->Conference;
        if (!$this->GetNextMessage(&$msg)) {
            printf("Warning: error: %08X\n",wcGetLastError());
            return false;
        }
        $this->LowMsg = $msg["Number"];
        $lowid  = $msg["Id"];

        $msg = array();
        $msg["Conference"] = $this->Conference;
        if (!$this->GetPrevMessage(&$msg)) {
            return false;
        }
        $this->HighMsg = $msg["Number"];
        $highid  = $msg["Id"];

        //
        // This logic starts at the highest message and works backwards
        //

        if ($this->FirstMsgId > 0) {
            if (!$this->SearchMessageById($this->Conference,$this->FirstMsgId,&$msg)) {
                return false;
            }
        } else {
            if ($this->FirstOffset > 0) {
                for ($x=0; $x<$this->FirstOffset;$x++) {
                    if (!$this->GetPrevMessage(&$msg)) {
                        return false;
                    }
                }
            }
        }

        //
        // start filling in the messages array, starting from the
        // highest found above
        //

        $i = 0;
    	do {
            $this->TotalScanned++;
    		$this->messages[$msg["Id"]]  = $msg;
    		$this->mindex[$i]            = $msg["Id"];
    	} while(++$i<$this->PageSize && $this->GetPrevMessage(&$msg));

        //print_r($this->messages);

        $this->NextLowId = 0;
        if ($this->GetPrevMessage(&$msg)) $this->NextLowId = $msg["Id"];

    	for ($i=0; $i< $this->TotalScanned; $i++) {
            $mid = $this->mindex[$i];
    		$ref = $this->messages[$mid]["Reference"];
            $msg = $this->messages[$ref];
    		if(($ref == 0) || ($msg == null) ){
    			// this is head of thread
    			// add to thread list
      			$this->ThreadHeadList[] = $mid;

                if ($msg == null && $ref != 0) {
                    // lost originals
        			$this->ThreadHeadRef[$ref][] = $mid;
                } else {
        			$this->ThreadHeadRef[$mid] = $mid;
               }

    		} else {
       			// add index to threads array
    			$this->threads[$ref][] = $i;
    		}
    	}

        //print_r($this->threads);
        //print "Total ThreadHeadRef: " . count($this->ThreadHeadRef)."\n";
        //print_r($this->ThreadHeadRef);

    	$thrn = count($this->ThreadHeadList);

        // create a 'flat index'
        {
            $fmsg=0;
            $fi=0;
            for ($i=0;$i<$thrn;$i++) {
                $id = $this->ThreadHeadList[$i];
                $this->fmindex[$id] = $fi;
                $this->findex[$fi]  = $id;
                $fi = $this->figetchildid($id, 0, $fi+1);
            }
        }
        return true;
    }

//------------------
// private:
//------------------

    //---------------------------------------------------------------------
    // used in creating flat index of thread structure
    //---------------------------------------------------------------------

    private function figetchildid($id, $level, $fi)
    {
    	$x      = 0;
    	$fmsg   = 0;

        for ($x=0; $x<$this->GetNumChildren($id); $x++) {
            $fmsg = $this->getchildid($id,$x);
            $this->fmindex[$fmsg] = $fi;
            $this->findex[$fi]    = $fmsg;

            $fi = $this->figetchildid($fmsg, 0, $fi+1);
        }
        return $fi;
    }

    private function ClearThreadHeadList()
    {
      for ($i = 0; $i < count($ThreadHeadList); $i++) {
         $this->ThreadHeadList[$i] = 0;
      }
    }

    private function GetNextMessage($msg)
    {
        $this->nTotalNext++;
        return wcGetNextMessage(&$msg);
    }
    private function GetPrevMessage($msg)
    {
        $this->nTotalPrev++;
        return wcGetPrevMessage(&$msg);
    }

    private function SearchMessageById($conf, $msgid, $msg)
    {
        $this->nTotalSearch++;
        return wcSearchMessageById($conf, $msgid, &$msg);
    }
}

//---------------------------------------------------------------
// Exposed Functions
//----------------------------------------------------------------

function ConfThreadCreate
            (
             $conf,
             $PageSize,
             $firstoffset = 0,
             $firstmid    = 0
             )

{
	$msgobj  = new CWildcatMsgThread();
	$msgobj->Conference  = $conf;
	$msgobj->PageSize    = $PageSize;
	$msgobj->FirstMsgId  = $firstmid;
	$msgobj->FirstOffset = $firstoffset;
    if ($msgobj->FirstOffset < 0) $msgobj->FirstOffset = 0;
    if (!$msgobj->Load()) $msgobj = null;
	return $msgobj;
}

function ConfThreadDelete($msgobj)
{
    $msgobj = null;
    return $msgobj;
}

function ConfThreadGetTotalThreads($msgobj)
{
    if (!$msgobj) return 0;
    $nTotal = 0;
    for ($i = 0; $i < $msgobj->GetTotalThreads(); $i++) {
        if ($msgobj->GetThread($i) > 0) {
           $nTotal++;
        }
    }
	return $nTotal;
}

function ConfThreadGetThread($msgobj, $i)
{
    if (!$msgobj) return 0;

    if ($msgobj->EnableLostMail) {
       $s = array_slice($msgobj->ThreadHeadRef, $i, 1);
       if (is_array($s[0])) return $s[0][0];
       return $s[0];
    }
    return $msgobj->GetThread($i);

}

function ConfThreadGetMsgId($msgobj, $fmsg)
{
    if (!$msgobj) return 0;

    $msg = null;
    if ($msgobj->getmsg($fmsg,&$msg)) {
        return $msg["Id"];
    }
    return 0;
}

function ConfThreadGetMsgChild($msgobj, $id, $i)
{
    if (!$msgobj) return 0;

    if ($i < $msgobj->GetNumChildren($id)) {
        return $msgobj->GetChildId($id, $i);
    }
	return 0;
}

function ConfThreadGetNext($msgobj, $id)
{
    if (!$msgobj) return 0;

    $i = $msgobj->fmindex[$id]+1;
    if ($i < count($msgobj->findex)) {
        if ($msgobj->findex[$i]>0) {
           return $msgobj->findex[$i];
        }
    }
    return $msgobj->findex[0];
}

function ConfThreadGetPrev($msgobj,$id)
{
    if (!$msgobj) return 0;

    $i = $msgobj->fmindex[$id]-1;
    if($i >= 0) {
        if ($msgobj->findex[$i]>0) {
           return $msgobj->findex[$i];
        }
    }
    return $msgobj->findex[$msgobj->TotalScanned-1];
}

function ConfThreadGetNextLowId($msgobj)
{
    if (!$msgobj) return 0;
    return $msgobj->NextLowId;
}

function ConfThreadGetTotalChildren($msgobj, $msgid)
{
    if (!$msgobj) return 0;

    $total = 0;
    $i     = 0;
    $chid  = ConfThreadGetMsgChild($msgobj,$msgid,$i);
    while ($chid > 0) {

       if ($msgobj->EnableLostMail) {
           //------------------------------
           // This counts the lost references
           $msg = $msgobj->messages[$msgid];
           if ($msg) {
              $lt = $msgobj->ThreadHeadRef[$msg["Reference"]];
              if (is_array($lt)) $total += count($lt);
           }
           //-------------------------------
       }

       $total++;
       $total += ConfThreadGetTotalChildren($msgobj,$chid);
       $i++;
       $chid = ConfThreadGetMsgChild($msgobj,$msgid,$i);
    }
    return $total;
}

function ConfThreadGetLastPost($msgobj, $msgid)
{
    if (!$msgobj) return 0;

    $lastmsg = null;
    $i       = 0;
    $chid    = ConfThreadGetMsgChild($msgobj,$msgid,$i);

    while ($chid > 0) {
       $lastmsg = $msgobj->messages[$chid];
       $newlast = ConfThreadGetLastPost($msgobj,$chid);
       if ($newlast != null) $lastmsg = $newlast;
       $i++;
       $chid = ConfThreadGetMsgChild($msgobj,$msgid,$i);
    }
    return $lastmsg;
}

?>
