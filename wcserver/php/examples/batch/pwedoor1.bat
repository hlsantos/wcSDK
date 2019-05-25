@echo off

setlocal

:-------------------------------------------------
: These are example PWE door scripts.  The last
: pwescript line is the one that is run.
:-------------------------------------------------

set pwescript=pwe_door_example1.php
set pwescript=pwe_door_example2.php
set pwescript=pwe_door_example3.php
set pwescript=pwe_door_example4.php
set pwescript=pwe_door_example5.php
set pwescript=pwe_door_example6.php
set pwescript=pwe_doorsys_test.php
set pwescript=pwe_obdoor_example1.php
set pwescript=pwe_obdoor_example2.php
set pwescript=pwe_door_ansitest.php
set pwescript=pwe_door_ansitest0.php
set pwescript=pwe_door_ansitest1.php
set pwescript=pwe_door_game_ex1.php
set pwescript=pwe_csp_door_ob.php
set pwescript=pwe_door_trivia_ob.php
set pwescript=pwe_virtualconsole.php
set pwescript=pwe_wcNetNotes.php


set pwescript=pwe_door_ansitest1.php

:--------------------------------------------------
: Don't forget to set the proper paths below.
:--------------------------------------------------

set dropfile=c:\wc6\doors\node%wcnodeid%
cd \wc6\batch\pwe
c:\php6\php.exe -q %pwescript% %dropfile% > stdout.%wcnodeid%

