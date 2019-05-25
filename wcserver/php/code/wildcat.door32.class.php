<?php
//***********************************************************************
// (c) Copyright 1998-2008 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : wildcat.door32.class.php
// Subsystem : PWE
// Date      : 03/19/08 01:51 pm
// Version   : v1.0f
// Author    : HLS/SSI
//
// Usage:
//
// This class can be used for both DOOR32 and local console
// applications.
//
// For DOOR32 usage only:
//
//  $cio  = new CWildcatDoor();
//
// For CRT32 usage only:
//
//  $cio  = new CWildcatLocal();
//
// For either DOO32/CRT32 usage:
//
//  $cio  = new CWildcatConsole();
//
// Revision History:
// Build    Date      Author  Comments
// -----    --------  ------  -------------------------------------------
//***********************************************************************

if (!extension_loaded("wildcat")) dl("php_wildcat.dll");
require_once("wildcat.console.inc.php");

interface iWildcatConsoleIO
{
    function GetDeviceType();
    function Initialize();
    function ShutDown();
    function Write($data = "");
    function Writeln($data = "");
    function Read($s, $n = 1024);
    function Peek($s, $n = 1024);
    function CharReady();
    function Event($msecs);
    function ClearScreen($v=2);
}

class CWildcatDeviceDoor32 implements iWildcatConsoleIO
{
    function GetDeviceType()     { return "WCDOOR32"; }
    function Initialize()        { return WcDoorInitialize(); }
    function ShutDown()          { return WcDoorShutdown(); }
    function Write($data = "")   { return WcDoorWrite($data); }
    function Writeln($data = "") { return WcDoorWrite($data."\r\n"); }
    function Read($s, $n = 1024) { return WcDoorRead(&$s,$n); }
    function Peek($s, $n = 1024) { return WcDoorReadPeek(&$s, $n); }
    function CharReady()         { return WcDoorCharReady(); }
    function Event($msecs)       { return WcDoorEvent($msecs); }
    function ClearScreen($v=2)   { wcDoorWrite(sprintf("\33[%dJ",$v)); }
}

class CWildcatDeviceCRT32 implements iWildcatConsoleIO
{
    function GetDeviceType()     { return "WCCRT32"; }
    function Initialize()        { return true; }
    function ShutDown()          { return true; }
    function Write($data = "")   { return fputs(STDOUT,$data); }
    function Writeln($data = "") { return fputs(STDOUT,$data."\n"); }
    function Read($s, $n = 1024)
    {
       $s = "";
       while (wcKeyPressed()) $s .= chr(wcReadKey());
       return strlen($s);
    }

    function Peek($s, $n = 1024)
    {
       $s = "";
       while (wcKeyPressed()) $s .= chr(wcReadKey());
       return strlen($s);
    }

    function CharReady()         { return wcKeyPressed(); }

    function Event($msecs)
    {
       $atime = 0;
       $slice = 15;
       while (1) {
          if (wcKeyPressed()) return WCDOOR_EVENT_KEYBOARD;
          usleep($slice*1000);
          $atime += $slice;
          if ($atime >= $msecs) break;
       }
       return WCDOOR_EVENT_TIMEOUT;
    }

    function ClearScreen($v=2)  { }

}

//*****************************************************************
// class CWildcatConsole(class device_interface)
//
// class wrapper for virtual local console or wcdoor32
// communications.  The constructor needs to be passed
// the device interface to be used.  If not passed, then
// it will check for the environment string "wcdoorpipename"
// as an indicator for DOOR32 operations.
//
//*****************************************************************

class CWildcatConsole {

//-----------------
// Options
//-----------------

   public  $GlobalTimeoutSecs     = 0;
   public  $IdleTimeoutSecs       = 60;
   public  $InputBufferSize       = 0;

//-----------------
// Variables Set by Class
//-----------------

   public  $User                = null;
   public  $UserName            = null;
   public  $Node                = 0;
   public  $DoorSys             = array();

//-----------------
// private
//-----------------

   private $Active              = false;
   private $StartTime           = 0;
   private $interface           = null;
   private $interfaceType       = "";

