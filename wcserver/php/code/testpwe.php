<?php
//--------------------------------------------------------------
// File : L:\local\wc5\wcphp\dist\php\testpwe.php
// Date : 03/22/08 09:56 am
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


?>

