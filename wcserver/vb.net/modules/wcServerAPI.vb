Option Strict On
Option Explicit On

Imports System.Runtime.InteropServices

Module wcServerAPI

#Region "Credits ..."

	'// ------------------------------------------------------------------------
	'// (c) Copyright 1998-2019 by Santronics Software Inc. All Rights Reserved.
	'// Wildcat! SDK API v8.0.454.8
    '//
    '// CUSTOM/MANUALLY FIXED UNTIL WE GET A CPP2NET.CPP TRANSLATOR
    '//
    '// ------------------------------------------------------------------------

#End Region

#Region "Public Windows Structures ..."

    Public Structure FileTime
        Public dwLowDateTime As Integer
        Public dwHighDateTime As Integer
    End Structure

    Public Structure SYSTEMTIME
        Public wYear As Short
        Public wMonth As Short
        Public wDayOfWeek As Short
        Public wDay As Short
        Public wHour As Short
        Public wMinute As Short
        Public wSecond As Short
        Public wMilliseconds As Short
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Structure WIN32_FIND_DATA
        Public dwFileAttributes As Integer
        Public ftCreationTime As FileTime
        Public ftLastAccessTime As FileTime
        Public ftLastWriteTime As FileTime
        Public nFileSizeHigh As Integer
        Public nFileSizeLow As Integer
        Public dwReserved0 As Integer
        Public dwReserved1 As Integer
        <MarshalAs(UnmanagedType.ByValTStr, sizeconst:=MAX_PATH)> Public cFileName As String
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=14)> Public cAlternateFileName As String
    End Structure

#End Region

#Region "Public Windows DLL Imports"

    <DllImport("kernel32.dll", SetLastError:=True)> Public Function FileTimeToSystemTime(ByRef lpFileTime As FileTime, ByRef lpSystemTime As SYSTEMTIME) As Integer
    End Function
    <DllImport("kernel32.dll", SetLastError:=True)> Public Function SystemTimeToFileTime(ByRef lpSystemTime As SYSTEMTIME, ByRef lpFileTime As FileTime) As Integer
    End Function
    <DllImport("kernel32.dll", SetLastError:=True)> Public Function GetLastError() As Long
    End Function
    <DllImport("kernel32.dll", SetLastError:=True)> Public Function GetCurrentThreadId() As Long
    End Function

#End Region

