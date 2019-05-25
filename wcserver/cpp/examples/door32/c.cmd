@echo off
   setlocal
   set cl=/GS /GL /analyze- /W3 /Zc:wchar_t /I"..\..\include" /Zi /Gm- /O2 /Zc:inline /fp:precise /D "WIN32" /D "NDEBUG" /D "_CONSOLE" /D "_USING_V110_SDK71_" /errorReport:prompt /WX- /Zc:forScope /Gd /Oy- /MD /EHsc /nologo
   cl %*

