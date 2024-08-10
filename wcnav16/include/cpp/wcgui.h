// Responsibility::GDH

#ifndef __WCGUI_H
#define __WCGUI_H

#include "wctype.h"
#include "wctype5.h"

const DWORD SIZE_PACKAGE_NAME       = 64;
const DWORD SIZE_PACKAGE_VERSION    = 10;

#pragma pack(1)

typedef WORD TWildcatRequestType;

enum {
 /*   0 */ wrNone,
 /*   1 */ wrLoginUser,
 /*   2 */ wrGetConferenceCount,
 /*   3 */ wrGetEffectiveConferenceCount,
 /*   4 */ wrGetConfDescs,
 /*   5 */ wrGetConferenceGroupCount,
 /*   6 */ wrGetEffectiveConferenceGroupCount,
 /*   7 */ wrGetConferenceGroups,
 /*   8 */ wrGetConferenceGroupAreas,
 /*   9 */ wrAddMessage,
 /*  10 */ wrGetFileGroupCount,
 /*   1 */ wrGetEffectiveFileGroupCount,
 /*   2 */ wrGetFileGroups,
 /*   3 */ wrGetFileGroupAreas,
 /*   4 */ wrGetFileAreaCount,
 /*   5 */ wrGetEffectiveFileAreaCount,
 /*   6 */ wrGetFileAreas,
 /*   7 */ wrListFilesByName,
 /*   8 */ wrListFilesByDate,
 /*   9 */ wrListFilesBySearch,
 /*  20 */ wrGetFileDescription,
 /*   1 */ wrGetCurrentUser,
 /*   2 */ wrUpdateCurrentUser,
 /*   3 */ wrGetUserInfo,
 /*   4 */ wrGetWhosOnline,
 /*   5 */ wrDownloadFile,
 /*   6 */ wrUploadFile,
 /*   7 */ wrUploadAttachment,
 /*   8 */ wrGetSystemInfo,
 /*   9 */ wrGetObjectFlags,
 /*  30 */ wrResolveFileName,
 /*   1 */ wrGetUserList,
 /*   2 */ wrDeleteFile,
 /*   3 */ wrViewArchive,
 /*   4 */ wrGetNodeInfoByName,
 /*   5 */ wrSetLastRead,
 /*   6 */ wrDeleteMessage,
 /*   7 */ wrSetConferenceFlags,
 /*   8 */ wrGetPackageVersion,
 /*   9 */ wrSearchUserNames,
 /*  40 */ wrListMessagesByAreaNumber,
 /*   1 */ wrListMessagesByAreaMsgId,
 /*   2 */ wrListMessagesByAreaDate,
 /*   3 */ wrListMessagesBySearch,
 /*   4 */ wrListMessagesByUnread,
 /*   5 */ wrSetMultipleConferenceFlags,
 /*   6 */ wrUpdateFileInfo,
 /*   7 */ wrGetObjectFlagsByName,
 /*   8 */ wrRequestOfflineFiles,
 /*   9 */ wrGetSecurityProfile,
 /*  50 */ wrGetDownloadStats,
 /*   1 */ wrMarkMessageRead,
 /*   2 */ wrGetVolatileConfInfo,
 /*   3 */ wrListConferencesByNumber,
 /*   4 */ wrListConferencesByName,
 /*   5 */ wrListMessagesBackwardsByMsgId,
 /*   6 */ wrListMessagesBackwardsByNumber,
 /*   7 */ wrKeepAlive,
 /*   8 */ wrGetVolatileConfInfoEx,
 /*   9 */ wrGetTimeLeftOnline,
 /*  60 */ wrWriteActivityLogEntry,
 /*   1 */ wrUploadFileEx,
 /*   2 */ wrGetServiceByName,
 /*   3 */ wrGetServerContextHandle,
 /*   4 */ wrCopyBeforeDownload,
 /*   5 */ wrGetServerChallengeString,
 /*   6 */ wrGetPredefinedChatChannels,
 /*   7 */ wrGetObjectInfo,
 /*   8 */ wrMAX
};

