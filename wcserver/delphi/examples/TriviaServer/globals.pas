unit Globals;

interface

uses
//  TextFile,
  Windows;

var
  ActiveConnections : Integer;
  DataFileMutex : TRTLCriticalSection;
{  DataFile : TTextFile; }
  DataFile : Text;

implementation

end.
