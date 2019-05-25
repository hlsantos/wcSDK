<?php
//****************************************************************
// File Name : pwe_door_trivia.php
// Subsystem : PWE
//
// Example PWE based DOOR for Example WcTrivia Service
//
//****************************************************************

// g:\phpcommon\include\wildcat.php
// g:\phpcommon\include\wildcat.console.inc.php
// g:\phpcommon\include\wildcat.door32.class.php

require_once("wildcat.php");
uses_wildcat("door32");

@dl("php_sockets.dll");

//
// mixed GetServiceResponse(int socket, &string out [, &int code])
//

Function GetServiceResponse($socket, $out, $code = null)
{
   $out = trim(socket_read($socket, 1024));
   $more = (strlen($out) > 3) && ($out[3] == '-');
   if (func_num_args() == 1) {
       $out  = substr($out,4);
       return $out;
   }
   if (func_num_args() == 3) {
       $code = (int)substr($out,0,3);
       $out  = substr($out,4);
   }
   return $more;
}

function SendServiceText($socket, $text)
{
   $text .= "\r\n";
   return socket_send($socket, $text, strlen($text), 0);
}

Function GetServiceWelcome($socket, $door = null)
{
   $result = "";
   while ($out = socket_read($socket, 2048)) {
       $out = trim($out);
       $code = (int)substr($out,0,3);
       if ($door) {
          $door->Write("@H@".substr($out,4)."@L@\n");
       } else {
          print "$out\r\n";
       }
       $result[$code][] = substr($out,4);
       if (substr($out,3,1) == " ") break;
   }
   return $result;
}

function GetServiceQuestion($socket)
{
   SendServiceText($socket, "NEXT");
   //$out = trim(socket_read($socket, 1024));
   //$out = substr($out,4);
   $out = GetServiceResponse($socket);
   $out = explode('",',$out);
   $q = str_replace('"','',$out[0]);
   $a = str_replace('"','',$out[1]);
   return array($q,$a);
}

function PrepareHint($answer, $hint)
{
   if ($hint == "") {
      $hint = str_repeat(".",strlen($answer));
      for ($i=0; $i <strlen($answer); $i++) {
         if ($answer[$i]==" ") $hint[$i] = " ";
      }
      return $hint;
   }
   $hidx = strpos($hint,".");
   if ($hidx !== false) {
      for($i=0; $i<strlen($answer); $i++) {
         if ($answer[$hidx] == $answer[$i]) {
            $hint[$i] = $answer[$i];
         }
      }
      return $hint;
   }
   return null;
}

//----------------------------------------------------------
// MAIN
//----------------------------------------------------------

   $door = new CWildcatDoor();

   $door->SetGlobalTimeout(0);  // turn off PHP timeout
   $door->ClearScreen();

   $door->Write("@H@Welcome to PWE Trivia Door (Door32 Output)\n");
   $door->Write("@B@User      : @A@%s\n",$door->UserName);
   $door->Write("@B@Login Node: @A@%d\n",$door->Node);
   $door->Write("@B@Door Node : @A@%d\n",wcGetNode());

   //
   // Find Wildcat Service
   //

   if (!wcGetServiceByName("wcTrivia Service",&$service)) {
       $door->Write("! ERROR Finding WCTRIVIA Server\n");
       $door->input();
       exit();
   }

   $service_ip   = GetHostAddress($service[Address]);
   $service_port = $service[Port];

   $door->Write("@B@Service IP  : @A@%s\n",$service_ip);
   $door->Write("@B@Service Port: @A@%s\n",$service_port);

   $socket = socket_create(AF_INET, SOCK_STREAM, SOL_TCP);
   if ($socket === false) {
      $door->Write("socket_create() failed: reason: " .
                    socket_strerror(socket_last_error()) . "\r\n");
      $door->input();
      die();
   }

   $result = socket_connect($socket, $service_ip, $service_port);
   if ($result === false) {
      $door->Write("socket_connect() failed.\r\nReason: ($result) " .
                    socket_strerror(socket_last_error($socket)) . "\r\n");
      $door->input();
      die();
   }

   $door->Writeln();
   GetServiceWelcome($socket,$door);
   /*
   while (GetServiceResponse($socket,&$line,&$code)) {
      $door->Writeln($line);
   }
   */
   $door->Writeln();

   $door->Write("@B@Would you like to answer some trivia questions?@L@ ");

   while (in_array(strtolower($door->input()),array("yes","y"))) {

      $door->Writeln();

      list($Question, $Answer) = GetServiceQuestion($socket);

      $Hint = "";

      while (1) {
        $Hint = PrepareHint($Answer, $Hint);

        $door->Writeln();
        $door->Writeln("@B@".$Question."@L@");
        $door->Writeln("@A@Hint:@N@");
        $door->Write($Hint);
        $door->Writeln("@L@");

        $UserLine = $door->Input();
        $door->Writeln();
        if (!strcasecmp($UserLine,"/quit")) break;

        if (!strcasecmp($UserLine,$Answer)) {
           $door->Writeln("@H@'$Answer'@B@ is the correct answer!@L@");
           break;
        }

        $door->Writeln("@E@Wrong Answer! Try again@L@");
        if (strchr($Hint,".")===false) {
            $door->Writeln("@E@Sorry, the answer is: @B@%s@L@",$Answer);
            break;
        }
      }

      $door->Writeln();
      $door->Writeln();
      $door->Write("@B@Would you like another question?@L@ ");
   }
   socket_close($socket);
   $door->Write("\r\n... Exiting...\r\n");
   $door->Delay(1);
   exit();

?>


