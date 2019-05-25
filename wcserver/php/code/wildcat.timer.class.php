<?php
//***********************************************************************
// (c) Copyright 1998-2008 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : wildcat.timer.class.php
// Subsystem : PWE
// Date      : 04/13/08 12:05 am
// Version   : v1.0f
// Author    : HLS/SSI
// About     : Class for setting up callback events scheduler.
//
// Revision History:
// Build    Date      Author  Comments
// -----    --------  ------  -------------------------------------------
//
//***********************************************************************

//-------------------------------------------------------------
// class CEventTimer
//-------------------------------------------------------------
//

class CEventTimer {

   private $t1             = 0;
   private $t0             = 0;
   public $flist           = array();
   private $schedulerName  = "_scheduler";

   function __construct()
   {
      $this->t0 = $this->GetTime();
      $this->t1 = $this->t0;
      $this->RegisterScheduler();
   }

   function RegisterScheduler()
   {
      register_tick_function(array($this, $this->schedulerName));
      declare(ticks = 1);
   }

   function UnRegisterScheduler()
   {
      unregister_tick_function(array($this->schedulerName));
   }

   function poke()
   {
      return true;
   }

   function _scheduler()
   {
      $t2    = $this->GetTime();
      $etime = $t2-$this->t0;
      $this->t1 = $t2;
      if (count($this->flist)) {
         foreach($this->flist as $func => $attr) {
            if (!$attr[active] && ($etime >= $attr[next])) {
               $this->flist[$func][next] = $etime+$attr[freq];
               $this->flist[$func][active] = 1;
               call_user_func($func);
               $this->flist[$func][active] = 0;
            }
         }
      }
   }

   function GetTime()
   {
      list($usec,$sec) = explode(" ",microtime());
      return ((float)substr($usec,2,3) + (float)$sec*1000);
   }

   function elapsed()
   {
      return $this->GetTime() - $this->t0;
   }

   function addEvent($func, $freq)
   {
      $next = $this->elapsed()+$freq;
      $this->flist[$func] = array(
               freq => $freq,
               next => $next,
               active => 0
               );
   }

   function clearEvent($func)
   {
      unset($this->flist[$func]);
   }

   function stopTimer()
   {
      $this->UnRegisterScheduler();
   }

   function startTimer()
   {
      $this->stopTimer();
      if (count($this->flist)) {
         $etime = $this->elapsed();
         foreach($this->flist as $func => $attr) {
            $this->flist[$func][next] = $etime+$attr[freq];
         }
      }
      $this->RegisterScheduler();
   }

}


?>
