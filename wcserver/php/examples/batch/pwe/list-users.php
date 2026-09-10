<?PHP
//***********************************************************************
// (c) Copyright 1998-2026 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : list-users.php
// Subsystem : wcPHP CLI Utility
// Version   : 500.2 26.3.21
// About     : List Wildcat! users from the command line.
//
// Usage     : php list-users.php [options]
//
// Options   : --server=HOSTNAME   | /server:HOSTNAME
//             --sort=name|id|security|lastcall  (default: name)
//             --search=PREFIX     search by current sort key prefix
//             --fields=FIELDLIST  comma-separated fields to display
//                                 default: id,name,security,lastcall
//             --max=N             stop after N users (default: all)
//             --help
//
// Examples  : php list-users.php --server=NTBBS
//             php list-users.php /server:NTBBS --sort=lastcall --max=20
//             php list-users.php --sort=name --search=S
//
//***********************************************************************

// -----------------------------------------------------------------------
// Require the Wildcat class library.
// Adjust path if running outside the examples tree.
// -----------------------------------------------------------------------

$base = dirname(__FILE__);
require_once($base . "/../../../code/wildcat.user.class.php");

// -----------------------------------------------------------------------
// Arg parser: supports --key=value, --key value, /key:value, /key value
// -----------------------------------------------------------------------

function parse_args($argv)
{
    $opts = array(
        "server"  => ini_get("wildcat.server") ?: "localhost",
        "sort"    => "name",
        "search"  => null,
        "fields"  => "id,name,security,lastcall",
        "max"     => 0,
        "help"    => false,
    );

    $i = 1;
    while ($i < count($argv)) {
        $a = $argv[$i];

        // --key=value  or  /key:value
        if (preg_match('/^(--|\/)([\w]+)[=:](.*)$/', $a, $m)) {
            $opts[$m[2]] = $m[3];
            $i++;
            continue;
        }

        // --key value  or  /key value
        if (preg_match('/^(--|\/)([\w]+)$/', $a, $m)) {
            $key = $m[2];
            if ($key === "help") {
                $opts["help"] = true;
                $i++;
                continue;
            }
            if (isset($argv[$i+1]) && $argv[$i+1][0] !== '-' && $argv[$i+1][0] !== '/') {
                $opts[$key] = $argv[$i+1];
                $i += 2;
                continue;
            }
            $opts[$key] = true;
            $i++;
            continue;
        }

        $i++;
    }

    return $opts;
}

function usage()
{
    echo "Usage: php list-users.php [options]\n";
    echo "\n";
    echo "  --server=HOSTNAME  | /server:HOSTNAME\n";
    echo "  --sort=name|id|security|lastcall  (default: name)\n";
    echo "  --search=PREFIX    search by sort key prefix\n";
    echo "  --fields=LIST      id,name,security,lastcall (default: all four)\n";
    echo "  --max=N            stop after N users\n";
    echo "  --help\n";
    exit(0);
}

// -----------------------------------------------------------------------
// Sort key map
// -----------------------------------------------------------------------

$SORT_KEYS = array(
    "id"       => UserIdKey,
    "name"     => UserNameKey,
    "lastname" => UserLastNameKey,
    "security" => UserSecurityKey,
    "lastcall" => UserLastCallKey,
);

// -----------------------------------------------------------------------
// FILETIME -> readable string helper (if not already loaded)
// -----------------------------------------------------------------------

if (!function_exists("filetime_to_str")) {
    function filetime_to_str($ft)
    {
        if (!is_array($ft)) return "";
        $lo = isset($ft["dwLowDateTime"])  ? $ft["dwLowDateTime"]  : 0;
        $hi = isset($ft["dwHighDateTime"]) ? $ft["dwHighDateTime"] : 0;
        if ($lo == 0 && $hi == 0) return "(never)";
        // FILETIME = 100-ns intervals since 1601-01-01
        $ft64  = ($hi * 4294967296.0) + ($lo < 0 ? $lo + 4294967296.0 : $lo);
        $epoch = ($ft64 - 116444736000000000.0) / 10000000.0;
        if ($epoch <= 0) return "(never)";
        return date("Y-m-d H:i", (int)$epoch);
    }
}

// -----------------------------------------------------------------------
// Main
// -----------------------------------------------------------------------

$opts = parse_args($argv);

if ($opts["help"]) {
    usage();
}

$server  = $opts["server"];
$sortstr = strtolower($opts["sort"]);
$search  = $opts["search"];
$fields  = array_map("trim", explode(",", strtolower($opts["fields"])));
$maxrows = (int)$opts["max"];

if (!isset($SORT_KEYS[$sortstr])) {
    fwrite(STDERR, "Unknown sort key: {$sortstr}\n");
    fwrite(STDERR, "Valid: " . implode(", ", array_keys($SORT_KEYS)) . "\n");
    exit(1);
}
$sortkey = $SORT_KEYS[$sortstr];

// Override server from arg (ini_get fallback already in parse_args)
ini_set("wildcat.server", $server);

// Connect
$wcat = new CWildcat();
if (!$wcat->LoginSystemContext()) {
    fwrite(STDERR, sprintf("! LoginSystemContext() failed: error %08X\n", wcGetLastError()));
    exit(1);
}

// Column widths
$W_ID   = 6;
$W_NAME = 32;
$W_SEC  = 20;
$W_LC   = 16;

// Header
$header = "";
if (in_array("id",       $fields)) $header .= sprintf("%-{$W_ID}s  ", "ID");
if (in_array("name",     $fields)) $header .= sprintf("%-{$W_NAME}s  ", "Name");
if (in_array("security", $fields)) $header .= sprintf("%-{$W_SEC}s  ", "Security");
if (in_array("lastcall", $fields)) $header .= sprintf("%-{$W_LC}s", "Last Call");
echo $header . "\n";
echo str_repeat("-", strlen($header)) . "\n";

// Iterate
$wcusers = new CWildcatUser();
$wcusers->SortKey($sortkey);

$count = 0;

if ($search !== null) {
    $u = $wcusers->Search($search);
} else {
    $u = $wcusers->First();
}

while ($u !== null) {

    $info = isset($u["Info"])     ? $u["Info"]     : array();
    $sec  = isset($u["Security"]) ? $u["Security"] : array();
    $lc   = isset($u["LastCall"]) ? $u["LastCall"] : null;

    $id       = isset($info["Id"])   ? $info["Id"]   : 0;
    $name     = isset($info["Name"]) ? $info["Name"] : "";
    $secname  = is_array($sec) && count($sec) > 0 ? $sec[0] : "";
    $lcstr    = $lc !== null ? filetime_to_str($lc) : "(never)";

    $row = "";
    if (in_array("id",       $fields)) $row .= sprintf("%-{$W_ID}d  ", $id);
    if (in_array("name",     $fields)) $row .= sprintf("%-{$W_NAME}s  ", substr($name, 0, $W_NAME));
    if (in_array("security", $fields)) $row .= sprintf("%-{$W_SEC}s  ", substr($secname, 0, $W_SEC));
    if (in_array("lastcall", $fields)) $row .= sprintf("%-{$W_LC}s", $lcstr);
    echo $row . "\n";

    $count++;
    if ($maxrows > 0 && $count >= $maxrows) break;

    $u = $wcusers->Next();
}

echo str_repeat("-", strlen($header)) . "\n";
echo "{$count} user(s) listed.\n";

$wcat->RestoreContext();
?>