enum {
 /* 256 */ wrListFiles_SetFileArea = 256,
 /*   7 */ wrListFiles_SetFileAreaDone,
 /*   8 */ wrFileTransfer_Data,
 /*   9 */ wrFileTransfer_Error,
 /* 260 */ wrAddMessage_Text,
 /*   1 */ wrViewArchive_Data,
 /*   2 */ wrSearchMessages_SetConfs,
 /*   3 */ wrSearchMessages_SetConfsDone,
 /*   4 */ wrUploadAttachment_SetMessage,
 /*   5 */ wrUploadAttachment_SetMessageDone,
 /*   6 */ wrListMessages_GetMore,
 /*   7 */ wrListMessages_GetAll,
 /*   8 */ wrSetMultipleConferenceFlags_SetAll,
 /*   9 */ wrSetMultipleConferenceFlags_SetData,
 /* 270 */ wrSetMultipleConferenceFlags_SetDone,
 /*   1 */ wrListFiles_GetMore,
 /*   2 */ wrListFiles_GetAll,
 /*   3 */ wrListFiles_Pause,
 /*   4 */ wrListMessages_MsgHeader,
 /*   5 */ wrListMessages_MsgText,
 /*   6 */ wrRequestOfflineFiles_Submit,
 /*   7 */ wrRequestOfflineFiles_Done,
 /*   8 */ wrGetVolatileConfInfo_SetConfs,
 /*   9 */ wrGetVolatileConfInfo_SetConfsDone,
 /* 280 */ wrCopyBeforeDownload_Submit,
 /*   1 */ wrCopyBeforeDownload_Status,
 /*   2 */ wrCopyBeforeDownload_Remove,
};

const DWORD NAV_STATUS_BASE                   = 0x40000000;

const DWORD NAV_SUCCESS                       = NAV_STATUS_BASE + 0;
const DWORD NAV_DOWNLOAD_OVER_DAILY_KBYTE     = NAV_STATUS_BASE + 1;
const DWORD NAV_DOWNLOAD_OVER_DAILY_COUNT     = NAV_STATUS_BASE + 2;
const DWORD NAV_DOWNLOAD_OVER_KBYTE_RATIO     = NAV_STATUS_BASE + 3;
const DWORD NAV_DOWNLOAD_OVER_DOWNLOAD_RATIO  = NAV_STATUS_BASE + 4;
const DWORD NAV_DOWNLOAD_INSUFFICIENT_BALANCE = NAV_STATUS_BASE + 5;
const DWORD NAV_USER_OUT_OF_TIME              = NAV_STATUS_BASE + 6;
const DWORD NAV_REQUEST_OUT_OF_ORDER          = NAV_STATUS_BASE + 7;
const DWORD NAV_USER_NOT_FOUND                = NAV_STATUS_BASE + 8;

const SIZE_FILE_DATA_BLOCK = 1024;

///////////////////////////////////////////////////////////////////////////////////////////////////

struct TWildcatRequest {
  TWildcatRequestType type;
};

struct TSortedList_Request: public TWildcatRequest {
  DWORD sorted;
};

///////////////////////////////////////////////////////////////////////////////////////////////////

const DWORD LOGIN_NETSCAPE_16        = 0x00000001;
const DWORD LOGIN_NETSCAPE_32        = 0x00000002;
const DWORD LOGIN_IEXPLORER_16       = 0x00000004;
const DWORD LOGIN_IEXPLORER_32       = 0x00000008;
const DWORD LOGIN_NO_QUESNEW         = 0x00000100;
const DWORD LOGIN_IGNORE_IDLE_TIME   = 0x00000200;
const DWORD LOGIN_IGNORE_TIME_ONLINE = 0x00000400;

struct TLoginUser_Request: public TWildcatRequest {
  WORD ClientRequestTypes;
  char Name[MAX_USER_NAME];
  char Password[40]; // size enough for an MD5 hashed password response
  BYTE AddNewUser; // Password field must contain plaintext password in this case
};

struct TLoginUser_Response: public TWildcatRequest {
  DWORD error;
  DWORD SystemAccess;
  DWORD MaxLoginAttempts;
  char Info[420];
  char WWWHostname[80];
  WORD ServerRequestTypes;
  DWORD Flags;
  WORD IdleTimeout;  //HLS 447.3 09/11/99 01:33 am
  BYTE Reserved[4];  //HLS 447.3 was 6
};

///////////////////////////////////////////////////////////////////////////////////////////////////

