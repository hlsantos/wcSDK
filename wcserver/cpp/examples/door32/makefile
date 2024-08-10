#----------------------------------------------------------------  THIS WORKS
#all: wcDoor32-example.cpp wcDoor32-example.exe  dortst32.cpp dortst32.exe
#
#dortst32.exe: dortst32.cpp dortst32.obj
#	cl dortst32.cpp $(CL)
#
#wcDoor32-example.exe: wcDoor32-example.cpp wcDoor32-example.obj
#	cl wcDoor32-example.cpp $(CL)
#----------------------------------------------------------------

#
#CPPFLAGS=/W3 /EHsc /D "_CRT_SECURE_NO_WARNINGS" /D "_WIN32_WINNT=0x0501" /D "_USING_V110_SDK71_" /link /SUBSYSTEM:CONSOLE,"5.01"
#CPPFLAGS=/W3 /EHsc /D "_CRT_SECURE_NO_WARNINGS" /D "_WIN32_WINNT=0x0501" /D "_USING_V110_SDK71_"
#CPPFLAGS=/Zi /Zo /W3 /EHsc /MD /D "_AFXDLL" /D "_CRT_SECURE_NO_WARNINGS"
# smallest
CPPFLAGS=/GS /GL /analyze- /W3 /Zc:wchar_t /I"..\..\include" /Zi /Gm- /O2 /Zc:inline /fp:precise /D "WIN32" /D "NDEBUG" /D "_CONSOLE" /D "_USING_V110_SDK71_" /errorReport:prompt /WX- /Zc:forScope /Gd /Oy- /MD /EHsc /nologo

#SRCS=wcDoor32-example.cpp dortst32.cpp

TARGETS=wcDoor32-example.exe wcDoor32-example.obj
        dortst32.exe dortst32.obj


all : $(TARGETS)

#.cpp.exe:
#	$(CPP) $(CPPFLAGS) $<

clean :
    del *.exe *.obj
