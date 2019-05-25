                       PHP Wildcat! Extension (PWE)

Date   : 05/06/2012
version: 454.3
About  : PHP Windcat! Extension Readme

--------
History:
--------

02/09/08

   452.4  - initial version PWE

05/06/12

   454.3  - Updated for PHP v5.3 engine

-------------
Introduction:
-------------

PHP is a popular web scripting language.  Its popularity comes that it
has a rich language and is well supported with many extensions that
add new functionality via PHP to web sites.

PWE (PHP Wildcat! Extension) is such extension called PHP_WILDCAT.DLL.

By adding this DLL extension to your PHP setup, you will be able to use
the rich 250+ functions in the WCSDK (Wildcat Software Development Kit)
to directly write Wildcat! applications using PHP scripting language.

-------------
Requirement
-------------

Installing PWE requires PHP to be installed first.

If you don't have PHP installed, you can go to the HTTP://PHP.NET
web site and download the most current version version.

Alternatively, you may go http://www.winserver.com support site
and download specific PHP installations for Wildcat!

   WCPHP-LITE-x.x.x.EXE   - lite installation PHP with minimal
                            set of files required to use the
                            PHP Wildcat! extension and example
                            PHP applications.  WCPHP-LITE is
                            installed in the Wildcat! root
                            folder.

   WCPHP-FULL-x.x.x.EXE   - This is a complete PHP installation
                            of the current version as of this
                            documentation.  The installer helps
                            prepare PHP for immediate Wildcat!
                            usage. WCPHP-FULL installs PHP in
                            its own separate folder.

-------------
Installation:
-------------

NOTE:

  If you installed PHP using WCPHP-LITE or WCPHP-FULL, you may
  skip the installation since the installer already copies the
  EXT\PHP*.DLL files into the PHP setup and prepares the
  PHP.INI file for you.

(1) Copy/Move the EXT\PHP_*.DLL to your PHP Extension directory.

   This is the \PHP\EXT\ subfolder under your PHP installation
   folder or where the PHP_xxxxxxx.dll files are located.


(2) Edit the PHP.INI and add the following line to the block
    of extension= lines:

    extension=php_wildcat.dll

    Note: You can skip adding this extension line and use
    the DL() php command to load the DLL, like so:

      if (!extension_loaded("php_wildcat.dll")) {
          dl("php_wildcat.dll");
      }


(3) Optional:  Add the following section to PHP.INI

    [wildcat]
    wildcat.server      = ""
    wildcat.autoconnect = On

See the wcsdk_php_wildcat.txt to understand these options.

(4) Make sure you have a SCRIPT MAP entry for your PHP scripts
    in WCCONFIG | WEB Server | Script Mapping section:

    For example:

    Path To Script Engine: c:\php\php-cgi.exe
    Extension            : .php

(5) To test the installation, you can copy the TEST_WCAT.PHP script to a
    HTTP\ or HTTP\PUBLIC folder and run it from your web browser.

    /test_wcat.php                testing user session
    /public/test_wcat.php         testing non-user session

