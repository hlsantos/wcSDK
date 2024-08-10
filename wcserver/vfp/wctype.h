*********************************************************
**     Wildcat! SDK/API for Microsoft Visual Foxpro    **
**     (c) copyright 2001 Santronics Software Inc.     **
*********************************************************
** File: wctype.h
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

#DEFINE MAX_PATH                                      260
#DEFINE WILDCAT_FRAMEWORK_VERSION                     1
#DEFINE WILDCAT_MKTG_VERSION                          6
#DEFINE WILDCAT_MARKETING_VERSION                     "6.0"
#DEFINE WILDCAT_COMPONENT_ICP                         0x00000001
#DEFINE WILDCAT_COMPONENT_SSL                         0x00000002
#DEFINE SIZE_SHORT_FILE_NAME                          16
#DEFINE SIZE_LONG_FILE_NAME                           MAX_PATH
#DEFINE SIZE_VOLUME_NAME                              16
#DEFINE SIZE_CALLTYPE                                 32
#DEFINE SIZE_COMPUTER_NAME                            16
#DEFINE SIZE_CONFERENCE_NAME                          60
#DEFINE SIZE_CONFERENCEGROUP_NAME                     32
#DEFINE SIZE_DOMAIN_NAME                              64
#DEFINE SIZE_DOOR_NAME                                40
#DEFINE SIZE_ENCODED_PASSWORD                         20
#DEFINE SIZE_EXTENSION                                4
#DEFINE SIZE_FILEAREA_NAME                            32
#DEFINE SIZE_FILEGROUP_NAME                           32
#DEFINE SIZE_LANGUAGE_NAME                            12
#DEFINE SIZE_MENU_DESCRIPTION                         40
#DEFINE SIZE_MODEM_NAME                               32
#DEFINE SIZE_PASSWORD                                 32
#DEFINE SIZE_SECURITY_NAME                            24
#DEFINE SIZE_SERVICE_NAME                             64
#DEFINE SIZE_USER_NAME                                72
#DEFINE SIZE_MAKEWILD_BBSNAME                         52
#DEFINE SIZE_MAKEWILD_CITY                            32
#DEFINE SIZE_MAKEWILD_PHONE                           28
#DEFINE SIZE_MAKEWILD_FIRSTCALL                       28
#DEFINE SIZE_MAKEWILD_PACKETID                        12
#DEFINE SIZE_MAKEWILD_REGSTRING                       8
#DEFINE MAX_USER_NAME                                 28
#DEFINE MASK_OBJECTCLASS                              0xFF000000
#DEFINE OBJECTCLASS_RIGHTS                            0x01000000
#DEFINE OBJECTCLASS_CONFERENCE                        0x02000000
#DEFINE OBJECTCLASS_CONFERENCEGROUP                   0x03000000
#DEFINE OBJECTCLASS_FILEAREA                          0x04000000
#DEFINE OBJECTCLASS_FILEGROUP                         0x05000000
#DEFINE OBJECTCLASS_DOOR                              0x06000000
#DEFINE OBJECTCLASS_MENU                              0x07000000
#DEFINE OBJECTCLASS_CODE                              0x08000000
#DEFINE OBJECTCLASS_CLIENT                            0x09000000
#DEFINE OBJECTCLASS_SAPPHIRE_QUERY                    0x0a000000
#DEFINE OBJECTCLASS_CHAT_CHANNEL                      0x0b000000
#DEFINE OBJECTCLASS_RADIUS_CLIENT                     0x0c000000
#DEFINE OBJECTCLASS_DOMAINS                           0x0d000000
#DEFINE OBJECTID_BULLETINS_OPTIONAL                   OBJECTCLASS_RIGHTS + 1
#DEFINE OBJECTID_CHANGE_PHONE                         OBJECTCLASS_RIGHTS + 2
#DEFINE OBJECTID_CHANGE_BIRTHDATE                     OBJECTCLASS_RIGHTS + 4
#DEFINE OBJECTID_QWK_ALLOW_BULLETINS                  OBJECTCLASS_RIGHTS + 5
#DEFINE OBJECTID_QWK_ALLOW_NEWS                       OBJECTCLASS_RIGHTS + 6
#DEFINE OBJECTID_QWK_ALLOW_FILES                      OBJECTCLASS_RIGHTS + 7
#DEFINE OBJECTID_QWK_DETAIL_DOWNLOAD                  OBJECTCLASS_RIGHTS + 8
#DEFINE OBJECTID_QWK_CHECK_DUPES                      OBJECTCLASS_RIGHTS + 9
#DEFINE OBJECTID_QWK_SAVE_PACKETS                     OBJECTCLASS_RIGHTS + 10
#DEFINE OBJECTID_MASTER_SYSOP                         OBJECTCLASS_RIGHTS + 11
#DEFINE OBJECTID_RATIO_ACTION                         OBJECTCLASS_RIGHTS + 12
#DEFINE OBJECTID_ALLOW_FAST_LOGIN                     OBJECTCLASS_RIGHTS + 13
#DEFINE OBJECTID_ALLOW_OVERWRITE_FILES                OBJECTCLASS_RIGHTS + 14
#DEFINE OBJECTID_SHOW_PASSWORD_FILES                  OBJECTCLASS_RIGHTS + 15
#DEFINE OBJECTID_ALLOW_OFFLINE_FILE_REQUESTS          OBJECTCLASS_RIGHTS + 16
#DEFINE OBJECTID_ALLOW_UPLOAD_OVER_TIME               OBJECTCLASS_RIGHTS + 17
#DEFINE OBJECTID_ALLOW_DOWNLOAD_OVER_TIME             OBJECTCLASS_RIGHTS + 18
#DEFINE OBJECTID_ALLOW_UPLOADER_MODIFY_FILE           OBJECTCLASS_RIGHTS + 20
#DEFINE OBJECTID_QWK_NETSTATUS                        OBJECTCLASS_RIGHTS + 26
#DEFINE OBJECTID_SYSOP_READ_PRIVATE_MAIL              OBJECTCLASS_RIGHTS + 27
#DEFINE OBJECTID_ALLOW_INTERNET_EMAIL                 OBJECTCLASS_RIGHTS + 28
#DEFINE OBJECTID_ALLOW_ANY_TELNET                     OBJECTCLASS_RIGHTS + 29
#DEFINE OBJECTID_ALLOW_ANY_FTP                        OBJECTCLASS_RIGHTS + 30
#DEFINE OBJECTID_ALLOW_HTTP_PROXY                     OBJECTCLASS_RIGHTS + 31
#DEFINE OBJECTID_ALLOW_ALL_IP                         OBJECTCLASS_RIGHTS + 32
#DEFINE OBJECTID_ALLOW_DEFAULT_IP                     OBJECTCLASS_RIGHTS + 33
#DEFINE OBJECTID_ALLOW_PPP                            OBJECTCLASS_RIGHTS + 34
#DEFINE OBJECTID_IGNORE_TIME_ONLINE                   OBJECTCLASS_RIGHTS + 35
#DEFINE OBJECTID_IGNORE_IDLE_TIME                     OBJECTCLASS_RIGHTS + 36
#DEFINE OBJECTID_ALLOW_SMTP_AUTH                      OBJECTCLASS_RIGHTS + 37
#DEFINE OBJECTID_ALLOW_NNTP_ACCESS                    OBJECTCLASS_RIGHTS + 38
#DEFINE OBJECTID_USERBIN_ACCESS                       OBJECTCLASS_RIGHTS + 39
#DEFINE OBJECTID_ALLOW_FTP_ACCESS                     OBJECTCLASS_RIGHTS + 40
#DEFINE OBJECTID_ALLOW_WEB_ACCESS                     OBJECTCLASS_RIGHTS + 41
#DEFINE OBJECTID_ALLOW_TELNET_ACCESS                  OBJECTCLASS_RIGHTS + 42
#DEFINE OBJECTID_CHANGE_EMAILADDRESS                  OBJECTCLASS_RIGHTS + 43
#DEFINE OBJECTID_CHANGE_SMTPFORWARD                   OBJECTCLASS_RIGHTS + 44
#DEFINE OBJECTID_PROTOCOL_ACCESS                      OBJECTCLASS_RIGHTS + 0x00010000
#DEFINE OBJECTID_NODE_ACCESS                          OBJECTCLASS_RIGHTS + 0x00020000
#DEFINE OBJECTFLAGS_CONFERENCE_JOIN                   0x00000001
#DEFINE OBJECTFLAGS_CONFERENCE_READ                   0x00000002
#DEFINE OBJECTFLAGS_CONFERENCE_WRITE                  0x00000004
#DEFINE OBJECTFLAGS_CONFERENCE_SYSOP                  0x00000008
#DEFINE OBJECTFLAGS_FILEAREA_LIST                     0x00000001
#DEFINE OBJECTFLAGS_FILEAREA_DOWNLOAD                 0x00000002
#DEFINE OBJECTFLAGS_FILEAREA_UPLOAD                   0x00000004
#DEFINE OBJECTFLAGS_FILEAREA_SYSOP                    0x00000008
#DEFINE MSF_FORWARD                                   0x00000001
#DEFINE MSF_FROM                                      0x00000002
#DEFINE MSF_TO                                        0x00000004
#DEFINE MSF_SUBJECT                                   0x00000008
#DEFINE MSF_BODY                                      0x00000010
#DEFINE CONNECT_RAW                                   0
#DEFINE CONNECT_TELNET_ASCII                          1
#DEFINE CONNECT_TELNET_7BIT                           2
#DEFINE CONNECT_TELNET_8BIT                           3
#DEFINE UserIdKey                                     0
#DEFINE UserNameKey                                   1
#DEFINE UserLastNameKey                               2
#DEFINE UserSecurityKey                               3
#DEFINE FileNameAreaKey                               0
#DEFINE FileAreaNameKey                               1
#DEFINE FileAreaDateKey                               2
#DEFINE FileUploaderKey                               3
#DEFINE FileDateAreaKey                               4
#DEFINE CHANNEL_MESSAGE_HEADER_SIZE                   12
#DEFINE MAX_CHANNEL_MESSAGE_SIZE                      500

