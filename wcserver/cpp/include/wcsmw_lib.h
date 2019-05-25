#pragma once

#ifdef _WIN64
#   pragma comment(lib, "wcsmw64.lib")
#else
#   pragma comment(lib, "wcsmw.lib")
#endif
