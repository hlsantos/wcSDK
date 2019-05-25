//***********************************************************************
// (c) Copyright 1998-2012 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : wcWinbuild.h
// Subsystem : WCSDK
// Date      : 05/27/2012
// Version   : v7.0.454.4
// Author    : HLS/SSI
//
// Header to single source compiler between VC6.0, VS20XX
//
// Include this at the top of all source files or in the
// stdafx.h file or common.h type of file, if any.
//
// It must be done before any C/C++ standard library headers
// are included.
//
// Revision History:
// Build    Date      Author  Comments
// -----    --------  ------  -------------------------------------------
//***********************************************************************

#pragma once

#ifndef WINVER
#  define WINVER 0x500
#endif

#ifndef _CRT_SECURE_NO_WARNINGS
#  define _CRT_SECURE_NO_WARNINGS
#endif
