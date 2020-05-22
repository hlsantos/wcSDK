// File:  wcWriteChannel.cpp
// About: Custom Channel Example

#include <stdio.h>
#include <afx.h>
#include <conio.h>
#include <wcserver.h>
#include <wclinker.h>

//////////////////////////////////////////////////////////////
// Wildcat! process that creates the given channel name

char *pszChProc = "wcProject.exe";    // Process to receive signal
char *pszChName = "wcsession.viewer"; // custom channel name
DWORD MY_SIGNAL = 1;                  // custom channel signal

// Custome channel data to write/send to process

typedef struct _TMyChannelData {
    char s1[80];
    char s2[80];
} TMyChannelData;


//////////////////////////////////////////////////////////////
// GetWildcatClientIdByName()

DWORD GetWildcatClientIdByName(const char *szProgamName)
{
    TConnectionInfo ci;
    ci.ConnectionId = 0;
    while (GetConnectionInfo(ci.ConnectionId+1, ci)) {
        if (_stricmp(ci.ProgramName,szProgamName) == 0) {
            return ci.ConnectionId;
        }
    }
    return 0;
}

//////////////////////////////////////////////////////////////
// Main Process
//////////////////////////////////////////////////////////////

void main(char argc, char *argv[])
{
    if (!WildcatServerConnect(NULL)) return;
    if (!WildcatServerCreateContext()) return;

    __try {
        if (!LoginSystem()) return;

        DWORD cid = GetWildcatClientIdByName(pszChProc);
        DWORD ch  = OpenChannel(pszChName);

        printf("* ch: %d cid: %d\n",ch,cid);

        if (cid == 0) {
            printf("! cid is 0. Process \"%s\" not running?\n", pszChProc);
            return;
        }

        TMyChannelData cd;
        ZeroMemory(&cd,sizeof(cd));

        strcpy(cd.s1,"Hi There!");
        strcpy(cd.s2,"Can you hear me now!");

        if (!WriteChannel(ch, cid, MY_SIGNAL, &cd, sizeof(cd))) {
            printf("error %08X writechannel(%d,%d,,,,)\n",GetLastError(),ch,cid);
        }

        _cprintf("<Press Any Key To Continue>"); _getch();

    } __finally {
        WildcatServerDeleteContext();
    }

}
