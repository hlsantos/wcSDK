#pragma once

#ifdef _WIN64
#   pragma message("- Linking wcsmw64 library")
#   pragma comment(lib, "wcsmw64.lib")
#else
#   pragma message("- Linking wcsmw library")
#   pragma comment(lib, "wcsmw.lib")
#endif