struct TGetCount_Response: public TWildcatRequest {
  DWORD count;
};

///////////////////////////////////////////////////////////////////////////////////////////////////

const DWORD guiShowPasswordFiles = 0x01;
const DWORD guiWindowsCharset    = 0x02;
const DWORD guiNAVSMTP           = 0x04;

struct TGetSystemInfo_Response: public TWildcatRequest {
  char BBSName[SIZE_MAKEWILD_BBSNAME];
  char SysopName[MAX_USER_NAME];
  char RegString[SIZE_MAKEWILD_REGSTRING];
  char PacketId[SIZE_MAKEWILD_PACKETID];
  DWORD Flags;
};

///////////////////////////////////////////////////////////////////////////////////////////////////

struct TGetObjectFlags_Request: public TWildcatRequest {
  DWORD ObjectID;
};

struct TGetObjectFlags_Response: public TWildcatRequest {
  DWORD Flags;
};

struct TGetObjectFlagsByName_Request: public TWildcatRequest {
  char ObjectName[MAX_PATH];
};

///////////////////////////////////////////////////////////////////////////////////////////////////

struct TGetObjectInfo_Request: public TWildcatRequest {
  DWORD ObjectId;
  DWORD ObjectClass;
  char ObjectName[MAX_PATH];
};

struct TGetObjectInfo_Response: public TWildcatRequest {
  DWORD ObjectId;
  DWORD ObjectFlags;
  DWORD ObjectNumber;
  char ObjectName[MAX_PATH];
};

///////////////////////////////////////////////////////////////////////////////////////////////////

struct TGetServiceByName_Request: public TWildcatRequest {
  char name[SIZE_SERVICE_NAME];
};

struct TGetServiceByName_Response: public TWildcatRequest {
  TWildcatService info;
};

///////////////////////////////////////////////////////////////////////////////////////////////////

const int MAX_LOGENTRY_LEN = 256;

struct TWriteActivityLogEntry_Request: public TWildcatRequest {
  DWORD len;
  char text[MAX_LOGENTRY_LEN];
};

///////////////////////////////////////////////////////////////////////////////////////////////////

struct TGetTimeLeftOnline_Response: public TWildcatRequest {
  DWORD TimeLeft;
};

///////////////////////////////////////////////////////////////////////////////////////////////////

struct TGetServerContextHandle_Response: public TWildcatRequest {
  DWORD handle;
};

///////////////////////////////////////////////////////////////////////////////////////////////////

const WORD MAX_CHALLENGE_LEN = 80;

struct TGetServerChallengeString_Response: public TWildcatRequest {
  DWORD len;
  char data[MAX_CHALLENGE_LEN];
};

///////////////////////////////////////////////////////////////////////////////////////////////////

const WORD guiPromptToKillMsg    = 0x01;
const WORD guiPromptToKillAttach = 0x02;
const WORD guiAllowHighAscii     = 0x04;
const WORD guiAllowCarbon        = 0x08;
const WORD guiAllowReturnReceipt = 0x10;
const WORD guiLongHeaderFormat   = 0x20;
const WORD guiAllowAttach        = 0x40;

struct TGuiConfDesc {
  DWORD Number;
  char Name[SIZE_CONFERENCE_NAME];
  char ConfSysop[SIZE_USER_NAME];
  BYTE MailType;
  DWORD HiMsg;
  DWORD HiMsgId;
  DWORD LoMsg;
  DWORD LoMsgId;
  DWORD LastRead;
  DWORD ConfAccess;
  DWORD ConfFlags;
  DWORD ValidNames;
  DWORD FirstUnread;
  DWORD ReadFlags;
};

//struct TGetConfDescs_Request: public TWildcatRequest {
//  DWORD conference;
//  DWORD count;
//};

struct TGetConfDescs_Response: public TWildcatRequest {
  TGuiConfDesc cd;
};

const DWORD LISTCONFERENCES_GETALL = 0xFFFFFFFF;

struct TListConferencesByNumber_Request: public TWildcatRequest {
  DWORD start;
  DWORD count;
};

struct TListConferencesByName_Request: public TWildcatRequest {
  char name[SIZE_CONFERENCE_NAME];
  DWORD count;
};

struct TGetVolatileConfInfo_SetConfs: public TWildcatRequest {
  DWORD start;
  DWORD count;
};

