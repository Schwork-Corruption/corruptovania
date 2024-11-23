# Change Log

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.5.1] - 2024-11-23

	No Changes.

## [1.5.0] - 2024-11-23

- **Major** - Added: The Data Visualiser now has a node map to help make interpreting the logic database easier.

##### Logic Database

- Fixed: Added new templates for a bunch of miscellaneous things to help out with data validation.

## [1.4.2] - 2024-10-17

- **Major** - Fixed: You can now start with Ship Grapple again, but *only* if you have MP3Update enabled in your preset/rdvgame. Game will refuse to generate otherwise.

## [1.4.1] - 2024-10-12

- **Major** - Fixed: You can now have Hazard Shield be a starting item.
- **Major** - Changed: Due to a bug in gollop's patcher, it is impossible to start with Ship Grapple. Presets that have it as a starting item will now refuse to generate, as well as all past permalinks that start with it.

## [1.4.0] - 2024-10-04

- **Major** - Added: You can now enable MrMiguel's MP3Update from a setting in your preset. Go to Game Modifications > Quality of Life to find it.
- Fixed: You should no longer get an error if you have no cached data for Corruptovania.

## [1.3.1] - 2024-10-01

- Fixed: Reverted the current build of nodtool to a previous version for exporting reasons.

## [1.3.0] - 2024-09-29

- **Major** - Added: Exporting to WBFS is now supported, enjoy playing on console!

## [1.2.9] - 2024-09-28

- Fixed: Correctly append the output format to the generated file name.
- Removed: the patcher commands will no longer be saved to your clipboard.

## [1.2.8] - 2024-09-27

- Added: You can now toggle required mains for both Missile Launcher and Ship Missiles when making a preset.
- Changed: The Play Solo Game button will now take you directly to the Corruption splash screen.
- Changed: The layout editor is now moved to the Edit tab, thus making the splash page load faster.
- Fixed: Fast Flying is now correctly implemented.
- Fixed: The external links in the export window are now functional.
- Fixed: Seed hashes will correctly update when exporting multiple games per session.

## [1.2.2] - 2024-09-24

- Fixed: The export window will now only have .iso as a valid export format.

## [1.2.1] - 2024-09-24

- Fixed: Emergency bug fix, gollop's patcher is now actually supplied.

## [1.2.0] - 2024-09-23

- **Major** - Added: gollop's patcher is now fully integrated into Corruptovania! You can now export you're games directly from the application.

#### Logic Database

##### Bryyo

- Added: The Imperial Hall can now be reached without having to pull down the grapple panels.
- Added: Destroying the Jungle Generator while only defeating the southern turret is now logical.
- Changed: Several videos have been replaced with ones with more in-depth descriptions.

##### G.F.S. Valhalla

- Removed: You no longer need Screw Attack to skip the E-Cell requirements in Stairwell

## [1.1.0] - 2024-07-17

- **Major** - Added: The auto-tracker now has a variant that uses pixel art! Brought to you by AbyssalCreature, Kunibert, and LaKompetenzia

#### Logic Database

##### Bryyo

- Fixed: The E-Cell check in Hidden Court now checks for both sides of Machineworks Bridge to be open.

##### Pirate Homeworld

- Changed: Grandrayda's logic been overhauled in an attempt to make the fight more balanced.
- Fixed: The single out-of-bounds method for circumventing the energy shield Command Courtyard now accounts for Standable Terrain (Intermediate)

##### G.F.S. Valhalla

- Fixed: There is now logic for crossing the chasm in Hangar A Access both ways without Grapple Swing and Screw Attack.

## [1.0.3] - 2024-05-31

- Fixed: Corruptovania no longer shares settings with Randovania.
- Fixed: minor bug fixes

## [1.0.2] - 2024-05-31

- Fixed: dumb crash on startup lol.

## [1.0.1] - 2024-05-31

- **Major** - Changed: Corruption is now the only game you can access from this build. To play the other games check out the [official Randovania build](https://github.com/randovania/randovania/releases/latest).
- **Major** - Added: All changes that concern Prime 3 will now be recorded here.
- Removed: The layout editor has been hidden to increase performance.
- Removed: The Multiworld tab has been hidden due to Prime 3 not being compatible.
- Changed: The welcome screen has been shortened to only mention Prime 3.

### Metroid Prime 3: Corruption

- Fixed: The progressive missile/beam text in the preset describer will now only be shown once.
- Changed: The Starter Preset now have Progressive Missiles and Progressive Beams enabled by default.

#### Logic Database

- Fixed: The trick to open the door with spring ball in Skytown, Elysia - Aurora Chamber has been removed due to no documented proof of it being possible.