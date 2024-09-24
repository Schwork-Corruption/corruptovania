This is a mod for Corruption intended to be used in conjuction with Gollop's MP3Randomizer program, since that project is discontinued, this mod takes it's place in terms of updating the game for adding certain Quality of Life improvements.


How To INSTALL:

NOTE: If you are installing for the first time, it is recommended that you re-export your game for clean files, you can do this by deleting the files in the folder "game_files" and "paks" inside Gollop's MP3Randomizer folder, then follow the instructions on their original readme file again.

Step 1: Extract MP3Update inside Gollop's MP3Randomizer folder.
Step 2: In there, run MP3Update.bat and wait for it to finish.

After that, the changes are done and you can continue with the standard procedure of making a new seed.
There will be a new folder named "original_paks" which will have files needed for whenever this unevitably gets updated, so leave them there.

How to UPDATE:
Replace the contents of the new MP3Update folder with the old one (Inside MP3Randomizer) then replace (move) the files of "original_paks" into "paks". Then run MP3Update.bat in the MP3Randomizer folder.


And that's it! Enjoy the following changes:


12/1/23 - Update 10

- Fixed the Demolition Troopers count text staying on screen forever if bailed out of Skyway Access.
- Fixed Zipline Station Delta softlock issue for the 2nd time.
- Properly fixed the music not playing after the Nova Beam laser fight in Main Cavern.
- Admiral Dane won't take you to the map screen anymore after the rendezvous call.
- Shortened the HUDMemo duration of Hall of Remembrance item.

11/27/23 - Update 9

- Disabling the Defense System will now deactivate the 1st Pass layer in Skyway Access, to prevent overlapping layer issues.
- Adjusted the repositions of Skyway Access to be outside the acid rain.
- Fixed an issue with certain cutscenes where if you watched them fully and then skipped a different one, it would not skip them properly.
- Fixed an issue in Zipline Station Delta where if you screw attacked to the middle platform you would get stuck far oob.
- Shortened various long HUDMemo durations.
- Removed the HUDMemo in Phaaze after getting permanent hypermode.

10/18/23 - Update 8

- The ALARM layer in Metroid Processing no longer get disabled after disabling the Pirate Defense System, to prevent a softlock regarding the 1st Pass Fight.
- Reverted IFT Hint Calls patch due to it causing a different bug and not actually causing the hint calls to not go through.


9/28/23 - Update 7

- Fixed Weld Panel softlock in Scrapvault that happens when the commando intro cutscene starts while you're welding.
- Fixed Seed IFTs still playing continously upon world changes.


9/28/23 - Update 6

## Base
- Removed (Hopefully) all remaining IFT Hint calls.

## Elysia
- Changed the Elevator trigger in Skytown Federation Landing Site to match Landing Site A's elevator trigger flags.
- IFTs doesn't take you to the map screen anymore.
- Shortened the HUDMemo duration of AU Vaccine.
- Added missing instant CSI in Concourse west weld panel.
- Fixed incorrect CSI position in Escape Pod Bay Access top Hand Panel.
- You can now move from Security Station/Junction to Aurora Chamber pods and vice versa in empty Spire Dock. (Look for Holograms)

## Bryyo
- 'Shield Flicker' layers in Temple Generator and Jungle Generator are now active by default.


9/26/23 - Update 5

- Removed Big Door opening cinematic scripting in Cargo Dock A.
- Adjusted Snatcher ControlHint in Main Lift to allow Boosting when being lift up.
- The small Fuel Gel stream in Hidden Court is now flammable by uncharged power shots.
- Removed no control PlayerHint in Imperial Hall.
- The Gel Spirals in Imperial Hall can now be shot from reverse.
- Shortened the HUDMemo duration of Ballista Storage item.
- Fixed incorrect CSI positions in Phazon Quarry and Defense Access.
- Added PAL fix for Mine Lift.


9/25/23 - Update 4

## Base
- All Context Sensitive Indicators now move you into position instantly.

## Bryyo
- Removed no jump ControlHint in Hangar Bay elevator.
- Re-aligned the door leading to North Jungle Hall in Auxiliary Dynamo.
- Fixed an incorrect sound effect playing when grabbing the item in Temple of Bryyo.
- Fixed Item peek camera in Fuel Gel Pool not working. (Scan the door instead)

## Elysia
- Increased the velocity of all Ziplines by 50%. (With the exception of Zipline Station Charlie and Spire Dock)
 - Be adviced this could cause Motion Sickness if you are prone to it.
- It is no longer needed to interact with AU 217 at all.
- The doors in Aurora Chamber won't lock anymore, aside from a special exception.
- After the Ghor Sighting cinematic is finished in Aurora Chamber, the welding panels will be accessible immediately without needing a room reload.
- Fixed Ship Warning IFT still playing multiple times.
- Removed Ship Repaired IFT.
- Shortened the HUDMemo duration of Plasma Beam item.
- Defeating Ghor now properly disables the Gunship Under Attack event.
- Removed Chozo Observatory scripting.

