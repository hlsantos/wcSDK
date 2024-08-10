<?php
//****************************************************************
// File Name : pwe_door_trivia_ob.php
// Subsystem : PWE
//
// Example PWE based DOOR for Example WcTrivia Service
//
// - Uses PHP output commands
//
//****************************************************************

require_once("wildcat.php");
uses_wildcat("door32");

//
// mixed GetServiceResponse(int socket, &string out [, &int code])
//

Function GetServiceResponse($socket, $out = null, $code = null)
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

//
// int SendServiceText(int socket, string out)
//

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

   $socket = socket_create(AF_INET, SOCK_STREAM, SOL_TCP);
   if ($socket === false) {
      printf("socket_create() failed: reason: " .
                    socket_strerror(socket_last_error()) . "\r\n");
      $door->WaitEnter();
      die();
   }

   $service_ip   = GetHostAddress($service[Address]);
   $service_port = $service[Port];
   $service_port = 4624;

   $result = @socket_connect($socket, $service_ip, $service_port);
   if ($result === false) {
      printf("socket_connect() failed.\r\nReason: (".socket_last_error($socket).") " .
                    socket_strerror(socket_last_error($socket)) . "\r\n");
      $door->WaitEnter();
      die();
   }

   //
   // Get and Display the Welcome lines!
   //

   echo "\n";
   while (GetServiceResponse($socket,&$line,&$code)) {
      echo "@H@$line@L@\n";
   }
   echo "\n";

   echo "@A@Would you like to answer some trivia questions?@L@ ";

   while (in_array(strtolower($door->input()),array("yes","y"))) {

      echo "\n";
      list($Question, $Answer) = GetServiceQuestion($socket);

      $Hint = "";
      while (1) {
        $Hint = PrepareHint($Answer, $Hint);

        echo "\n@B@".$Question."@L@\n";
        echo "@A@Hint:@N@\n";
        echo "$Hint@L@\n";

        $UserLine = $door->Input();
        echo "\n";
        if (!strcasecmp($UserLine,"/quit")) break;

        if (!strcasecmp($UserLine,$Answer)) {
           echo "\n@H@'$Answer'@B@ is the correct answer!@L@\n";
           break;
        }
        echo ("@E@Wrong Answer! Try again@L@");
        if (strchr($Hint,".")===false) {
            echo "@E@Sorry, the answer is: @B@$Answer@L@\n";
            break;
        }
      }
      echo "\n@A@Would you like another question?@L@ ";
   }
   socket_close($socket);
   echo "\n\n...@H@Exiting...Thanks for trying wcTrivia!\n";
   $door->Delay(1);
   exit();

?>


