# Microsoft Developer Studio Generated NMAKE File, Based on userlist.dsp
!IF "$(CFG)" == ""
CFG=UserList - Win32 Release
!MESSAGE No configuration specified. Defaulting to UserList - Win32 Release.
!ENDIF 

!IF "$(CFG)" != "UserList - Win32 Release" && "$(CFG)" != "UserList - Win32 Debug"
!MESSAGE Invalid configuration "$(CFG)" specified.
!MESSAGE You can specify a configuration when running NMAKE
!MESSAGE by defining the macro CFG on the command line. For example:
!MESSAGE 
!MESSAGE NMAKE /f "userlist.mak" CFG="UserList - Win32 Release"
!MESSAGE 
!MESSAGE Possible choices for configuration are:
!MESSAGE 
!MESSAGE "UserList - Win32 Release" (based on "Win32 (x86) Application")
!MESSAGE "UserList - Win32 Debug" (based on "Win32 (x86) Application")
!MESSAGE 
!ERROR An invalid configuration is specified.
!ENDIF 

!IF "$(OS)" == "Windows_NT"
NULL=
!ELSE 
NULL=nul
!ENDIF 

CPP=cl.exe
MTL=midl.exe
RSC=rc.exe

!IF  "$(CFG)" == "UserList - Win32 Release"

OUTDIR=.\Release
INTDIR=.\Release
# Begin Custom Macros
OutDir=.\Release
# End Custom Macros

ALL : "$(OUTDIR)\userlist.exe"


CLEAN :
	-@erase "$(INTDIR)\StdAfx.obj"
	-@erase "$(INTDIR)\Ulistbox.obj"
	-@erase "$(INTDIR)\Ulistdlg.obj"
	-@erase "$(INTDIR)\Userdisp.obj"
	-@erase "$(INTDIR)\UserList.obj"
	-@erase "$(INTDIR)\userlist.pch"
	-@erase "$(INTDIR)\UserList.res"
	-@erase "$(OUTDIR)\userlist.exe"
	-@erase "$(OUTDIR)\userlist.ilk"
	-@erase "$(OUTDIR)\userlist.pdb"

"$(OUTDIR)" :
    if not exist "$(OUTDIR)/$(NULL)" mkdir "$(OUTDIR)"

CPP_PROJ=/nologo /MD /W3 /GX /O2 /I "..\..\include" /D "WIN32" /D "NDEBUG" /D "_WINDOWS" /D "_AFXDLL" /D "_MBCS" /Fp"$(INTDIR)\userlist.pch" /Yu"stdafx.h" /Fo"$(INTDIR)\\" /Fd"$(INTDIR)\\" /FD /c 
MTL_PROJ=/nologo /D "NDEBUG" /mktyplib203 /win32 
RSC_PROJ=/l 0x409 /fo"$(INTDIR)\UserList.res" /d "NDEBUG" /d "_AFXDLL" 
BSC32=bscmake.exe
BSC32_FLAGS=/nologo /o"$(OUTDIR)\userlist.bsc" 
BSC32_SBRS= \
	
LINK32=link.exe
LINK32_FLAGS=wcsrv2.lib /nologo /subsystem:windows /incremental:yes /pdb:"$(OUTDIR)\userlist.pdb" /debug /machine:I386 /out:"$(OUTDIR)\userlist.exe" /libpath:"..\..\lib" 
LINK32_OBJS= \
	"$(INTDIR)\UserList.obj" \
	"$(INTDIR)\StdAfx.obj" \
	"$(INTDIR)\Ulistbox.obj" \
	"$(INTDIR)\Ulistdlg.obj" \
	"$(INTDIR)\Userdisp.obj" \
	"$(INTDIR)\UserList.res"

"$(OUTDIR)\userlist.exe" : "$(OUTDIR)" $(DEF_FILE) $(LINK32_OBJS)
    $(LINK32) @<<
  $(LINK32_FLAGS) $(LINK32_OBJS)
<<

!ELSEIF  "$(CFG)" == "UserList - Win32 Debug"

OUTDIR=.\Debug
INTDIR=.\Debug
# Begin Custom Macros
OutDir=.\Debug
# End Custom Macros

ALL : "$(OUTDIR)\userlist.exe"


CLEAN :
	-@erase "$(INTDIR)\StdAfx.obj"
	-@erase "$(INTDIR)\Ulistbox.obj"
	-@erase "$(INTDIR)\Ulistdlg.obj"
	-@erase "$(INTDIR)\Userdisp.obj"
	-@erase "$(INTDIR)\UserList.obj"
	-@erase "$(INTDIR)\userlist.pch"
	-@erase "$(INTDIR)\UserList.res"
	-@erase "$(INTDIR)\vc60.idb"
	-@erase "$(INTDIR)\vc60.pdb"
	-@erase "$(OUTDIR)\userlist.exe"
	-@erase "$(OUTDIR)\userlist.ilk"
	-@erase "$(OUTDIR)\userlist.pdb"

"$(OUTDIR)" :
    if not exist "$(OUTDIR)/$(NULL)" mkdir "$(OUTDIR)"

