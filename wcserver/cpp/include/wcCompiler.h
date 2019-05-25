#pragma once

#if _MSC_VER == 1200
#  pragma message("* VC6 VS1998")
#endif
#if _MSC_VER == 1300
#  pragma message("* VC7 VS2002")
#endif
#if _MSC_VER == 1301
#  pragma message("* VC71 VS2003")
#endif
#if _MSC_VER == 1400
#  pragma message("* VC8 VS2005")
#endif
#if _MSC_VER == 1500
#  pragma message("* VC9 VS2008")
#endif
#if _MSC_VER == 1600
#  pragma message("* VC10 VS2010")
#endif
#if _MSC_VER == 1600
#  pragma message("* VC10 VS2010")
#endif
#if _MSC_VER == 1900
#  pragma message("* VC14 VS2015")
#endif


#if _MSC_VER > 1200
#  ifndef _CRT_SECURE_NO_WARNINGS
#	 define _CRT_SECURE_NO_WARNINGS
#  endif
#  ifndef _CRT_SECURE_NO_DEPRECATE
#	 define _CRT_SECURE_NO_DEPRECATE
#  endif
#endif

#if _MSC_VER > 1200
//#  pragma warning( disable : 4867 4407)  // removes pointer to member function initialization error
#endif

#ifdef _ATL_ENABLE_PTM_WARNING
#  pragma message("* _ATL_ENABLE_PTM_WARNING is defined")
#endif

