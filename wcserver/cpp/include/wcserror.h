//*******************************************************************
// (c) Copyright 1999 Santronics Software, Inc. All Rights Reserved.
//*******************************************************************
//
// File Name : wcserror.h
// Created   :
// Programmer: HLS
// Original  : GDH
//
// Revision History:
// Build  Date     Author  Comments
// -----  -------- ------  -------------------------------
// 447             HLS     Cleaned up
// 447b2           HLS     new error #38
// 447b6           HLS     Comment about WC_INVALID_NODE_NUMBER
//                         WCSERVER will return this error if
//                         node numbers were available for the
//                         particular "server".  For example,
//                         I added SetServerState() state definitions
//                         along with a system control channel callback.
//                         If the server is marked down, you don't
//                         need to get the server state because
//                         any login attempt will return the invalid
//                         node number error.
//
// 451.9 10/02/06 HLS      Added WC_INVALID_USERNAME
// 454.6 07/25/17 HLS      Replaced WC_OBSELETE_BY_502BETA with WC_DBASE_NOT_AVAILABLE
//*******************************************************************

#ifndef __WCSERROR_H
#define __WCSERROR_H

const DWORD WC_STATUS_BASE = 0x20000000;

const DWORD WC_SUCCESS                     = 0; // HLS
const DWORD WC_UNSUPPORTED_VERSION         = WC_STATUS_BASE + 1;
const DWORD WC_CONTEXT_NOT_INITIALIZED     = WC_STATUS_BASE + 2;
const DWORD WC_INVALID_NODE_NUMBER         = WC_STATUS_BASE + 3;
const DWORD WC_USER_NOT_FOUND              = WC_STATUS_BASE + 4;
const DWORD WC_INCORRECT_PASSWORD          = WC_STATUS_BASE + 5;
const DWORD WC_USER_NOT_LOGGED_IN          = WC_STATUS_BASE + 6;
const DWORD WC_INVALID_INDEX               = WC_STATUS_BASE + 7;
const DWORD WC_INVALID_OBJECT_ID           = WC_STATUS_BASE + 8;
const DWORD WC_GROUP_ALREADY_EXISTS        = WC_STATUS_BASE + 9;
const DWORD WC_GROUP_NOT_FOUND             = WC_STATUS_BASE + 10; // A
const DWORD WC_DBASE_NOT_AVAILABLE         = WC_STATUS_BASE + 11; // B   // 454.6
const DWORD WC_OBJECTID_ALREADY_EXISTS     = WC_STATUS_BASE + 12; // C
const DWORD WC_NAME_NOT_FOUND              = WC_STATUS_BASE + 13; // D
const DWORD WC_NAME_ALREADY_EXISTS         = WC_STATUS_BASE + 14; // E
const DWORD WC_ALREADY_LOGGED_IN           = WC_STATUS_BASE + 15; // F
const DWORD WC_ITEM_NOT_FOUND              = WC_STATUS_BASE + 16; // 10
const DWORD WC_ITEM_REQUIRES_NAME          = WC_STATUS_BASE + 17; // 11
const DWORD WC_ITEM_ALREADY_EXISTS         = WC_STATUS_BASE + 18; // 12
const DWORD WC_ITEM_NAME_DIFFERENT         = WC_STATUS_BASE + 19; // 13
const DWORD WC_RECORD_NOT_FOUND            = WC_STATUS_BASE + 20; // 14
const DWORD WC_ACCESS_DENIED               = WC_STATUS_BASE + 21; // 15
const DWORD WC_NODE_ALREADY_IN_USE         = WC_STATUS_BASE + 22; // 16
const DWORD WC_USER_ALREADY_LOGGED_IN      = WC_STATUS_BASE + 23; // 17
const DWORD WC_INVALID_CONNECTION_ID       = WC_STATUS_BASE + 24; // 18
const DWORD WC_INVALID_CONFERENCE          = WC_STATUS_BASE + 25; // 19
const DWORD WC_INVALID_CONFERENCEGROUP     = WC_STATUS_BASE + 26; // 1A
const DWORD WC_INVALID_FILEAREA            = WC_STATUS_BASE + 27; // 1B
const DWORD WC_INVALID_FILEGROUP           = WC_STATUS_BASE + 28; // 1C
const DWORD WC_DUPLICATE_RECORD            = WC_STATUS_BASE + 29; // 1D
const DWORD WC_NO_ACTION_TAKEN             = WC_STATUS_BASE + 30; // 1E
const DWORD WC_ACCOUNT_LOCKED_OUT          = WC_STATUS_BASE + 31; // 1F
const DWORD WC_FILE_SEARCH_SYNTAX          = WC_STATUS_BASE + 32; // 20
const DWORD WC_REQUEST_NOT_ADDED           = WC_STATUS_BASE + 33; // 21
const DWORD WC_CONTEXT_MULTI_REFS          = WC_STATUS_BASE + 34; // 22
const DWORD WC_CONTEXT_ALREADY_INITIALIZED = WC_STATUS_BASE + 35; // 23
const DWORD WC_NO_NODES_AVAILABLE          = WC_STATUS_BASE + 36; // 24
const DWORD WC_COMPUTERNAME_NOT_FOUND      = WC_STATUS_BASE + 37; // 25
const DWORD WC_DBASE_IX_MISMATCH           = WC_STATUS_BASE + 38; // 26
const DWORD WC_DBASE_UPDATE_ERROR          = WC_STATUS_BASE + 39; // 27
const DWORD WC_DBASE_RESERVED40            = WC_STATUS_BASE + 40; // 28
const DWORD WC_DBASE_RESERVED41            = WC_STATUS_BASE + 41; // 29
const DWORD WC_DBASE_RESERVED42            = WC_STATUS_BASE + 42; // 2A
const DWORD WC_DBASE_RESERVED43            = WC_STATUS_BASE + 43; // 2B
const DWORD WC_USER_OUT_OF_TIME            = WC_STATUS_BASE + 44; // 2C
const DWORD WC_ACCOUNT_NOT_VALIDATED       = WC_STATUS_BASE + 45; /* 2D */
const DWORD WC_DOMAIN_ACCESS_DENIED        = WC_STATUS_BASE + 46; /* 2E */
const DWORD WC_BUFFER_TOO_SMALL            = WC_STATUS_BASE + 47; /* 2F */
const DWORD WC_DOMAIN_NOT_FOUND            = WC_STATUS_BASE + 48; /* 30 */
const DWORD WC_PASSWORD_EXPIRED            = WC_STATUS_BASE + 49; /* 31 */
const DWORD WC_PASSWORD_CHANGE_REQUIRED    = WC_STATUS_BASE + 50; /* 32 */
const DWORD WC_ANONYMOUS_DENIED            = WC_STATUS_BASE + 51; /* 33 */
const DWORD WC_HOURS_RESTRICTED            = WC_STATUS_BASE + 52; /* 34 */
const DWORD WC_SECURITY_NOT_FOUND          = WC_STATUS_BASE + 53; /* 35 */
const DWORD WC_INVALID_USERNAME            = WC_STATUS_BASE + 54; /* 36 */


#endif
