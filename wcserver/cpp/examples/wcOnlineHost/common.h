#pragma once

#if _MSC_VER > 1200
#define _CRT_SECURE_NO_WARNINGS
#define _CRT_SECURE_NO_DEPRECATE
#endif

#include <afxwin.h>
#include <afxtempl.h>
#include <afxcmn.h>
#include <afxext.h>

#include <process.h>
#include <stdio.h>
#include <stdlib.h>

#include <winsock.h>

#define assert ASSERT
#ifdef _DEBUG
#define new DEBUG_NEW
#endif

#pragma warning(disable: 4251 4275) // needs dll-interface warnings



