<?php
// test_connections.php - diagnose wcGetConnectionInfo by-ref issue
// 500.2 26.3.21

require_once("wildcat.user.class.php");

$wcat = new CWildcat();

echo "<pre>\n";
echo "PHP version: " . phpversion() . "\n";
echo "wcGetLastError before login: " . sprintf("%08X", wcGetLastError()) . "\n";

// Login system context
if (!wcGetNode() && !$wcat->LoginSystem()) {
    printf("! LoginSystem() failed: %08X\n", wcGetLastError());
    exit();
}
echo "LoginSystem() OK\n";
echo "Node: " . wcGetNode() . "\n\n";

// Test 1: call with $ci unset
echo "--- Test 1: \$ci unset ---\n";
$ci = NULL;
$result = wcGetConnectionInfo(0, $ci);
printf("wcGetConnectionInfo(0, NULL) returned: %s\n", $result ? "TRUE" : "FALSE");
printf("wcGetLastError: %08X\n", wcGetLastError());
printf("ci type: %s\n", gettype($ci));
if (is_array($ci)) {
    printf("ci keys: %s\n", implode(", ", array_keys($ci)));
    printf("ci[ConnectionId]: %s\n", isset($ci["ConnectionId"]) ? $ci["ConnectionId"] : "(not set)");
} else {
    printf("ci value: %s\n", var_export($ci, true));
}
echo "\n";

// Test 2: call with $ci as empty array
echo "--- Test 2: \$ci = array() ---\n";
$ci2 = array();
$result2 = wcGetConnectionInfo(0, $ci2);
printf("wcGetConnectionInfo(0, array()) returned: %s\n", $result2 ? "TRUE" : "FALSE");
printf("wcGetLastError: %08X\n", wcGetLastError());
printf("ci2 type: %s\n", gettype($ci2));
if (is_array($ci2)) {
    printf("ci2 keys: %s\n", implode(", ", array_keys($ci2)));
    printf("ci2[ConnectionId]: %s\n", isset($ci2["ConnectionId"]) ? $ci2["ConnectionId"] : "(not set)");
}
echo "\n";

// Test 3: walk first 3 slots
echo "--- Test 3: walk cid 0..2 ---\n";
for ($cid = 0; $cid <= 2; $cid++) {
    $ci3 = NULL;
    $r3 = wcGetConnectionInfo($cid, $ci3);
    printf("cid=%d result=%s err=%08X ci_type=%s",
        $cid, $r3?"TRUE":"FALSE", wcGetLastError(), gettype($ci3));
    if (is_array($ci3) && isset($ci3["ConnectionId"])) {
        printf(" ConnectionId=%s User=%s", $ci3["ConnectionId"],
            isset($ci3["User"]["Name"]) ? $ci3["User"]["Name"] : "?");
    }
    echo "\n";
}

echo "</pre>\n";
?>
