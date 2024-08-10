*********************************************************
**     Wildcat! SDK/API for Microsoft Visual Foxpro    **
**     (c) copyright 2001 Santronics Software Inc.     **
*********************************************************
** File: wcserror.h
** Date: 04/13/2004 14:09:51
**                      WARNING!!
** If you make any custom change to the SDK, Santronics
** Software will not be responsible for support issues.
** To maintain source version compatibility with future
** Wildcat! SDK/API updates, you should refrain from 
** editing the SDK source code. If you need a change or
** bug fix, contact Santronics to investigate whether or
** not the bug was fixed or your change request should
** be considered as an official update to the SDK.
*********************************************************

#DEFINE WC_STATUS_BASE                                0x20000000
#DEFINE WC_SUCCESS                                    0
#DEFINE WC_UNSUPPORTED_VERSION                        WC_STATUS_BASE + 1
#DEFINE WC_CONTEXT_NOT_INITIALIZED                    WC_STATUS_BASE + 2
#DEFINE WC_INVALID_NODE_NUMBER                        WC_STATUS_BASE + 3
#DEFINE WC_USER_NOT_FOUND                             WC_STATUS_BASE + 4
#DEFINE WC_INCORRECT_PASSWORD                         WC_STATUS_BASE + 5
#DEFINE WC_USER_NOT_LOGGED_IN                         WC_STATUS_BASE + 6
#DEFINE WC_INVALID_INDEX                              WC_STATUS_BASE + 7
#DEFINE WC_INVALID_OBJECT_ID                          WC_STATUS_BASE + 8
#DEFINE WC_GROUP_ALREADY_EXISTS                       WC_STATUS_BASE + 9
#DEFINE WC_GROUP_NOT_FOUND                            WC_STATUS_BASE + 10
#DEFINE WC_OBSELETE_BY_502BETA                        WC_STATUS_BASE + 11
#DEFINE WC_OBJECTID_ALREADY_EXISTS                    WC_STATUS_BASE + 12
#DEFINE WC_NAME_NOT_FOUND                             WC_STATUS_BASE + 13
#DEFINE WC_NAME_ALREADY_EXISTS                        WC_STATUS_BASE + 14
#DEFINE WC_ALREADY_LOGGED_IN                          WC_STATUS_BASE + 15
#DEFINE WC_ITEM_NOT_FOUND                             WC_STATUS_BASE + 16
#DEFINE WC_ITEM_REQUIRES_NAME                         WC_STATUS_BASE + 17
#DEFINE WC_ITEM_ALREADY_EXISTS                        WC_STATUS_BASE + 18
#DEFINE WC_ITEM_NAME_DIFFERENT                        WC_STATUS_BASE + 19
#DEFINE WC_RECORD_NOT_FOUND                           WC_STATUS_BASE + 20
#DEFINE WC_ACCESS_DENIED                              WC_STATUS_BASE + 21
#DEFINE WC_NODE_ALREADY_IN_USE                        WC_STATUS_BASE + 22
#DEFINE WC_USER_ALREADY_LOGGED_IN                     WC_STATUS_BASE + 23
#DEFINE WC_INVALID_CONNECTION_ID                      WC_STATUS_BASE + 24
#DEFINE WC_INVALID_CONFERENCE                         WC_STATUS_BASE + 25
#DEFINE WC_INVALID_CONFERENCEGROUP                    WC_STATUS_BASE + 26
#DEFINE WC_INVALID_FILEAREA                           WC_STATUS_BASE + 27
#DEFINE WC_INVALID_FILEGROUP                          WC_STATUS_BASE + 28
#DEFINE WC_DUPLICATE_RECORD                           WC_STATUS_BASE + 29
#DEFINE WC_NO_ACTION_TAKEN                            WC_STATUS_BASE + 30
#DEFINE WC_ACCOUNT_LOCKED_OUT                         WC_STATUS_BASE + 31
#DEFINE WC_FILE_SEARCH_SYNTAX                         WC_STATUS_BASE + 32
#DEFINE WC_REQUEST_NOT_ADDED                          WC_STATUS_BASE + 33
#DEFINE WC_CONTEXT_MULTI_REFS                         WC_STATUS_BASE + 34
#DEFINE WC_CONTEXT_ALREADY_INITIALIZED                WC_STATUS_BASE + 35
#DEFINE WC_NO_NODES_AVAILABLE                         WC_STATUS_BASE + 36
#DEFINE WC_COMPUTERNAME_NOT_FOUND                     WC_STATUS_BASE + 37
#DEFINE WC_DBASE_IX_MISMATCH                          WC_STATUS_BASE + 38
#DEFINE WC_DBASE_UPDATE_ERROR                         WC_STATUS_BASE + 39
#DEFINE WC_DBASE_RESERVED40                           WC_STATUS_BASE + 40
#DEFINE WC_DBASE_RESERVED41                           WC_STATUS_BASE + 41
#DEFINE WC_DBASE_RESERVED42                           WC_STATUS_BASE + 42
#DEFINE WC_DBASE_RESERVED43                           WC_STATUS_BASE + 43
#DEFINE WC_USER_OUT_OF_TIME                           WC_STATUS_BASE + 44
#DEFINE WC_ACCOUNT_NOT_VALIDATED                      WC_STATUS_BASE + 45
#DEFINE WC_DOMAIN_ACCESS_DENIED                       WC_STATUS_BASE + 46
#DEFINE WC_BUFFER_TOO_SMALL                           WC_STATUS_BASE + 47
#DEFINE WC_DOMAIN_NOT_FOUND                           WC_STATUS_BASE + 48
#DEFINE WC_PASSWORD_EXPIRED                           WC_STATUS_BASE + 49
#DEFINE WC_PASSWORD_CHANGE_REQUIRED                   WC_STATUS_BASE + 50
#DEFINE WC_ANONYMOUS_DENIED                           WC_STATUS_BASE + 51
#DEFINE WC_HOURS_RESTRICTED                           WC_STATUS_BASE + 52
#DEFINE WC_SECURITY_NOT_FOUND                         WC_STATUS_BASE + 53
