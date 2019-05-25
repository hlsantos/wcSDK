<?php

require_once("arraylib.php");

class CWcShareNet {
   var $cfg = array();
   var $dbo = null;

   function __construct()
   {
      $this->cfg['dbf'] = get_cfg_var("wcsharenet.pdo.dbf");
      $this->cfg['drv'] = get_cfg_var("wcsharenet.pdo.drv");
      $this->cfg['dsn'] = get_cfg_var("wcsharenet.pdo.dsn");
      $this->cfg['uid'] = get_cfg_var("wcsharenet.pdo.uid");
      $this->cfg['pwd'] = get_cfg_var("wcsharenet.pdo.pwd");
      if (!$this->cfg['dsn']) {
         $this->cfg['dsn'] = $this->cfg['drv'].':'.$this->cfg['dbf'];
      }
   }

   function ShowConfig()
   {
      print_r($this->cfg);
   }

   function __destruct()
   {
      $this->Close();
   }

   function IsConfigReady()
   {
      $ok = $this->cfg['dsn'] != "";
      if ($this->cfg['dsn'] == ":") $ok = false;
      return $ok;
   }

   function Open()
   {
      try {
         $this->dbo = new PDO($this->cfg['dsn'],
                              $this->cfg['uid'],
                              $this->cfg['pwd']);
      } catch (Exception $e) {
        echo "\n";
        echo "=====================================\n";
        echo "! Failed: " . $e->getMessage() ."\n";
        echo "! DSN   : " . $this->cfg['dsn'] ."\n";
        echo "=====================================\n";
        echo "\n";
        return FALSE;
      }
      return TRUE;
   }

   function Close()
   {
      $this->dbo = null;
   }

   function IsOpen()
   {
      return $this->dbo != null;
   }

   function DeleteDatabase()
   {

      if ($this->IsOpen()) {
         print "! Close database first before deleting\n";
         return false;
      }

      $dbf = $this->cfg['dbf'];
      if ($dbf) {
         print "* Deleting database file: $dbf\n";
         if (file_exists($dbf) && !@unlink($dbf)) {
             printf("! Error Deleting $dbf\n");
             return FALSE;
         }
      }
      return TRUE;
   }

   function CreateDatabase()
   {
      if (!DeleteDatabase()) {
         return FALSE;
      }
      return Open();
   }

   function ProcessSQL($sql)
   {
      if (!$this->IsOpen()) {
         print "! ERROR - database not open\n";
         return FALSE;
      }
      try {
        $result = $this->dbo->query($sql, PDO::FETCH_ASSOC);
        $errorInfo = $this->dbo->errorInfo();
        if ($errorInfo[1]) {
           echo "\nPDO::errorInfo(): ";
           print_r($errorInfo);
           print "\n";
        }
      } catch (Exception $e) {
        echo "\n";
        echo "=====================================\n";
        echo "! Failed: " . $e->getMessage() ."\n";
        echo "! DSN   : " . $dbDSN ."\n";
        echo "=====================================\n";
        echo "\n";
        return FALSE;
      }
      return TRUE;
   }

   //---------------------------------------------------------
   // ReadData()
   // - Query new notes from channel since requestid (rid)
   //---------------------------------------------------------

   function ReadData($chn, $rid)
   {

      $sql = "select * from messages where chn='$chn' and rid>$rid;";

      if ($rid == 0) {
         // query for total and last rid info
         $sql = "select count(*) as 'total', " .
                "       max(rid) as 'last' " .
                "  from messages where chn='$chn';";
      }

      try {
        $result = $this->dbo->query($sql,PDO::FETCH_ASSOC);
        $errorInfo = $this->dbo->errorInfo();
        if ($errorInfo[1]) {
           print_r($errorInfo);
        } else {
           $result = object_2_array($result);
           if ($rid == 0) {
              $total  = $result[0][total];
              $newpos = $result[0][last];
              $result = array();
           } else {
              $newpos  = count($result);
              if ($newpos == 0) {
                  $newpos = $rid;
                  $total  = $newpos;
              } else {
                 foreach ($result as $row) {
                   $total = $row[rid];
                 }
              }
           }
           $lines = json_encode($result);
           printf("%d | %d | {notes:%s}\n",$total, $newpos, $lines);
        }
      } catch (Exception $e) {
        echo "\n";
        echo "=====================================\n";
        echo "! Failed: " . $e->getMessage() ."\n";
        echo "! DSN   : " . $dbDSN ."\n";
        echo "=====================================\n";
        echo "\n";
        return FALSE;
      }
      return TRUE;
   }

   //---------------------------------------------------------
   // SaveData()
   // - Post a note into the channel
   //---------------------------------------------------------

   function SaveData($chn, $txt, $uid, $uts)
   {
      // strip any html tages and encode special chars for
      // the user provided uid and text

      $uid = Strip_Tags($uid);
      $txt = Strip_Tags($txt);
      $txt = rawurlencode($txt);

      // set the user ip and time

      $uip = getenv('REMOTE_ADDR');
      //$tid = date('Y/m/d h:i:sa');
      $tid = date('Y/m/d g:i:s a');  // recommended by map

      $sql = sprintf('INSERT INTO messages (tid,chn,uid,uts,uip,data) ' .
                     'values("%s","%s","%s","%s","%s","%s");',
                     $tid,
                     $chn,
                     $uid,
                     $uts,
                     $uip,
                     $txt);

      try {
        $result = $this->dbo->query($sql,PDO::FETCH_ASSOC);
        $errorInfo = $this->dbo->errorInfo();
        if ($errorInfo[1]) {
           print_r($errorInfo);
        } else {
           printf("ok\n");
        }
      } catch (Exception $e) {
        echo "\n";
        echo "=====================================\n";
        echo "! Failed: " . $e->getMessage() ."\n";
        echo "! DSN   : " . $dbDSN ."\n";
        echo "=====================================\n";
        echo "\n";
        return FALSE;
      }
      return TRUE;

   }
}

?>
