<html>
<head>
<title>Wildcat! Server Info</title>
<style>
body {
   margin-left: 2%;
   margin-right: 2%;
   color: blue;
}

h3 {
    background: yellow;
    border: 1px solid blue;
    padding: 4pt;
}
table {
    border-collapse: collapse;
}
th { background-color: silver;}
th { padding: 2pt; }
td { padding: 2pt; }
</style>
</head>

<body>

<?php

   require_once("wildcat.user.class.php");
   require_once("wildcat.filetime.inc.php");

   $wcat = new CWildcat();

   $mw = wcGetMakewild();
   $si = wcGetWildcatServerInfo();

   print "<H3>Wildcat! Server Process Information</H3>";
   print "<pre>\n";

   printf("System Name  : %s\n", $mw["BBSName"]);
   printf("Compute Name : %s\n", wcGetConnectedServer());
   printf("Max Users    : %d\n", wcGetMaximumUserCount());
   printf("Node Count   : %d\n", wcGetNodeCount());
   printf("Users Online : %d\n", wcGetUsersOnline());
   printf("Total Calls  : %d\n", $si["TotalCalls"]);
   printf("Total Users  : %d\n", $si["TotalUsers"]);
   printf("Total Files  : %d\n", $si["TotalFiles"]);
   printf("Total Msgs   : %d\n", $si["TotalMessages"]);
   printf("Memory Load  : %d%%\n", $si["MemoryLoad"]);


   print "<H3>Server Thread Contexts Table</H3>";

   print "<table border='1'>\n";
   print "<tr>\n";
   print "<th>#</th>\n";
   print "<th>CID</th>\n";
   print "<th>NODE</th>\n";
   print "<th>TIME</th>\n";
   print "<th>IDLE</th>\n";
   print "<th>CALLS</th>\n";
   print "<th>COMPUTER</th>\n";
   print "<th>PROCESS</th>\n";
   print "<th>TYPE</th>\n";
   print "<th>USER</th>\n";
   print "</tr>\n";

   //------------------------------------------------------
   // Access connection information requires a user or
   // system context.  Use system if user is not logged in
   //------------------------------------------------------

   if (!wcGetNode() && !$wcat->LoginSystem()) {
      printf("! Error %08X : LoginSystem()\n",wcGetLastError());
      exit();
   }
   $cid = 0;
   while (wcGetConnectionInfo($cid, &$ci)) {
         print "<tr>\n";
         print "<td>" . $cid ."</td>\n";
         print "<td>" . $ci["ConnectionId"] ."</td>\n";
         print "<td>" . $ci["Node"] ."</td>\n";
         print "<td>" . FmtTicks($ci["Time"]) ."</td>\n";
         print "<td>" . Fmtticks($ci["IdleTime"]) ."</td>\n";
         print "<td>" . $ci["Calls"] ."</td>\n";
         print "<td>" . $ci["Computer"] ."</td>\n";
         print "<td>" . $ci["ProgramName"] ."</td>\n";
         print "<td>" . wcGetCallTypeStr($ci["CallType"]) ."</td>\n";
         print "<td>" . $ci["User"]["Name"] ."</td>\n";
         print "</tr>\n";
         $cid = $ci["ConnectionId"]+1;
   }
   print "</table>\n";
   print "</pre>\n";

?>

</body>
</html>
