unit wcserror;

{ DO NOT EDIT THIS FILE!!! }
{ This file is automatically generated from wcserror.h by cpp2pas. }

interface

uses WinTypes, wctype;

const WC_STATUS_BASE =  $20000000;
const WC_SUCCESS                     = 0;
const WC_UNSUPPORTED_VERSION         = WC_STATUS_BASE + 1;
const WC_CONTEXT_NOT_INITIALIZED     = WC_STATUS_BASE + 2;
const WC_INVALID_NODE_NUMBER         = WC_STATUS_BASE + 3;
const WC_USER_NOT_FOUND              = WC_STATUS_BASE + 4;
const WC_INCORRECT_PASSWORD          = WC_STATUS_BASE + 5;
const WC_USER_NOT_LOGGED_IN          = WC_STATUS_BASE + 6;
const WC_INVALID_INDEX               = WC_STATUS_BASE + 7;
const WC_INVALID_OBJECT_ID           = WC_STATUS_BASE + 8;
const WC_GROUP_ALREADY_EXISTS        = WC_STATUS_BASE + 9;
const WC_GROUP_NOT_FOUND             = WC_STATUS_BASE + 10;
const WC_OBSELETE_BY_502BETA         = WC_STATUS_BASE + 11;
const WC_OBJECTID_ALREADY_EXISTS     = WC_STATUS_BASE + 12;
const WC_NAME_NOT_FOUND              = WC_STATUS_BASE + 13;
const WC_NAME_ALREADY_EXISTS         = WC_STATUS_BASE + 14;
const WC_ALREADY_LOGGED_IN           = WC_STATUS_BASE + 15;
const WC_ITEM_NOT_FOUND              = WC_STATUS_BASE + 16;
const WC_ITEM_REQUIRES_NAME          = WC_STATUS_BASE + 17;
const WC_ITEM_ALREADY_EXISTS         = WC_STATUS_BASE + 18;
const WC_ITEM_NAME_DIFFERENT         = WC_STATUS_BASE + 19;
const WC_RECORD_NOT_FOUND            = WC_STATUS_BASE + 20;
const WC_ACCESS_DENIED               = WC_STATUS_BASE + 21;
const WC_NODE_ALREADY_IN_USE         = WC_STATUS_BASE + 22;
const WC_USER_ALREADY_LOGGED_IN      = WC_STATUS_BASE + 23;
const WC_INVALID_CONNECTION_ID       = WC_STATUS_BASE + 24;
const WC_INVALID_CONFERENCE          = WC_STATUS_BASE + 25;
const WC_INVALID_CONFERENCEGROUP     = WC_STATUS_BASE + 26;
const WC_INVALID_FILEAREA            = WC_STATUS_BASE + 27;
const WC_INVALID_FILEGROUP           = WC_STATUS_BASE + 28;
const WC_DUPLICATE_RECORD            = WC_STATUS_BASE + 29;
const WC_NO_ACTION_TAKEN             = WC_STATUS_BASE + 30;
const WC_ACCOUNT_LOCKED_OUT          = WC_STATUS_BASE + 31;
const WC_FILE_SEARCH_SYNTAX          = WC_STATUS_BASE + 32;
const WC_REQUEST_NOT_ADDED           = WC_STATUS_BASE + 33;
const WC_CONTEXT_MULTI_REFS          = WC_STATUS_BASE + 34;
const WC_CONTEXT_ALREADY_INITIALIZED = WC_STATUS_BASE + 35;
const WC_NO_NODES_AVAILABLE          = WC_STATUS_BASE + 36;
const WC_COMPUTERNAME_NOT_FOUND      = WC_STATUS_BASE + 37;
const WC_DBASE_IX_MISMATCH           = WC_STATUS_BASE + 38;
const WC_DBASE_UPDATE_ERROR          = WC_STATUS_BASE + 39;
const WC_DBASE_RESERVED40            = WC_STATUS_BASE + 40;
const WC_DBASE_RESERVED41            = WC_STATUS_BASE + 41;
const WC_DBASE_RESERVED42            = WC_STATUS_BASE + 42;
const WC_DBASE_RESERVED43            = WC_STATUS_BASE + 43;
const WC_USER_OUT_OF_TIME            = WC_STATUS_BASE + 44;
const WC_ACCOUNT_NOT_VALIDATED       = WC_STATUS_BASE + 45;
const WC_DOMAIN_ACCESS_DENIED        = WC_STATUS_BASE + 46;
const WC_BUFFER_TOO_SMALL            = WC_STATUS_BASE + 47;
const WC_DOMAIN_NOT_FOUND            = WC_STATUS_BASE + 48;
const WC_PASSWORD_EXPIRED            = WC_STATUS_BASE + 49;
const WC_PASSWORD_CHANGE_REQUIRED    = WC_STATUS_BASE + 50;
const WC_ANONYMOUS_DENIED            = WC_STATUS_BASE + 51;
const WC_HOURS_RESTRICTED            = WC_STATUS_BASE + 52;
const WC_SECURITY_NOT_FOUND          = WC_STATUS_BASE + 53;

implementation


end.