#DEFINE saOpen                                        0
#DEFINE saClosed                                      1
#DEFINE saClosedQuestionnaire                         2
#DEFINE saClosedValidation                            3

#DEFINE dusNone                                       0
#DEFINE dusAsk                                        1
#DEFINE dusAllow                                      2

#DEFINE mhcUpperCase                                  0
#DEFINE mhcLowerCase                                  1
#DEFINE mhcAsIs                                       2

#DEFINE pNone                                         0
#DEFINE pAscii                                        1
#DEFINE pXmodem                                       2
#DEFINE pXmodemCRC                                    3
#DEFINE pXmodem1K                                     4
#DEFINE pXmodem1KG                                    5
#DEFINE pYmodem                                       6
#DEFINE pYmodemG                                      7
#DEFINE pKermit                                       8
#DEFINE pZmodem                                       9
#DEFINE NumProtocols                                  10

#DEFINE fiaAllow                                      0
#DEFINE fiaLogoff                                     1
#DEFINE fiaLockout                                    2

#DEFINE ipfilterDeny                                  0
#DEFINE ipfilterAllow                                 1
#DEFINE ipfilterNone                                  2
#DEFINE pop3MarkRcvd                                  0x0001
#DEFINE pop3HonorRR                                   0x0002
#DEFINE pop3ResolveHost                               0x0020
#DEFINE smtpBit0                                      0x0001
#DEFINE smtpRcvdBin                                   0x0002
#DEFINE smtpNoMXOnce                                  0x0004
#DEFINE smtpIpFilter                                  0x0008
#DEFINE smtpIncMXTries                                0x0010
#DEFINE smtpResolveHost                               0x0020
#DEFINE smtpDisableETRN                               0x0040
#DEFINE ftpBit0                                       0x0001
#DEFINE ftpUnixFileAge                                0x0002
#DEFINE ftpUseFtpLimit                                0x0004
#DEFINE ftpCheckForDIZ                                0x0008
#DEFINE ftpResolveHost                                0x0020
#DEFINE pwdChangeForce                                0x0001
#DEFINE pwdChangeDisallow                             0x0002
#DEFINE pwdChangeExpire                               0x0004
#DEFINE pwdExpireLockout                              0x0008
#DEFINE nntpAllowAnony                                0x0001
#DEFINE nntpResolveHost                               0x0020
#DEFINE httpEnableProxy                               0x0001
#DEFINE httpCommonLogFile                             0x0002
#DEFINE httpDeutschIVW                                0x0004
#DEFINE httpResolveHost                               0x0020
#DEFINE telnetEnableRLogin                            0x0001
#DEFINE telnetResolveHost                             0x0020
#DEFINE lh12am                                        0x00000001
#DEFINE lh1am                                         0x00000002
#DEFINE lh2am                                         0x00000004
#DEFINE lh3am                                         0x00000008
#DEFINE lh4am                                         0x00000010
#DEFINE lh5am                                         0x00000020
#DEFINE lh6am                                         0x00000040
#DEFINE lh7am                                         0x00000080
#DEFINE lh8am                                         0x00000100
#DEFINE lh9am                                         0x00000200
#DEFINE lh10am                                        0x00000400
#DEFINE lh11am                                        0x00000800
#DEFINE lh12pm                                        0x00001000
#DEFINE lh1pm                                         0x00002000
#DEFINE lh2pm                                         0x00004000
#DEFINE lh3pm                                         0x00008000
#DEFINE lh4pm                                         0x00010000
#DEFINE lh5pm                                         0x00020000
#DEFINE lh6pm                                         0x00040000
#DEFINE lh7pm                                         0x00080000
#DEFINE lh8pm                                         0x00100000
#DEFINE lh9pm                                         0x00200000
#DEFINE lh10pm                                        0x00400000
#DEFINE lh11pm                                        0x00800000
#DEFINE lhAllHours                                    0x00FFFFFF
#DEFINE lhSun                                         0x01
#DEFINE lhMon                                         0x02
#DEFINE lhTue                                         0x04
#DEFINE lhWed                                         0x08
#DEFINE lhThu                                         0x10
#DEFINE lhFri                                         0x20
#DEFINE lhSat                                         0x40
#DEFINE lhAllDays                                     0x7F
#DEFINE lhStartofWeek                                 lhSun
#DEFINE lhEndofWeek                                   lhSat
#DEFINE SIZE_CONFERENCE_ECHOTAG                       64

