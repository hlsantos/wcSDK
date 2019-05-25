//***********************************************************************
// (c) Copyright 1998-2019 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : WildcatModuleProtocol.h
// Subsystem : wcOnline Host Module
//
// WCONLINE MODULE INTERFACE PROC
// - Exported functions
//
// Revision History:
// Build    Date      Author  Comments
// -----    --------  ------  -------------------------------------------
//***********************************************************************

#define DLL_EXPORT  _declspec(dllexport)

#include "wcbuild.h"

// This loads with GetProcAddress(h,"_WcOnlineGetModule@0")
extern "C" DLL_EXPORT WconlineModule *WINAPI WcOnlineGetModule()
{
  return &Module;
}

// This loads with GetProcAddress(h,"_CheckWildcatBuild@0")
extern "C" int DLL_EXPORT __stdcall CheckWildcatBuild()
{
  return WILDCAT_FRAMEWORK_BUILD;
}

// 450
// This loads with GetProcAddress(h,"CheckWildcatBuild")
extern "C" DLL_EXPORT int CheckWildcatBuildEx()
{
  return WILDCAT_FRAMEWORK_BUILD;
}

#ifdef MODSERVICE
extern "C" DLL_EXPORT char *GetModuleServiceName()
{
  return MODSERVICE;
}
#endif

