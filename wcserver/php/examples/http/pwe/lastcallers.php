<html>
<body>
<title>LastCallers</title>
<style>
h3 {
    background: yellow;
    border: 1px solid blue;
    padding: 4pt;
}
table {
    border-collapse: collapse;
    margin-left: 5%;
}
th { background-color: silver;}
td { padding: 2pt; }
</style>

<?PHP

   require_once("wildcat.user.class.php");
   uses_wildcat("filetime");

   $wcat = new CWildcat();

   if (!$wcat->LoginSystemContext()) {
      printf("! Error %08X : LoginSystemContext()\n",wcGetLastError());
      exit();
   }

   print "<table border='1'>\n";
   print "<tr><th colspan=2>Last Callers</th</tr>\n";
   print "<tr><th>LastCall</th><th>Name</th></tr>\n";

   $wcusers = new CWildcatUser();
   $wcusers->SortKey(UserLastCallKey);
   while ($wcusers->Prev()) {
         $u  = $wcusers->User();
         $ui = $u["Info"];
         $lc = DateTimeString($u["LastCall"]);
         if ($lc == "") break;
         print "<tr>\n";
         print "<td>" . $lc ."</td>\n";
         print "<td>" . $ui["Name"] ."</td>\n";
         print "</tr>\n";
   }

   print "</table>\n";

   $wcat->RestoreContext();

?>


</body>
</html>
