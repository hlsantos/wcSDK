//***********************************************************************
// (c) Copyright 1998-2008 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : globals.h
// Subsystem :
// Date      :
// Version   :
// Author    :
//
// Revision History:
// Build    Date      Author  Comments
// -----    --------  ------  -------------------------------------------
//***********************************************************************

#ifndef __globals_h
#define __globals_h

#include "textfile.h"

extern DWORD ActiveConnections;
extern TTextFile DataFile;
extern CRITICAL_SECTION DataFileMutex;

#endif
