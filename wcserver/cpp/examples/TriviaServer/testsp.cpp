// File: V:\local\wc5\wcsdk\wcserver\cpp\examples\TriviaServer\testsp.cc

#include <stdio.h>
#include <afx.h>

class TAbstractProtocolServer {
public:
  struct TSPDispatch {
    char *cmd;
    BOOL (TAbstractProtocolServer::*f)(char *args);
  };
  TAbstractProtocolServer(TSPDispatch *dispatch);
  ~TAbstractProtocolServer();
private:
  TSPDispatch *Dispatch;
};

class TProtocolServer: public TAbstractProtocolServer {
typedef TAbstractProtocolServer inherited;
public:
  TProtocolServer();
  ~TProtocolServer();
protected:
  virtual void Go();
  virtual void SendWelcome();
private:
  static TSPDispatch Dispatch[];
  BOOL tsCMD1(char *args);
  BOOL tsCMD2(char *args);
  BOOL tsCMD3(char *args);
};


#define SPCMD(cls, cmd, func) \
     {cmd, (BOOL (TAbstractProtocolServer::*)(char *))(cls::func)}

TAbstractProtocolServer::TSPDispatch TProtocolServer::Dispatch[] = {
	SPCMD(TProtocolServer, "CMD1",  tsCMD1),
	SPCMD(TProtocolServer, "CMD2",  tsCMD2),
	SPCMD(TProtocolServer, "CMD3",  tsCMD3),
	{0}
};

BOOL TProtocolServer::tsCMD1(char *args) { return TRUE; }
BOOL TProtocolServer::tsCMD2(char *args) { return TRUE; }
BOOL TProtocolServer::tsCMD3(char *args) { return TRUE; }

void main(char argc, char *argv[])
{
}
