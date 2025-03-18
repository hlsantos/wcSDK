@echo off
rem this batch file will compile the wcsdk *.pas files
dcc32 %* door32.pas
dcc32 %* wcdoor32.pas
dcc32 %* wcgtype.pas
dcc32 %* wcserror.pas
dcc32 %* wcserver.pas
dcc32 %* wcsgate.pas
dcc32 %* wcsmw.pas
dcc32 %* wctype.pas
dcc32 %* wctypemw.pas
dcc32 %* ansiterm.pas

