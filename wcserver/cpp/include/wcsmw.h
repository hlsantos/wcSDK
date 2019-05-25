//***********************************************************************
// (c) Copyright 1998-2002 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : wcsmw.h
// Subsystem : header for to access configuration function
// Date      :
// Author    :
//
// Revision History:
// Build  Date      Author  Comments
// -----  --------  ------  ---------------------------------------------
//***********************************************************************

#ifndef __WCSMW_H
#define __WCSMW_H

#include "wctypemw.h"

#ifdef __cplusplus
extern "C" {
#endif

//!----------------------------------------------------------------
//+ Group: Makewild Configuration
//@ MwLogin
//# Login as the configuration client
//$ password  - configuration password, used "" if none. if a
//$             password is required, you should prompt for the
//$             password.
//% returns TRUE if successful, otherwise see extended error
//!----------------------------------------------------------------

BOOL  APIENTRY MwLogin(const char *password);

//!----------------------------------------------------------------
//+ Group: Makewild Configuration
//@ MwGetMakewild
//# return the configuration structure TWildcatServerPrivateConfig
//$ mw - TWildcatServerPrivateConfig
//% returns TRUE if successful, otherwise see extended error
//& see also MwUpdateMakeWild
//!----------------------------------------------------------------

BOOL  APIENTRY MwGetMakewild(TWildcatServerPrivateConfig &mw);

//!----------------------------------------------------------------
//+ Group: Makewild Configuration
//@ MwUpdateMakewild
//# Save the configuration structure TWildcatServerPrivateConfig
//$ mw - TWildcatServerPrivateConfig
//% returns TRUE if successful, otherwise see extended error
//& see also MwGetMakeWild
//!----------------------------------------------------------------

BOOL  APIENTRY MwUpdateMakewild(TWildcatServerPrivateConfig &mw);

//!----------------------------------------------------------------
//+ Group: Security Profile functions
//!
//! MwGetSecurityProfileCount    get number of security profiles
//! MwGetSecurityProfileNames    get a string list of security names
//! MwGetSecurityProfiles        get an array of TSecurityProfiles
//! MwAddSecurityProfile         add a security profile
//! MwUpdateSecurityProfile      update a security profile
//! MwRemoveSecurityProfile      remote a security profile
//!----------------------------------------------------------------

DWORD APIENTRY MwGetSecurityProfileCount();
BOOL  APIENTRY MwGetSecurityProfileNames(DWORD index, DWORD count, char profilenames[][SIZE_SECURITY_NAME]);
BOOL  APIENTRY MwGetSecurityProfiles(DWORD index, DWORD count, TSecurityProfile *profile);
BOOL  APIENTRY MwAddSecurityProfile(const TSecurityProfile &profile, DWORD &index);
BOOL  APIENTRY MwUpdateSecurityProfile(DWORD index, const TSecurityProfile &profile);
BOOL  APIENTRY MwRemoveSecurityProfile(DWORD index);

//!----------------------------------------------------------------
//+ Group: Security Access Profile functions
//! The "Group" functions apply to the access profiles, NOT the
//! security profiles.
//!
//! MwCreateGroup                create a new group
//! MwRemoveGroup                remove a group
//! MwCloneGroup                 clone a group and all its flags
//! MwGetGroupCount              get the number of groups
//! MwGetGroupNames              get the current group names (and
//!                              indexes implicitly by position in
//!                              array)
//! MwGetObjectFlags             get the object's flags in group
//! MwGetMultipleObjectFlags     get multiple object flags in group
//! MwSetObjectFlags             sets the object's flags in a group (will
//!                              add the object to the group file if
//!                              it needs to, or remove it if flags == 0)
//! MwSetMultipleObjectFlags     set multiple object flags in group
//! MwGetObjectFlagsInGroups     get the flags for an object in each
//!                              group, indexes are relative to the
//!                              group names returned by MwGetGroupNames()
//! MwSetObjectFlagsInGroups     set the flags for an object in each group
//!----------------------------------------------------------------

BOOL  APIENTRY MwCreateGroup(const char *groupname, DWORD &index);
BOOL  APIENTRY MwRemoveGroup(const char *groupname);
BOOL  APIENTRY MwCloneGroup(DWORD sourcegroupindex, const char *newgroupname, DWORD &newgroupindex);
DWORD APIENTRY MwGetGroupCount();
BOOL  APIENTRY MwGetGroupNames(char groupnames[][SIZE_SECURITY_NAME]);
DWORD APIENTRY MwGetObjectFlags(DWORD groupindex, DWORD objectid);
BOOL  APIENTRY MwGetMultipleObjectFlags(DWORD groupindex, const DWORD *objectid, DWORD count, DWORD *flags);
BOOL  APIENTRY MwSetObjectFlags(DWORD groupindex, DWORD objectid, DWORD flags);
BOOL  APIENTRY MwSetMultipleObjectFlags(DWORD groupindex, const DWORD *objectid, const DWORD *flags, DWORD count);
BOOL  APIENTRY MwGetObjectFlagsInGroups(DWORD objectid, DWORD *flags);
BOOL  APIENTRY MwSetObjectFlagsInGroups(DWORD objectid, const DWORD *flags);

//!----------------------------------------------------------------
//+ Group: Computers/Load Balancing
//! The "Computer" functions apply to the "Computers" setup in
//! wcconfig.exe.  This help load balance the system by distributing
//! the wconline setup of the internet servers across various
//! machines. The default is a blank computer name - index 0.
//!----------------------------------------------------------------

DWORD APIENTRY MwGetComputerConfigCount();
BOOL  APIENTRY MwGetComputerConfigNames(DWORD index, DWORD count, char computernames[][SIZE_COMPUTER_NAME]);
BOOL  APIENTRY MwGetComputerConfigs(DWORD index, DWORD count, TComputerConfig *cconfig);
BOOL  APIENTRY MwAddComputerConfig(const TComputerConfig &ccoonfig, DWORD &index);
BOOL  APIENTRY MwUpdateComputerConfig(DWORD index, TComputerConfig &cconfig);
BOOL  APIENTRY MwRemoveComputerConfig(DWORD index);

//!----------------------------------------------------------------
//+ Group: Mail Conference Setup
//! Mail conference setup functions
//!----------------------------------------------------------------

BOOL  APIENTRY MwGetShortConfDescs(DWORD conference, DWORD count, TShortConfDesc *cd);
BOOL  APIENTRY MwGetConfDescs(DWORD conference, DWORD count, TWildcatServerPrivateConfDesc *cd);
BOOL  APIENTRY MwSetConferenceCount(DWORD count);
BOOL  APIENTRY MwUpdateConfDesc(DWORD conference, TWildcatServerPrivateConfDesc &cd);

BOOL  APIENTRY MwGetConferenceGroups(DWORD group, DWORD count, TConferenceGroup *fg);
BOOL  APIENTRY MwSetConferenceGroupCount(DWORD count);
BOOL  APIENTRY MwUpdateConferenceGroup(DWORD group, TConferenceGroup &cg);
BOOL  APIENTRY MwGetConferenceGroupBits(DWORD group, DWORD bytes, BYTE *bits);
BOOL  APIENTRY MwSetConferenceGroupBits(DWORD group, DWORD bytes, const BYTE *bits);

//!----------------------------------------------------------------
//+ Group: File Area Setup
//! File Area setup functions
//!----------------------------------------------------------------

BOOL  APIENTRY MwGetShortFileAreas(DWORD area, DWORD count, TShortFileArea *fa);
BOOL  APIENTRY MwGetFileAreas(DWORD area, DWORD count, TWildcatServerPrivateFileArea *fa);
BOOL  APIENTRY MwSetFileAreaCount(DWORD count);
BOOL  APIENTRY MwUpdateFileArea(DWORD area, TWildcatServerPrivateFileArea &fa);

//+ Group: File Area Group Setup

BOOL  APIENTRY MwGetFileGroups(DWORD group, DWORD count, TFileGroup *fg);
BOOL  APIENTRY MwSetFileGroupCount(DWORD count);
BOOL  APIENTRY MwUpdateFileGroup(DWORD group, TFileGroup &fg);
BOOL  APIENTRY MwGetFileGroupBits(DWORD group, DWORD bytes, BYTE *bits);
BOOL  APIENTRY MwSetFileGroupBits(DWORD group, DWORD bytes, const BYTE *bits);

//+ Group: CD Volume Setup

DWORD APIENTRY MwGetFileVolumeCount();
BOOL  APIENTRY MwGetFileVolumeNames(DWORD index, DWORD count, char volumenames[][SIZE_SHORT_FILE_NAME]);
BOOL  APIENTRY MwGetFileVolumes(DWORD index, DWORD count, TWildcatServerPrivateFileVolume *fv);
BOOL  APIENTRY MwAddFileVolume(TWildcatServerPrivateFileVolume &fv, DWORD &index);
BOOL  APIENTRY MwUpdateFileVolume(DWORD index, TWildcatServerPrivateFileVolume &fv);
BOOL  APIENTRY MwRemoveFileVolume(DWORD index);

//!----------------------------------------------------------------
//+ Group: Door Setup
//! Door setup functions
//!----------------------------------------------------------------

BOOL  APIENTRY MwGetDoorNames(DWORD index, DWORD count, char doornames[][SIZE_DOOR_NAME]);
BOOL  APIENTRY MwGetDoors(DWORD index, DWORD count, TDoorInfo *di);
BOOL  APIENTRY MwAddDoor(TDoorInfo &di, DWORD &index);
BOOL  APIENTRY MwUpdateDoor(DWORD index, const TDoorInfo &di);
BOOL  APIENTRY MwRemoveDoor(DWORD index);

//!----------------------------------------------------------------
//+ Group: Language Prompt Files Setup
//! Language Setup functions
//!----------------------------------------------------------------

BOOL  APIENTRY MwGetLanguages(DWORD index, DWORD count, TLanguageInfo *li);
BOOL  APIENTRY MwAddLanguage(const TLanguageInfo &li, DWORD &index);
BOOL  APIENTRY MwUpdateLanguage(DWORD index, const TLanguageInfo &li);
BOOL  APIENTRY MwRemoveLanguage(DWORD index);

//!----------------------------------------------------------------
//+ Group: Modem Profiles Setup
//! Modem Profiles setup functions
//!----------------------------------------------------------------

DWORD APIENTRY MwGetModemCount();
BOOL  APIENTRY MwGetShortModemProfiles(DWORD index, DWORD count, TShortModemProfile *mp);
BOOL  APIENTRY MwGetModemProfile(DWORD index, TModemProfile &mp);
BOOL  APIENTRY MwAddModemProfile(const TModemProfile &mp, DWORD &index);
BOOL  APIENTRY MwUpdateModemProfile(DWORD index, const TModemProfile &mp);
BOOL  APIENTRY MwRemoveModemProfile(DWORD index);

//!----------------------------------------------------------------
//+ Group: Node Configuration functions.
//!----------------------------------------------------------------

DWORD APIENTRY MwGetNodeConfigCount();
BOOL  APIENTRY MwGetNodeConfigs(DWORD node, DWORD count, TNodeConfig *nc);
BOOL  APIENTRY MwUpdateNodeConfig(DWORD node, const TNodeConfig &nc);

//!----------------------------------------------------------------
//+ Group: Miscellaneous
//! Check for the existence of server path with
//! optional create option
//!----------------------------------------------------------------

BOOL  APIENTRY MwCheckPath(const char *path, BOOL create);

//!----------------------------------------------------------------
//+ Group: Domain Configuration Functions
//!----------------------------------------------------------------

BOOL APIENTRY MwSetDomainConfigVar(const char *szDomain, const char *szSection, const char *szKey, const char *szValue);
BOOL APIENTRY MwSetConfigFileVar(const char *szFilename, const char *szSection, const char *szKey, const char *szValue);
BOOL APIENTRY MwReloadDomainConfig();

//!----------------------------------------------------------------
//+ Group: Server File Directory
//!----------------------------------------------------------------

WCHANDLE APIENTRY MwFindFirstFile(LPCTSTR fn, WIN32_FIND_DATA *fd);
BOOL APIENTRY MwFindNextFile(WCHANDLE ff, WIN32_FIND_DATA *fd);
BOOL APIENTRY MwFindClose(WCHANDLE ff);


#ifdef __cplusplus
} // extern "C"
#endif

#endif
