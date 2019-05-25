<?php
//****************************************************************
// File Name : pwe_csp_door_ob.php
// Subsystem : PWE
//
// Example PWE based Client/Server Protocol (CSP) client door
//
// This version uses the PHP extension/functions stream_xxxxxx()
//
//****************************************************************

require_once("wildcat.php");
uses_wildcat("door32");

class CSPSocketClient {

   private $socket       = false;
   private $host_ip      = 0;
   private $host_port    = 0;
   public  $errorNumber  = 0;
   public  $errorReason  = "";
   public  $errorLine    = "";
   public  $UsingStream  = true;

   function __construct($useStream = true)
   {
      $this->UsingStream  = $useStream;
      if (!$this->UsingStream) {
         @dl("php_sockets.dll");
      }
      $this->socket       = false;
      $this->ClearError();

   }

   function __destruct()
   {
      $this->Close();
   }

   /*
   ** Set blocking or nonblocking mode 0 or 1
   */

   function SetBlockMode($mode)
   {
      if ($this->UsingStream) {
         return stream_set_blocking($this->socket,$mode);
      } else {
      }
   }

   /*
   ** Set read timeout
   */

   function SetTimeout($secs, $msecs = 0)
   {
      if ($this->UsingStream) {
         return stream_set_timeout($this->socket,$secs, $msecs);
      } else {
      }
   }

   /*
   ** Clear last error captured
   */

   function ClearError()
   {
      $this->errorNumber  = 0;
      $this->errorLine    = 0;
      $this->errorReason  = "";
      if ($this->socket) {
         if ($this->UsingStream) {
         } else {
            socket_clear_error($this->socket);
         }
      }
   }

   /*
   ** Set last error
   */

   function SetLastError($line, $err = null)
   {
      if ($this->UsingStream) {
         $this->errorReason  = "?";
      } else {
         if ($err === null) $err = socket_last_error($this->socket);
         $this->errorReason  = socket_strerror($err);
      }
      $this->errorNumber  = $err;
      $this->errorLine    = $line;
   }


   /*
   ** Dump last error captured
   */

   function ShowLastError()
   {
      printf("@E@%s failed\nError Code: %d\nReason: %s\n\n",
              $this->errorLine,
              $this->errorNumber,
              $this->errorReason);
   }

   /*
   ** Create a socket if using sockets
   */

   function Create()
   {
      if ($this->UsingStream) {
         //$this->context = stream_context_create();
      } else {
         $this->socket = @socket_create(AF_INET, SOCK_STREAM, SOL_TCP);
         if ($this->socket === false) {
            $this->SetLastError("socket_create()");
            return false;
         }
      }
      return true;
   }

   /*
   ** Close current connection
   */

   function Close()
   {
      if ($this->socket) {
         if ($this->UsingStream) {
            fclose($this->socket);
         } else {
            socket_close($this->socket);
         }
      }
      $this->socket = false;
      return true;
   }

   /*
   ** Connect to a IP/PORT
   */

   function Connect($ip,$port)
   {
      if (is_long($ip)) $ip = GetHostAddress($ip);
      $this->host_ip   = $ip;
      $this->host_port = $port;
      if ($this->UsingStream) {
         $stm = sprintf("tcp://%s:%d",$this->host_ip,$port);
         $this->socket = @stream_socket_client($stm,$errno,$errstr,5);
         if (!$this->socket) {
            $this->errorReason  = $errstr;
            $this->errorNumber  = $errno;
            $this->errorLine    = "socket_connect()";
            return false;
         }
      } else {
         $result = @socket_connect($this->socket, $this->host_ip, $port);
         if ($result === false) {
            $this->SetLastError("socket_connect()");
            return false;
         }
      }
      return true;

   }

   /*
   ** Open a connect giving IP and PORT
   */

   function Open($ip,$port)
   {
      if ($this->Create()) {
         if ($this->Connect($ip,$port)) {
            return true;
         }
         $this->Close();
      }
      return false;
   }

   /*
   ** Read a line, parse multiple lines into line buffer
   ** Read from buffer first, if any;
   */

