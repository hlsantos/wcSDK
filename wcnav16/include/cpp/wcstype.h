// Responsibility::GDH

#ifndef __WCSTYPE_H
#define __WCSTYPE_H

struct TSecurityInfo {
  // object id management
  DWORD LastObjectId[256];
};

struct TMasterInfo {
  // totals
  DWORD TotalCalls;
  DWORD TotalMessages;
  // id management
  DWORD LastUserId;
  DWORD LastMessageId;
  // qotd
  DWORD QuoteOffset;
};

#endif