#DEFINE mtNormalPublicPrivate                         0
#DEFINE mtNormalPublic                                1
#DEFINE mtNormalPrivate                               2
#DEFINE mtFidoNetmail                                 3
#DEFINE mtEmailOnly                                   4
#DEFINE mtUsenetNewsgroup                             5
#DEFINE mtUsenetNewsgroupModerated                    6
#DEFINE mtInternetMailingList                         7

#DEFINE vnYes                                         0
#DEFINE vnNo                                          1
#DEFINE vnPrompt                                      2
#DEFINE maAllowMailSnooping                           0x00000001
#DEFINE maPreserveMime                                0x00000002

#DEFINE authorDefaultName                             0
#DEFINE authorForceUserName                           1
#DEFINE authorForceAliasName                          2
#DEFINE authorAllowBoth                               3
#DEFINE authorAnonymousName                           4
#DEFINE faIsVolume                                    0x00000001
#DEFINE faAllowPrivateFiles                           0x00000002
#DEFINE faAllowFolderWatch                            0x00000004

#DEFINE dtGeneric16                                   0
#DEFINE dtDoor32                                      1
#DEFINE dtDoorway                                     2
#DEFINE SIZE_LANGUAGE_DESCRIPTION                     72
#DEFINE MAX_LANGUAGE_SUBCOMMAND_CHARS                 100
#DEFINE LSC_YES                                       0
#DEFINE LSC_NO                                        1
#DEFINE SIZE_MODEM_STRING                             64

