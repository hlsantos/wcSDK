<?php
// pwe_session_info.php - wcPHP session context diagnostic
// 500.2 26.4.1
//
// Shows login signals to determine session context type.
// Deploy under /pwe/ (authenticated) or /public/pwe/ (public) to compare.
//
// wcPHP session types (from wctype.h):
//   clSessionNone   = 0  no session / not logged in
//   clSessionUser   = 1  logged in as user
//   clSessionSystem = 2  system session
//   clSessionConfig = 3  config session
//
// IMPORTANT: WcInitialize() (called by CWildcat constructor) must run first.
// It connects to wcserver and calls WildcatServerCreateContextFromChallenge()
// to restore the user session from the HTTP challenge string.
// Without it, WildcatLoggedIn() always returns clSessionNone (0).

header('Content-Type: text/plain');

require_once("wildcat.php");

echo "=== wcPHP Session Context Diagnostic ===\n\n";

// Establish context - connects to wcserver and restores challenge session.
// quiet=false to show init steps; those print AFTER header() so no conflict.
$wcat = new CWildcat(false);   // false = verbose (show connect/restore steps)

echo "\n";

// --- Primary login signal ---
$sesstype = WildcatLoggedIn();
$sessname = wcGetSessionTypeStr($sesstype);
echo "WildcatLoggedIn()  : $sesstype  => $sessname\n";

// --- Node / connection ---
$node = wcGetNode();
$cid  = wcGetConnectionId();
echo "wcGetNode()        : $node" . ($node == 0 ? "  (not a user node)" : "") . "\n";
echo "wcGetConnectionId(): $cid\n";

// --- User struct from CWildcat ---
echo "\n";
if ($wcat->User === null) {
    echo "wcat->User         : NULL (not logged in)\n";
} elseif (empty($wcat->User)) {
    echo "wcat->User         : empty array\n";
} else {
    $id   = isset($wcat->User['Info']['Id'])   ? $wcat->User['Info']['Id']   : '(not set)';
    $name = isset($wcat->User['Info']['Name']) ? $wcat->User['Info']['Name'] : '(not set)';
    echo "User.Info.Id       : $id\n";
    echo "User.Info.Name     : $name\n";
}

// --- URL context ---
echo "\n";
echo "SCRIPT_NAME        : " . (isset($_SERVER['SCRIPT_NAME']) ? $_SERVER['SCRIPT_NAME'] : '(not set)') . "\n";
echo "REQUEST_URI        : " . (isset($_SERVER['REQUEST_URI']) ? $_SERVER['REQUEST_URI']  : '(not set)') . "\n";

echo "\n=== End ===\n";
?>
