#ifndef __DOOR32_H
#define __DOOR32_H

#ifdef __cplusplus
extern "C" {
#endif

BOOL   APIENTRY DoorInitialize();
BOOL   APIENTRY DoorShutdown();

BOOL   APIENTRY DoorWrite(const void *data, DWORD size);
DWORD  APIENTRY DoorRead(void *data, DWORD size);

DWORD  APIENTRY DoorReadPeek(void *data, DWORD size);
DWORD  APIENTRY DoorCharReady();

HANDLE APIENTRY DoorGetAvailableEventHandle();
HANDLE APIENTRY DoorGetOfflineEventHandle();

BOOL APIENTRY DoorHangUp();

#ifdef __cplusplus
} // extern "C"
#endif

#endif
