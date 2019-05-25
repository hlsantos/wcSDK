// File: V:\wc5beta\wcYellShutdown.cpp

#include <stdio.h>
#include <afx.h>
#include <wctype.h>
#include <wcserver.h>

#pragma comment(lib,"wcsrv2.lib")

void Yell()
{
   TPageMessage page = {"Sysop",
                        "Shutdown in 10 minutes! Please logout"};

   WriteChannel(OpenChannel("System.Page"),
                0,0,&page,sizeof(page));

}

int main(char argc, char *argv[])
{
  if (!WildcatServerConnect(NULL)) return 1;
  if (!WildcatServerCreateContext()) return 1;

  __try {
    if (!LoginSystem()) return 1;
    Yell();
  } __finally {
    WildcatServerDeleteContext();
  }

  return 0;
}
