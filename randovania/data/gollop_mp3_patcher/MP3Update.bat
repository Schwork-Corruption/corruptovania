@echo off
@echo Patching paks...
mkdir "%~dp0original_paks"
move /y "%~dp0paks\FrontEnd.pak" "%~dp0original_paks"
move /y "%~dp0game_files\DATA\files\NoARAM.pak" "%~dp0original_paks"
move /y "%~dp0paks\Metroid1.pak" "%~dp0original_paks"
move /y "%~dp0paks\Metroid3.pak" "%~dp0original_paks"
move /y "%~dp0paks\Metroid4.pak" "%~dp0original_paks"
move /y "%~dp0paks\Metroid5.pak" "%~dp0original_paks"
move /y "%~dp0paks\Metroid6.pak" "%~dp0original_paks"
move /y "%~dp0paks\Metroid7.pak" "%~dp0original_paks"
move /y "%~dp0paks\UniverseArea.pak" "%~dp0original_paks"
hpatchz.exe "%~dp0original_paks/FrontEnd.pak" "%~dp0MP3Update/FrontEnd.hdiff" "%~dp0paks/FrontEnd.pak" 
hpatchz.exe "%~dp0original_paks/NoARAM.pak" "%~dp0MP3Update/NoARAM.hdiff" "%~dp0game_files/DATA/files/NoARAM.pak" 
hpatchz.exe "%~dp0original_paks/Metroid1.pak" "%~dp0MP3Update/Metroid1.hdiff" "%~dp0paks/Metroid1.pak" 
hpatchz.exe "%~dp0original_paks/Metroid3.pak" "%~dp0MP3Update/Metroid3.hdiff" "%~dp0paks/Metroid3.pak" 
hpatchz.exe "%~dp0original_paks/Metroid4.pak" "%~dp0MP3Update/Metroid4.hdiff" "%~dp0paks/Metroid4.pak" 
hpatchz.exe "%~dp0original_paks/Metroid5.pak" "%~dp0MP3Update/Metroid5.hdiff" "%~dp0paks/Metroid5.pak"
hpatchz.exe "%~dp0original_paks/Metroid6.pak" "%~dp0MP3Update/Metroid6.hdiff" "%~dp0paks/Metroid6.pak"
hpatchz.exe "%~dp0original_paks/Metroid7.pak" "%~dp0MP3Update/Metroid7.hdiff" "%~dp0paks/Metroid7.pak"
hpatchz.exe "%~dp0original_paks/UniverseArea.pak" "%~dp0MP3Update/UniverseArea.hdiff" "%~dp0paks/UniverseArea.pak"
@echo Done!
pause