struct TGetVolatileConfInfo_Response: public TWildcatRequest {
  DWORD Conf;
  DWORD HiMsg;
  DWORD HiMsgId;
  DWORD LoMsg;
  DWORD LoMsgId;
  DWORD LastRead;
  DWORD FirstUnread;
};

struct TGetVolatileConfInfoEx_Response: public TWildcatRequest {
  DWORD Conf;
  DWORD HiMsg;
  DWORD HiMsgId;
  DWORD LoMsg;
  DWORD LoMsgId;
  DWORD LastRead;
  DWORD FirstUnread;
  DWORD ReadFlags;
};

//struct TGetConferenceGroups_Request: public TWildcatRequest {
//  DWORD group;
//  DWORD count;
//};

struct TGetConferenceGroups_Response: public TWildcatRequest {
  TConferenceGroup cg;
};

struct TGetConferenceGroupAreas_Request: public TWildcatRequest {
  DWORD group;
};

struct TGetConferenceGroupAreas_Response: public TWildcatRequest {
  WORD start;
  WORD runlength;
};

struct TSetConferenceFlags_Request: public TWildcatRequest {
  DWORD conference;
  DWORD flags;
};

struct TSetMultipleConferenceFlags_SetAll: public TWildcatRequest {
  DWORD flags;
};

struct TSetMultipleConferenceFlags_SetData: public TWildcatRequest {
  DWORD start;
  DWORD runlength;
  DWORD flags;
};

struct TSetLastRead_Request: public TWildcatRequest {
  DWORD conference;
  DWORD lastread;
};

struct TGetSecurityProfile_Response: public TWildcatRequest {
  TSecurityProfile Sec;
};

struct TGetDownloadStats_Response: public TWildcatRequest {
  DWORD Uploads;
  DWORD TotalUploadKbytes;
  DWORD Downloads;
  DWORD TotalDownloadKbytes;
  DWORD DownloadCountToday;
  DWORD DownloadKbytesToday;
};

struct TDeleteMessage_Request: public TWildcatRequest {
  DWORD conference;
  DWORD msgid;
};

struct TDeleteMessage_Response: public TWildcatRequest {
  DWORD conference;
  DWORD msgid;
  DWORD error;
};

const DWORD READMESSAGE_SNOOP = 0x0001;

struct TMarkMessageRead_Request: public TWildcatRequest {
  DWORD conference;
  DWORD msgid;
  DWORD flags;
};

///////////////////////////////////////////////////////////////////////////////////////////////////

const SIZE_MSG_BLOCK_TEXT = 1024;

const WORD guiMsgPrivate  = 1;
const WORD guiMsgReceived = 2;
const WORD guiMsgDeleted  = 4;
const WORD guiMsgAttach   = 8;

struct TGuiMsgHeader {
    DWORD Id;
    DWORD Number;
    TUserInfo From;
    TUserInfo To;
    char Subject[SIZE_MESSAGE_SUBJECT];
    FILETIME MsgTime;
    DWORD Reference;
    WORD MsgFlags;
    DWORD MsgSize;
    DWORD Conference;
    DWORD PrevUnread;
    DWORD NextUnread;
    char Attachment[SIZE_SHORT_FILE_NAME];
};

//struct TGetConfMsgHeaders_Request: public TWildcatRequest {
//  DWORD conference;
//  DWORD start;
//  DWORD count;
//};

struct TListMessages_MsgHeader_Response: public TWildcatRequest {
  TGuiMsgHeader mh;
};

struct TListMessages_GetMore: public TWildcatRequest {
  DWORD count;
};

//struct TGetConfMsgText_Request: public TWildcatRequest {
//  DWORD conference;
//  DWORD start;
//  DWORD count;
//  DWORD snoop;
//};

struct TListMessages_MsgText_Response: public TWildcatRequest {
  WORD len;
  char text[SIZE_MSG_BLOCK_TEXT];
};

const WORD LISTMESSAGES_TEXT       = 0x01;
const WORD LISTMESSAGES_SNOOP      = 0x02;
const WORD LISTMESSAGES_SUPERSNOOP = 0x04;

struct TListMessagesByAreaNumber_Request: public TWildcatRequest {
  DWORD conference;
  DWORD number;
  DWORD count;
  WORD flags;
};