#Region "Public WINServer API Constants ..."

    '//!
    '//! WC DLL Error Values
    '//!
    Public Const WC_STATUS_BASE As Integer = &H20000000
    Public Const WC_SUCCESS As Integer = 0
    Public Const WC_UNSUPPORTED_VERSION As Integer = WC_STATUS_BASE + 1
    Public Const WC_CONTEXT_NOT_INITIALIZED As Integer = WC_STATUS_BASE + 2
    Public Const WC_INVALID_NODE_NUMBER As Integer = WC_STATUS_BASE + 3
    Public Const WC_USER_NOT_FOUND As Integer = WC_STATUS_BASE + 4
    Public Const WC_INCORRECT_PASSWORD As Integer = WC_STATUS_BASE + 5
    Public Const WC_USER_NOT_LOGGED_IN As Integer = WC_STATUS_BASE + 6
    Public Const WC_INVALID_INDEX As Integer = WC_STATUS_BASE + 7
    Public Const WC_INVALID_OBJECT_ID As Integer = WC_STATUS_BASE + 8
    Public Const WC_GROUP_ALREADY_EXISTS As Integer = WC_STATUS_BASE + 9
    Public Const WC_GROUP_NOT_FOUND As Integer = WC_STATUS_BASE + 10
    Public Const WC_OBSELETE_BY_502BETA As Integer = WC_STATUS_BASE + 11
    Public Const WC_OBJECTID_ALREADY_EXISTS As Integer = WC_STATUS_BASE + 12
    Public Const WC_NAME_NOT_FOUND As Integer = WC_STATUS_BASE + 13
    Public Const WC_NAME_ALREADY_EXISTS As Integer = WC_STATUS_BASE + 14
    Public Const WC_ALREADY_LOGGED_IN As Integer = WC_STATUS_BASE + 15
    Public Const WC_ITEM_NOT_FOUND As Integer = WC_STATUS_BASE + 16
    Public Const WC_ITEM_REQUIRES_NAME As Integer = WC_STATUS_BASE + 17
    Public Const WC_ITEM_ALREADY_EXISTS As Integer = WC_STATUS_BASE + 18
    Public Const WC_ITEM_NAME_DIFFERENT As Integer = WC_STATUS_BASE + 19
    Public Const WC_RECORD_NOT_FOUND As Integer = WC_STATUS_BASE + 20
    Public Const WC_ACCESS_DENIED As Integer = WC_STATUS_BASE + 21
    Public Const WC_NODE_ALREADY_IN_USE As Integer = WC_STATUS_BASE + 22
    Public Const WC_USER_ALREADY_LOGGED_IN As Integer = WC_STATUS_BASE + 23
    Public Const WC_INVALID_CONNECTION_ID As Integer = WC_STATUS_BASE + 24
    Public Const WC_INVALID_CONFERENCE As Integer = WC_STATUS_BASE + 25
    Public Const WC_INVALID_CONFERENCEGROUP As Integer = WC_STATUS_BASE + 26
    Public Const WC_INVALID_FILEAREA As Integer = WC_STATUS_BASE + 27
    Public Const WC_INVALID_FILEGROUP As Integer = WC_STATUS_BASE + 28
    Public Const WC_DUPLICATE_RECORD As Integer = WC_STATUS_BASE + 29
    Public Const WC_NO_ACTION_TAKEN As Integer = WC_STATUS_BASE + 30
    Public Const WC_ACCOUNT_LOCKED_OUT As Integer = WC_STATUS_BASE + 31
    Public Const WC_FILE_SEARCH_SYNTAX As Integer = WC_STATUS_BASE + 32
    Public Const WC_REQUEST_NOT_ADDED As Integer = WC_STATUS_BASE + 33
    Public Const WC_CONTEXT_MULTI_REFS As Integer = WC_STATUS_BASE + 34
    Public Const WC_CONTEXT_ALREADY_INITIALIZED As Integer = WC_STATUS_BASE + 35
    Public Const WC_NO_NODES_AVAILABLE As Integer = WC_STATUS_BASE + 36
    Public Const WC_COMPUTERNAME_NOT_FOUND As Integer = WC_STATUS_BASE + 37
    Public Const WC_DBASE_IX_MISMATCH As Integer = WC_STATUS_BASE + 38
    Public Const WC_DBASE_UPDATE_ERROR As Integer = WC_STATUS_BASE + 39
    Public Const WC_DBASE_RESERVED40 As Integer = WC_STATUS_BASE + 40
    Public Const WC_DBASE_RESERVED41 As Integer = WC_STATUS_BASE + 41
    Public Const WC_DBASE_RESERVED42 As Integer = WC_STATUS_BASE + 42
    Public Const WC_DBASE_RESERVED43 As Integer = WC_STATUS_BASE + 43
    Public Const WC_USER_OUT_OF_TIME As Integer = WC_STATUS_BASE + 44
    Public Const WC_ACCOUNT_NOT_VALIDATED As Integer = WC_STATUS_BASE + 45
    Public Const WC_DOMAIN_ACCESS_DENIED As Integer = WC_STATUS_BASE + 46
    Public Const WC_BUFFER_TOO_SMALL As Integer = WC_STATUS_BASE + 47
    Public Const WC_DOMAIN_NOT_FOUND As Integer = WC_STATUS_BASE + 48
    Public Const WC_PASSWORD_EXPIRED As Integer = WC_STATUS_BASE + 49
    Public Const WC_PASSWORD_CHANGE_REQUIRED As Integer = WC_STATUS_BASE + 50
    Public Const WC_ANONYMOUS_DENIED As Integer = WC_STATUS_BASE + 51
    Public Const WC_HOURS_RESTRICTED As Integer = WC_STATUS_BASE + 52
    Public Const WC_SECURITY_NOT_FOUND As Integer = WC_STATUS_BASE + 53
    Public Const WC_INVALID_USERNAME As Integer = WC_STATUS_BASE + 54

    Public Const MAX_PATH As Integer = 260

    Public Const SIZE_VOLUME_NAME As Integer = 16
    Public Const SIZE_CALLTYPE As Integer = 32
    Public Const SIZE_COMPUTER_NAME As Integer = 16
    Public Const SIZE_CONFERENCE_NAME As Integer = 60
    Public Const SIZE_CONFERENCEGROUP_NAME As Integer = 32
    Public Const SIZE_DOMAIN_NAME As Integer = 64
    Public Const SIZE_DOOR_NAME As Integer = 40
    Public Const SIZE_ENCODED_PASSWORD As Integer = 20
    Public Const SIZE_EXTENSION As Integer = 4
    Public Const SIZE_FILEAREA_NAME As Integer = 32
    Public Const SIZE_FILEGROUP_NAME As Integer = 32
    Public Const SIZE_LANGUAGE_NAME As Integer = 12
    Public Const SIZE_MENU_DESCRIPTION As Integer = 40
    Public Const SIZE_MODEM_NAME As Integer = 32
    Public Const SIZE_PASSWORD As Integer = 32
    Public Const SIZE_SASL_NAME As Integer = 32
    Public Const SIZE_SECURITY_NAME As Integer = 24
    Public Const SIZE_SERVICE_NAME As Integer = 64
    Public Const SIZE_USER_NAME As Integer = 72
    Public Const MAX_USER_NAME As Integer = 28
    Public Const CHANNEL_MESSAGE_HEADER_SIZE As Integer = 12
    Public Const MAX_CHANNEL_MESSAGE_SIZE As Integer = 500
    Public Const SIZE_PACKER_DESCRIPTION As Integer = 32
    Public Const SIZE_PACKER_COMMAND As Integer = 40
    Public Const MAX_PACKER_COUNT As Integer = 10
    Public Const SIZE_MAKEWILD_BBSNAME As Integer = 52
    Public Const SIZE_MAKEWILD_CITY As Integer = 32
    Public Const SIZE_MAKEWILD_PHONE As Integer = 28
    Public Const SIZE_MAKEWILD_FIRSTCALL As Integer = 28
    Public Const SIZE_MAKEWILD_PACKETID As Integer = 12
    Public Const SIZE_MAKEWILD_REGSTRING As Integer = 8

    Public Const WILDCAT_FRAMEWORK_VERSION As Integer = 1
    Public Const WILDCAT_MKTG_VERSION As Integer = 6
    Public Const WILDCAT_COMPONENT_ICP As Integer = &H1
    Public Const WILDCAT_COMPONENT_SSL As Integer = &H2

    '//!--------------------------------------------------------------
    '//! SPECIAL NOTE ABOUT LONG vs SHORT FILE NAMES
    '//!
    '//! - v5.5 - File Database Only
    '//!
    '//!    MAX_PATH long file name support was implemented in v5.5
    '//!    Database conversion was required since TFileRecord size
    '//!    was changed
    '//!
    '//! - v6.1.451.9 - Message Database Only (Native storage)
    '//!
    '//!   A 80 (79 + 1 null) semi-long file name was implemented
    '//!   in v6.1.451.9 for TMsgHeader.Attachment.  The old
    '//!   short file name field was renamed to TMsgHeader.AttachmentSFN
    '//!
    '//!   Developers can use a sizeof(TMsgHeader.Header) check to see
    '//!   what is the current size of the API.
    '//!
    '//!--------------------------------------------------------------
    Public Const SIZE_SHORT_FILE_NAME As Integer = 16
    Public Const SIZE_LONG_FILE_NAME As Integer = MAX_PATH
    Public Const SIZE_ATTACH_FILE_NAME As Integer = 80

    '//!--------------------------------------------------------------------
    '//! Access Profiles Class Object identifiers (COID).
    '//! COIDS are used to identify a group/class of objects.
    '//!--------------------------------------------------------------------
    Public Const MASK_OBJECTCLASS As Integer = &HFF000000
    Public Const OBJECTCLASS_RIGHTS As Integer = &H1000000
    Public Const OBJECTCLASS_CONFERENCE As Integer = &H2000000
    Public Const OBJECTCLASS_CONFERENCEGROUP As Integer = &H3000000
    Public Const OBJECTCLASS_FILEAREA As Integer = &H4000000
    Public Const OBJECTCLASS_FILEGROUP As Integer = &H5000000
    Public Const OBJECTCLASS_DOOR As Integer = &H6000000
    Public Const OBJECTCLASS_MENU As Integer = &H7000000
    Public Const OBJECTCLASS_CODE As Integer = &H8000000
    Public Const OBJECTCLASS_CLIENT As Integer = &H9000000
    Public Const OBJECTCLASS_SAPPHIRE_QUERY As Integer = &HA000000
    Public Const OBJECTCLASS_CHAT_CHANNEL As Integer = &HB000000
    Public Const OBJECTCLASS_RADIUS_CLIENT As Integer = &HC000000
    Public Const OBJECTCLASS_DOMAINS As Integer = &HD000000

    '//!--------------------------------------------------------------------
    '//! Access Profiles Object identifiers (OID).
    '//! Use with GetObjectFlags() during user sessions to determine if
    '//! logged in user has access to specific functionalities identified
    '//! by the OIDs
    '//!--------------------------------------------------------------------
    Public Const OBJECTID_BULLETINS_OPTIONAL As Integer = OBJECTCLASS_RIGHTS + 1
    Public Const OBJECTID_CHANGE_PHONE As Integer = OBJECTCLASS_RIGHTS + 2
    Public Const OBJECTID_CHANGE_BIRTHDATE As Integer = OBJECTCLASS_RIGHTS + 4
    Public Const OBJECTID_QWK_ALLOW_BULLETINS As Integer = OBJECTCLASS_RIGHTS + 5
    Public Const OBJECTID_QWK_ALLOW_NEWS As Integer = OBJECTCLASS_RIGHTS + 6
    Public Const OBJECTID_QWK_ALLOW_FILES As Integer = OBJECTCLASS_RIGHTS + 7
    Public Const OBJECTID_QWK_DETAIL_DOWNLOAD As Integer = OBJECTCLASS_RIGHTS + 8
    Public Const OBJECTID_QWK_CHECK_DUPES As Integer = OBJECTCLASS_RIGHTS + 9
    Public Const OBJECTID_QWK_SAVE_PACKETS As Integer = OBJECTCLASS_RIGHTS + 10
    Public Const OBJECTID_MASTER_SYSOP As Integer = OBJECTCLASS_RIGHTS + 11
    Public Const OBJECTID_RATIO_ACTION As Integer = OBJECTCLASS_RIGHTS + 12
    Public Const OBJECTID_ALLOW_FAST_LOGIN As Integer = OBJECTCLASS_RIGHTS + 13
    Public Const OBJECTID_ALLOW_OVERWRITE_FILES As Integer = OBJECTCLASS_RIGHTS + 14
    Public Const OBJECTID_SHOW_PASSWORD_FILES As Integer = OBJECTCLASS_RIGHTS + 15
    Public Const OBJECTID_ALLOW_OFFLINE_FILE_REQUESTS As Integer = OBJECTCLASS_RIGHTS + 16
    Public Const OBJECTID_ALLOW_UPLOAD_OVER_TIME As Integer = OBJECTCLASS_RIGHTS + 17
    Public Const OBJECTID_ALLOW_DOWNLOAD_OVER_TIME As Integer = OBJECTCLASS_RIGHTS + 18
    Public Const OBJECTID_ALLOW_UPLOADER_MODIFY_FILE As Integer = OBJECTCLASS_RIGHTS + 20
    Public Const OBJECTID_QWK_NETSTATUS As Integer = OBJECTCLASS_RIGHTS + 26
    Public Const OBJECTID_SYSOP_READ_PRIVATE_MAIL As Integer = OBJECTCLASS_RIGHTS + 27
    Public Const OBJECTID_ALLOW_INTERNET_EMAIL As Integer = OBJECTCLASS_RIGHTS + 28
    Public Const OBJECTID_ALLOW_ANY_TELNET As Integer = OBJECTCLASS_RIGHTS + 29
    Public Const OBJECTID_ALLOW_ANY_FTP As Integer = OBJECTCLASS_RIGHTS + 30
    Public Const OBJECTID_ALLOW_HTTP_PROXY As Integer = OBJECTCLASS_RIGHTS + 31
    Public Const OBJECTID_ALLOW_ALL_IP As Integer = OBJECTCLASS_RIGHTS + 32
    Public Const OBJECTID_ALLOW_DEFAULT_IP As Integer = OBJECTCLASS_RIGHTS + 33
    Public Const OBJECTID_ALLOW_PPP As Integer = OBJECTCLASS_RIGHTS + 34
    Public Const OBJECTID_IGNORE_TIME_ONLINE As Integer = OBJECTCLASS_RIGHTS + 35
    Public Const OBJECTID_IGNORE_IDLE_TIME As Integer = OBJECTCLASS_RIGHTS + 36
    Public Const OBJECTID_ALLOW_SMTP_AUTH As Integer = OBJECTCLASS_RIGHTS + 37
    Public Const OBJECTID_ALLOW_NNTP_ACCESS As Integer = OBJECTCLASS_RIGHTS + 38
    Public Const OBJECTID_USERBIN_ACCESS As Integer = OBJECTCLASS_RIGHTS + 39
    Public Const OBJECTID_ALLOW_FTP_ACCESS As Integer = OBJECTCLASS_RIGHTS + 40
    Public Const OBJECTID_ALLOW_WEB_ACCESS As Integer = OBJECTCLASS_RIGHTS + 41
    Public Const OBJECTID_ALLOW_TELNET_ACCESS As Integer = OBJECTCLASS_RIGHTS + 42
    Public Const OBJECTID_CHANGE_EMAILADDRESS As Integer = OBJECTCLASS_RIGHTS + 43
    Public Const OBJECTID_CHANGE_SMTPFORWARD As Integer = OBJECTCLASS_RIGHTS + 44
    Public Const OBJECTID_ALLOW_CC_GROUPS As Integer = OBJECTCLASS_RIGHTS + 45
    Public Const OBJECTID_PROTOCOL_ACCESS As Integer = OBJECTCLASS_RIGHTS + &H10000
    Public Const OBJECTID_NODE_ACCESS As Integer = OBJECTCLASS_RIGHTS + &H20000
    Public Const OBJECTFLAGS_CONFERENCE_JOIN As Integer = &H1S
    Public Const OBJECTFLAGS_CONFERENCE_READ As Integer = &H2S
    Public Const OBJECTFLAGS_CONFERENCE_WRITE As Integer = &H4S
    Public Const OBJECTFLAGS_CONFERENCE_SYSOP As Integer = &H8S
    Public Const OBJECTFLAGS_FILEAREA_LIST As Integer = &H1S
    Public Const OBJECTFLAGS_FILEAREA_DOWNLOAD As Integer = &H2S
    Public Const OBJECTFLAGS_FILEAREA_UPLOAD As Integer = &H4S
    Public Const OBJECTFLAGS_FILEAREA_SYSOP As Integer = &H8S

    '//!
    '//! MessageSearch() search attributes
    '//!
    Public Const MSF_FORWARD As Integer = &H1S
    Public Const MSF_FROM As Integer = &H2S
    Public Const MSF_TO As Integer = &H4S
    Public Const MSF_SUBJECT As Integer = &H8S
    Public Const MSF_BODY As Integer = &H10S

    '//!
    '//! wcBASIC Telnet connection options
    '//!
    Public Const CONNECT_RAW As Integer = 0
    Public Const CONNECT_TELNET_ASCII As Integer = 1
    Public Const CONNECT_TELNET_7BIT As Integer = 2
    Public Const CONNECT_TELNET_8BIT As Integer = 3

    '//!
    '//! User Database Function Keys
    '//!
    Public Const UserIdKey As Integer = 0
    Public Const UserNameKey As Integer = 1
    Public Const UserLastNameKey As Integer = 2
    Public Const UserSecurityKey As Integer = 3

    '//!
    '//! Files Database Function Keys
    '//!
    Public Const FileNameAreaKey As Integer = 0
    Public Const FileAreaNameKey As Integer = 1
    Public Const FileAreaDateKey As Integer = 2
    Public Const FileUploaderKey As Integer = 3
    Public Const FileDateAreaKey As Integer = 4

    '//!
    '//! System Operation Type
    '//!
    Public Const saOpen As Short = 0
    Public Const saClosed As Short = 1
    Public Const saClosedQuestionnaire As Short = 2
    Public Const saClosedValidation As Short = 3
    Public Const dusNone As Short = 0
    Public Const dusAsk As Short = 1
    Public Const dusAllow As Short = 2
    Public Const mhcUpperCase As Short = 0
    Public Const mhcLowerCase As Short = 1
    Public Const mhcAsIs As Short = 2

    '//!
    '//! LogPeriod options
    '//!
    Public Const wclogNone As Short = 0
    Public Const wclogHourly As Short = 1
    Public Const wclogDaily As Short = 2
    Public Const wclogWeekly As Short = 3
    Public Const wclogMonthly As Short = 4
    Public Const wclogUnlimitedSize As Short = 5
    Public Const wclogMaxSize As Short = 6

    Public Const pNone As Short = 0
    Public Const pAscii As Short = 1
    Public Const pXmodem As Short = 2
    Public Const pXmodemCRC As Short = 3
    Public Const pXmodem1K As Short = 4
    Public Const pXmodem1KG As Short = 5
    Public Const pYmodem As Short = 6
    Public Const pYmodemG As Short = 7
    Public Const pKermit As Short = 8
    Public Const pZmodem As Short = 9
    Public Const NumProtocols As Short = 10
    Public Const fiaAllow As Short = 0
    Public Const fiaLogoff As Short = 1
    Public Const fiaLockout As Short = 2

    '//!
    '//! Password Bit Options for Security Profile and User Record
    '//!
    Public Const pwdChangeForce As Integer = &H1S
    Public Const pwdChangeDisallow As Integer = &H2S
    Public Const pwdChangeExpire As Integer = &H4S
    Public Const pwdExpireLockout As Integer = &H8S
    Public Const pwdAttemptsLockout As Integer = &H10

    Public Const lh12am As Integer = &H1S
    Public Const lh1am As Integer = &H2S
    Public Const lh2am As Integer = &H4S
    Public Const lh3am As Integer = &H8S
    Public Const lh4am As Integer = &H10S
    Public Const lh5am As Integer = &H20S
    Public Const lh6am As Integer = &H40S
    Public Const lh7am As Integer = &H80S
    Public Const lh8am As Integer = &H100S
    Public Const lh9am As Integer = &H200S
    Public Const lh10am As Integer = &H400S
    Public Const lh11am As Integer = &H800S
    Public Const lh12pm As Integer = &H1000S
    Public Const lh1pm As Integer = &H2000S
    Public Const lh2pm As Integer = &H4000S
    Public Const lh3pm As Integer = &H8000S
    Public Const lh4pm As Integer = &H10000
    Public Const lh5pm As Integer = &H20000
    Public Const lh6pm As Integer = &H40000
    Public Const lh7pm As Integer = &H80000
    Public Const lh8pm As Integer = &H100000
    Public Const lh9pm As Integer = &H200000
    Public Const lh10pm As Integer = &H400000
    Public Const lh11pm As Integer = &H800000
    Public Const lhAllHours As Integer = &HFFFFFF
    Public Const lhSun As Integer = &H1S
    Public Const lhMon As Integer = &H2S
    Public Const lhTue As Integer = &H4S
    Public Const lhWed As Integer = &H8S
    Public Const lhThu As Integer = &H10S
    Public Const lhFri As Integer = &H20S
    Public Const lhSat As Integer = &H40S
    Public Const lhAllDays As Integer = &H7FS
    Public Const lhStartofWeek As Integer = lhSun
    Public Const lhEndofWeek As Integer = lhSat
    Public Const SIZE_CONFERENCE_ECHOTAG As Integer = 64
    Public Const mtNormalPublicPrivate As Short = 0
    Public Const mtNormalPublic As Short = 1
    Public Const mtNormalPrivate As Short = 2
    Public Const mtFidoNetmail As Short = 3
    Public Const mtEmailOnly As Short = 4
    Public Const mtUsenetNewsgroup As Short = 5
    Public Const mtUsenetNewsgroupModerated As Short = 6
    Public Const mtInternetMailingList As Short = 7
    Public Const mtFidoEcho As Short = 8
    Public Const mtListServeForum As Short = 9
    Public Const mtUserEmail As Short = 10
    Public Const mtEND As Short = 256
    Public Const vnYes As Short = 0
    Public Const vnNo As Short = 1
    Public Const vnPrompt As Short = 2

    '//! //! 449.5 //! The following maXXXXXXXXX bit flags are used in the
    '//! TConfDesc.Options field. //!
    Public Const maAllowMailSnooping As Integer = &H1
    Public Const maPreserveMime As Integer = &H2
    Public Const maAllowReplyOnly As Integer = &H4

    '//!
    '//! 449.5
    '//! Option for TConfDesc.AuthorType field. This will define the
    '//! conference option for how the From field will be defined when
    '//! a message is created.
    '//!
    Public Const authorDefaultName As Short = 0
    Public Const authorForceUserName As Short = 1
    Public Const authorForceAliasName As Short = 2
    Public Const authorAllowBoth As Short = 3
    Public Const authorAnonymousName As Short = 4

    '//!
    '//! 449.5
    '//! TFileArea.Options attributes
    '//!
    Public Const faIsVolume As Integer = &H1S
    Public Const faAllowPrivateFiles As Integer = &H2
    Public Const faAllowFolderWatch As Integer = &H4

    Public Const dtGeneric16 As Short = 0
    Public Const dtDoor32 As Short = 1
    Public Const dtDoorway As Short = 2

    Public Const CALLTYPE_LOCAL As Integer = &H1S
    Public Const CALLTYPE_DIALUP As Integer = &H2S
    Public Const CALLTYPE_TELNET As Integer = &H4S
    Public Const CALLTYPE_FTP As Integer = &H8S
    Public Const CALLTYPE_HTTP As Integer = &H10S
    Public Const CALLTYPE_FRONTEND As Integer = &H20S
    Public Const CALLTYPE_POP3 As Integer = &H40S
    Public Const CALLTYPE_SMTP As Integer = &H80S
    Public Const CALLTYPE_PPP As Integer = &H100S
    Public Const CALLTYPE_RADIUS As Integer = &H200S
    Public Const CALLTYPE_NNTP As Integer = &H400S
    Public Const CALLTYPE_HTTPS As Integer = &H800

    Public Const SIZE_NODECONFIG_COMPUTER As Integer = 16
    Public Const SIZE_NODECONFIG_PORTNAME As Integer = 16
    Public Const SIZE_LANGUAGE_DESCRIPTION As Integer = 72
    Public Const MAX_LANGUAGE_SUBCOMMAND_CHARS As Integer = 100
    Public Const LSC_YES As Integer = 0
    Public Const LSC_NO As Integer = 1
    Public Const SIZE_MODEM_STRING As Integer = 64
    Public Const aRing As Short = 0
    Public Const aResult As Short = 1
    Public Const aAutoAnswer As Short = 2
    Public Const SIZE_SERVERSTATE_PORT As Integer = 80
    Public Const SERVERSTATE_OFFLINE As Integer = 0
    Public Const SERVERSTATE_DOWN As Integer = 1
    Public Const SERVERSTATE_REFUSE As Integer = 2
    Public Const SERVERSTATE_UP As Integer = 3
    Public Const MENU_TOPLEVEL As Integer = &H2S
    Public Const MAX_MENU_ITEMS As Integer = 40
    Public Const SIZE_MENUITEM_SELECTION As Integer = 16
    Public Const SIZE_MENUITEM_DESCRIPTION As Integer = 32
    Public Const SIZE_MENUITEM_COMMAND As Integer = 48
    Public Const SIZE_USER_TITLE As Integer = 12
    Public Const clSessionNone As Short = 0
    Public Const clSessionUser As Short = 1
    Public Const clSessionSystem As Short = 2
    Public Const clSessionConfig As Short = 3
    Public Const nsDown As Short = 0
    Public Const nsUp As Short = 1
    Public Const nsSigningOn As Short = 2
    Public Const nsLoggedIn As Short = 3
    Public Const nsProcessingEvent As Short = 4
    Public Const nsForceDown As Short = 5
    Public Const SIZE_NODEINFO_ACTIVITY As Integer = 32
    Public Const SIZE_NODEINFO_SPEED As Integer = 8
    Public Const SIZE_NODEINFO_LASTCALLER As Integer = 48
    Public Const SIZE_USER_FROM As Integer = 32
    Public Const ucstNone As Integer = 0
    Public Const ucstPersonal As Integer = 1
    Public Const ucstPersonalAll As Integer = 2
    Public Const ucstAll As Integer = 3
    Public Const ucstMask As Integer = &HFS
    Public Const ucfReserved1 As Integer = &H10S
    Public Const ucfReserved2 As Integer = &H20S
    Public Const ucfReserved3 As Integer = &H40S
    Public Const ucfAllAttach As Integer = &H80S
    Public Const SIZE_USER_PHONE As Integer = 16
    Public Const SIZE_USER_ADDRESS As Integer = 32
    Public Const SIZE_USER_STATE As Integer = 16
    Public Const SIZE_USER_ZIP As Integer = 12
    Public Const NUM_USER_SECURITY As Integer = 10
    Public Const sNotDisclosed As Short = 0
    Public Const sMale As Short = 1
    Public Const sFemale As Short = 2
    Public Const ePrompt As Short = 0
    Public Const eLine As Short = 1
    Public Const eFullScreen As Short = 2
    Public Const hlNovice As Short = 0
    Public Const hlRegular As Short = 1
    Public Const hlExpert As Short = 2
    Public Const ttAuto As Short = 0
    Public Const ttTTY As Short = 1
    Public Const ttAnsi As Short = 2
    Public Const fdSingle As Short = 0
    Public Const fdDouble As Short = 1
    Public Const fdFull As Short = 2
    Public Const fdAnsi As Short = 3
    Public Const mdScroll As Short = 0
    Public Const mdClear As Short = 1
    Public Const mdKeepHeader As Short = 2
    Public Const ptText As Short = 0
    Public Const ptQwk As Short = 1
    Public Const ptOPX As Short = 2

    '//!
    '//! User validation states for ssClosedValidation setup
    '//!
    Public Const vsNone As Short = 0
    Public Const vsValidationRequired As Short = 1
    Public Const vsPrevalidated As Short = 2
    Public Const vsValidated As Short = 3

    Public Const SIZE_MESSAGE_SUBJECT As Integer = 72
    Public Const SIZE_MESSAGE_NETWORK As Integer = 12

    '//!
    '//! The following mfXXXXXXXXX bit flags are used in the
    '//! TMsgHeader.MailFlags field.  Bits are defined as required
    '//! for unique/special mail processing.
    '//!
    Public Const mfPOP3Received As Integer = &H1000000
    Public Const mfReceiptCreated As Integer = &H2000000
    Public Const mfSmtpDelivered As Integer = &H4000000
    Public Const mfNNTPPost As Integer = &H8000000
    Public Const mfMimeSaved As Integer = &H1S
    Public Const mfNoDupeChecking As Integer = &H2
    Public Const mfNoReplying As Integer = &H4

    Public Const SIZE_FILE_DESCRIPTION As Integer = 76
    Public Const MAX_FILE_LONGDESC_LINES As Integer = 15
    Public Const SIZE_FILE_LONGDESC As Integer = 80
    Public Const ffAbortedUpload As Integer = &H1S

    '//!
    '//! System.Control or System.Control.# Signals
    '//!
    Public Const SC_WATCH_REQUEST As Integer = 0
    Public Const SC_DISPLAY_UPDATE As Integer = 1
    Public Const SC_PUSH_KEY As Integer = 2
    Public Const SC_SECURITY_CHANGE As Integer = 3
    Public Const SC_DISCONNECT As Integer = 4
    Public Const SC_TIME_CHANGE As Integer = 5
    Public Const SC_USER_RECORD_CHANGE As Integer = 6

    '//!
    '//! System.Event Signals: File Database Signals
    '//!
    Public Const SE_FILE_UPLOAD As Integer = 10
    Public Const SE_FILE_DOWNLOAD As Integer = 11
    Public Const SE_FILE_DELETE As Integer = 12
    Public Const SE_FILE_UPDATE As Integer = 13

    '//!
    '//! System.Event Signals: Miscellaneous Client Control Signals
    '//! Note: Currently, there is no implementation. However, the
    '//! signals are defined to begin a standard signal number set.
    '//!
    Public Const SE_SHUTDOWN_REQUEST As Integer = 20
    Public Const SE_RESTART As Integer = 21
    Public Const SE_CONFIG_CHANGE As Integer = 22
    Public Const SE_POPCONNECT As Integer = 23

    '//!
    '//! System.Event Signals: Server Status Change
    '//!
    Public Const SE_SERVER_STATE_CHANGE As Integer = 30
    Public Const SE_NODE_STATE_CHANGE As Integer = 31

    '//!
    '//! System.MailServer Signals: This channel is specifically
    '//! designed for events between wcmail/wcsmtp and configuration
    '//! components so that wcmail/wcsmtp can automatically reread
    '//! internal data.  NOTE: wcSMTP port info changes requires
    '//! a restart. Only non-essential data is reread
    '//!
    Public Const SE_MAILSERVER_UPDATE As Integer = 40

    Public Const SP_USER_PAGE As Integer = 0
    Public Const SP_SYSOP_CHAT As Integer = 1
    Public Const SP_NEW_MESSAGE As Integer = 2
    Public Const SP_ALT_NUMBER_FILE As Integer = 3

    Public Const listUnixFormat As Integer = 0
    Public Const listMSDOSFormat As Integer = 1

    Public Const SIZE_SYSTEMPAGE_LINES As Integer = 3
    Public Const SIZE_SYSTEMPAGE_TEXT As Integer = 80

    Public Const ipfilterDeny As Integer = 0
    Public Const ipfilterAllow As Integer = 1
    Public Const ipfilterNone As Integer = 2

    '//!
    '//! TWildcatPOP3.dwOptions Bit Flags
    '//!
    Public Const pop3MarkRcvd As Integer = &H1
    Public Const pop3HonorRR As Integer = &H2
    Public Const pop3ResolveHost As Integer = &H20

    '//!
    '//! TWildcatSMTP.dwOptions Bit Flags
    '//!
    Public Const smtpBit0 As Integer = &H1
    Public Const smtpRcvdBin As Integer = &H2
    Public Const smtpNoMXOnce As Integer = &H4
    Public Const smtpIpFilter As Integer = &H8
    Public Const smtpIncMXTries As Integer = &H10
    Public Const smtpResolveHost As Integer = &H20
    Public Const smtpDisableETRN As Integer = &H40
    Public Const smtpAllowLocal As Integer = &H80
    Public Const smtpCheckHello As Integer = &H100
    Public Const smtpEnableWCSAP As Integer = &H200
    Public Const smtpEnableSFHook As Integer = &H400
    Public Const smtpUsePort587 As Integer = &H800

    '//!
    '//! TWildcatFTP.dwOptions Bit Flags
    '//!
    Public Const ftpBit0 As Integer = &H1
    Public Const ftpUnixFileAge As Integer = &H2
    Public Const ftpUseFtpLimit As Integer = &H4
    Public Const ftpCheckForDIZ As Integer = &H8
    Public Const ftpResolveHost As Integer = &H20
    Public Const ftpDisableIndex As Integer = &H40

    '//!
    '//! TWildcatNNTP.dwOptions Bit Flags
    '//!
    Public Const nntpAllowAnony As Integer = &H1
    Public Const nntpResolveHost As Integer = &H20

    '//!
    '//! TWildcatHttpd.dwOptions Bit Flags
    '//!
    Public Const httpEnableProxy As Integer = &H1
    Public Const httpCommonLogFile As Integer = &H2
    Public Const httpDeutschIVW As Integer = &H4
    Public Const httpResolveHost As Integer = &H20
    Public Const httpEnableChunking As Integer = &H8

    '//!
    '//! TWildcatTelnet.dwOptions Bit Flags
    '//!
    Public Const telnetEnableRLogin As Integer = &H1
    Public Const telnetResolveHost As Integer = &H20

    '//! v5.5.450.3
    '//! Options and structures for Wildcat! SASL Authentication functions.
    '//!
    Public Const WCSASL_SUCCESS As Integer = 0
    Public Const WCSASL_AUTH_OK As Integer = WCSASL_SUCCESS
    Public Const WCSASL_AUTH_FAIL As Integer = 1
    Public Const WCSASL_INVALID_METHOD As Integer = 2
    Public Const WCSASL_GET_RESPONSE As Integer = 3
    Public Const WCSASL_GET_PASSWORD As Integer = 4
    Public Const WCSASL_LOOKUPUSER As Integer = 5

    '//!
    '//! TWildcatSASLContext.dwOptions Bit Flags
    '//!
    Public Const saslTranslate As Integer = &H1
    Public Const saslTranslateBoth As Integer = &H11

