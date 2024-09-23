# PawnTaskDisplay v1.1.0 ([View Changelog](https://github.com/carnationcrab/Rimworld_PawnTaskDisplay/blob/master/Changelog.md))

Adds the pawn's current task below the pawn's name. For use in the game Rimworld, (c)Ludeon Studios.

Find this mod on steam [here](https://steamcommunity.com/sharedfiles/filedetails/?id=3335474906)!

![image](https://github.com/user-attachments/assets/48b5c28f-3159-4dff-8f33-7a70976a30bf)

---

## How It Works
*Requires the Harmony Library.* 

This mod leverages RimWorld's Verse framework to display the current tasks of your colonists directly below their names. Here's a breakdown of how I achieve this:

1. **MapComponent:**
The mod defines a custom Verse `MapComponent` (`PawnTaskDisplayComponent`), which runs continuously as part of the game’s logic. This allows the mod to monitor and update each colonist's task in real-time.

2. **Drawing Labels with Verse:**
Using Verse’s `Widgets.Label()` method, the mod draws the task label below each pawn’s name. This ensures that the text is displayed in a way that's consistent with RimWorld's existing UI elements which also use Verse.

4. **Accessing Current Jobs:**
The mod accesses each pawn’s current job using the `CurJob` property provided by the RimWorld API. This information is processed and converted into a human-readable format using RimWorld’s built-in `GetReport()` method, ensuring that job descriptions are accurate and localized based on the player’s language settings. The first letter of the job is capitalized before being added to the screen.

**Performance:**
The mod is designed to update the task labels only when necessary. It skips over animals and non-player factions to avoid clutter and reduce unnecessary processing.

---

## Settings

The mod includes a settings menu accessible from the RimWorld Mod Settings screen. Here's a breakdown of the available options:

**Enable Task Display:** This checkbox lets you toggle the display of task labels below pawns' names. If unchecked, the mod will be inactive, and no task labels will be displayed on your pawns.

**Update Task Display Every Frame:** This checkbox lets you to control how often the pawn task labels are updated. **If checked**, Task labels are updated every game frame. This provides the most real-time updates but may have a slight performance impact, especially in larger colonies. **If unchecked**, Task labels are updated once per second. This option is more performance-friendly and is ideal for players who want to minimize the mod's impact on game performance.

These settings can be accessed at any time from the game's main menu or in-game by navigating to `Options > Mod Settings > Pawn Task Display`. Adjust them according to your preferences and performance needs!

![image](https://github.com/user-attachments/assets/d12e9ec1-1ef3-4ce7-9f60-3b2a9dd3a855)


---

## Troubleshooting the Pawn Task Display Mod

I have included built-in logging in the mod to help you monitor and understand any bugs. The mod itself is very simple and shouldn't conflict with other mods or cause any issues. I have tested it in most places in the load order and it has worked. Put it as far down as you are able.

### Log Messages Explained
Here’s a breakdown of all the different log messages you might encounter:

1. **Startup Logs:**
   When you start playing, you should see two logs from Pawn Task Display:
   ```
   [PawnTaskDisplay] Harmony patches applied successfully.
   ```
   AND
   ```
   [PawnTaskDisplay] MapComponent added successfully.
   ```
   These indicate all components of the mod are working properly. If the first log is not present, there is likely an issue with the mod's access to the Harmony library.


2. **Pawn Error Logs**:
   ```
   [PawnTaskDisplay] <Pawn Name> has no current job.
   ```
   This indicates that the pawn is idle and not assigned to any task at the moment.

   ```
   [PawnTaskDisplay] <Pawn Name> has a job, but the JobDef is null.
   ```
   This is unusual but might occur if there's an issue with the job system, a mod conflict, or a bug. Let me know!

1. **Update Logs:**
   The default is updating once per second:
   ```
   [PawnTaskDisplay] Updating every second.
   ```
   But if you have Every Frame checked in settings, it should log:
   ```
   [PawnTaskDisplay] Updating every frame.
   ```
   
### How to View the Logs
- **In-Game**: Enable Development Mode from RimWorld’s options menu. Then, you can open the debug log console by pressing `~` (tilde) while in debug mode or clicking the bug icon at the top right corner.
  
- **Outside the Game**: Logs are saved in RimWorld's log files. On Windows, you can find these in:
  ```
  %USERPROFILE%\AppData\LocalLow\Ludeon Studios\RimWorld by Ludeon Studios\Player.log
  ```
---

### 💡 Future To Do's
- **User Settings**: Enable user to change styling or placement of the text. Also dev settings for more robust logging.
- **Hover color**: When hovering over the job, it should go transparent so the user can see behind.
  
