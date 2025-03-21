//***********************************************************************
// (c) Copyright 1998-2025 Santronics Software, Inc. All Rights Reserved.
//***********************************************************************
//
// File Name : AnsiTerm.pas
// Subsystem : Wildcat! ANSI Terminal Emulation
// Version   : 8.0.454.16
// Author    : SSI
// About     : GPT4o
//
// Revision History:
// Build    Date      Author  Comments
// -----    --------  ------  -------------------------------------------
//***********************************************************************

unit AnsiTerm;

interface

uses
  sysutils,
  wcdoor32;

procedure co(ch: char);
procedure coln(const s: string);
procedure ClrScr;
procedure ClrEol;
procedure GotoXY(X, Y: integer);
procedure TextReset;
procedure TextBold;
procedure TextUnderline;
procedure TextReverse;
procedure SetFgColor(color: integer);
procedure SetBgColor(color: integer);

 {$IFDEF VER100}
// Delphi 3 (v10) without default parameters
procedure CursorUp(n: integer);
procedure CursorDown(n: integer);
procedure CursorForward(n: integer);
procedure CursorBack(n: integer);
{$ELSE}
// Delphi newer versions with default parameters
procedure CursorUp(n: integer = 1);
procedure CursorDown(n: integer = 1);
procedure CursorForward(n: integer = 1);
procedure CursorBack(n: integer = 1);
{$ENDIF}

procedure SaveCursorPos;
procedure RestoreCursorPos;
procedure CursorHide;
procedure CursorShow;

implementation

// Output single character
procedure co(ch: char);
begin
  wcDoorWrite(@ch, 1);
end;

// Output string
procedure coln(const s: string);
begin
  if length(s) > 0 then
    wcDoorWrite(@s[1], length(s));
end;

// Send escape sequence
procedure esc(const s: string);
begin
  coln(#27 + s);
end;

// Clear entire screen and move cursor to top-left
procedure ClrScr;
begin
  esc('[2J');
  esc('[H');
end;

// Clear from cursor to end of line
procedure ClrEol;
begin
  esc('[K');
end;

// Move cursor to (X,Y) position (1-based coordinates)
procedure GotoXY(X, Y: integer);
begin
  esc(Format('[%d;%dH', [Y, X]));
end;

// Reset text attributes to default
procedure TextReset;
begin
  esc('[0m');
end;

// Bold text attribute
procedure TextBold;
begin
  esc('[1m');
end;

// Underline text attribute
procedure TextUnderline;
begin
  esc('[4m');
end;

// Reverse video text attribute
procedure TextReverse;
begin
  esc('[7m');
end;

// Set foreground color (30-37 standard)
procedure SetFgColor(color: integer);
begin
  esc(Format('[%dm', [30 + (color and 7)]));
end;

// Set background color (40-47 standard)
procedure SetBgColor(color: integer);
begin
  esc(Format('[%dm', [40 + (color and 7)]));
end;

// Move cursor up by n lines
{$IFDEF VER100}
// Delphi 3 (v10) without default parameters
procedure CursorUp(n: integer {= 1});
begin
  esc(Format('[%dA', [n]));
end;

// Move cursor down by n lines
procedure CursorDown(n: integer {= 1});
begin
  esc(Format('[%dB', [n]));
end;

// Move cursor forward by n characters
procedure CursorForward(n: integer {= 1});
begin
  esc(Format('[%dC', [n]));
end;

// Move cursor backward by n characters
procedure CursorBack(n: integer {= 1});
begin
  esc(Format('[%dD', [n]));
end;

{$ELSE}
// Delphi newer versions with default parameters
// Move cursor down by n lines

procedure CursorUp(n: integer = 1);
begin
  esc(Format('[%dA', [n]));
end;

procedure CursorDown(n: integer = 1);
begin
  esc(Format('[%dB', [n]));
end;

// Move cursor forward by n characters
procedure CursorForward(n: integer = 1);
begin
  esc(Format('[%dC', [n]));
end;

// Move cursor backward by n characters
procedure CursorBack(n: integer = 1);
begin
  esc(Format('[%dD', [n]));
end;
{$ENDIF}

// Save cursor position
procedure SaveCursorPos;
begin
  esc('[s');
end;

// Restore cursor position
procedure RestoreCursorPos;
begin
  esc('[u');
end;

// Hide cursor
procedure CursorHide;
begin
  esc('[?25l');
end;

// Show cursor
procedure CursorShow;
begin
  esc('[?25h');
end;

end.
