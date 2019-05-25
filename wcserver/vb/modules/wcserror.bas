Attribute VB_Name = "wcserror" 

'------------------------------------------------------------------------
'Visual Basic Wildcat! SDK API v6.1.451.9
'(c) copyright 1998-2006 by Santronics Software Inc.. All Rights Reserved.
'
'Automatically generated from wcserror.h by CPP2BAS
'------------------------------------------------------------------------


public const WC_STATUS_BASE as Long = &H20000000

public const WC_SUCCESS as Long                     = 0
public const WC_UNSUPPORTED_VERSION as Long         = WC_STATUS_BASE + 1
public const WC_CONTEXT_NOT_INITIALIZED as Long     = WC_STATUS_BASE + 2
public const WC_INVALID_NODE_NUMBER as Long         = WC_STATUS_BASE + 3
public const WC_USER_NOT_FOUND as Long              = WC_STATUS_BASE + 4
public const WC_INCORRECT_PASSWORD as Long          = WC_STATUS_BASE + 5
public const WC_USER_NOT_LOGGED_IN as Long          = WC_STATUS_BASE + 6
public const WC_INVALID_INDEX as Long               = WC_STATUS_BASE + 7
public const WC_INVALID_OBJECT_ID as Long           = WC_STATUS_BASE + 8
public const WC_GROUP_ALREADY_EXISTS as Long        = WC_STATUS_BASE + 9
public const WC_GROUP_NOT_FOUND as Long             = WC_STATUS_BASE + 10
public const WC_OBSELETE_BY_502BETA as Long         = WC_STATUS_BASE + 11
public const WC_OBJECTID_ALREADY_EXISTS as Long     = WC_STATUS_BASE + 12
public const WC_NAME_NOT_FOUND as Long              = WC_STATUS_BASE + 13
public const WC_NAME_ALREADY_EXISTS as Long         = WC_STATUS_BASE + 14
public const WC_ALREADY_LOGGED_IN as Long           = WC_STATUS_BASE + 15
public const WC_ITEM_NOT_FOUND as Long              = WC_STATUS_BASE + 16
public const WC_ITEM_REQUIRES_NAME as Long          = WC_STATUS_BASE + 17
public const WC_ITEM_ALREADY_EXISTS as Long         = WC_STATUS_BASE + 18
public const WC_ITEM_NAME_DIFFERENT as Long         = WC_STATUS_BASE + 19
public const WC_RECORD_NOT_FOUND as Long            = WC_STATUS_BASE + 20
public const WC_ACCESS_DENIED as Long               = WC_STATUS_BASE + 21
public const WC_NODE_ALREADY_IN_USE as Long         = WC_STATUS_BASE + 22
public const WC_USER_ALREADY_LOGGED_IN as Long      = WC_STATUS_BASE + 23
public const WC_INVALID_CONNECTION_ID as Long       = WC_STATUS_BASE + 24
public const WC_INVALID_CONFERENCE as Long          = WC_STATUS_BASE + 25
public const WC_INVALID_CONFERENCEGROUP as Long     = WC_STATUS_BASE + 26
public const WC_INVALID_FILEAREA as Long            = WC_STATUS_BASE + 27
public const WC_INVALID_FILEGROUP as Long           = WC_STATUS_BASE + 28
public const WC_DUPLICATE_RECORD as Long            = WC_STATUS_BASE + 29
public const WC_NO_ACTION_TAKEN as Long             = WC_STATUS_BASE + 30
public const WC_ACCOUNT_LOCKED_OUT as Long          = WC_STATUS_BASE + 31
public const WC_FILE_SEARCH_SYNTAX as Long          = WC_STATUS_BASE + 32
public const WC_REQUEST_NOT_ADDED as Long           = WC_STATUS_BASE + 33
public const WC_CONTEXT_MULTI_REFS as Long          = WC_STATUS_BASE + 34
public const WC_CONTEXT_ALREADY_INITIALIZED as Long = WC_STATUS_BASE + 35
public const WC_NO_NODES_AVAILABLE as Long          = WC_STATUS_BASE + 36
public const WC_COMPUTERNAME_NOT_FOUND as Long      = WC_STATUS_BASE + 37
public const WC_DBASE_IX_MISMATCH as Long           = WC_STATUS_BASE + 38
public const WC_DBASE_UPDATE_ERROR as Long          = WC_STATUS_BASE + 39
public const WC_DBASE_RESERVED40 as Long            = WC_STATUS_BASE + 40
public const WC_DBASE_RESERVED41 as Long            = WC_STATUS_BASE + 41
public const WC_DBASE_RESERVED42 as Long            = WC_STATUS_BASE + 42
public const WC_DBASE_RESERVED43 as Long            = WC_STATUS_BASE + 43
public const WC_USER_OUT_OF_TIME as Long            = WC_STATUS_BASE + 44
public const WC_ACCOUNT_NOT_VALIDATED as Long       = WC_STATUS_BASE + 45
public const WC_DOMAIN_ACCESS_DENIED as Long        = WC_STATUS_BASE + 46
public const WC_BUFFER_TOO_SMALL as Long            = WC_STATUS_BASE + 47
public const WC_DOMAIN_NOT_FOUND as Long            = WC_STATUS_BASE + 48
public const WC_PASSWORD_EXPIRED as Long            = WC_STATUS_BASE + 49
public const WC_PASSWORD_CHANGE_REQUIRED as Long    = WC_STATUS_BASE + 50

public const WC_ANONYMOUS_DENIED as Long            = WC_STATUS_BASE + 51
public const WC_HOURS_RESTRICTED as Long            = WC_STATUS_BASE + 52
public const WC_SECURITY_NOT_FOUND as Long          = WC_STATUS_BASE + 53
public const WC_INVALID_USERNAME as Long            = WC_STATUS_BASE + 54