   private $LineBuffer = array();
   Function ReadLine()
   {
      if (count($this->LineBuffer) > 0) {
         return array_shift($this->LineBuffer);
      } else {
         $this->SetTimeout(30);
         if ($this->UsingStream) {
            $result = fgets($this->socket,1024);
         } else {
            $result = @socket_read($this->socket,1024);
         }
         if ($result === false) {
             $this->SetLastError("ReadLine()");
             return null;
         }
         $this->LineBuffer = Explode("\r\n",rtrim($result));
         return array_shift($this->LineBuffer);
      }
      return $result;
   }

   /*
   ** Sending a command
   */

   Function SendLine($line)
   {
      $line .= "\r\n";
      if ($this->UsingStream) {
         $result = fwrite($this->socket, $line);
      } else {
         $result = socket_send($this->socket, $line, strlen($line), 0);
      }
      if ($result === false) {
         $this->SetLastError("SendLine()");
         return null;
      }
      return $result;
   }

   /*
   ** Return an array of responses with the key as the repy code
   */

   Function GetResponseLines()
   {
      $more = true;
      $result = "";
      while ($more) {
          $line = $this->ReadLine();
          if ($line === null) {
             break;
          }
          $sa = explode("\r\n",$line);
          foreach($sa as $out) {
             if ($out) {
                $code = (int)substr($out,0,3);
                $result[$code][] = substr($out,4);
                $more = (strlen($out) > 3) && ($out[3] == '-');
             }
          }
      }
      return $result;
   }

   /*
   ** Parse a line into:
   ** Array [Line]   original line
   **       [Code]   reply code
   **       [More]   True if continue reply code (i.e, 250-)
   **       [Text]   Line without reply code.
   */

   Function ParseReplyLine($s)
   {
      $s = trim($s);
      $result[Line] = $s;
      $result[Code] = (int)substr($s,0,3);
      $result[More] = (strlen($s) > 3) && ($s[3] == '-');
      $result[Text] = substr($s,4);
      return $result;
   }

}

//----------------------------------------------------------
// MAIN
//----------------------------------------------------------

   $door = new CWildcatDoor();
   $door->SetGlobalTimeout(0);  // turn off PHP timeout

   // Enable standard PHP output for door.
   // If not called, then you must use $door->WriteXX() functions
   // to send characters to the remote client.
   $door->InitOutputFilter();

   $door->ClearScreen();

   printf("@H@Welcome to PWE Trivia Door\n");
   printf("@B@User: @A@%s\n",$door->UserName);

   //
   // Find Wildcat Service
   //

   if (!wcGetServiceByName("wcTrivia Service",&$service)) {
       printf("\n@E@! WCTRIVIA Service is DOWN!. Try again later\n\n@L@");
       $door->WaitEnter();
       exit();
   }
/*
*/
   //
   // Create a CSP client
   //

   $csp = new CSPSocketClient();

   // DEBUG only
//   $service[Address]  = "192.168.1.2";
//   $service[Port]     = 25;
//   $service[Port]     = 4622;

//   $service[Address]  = "208.247.131.9";
//   $service[Port]     = 587;

 //$service[Address]  = "hdev21";
//   $service[Address]  = "hdev1";
//   $service[Port]     = 16000;
   //------------

   if (!$csp->Open($service[Address], $service[Port])) {
      $csp->ShowLastError();
      $door->WaitEnter();
      exit();
   }

   // Show Server Welcome, if any

   echo "\n";
   while ($line = $csp->ReadLine()) {
      $resp = $csp->ParseReplyLine($line);
      echo "@B@$resp[Line]@L@\n";
      if (!$resp[More]) break;
   }

   $done = false;
   while (!$done) {

      do {
        echo "\n";
        echo "@N@> @L@";
      } while (($cmd = trim($door->input())) == "");
      echo "\n";
      if (!strncasecmp($cmd,"/quit",2)) break;

      if ($csp->SendLine($cmd) === null) {
         $csp->ShowLastError();
         $door->WaitEnter();
         break;
      }

      while ($line = $csp->ReadLine()) {
         $resp = $csp->ParseReplyLine($line);
         echo "@B@$resp[Line]@L@\n";
         if (!$resp[More]) break;
      }

      if ($line === null) {
         break;
      }

   }
   $csp->Close();
   echo "\n\n...@H@Exiting...\n";
   $door->Delay(1);
   exit();

?>


