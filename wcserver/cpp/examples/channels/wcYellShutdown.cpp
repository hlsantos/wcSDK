// File: wcYellShutdown.cpp

#include <stdio.h>
#include <windows.h>
#include <wcserver.h>
#include <wclinker.h>

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
