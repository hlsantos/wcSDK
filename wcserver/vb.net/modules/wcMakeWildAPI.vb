Option Strict On
Option Explicit On

Imports System.Runtime.InteropServices

Module wcMakeWildAPI

#Region "Credits ..."

    '------------------------------------------------------------------------
    'Visual Basic Wildcat! SDK API v6.1.451.9
    '(c) copyright 1998-2006 by Santronics Software Inc.. All Rights Reserved.
    '
    'Automatically generated from wctypemw.h by CPP2BAS
    '
    'Converted to .NET 2.0 Framework by Mark Bappe (10/18/2006)
    '------------------------------------------------------------------------

#End Region

#Region "Public WINServer MakeWild API Constants ..."

    Public Const MAX_PATH As Integer = 260

    Public Const srvFingerServer As Integer = &H1
    Public Const srvWcxMwLogin As Integer = &H2
    Public Const srvWcxIpCheck As Integer = &H4
    Public Const srvOnlyLocalRPC As Integer = &H8

#End Region

#Region "Public WINServer MakeWild API Structures ..."

    '//! Group: Configuration Structures

    '//!---------------------------------------------------------
    '//! TConferencePaths provides the various directory setups
    '//! per mail confeference
    '//!---------------------------------------------------------
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TConferencePaths
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> Public Display As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> Public Bulletin As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> Public Help As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> Public Menu As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> Public Questionnaire As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> Public MsgDatabase As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> Public Attach As String
    End Structure

    '//!---------------------------------------------------------
    '//! TWildcatServerPrivateConfig is the configuration "MakeWild"
    '//! structure. The public field is exposed to normal
    '//! SDK clients.
    '//!---------------------------------------------------------
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TWildcatServerPrivateConfig
        Public mwPublic As TMakewild
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> Public FileDatabasePath As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> Public UserDatabasePath As String
        Public DefaultConferencePaths As TConferencePaths
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_ENCODED_PASSWORD)> Public SystemPassword As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_ENCODED_PASSWORD)> Public MakewildPassword As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> Public LanguagePath As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> Public BatchFilePath As String
        Public dwServerOptions As Integer
    End Structure

    '//!---------------------------------------------------------
    '//! TWildcatServerPrivateConfDesc defines a mail conference
    '//! setup.
    '//!---------------------------------------------------------
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TWildcatServerPrivateConfDesc
        Public tcdPublic As TConfDesc
        Public Paths As TConferencePaths
    End Structure

    '//!---------------------------------------------------------
    '//! TWildcatServerPrivateConfDesc defines a mail conference
    '//! setup.
    '//!---------------------------------------------------------
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TWildcatServerPrivateFileArea
        Public tfaPublic As TFileArea
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> Public Path As String
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=40)> Public Reserved() As Byte
    End Structure

    '//!---------------------------------------------------------
    '//! TWildcatServerPrivateFileVolumec provides CD volume
    '//! setup information.
    '//!---------------------------------------------------------
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TWildcatServerPrivateFileVolume
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_SHORT_FILE_NAME)> Public Name As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=SIZE_SHORT_FILE_NAME)> Public VolumeLabel As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> Public UniqueFile As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> Public Path As String
        Public Offline As Integer
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=84)> Public Reserved() As Byte
    End Structure

#End Region