   function __construct($interface = null)
   {
      global $ColorEnabled;

      if (!$interface) {
         if (getenv("wcdoorpipename")) {
            $interface  = new CWildcatDeviceDoor32();
            $this->interfaceType = "WCDOOR32";
         } else {
            $interface  = new CWildcatDeviceCRT32();
            $this->interfaceType = "WCCRT32";
         }
      }
      $this->interface = $interface;

      set_time_limit($this->GlobalTimeoutSecs);

      $this->StartTime  = time();
      $this->Node       = getenv("WCNODEID");

      if ($this->interface->Initialize()) {
          $this->Active   = true;
          WildcatLoggedIn(&$this->User);
          $this->UserName = $this->User["Info"]["Name"];
          $this->DoorSys  = $this->ReadDoorSys();
          $ColorEnabled   = $this->DoorSys[DisplayMode] == "GR";
          //$this->InitOutputFilter();
          $this->Flush();
          return true;
      }

      $this->InitOutputFilter();
      printf("Could not initialize door!\n");
      printf("Program must run as a 32-bit door from Wildcat!\n");
      $this->DelayMS(2000);
      return false;
   }

   function __destruct()
   {
      if ($this->Active) {
         $this->interface->Shutdown();
      }
   }

//-----------------
// public
//-----------------

   function GetDeviceType()
   {
      return $this->interface->GetDeviceType();
   }

   function callback_colorize($buffer)
   {
      $out = str_replace("\n","\r\n",$buffer);
      $this->interface->Write(ExpandMacros($out));
      return "";
   }

   function InitOutputFilter($cbfilter=null) {
      ob_start($cbfilter?$cbfilter:array($this,"callback_colorize"),2);
      ob_implicit_flush(true);
      register_shutdown_function('ob_end_clean');
   }

   function SetGlobalTimeout($secs)
   {
       // Dependencies: safe_mode = off
       // change max_execution_time
       set_time_limit($secs);
   }

   function DelayMS($msecs)      { usleep($msecs*1000); }

   function Delay($secs)
   {
      if (is_float($secs)) {
         $this->DelayMS($secs*1000.0);
      } else {
         sleep($secs);
      }
   }

   function Elapsed()            { return time() - $this->StartTime; }

   function Bell($n=1)
   {
      while($n--) {
         $this->interface->Write(chr(7));
         $this->DelayMS(200);
      }
   }

   function GetKey($passive = true, $timeout = null)
   {
       if ($timeout !== null) $this->SetGlobalTimeout($timeout);
       while (1) {
         $this->DelayMS(15);
         if ($this->interface->Read(&$c,1) > 0) {
            if (!$passive) {
              $this->interface->Write($c);
            }
            return $c;
         }
       }
       return null;
   }

   function WaitEnter()
   {
       $this->Write("@N@Press [@H@ENTER@N@] To Continue:@L@ ");
       while ($this->GetKey() != chr(13));
       $this->Writeln();
   }

   function Flush($dump = false)
   {
      while ($this->CharReady() && $this->Read(&$c)) {
        if ($dump) {
           $bytes = str_split($c);
           foreach($bytes as $i => $ch) {
             if (ord($ch) < 32) {
                printf("%2d = [%02X]\n",$i,ord($ch));
             } else {
                printf("%2d = [%s]\n",$i,$ch);
             }
           }
        }
      }
   }

   function Read($s, $n = 1024)  { return $this->interface->Read(&$s, $n); }
   function CharReady()          { return $this->interface->CharReady();   }
   function Peek($s, $n = 1024)  { return $this->interface->ReadPeek(&$s, $n); }

   function ReadKey()
   {
      $this->Read(&$s,1);
      return ord($s);
   }

   function Write()
   {
      $a = func_get_args();
      $format = array_shift($a);
      $s = vsprintf($format, $a);
      $s = str_replace("\n","\r\n",$s);
      return $this->interface->Write(ExpandMacros($s));
   }

   function Writeln()
   {
      $a = func_get_args();
      $format = array_shift($a);
      $s = vsprintf($format, $a);
      $s = str_replace("\n","\r\n",$s);
      return $this->interface->Write(ExpandMacros($s)."\r\n");
   }

   function Trace($c)
   {
      $bytes = str_split($c);
      foreach($bytes as $i => $ch) {
        if (ord($ch) < 32) {
           printf("%2d = [%02X]\n",$i,ord($ch));
        } else {
           printf("%2d = [%s]\n",$i,$ch);
        }
      }
   }

   public $idlesecs = 0;
   public function ResetIdle()
   {
      $this->idlesecs = 0;
   }

   public function CheckIdle()
   {
      $this->idlesecs++;
      if ($this->IdleTimeoutSecs) {
          if ($this->idlesecs >= ($this->IdleTimeoutSecs+60)) {
              $this->Writeln("@E@\r\nTIMEOUT!@L@");
              return true;
          }
          if ($this->idlesecs == $this->IdleTimeoutSecs) {
              $this->Bell();
              $this->Writeln("@E@\r\nWARNING!@H@ Timeout in 60 seconds@L@");
          }
      }
      return false;
   }

