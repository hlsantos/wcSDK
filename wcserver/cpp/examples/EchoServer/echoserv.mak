# Microsoft Developer Studio Generated NMAKE File, Based on ECHOSERV.DSP
!IF "$(CFG)" == ""
CFG=Echoserv - Win32 Release
!MESSAGE No configuration specified. Defaulting to Echoserv - Win32 Release.
!ENDIF 

!IF "$(CFG)" != "Echoserv - Win32 Release" && "$(CFG)" != "Echoserv - Win32 Debug"
!MESSAGE Invalid configuration "$(CFG)" specified.
!MESSAGE You can specify a configuration when running NMAKE
!MESSAGE by defining the macro CFG on the command line. For example:
!MESSAGE 
!MESSAGE NMAKE /f "ECHOSERV.MAK" CFG="Echoserv - Win32 Release"
!MESSAGE 
!MESSAGE Possible choices for configuration are:
!MESSAGE 
!MESSAGE "Echoserv - Win32 Release" (based on "Win32 (x86) Console Application")
!MESSAGE "Echoserv - Win32 Debug" (based on "Win32 (x86) Console Application")
!MESSAGE 
!ERROR An invalid configuration is specified.
!ENDIF 

!IF "$(OS)" == "Windows_NT"
NULL=
!ELSE 
NULL=nul
!ENDIF 

CPP=cl.exe
RSC=rc.exe

!IF  "$(CFG)" == "Echoserv - Win32 Release"

OUTDIR=.
INTDIR=.
# Begin Custom Macros
OutDir=.
# End Custom Macros

ALL : "$(OUTDIR)\ECHOSERV.exe"


CLEAN :
	-@erase "$(INTDIR)\Echoserv.obj"
	-@erase "$(OUTDIR)\ECHOSERV.exe"

CPP_PROJ=/nologo /MD /W3 /GX /O2 /D "WIN32" /D "NDEBUG" /D "_CONSOLE" /D "_AFXDLL" /D "_MBCS" /Fp"ECHOSERV.pch" /YX /FD /c 
BSC32=bscmake.exe
BSC32_FLAGS=/nologo /o"$(OUTDIR)\ECHOSERV.bsc" 
BSC32_SBRS= \
	
LINK32=link.exe
LINK32_FLAGS=wcsrv.lib wsock32.lib /nologo /subsystem:console /incremental:no /pdb:"$(OUTDIR)\ECHOSERV.pdb" /machine:I386 /out:"$(OUTDIR)\ECHOSERV.exe" 
LINK32_OBJS= \
	"$(INTDIR)\Echoserv.obj"

"$(OUTDIR)\ECHOSERV.exe" : "$(OUTDIR)" $(DEF_FILE) $(LINK32_OBJS)
    $(LINK32) @<<
  $(LINK32_FLAGS) $(LINK32_OBJS)
<<

!ELSEIF  "$(CFG)" == "Echoserv - Win32 Debug"

OUTDIR=.
INTDIR=.
# Begin Custom Macros
OutDir=.
# End Custom Macros

ALL : "$(OUTDIR)\ECHOSERV.exe"


CLEAN :
	-@erase "$(INTDIR)\Echoserv.obj"
	-@erase "$(INTDIR)\vc60.idb"
	-@erase "$(INTDIR)\vc60.pdb"
	-@erase "$(OUTDIR)\ECHOSERV.exe"
	-@erase "$(OUTDIR)\ECHOSERV.ilk"
	-@erase "$(OUTDIR)\ECHOSERV.pdb"

CPP_PROJ=/nologo /MDd /W3 /Gm /GX /ZI /Od /D "WIN32" /D "_DEBUG" /D "_CONSOLE" /D "_AFXDLL" /D "_MBCS" /Fp"ECHOSERV.pch" /YX /FD /c 
BSC32=bscmake.exe
BSC32_FLAGS=/nologo /o"$(OUTDIR)\ECHOSERV.bsc" 
BSC32_SBRS= \
	
LINK32=link.exe
LINK32_FLAGS=wcsrv.lib wsock32.lib /nologo /subsystem:console /incremental:yes /pdb:"$(OUTDIR)\ECHOSERV.pdb" /debug /machine:I386 /out:"$(OUTDIR)\ECHOSERV.exe" 
LINK32_OBJS= \
	"$(INTDIR)\Echoserv.obj"

"$(OUTDIR)\ECHOSERV.exe" : "$(OUTDIR)" $(DEF_FILE) $(LINK32_OBJS)
    $(LINK32) @<<
  $(LINK32_FLAGS) $(LINK32_OBJS)
<<

!ENDIF 

.c.obj::
   $(CPP) @<<
   $(CPP_PROJ) $< 
<<

.cpp.obj::
   $(CPP) @<<
   $(CPP_PROJ) $< 
<<

.cxx.obj::
   $(CPP) @<<
   $(CPP_PROJ) $< 
<<

.c.sbr::
   $(CPP) @<<
   $(CPP_PROJ) $< 
<<

.cpp.sbr::
   $(CPP) @<<
   $(CPP_PROJ) $< 
<<

.cxx.sbr::
   $(CPP) @<<
   $(CPP_PROJ) $< 
<<


!IF "$(NO_EXTERNAL_DEPS)" != "1"
!IF EXISTS("ECHOSERV.DEP")
!INCLUDE "ECHOSERV.DEP"
!ELSE 
!MESSAGE Warning: cannot find "ECHOSERV.DEP"
!ENDIF 
!ENDIF 


!IF "$(CFG)" == "Echoserv - Win32 Release" || "$(CFG)" == "Echoserv - Win32 Debug"
SOURCE=.\Echoserv.cpp

"$(INTDIR)\Echoserv.obj" : $(SOURCE) "$(INTDIR)"



!ENDIF 

