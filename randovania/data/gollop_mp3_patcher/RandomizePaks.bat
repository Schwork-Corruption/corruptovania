set seed="00444t7u44k44}k4444Cp44kk4y4444Hh9kI4d4f444{4sI44k4Bk4k44^nv44k{444ogI4444k4}I4IeIk4rkII44a84#zkxD4kq499598"
set "starting_items=custom 0000000010010000000000100100000000000010000"
set "starting_location=custom c133f919c108bdf9 d8cf355d3e9e3741"
set "random_door_colors=false"
set "random_welding_colors=false"
set "hyper_hints=true"
set "fast_flying=true"
set "phaaze_skip=false"
set "require_launcher=true"
set "require_ship_missile=true"

set "input_path=%~dp0paks/"
set "output_path=%~dp0game_files/DATA/files/"

@echo off
if %seed% == "" echo.
if %seed% == "" echo No seed layout given. Change the seed parameter in the .bat file to your desired seed.
if %seed% == "" pause
if %seed% == "" exit
@echo on

if %random_door_colors%==true (set "random_door_colors=--random-door-colors")else (set "random_door_colors=")
if %random_welding_colors%==true (set "random_welding_colors=--random-welding-colors") else (set "random_welding_colors=")
if %hyper_hints%==true (set "hyper_hints=--hyper-hints") else (set "hyper_hints=")
if %fast_flying%==true (set "fast_flying=--fast-flying") else (set "fast_flying=")
if %phaaze_skip%==true (set "phaaze_skip=--phaaze-skip") else (set "phaaze_skip=")
if %require_launcher%==true (set "require_launcher=--require-launcher") else (set "require_launcher=")
if %require_ship_missile%==true (set "require_ship_missile=--require-ship-missile") else (set "require_ship_missile=")

MP3Randomizer.exe --input-path "%input_path%" --output-path "%output_path%" --layout %seed% --starting-items %starting_items% --starting-location %starting_location% %hyper_hints% %random_door_colors% %random_welding_colors% %fast_flying% %phaaze_skip% %require_launcher% %require_ship_missile%
pause