#DEFINE aRing                                         0
#DEFINE aResult                                       1
#DEFINE aAutoAnswer                                   2
#DEFINE CALLTYPE_LOCAL                                0x00000001
#DEFINE CALLTYPE_DIALUP                               0x00000002
#DEFINE CALLTYPE_TELNET                               0x00000004
#DEFINE CALLTYPE_FTP                                  0x00000008
#DEFINE CALLTYPE_HTTP                                 0x00000010
#DEFINE CALLTYPE_FRONTEND                             0x00000020
#DEFINE CALLTYPE_POP3                                 0x00000040
#DEFINE CALLTYPE_SMTP                                 0x00000080
#DEFINE CALLTYPE_PPP                                  0x00000100
#DEFINE CALLTYPE_RADIUS                               0x00000200
#DEFINE CALLTYPE_NNTP                                 0x00000400
#DEFINE CALLTYPE_HTTPS                                0x00000800
#DEFINE SIZE_NODECONFIG_COMPUTER                      16
#DEFINE SIZE_NODECONFIG_PORTNAME                      16
#DEFINE SIZE_SERVERSTATE_PORT                         80
#DEFINE SERVERSTATE_OFFLINE                           0
#DEFINE SERVERSTATE_DOWN                              1
#DEFINE SERVERSTATE_REFUSE                            2
#DEFINE SERVERSTATE_UP                                3
#DEFINE MENU_TOPLEVEL                                 0x00000002
#DEFINE MAX_MENU_ITEMS                                40
#DEFINE SIZE_MENUITEM_SELECTION                       16
#DEFINE SIZE_MENUITEM_DESCRIPTION                     32
#DEFINE SIZE_MENUITEM_COMMAND                         48
#DEFINE SIZE_USER_TITLE                               12

