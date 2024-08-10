*************************************************
** Kernel functions

DECLARE INTEGER GetTickCount IN kernel32
DECLARE INTEGER GetLastError IN kernel32
DECLARE INTEGER SetLastError IN kernel32;
       INTEGER iError

DECLARE INTEGER SystemTimeToFileTime IN kernel32;
    STRING @lpSystemTime, ;
    STRING @lpFileTime



