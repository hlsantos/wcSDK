// File: wchello.cpp

#include <stdio.h>
#include <afx.h>
#include <wctype.h>
#include <wcserver.h>

#using <mscorlib.dll>

using namespace System;
using namespace System::Globalization;

#pragma comment(lib,"wcsrv2.lib")

void main(char argc, char *argv[])
{
  if (!WildcatServerConnect(NULL)) return;
  if (!WildcatServerCreateContext()) return;

  __try {
    if (!LoginSystem()) return;

    Console::WriteLine(S"Hello! Connected to server!");

  } __finally {
    WildcatServerDeleteContext();
    Console::WriteLine(S"Hello! Disconnected from server!");
  }

}
