File   : Readme-Wildcat-Headers.txt
Date   : 05/03/2019
Version: v8.0.454.8

- Obsolete/Deprecated headers

   door32.h          deprepated, see wcdoor32.h
   build.h           deprepated, see wcbuild.h

- Helper Headers for Win32/64

   wcWinBuild.h
   wcCompiler.h

- WCSDK Standard Headers for basic WCSDK clients

   wctype.h           Wildcat! Server data structures
   wcserver.h         Wildcat! Server API functions
   wcserror.h         possible wcserver API errors

- WCSDK Standard Headers for "Mail Gateway" clients

   wcgtype.h
   wcsgate.h

- WCSDK Standard Headers for "Configuration" clients

   wcsmw.h
   wctypemw.h

- WCSDK Standard Headers for plug-in clients

   wcdoor32.h         for creating WCDOOR32 applications
   wcfront.h          for creating WCFRONTEND applications (i.e., PX/WIN) (see note #1)

- WCSDK Standard Headers for plug-in wcOnline hosting

   wcbuild.h
   WconlineModule.h
   WildcatModuleProtocol.h

- This are not necessarily part of the WCSDK. They are helpers for
- some of the C/C++ examples.

   critsect.h  (see note #1)
   linestat.h  (see note #1)
   thread.h    (see note #1)


NOTES:

 1 -  found in "wcsdk\wcserver\cpp\include" folder only.

