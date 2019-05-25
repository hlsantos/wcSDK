Attribute VB_Name = "w32glob"
Type SYSTEMTIME
        wYear As Integer
        wMonth As Integer
        wDayOfWeek As Integer
        wDay As Integer
        wHour As Integer
        wMinute As Integer
        wSecond As Integer
        wMilliseconds As Integer
End Type

Declare Function GetLastError Lib "KERNEL32" () As Long

Declare Function GetCurrentThreadId Lib "KERNEL32" () As Long

