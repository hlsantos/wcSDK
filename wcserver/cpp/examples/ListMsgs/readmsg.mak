# Microsoft Developer Studio Generated NMAKE File, Based on readmsg.dsp
!IF "$(CFG)" == ""
CFG=ReadMsg - Win32 Release
!MESSAGE No configuration specified. Defaulting to ReadMsg - Win32 Release.
!ENDIF 

!IF "$(CFG)" != "ReadMsg - Win32 Release" && "$(CFG)" != "ReadMsg - Win32 Debug"
!MESSAGE Invalid configuration "$(CFG)" specified.
!MESSAGE You can specify a configuration when running NMAKE
!MESSAGE by defining the macro CFG on the command line. For example:
!MESSAGE 
!MESSAGE NMAKE /f "readmsg.mak" CFG="ReadMsg - Win32 Release"
!MESSAGE 
!MESSAGE Possible choices for configuration are:
!MESSAGE 
!MESSAGE "ReadMsg - Win32 Release" (based on "Win32 (x86) Application")
!MESSAGE "ReadMsg - Win32 Debug" (based on "Win32 (x86) Application")
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

!IF  "$(CFG)" == "ReadMsg - Win32 Release"

OUTDIR=.\Release
INTDIR=.\Release
# Begin Custom Macros
OutDir=.\Release
# End Custom Macros

ALL : "$(OUTDIR)\readmsg.exe"


CLEAN :
	-@erase "$(INTDIR)\Clistbox.obj"
	-@erase "$(INTDIR)\Mreader.obj"
	-@erase "$(INTDIR)\ReadMsg.obj"
	-@erase "$(INTDIR)\readmsg.pch"
	-@erase "$(INTDIR)\ReadMsg.res"
	-@erase "$(INTDIR)\Rmsgdlg.obj"
	-@erase "$(INTDIR)\StdAfx.obj"
	-@erase "$(INTDIR)\vc60.idb"
	-@erase "$(OUTDIR)\readmsg.exe"

"$(OUTDIR)" :
    if not exist "$(OUTDIR)/$(NULL)" mkdir "$(OUTDIR)"

CPP_PROJ=/nologo /MD /W3 /GX /O2 /I "..\..\include" /D "WIN32" /D "NDEBUG" /D "_WINDOWS" /D "_AFXDLL" /D "_MBCS" /Fp"$(INTDIR)\readmsg.pch" /Yu"stdafx.h" /Fo"$(INTDIR)\\" /Fd"$(INTDIR)\\" /FD /c 
MTL_PROJ=/nologo /D "NDEBUG" /mktyplib203 /win32 
RSC_PROJ=/l 0x409 /fo"$(INTDIR)\ReadMsg.res" /d "NDEBUG" /d "_AFXDLL" 
BSC32=bscmake.exe
BSC32_FLAGS=/nologo /o"$(OUTDIR)\readmsg.bsc" 
BSC32_SBRS= \
	
LINK32=link.exe
LINK32_FLAGS=wcsrv2.lib /nologo /subsystem:windows /incremental:no /pdb:"$(OUTDIR)\readmsg.pdb" /machine:I386 /out:"$(OUTDIR)\readmsg.exe" /libpath:"..\..\lib" 
LINK32_OBJS= \
	"$(INTDIR)\Clistbox.obj" \
	"$(INTDIR)\Mreader.obj" \
	"$(INTDIR)\ReadMsg.obj" \
	"$(INTDIR)\Rmsgdlg.obj" \
	"$(INTDIR)\StdAfx.obj" \
	"$(INTDIR)\ReadMsg.res"

"$(OUTDIR)\readmsg.exe" : "$(OUTDIR)" $(DEF_FILE) $(LINK32_OBJS)
    $(LINK32) @<<
  $(LINK32_FLAGS) $(LINK32_OBJS)
<<

!ELSEIF  "$(CFG)" == "ReadMsg - Win32 Debug"

OUTDIR=.\Debug
INTDIR=.\Debug
# Begin Custom Macros
OutDir=.\Debug
# End Custom Macros

ALL : "$(OUTDIR)\readmsg.exe"


CLEAN :
	-@erase "$(INTDIR)\Clistbox.obj"
	-@erase "$(INTDIR)\Mreader.obj"
	-@erase "$(INTDIR)\ReadMsg.obj"
	-@erase "$(INTDIR)\readmsg.pch"
	-@erase "$(INTDIR)\ReadMsg.res"
	-@erase "$(INTDIR)\Rmsgdlg.obj"
	-@erase "$(INTDIR)\StdAfx.obj"
	-@erase "$(INTDIR)\vc60.idb"
	-@erase "$(INTDIR)\vc60.pdb"
	-@erase "$(OUTDIR)\readmsg.exe"
	-@erase "$(OUTDIR)\readmsg.ilk"
	-@erase "$(OUTDIR)\readmsg.pdb"

