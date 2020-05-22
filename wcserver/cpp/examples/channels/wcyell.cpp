// File: wcYell.cpp

#include <stdio.h>
#include <stdio.h>
#include <windows.h>
#include <wcserver.h>
#include <wcversion.h>
#include <wclinker.h>


void Yell(char argc, char *argv[])
{
   TPageMessage page = {"Sysop",""};
   char sz[sizeof(page.message[0])] = {0};
   for (int i=1; i<argc; i++) {
      char *p = argv[i];
      if (strlen(sz)+strlen(p) < sizeof(sz)) {
         if (i > 1 && (sz[strlen(sz)-1] != ' ')) strncat(sz," ",sizeof(sz)-1);
         strncat(sz,p, sizeof(sz)-1);
      } else {
         strncat(sz,p, sizeof(sz)-1);
         break;
      }
   }
   strncpy(page.message[0], sz, sizeof(page.message));
   WriteChannel(OpenChannel("System.Page"),0,0,&page,sizeof(page));
}

int main(char argc, char *argv[])
{
   if (argc < 2) {
       printf("wcYell %s %s\n", WC_VERSION_STR, WC_COPYRIGHT_LONG);
       printf("syntax: wcYell <broadcast message>\n");
       printf("\n");
       printf("wcYell will broadcast a message to all nodes. The maximum\n");
       printf("length of the message is 78 characters\n");
       printf("\n");
       printf("example: wcYell Please Log off! System Maintenance begins in 1 min\n");
       return 1;
   }

   if (!WildcatServerConnect(NULL)) return 1;
   if (!WildcatServerCreateContext()) return 1;

   __try {
     if (!LoginSystem()) return 1;
     Yell(argc, argv);
   } __finally {
     WildcatServerDeleteContext();
   }

   return 0;
}
