### Version 1.1.0 - 2024-09-22
#### New Features
- Added a mod setting to toggle the frequency of task label updates between "Every Frame" and "Every Second."
- Task labels now cache pawn job reports for improved performance.

#### Improvements
- Optimized task label display by caching job reports and reducing unnecessary calculations.
- Labels now display in white.
- Mod settings are now broken out into their own thing.
- Optimized Logging: Introduced a custom logger for devmode logging.

#### Bug Fixes
- Resolved a potential performance issue caused by redundant job report retrievals.

---

### Version 1.0.0 - Initial Release 24-09-20

#### Features
- Displays the current task each colonist is working on directly below their name.
- Task labels are shown for humanlike colonists only (no animals or non-player factions).
- Automatically updates the task label display every frame.
- Compatible with RimWorld versions 1.4 and 1.5.
