Attribute VB_Name = "wcsmw" 

'------------------------------------------------------------------------
'Visual Basic Wildcat! SDK API v6.1.451.9
'(c) copyright 1998-2006 by Santronics Software Inc.. All Rights Reserved.
'
'Automatically generated from wcsmw.h by CPP2BAS
'------------------------------------------------------------------------

'//!----------------------------------------------------------------
'//! Group: Makewild Configuration
'//! MwLogin
'//! Login as the configuration client
'//! password  - configuration password, used "" if none. if a
'//!             password is required, you should prompt for the
'//!             password.
'//! returns TRUE if successful, otherwise see extended error
'//!----------------------------------------------------------------

Declare Function MwLogin Lib "wcsmw.dll" (ByVal password As String) As Boolean

'//!----------------------------------------------------------------
'//! Group: Makewild Configuration
'//! MwGetMakewild
'//! return the configuration structure TWildcatServerPrivateConfig
'//! mw - TWildcatServerPrivateConfig
'//! returns TRUE if successful, otherwise see extended error
'//! see also MwUpdateMakeWild
'//!----------------------------------------------------------------

Declare Function MwGetMakewild Lib "wcvb.dll" Alias "vbMwGetMakewild" (mw As TWildcatServerPrivateConfig) As Boolean

'//!----------------------------------------------------------------
'//! Group: Makewild Configuration
'//! MwUpdateMakewild
'//! Save the configuration structure TWildcatServerPrivateConfig
'//! mw - TWildcatServerPrivateConfig
'//! returns TRUE if successful, otherwise see extended error
'//! see also MwGetMakeWild
'//!----------------------------------------------------------------

Declare Function MwUpdateMakewild Lib "wcvb.dll" Alias "vbMwUpdateMakewild" (mw As TWildcatServerPrivateConfig) As Boolean

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

Declare Function MwGetSecurityProfileCount Lib "wcsmw.dll" () As Long
Declare Function MwGetSecurityProfileNames Lib "wcvb.dll" Alias "vbMwGetSecurityProfileNames" (ByVal index as Long, ByVal count as Long) As Variant
Declare Function MwGetSecurityProfiles Lib "wcvb.dll" Alias "vbMwGetSecurityProfiles" (ByVal index As Long, ByVal count As Long, profile As TSecurityProfile) As Boolean
Declare Function MwAddSecurityProfile Lib "wcvb.dll" Alias "vbMwAddSecurityProfile" (profile As TSecurityProfile, index As Long) As Boolean
Declare Function MwUpdateSecurityProfile Lib "wcvb.dll" Alias "vbMwUpdateSecurityProfile" (ByVal index As Long, profile As TSecurityProfile) As Boolean
Declare Function MwRemoveSecurityProfile Lib "wcsmw.dll" (ByVal index As Long) As Boolean

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

Declare Function MwCreateGroup Lib "wcsmw.dll" (ByVal groupname As String, index As Long) As Boolean
Declare Function MwRemoveGroup Lib "wcsmw.dll" (ByVal groupname As String) As Boolean
Declare Function MwCloneGroup Lib "wcsmw.dll" (ByVal sourcegroupindex As Long, ByVal newgroupname As String, newgroupindex As Long) As Boolean
Declare Function MwGetGroupCount Lib "wcsmw.dll" () As Long
Declare Function MwGetGroupNames Lib "wcvb.dll" Alias "vbMwGetGroupNames" () As Variant
Declare Function MwGetObjectFlags Lib "wcsmw.dll" (ByVal groupindex As Long, ByVal objectid As Long) As Long
Declare Function MwGetMultipleObjectFlags Lib "wcsmw.dll" (ByVal groupindex As Long, objectid As Long, ByVal count As Long, flags As Long) As Boolean
Declare Function MwSetObjectFlags Lib "wcsmw.dll" (ByVal groupindex As Long, ByVal objectid As Long, ByVal flags As Long) As Boolean
Declare Function MwSetMultipleObjectFlags Lib "wcsmw.dll" (ByVal groupindex As Long, objectid As Long, flags As Long, ByVal count As Long) As Boolean
Declare Function MwGetObjectFlagsInGroups Lib "wcsmw.dll" (ByVal objectid As Long, flags As Long) As Boolean
Declare Function MwSetObjectFlagsInGroups Lib "wcsmw.dll" (ByVal objectid As Long, flags As Long) As Boolean

'//!----------------------------------------------------------------
'//! Group: Computers/Load Balancing
'//! The "Computer" functions apply to the "Computers" setup in
'//! wcconfig.exe.  This help load balance the system by distributing
'//! the wconline setup of the internet servers across various
'//! machines. The default is a blank computer name - index 0.
'//!----------------------------------------------------------------

