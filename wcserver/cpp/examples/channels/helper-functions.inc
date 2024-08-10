#if 0
const char *GetEventName(const TChannelMessage *msg, const char *dest, const int dsize)
{
    char sz[32] = {0};
    if ((short)msg->UserData == SC_CHANNEL_CLOSE) {
        strcpy(sz,"SC_CHANNEL_CLOSE");
    } else {
        sprintf(sz,"%2d",(short)msg->UserData);
    }

    if (msg->Channel == SystemEventChannel) {
        switch (msg->UserData) {
        case SE_FILE_UPLOAD:            strcpy(sz,"SE_FILE_UPLOAD"); break;
        case SE_FILE_DOWNLOAD:          strcpy(sz,"SE_FILE_DOWNLOAD"); break;
        case SE_FILE_DELETE:            strcpy(sz,"SE_FILE_DELETE"); break;
        case SE_FILE_UPDATE:            strcpy(sz,"SE_FILE_UPDATE"); break;
       }
    }
    strncpy(dest,sz, dsize);
    return dest;
}

const char *GetSenderName(const DWORD cid, const char *dest, const int dsize)
{
    char sz[64] = {0};
    TConnectionInfo ci;
    if (GetConnectionInfo(cid,ci)) {
        strcpy(sz,ci.ProgramName);
    } else {
        sprintf(sz, "%3d",cid);
    }
    strncpy(dest,sz, dsize);
    return dest;
}
#endif