#DEFINE clSessionNone                                 0
#DEFINE clSessionUser                                 1
#DEFINE clSessionSystem                               2
#DEFINE clSessionConfig                               3

#DEFINE nsDown                                        0
#DEFINE nsUp                                          1
#DEFINE nsSigningOn                                   2
#DEFINE nsLoggedIn                                    3
#DEFINE SIZE_NODEINFO_ACTIVITY                        32
#DEFINE SIZE_NODEINFO_SPEED                           8
#DEFINE SIZE_NODEINFO_LASTCALLER                      48
#DEFINE SIZE_USER_FROM                                32
#DEFINE ucstNone                                      0
#DEFINE ucstPersonal                                  1
#DEFINE ucstPersonalAll                               2
#DEFINE ucstAll                                       3
#DEFINE ucstMask                                      0x0F
#DEFINE ucfReserved1                                  0x10
#DEFINE ucfReserved2                                  0x20
#DEFINE ucfReserved3                                  0x40
#DEFINE ucfAllAttach                                  0x80
#DEFINE SIZE_USER_PHONE                               16
#DEFINE SIZE_USER_ADDRESS                             32
#DEFINE SIZE_USER_STATE                               16
#DEFINE SIZE_USER_ZIP                                 12
#DEFINE NUM_USER_SECURITY                             10

#DEFINE sNotDisclosed                                 0
#DEFINE sMale                                         1
#DEFINE sFemale                                       2

#DEFINE ePrompt                                       0
#DEFINE eLine                                         1
#DEFINE eFullScreen                                   2

#DEFINE hlNovice                                      0
#DEFINE hlRegular                                     1
#DEFINE hlExpert                                      2

#DEFINE ttAuto                                        0
#DEFINE ttTTY                                         1
#DEFINE ttAnsi                                        2

#DEFINE fdSingle                                      0
#DEFINE fdDouble                                      1
#DEFINE fdFull                                        2
#DEFINE fdAnsi                                        3

#DEFINE mdScroll                                      0
#DEFINE mdClear                                       1
#DEFINE mdKeepHeader                                  2

#DEFINE ptText                                        0
#DEFINE ptQwk                                         1
#DEFINE ptOPX                                         2

#DEFINE vsNone                                        0
#DEFINE vsValidationRequired                          1
#DEFINE vsPrevalidated                                2
#DEFINE vsValidated                                   3
#DEFINE SIZE_MESSAGE_SUBJECT                          72
#DEFINE SIZE_MESSAGE_NETWORK                          12
#DEFINE mfPOP3Received                                0x01000000
#DEFINE mfReceiptCreated                              0x02000000
#DEFINE mfSmtpDelivered                               0x04000000
#DEFINE mfNNTPPost                                    0x08000000
#DEFINE mfMimeSaved                                   0x00000001
#DEFINE mfNoDupeChecking                              0x00000002
#DEFINE SIZE_FILE_DESCRIPTION                         76
#DEFINE MAX_FILE_LONGDESC_LINES                       15
#DEFINE SIZE_FILE_LONGDESC                            80
#DEFINE ffAbortedUpload                               0x00000001
#DEFINE SC_WATCH_REQUEST                              0
#DEFINE SC_DISPLAY_UPDATE                             1
#DEFINE SC_PUSH_KEY                                   2
#DEFINE SC_SECURITY_CHANGE                            3
#DEFINE SC_DISCONNECT                                 4
#DEFINE SC_TIME_CHANGE                                5
#DEFINE SC_USER_RECORD_CHANGE                         6
#DEFINE SP_USER_PAGE                                  0
#DEFINE SP_SYSOP_CHAT                                 1
#DEFINE SP_NEW_MESSAGE                                2
#DEFINE SP_ALT_NUMBER_FILE                            3
#DEFINE SE_FILE_UPLOAD                                10
#DEFINE SE_FILE_DOWNLOAD                              11
#DEFINE SE_FILE_DELETE                                12
#DEFINE SE_FILE_UPDATE                                13
#DEFINE SE_SHUTDOWN_REQUEST                           20
#DEFINE SE_RESTART                                    21
#DEFINE SE_CONFIG_CHANGE                              22
#DEFINE SE_POPCONNECT                                 23
#DEFINE SE_SERVER_STATE_CHANGE                        30
#DEFINE SE_NODE_STATE_CHANGE                          31
#DEFINE SE_MAILSERVER_UPDATE                          40
#DEFINE SIZE_SYSTEMPAGE_LINES                         3
#DEFINE SIZE_SYSTEMPAGE_TEXT                          80
#DEFINE WCSASL_SUCCESS                                0
#DEFINE WCSASL_AUTH_OK                                WCSASL_SUCCESS
#DEFINE WCSASL_AUTH_FAIL                              1
#DEFINE WCSASL_INVALID_METHOD                         2
#DEFINE WCSASL_GET_RESPONSE                           3
#DEFINE WCSASL_GET_PASSWORD                           4
#DEFINE WCSASL_LOOKUPUSER                             5
#DEFINE SIZE_SASL_NAME                                32