#End Region

#Region "Public Structures created to get around conversion issues ..."

#Region "TmodemProfile Changes ..."

    '//====[TModemProfile Begin]=======================================================
    '//These were created to get around the Array of fixed length strings in the 
    '//TModemProfile Structure
    '//
    '//ExtraBaudResults replaces - ExtraBaudResults(1 To 10) As String * SIZE_MODEM_STRING
    '//ModemStrings replaces - Reserved5(1 To 3) As String * SIZE_MODEM_STRING
    '//
    '//====[Structures]===============================================================

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure ExtraBaudResults
        <MarshalAs(UnmanagedType.ByValTStr, sizeconst:=SIZE_MODEM_STRING)> Public BaudResult As String
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure ModemStrings
        <MarshalAs(UnmanagedType.ByValTStr, sizeconst:=SIZE_MODEM_STRING)> Public ModemString As String
    End Structure

    '//====[End Structures]===========================================================

#End Region

#Region "TUser Changes ..."

    '//====[TUser Begin]=======================================================
    '//These were created to get around the Array of fixed length strings in the 
    '//TUser Structure
    '//
    '//UserSecurityProfiles replaces - security(1 To NUM_USER_SECURITY) As String * SIZE_SECURITY_NAME
    '//
    '//====[Structures]===============================================================

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure UserSecurityProfiles
        <MarshalAs(UnmanagedType.ByValTStr, sizeconst:=SIZE_SECURITY_NAME)> Public SecurityProfile As String
    End Structure

    '//====[End Structures]===========================================================