CPP_PROJ=/nologo /MDd /W3 /Gm /GX /ZI /Od /D "WIN32" /D "_DEBUG" /D "_WINDOWS" /D "_AFXDLL" /D "_MBCS" /Fp"$(INTDIR)\userlist.pch" /Yu"stdafx.h" /Fo"$(INTDIR)\\" /Fd"$(INTDIR)\\" /FD /c 
MTL_PROJ=/nologo /D "_DEBUG" /mktyplib203 /win32 
RSC_PROJ=/l 0x409 /fo"$(INTDIR)\UserList.res" /d "_DEBUG" /d "_AFXDLL" 
BSC32=bscmake.exe
BSC32_FLAGS=/nologo /o"$(OUTDIR)\userlist.bsc" 
BSC32_SBRS= \
	
LINK32=link.exe
LINK32_FLAGS=wcsrv2.lib /nologo /subsystem:windows /incremental:yes /pdb:"$(OUTDIR)\userlist.pdb" /debug /machine:I386 /out:"$(OUTDIR)\userlist.exe" /libpath:"..\..\lib" 
LINK32_OBJS= \
	"$(INTDIR)\UserList.obj" \
	"$(INTDIR)\StdAfx.obj" \
	"$(INTDIR)\Ulistbox.obj" \
	"$(INTDIR)\Ulistdlg.obj" \
	"$(INTDIR)\Userdisp.obj" \
	"$(INTDIR)\UserList.res"

"$(OUTDIR)\userlist.exe" : "$(OUTDIR)" $(DEF_FILE) $(LINK32_OBJS)
    $(LINK32) @<<
  $(LINK32_FLAGS) $(LINK32_OBJS)
<<

!ENDIF 

.c{$(INTDIR)}.obj::
   $(CPP) @<<
   $(CPP_PROJ) $< 
<<

.cpp{$(INTDIR)}.obj::
   $(CPP) @<<
   $(CPP_PROJ) $< 
<<

.cxx{$(INTDIR)}.obj::
   $(CPP) @<<
   $(CPP_PROJ) $< 
<<

.c{$(INTDIR)}.sbr::
   $(CPP) @<<
   $(CPP_PROJ) $< 
<<

.cpp{$(INTDIR)}.sbr::
   $(CPP) @<<
   $(CPP_PROJ) $< 
<<

.cxx{$(INTDIR)}.sbr::
   $(CPP) @<<
   $(CPP_PROJ) $< 
<<


!IF "$(NO_EXTERNAL_DEPS)" != "1"
!IF EXISTS("userlist.dep")
!INCLUDE "userlist.dep"
!ELSE 
!MESSAGE Warning: cannot find "userlist.dep"
!ENDIF 
!ENDIF 


!IF "$(CFG)" == "UserList - Win32 Release" || "$(CFG)" == "UserList - Win32 Debug"
SOURCE=.\StdAfx.cpp

!IF  "$(CFG)" == "UserList - Win32 Release"

CPP_SWITCHES=/nologo /MD /W3 /GX /O2 /I "..\..\include" /D "WIN32" /D "NDEBUG" /D "_WINDOWS" /D "_AFXDLL" /D "_MBCS" /Fp"$(INTDIR)\userlist.pch" /Yc"stdafx.h" /Fo"$(INTDIR)\\" /Fd"$(INTDIR)\\" /FD /c 

"$(INTDIR)\StdAfx.obj"	"$(INTDIR)\userlist.pch" : $(SOURCE) "$(INTDIR)"
	$(CPP) @<<
  $(CPP_SWITCHES) $(SOURCE)
<<


!ELSEIF  "$(CFG)" == "UserList - Win32 Debug"

CPP_SWITCHES=/nologo /MDd /W3 /Gm /GX /ZI /Od /D "WIN32" /D "_DEBUG" /D "_WINDOWS" /D "_AFXDLL" /D "_MBCS" /Fp"$(INTDIR)\userlist.pch" /Yc"stdafx.h" /Fo"$(INTDIR)\\" /Fd"$(INTDIR)\\" /FD /c 

"$(INTDIR)\StdAfx.obj"	"$(INTDIR)\userlist.pch" : $(SOURCE) "$(INTDIR)"
	$(CPP) @<<
  $(CPP_SWITCHES) $(SOURCE)
<<


!ENDIF 

SOURCE=.\Ulistbox.cpp

"$(INTDIR)\Ulistbox.obj" : $(SOURCE) "$(INTDIR)" "$(INTDIR)\userlist.pch"


SOURCE=.\Ulistdlg.cpp

"$(INTDIR)\Ulistdlg.obj" : $(SOURCE) "$(INTDIR)" "$(INTDIR)\userlist.pch"


SOURCE=.\Userdisp.cpp

"$(INTDIR)\Userdisp.obj" : $(SOURCE) "$(INTDIR)" "$(INTDIR)\userlist.pch"


SOURCE=.\UserList.cpp

"$(INTDIR)\UserList.obj" : $(SOURCE) "$(INTDIR)" "$(INTDIR)\userlist.pch"


SOURCE=.\UserList.rc

"$(INTDIR)\UserList.res" : $(SOURCE) "$(INTDIR)"
	$(RSC) $(RSC_PROJ) $(SOURCE)



!ENDIF 

