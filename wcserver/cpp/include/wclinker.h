#ifndef __WCLINKER_H
#define __WCLINKER_H

#ifdef _WIN64
#  pragma message("<< Preparing linker with library: wcsrv2x64.lib >>")
#  pragma comment(lib,"wcsrv2x64.lib")
#else
#  pragma message("<< Preparing linker with library: wcsrv2.lib >>")
#  pragma comment(lib,"wcsrv2.lib")
#endif

#endif

