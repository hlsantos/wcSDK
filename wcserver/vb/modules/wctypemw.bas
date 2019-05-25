Attribute VB_Name = "wcTypeMw" 

'------------------------------------------------------------------------
'Visual Basic Wildcat! SDK API v6.1.451.9
'(c) copyright 1998-2006 by Santronics Software Inc.. All Rights Reserved.
'
'Automatically generated from wctypemw.h by CPP2BAS
'------------------------------------------------------------------------


public const MAX_PATH as Long = 260

'//! Group: Configuration Structures

'//!---------------------------------------------------------
'//! TConferencePaths provides the various directory setups
'//! per mail confeference
'//!---------------------------------------------------------


type TConferencePaths
  Display as String*MAX_PATH
  Bulletin as String*MAX_PATH
  Help as String*MAX_PATH
  Menu as String*MAX_PATH
  Questionnaire as String*MAX_PATH
  MsgDatabase as String*MAX_PATH
  Attach as String*MAX_PATH
end type

'//!---------------------------------------------------------
'//! TWildcatServerPrivateConfig is the configuration "MakeWild"
'//! structure. The public field is exposed to normal
'//! SDK clients.
'//!---------------------------------------------------------


type TWildcatServerPrivateConfig
  Public as TMakewild
  FileDatabasePath as String*MAX_PATH
  UserDatabasePath as String*MAX_PATH
  DefaultConferencePaths as TConferencePaths
  SystemPassword as String*SIZE_ENCODED_PASSWORD
  MakewildPassword as String*SIZE_ENCODED_PASSWORD
  LanguagePath as String*MAX_PATH
  BatchFilePath as String*MAX_PATH
  dwServerOptions as Long
end type


public const srvFingerServer as Long  = &H00000001
public const srvWcxMwLogin as Long    = &H00000002
public const srvWcxIpCheck as Long    = &H00000004
public const srvOnlyLocalRPC as Long  = &H00000008

'//!---------------------------------------------------------
'//! TWildcatServerPrivateConfDesc defines a mail conference
'//! setup.
'//!---------------------------------------------------------


type TWildcatServerPrivateConfDesc
  Public as TConfDesc
  Paths as TConferencePaths
end type

'//!---------------------------------------------------------
'//! TWildcatServerPrivateConfDesc defines a mail conference
'//! setup.
'//!---------------------------------------------------------


type TWildcatServerPrivateFileArea
  Public as TFileArea
  Path as String*MAX_PATH
  Reserved(1 to 40) as Byte
end type

'//!---------------------------------------------------------
'//! TWildcatServerPrivateFileVolumec provides CD volume
'//! setup information.
'//!---------------------------------------------------------


type TWildcatServerPrivateFileVolume
  Name as String*SIZE_SHORT_FILE_NAME
  VolumeLabel as String*SIZE_SHORT_FILE_NAME
  UniqueFile as String*MAX_PATH
  Path as String*MAX_PATH
  Offline as Long
  Reserved(1 to 84) as Byte
end type

