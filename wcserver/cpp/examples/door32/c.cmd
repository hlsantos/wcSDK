@echo off
   setlocal

   if "%1" == "" (
      echo syntax: cl source.cpp [options]
      goto :eof
   )


REM add /MD to link RTE DLL files, makes EXE smaller
REM     example: c source.cpp /MD
REM add /Zi to create *.PDB debug database
REM     example: c source.cpp /Zi

   set cl=/GS /GL /analyze- /W3 /Zc:wchar_t /I"..\..\include" /Gm- /O2 /Zc:inline /fp:precise /D "WIN32" /D "NDEBUG" /D "_CONSOLE" /D "_USING_V110_SDK71_" /errorReport:prompt /WX- /Zc:forScope /Gd /Oy- /EHsc /nologo /D "_CRT_SECURE_NO_WARNINGS"

   for %%i in (%1) do call :compile "%%~nxi" %2 %3 %4 %5
   goto :eof


:compile
   echo ===================================== %*
   cl %*
   if errorlevel 1 goto :eof
   if exist %~n1.obj erase %~n1.obj
   goto :eof

