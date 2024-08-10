#ifndef __WCCACHE_H
#define __WCCACHE_H

#include "wchkeys.h"

#ifdef __cplusplus
extern "C" {
#endif

long PASCAL WcEnumKey(WCHKEY hkey, DWORD subkeyindex, char far *subkey, DWORD cbsubkey);

long PASCAL WcCreateKey(WCHKEY hkey, const char far *subkey, WCHKEY far *phkey);
long PASCAL WcDeleteKey(WCHKEY hkey, const char far *subkey);

long PASCAL WcOpenKey(WCHKEY hkey, const char far *subkey, WCHKEY far *phkey);
long PASCAL WcCloseKey(WCHKEY hkey);

long PASCAL WcSetValue(WCHKEY hkey, const char far *value, void far *data, DWORD cbdata);
long PASCAL WcQueryValue(WCHKEY hkey, const char far *value, void far *data, DWORD far *cbdata);
long PASCAL WcDeleteValue(WCHKEY hkey, const char far *value);

long PASCAL WcQueryValueCRC(WCHKEY hkey, const char far *value, DWORD far *crc);
long PASCAL WcEnumValue(WCHKEY hkey, DWORD valueindex, char far *value, DWORD cbvalue);

long PASCAL WcGetKeyName(WCHKEY hkey, BOOL includepath, char far *keyname, DWORD cbkeyname);

#ifdef __cplusplus
}
#endif

#endif