#Region "Public WINServer MakeWild API DLL Imports ..."

    '//!----------------------------------------------------------------
    '//! Group: Makewild Configuration
    '//! MwLogin
    '//! Login as the configuration client
    '//! password  - configuration password, used "" if none. if a
    '//!             password is required, you should prompt for the
    '//!             password.
    '//! returns TRUE if successful, otherwise see extended error
    '//!----------------------------------------------------------------
    <DllImport("wcsmw.dll", SetLastError:=True)> Public Function MwLogin(ByVal password As String) As Boolean
    End Function

    '//!----------------------------------------------------------------
    '//! Group: Makewild Configuration
    '//! MwGetMakewild
    '//! return the configuration structure TWildcatServerPrivateConfig
    '//! mw - TWildcatServerPrivateConfig
    '//! returns TRUE if successful, otherwise see extended error
    '//! see also MwUpdateMakeWild
    '//!----------------------------------------------------------------
    <DllImport("wcvb.dll", EntryPoint:="vbMwGetMakewild", SetLastError:=True)> Public Function MwGetMakewild(ByVal mw As TWildcatServerPrivateConfig) As Boolean
    End Function

    '//!----------------------------------------------------------------
    '//! Group: Makewild Configuration
    '//! MwUpdateMakewild
    '//! Save the configuration structure TWildcatServerPrivateConfig
    '//! mw - TWildcatServerPrivateConfig
    '//! returns TRUE if successful, otherwise see extended error
    '//! see also MwGetMakeWild
    '//!----------------------------------------------------------------
    <DllImport("wcvb.dll", EntryPoint:="vbMwUpdateMakewild", SetLastError:=True)> Public Function MwUpdateMakewild(ByVal mw As TWildcatServerPrivateConfig) As Boolean
    End Function

    '//!----------------------------------------------------------------
    '//! Group: Security Profile functions
    '//!
    '//! MwGetSecurityProfileCount    get number of security profiles
    '//! MwGetSecurityProfileNames    get a string list of security names
    '//! MwGetSecurityProfiles        get an array of TSecurityProfiles
    '//! MwAddSecurityProfile         add a security profile
    '//! MwUpdateSecurityProfile      update a security profile
    '//! MwRemoveSecurityProfile      remote a security profile
    '//!----------------------------------------------------------------
    <DllImport("wcsmw.dll", SetLastError:=True)> Public Function MwGetSecurityProfileCount() As Integer
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbMwGetSecurityProfileNames", SetLastError:=True)> Public Function MwGetSecurityProfileNames(ByVal index As Integer, ByVal count As Integer) As Object
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbMwGetSecurityProfiles", SetLastError:=True)> Public Function MwGetSecurityProfiles(ByVal index As Integer, ByVal count As Integer, ByVal profile As TSecurityProfile) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbMwAddSecurityProfile", SetLastError:=True)> Public Function MwAddSecurityProfile(ByVal profile As TSecurityProfile, ByVal index As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbMwUpdateSecurityProfile", SetLastError:=True)> Public Function MwUpdateSecurityProfile(ByVal index As Integer, ByVal profile As TSecurityProfile) As Boolean
    End Function
    <DllImport("wcsmw.dll", SetLastError:=True)> Public Function MwRemoveSecurityProfile(ByVal index As Integer) As Boolean
    End Function

    '//!----------------------------------------------------------------
    '//! Group: Security Access Profile functions
    '//! The "Group" functions apply to the access profiles, NOT the
    '//! security profiles.
    '//!
    '//! MwCreateGroup                create a new group
    '//! MwRemoveGroup                remove a group
    '//! MwCloneGroup                 clone a group and all its flags
    '//! MwGetGroupCount              get the number of groups
    '//! MwGetGroupNames              get the current group names (and
    '//!                              indexes implicitly by position in
    '//!                              array)
    '//! MwGetObjectFlags             get the object's flags in group
    '//! MwGetMultipleObjectFlags     get multiple object flags in group
    '//! MwSetObjectFlags             sets the object's flags in a group (will
    '//!                              add the object to the group file if
    '//!                              it needs to, or remove it if flags == 0)
    '//! MwSetMultipleObjectFlags     set multiple object flags in group
    '//! MwGetObjectFlagsInGroups     get the flags for an object in each
    '//!                              group, indexes are relative to the
    '//!                              group names returned by MwGetGroupNames()
    '//! MwSetObjectFlagsInGroups     set the flags for an object in each group
    '//!----------------------------------------------------------------
    <DllImport("wcsmw.dll", SetLastError:=True)> Public Function MwCreateGroup(ByVal groupname As String, ByVal index As Integer) As Boolean
    End Function
    <DllImport("wcsmw.dll", SetLastError:=True)> Public Function MwRemoveGroup(ByVal groupname As String) As Boolean
    End Function
    <DllImport("wcsmw.dll", SetLastError:=True)> Public Function MwCloneGroup(ByVal sourcegroupindex As Integer, ByVal newgroupname As String, ByVal newgroupindex As Integer) As Boolean
    End Function
    <DllImport("wcsmw.dll", SetLastError:=True)> Public Function MwGetGroupCount() As Integer
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbMwGetGroupNames", SetLastError:=True)> Public Function MwGetGroupNames() As Object
    End Function
    <DllImport("wcsmw.dll", SetLastError:=True)> Public Function MwGetObjectFlags(ByVal groupindex As Integer, ByVal objectid As Integer) As Integer
    End Function
    <DllImport("wcsmw.dll", SetLastError:=True)> Public Function MwGetMultipleObjectFlags(ByVal groupindex As Integer, ByVal objectid As Integer, ByVal count As Integer, ByVal flags As Integer) As Boolean
    End Function
    <DllImport("wcsmw.dll", SetLastError:=True)> Public Function MwSetObjectFlags(ByVal groupindex As Integer, ByVal objectid As Integer, ByVal flags As Integer) As Boolean
    End Function
    <DllImport("wcsmw.dll", SetLastError:=True)> Public Function MwSetMultipleObjectFlags(ByVal groupindex As Integer, ByVal objectid As Integer, ByVal flags As Integer, ByVal count As Integer) As Boolean
    End Function
    <DllImport("wcsmw.dll", SetLastError:=True)> Public Function MwGetObjectFlagsInGroups(ByVal objectid As Integer, ByVal flags As Integer) As Boolean
    End Function
    <DllImport("wcsmw.dll", SetLastError:=True)> Public Function MwSetObjectFlagsInGroups(ByVal objectid As Integer, ByVal flags As Integer) As Boolean
    End Function

    '//!----------------------------------------------------------------
    '//! Group: Computers/Load Balancing
    '//! The "Computer" functions apply to the "Computers" setup in
    '//! wcconfig.exe.  This help load balance the system by distributing
    '//! the wconline setup of the internet servers across various
    '//! machines. The default is a blank computer name - index 0.
    '//!----------------------------------------------------------------
    <DllImport("wcsmw.dll", SetLastError:=True)> Public Function MwGetComputerConfigCount() As Integer
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbMwGetComputerConfigNames", SetLastError:=True)> Public Function MwGetComputerConfigNames(ByVal index As Integer, ByVal count As Integer) As Object
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbMwGetComputerConfigs", SetLastError:=True)> Public Function MwGetComputerConfigs(ByVal index As Integer, ByVal count As Integer, ByVal cconfig As TComputerConfig) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbMwAddComputerConfig", SetLastError:=True)> Public Function MwAddComputerConfig(ByVal ccoonfig As TComputerConfig, ByVal index As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbMwUpdateComputerConfig", SetLastError:=True)> Public Function MwUpdateComputerConfig(ByVal index As Integer, ByVal cconfig As TComputerConfig) As Boolean
    End Function
    <DllImport("wcsmw.dll", SetLastError:=True)> Public Function MwRemoveComputerConfig(ByVal index As Integer) As Boolean
    End Function

    '//!----------------------------------------------------------------
    '//! Group: Mail Conference Setup
    '//! Mail conference setup functions
    '//!----------------------------------------------------------------
    <DllImport("wcvb.dll", EntryPoint:="vbMwGetShortConfDescs", SetLastError:=True)> Public Function MwGetShortConfDescs(ByVal conference As Integer, ByVal count As Integer, ByVal cd As TShortConfDesc) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbMwGetConfDescs", SetLastError:=True)> Public Function MwGetConfDescs(ByVal conference As Integer, ByVal count As Integer, ByVal cd As TWildcatServerPrivateConfDesc) As Boolean
    End Function
    <DllImport("wcsmw.dll", SetLastError:=True)> Public Function MwSetConferenceCount(ByVal count As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbMwUpdateConfDesc", SetLastError:=True)> Public Function MwUpdateConfDesc(ByVal conference As Integer, ByVal cd As TWildcatServerPrivateConfDesc) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbMwGetConferenceGroups", SetLastError:=True)> Public Function MwGetConferenceGroups(ByVal group As Integer, ByVal count As Integer, ByVal fg As TConferenceGroup) As Boolean
    End Function
    <DllImport("wcsmw.dll", SetLastError:=True)> Public Function MwSetConferenceGroupCount(ByVal count As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbMwUpdateConferenceGroup", SetLastError:=True)> Public Function MwUpdateConferenceGroup(ByVal group As Integer, ByVal cg As TConferenceGroup) As Boolean
    End Function
    <DllImport("wcsmw.dll", SetLastError:=True)> Public Function MwGetConferenceGroupBits(ByVal group As Integer, ByVal bytes As Integer, ByVal bits As Byte) As Boolean
    End Function
    <DllImport("wcsmw.dll", SetLastError:=True)> Public Function MwSetConferenceGroupBits(ByVal group As Integer, ByVal bytes As Integer, ByVal bits As Byte) As Boolean
    End Function

    '//!----------------------------------------------------------------
    '//! Group: File Area Setup
    '//! File Area setup functions
    '//!----------------------------------------------------------------
    <DllImport("wcvb.dll", EntryPoint:="vbMwGetShortFileAreas", SetLastError:=True)> Public Function MwGetShortFileAreas(ByVal area As Integer, ByVal count As Integer, ByVal fa As TShortFileArea) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbMwGetFileAreas", SetLastError:=True)> Public Function MwGetFileAreas(ByVal area As Integer, ByVal count As Integer, ByVal fa As TWildcatServerPrivateFileArea) As Boolean
    End Function
    <DllImport("wcsmw.dll", SetLastError:=True)> Public Function MwSetFileAreaCount(ByVal count As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbMwUpdateFileArea", SetLastError:=True)> Public Function MwUpdateFileArea(ByVal area As Integer, ByVal fa As TWildcatServerPrivateFileArea) As Boolean
    End Function

    '//!
    '//! Group: File Area Group Setup
    '//!
    <DllImport("wcvb.dll", EntryPoint:="vbMwGetFileGroups", SetLastError:=True)> Public Function MwGetFileGroups(ByVal group As Integer, ByVal count As Integer, ByVal fg As TFileGroup) As Boolean
    End Function
    <DllImport("wcsmw.dll", SetLastError:=True)> Public Function MwSetFileGroupCount(ByVal count As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbMwUpdateFileGroup", SetLastError:=True)> Public Function MwUpdateFileGroup(ByVal group As Integer, ByVal fg As TFileGroup) As Boolean
    End Function
    <DllImport("wcsmw.dll", SetLastError:=True)> Public Function MwGetFileGroupBits(ByVal group As Integer, ByVal bytes As Integer, ByVal bits As Byte) As Boolean
    End Function
    <DllImport("wcsmw.dll", SetLastError:=True)> Public Function MwSetFileGroupBits(ByVal group As Integer, ByVal bytes As Integer, ByVal bits As Byte) As Boolean
    End Function

    '//!
    '//! Group: CD Volume Setup
    '//!
    <DllImport("wcsmw.dll", SetLastError:=True)> Public Function MwGetFileVolumeCount() As Integer
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbMwGetFileVolumeNames", SetLastError:=True)> Public Function MwGetFileVolumeNames(ByVal index As Integer, ByVal count As Integer) As Object
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbMwGetFileVolumes", SetLastError:=True)> Public Function MwGetFileVolumes(ByVal index As Integer, ByVal count As Integer, ByVal fv As TWildcatServerPrivateFileVolume) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbMwAddFileVolume", SetLastError:=True)> Public Function MwAddFileVolume(ByVal fv As TWildcatServerPrivateFileVolume, ByVal index As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbMwUpdateFileVolume", SetLastError:=True)> Public Function MwUpdateFileVolume(ByVal index As Integer, ByVal fv As TWildcatServerPrivateFileVolume) As Boolean
    End Function
    <DllImport("wcsmw.dll", SetLastError:=True)> Public Function MwRemoveFileVolume(ByVal index As Integer) As Boolean
    End Function

    '//!----------------------------------------------------------------
    '//! Group: Door Setup
    '//! Door setup functions
    '//!----------------------------------------------------------------
    <DllImport("wcvb.dll", EntryPoint:="vbMwGetDoorNames", SetLastError:=True)> Public Function MwGetDoorNames(ByVal index As Integer, ByVal count As Integer) As Object
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbMwGetDoors", SetLastError:=True)> Public Function MwGetDoors(ByVal index As Integer, ByVal count As Integer, ByVal di As TDoorInfo) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbMwAddDoor", SetLastError:=True)> Public Function MwAddDoor(ByVal di As TDoorInfo, ByVal index As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbMwUpdateDoor", SetLastError:=True)> Public Function MwUpdateDoor(ByVal index As Integer, ByVal di As TDoorInfo) As Boolean
    End Function
    <DllImport("wcsmw.dll", SetLastError:=True)> Public Function MwRemoveDoor(ByVal index As Integer) As Boolean
    End Function

    '//!----------------------------------------------------------------
    '//! Group: Language Prompt Files Setup
    '//! Language Setup functions
    '//!----------------------------------------------------------------
    <DllImport("wcvb.dll", EntryPoint:="vbMwGetLanguages", SetLastError:=True)> Public Function MwGetLanguages(ByVal index As Integer, ByVal count As Integer, ByVal li As TLanguageInfo) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbMwAddLanguage", SetLastError:=True)> Public Function MwAddLanguage(ByVal li As TLanguageInfo, ByVal index As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbMwUpdateLanguage", SetLastError:=True)> Public Function MwUpdateLanguage(ByVal index As Integer, ByVal li As TLanguageInfo) As Boolean
    End Function
    <DllImport("wcsmw.dll", SetLastError:=True)> Public Function MwRemoveLanguage(ByVal index As Integer) As Boolean
    End Function

    '//!----------------------------------------------------------------
    '//! Group: Modem Profiles Setup
    '//! Modem Profiles setup functions
    '//!----------------------------------------------------------------
    <DllImport("wcsmw.dll", SetLastError:=True)> Public Function MwGetModemCount() As Integer
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbMwGetShortModemProfiles", SetLastError:=True)> Public Function MwGetShortModemProfiles(ByVal index As Integer, ByVal count As Integer, ByVal mp As TShortModemProfile) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbMwGetModemProfile", SetLastError:=True)> Public Function MwGetModemProfile(ByVal index As Integer, ByVal mp As TModemProfile) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbMwAddModemProfile", SetLastError:=True)> Public Function MwAddModemProfile(ByVal mp As TModemProfile, ByVal index As Integer) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbMwUpdateModemProfile", SetLastError:=True)> Public Function MwUpdateModemProfile(ByVal index As Integer, ByVal mp As TModemProfile) As Boolean
    End Function
    <DllImport("wcsmw.dll", SetLastError:=True)> Public Function MwRemoveModemProfile(ByVal index As Integer) As Boolean
    End Function

    '//!----------------------------------------------------------------
    '//! Group: Node Configuration functions.
    '//!----------------------------------------------------------------
    <DllImport("wcsmw.dll", SetLastError:=True)> Public Function MwGetNodeConfigCount() As Integer
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbMwGetNodeConfigs", SetLastError:=True)> Public Function MwGetNodeConfigs(ByVal node As Integer, ByVal count As Integer, ByVal nc As TNodeConfig) As Boolean
    End Function
    <DllImport("wcvb.dll", EntryPoint:="vbMwUpdateNodeConfig", SetLastError:=True)> Public Function MwUpdateNodeConfig(ByVal node As Integer, ByVal nc As TNodeConfig) As Boolean
    End Function

    '//!----------------------------------------------------------------
    '//! Group: Miscellaneous
    '//! Check for the existence of server path with
    '//! optional create option
    '//!----------------------------------------------------------------
    <DllImport("wcsmw.dll", SetLastError:=True)> Public Function MwCheckPath(ByVal path As String, ByVal create As Integer) As Boolean
    End Function

#End Region

End Module