   public $InputOptions =  array(
           ExitKey        => 27,
           cbKeyEvent     => null,
           cbDropEvent    => null,
           cbIdleEvent    => null
         );

   function SetTerminalExit($value)
   {
       $this->InputOptions[ExitKey] = $value;
   }

   function SetTerminalHandler($opt,$value)
   {
       $this->InputOptions[$opt] = $value;
   }

   function PrepareOptions($cbKeyEvent  = null,
                           $cbDropEvent = null,
                           $cbIdleEvent = null,
                           $ExitKey     = 27)
   {
      $opts = array(
         ExitKey      => $ExitKey,
         cbKeyEvent   => $cbKeyEvent,
         cbDropEvent  => $cbDropEvent,
         cbIdleEvent  => $cbIdleEvent
      );

      if (is_array($cbKeyEvent)) {
         $opts = array_merge($opts,$cbKeyEvent);
      }

      if ($opts[cbKeyEvent]
             && is_string($opts[cbKeyEvent])
             && !function_exists($opts[cbKeyEvent])) {
          $this->Writeln("callback function \"%s\"  does not exist",
                          $opts[cbKeyEvent]);
          return false;
      }

      if ($opts[cbDropEvent]
             && is_string($opts[cbDropEvent])
             && !function_exists($opts[cbDropEvent])) {
          $this->Writeln("callback function \"%s\"  does not exist",
                          $opts[cbDropEvent]);
          return false;
      }

      if ($opts[cbIdleEvent]
             && is_string($opts[cbIdleEvent])
             && !function_exists($opts[cbIdleEvent])) {
          $this->Writeln("callback function \"%s\"  does not exist",
                          $opts[cbIdleEvent]);
          return false;
      }
      return $opts;
   }

   function Terminal($cbKeyEvent = null,
                     $cbDropEvent = null,
                     $cbIdleEvent = null,
                     $ExitKey = 27)
   {
      $opts = $this->PrepareOptions($cbKeyEvent,
                                    $cbDropEvent,
                                    $cbIdleEvent,
                                    $ExitKey);

      if ($opts === false) {
          return false;
      }

      $done            = false;
      $this->idlesecs  = 0;

      while (!$done) {
        switch ($this->interface->Event(1000)) {
          //-------------------------------------
          // TIMEOUT SIGNAL
          //-------------------------------------
          case WCDOOR_EVENT_TIMEOUT:
            if ($this->CheckIdle()) {
               $done = true;
            }
            if ($opts[cbIdleEvent]) {
               // if callback returns false, exit terminal
               if (!call_user_func($opts[cbIdleEvent],$this)) {
                  $done = true;
               }
            }
            break;

          //-------------------------------------
          // KEYBOARD SIGNAL
          //-------------------------------------
          case WCDOOR_EVENT_KEYBOARD:
            $n = $this->Read(&$c,$this->InputBufferSize);
            $this->DelayMS(15);
            if ($n > 0) {
                $this->idlesecs = 0;
                if ($opts[ExitKey] && ord($c) == $opts[ExitKey]) {
                    $done = true;
                    break;
                }
                if ($opts[cbKeyEvent]) {
                   // if callback returns false, exit terminal
                   if (!call_user_func($opts[cbKeyEvent],$this,$c)) {
                      $done = true;
                      break;
                   }
                } else {
                   $this->Write($c);
                   if ($c == chr(13)) $this->Write(chr(10));
                }
                break;
            }
            break;

          //-------------------------------------
          // TERMINATE SIGNAL
          //-------------------------------------

          case WCDOOR_EVENT_OFFLINE:

            if ($opts[cbDropEvent]) {
               call_user_func($opts[cbDropEvent],$this);
            } else {
               $this->Writeln("@E@\r\nWILDCAT! SYSTEM TERMINATED@L@");
            }
            $this->DelayMS(1000);
            $done = true;
            exit();

          //-------------------------------------
          // FUNCTION FAILED (Bad Parameters?)
          //-------------------------------------

          case WCDOOR_EVENT_FAILED:
            $this->Writeln("@E@\r\nWAIT_FAILED@L@");
            $this->DelayMS(1000);
            $done = true;
            break;
        }
      }
   }