#End Region

#Region "TFullFileRecord Changes ..."

    '//====[TFullFileRecord Begin]=======================================================
    '//These were created to get around the Array of fixed length strings in the 
    '//TFullFileRecord Structure
    '//
    '//LongDescriptons replaces - LongDescription(1 To MAX_FILE_LONGDESC_LINES) As String * SIZE_FILE_LONGDESC
    '//
    '//====[Structures]===============================================================

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure LongDescriptions
        <MarshalAs(UnmanagedType.ByValTStr, sizeconst:=SIZE_FILE_LONGDESC)> Public Description As String
    End Structure

    '//====[End Structures]===========================================================

#End Region

#Region "TSpellSuggestList Changes ..."

    '//====[TSpellSuggestList Begin]=======================================================
    '//These were created to get around the Array of fixed length strings in the 
    '//TSpellSuggestList Structure
    '//
    '//SpellSuggestWords replaces - Words(1 To 10) As String * 32
    '//
    '//====[Structures]===============================================================

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure SpellSuggestWords
        <MarshalAs(UnmanagedType.ByValTStr, sizeconst:=32)> Public Word As String
    End Structure

    '//====[End Structures]===========================================================

#End Region

#Region "TSystemPageInstantMessage Changes ..."

    '//====[TSystemPageInstantMessage Begin]=======================================================
    '//These were created to get around the Array of fixed length strings in the 
    '//TSystemPageInstantMessage Structure
    '//
    '//SystemPageText replaces - text(1 To SIZE_SYSTEMPAGE_LINES) As String * SIZE_SYSTEMPAGE_TEXT
    '//
    '//====[Structures]===============================================================

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure SystemPageText
        <MarshalAs(UnmanagedType.ByValTStr, sizeconst:=SIZE_SYSTEMPAGE_TEXT)> Public PageText As String
    End Structure

    '//====[End Structures]===========================================================

#End Region

#End Region