Declare Function MwGetComputerConfigCount Lib "wcsmw.dll" () As Long
Declare Function MwGetComputerConfigNames Lib "wcvb.dll" Alias "vbMwGetComputerConfigNames" (ByVal index as Long, ByVal count as Long) As Variant
Declare Function MwGetComputerConfigs Lib "wcvb.dll" Alias "vbMwGetComputerConfigs" (ByVal index As Long, ByVal count As Long, cconfig As TComputerConfig) As Boolean
Declare Function MwAddComputerConfig Lib "wcvb.dll" Alias "vbMwAddComputerConfig" (ccoonfig As TComputerConfig, index As Long) As Boolean
Declare Function MwUpdateComputerConfig Lib "wcvb.dll" Alias "vbMwUpdateComputerConfig" (ByVal index As Long, cconfig As TComputerConfig) As Boolean
Declare Function MwRemoveComputerConfig Lib "wcsmw.dll" (ByVal index As Long) As Boolean

'//!----------------------------------------------------------------
'//! Group: Mail Conference Setup
'//! Mail conference setup functions
'//!----------------------------------------------------------------

Declare Function MwGetShortConfDescs Lib "wcvb.dll" Alias "vbMwGetShortConfDescs" (ByVal conference As Long, ByVal count As Long, cd As TShortConfDesc) As Boolean
Declare Function MwGetConfDescs Lib "wcvb.dll" Alias "vbMwGetConfDescs" (ByVal conference As Long, ByVal count As Long, cd As TWildcatServerPrivateConfDesc) As Boolean
Declare Function MwSetConferenceCount Lib "wcsmw.dll" (ByVal count As Long) As Boolean
Declare Function MwUpdateConfDesc Lib "wcvb.dll" Alias "vbMwUpdateConfDesc" (ByVal conference As Long, cd As TWildcatServerPrivateConfDesc) As Boolean

Declare Function MwGetConferenceGroups Lib "wcvb.dll" Alias "vbMwGetConferenceGroups" (ByVal group As Long, ByVal count As Long, fg As TConferenceGroup) As Boolean
Declare Function MwSetConferenceGroupCount Lib "wcsmw.dll" (ByVal count As Long) As Boolean
Declare Function MwUpdateConferenceGroup Lib "wcvb.dll" Alias "vbMwUpdateConferenceGroup" (ByVal group As Long, cg As TConferenceGroup) As Boolean
Declare Function MwGetConferenceGroupBits Lib "wcsmw.dll" (ByVal group As Long, ByVal bytes As Long, bits As Byte) As Boolean
Declare Function MwSetConferenceGroupBits Lib "wcsmw.dll" (ByVal group As Long, ByVal bytes As Long, bits As Byte) As Boolean

'//!----------------------------------------------------------------
'//! Group: File Area Setup
'//! File Area setup functions
'//!----------------------------------------------------------------

Declare Function MwGetShortFileAreas Lib "wcvb.dll" Alias "vbMwGetShortFileAreas" (ByVal area As Long, ByVal count As Long, fa As TShortFileArea) As Boolean
Declare Function MwGetFileAreas Lib "wcvb.dll" Alias "vbMwGetFileAreas" (ByVal area As Long, ByVal count As Long, fa As TWildcatServerPrivateFileArea) As Boolean
Declare Function MwSetFileAreaCount Lib "wcsmw.dll" (ByVal count As Long) As Boolean
Declare Function MwUpdateFileArea Lib "wcvb.dll" Alias "vbMwUpdateFileArea" (ByVal area As Long, fa As TWildcatServerPrivateFileArea) As Boolean

'//! Group: File Area Group Setup

Declare Function MwGetFileGroups Lib "wcvb.dll" Alias "vbMwGetFileGroups" (ByVal group As Long, ByVal count As Long, fg As TFileGroup) As Boolean
Declare Function MwSetFileGroupCount Lib "wcsmw.dll" (ByVal count As Long) As Boolean
Declare Function MwUpdateFileGroup Lib "wcvb.dll" Alias "vbMwUpdateFileGroup" (ByVal group As Long, fg As TFileGroup) As Boolean
Declare Function MwGetFileGroupBits Lib "wcsmw.dll" (ByVal group As Long, ByVal bytes As Long, bits As Byte) As Boolean
Declare Function MwSetFileGroupBits Lib "wcsmw.dll" (ByVal group As Long, ByVal bytes As Long, bits As Byte) As Boolean

'//! Group: CD Volume Setup