struct TListMessagesByAreaMsgId_Request: public TWildcatRequest {
  DWORD conference;
  DWORD msgid;
  DWORD count;
  WORD flags;
};

struct TListMessagesByAreaDate_Request: public TWildcatRequest {
  DWORD conference;
  FILETIME postedtime;
  DWORD count;
  WORD flags;
};

struct TListMessagesBackwardsByNumber_Request: public TWildcatRequest {
  DWORD conference;
  DWORD number;
  DWORD count;
  WORD flags;
};

struct TListMessagesBackwardsByMsgId_Request: public TWildcatRequest {
  DWORD conference;
  DWORD msgid;
  DWORD count;
  WORD flags;
};

const MSGSEARCH_FORWARD  = 0x0001;
const MSGSEARCH_BACKWARD = 0x0002;

struct TListMessagesBySearch_Request: public TWildcatRequest {
  char SearchFrom[SIZE_USER_NAME];
  char SearchTo[SIZE_USER_NAME];
  char SearchSubject[SIZE_MESSAGE_SUBJECT];
  char SearchBody[80];
  DWORD SearchNumber;
  DWORD sFlags;
  WORD flags;
};

struct TListMessagesByUnread_Request: TWildcatRequest {
  WORD flags;
};

struct TSearchMessages_SetConfs: public TWildcatRequest {
  DWORD start;
  DWORD runlength;
};

///////////////////////////////////////////////////////////////////////////////////////////////////

const DWORD SIZE_MSG_TEXT_BLOCK = 1024;

struct TAddMessage_Request: public TWildcatRequest {
  TMsgHeader mh;
};

struct TAddMessage_Response: public TWildcatRequest {
  DWORD error;
  DWORD msgid;
};

struct TAddMessage_MessageText: public TWildcatRequest {
  WORD size;
  char text[SIZE_MSG_TEXT_BLOCK];
};

///////////////////////////////////////////////////////////////////////////////////////////////////

//struct TGetFileAreas_Request: public TWildcatRequest {
//  DWORD area;
//  DWORD count;
//};

struct TGetFileAreas_Response: public TWildcatRequest {
  TFileArea fa;
  DWORD Access;
};

//struct TGetFileGroups_Request: public TWildcatRequest {
//  DWORD group;
//  DWORD count;
//};

struct TGetFileGroups_Response: public TWildcatRequest {
  TFileGroup fg;
};

struct TGetFileGroupAreas_Request: public TWildcatRequest {
  DWORD group;
};

struct TGetFileGroupAreas_Response: public TWildcatRequest {
  WORD start;
  WORD runlength;
};

struct TListFiles_Request: public TWildcatRequest {
  DWORD count;
};

struct TListFilesByDate_Request: public TListFiles_Request {
  FILETIME startdate;
};

struct TListFilesBySearch_Request: public TListFiles_Request {
  char Target[80];
};

struct TSetArea_Request: public TWildcatRequest {
  WORD start;
  WORD runlength;
};

struct TListFiles_GetMore: public TWildcatRequest {
  DWORD count;
};

const WORD guiFreeFile           = 0x01;
const WORD guiCopyBeforeDownload = 0x02;
const WORD guiOffline            = 0x04;
const WORD guiFreeTime           = 0x08;

////////////////////////////////////////////////////////////////////
// 450 note
// this must maintain a 8.3 filename format to support
// wcnav16 bit
struct TListFiles_Response: public TWildcatRequest {
    DWORD Area;
    char Name[SIZE_SHORT_FILE_NAME];
    char Description[SIZE_FILE_DESCRIPTION];
    DWORD UploaderId;
    char UploaderName[SIZE_USER_NAME];
    char Password[SIZE_PASSWORD];
    DWORD Size;
    FILETIME FileTime;
    FILETIME LastAccessed;
    DWORD Flags;
    DWORD Downloads;
    DWORD Cost;
    WORD LongDesc;
};

// Future Extended Record for WCNAV/32 file listing request events