#Region "Public WINServer API Structures..."

    '//!
    '//! Channel message structure for Callbacks
    '//!
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TChannelMessage
        Public Channel As Integer
        Public SenderId As Integer
        Public UserData As Short
        Public DataSize As Short
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_CHANNEL_MESSAGE_SIZE)> Public Data() As Byte
    End Structure

    '//!
    '//! Data structure for Paging Channel Events
    '//! passed via TChannelMessage.Data field
    '//!
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TPageMessage
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_USER_NAME)> Public From As String
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=SIZE_SYSTEMPAGE_LINES)> Public Message() As SystemPageText
        Public InviteToChat As Integer
    End Structure

    '//!
    '//! Data structure for Chat Channel Events
    '//! passed via TChannelMessage.Data field
    '//!
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TChatMessage
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=28)> Public From As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=256)> Public Text As String
        Public Whisper As Byte
    End Structure

    '//!---------------------------------------------------------------------------------------
    '//! These next four structures were added to the "mod" source to make wcsdk corrections,
    '//! as required for the VB.NET based app.
    '//!
    '//! TChatControl
    '//! TChatControlSwitch
    '//! TChatAction
    '//! TChatUserInfo
    '//!
    '//! We are moving them into the wcSDK v8.0 library
    '//!---------------------------------------------------------------------------------------

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TChatControl
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=28)> Public Name As String
        Public ChannelId As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> Public Text As String
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TChatControlSwitch
        Public Control As TChatControl
        Public NewId As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> Public NewText As String
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TChatAction
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=28)> Public From As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> Public Text As String
        Public Target As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> Public TargetText As String
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TChatUserInfo
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=28)> Public Name As String
        Public Id As Short
        Public Channel As Short
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=40)> Public Topic As String
    End Structure

    '//!---------------------------------------------------------------------------------------

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TObjectName
        Public Status As Integer
        Public objectID As Integer
        Public Number As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> Public Name As String
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TWildcatTimeouts
        Public dwVersion As Short
        Public dwRevision As Short
        Public Web As Integer
        Public WebQues As Integer
        Public Telnet As Integer
        Public TelnetLogin As Integer
        Public Ftp As Integer
        Public wcPPP As Integer
        Public wcNAV As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=92)> Public Reserved As String
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TWildcatLogOptions
        Public EnableSessionTrace As Integer
        Public LogPeriod As Integer
        Public dwMaxSize As Integer
        Public dwVerbosity As Integer
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=16)> Dim Reserved() As Byte
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure THttpAuthOptions
        Public AllowPlainText As Integer
        Public AllowPlainTextWithSSL As Integer
        Public AllowPlainMD5 As Integer
        Public AllowDigest As Integer
        Public AllowWcChallenge As Integer
        Public RequireSSL As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TWildcatHttpd
        Public dwVersion As Short
        Public dwRevision As Short
        Public obs_CommonLogF As Integer
        Public obs_Deutsch As Integer
        Public LogOptions As TWildcatLogOptions
        Public dwOptions As Integer
        Public MaximumBandWidth As Integer
        Public SendBufferSize1K As Integer
        Public RcvdBufferSize1K As Integer
        Public TrackPerformance As Integer
        Public HttpAuth As THttpAuthOptions
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=24)> Public Reserved As String
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TWildcatSMTP
        Public dwVersion As Short
        Public dwRevision As Short
        Public port As Integer
        Public sendthreads As Short
        Public acceptthreads As Short
        Public dwOptions As Integer
        Public acceptonly As Integer
        Public retries As Integer
        Public retrywait As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=52)> Public SmartHost As String
        Public sizelimit As Integer
        Public localonly As Integer
        Public MAPSRBL As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=52)> Public MAPSRBLServer As String
        Public ESMTP As Integer
        Public reqauth As Integer
        Public VRFY As Integer
        Public AllowRelay As Integer
        Public CheckRCPT As Integer
        Public EnableBadFilter As Integer
        Public RequireMX As Integer
        Public RequireHostMatch As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TWildcatNNTP
        Public dwVersion As Short
        Public dwRevision As Short
        Public dwPort As Integer
        Public dwOptions As Integer
        Public MaxCrossPost As Integer
        Public LogOptions As TWildcatLogOptions
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> Public Reserved As String
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TWildcatPOP3
        Public dwVersion As Short
        Public dwRevision As Short
        Public EnablePopBeforeSmtp As Integer
        Public dwPopBeforeSmtpTimeout As Integer
        Public dwOptions As Integer
        Public LogOptions As TWildcatLogOptions
        Public MaximumBandWidth As Integer
        Public SendBufferSize1K As Integer
        Public RcvdBufferSize1K As Integer
        Public TrackPerformance As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=64)> Public Reserved As String
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TWildcatTelnet
        Public dwVersion As Short
        Public dwRevision As Short
        Public dwOptions As Integer
        Public LogOptions As TWildcatLogOptions
        Public MaximumBandWidth As Integer
        Public SendBufferSize1K As Integer
        Public RcvdBufferSize1K As Integer
        Public TrackPerformance As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=72)> Public Reserved As String
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TWildcatFTP
        Public dwVersion As Short
        Public dwRevision As Short
        Public AllowAnonymous As Integer
        Public ShowFileGroups As Integer
        Public UseUnderScore As Integer
        Public UseSingleAreaChange As Integer
        Public MaxAnonymousConnects As Integer
        Public LogOptions As TWildcatLogOptions
        Public ListFormat As Integer
        Public dwOptions As Integer
        Public MaximumBandWidth As Integer
        Public SendBufferSize1K As Integer
        Public RcvdBufferSize1K As Integer
        Public TrackPerformance As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=48)> Public Reserved As String
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TMakewild
        Public Version As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_MAKEWILD_BBSNAME)> Public BBSName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_USER_NAME)> Public SysopName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_MAKEWILD_CITY)> Public City As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_MAKEWILD_PHONE)> Public Phone As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_MAKEWILD_FIRSTCALL)> Public FirstCall As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_MAKEWILD_PACKETID)> Public PacketId As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_MAKEWILD_REGSTRING)> Public RegString As String
        Public SystemAccess As Integer
        Public MaxLoginAttempts As Integer
        Public FreeFormPhone As Integer
        Public HideAnonFtpPassword As Integer
        Public LogonLanguagePrompt As Integer
        Public Assume8N1 As Integer
        Public LoginAskLocation As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_SECURITY_NAME)> Public NewUserSecurity As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_EXTENSION)> Public DefaultExt As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_SHORT_FILE_NAME)> Public ThumbnailFile As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> Public OldDoorPath As String
        Public obs_EnableHttpPr As Integer
        Public SmtpMaxAcceptLoad As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=124)> Public Reserved As String
        Public TelnetConfig As TWildcatTelnet
        Public FTPConfig As TWildcatFTP
        Public POP3Config As TWildcatPOP3
        Public MAILLogOptions As TWildcatLogOptions
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=32)> Public Reserved2 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=32)> Public Reserved1 As String
        Public SMTPLogOptions As TWildcatLogOptions
        Public NNTPConfig As TWildcatNNTP
        Public AllowLogonEmail As Integer
        Public CaseSensitivePasswords As Integer
        Public MsgHeaderCaseMode As Integer
        Public SpamAllowAuth As Integer
        Public SMTPConfig As TWildcatSMTP
        Public HttpdConfig As TWildcatHttpd
        Public Timeouts As TWildcatTimeouts
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=27)> Public DefaultColors() As Byte
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=40)> Public ExcludeBulletins() As Byte
        Public InstalledComponents As Integer
        Public obs_ResolveHostna As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=16)> Public BuildDate As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_DOMAIN_NAME)> Public DomainName As String
        Public WindowsCharset As Integer
        Public LogonUserNameOnly As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TWildcatComputerIpPort
        Public dwPort As Integer
        Public dwIpAddress As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TComputerConfig
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_COMPUTER_NAME)> Public Name As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> Public DoorPath As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> Public CgiPath As String
        Public HttpPort As Integer
        Public FtpPort As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> Public WWWHostname As String
        Public Servers As Integer
        Public HttpProxyPort As Integer
        Public dwVersion As Short
        Public dwRevision As Short
        Public ipportHttp As TWildcatComputerIpPort
        Public ipportFtp As TWildcatComputerIpPort
        Public ipportPop3 As TWildcatComputerIpPort
        Public ipportTelnet As TWildcatComputerIpPort
        Public ipportSmtp As TWildcatComputerIpPort
        Public ipportNntp As TWildcatComputerIpPort
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=340)> Dim Reserved() As Byte
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TLogonhours
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public DayValue() As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TSecurityProfile
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_SECURITY_NAME)> Public Name As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_SECURITY_NAME)> Public ExpiredName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_SHORT_FILE_NAME)> Public DisplayFileName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_SECURITY_NAME)> Public DoorSysProfileName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_SHORT_FILE_NAME)> Public MenuDisplaySet As String
        Public DailyTimeLimit As Integer
        Public PerCallTimeLimit As Integer
        Public VerifyPhoneInterval As Integer
        Public VerifyBirthdateInterval As Integer
        Public FailedInfoAction As Integer
        Public MaxDownloadCountPerDay As Integer
        Public DownloadRatioLimit As Integer
        Public MaxDownloadKbytesPerDay As Integer
        Public DownloadKbytesRatioLimit As Integer
        Public UploadTimeCredit As Integer
        Public ExpireDays As Integer
        Public PasswordOptions As Short
        Public PasswordExpireDays As Short
        Public FtpSpaceKbytes As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_DOMAIN_NAME)> Public EmailDomainName As String
        Public MaximumLogons As Integer
        Public RestrictedHours As Integer
        Public LogonHours As TLogonhours
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TConfDesc
        Public objectid As Integer
        Public Number As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_CONFERENCE_NAME)> Public name As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=16)> Public Reserved1 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_USER_NAME)> Public ConferenceSysop As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_CONFERENCE_ECHOTAG)> Public EchoTag As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_USER_NAME)> Public ReplyToAddress As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_USER_NAME)> Public Distribution As String
        Public MailType As Integer
        Public PromptToKillMsg As Integer
        Public PromptToKillAttach As Integer
        Public AllowHighAscii As Integer
        Public AllowCarbon As Integer
        Public AllowReturnReceipt As Integer
        Public LongHeaderFormat As Integer
        Public AllowAttach As Integer
        Public ShowCtrlLines As Integer
        Public ValidateNames As Integer
        Public DefaultFileGroup As Integer
        Public MaxMessages As Integer
        Public DaysToKeepReceivedMail As Integer
        Public DaysToKeepPublicMail As Integer
        Public RenumberThreshold As Integer
        Public DaysToKeepExternalMail As Integer
        Public DeleteSMTPDelivered As Integer
        Public PublishAsLocalNewsGroup As Integer
        Public Options As Integer
        Public AuthorType As Integer
        Public UnixCreationTime As Integer
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=6)> Public Reserved() As Byte
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_USER_NAME)> Public DefaultFromAddress As String
        Public wVersion As Short
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TShortConfDesc
        Public objectid As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_CONFERENCE_NAME)> Public name As String
        Public MailType As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TConferenceGroup
        Public objectid As Integer
        Public Number As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_CONFERENCEGROUP_NAME)> Public name As String
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=24)> Public Reserved() As Byte
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TFileArea
        Public objectid As Integer
        Public Number As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_FILEAREA_NAME)> Public name As String
        Public ExcludeFromNewFiles As Integer
        Public PromptForPasswordProtect As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_FILEAREA_NAME)> Public FtpDirectoryName As String
        Public Options As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TShortFileArea
        Public objectid As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_FILEAREA_NAME)> Public name As String
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TFileGroup
        Public objectid As Integer
        Public Number As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_FILEGROUP_NAME)> Public name As String
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=24)> Public Reserved() As Byte
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TDoorInfo
        Public objectid As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_DOOR_NAME)> Public name As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_SHORT_FILE_NAME)> Public Batch As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_SHORT_FILE_NAME)> Public Display As String
        Public DoorMenuIndex As Integer
        Public MultiUser As Integer
        Public SmallDoorSys As Integer
        Public DoorType As Integer
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=36)> Public Reserved() As Byte
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TLanguageInfo
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_LANGUAGE_NAME)> Public name As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_LANGUAGE_DESCRIPTION)> Public Description As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_LANGUAGE_SUBCOMMAND_CHARS)> Public SubcommandChars As String
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=72)> Public Reserved() As Byte
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TShortModemProfile
        Public UserDefined As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_MODEM_NAME)> Public name As String
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TModemProfile
        Public Version As Integer
        Public UserDefined As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_MODEM_NAME)> Public name As String
        Public InitBaud As Integer
        Public LockDTE As Integer
        Public HardwareFlow As Integer
        Public ExitOffHook As Integer
        Public CarrierDelay As Integer
        Public RingDelay As Integer
        Public DropDtrDelay As Integer
        Public PrelogDelay As Integer
        Public ResultDelay As Integer
        Public ResetDelay As Integer
        Public AnswerMethod As Integer
        Public EnableCallerId As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_MODEM_STRING)> Public ResetCommand As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_MODEM_STRING)> Public AnswerCommand As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_MODEM_STRING)> Public Reserved1 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_MODEM_STRING)> Public OffHook As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_MODEM_STRING)> Public RingResult As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_MODEM_STRING)> Public ConnectResult As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_MODEM_STRING)> Public Reserved2 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_MODEM_STRING)> Public ErrorFreeResult As String
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=10)> Public ExtraBaudResults() As ExtraBaudResults
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=10)> Public ExtraBaudResultNumbers() As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_MODEM_STRING)> Public Reserved3 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_MODEM_STRING)> Public InitCommand As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_MODEM_STRING)> Public Reserved4 As String
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=3)> Public Reserved5() As ModemStrings
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=256)> Public Reserved6 As String
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=128)> Public Reserved() As Byte
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TNodeConfig
        Public CallTypesAllowed As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_MODEM_NAME)> Public ModemName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_NODECONFIG_COMPUTER)> Public Computer As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_NODECONFIG_PORTNAME)> Public port As String
        Public PermanentLineID As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=8)> Public VirtualDoorPort As String
        Public NodeDisabled As Integer
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=44)> Public Reserved() As Byte
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TServerState
        Public OwnerId As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_NODECONFIG_COMPUTER)> Public Computer As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_SERVERSTATE_PORT)> Public port As String
        Public State As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TwcMenuItem
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_MENUITEM_SELECTION)> Public Selection As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_MENUITEM_DESCRIPTION)> Public Description As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_MENUITEM_COMMAND)> Public Command_Renamed As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_MENUITEM_COMMAND)> Public Parameters() As String
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=4)> Public Reserved() As Byte
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TMenu
        Public objectid As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_MENU_DESCRIPTION)> Public Description As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_SHORT_FILE_NAME)> Public DisplayName As String
        Public flags As Integer
        Public count As Integer
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=MAX_MENU_ITEMS - 1)> Public Items() As TwcMenuItem
        Public FastLoginChar As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_SECURITY_NAME)> Public SecurityEntryName As String
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=128)> Public Reserved() As Byte
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TUserInfo
        Public ID As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_USER_NAME)> Public Name As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_USER_TITLE)> Public Title As String
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TwcNodeInfo
        Public Nodestatus As Integer
        Public ServerState As Integer
        Public Connectionid As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_NODEINFO_LASTCALLER)> Public LastCaller As String
        Public User As TUserInfo
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_USER_FROM)> Public UserFrom As String
        Public UserPageAvailable As Integer
        Public Reserved1 As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_NODEINFO_ACTIVITY)> Public Activity As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_NODEINFO_SPEED)> Public Speed As String
        Public TimeCalled As FileTime
        Public CurrentTime As FileTime
        Public Reserved2 As Integer
        Public NodeNumber As Integer
        Public MinutesLeft As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TUser
        Public Status As Integer
        Public Info As TUserInfo
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_USER_FROM)> Public From As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_PASSWORD)> Public Password As String
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=10)> Public Security() As UserSecurityProfiles
        Public Reserved1 As Integer
        Public AllowMultipleLogins As Integer
        Public LogonHoursOverride As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_USER_NAME)> Public RealName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_USER_PHONE)> Public PhoneNumber As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_USER_ADDRESS)> Public Company As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_USER_ADDRESS)> Public Address1 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_USER_ADDRESS)> Public Address2 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_USER_ADDRESS)> Public City As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_USER_STATE)> Public State As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_USER_ZIP)> Public Zip As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_USER_ADDRESS)> Public Country As String
        Public Sex As Integer
        Public editor As Integer
        Public HelpLevel As Integer
        Public protocol As Integer
        Public terminaltype As Integer
        Public filedisplay As Integer
        Public msgdisplay As Integer
        Public PacketType As Integer
        Public LinesPerPage As Integer
        Public Hotkeys As Integer
        Public QuoteOnReply As Integer
        Public SortedListings As Integer
        Public PageAvailable As Integer
        Public EraseMorePrompt As Integer
        Public Reserved3 As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_LANGUAGE_NAME)> Public Language As String
        Public LastCall As FileTime
        Public LastNewFiles As FileTime
        Public ExpireDate As FileTime
        Public FirstCall As FileTime
        Public Birthdate As FileTime
        Public Conference As Integer
        Public MsgsWritten As Integer
        Public Uploads As Integer
        Public TotalUploadKbytes As Integer
        Public Downloads As Integer
        Public TotalDownloadKbytes As Integer
        Public DownloadCountToday As Integer
        Public DownloadKbytesToday As Integer
        Public TimesOn As Integer
        Public TimeLeftToday As Integer
        Public MinutesLogged As Integer
        Public SubscriptionBalance As Integer
        Public NetmailBalance As Integer
        Public AccountLockedOut As Integer
        Public PreserveMimeMessages As Integer
        Public ShowEmailHeaders As Integer
        Public LastUpdate As FileTime
        Public SystemFlags As Short
        Public UserFlags As Short
        Public Validation As Integer
        Public PasswordOptions As Short
        Public PasswordExpireDays As Short
        Public PasswordChangeDate As FileTime
        Public AnonymousOnly As Integer
        Public AllowUserDirectory As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TFidoAddress
        Public Zone As Short
        Public Net As Short
        Public Node As Short
        Public Point As Short
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TMsgHeader
        Public Status As Integer
        Public Conference As Integer
        Public Id As Integer
        Public Number As Integer
        Public MsgFrom As TUserInfo
        Public MsgTo As TUserInfo
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_MESSAGE_SUBJECT)> Public Subject As String
        Public PostedTimeGMT As FileTime
        Public MsgTime As FileTime
        Public ReadTime As FileTime
        Public IsPrivate As Integer
        Public Received As Integer
        Public ReceiptRequested As Integer
        Public Deleted As Integer
        Public Tagged As Integer
        Public Reference As Integer
        Public ReplyCount As Integer
        Public FidoFrom As TFidoAddress
        Public FidoTo As TFidoAddress
        Public FidoFlags As Integer
        Public MsgSize As Integer
        Public PrevUnread As Integer
        Public NextUnread As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_MESSAGE_NETWORK)> Public Network As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_SHORT_FILE_NAME)> Public AttachmentSFN As String
        Public AllowDisplayMacros As Integer
        Public AddedByUserId As Integer
        Public Exported As Integer
        Public MailFlags As Integer
        Public NextAttachment As Integer
        Public ReadCount As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_ATTACH_FILE_NAME)> Public Attachment As String
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=32)> Public Reserved() As Byte
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TFileRecord
        Public Status As Integer
        Public Area As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_SHORT_FILE_NAME)> Public SFName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_FILE_DESCRIPTION)> Public Description As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_PASSWORD)> Public Password As String
        Public FileFlags As Integer
        Public Size As Integer
        Public FileTime As FileTime
        Public LastAccessed As FileTime
        Public NeverOverwrite As Integer
        Public NeverDelete As Integer
        Public IsFreeFile As Integer
        Public CopyBeforeDownload As Integer
        Public Offline As Integer
        Public FailedScan As Integer
        Public FreeTime As Integer
        Public Downloads As Integer
        Public Cost As Integer
        Public Uploader As TUserInfo
        Public UserInfo As Integer
        Public HasLongDescription As Integer
        Public PostTime As FileTime
        Public PrivateUserId As Integer
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=32)> Public Reserved() As Byte
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_LONG_FILE_NAME)> Public Name As String
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=100)> Public Reserved2() As Byte
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TFullFileRecord
        Public Info As TFileRecord
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> Public StoredPath As String
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=MAX_FILE_LONGDESC_LINES)> Public LongDescription() As LongDescriptions
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TFileRecord5
        Public Status As Integer
        Public Area As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_SHORT_FILE_NAME)> Public Name As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_FILE_DESCRIPTION)> Public Description As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_PASSWORD)> Public Password As String
        Public Reserved1 As Integer
        Public Size As Integer
        Public FileTime As FileTime
        Public LastAccessed As FileTime
        Public NeverOverwrite As Integer
        Public NeverDelete As Integer
        Public FreeFile As Integer
        Public CopyBeforeDownload As Integer
        Public Offline As Integer
        Public FailedScan As Integer
        Public FreeTime As Integer
        Public Downloads As Integer
        Public Cost As Integer
        Public Uploader As TUserInfo
        Public UserInfo As Integer
        Public HasLongDescription As Integer
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=44)> Public Reserved() As Byte
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TFullFileRecord5
        Public Info As TFileRecord5
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> Public StoredPath As String
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=MAX_FILE_LONGDESC_LINES)> Public LongDescription() As LongDescriptions
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TSpellSuggestList
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=10)> Public Words() As SpellSuggestWords
    End Structure

    '//!
    '//! Data Structure used for SE_FILE_xxxxxx channel signals.
    '//!
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TSystemEventFileInfo
        Public FileArea As Integer
        Public Connectionid As Integer
        Public TimeStamp As FileTime
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_LONG_FILE_NAME)> Public szFileName As String
    End Structure

    '//!
    '//! Structure used by WCVIEW to display screen data sent by
    '//! Host clients.  WCVIEW will send SC_WATCH_REQUEST to clients
    '//! asking them to provide screen data. If the clients are listening,
    '//! they can fill in the structure and send the data with the
    '//! SC_DISPLAY_UPDATE channel signal which will then signal WCVIEW
    '//! to update its display screens.
    '//!
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TSystemControlViewMsg
        Public Line As Short
        Public Count As Short
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=240)> Public Text() As Short
        Public CursorX As Short
        Public CursorY As Short
        Public MinutesLeft As Short
    End Structure

    '//!
    '//! Data Structure used for SP_xxxxxx channel signals
    '//!
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TSystemPageNewMessage
        Public Conference As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_CONFERENCE_NAME)> Public ConferenceName As String
        Public Id As Integer
        Public From As TUserInfo
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_MESSAGE_SUBJECT)> Public Subject As String
    End Structure

    '//!
    '//! Data Structure used for instant messages, channel "System.Page"
    '//!
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TSystemPageInstantMessage
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_USER_NAME)> Public From As String
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=SIZE_SYSTEMPAGE_LINES)> Public Message As SystemPageText
        Public InviteToChat As Integer
    End Structure

    '//!
    '//! Structure for Wildcat! Service Creations
    '//!
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TWildcatService
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_SERVICE_NAME)> Public Name As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_SERVICE_NAME)> Public Vendor As String
        Public Version As Integer
        Public Address As Integer
        Public Port As Integer
    End Structure

    '//!
    '//! Structure for Connection Information
    '//! Set GetConnectionInfo() SDK function
    '//!
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TConnectionInfo
        Public Connectionid As Integer
        Public Node As Integer
        Public Time As Integer
        Public IdleTime As Integer
        Public Calls As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> Public WindowsUserName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_COMPUTER_NAME)> Public Computer As String
        Public IpAddress As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> Public ProgramName As String
        Public RefCount As Integer
        Public User As TUserInfo
        Public HandlesOpen As Integer
        Public ChannelsOpen As Integer
        Public CurrentTid As Integer
        Public PeerAddress As Integer
        Public CallType As Integer
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=92)> Public Reserved() As Byte
    End Structure

    '//!
    '//! Structure for GetWildcatServerInfo() function
    '//! Combines multiple server calls to get server totals in 1 call
    '//!
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TWildcatServerInfo
        Public TotalCalls As Integer
        Public TotalUsers As Integer
        Public TotalMessages As Integer
        Public TotalFiles As Integer
        Public MemoryUsage As Integer
        Public MemoryLoad As Integer
        Public LastMessageId As Integer
        Public LastUserId As Integer
        Public ServerVersion As Integer
        Public ServerBuild As Integer
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=84)> Public Reserved() As Byte
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TWildcatProcessTimes
        Public ftSystem As FileTime
        Public ftStart As FileTime
        Public ftExit As FileTime
        Public ftKernel As FileTime
        Public ftUser As FileTime
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=24)> Public Reserved() As Byte
    End Structure

    '//!
    '//! TWildcatSASLContext is used to store any context specific
    '//! data we need in SASL based connections
    '//!
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TWildcatSASLContext
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_SASL_NAME)> Public szSaslMethod As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=256)> Public szChallenge As String
        Public dwOptions As Integer
        Public dwState As Integer
        Public dwUserid As Integer
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=4096)> Public Data() As Byte
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_USER_NAME)> Public szUsername As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> Public szRealm As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> Public szDomain As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> Public szNonce As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> Public szCNonce As String
        Public dwCNonceCount As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> Public szURI As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=20)> Public szMethod As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=64)> Public szAlg As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=64)> Public szQop As String
    End Structure

    '//! v6.0.451.2
    '//! Structure for wcCreateFileEx() function
    '//!
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TwcOpenFileInfo
        Public hFile As Integer
        Public dwSize As Integer
        Public ftWriteTime As FileTime
        Public dwAttributes As Integer
        Public dwSizeHigh As Integer
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=232)> Public Reserved() As Byte
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TPackerRec
        Public Letter As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_PACKER_DESCRIPTION)> Public Description As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_EXTENSION)> Public Extension As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_PACKER_COMMAND)> Public Packer As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_PACKER_COMMAND)> Public Unpacker As String
    End Structure

