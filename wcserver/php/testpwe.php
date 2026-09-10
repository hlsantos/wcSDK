<?php
//--------------------------------------------------------------
// File : c:\local\wc10\wcphp\dist\php\testpwe.php
// Date : 03/20/26 05:32 pm
// About:
//
// History:
//--------------------------------------------------------------

  $pweloaded = extension_loaded("wildcat");
  printf("- pweloaded: %d\n",$pweloaded?"YES":"NO");
  if (!$pweloaded) {
      dl("php_wildcat.dll");
  }
  print_r(ini_get_all("wildcat"));
  print_r(get_extension_funcs("wildcat"));

  print "\n";
  print "Press ENTER to Continue\n";
  fgets(STDIN);

?>