struct TListFilesEx_Response: public TWildcatRequest {
    DWORD Area;
    char Name[SIZE_LONG_FILE_NAME];           // new
    char Description[SIZE_FILE_DESCRIPTION];
    DWORD UploaderId;
    char UploaderName[SIZE_USER_NAME];
    char Password[SIZE_PASSWORD];
    DWORD Size;
    FILETIME FileTime;
    FILETIME PostTime;                        // new
    FILETIME LastAccessed;
    DWORD Flags;
    DWORD Downloads;
    DWORD Cost;
    WORD LongDesc;
};
////////////////////////////////////////////////////////////////////

////////////////////////////////////////////////////////////////////
// 450 note
// this must maintain a 8.3 filename format to support
// wcnav16 bit
struct TGetFileDescription_Request: public TWildcatRequest {
  WORD area;
  char name[SIZE_SHORT_FILE_NAME];
};

struct TGetFileDescription_Response: public TWildcatRequest {
  WORD len;
  char text[MAX_FILE_LONGDESC_LINES*SIZE_FILE_LONGDESC];
};

////////////////////////////////////////////////////////////////////
// 450 note
// this must maintain a 8.3 filename format to support
// wcnav16 bit
struct TResolveFileName_Request: public TWildcatRequest {
  char filename[SIZE_SHORT_FILE_NAME];
};

////////////////////////////////////////////////////////////////////
// 450 note
// this must maintain a 8.3 filename format to support
// wcnav16 bit
struct TDeleteFile_Request: public TWildcatRequest {
  char filename[SIZE_SHORT_FILE_NAME];
  DWORD area;
  DWORD disktoo;
};

struct TDeleteFile_Response: public TWildcatRequest {
  DWORD error;
};

////////////////////////////////////////////////////////////////////
// 450 note
// this must maintain a 8.3 filename format to support
// wcnav16 bit
struct TUpdateFileInfo_Request: public TWildcatRequest {
  DWORD area;
  char filename[SIZE_SHORT_FILE_NAME];
  char origpassword[SIZE_PASSWORD];
  char description[SIZE_FILE_DESCRIPTION];
  char password[SIZE_PASSWORD];
  DWORD updatelongdesc;
  WORD longdescbytes;
  char longdescription[MAX_FILE_LONGDESC_LINES*SIZE_FILE_LONGDESC];
};

struct TUpdateFileInfo_Response: public TWildcatRequest {
  DWORD result;
};

///////////////////////////////////////////////////////////////////////////////////////////////////

struct TFileRequest {
  TUserInfo User;
  FILETIME RequestTime;
  char FileName[SIZE_SHORT_FILE_NAME];
  DWORD FileArea;
  char Reserved[100];
};

////////////////////////////////////////////////////////////////////
// 450 note
// this must maintain a 8.3 filename format to support
// wcnav16 bit
struct TRequestOfflineFiles_Submit: public TWildcatRequest {
  char FileName[SIZE_SHORT_FILE_NAME];
  DWORD FileArea;
};

///////////////////////////////////////////////////////////////////////////////////////////////////

struct TGetCurrentUser_Response: public TWildcatRequest {
  TUser User;
};

struct TUpdateCurrentUser_Request: public TWildcatRequest {
  TUser User;
};

struct TGetUserInfo_Request: public TWildcatRequest {
  char UserName[SIZE_USER_NAME];
  DWORD UserId;
};

struct TUserInfo_Response: public TWildcatRequest {
  TUserInfo UserInfo;
  char From[SIZE_USER_FROM];
  FILETIME LastCall;
};

struct TGetNodeInfo_Request: public TWildcatRequest {
  char username[SIZE_USER_NAME];
};

struct TWhosOnline_Response: public TWildcatRequest {
  TwcNodeInfo NodeInfo;
};

struct TSearchUserNames_Request: public TWildcatRequest {
  char username[SIZE_USER_NAME];
};


///////////////////////////////////////////////////////////////////////////////////////////////////

struct TDownloadFile_Request: public TWildcatRequest {
  char filename[MAX_PATH];
  DWORD have;
  DWORD crc;
};

struct TDownloadFile_Response: public TWildcatRequest {
  DWORD error;
  DWORD resume;
  DWORD filesize;
};

struct TUploadFile_Request: public TWildcatRequest {
    Wildcat5::TFullFileRecord file;
};

struct TUploadFile_Response: public TWildcatRequest {
  DWORD error;
};

const UPLOADFILE_OVERWRITE = 0x01;