** Structure Sizes **

#DEFINE SIZE_TCHANNELMESSAGE                          512
#DEFINE SIZE_TPAGEMESSAGE                             112
#DEFINE SIZE_TCHATMESSAGE                             285
#DEFINE SIZE_TOBJECTNAME                              272
#DEFINE SIZE_TWILDCATTIMEOUTS                         124
#DEFINE SIZE_TWILDCATLOGOPTIONS                       28
#DEFINE SIZE_TWILDCATHTTPD                            80
#DEFINE SIZE_TWILDCATSMTP                             176
#DEFINE SIZE_TWILDCATNNTP                             96
#DEFINE SIZE_TWILDCATPOP3                             96
#DEFINE SIZE_TWILDCATTELNET                           96
#DEFINE SIZE_TWILDCATFTP                              92
#DEFINE SIZE_TMAKEWILD                                900
#DEFINE SIZE_TWILDCATCOMPUTERIPPORT                   8
#DEFINE SIZE_TCOMPUTERCONFIG                          976
#DEFINE SIZE_TLOGONHOURS                              7
#DEFINE SIZE_TSECURITYPROFILE                         228
#DEFINE SIZE_TCONFDESC                                484
#DEFINE SIZE_TSHORTCONFDESC                           68
#DEFINE SIZE_TCONFERENCEGROUP                         64
#DEFINE SIZE_TFILEAREA                                84
#DEFINE SIZE_TSHORTFILEAREA                           36
#DEFINE SIZE_TFILEGROUP                               64
#DEFINE SIZE_TDOORINFO                                128
#DEFINE SIZE_TLANGUAGEINFO                            256
#DEFINE SIZE_TSHORTMODEMPROFILE                       36
#DEFINE SIZE_TMODEMPROFILE                            1314
#DEFINE SIZE_TNODECONFIG                              128
#DEFINE SIZE_TSERVERSTATE                             104
#DEFINE SIZE_TWCMENUITEM                              148
#DEFINE SIZE_TMENU                                    264
#DEFINE SIZE_TUSERINFO                                88
#DEFINE SIZE_TWCNODEINFO                              168
#DEFINE SIZE_TUSER                                    592
#DEFINE SIZE_TFIDOADDRESS                             8
#DEFINE SIZE_TMSGHEADER                               320
#DEFINE SIZE_TFILERECORD                              344
#DEFINE SIZE_TFULLFILERECORD                          340
#DEFINE SIZE_TFILERECORD5                             244
#DEFINE SIZE_TFULLFILERECORD5                         340
#DEFINE SIZE_TSPELLSUGGESTLIST                        32
#DEFINE SIZE_TSYSTEMEVENTFILEINFO                     16
#DEFINE SIZE_TSYSTEMCONTROLVIEWMSG                    13
#DEFINE SIZE_TSYSTEMPAGENEWMESSAGE                    140
#DEFINE SIZE_TSYSTEMPAGEINSTANTMESSAGE                112
#DEFINE SIZE_TWILDCATSERVICE                          140
#DEFINE SIZE_TCONNECTIONINFO                          496
#DEFINE SIZE_TWILDCATSERVERINFO                       124
#DEFINE SIZE_TWILDCATPROCESSTIMES                     64
#DEFINE SIZE_TWILDCATSASLCONTEXT                      5920