   private $line = "";
   private $max  = "";
   function cb_term_lineinput($door, $ch)
   {
      switch(ord($ch)) {
        case 8:
          if (strlen($door->line)) {
              $this->interface->Write($ch." ".$ch);
              $door->line = substr($door->line,0,strlen($door->line)-1);
          }
          return true;

        // ignore linefeed
        case 10:
          return true;

        case 13:
          // accept input
          //if ($door->CharReady()) $door->Read($junk,1); // eat linefeed
          return;
        case 27:
          $ch = chr(8)." ".chr(8);
          for ($i = 0; $i < strlen($door->line); $i++) {
              $this->interface->Write($ch);
          }
          $door->line = "";
          return true;
      }
      if (!$door->max || strlen($door->line) < $door->max) {
          $door->Write($ch);
          $door->line .= $ch;
      }
      return true;
   }

   function Input($max = 0)
   {
      $options = array(
         ExitKey     => 0,
         cbKeyEvent  => array($this,"cb_term_lineinput")
      );
      $this->line = "";
      $this->max  = $max;
      $this->Terminal($options);
      return $this->line;
   }

   function ReadDoorSys($dropfile = null)
   {
      $DoorSysFields = array(
        "Port",                   // Port
        "Speed",                  // Speed
        "DataBits",               // Data Bits
        "Node",                   // Node
        "DteSpeed",               // Dte Speed
        "ScreenWrite",            // Screen Write
        "Printer",                // Printer
        "Page",                   // Page
        "Bell",                   // Bell
        "Name",                   // Name
        "From",                   // From
        "PhoneNumber",            // Phone Number
        "DataNumber",             // Data Number
        "Password",               // Password
        "Profile",                // Profile
        "Calls",                  // Calls
        "LastCall",               // Last Call
        "SecondsRemaining",       // Seconds Remaining
        "MinutesRemaining",       // Minutes Remaining
        "DisplayMode",            // Display Mode
        "LinesPerPage",           // Lines Per Page
        "ExpertMode",             // Expert Mode
        "Conferences",            // Conferences
        "ConferenceNumber",       // Conference Number
        "ExpireDate",             // Expire Date
        "UserRefNumber",          // User Ref Number
        "Protocol",               // Protocol
        "Uploads",                // Uploads
        "Downloads",              // Downloads
        "DownloadKToday",         // Download K Today
        "MaxDownloadKPerDay",     // Max Download K Per Day
        "Birthdate",              // Birthdate
        "UserDatabasePath",       // User Database Path
        "HomePath",               // Home Path
        "SysopName",              // Sysop Name
        "AliasName",              // Alias Name
        "NextEvent",              // Next Event
        "ReliableConnect",        // Reliable Connect
        "AnsiDetected",           // Ansi Detected
        "Network",                // Network
        "NoIdea",                 // No Idea
        "BankedTime",             // Banked Time
        "LastNewFiles",           // Last New Files
        "TimeCalled",             // Time Called
        "PreviousLogoff",         // Previous Logoff
        "MaxDownloads",           // Max Downloads
        "DownloadsToday",         // Downloads Today
        "TotalUploadK",           // Total Upload K
        "TotalDownloadK",         // Total Download K
        "CommentField",           // Comment Field
        "NoIdea",                 // No Idea
        "MessagesWritten"         // Messages Written
     );

     if ($dropfile == null) {
        $droppath = $_SERVER[argv][1];
        $dropfile = $droppath."\\door.sys";
     }

     $dsys = array();
     if ($dropfile != null && file_exists($dropfile)) {
        $dsys  = explode("\r\n",file_get_contents($dropfile),52);
        $dsys  = array_combine($DoorSysFields, $dsys);
     }
     return $dsys;
   }

   function GotoXY($x, $y)     { $this->interface->Write(sprintf("\33[%d;%dH",$x,$y)); }
   function EraseLine($v="")   { $this->interface->Write(sprintf("\33[%sK",$v)); }
   function ClearScreen($v=2)  { $this->interface->ClearScreen($v); }

}

//------------------------------------------------------------
// Use this class for pure DOO32 operations
//------------------------------------------------------------

class CWildcatDoor extends CWildcatConsole
{
   function __construct()
   {
      if (!getenv("wcdoorpipename")) {
         print "- This class ".__CLASS__." is used for WCDOOR32 mode.\n";
         die();
      }
      return parent::__construct(new CWildcatDeviceDoor32());
   }
}

//------------------------------------------------------------
// Use this class for pure CRT32 local mode operations
//------------------------------------------------------------

class CWildcatLocal extends CWildcatConsole
{
   function __construct()
   {
      if (getenv("wcdoorpipename")) {
         print "- This class ".__CLASS__." is used for WCCRT32 mode.\n";
         die();
      }
      return parent::__construct(new CWildcatDeviceCRT32());
   }
}

?>