#End Region

#Region "Public WINServer API DLL Imports ..."

    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetWildcatVersion() As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetWildcatBuild() As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WcGetServerVersion() As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WcGetServerBuild() As Integer
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbWildcatServerConnect", SetLastError:=True)> Public Function WildcatServerConnect(ByVal parent As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbWildcatServerConnectSpecific", SetLastError:=True)> Public Function WildcatServerConnectSpecific(ByVal parent As Integer, ByVal computername As String) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WildcatServerDialog(ByVal parent As Integer, ByVal computername As String, ByVal namesize As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function SetWildcatErrorMode(ByVal verbose As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetConnectedServer", SetLastError:=True)> Public Function GetConnectedServer() As <MarshalAs(UnmanagedType.AnsiBStr)> String
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WildcatServerCreateContext() As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WildcatServerCreateContextFromHandle(ByVal context As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WildcatServerCreateContextFromChallenge(ByVal challenge As String) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetWildcatServerContextHandle() As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WildcatServerDeleteContext() As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function SetupWildcatCallback(ByVal cbproc As [Delegate], ByVal userdata As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function RemoveWildcatCallback() As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GrantThreadAccess(ByVal tid As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetWildcatThreadContext() As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function SetWildcatThreadContext(ByVal context As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetNode() As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function SetNodeStatus(ByVal nodestatus As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetMakewild", SetLastError:=True)> Public Function GetMakewild(ByRef mw As TMakewild) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetComputerConfig", SetLastError:=True)> Public Function GetComputerConfig(ByRef cc As TComputerConfig) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetChallengeString", SetLastError:=True)> Public Function GetChallengeString() As <MarshalAs(UnmanagedType.AnsiBStr)> String
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function LoginSystem() As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbLookupName", SetLastError:=True)> Public Function LookupName(ByVal name As String, ByRef uinfo As TUserInfo) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function AllocateNode(ByVal node As Integer, ByVal calltype As Integer, ByVal speed As String) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbLoginUser", SetLastError:=True)> Public Function LoginUser(ByVal UserId As Integer, ByVal Password As String, ByRef user As TUser) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbLoginUserEx", SetLastError:=True)> Public Function LoginUserEx(ByVal UserId As Integer, ByVal Password As String, ByVal calltype As Integer, ByVal speed As String, ByRef user As TUser) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbLoginRadiusUser", SetLastError:=True)> Public Function LoginRadiusUser(ByVal UserId As Integer, ByVal chapid As Byte, ByRef challenge As Byte, ByVal challengesize As Integer, ByRef challresponse As Byte, ByRef user As TUser) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function LogoutUser() As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbWildcatLoggedIn", SetLastError:=True)> Public Function WildcatLoggedIn(ByRef user As TUser) As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetUsersOnline() As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetProfileObjectFlags(ByVal profile As String, ByVal objectid As Integer) As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WcCloseHandle(ByVal h As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WcCreateDirectory(ByVal directory As String) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WcCreateFile(ByVal fn As String, ByVal access As Integer, ByVal sharemode As Integer, ByVal create As Integer) As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WcDeleteFile(ByVal fn As String) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WcExistFile(ByVal fn As String) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbWcFindFirstFile", SetLastError:=True)> Public Function WcFindFirstFile(ByVal fn As String, ByRef fd As WIN32_FIND_DATA) As Integer
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbWcFindNextFile", SetLastError:=True)> Public Function WcFindNextFile(ByVal ff As Integer, ByRef fd As WIN32_FIND_DATA) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WcFindClose(ByVal ff As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WcGetFileSize(ByVal h As Integer) As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WcGetFileTime(ByVal h As Integer, ByRef ft As FileTime) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WcGetFileTimeByName(ByVal fn As String, ByRef ft As FileTime) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WcMoveFile(ByVal src As String, ByVal dest As String) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WcReadFile(ByVal h As Integer, ByRef buffer As Byte(), ByVal requested As Integer, ByRef Read As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WcReadLine(ByVal h As Integer, ByRef buffer As Byte(), ByVal buflen As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WcSetEndOfFile(ByVal h As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WcSetFilePointer(ByVal h As Integer, ByVal dist As Integer, ByVal movemethod As Integer) As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WcSetFileTime(ByVal h As Integer, ByRef ft As FileTime) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WcWriteFile(ByVal h As Integer, ByRef buffer As Byte(), ByVal requested As Integer, ByRef Written As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetConnectionId() As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetTotalCalls(ByVal increment As Integer) As Integer
    End Function

    <DllImport("wcvb.dll", EntryPoint:="vbGetText", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Function GetText(ByVal fn As String) As <MarshalAs(UnmanagedType.AnsiBStr)> String
    End Function

    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetObjectFlags(ByVal objectid As Integer) As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetMultipleObjectFlags(ByRef objectid As Integer, ByVal count As Integer, ByRef flags As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetObjectById", SetLastError:=True)> Public Function GetObjectById(ByVal objectid As Integer, ByRef objectname As TObjectName) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetMultipleObjectsById", SetLastError:=True)> Public Function GetMultipleObjectsById(ByRef objectid As Integer, ByVal count As Integer, ByRef objectname As TObjectName) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetObjectByName", SetLastError:=True)> Public Function GetObjectByName(ByVal classid As Integer, ByVal name As String, ByRef objectname As TObjectName, ByRef tid As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetNextObjectByName", SetLastError:=True)> Public Function GetNextObjectByName(ByRef objectname As TObjectName, ByRef tid As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetStringObjectId(ByVal objectclass As Integer, ByVal name As String) As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetStringObjectFlags(ByVal objectclass As Integer, ByVal name As String) As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetSecurityProfileCount() As Integer
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetSecurityProfileNames", SetLastError:=True)> Public Function GetSecurityProfileNames() As Object
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetSecurityProfileByIndex", SetLastError:=True)> Public Function GetSecurityProfileByIndex(ByVal Index As Integer, ByRef profile As TSecurityProfile) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetSecurityProfileByName", SetLastError:=True)> Public Function GetSecurityProfileByName(ByVal name As String, ByRef profile As TSecurityProfile) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetAccessProfileCount() As Integer
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetAccessProfileNames", SetLastError:=True)> Public Function GetAccessProfileNames() As Object
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetAccessProfileName", SetLastError:=True)> Public Function GetAccessProfileName(ByVal Index As Integer) As <MarshalAs(UnmanagedType.AnsiBStr)> String
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetConferenceCount() As Integer
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetConfDesc", SetLastError:=True)> Public Function GetConfDesc(ByVal Conference As Integer, ByRef cd As TConfDesc) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetConferenceGroupCount() As Integer
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetConferenceGroup", SetLastError:=True)> Public Function GetConferenceGroup(ByVal Index As Integer, ByRef cg As TConferenceGroup) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetFileAreaCount() As Integer
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetFileArea", SetLastError:=True)> Public Function GetFileArea(ByVal area As Integer, ByRef fa As TFileArea) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetFileGroupCount() As Integer
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetFileGroup", SetLastError:=True)> Public Function GetFileGroup(ByVal Index As Integer, ByRef fg As TFileGroup) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetDoorCount() As Integer
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetDoor", SetLastError:=True)> Public Function GetDoor(ByVal Index As Integer, ByRef di As TDoorInfo) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetLanguageCount() As Integer
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetLanguage", SetLastError:=True)> Public Function GetLanguage(ByVal Index As Integer, ByRef li As TLanguageInfo) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetModemProfile", SetLastError:=True)> Public Function GetModemProfile(ByVal name As String, ByRef mp As TModemProfile) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetNodeCount() As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetMaximumUserCount() As Integer
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetNodeConfig", SetLastError:=True)> Public Function GetNodeConfig(ByVal node As Integer, ByRef nc As TNodeConfig) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetNodeInfo", SetLastError:=True)> Public Function GetNodeInfo(ByVal node As Integer, ByRef ni As TwcNodeInfo) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetNodeInfoByConnectionId", SetLastError:=True)> Public Function GetNodeInfoByConnectionId(ByVal id As Integer, ByRef ni As TwcNodeInfo) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetNodeInfoByName", SetLastError:=True)> Public Function GetNodeInfoByName(ByVal name As String, ByRef ni As TwcNodeInfo) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetNodeInfos", SetLastError:=True)> Public Function GetNodeInfos(ByVal node As Integer, ByVal count As Integer, ByRef ni As TwcNodeInfo) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbSetNodeInfo", SetLastError:=True)> Public Function SetNodeInfo(ByRef ni As TwcNodeInfo) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function SetNodeActivity(ByVal activity As String) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function SetServerState(ByVal port As String, ByVal State As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetServerState", SetLastError:=True)> Public Function GetServerState(ByVal Index As Integer, ByRef ss As TServerState) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function SetNodeServerState(ByVal node As Integer, ByVal State As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbAddFileRec", SetLastError:=True)> Public Function AddFileRec(ByRef f As TFullFileRecord) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbDeleteFileRec", SetLastError:=True)> Public Function DeleteFileRec(ByRef f As TFileRecord, ByVal disktoo As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbFileSearch", SetLastError:=True)> Public Function FileSearch(ByVal s As String) As Object
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetFileRecAbsolute", SetLastError:=True)> Public Function GetFileRecAbsolute(ByVal ref As Integer, ByRef f As TFileRecord) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetFileRecByNameArea", SetLastError:=True)> Public Function GetFileRecByNameArea(ByVal name As String, ByVal area As Integer, ByRef f As TFileRecord, ByRef tid As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetFileRecByAreaName", SetLastError:=True)> Public Function GetFileRecByAreaName(ByVal area As Integer, ByVal name As String, ByRef f As TFileRecord, ByRef tid As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetFileRecByAreaDate", SetLastError:=True)> Public Function GetFileRecByAreaDate(ByVal area As Integer, ByRef t As FileTime, ByRef f As TFileRecord, ByRef tid As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetFileRecByUploader", SetLastError:=True)> Public Function GetFileRecByUploader(ByVal id As Integer, ByRef f As TFileRecord, ByRef tid As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetFirstFileRec", SetLastError:=True)> Public Function GetFirstFileRec(ByVal keynum As Integer, ByRef f As TFileRecord, ByRef tid As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetFullFileRec", SetLastError:=True)> Public Function GetFullFileRec(ByRef f As TFileRecord, ByRef full As TFullFileRecord) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetLastFileRec", SetLastError:=True)> Public Function GetLastFileRec(ByVal keynum As Integer, ByRef f As TFileRecord, ByRef tid As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetNextFileRec", SetLastError:=True)> Public Function GetNextFileRec(ByVal keynum As Integer, ByRef f As TFileRecord, ByRef tid As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetPrevFileRec", SetLastError:=True)> Public Function GetPrevFileRec(ByVal keynum As Integer, ByRef f As TFileRecord, ByRef tid As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetTotalFiles() As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetTotalFilesInArea(ByVal area As Integer) As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetTotalFilesInGroup(ByVal group As Integer) As Integer
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbIncrementDownloadCount", SetLastError:=True)> Public Function IncrementDownloadCount(ByRef f As TFileRecord) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbSearchFileRecByNameArea", SetLastError:=True)> Public Function SearchFileRecByNameArea(ByVal name As String, ByVal area As Integer, ByRef f As TFileRecord, ByRef tid As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbSearchFileRecByAreaName", SetLastError:=True)> Public Function SearchFileRecByAreaName(ByVal area As Integer, ByVal name As String, ByRef f As TFileRecord, ByRef tid As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbSearchFileRecByAreaDate", SetLastError:=True)> Public Function SearchFileRecByAreaDate(ByVal area As Integer, ByRef t As FileTime, ByRef f As TFileRecord, ByRef tid As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbSearchFileRecByDateArea", SetLastError:=True)> Public Function SearchFileRecByDateArea(ByRef t As FileTime, ByVal area As Integer, ByRef f As TFileRecord, ByRef tid As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbSearchFileRecByUploader", SetLastError:=True)> Public Function SearchFileRecByUploader(ByVal id As Integer, ByRef f As TFileRecord, ByRef tid As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbUpdateFileRec", SetLastError:=True)> Public Function UpdateFileRec(ByRef f As TFileRecord) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbUpdateFullFileRec", SetLastError:=True)> Public Function UpdateFullFileRec(ByRef f As TFullFileRecord) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbAddMessage", SetLastError:=True)> Public Function AddMessage(ByRef msg As TMsgHeader, ByVal text As String) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbDeleteMessage", SetLastError:=True)> Public Function DeleteMessage(ByRef msg As TMsgHeader) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetHighMessageNumber(ByVal conf As Integer) As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetLowMessageNumber(ByVal conf As Integer) As Integer
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetMessageById", SetLastError:=True)> Public Function GetMessageById(ByVal conf As Integer, ByVal MsgID As Integer, ByRef msg As TMsgHeader) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetMsgIdFromNumber(ByVal conf As Integer, ByVal Number As Integer) As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetMsgNumberFromId(ByVal conf As Integer, ByVal MsgID As Integer) As Integer
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetNextMessage", SetLastError:=True)> Public Function GetNextMessage(ByRef msg As TMsgHeader) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetPrevMessage", SetLastError:=True)> Public Function GetPrevMessage(ByRef msg As TMsgHeader) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetTotalMessages() As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetTotalMessagesInConference(ByVal conf As Integer) As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetTotalMessagesInGroup(ByVal group As Integer) As Integer
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbIncrementReplyCount", SetLastError:=True)> Public Function IncrementReplyCount(ByRef msg As TMsgHeader) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbIncrementReadCount", SetLastError:=True)> Public Function IncrementReadCount(ByRef msg As TMsgHeader) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbMarkMessageRead", SetLastError:=True)> Public Function MarkMessageRead(ByRef msg As TMsgHeader) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbMessageSearch", SetLastError:=True)> Public Function MessageSearch(ByVal conf As Integer, ByVal MsgID As Integer, ByVal msflags As Integer, ByVal text As String, ByRef msg As TMsgHeader) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbSearchMessageById", SetLastError:=True)> Public Function SearchMessageById(ByVal conf As Integer, ByVal MsgID As Integer, ByRef msg As TMsgHeader) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbSetMessagePrivate", SetLastError:=True)> Public Function SetMessagePrivate(ByRef msg As TMsgHeader, ByVal pvt As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbUpdateMessageFidoInfo", SetLastError:=True)> Public Function UpdateMessageFidoInfo(ByRef msg As TMsgHeader) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetHighMessageIds(ByVal count As Integer, ByRef conferences As Integer, ByRef ids As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbSetMessageExported", SetLastError:=True)> Public Function SetMessageExported(ByRef msg As TMsgHeader, ByVal exported As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbAddNewUser", SetLastError:=True)> Public Function AddNewUser(ByRef u As TUser) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbDeleteOtherUser", SetLastError:=True)> Public Function DeleteOtherUser(ByRef u As TUser) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetUserById", SetLastError:=True)> Public Function GetUserById(ByVal id As Integer, ByRef u As TUser, ByRef tid As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetUserByLastName", SetLastError:=True)> Public Function GetUserByLastName(ByVal name As String, ByRef u As TUser, ByRef tid As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetUserByName", SetLastError:=True)> Public Function GetUserByName(ByVal name As String, ByRef u As TUser, ByRef tid As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetUserBySecurity", SetLastError:=True)> Public Function GetUserBySecurity(ByVal security As String, ByRef u As TUser, ByRef tid As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetUserVariable", SetLastError:=True)> Public Function GetUserVariable(ByVal id As Integer, ByVal section As String, ByVal key As String, ByVal def As String) As <MarshalAs(UnmanagedType.AnsiBStr)> String
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetUserVariables(ByVal id As Integer, ByRef buffer As String, ByVal requested As Integer, ByRef Read As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetUserVariables", SetLastError:=True)> Public Function GetUserVariables(ByVal id As Integer) As <MarshalAs(UnmanagedType.AnsiBStr)> String
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetFirstUser", SetLastError:=True)> Public Function GetFirstUser(ByVal keynum As Integer, ByRef u As TUser, ByRef tid As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetLastUser", SetLastError:=True)> Public Function GetLastUser(ByVal keynum As Integer, ByRef u As TUser, ByRef tid As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetNextUser", SetLastError:=True)> Public Function GetNextUser(ByVal keynum As Integer, ByRef u As TUser, ByRef tid As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetPrevUser", SetLastError:=True)> Public Function GetPrevUser(ByVal keynum As Integer, ByRef u As TUser, ByRef tid As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetTotalUsers() As Integer
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbSearchUserById", SetLastError:=True)> Public Function SearchUserById(ByVal id As Integer, ByRef u As TUser, ByRef tid As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbSearchUserByLastName", SetLastError:=True)> Public Function SearchUserByLastName(ByVal name As String, ByRef u As TUser, ByRef tid As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbSearchUserByName", SetLastError:=True)> Public Function SearchUserByName(ByVal name As String, ByRef u As TUser, ByRef tid As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbSearchUserBySecurity", SetLastError:=True)> Public Function SearchUserBySecurity(ByVal security As String, ByRef u As TUser, ByRef tid As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function SetUserVariable(ByVal id As Integer, ByVal section As String, ByVal key As String, ByVal data As String) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbUpdateUser", SetLastError:=True)> Public Function UpdateUser(ByRef u As TUser) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetEffectiveConferenceGroupCount() As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetEffectiveConferenceCount(ByVal group As Integer, ByVal flags As Integer) As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetFirstConference(ByVal group As Integer, ByVal flags As Integer) As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetLastConference(ByVal group As Integer, ByVal flags As Integer) As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetNextConference(ByVal group As Integer, ByVal flags As Integer, ByVal conf As Integer) As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetPrevConference(ByVal group As Integer, ByVal flags As Integer, ByVal conf As Integer) As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetFirstConferenceUnread() As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetNextConferenceUnread(ByVal conf As Integer) As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetPrevConferenceUnread(ByVal conf As Integer) As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function IsConferenceInGroup(ByVal group As Integer, ByVal conf As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetEffectiveFileGroupCount() As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetEffectiveFileAreaCount(ByVal group As Integer, ByVal flags As Integer) As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetFirstFileArea(ByVal group As Integer, ByVal flags As Integer) As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetLastFileArea(ByVal group As Integer, ByVal flags As Integer) As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetNextFileArea(ByVal group As Integer, ByVal flags As Integer, ByVal area As Integer) As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetPrevFileArea(ByVal group As Integer, ByVal flags As Integer, ByVal area As Integer) As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function IsFileAreaInGroup(ByVal group As Integer, ByVal area As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetLastRead(ByVal conf As Integer) As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetFirstUnread(ByVal conf As Integer) As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetConfFlags(ByVal conf As Integer) As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function SetLastRead(ByVal conf As Integer, ByVal lastread As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function SetConfFlags(ByVal conf As Integer, ByVal flags As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetUserLastRead(ByVal UserId As Integer, ByVal conf As Integer) As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetUserFirstUnread(ByVal UserId As Integer, ByVal conf As Integer) As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetUserConfFlags(ByVal UserId As Integer, ByVal conf As Integer) As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function SetUserLastRead(ByVal UserId As Integer, ByVal conf As Integer, ByVal lastread As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function SetUserConfFlags(ByVal UserId As Integer, ByVal conf As Integer, ByVal flags As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WriteLogEntry(ByVal fname As String, ByVal text As String) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WriteActivityLogEntry(ByVal text As String) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function SpellCheckLine(ByVal s As String, ByVal startpos As Integer, ByRef badpos As Integer, ByRef badlen As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbSpellCheckSuggest", SetLastError:=True)> Public Function SpellCheckSuggest(ByVal s As String, ByRef sl As TSpellSuggestList) As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function SpellCheckAddWord(ByVal s As String) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function OpenChannel(ByVal name As String) As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function CloseChannel(ByVal chandle As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WriteChannel(ByVal chandle As Integer, ByVal destid As Integer, ByVal userdata As Integer, ByRef data As String, ByVal datasize As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WriteChannel(ByVal chandle As Integer, ByVal destid As Integer, ByVal userdata As Integer, ByRef data As TPageMessage, ByVal datasize As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WriteChannel(ByVal chandle As Integer, ByVal destid As Integer, ByVal userdata As Integer, ByRef data As TChatMessage, ByVal datasize As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WriteChannel(ByVal chandle As Integer, ByVal destid As Integer, ByVal userdata As Integer, ByRef data As TChatControl, ByVal datasize As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WriteChannel(ByVal chandle As Integer, ByVal destid As Integer, ByVal userdata As Integer, ByRef data As TChatControlSwitch, ByVal datasize As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetQwkBaudLimits(ByRef perpacket As Integer, ByRef perconference As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetServiceByName", SetLastError:=True)> Public Function GetServiceByName(ByVal name As String, ByRef service As TWildcatService) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbRegisterService", SetLastError:=True)> Public Function RegisterService(ByRef service As TWildcatService) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function CheckNetworkAddress(ByVal clientip As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function SubmitCopyRequest(ByVal id As Integer, ByVal fn As String) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetNextCopyRequest() As Integer
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function RemoveCopyRequest(ByVal id As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetConnectionInfo", SetLastError:=True)> Public Function GetConnectionInfo(ByVal connectionid As Integer, ByRef ci As TConnectionInfo) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function AdjustUserTime(ByVal minutes As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function RegisterPPPAddress(ByVal Address As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function UnregisterPPPAddress(ByVal Address As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetValidPPPAddresses(ByRef addrs As Integer, ByRef addrlen As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetWildcatServerInfo(ByRef si As TWildcatServerInfo) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetUserByKeyIndex", SetLastError:=True)> Public Function GetUserByKeyIndex(ByVal keynum As Integer, ByVal idx As Integer, ByRef u As TUser, ByRef tid As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function CheckClientAddress(ByVal clientip As Integer, ByVal szIPFile As String) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function CheckMailIntegrity(ByVal conf As Integer, ByVal level As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbUpdateMessageFlags", SetLastError:=True)> Public Function UpdateMessageFlags(ByRef msg As TMsgHeader) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbDeleteMessageAttachment", SetLastError:=True)> Public Function DeleteMessageAttachment(ByRef msg As TMsgHeader) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetComputerConfigEx", SetLastError:=True)> Public Function GetComputerConfigEx(ByVal szComputerName As String, ByRef cc As TComputerConfig) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function ProfileDateToFileDate(ByVal szInt64 As String, ByRef ft As FileTime) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetUserVariableDate(ByVal id As Integer, ByVal section As String, ByVal key As String, ByRef ft As FileTime) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetUserProfileDate(ByVal id As Integer, ByVal key As String, ByRef ft As FileTime) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetUserProfileDateStr", SetLastError:=True)> Public Function GetUserProfileDateStr(ByVal id As Integer, ByVal key As String, ByVal pFormat As String) As <MarshalAs(UnmanagedType.AnsiBStr)> String
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbGetUserProfileDateStr", SetLastError:=True)> Public Function GetUserProfileTimeStr(ByVal id As Integer, ByVal key As String, ByVal pFormat As String) As <MarshalAs(UnmanagedType.AnsiBStr)> String
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function SetUserVariableDate(ByVal id As Integer, ByVal section As String, ByVal key As String, ByRef ft As FileTime) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function SetUserProfileDate(ByVal id As Integer, ByVal key As String, ByRef ft As FileTime) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function SetUserProfileSystemTime(ByVal id As Integer, ByVal key As String, ByRef st As SYSTEMTIME) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function GetUserProfileBool(ByVal id As Integer, ByVal key As String, ByRef flag As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function SetUserProfileBool(ByVal id As Integer, ByVal key As String, ByVal flag As Integer) As Boolean
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function wcCopyFileToTemp(ByVal area As Integer, ByVal fn As String) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbUpdateUserEx", SetLastError:=True)> Public Function UpdateUserEx(ByRef user As TUser, ByVal oldpwd As String, ByVal newpwd As String) As Boolean
    End Function

    '//!
    '//! 450.3 07/30/02
    '//! Wildcat! SASL functions for authentication services
    '//!
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WcSASLGetMethodName(ByVal szMethod As String, ByVal dwSize As Integer, ByVal dwIndex As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbWcSASLAuthenticateUser", SetLastError:=True)> Public Function WcSASLAuthenticateUser(ByVal ctx As TWildcatSASLContext, ByVal szFromClient As String, ByVal szResponse As String, ByVal dwResponseSize As Integer, ByVal u As TUser) As Integer
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbWcSASLAuthenticateUserEx", SetLastError:=True)> Public Function WcSASLAuthenticateUserEx(ByVal ctx As TWildcatSASLContext, ByVal szFromClient As String, ByVal szResponse As String, ByVal dwResponseSize As Integer, ByVal dwCallType As Integer, ByVal szSpeed As String, ByVal u As TUser) As Integer
    End Function

    '//!
    '//! 450.3 07/30/02
    '//! Get the wildcat server process running times
    '//!
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WcGetProcessTimes(ByVal pt As TWildcatProcessTimes) As Boolean
    End Function

    '//! 450.7
    '//! Set the context peer address
    '//!
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function SetContextPeerAddress(ByVal address As Integer) As Boolean
    End Function

    '//! 450.8 06/18/03
    '//! Wildcat! INI File Functions. These Wildcat! INI file
    '//! functions work similar to the Win32 equivalent private
    '//! profile functions. The key difference is that Win32
    '//! INI files are local to the machine, where these Wildcat!
    '//! INI functions use server side files using the Wildcat!
    '//! file naming syntax, i.e., "wc:\data\productxyz.ini"
    '//!
    <DllImport("wcvb.dll", EntryPoint:="vbWcGetPrivateProfileString", SetLastError:=True)> Public Function WcGetPrivateProfileString(ByVal section As String, ByVal key As String, ByVal def As String, ByVal ini As String) As <MarshalAs(UnmanagedType.AnsiBStr)> String
    End Function
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WcWritePrivateProfileString(ByVal sect As String, ByVal key As String, ByVal value As String, ByVal inifile As String) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbWcGetPrivateProfileSection", SetLastError:=True)> Public Function WcGetPrivateProfileSection(ByVal section As String, ByVal ini As String) As <MarshalAs(UnmanagedType.AnsiBStr)> String
    End Function

    '//! 451.2 07/18/04
    '//! Extended WcCreateFileEx() function returns TwcOpenFileInfo
    '//! structure. Useful when you need to open a file and obtain
    '//! file information in one single RPC call.
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WcCreateFileEx(ByVal fn As String, ByVal access As Integer, ByVal sharemode As Integer, ByVal create As Integer, ByVal pwcofi As TwcOpenFileInfo) As Integer
    End Function

    '//! 451.5 10/04/05
    '//! GetConnectionInfoFromChallenge() function returns TConnectionInfo
    '//! for a given challenge.
    <DllImport("wcvb.dll", EntryPoint:="vbGetConnectionInfoFromChallenge", SetLastError:=True)> Public Function GetConnectionInfoFromChallenge(ByVal challenge As String, ByVal ci As TConnectionInfo) As Boolean
    End Function

    '//! 451.6
    '//! DeleteUserVariable - delete extended user section or key
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function DeleteUserVariable(ByVal id As Integer, ByVal section As String, ByVal key As String) As Boolean
    End Function

    '//! 451.9
    '//! WcCheckUserName - Return FALSE if user name has invalid characters
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WcCheckUserName(ByVal szName As String) As Boolean
    End Function

    '//! 451.9
    '//! WcSetMessageAttachments - helps prepare attachment field
    <DllImport("wcvb.dll", EntryPoint:="vbWcSetMessageAttachment", SetLastError:=True)> Public Function WcSetMessageAttachment(ByVal msg As TMsgHeader, ByVal szFileName As String, ByVal bCopyTo As Integer) As Boolean
    End Function

    '//!
    '//! WcLocalCopyToServer - copy local side file to server side wc:\ file
    '//!
    <DllImport("wcsrv2.dll", SetLastError:=True)> Public Function WcLocalCopyToServer(ByVal szLocal As String, ByVal szServer As String, ByVal msSlice As Integer) As Boolean
    End Function

#End Region

End Module