"$(OUTDIR)" :
    if not exist "$(OUTDIR)/$(NULL)" mkdir "$(OUTDIR)"

CPP_PROJ=/nologo /MDd /W3 /Gm /GX /ZI /Od /I "..\..\include" /D "WIN32" /D "_DEBUG" /D "_WINDOWS" /D "_AFXDLL" /D "_MBCS" /Fp"$(INTDIR)\readmsg.pch" /Yu"stdafx.h" /Fo"$(INTDIR)\\" /Fd"$(INTDIR)\\" /FD /c 
MTL_PROJ=/nologo /D "_DEBUG" /mktyplib203 /win32 
RSC_PROJ=/l 0x409 /fo"$(INTDIR)\ReadMsg.res" /d "_DEBUG" /d "_AFXDLL" 
BSC32=bscmake.exe
BSC32_FLAGS=/nologo /o"$(OUTDIR)\readmsg.bsc" 
BSC32_SBRS= \
	
LINK32=link.exe
LINK32_FLAGS=wcsrv2.lib /nologo /subsystem:windows /incremental:yes /pdb:"$(OUTDIR)\readmsg.pdb" /debug /machine:I386 /out:"$(OUTDIR)\readmsg.exe" /libpath:"..\..\lib" 
LINK32_OBJS= \
	"$(INTDIR)\Clistbox.obj" \
	"$(INTDIR)\Mreader.obj" \
	"$(INTDIR)\ReadMsg.obj" \
	"$(INTDIR)\Rmsgdlg.obj" \
	"$(INTDIR)\StdAfx.obj" \
	"$(INTDIR)\ReadMsg.res"

"$(OUTDIR)\readmsg.exe" : "$(OUTDIR)" $(DEF_FILE) $(LINK32_OBJS)
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
!IF EXISTS("readmsg.dep")
!INCLUDE "readmsg.dep"
!ELSE 
!MESSAGE Warning: cannot find "readmsg.dep"
!ENDIF 
!ENDIF 


!IF "$(CFG)" == "ReadMsg - Win32 Release" || "$(CFG)" == "ReadMsg - Win32 Debug"
SOURCE=.\Clistbox.cpp

"$(INTDIR)\Clistbox.obj" : $(SOURCE) "$(INTDIR)" "$(INTDIR)\readmsg.pch"


SOURCE=.\Mreader.cpp

"$(INTDIR)\Mreader.obj" : $(SOURCE) "$(INTDIR)" "$(INTDIR)\readmsg.pch"


SOURCE=.\ReadMsg.cpp

"$(INTDIR)\ReadMsg.obj" : $(SOURCE) "$(INTDIR)" "$(INTDIR)\readmsg.pch"


SOURCE=.\ReadMsg.rc

"$(INTDIR)\ReadMsg.res" : $(SOURCE) "$(INTDIR)"
	$(RSC) $(RSC_PROJ) $(SOURCE)


SOURCE=.\Rmsgdlg.cpp

"$(INTDIR)\Rmsgdlg.obj" : $(SOURCE) "$(INTDIR)" "$(INTDIR)\readmsg.pch"


SOURCE=.\StdAfx.cpp

!IF  "$(CFG)" == "ReadMsg - Win32 Release"

CPP_SWITCHES=/nologo /MD /W3 /GX /O2 /I "..\..\include" /D "WIN32" /D "NDEBUG" /D "_WINDOWS" /D "_AFXDLL" /D "_MBCS" /Fp"$(INTDIR)\readmsg.pch" /Yc"stdafx.h" /Fo"$(INTDIR)\\" /Fd"$(INTDIR)\\" /FD /c 

"$(INTDIR)\StdAfx.obj"	"$(INTDIR)\readmsg.pch" : $(SOURCE) "$(INTDIR)"
	$(CPP) @<<
  $(CPP_SWITCHES) $(SOURCE)
<<


!ELSEIF  "$(CFG)" == "ReadMsg - Win32 Debug"

CPP_SWITCHES=/nologo /MDd /W3 /Gm /GX /ZI /Od /I "..\..\include" /D "WIN32" /D "_DEBUG" /D "_WINDOWS" /D "_AFXDLL" /D "_MBCS" /Fp"$(INTDIR)\readmsg.pch" /Yc"stdafx.h" /Fo"$(INTDIR)\\" /Fd"$(INTDIR)\\" /FD /c 

"$(INTDIR)\StdAfx.obj"	"$(INTDIR)\readmsg.pch" : $(SOURCE) "$(INTDIR)"
	$(CPP) @<<
  $(CPP_SWITCHES) $(SOURCE)
<<


!ENDIF 


!ENDIF 