## Pirate Homeworld
- Changed the Default SpawnPoint in Scrapvault to be on the ground floor.
- Removed Hazard Shield acquisition cinematic.
- Removed No Control PlayerHint in Main Cavern.
- Fixed Music not playing after the Nova Beam laser fight in Main Cavern.
- The push force trigger in Defense Access when coming from Skyway Access now gets deactivated after exiting it.

## Valhalla
- Removed Leviathan IFT in Control Room.
- Shortened the HUDMemo duration of Pirate Code.


9/20/23 - Update 3

- Fixed Help Menu scripting misbehaving for the 2nd Time.
- Improved Morph Elevator scripting in Command Station.
- Improved loading scripting for all Transit Station rooms.


9/19/23 - Update 2

- Fixed the Help Menu not working properly.
- Fixed Hangar Bay not having a SpawnPoint, putting the player out of bounds when loading the game from here.


9/19/23 - Update 1

## Base
- The Death hotkey has been extended into a help menu. Use this if you want to cheat or something idk.

##N Norion
- The gate in Docking Hub Alpha starts opened by default.
- Most Jets in Cargo Hub have been disabled and the relevant ones are active permanently.

## Bryyo
- Added a short cutscene in Fuel Gel Pool showing you what the item inside the small cave is, trigger it by scanning the Big Head.
- Added missing PlayerHint scripting in Gel Cavern.
- The Ice Missile cutscene in Temple of Bryyo has been removed.

## Elysia
- Fixed still taking damage from an obstacle in Zipline Station Alpha that was thought to be removed.
- The Security Station Wall Jump Surface reveal cutscene has been removed.
- Added a reposition in Powerworks that happens when the Gears Cinematic ends.
- Added short cutscenes in several rooms that show you what the item is.
 - Arrival Station: Scan the Ledge Grab
 - Hoverplat Docking Site: Scan the Doors
 - Zipline Station Charlie: Scan the Doors
 - Powerworks: Scan the Doors
 
## Pirate Homeworld
- Added a reposition after the CSI Activation cutscene in Metroid Processing ends.
 
## Valhalla
- Added a short cutscene in Auxiliary Lift that shows you what the item is, trigger it by scanning the Panel.
- Added a reposition in front of the hand panel after inserting the Energy Cell in Docking Bay 5.


9/17/23 - Release

## Base
- A handful of cutscenes that stay in a black screen for more than a few seconds when skipped are now instant.
- Unloading a Landing Site room while the Samus Jingle is still playing no longer causes music to not play.
- All Grapple Points are now visible by default. (On a new save file, they would be invisible until you scanned them)
- Added a Death hotkey, use this in case you are softlocked and want to reload your last checkpoint. (Hold A, B, D-Pad Down inputs then Shake your Wii Remote and Nunchuk)

## Norion
 - Entering Cargo Dock A for the first time immediately opens the Landing Site on the map.
 - Fixed Pirate Invasion music playing over GF Ambiance in Cargo Dock A.
 - Fixed Landing Beacons being inactive by default in Cargo Dock A.
 - Scanning the Hand Panel in Cargo Hub will trigger a short cutscene showing you what the item is.
 
 ## Bryyo
- Fixed Morph Air tunnel softlock in Hangar Bay.
- The door leading to Field Access in Jungle Generator doesn't lock anymore.
- The Gel Cavern shortcut is now always active by default.
- The shortcut in Gel Cavern --> Imperial Hall is now Two-Way after being used for the first time.
- Fixed getting softlocked in Hall of Remembrance if you got the Screw Attack item and fell down but didn't get repositioned before the stairways cutscene started.
- The 2nd Pass Layer in Temple of Bryyo has been disabled to prevent issues with the Rundas layer and potential crashes.
- Removed IFTs in Imperial Caverns and Tower.
 
## Elysia
- The statue in Main Docking Access has been removed and replaced with an Invisible wall that is only there when you don't have Hyper Ball (You can still cross the room in reverse and reposition past it with terminal fall).
  - This was done to prevent crashing when both it and Ghor are active at the same time.
  - Additionally, the Grapple points are now always active.
- Your ship will no longer enter the Broken state after defeating Ghor.
- "Ship Priority Status Alert. Hull armor taking damage." IFT now only plays once per session.
- All Spinners are now active by default.
 - If you don't have Bombs and Boost and enter a spinner, you'll automatically get ejected after one second.
- All Zipline rooms no longer have traversal obstacles on them. (Except Charlie because those are funny)
- Improved Morph elevator scripting in Aurora Chamber.
- The elevator in Steambot Barracks now activates if coming from the opposite side.
- Xenoresearch A and B Seeker Gates can now be opened in reverse.

## Valhalla
- Removed Doors that are out of bounds in Junction A.
- Changed the Medlab Alpha Docks so that they use load triggers instead of proximity.

## Pirate Homeworld
- The Scrapvault Lift panel can now be shot when entering the room from reverse.
- The Scrapvault Lift flap can now be destroyed with Charged Nova Beam and Boost Ball.
- The Half-pipe in Scrapworks is less annoying.
- Fixed a softlock in Metroid Proccessing related to the room's locks staying on.
- Adjusted Morph Elevator Triggers in Command Station.