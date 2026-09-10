#pragma once

#ifdef _WIN64
#  pragma message("<< Preparing linker with library: wcsgate64.lib >>")
#   pragma comment(lib, "wcsgate64.lib")
#else
#  pragma message("<< Preparing linker with library: wcsgate.lib >>")
#   pragma comment(lib, "wcsgate.lib")
#endif
