// File: wcSendEvent.cpp
// Test utility to send Wildcat events

#include <stdio.h>
#include <windows.h>
#include <wctype.h>
#include <wcserver.h>
#include <wclinker.h>
#include <conio.h>

void help()
{
   printf("syntax: wcSendEvent event\n");
   printf("\n");
   printf("possible events\n");
   printf("---------------\n");
   printf("SE_FILE_UPLOAD          = 10;  // file uploaded\n");
   printf("SE_FILE_DOWNLOAD        = 11;  // file downloaded\n");
   printf("SE_FILE_DELETE          = 12;  // file deleted\n");
   printf("SE_FILE_UPDATE          = 13;  // file was updated/moved\n");
   printf("SE_SHUTDOWN_REQUEST     = 20;  // request to shutdown\n");
   printf("SE_RESTART              = 21;  // request to restart\n");
   printf("SE_CONFIG_CHANGE        = 22;  // Makewild has changed, minimum\n");
   printf("SE_SERVER_STATE_CHANGE  = 30;  // server state has changed\n");
   printf("SE_NODE_STATE_CHANGE    = 31;  // node state has changed\n");
   printf("SE_MAILSERVER_UPDATE    = 40;  // mail server reload\n");
}

int GetSE(const char *sz, char *szChannel)
{
    strcpy(szChannel,"System.Event");
    if (!_stricmp(sz,"SE_FILE_UPLOAD"))         return SE_FILE_UPLOAD;
    if (!_stricmp(sz,"SE_FILE_DOWNLOAD"))       return SE_FILE_DOWNLOAD;
    if (!_stricmp(sz,"SE_FILE_DELETE"))         return SE_FILE_DELETE;
    if (!_stricmp(sz,"SE_FILE_UPDATE"))         return SE_FILE_UPDATE;
    if (!_stricmp(sz,"SE_SHUTDOWN_REQUEST"))    return SE_SHUTDOWN_REQUEST;
    if (!_stricmp(sz,"SE_RESTART"))             return SE_RESTART;
    if (!_stricmp(sz,"SE_CONFIG_CHANGE"))       return SE_CONFIG_CHANGE;
    if (!_stricmp(sz,"SE_SERVER_STATE_CHANGE")) return SE_SERVER_STATE_CHANGE;
    if (!_stricmp(sz,"SE_NODE_STATE_CHANGE"))   return SE_NODE_STATE_CHANGE;

    if (!_stricmp(sz,"SE_MAILSERVER_UPDATE"))   {
        strcpy(szChannel,"System.MailServer");
        return SE_MAILSERVER_UPDATE;
    }
    return -1;
}

void main(char argc, char *argv[])
{
    if (argc < 2) {
        help();
        return;
    }
    char szChannel[100];
    int evt = GetSE(argv[1],szChannel);
    if (evt == -1) {
        printf("Unknown event\n");
        help();
        return;
    }

    if (!WildcatServerConnect(NULL)) return;
    if (!WildcatServerCreateContext()) return;

    __try {
       if (!LoginSystem()) return;
       DWORD ch = OpenChannel(szChannel);
       if (!WriteChannel(ch, 0, evt, &ch, 0)) {
          printf("Error %d WriteChannel()\n",GetLastError());
       } else {
          printf("Event %d sent to channel: %s\n",evt,szChannel);
       }
    } __finally {
      WildcatServerDeleteContext();
    }

}