struct TUploadFileEx_Request: public TWildcatRequest {
  Wildcat5::TFullFileRecord file;
  WORD flags;
};

struct TUploadAttachment_Request: public TWildcatRequest {
  DWORD filesize;
};

struct TUploadAttachment_SetMessage_Request: public TWildcatRequest {
  WORD conference;
  DWORD msgid;
};

struct TUploadAttachment_Response: public TWildcatRequest {
  DWORD error;
};

struct TFileTransfer_Error: public TWildcatRequest {
  DWORD error;
};

struct TFileTransfer_Data: public TWildcatRequest {
  WORD size;
  char data[SIZE_FILE_DATA_BLOCK];
};

struct TViewArchive_Request: public TWildcatRequest {
  DWORD area;
  char filename[SIZE_SHORT_FILE_NAME];
};

struct TViewArchive_Response: public TWildcatRequest {
  DWORD error;
};

struct TViewArchive_Data: public TWildcatRequest {
  WORD size;
  char data[SIZE_FILE_DATA_BLOCK];
};

///////////////////////////////////////////////////////////////////////////////////////////////////

struct TCopyBeforeDownload_Submit_Request: public TWildcatRequest {
  DWORD id;
  DWORD area;
  char fn[SIZE_SHORT_FILE_NAME];
};

struct TCopyBeforeDownload_Submit_Response: public TWildcatRequest {
  DWORD id;
  DWORD result;
};

struct TCopyBeforeDownload_Status_Response: public TWildcatRequest {
  DWORD id;
  DWORD result;
  DWORD cookie;
};

struct TCopyBeforeDownload_Remove_Request: public TWildcatRequest {
  DWORD id;
};

///////////////////////////////////////////////////////////////////////////////////////////////////

//struct TGetPackageInfo_Request: public TWildcatRequest {
//  char PackageName[SIZE_PACKAGE_NAME];
//};
//
//struct TGetPackageInfo_Response: public TWildcatRequest {
//  char FileName[SIZE_FILE_NAME];
//  WORD DosDate;
//  WORD DosTime;
//  DWORD FileSize;
//};

struct TGetPackageVersion_Request: public TWildcatRequest {
  char PackageName[SIZE_PACKAGE_NAME];
  char PackageVersion[SIZE_PACKAGE_VERSION];
};

struct TGetPackageVersion_Response: public TWildcatRequest {
  DWORD error;
  char PackageName[SIZE_PACKAGE_NAME];
  char ShortPackageName[SIZE_SHORT_FILE_NAME];
  char PackageVersion[SIZE_PACKAGE_VERSION];
  char PackageInfoFilename[MAX_PATH];
  DWORD UpgradeVersion;
  DWORD PatchAvailable;
  char UpgradeFilename[MAX_PATH];
};

///////////////////////////////////////////////////////////////////////////////////////////////////

struct TGuiChannelMessage {
  DWORD DestId;
  WORD UserData;
  WORD DataSize;
  BYTE Data[MAX_CHANNEL_MESSAGE_SIZE];
};

struct TGetPredefinedChatChannels_Response: public TWildcatRequest {
  DWORD Id;
  DWORD Flags;
  DWORD Length;
  char ChannelName[MAX_PATH];
};

///////////////////////////////////////////////////////////////////////////////////////////////////

const DWORD NAVMSG_DOWNLOAD = 1;
const DWORD NAVMSG_RUNCLIENT = 2;
const DWORD NAVMSG_UPLOAD = 3;

struct TNavigatorDownload {
  DWORD Cookie;
  char FileName[16];
  DWORD FileSize;
};

struct TNavigatorRunClient {
  char CommandLine[MAX_PATH];
};

struct TNavigatorUpload {
  char FileName[16];
};

///////////////////////////////////////////////////////////////////////////////////////////////////

const WORD MAGIC_LISTEN_REQUEST = 0x8001;
const WORD MAGIC_ACCEPT_REQUEST = 0x8002;

struct TSocketListenRequest {
  WORD MagicListenRequest;
  WORD RequestedPort;
};

struct TSocketListenConnection {
  DWORD AcceptHandle;
};

struct TSocketAcceptRequest {
  WORD MagicAcceptRequest;
  DWORD AcceptHandle;
};

///////////////////////////////////////////////////////////////////////////////////////////////////

#pragma pack()

#endif