Declare Function MwGetFileVolumeCount Lib "wcsmw.dll" () As Long
Declare Function MwGetFileVolumeNames Lib "wcvb.dll" Alias "vbMwGetFileVolumeNames" (ByVal index as Long, ByVal count as Long) As Variant
Declare Function MwGetFileVolumes Lib "wcvb.dll" Alias "vbMwGetFileVolumes" (ByVal index As Long, ByVal count As Long, fv As TWildcatServerPrivateFileVolume) As Boolean
Declare Function MwAddFileVolume Lib "wcvb.dll" Alias "vbMwAddFileVolume" (fv As TWildcatServerPrivateFileVolume, index As Long) As Boolean
Declare Function MwUpdateFileVolume Lib "wcvb.dll" Alias "vbMwUpdateFileVolume" (ByVal index As Long, fv As TWildcatServerPrivateFileVolume) As Boolean
Declare Function MwRemoveFileVolume Lib "wcsmw.dll" (ByVal index As Long) As Boolean

'//!----------------------------------------------------------------
'//! Group: Door Setup
'//! Door setup functions
'//!----------------------------------------------------------------

Declare Function MwGetDoorNames Lib "wcvb.dll" Alias "vbMwGetDoorNames" (ByVal index as Long, ByVal count as Long) As Variant
Declare Function MwGetDoors Lib "wcvb.dll" Alias "vbMwGetDoors" (ByVal index As Long, ByVal count As Long, di As TDoorInfo) As Boolean
Declare Function MwAddDoor Lib "wcvb.dll" Alias "vbMwAddDoor" (di As TDoorInfo, index As Long) As Boolean
Declare Function MwUpdateDoor Lib "wcvb.dll" Alias "vbMwUpdateDoor" (ByVal index As Long, di As TDoorInfo) As Boolean
Declare Function MwRemoveDoor Lib "wcsmw.dll" (ByVal index As Long) As Boolean

'//!----------------------------------------------------------------
'//! Group: Language Prompt Files Setup
'//! Language Setup functions
'//!----------------------------------------------------------------

Declare Function MwGetLanguages Lib "wcvb.dll" Alias "vbMwGetLanguages" (ByVal index As Long, ByVal count As Long, li As TLanguageInfo) As Boolean
Declare Function MwAddLanguage Lib "wcvb.dll" Alias "vbMwAddLanguage" (li As TLanguageInfo, index As Long) As Boolean
Declare Function MwUpdateLanguage Lib "wcvb.dll" Alias "vbMwUpdateLanguage" (ByVal index As Long, li As TLanguageInfo) As Boolean
Declare Function MwRemoveLanguage Lib "wcsmw.dll" (ByVal index As Long) As Boolean

'//!----------------------------------------------------------------
'//! Group: Modem Profiles Setup
'//! Modem Profiles setup functions
'//!----------------------------------------------------------------

Declare Function MwGetModemCount Lib "wcsmw.dll" () As Long
Declare Function MwGetShortModemProfiles Lib "wcvb.dll" Alias "vbMwGetShortModemProfiles" (ByVal index As Long, ByVal count As Long, mp As TShortModemProfile) As Boolean
Declare Function MwGetModemProfile Lib "wcvb.dll" Alias "vbMwGetModemProfile" (ByVal index As Long, mp As TModemProfile) As Boolean
Declare Function MwAddModemProfile Lib "wcvb.dll" Alias "vbMwAddModemProfile" (mp As TModemProfile, index As Long) As Boolean
Declare Function MwUpdateModemProfile Lib "wcvb.dll" Alias "vbMwUpdateModemProfile" (ByVal index As Long, mp As TModemProfile) As Boolean
Declare Function MwRemoveModemProfile Lib "wcsmw.dll" (ByVal index As Long) As Boolean

'//!----------------------------------------------------------------
'//! Group: Node Configuration functions.
'//!----------------------------------------------------------------

Declare Function MwGetNodeConfigCount Lib "wcsmw.dll" () As Long
Declare Function MwGetNodeConfigs Lib "wcvb.dll" Alias "vbMwGetNodeConfigs" (ByVal node As Long, ByVal count As Long, nc As TNodeConfig) As Boolean
Declare Function MwUpdateNodeConfig Lib "wcvb.dll" Alias "vbMwUpdateNodeConfig" (ByVal node As Long, nc As TNodeConfig) As Boolean

'//!----------------------------------------------------------------
'//! Group: Miscellaneous
'//! Check for the existence of server path with
'//! optional create option
'//!----------------------------------------------------------------

Declare Function MwCheckPath Lib "wcsmw.dll" (ByVal path As String, ByVal create As Long) As Boolean

