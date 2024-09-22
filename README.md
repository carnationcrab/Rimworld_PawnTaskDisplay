# PawnTaskDisplay

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


2. **When a pawn has no current job:**
   ```
   [PawnTaskDisplay] <Pawn Name> has no current job.
   ```
   This indicates that the pawn is idle and not assigned to any task at the moment.

3. **When a pawn has a job, but the job definition is missing:**
   ```
   [PawnTaskDisplay] <Pawn Name> has a job, but the JobDef is null.
   ```
   This is unusual but might occur if there's an issue with the job system, a mod conflict, or a bug. Let me know!

### How to View the Logs
- **In-Game**: Enable Development Mode from RimWorld’s options menu. You can open the debug log console by pressing `~` (tilde) while in debug mode or clicking the bug icon at the top right corner.
  
- **Outside the Game**: Logs are saved in RimWorld's log files. On Windows, you can find these in:
  ```
  %USERPROFILE%\AppData\LocalLow\Ludeon Studios\RimWorld by Ludeon Studios\Player.log
  ```
---

### 💡 Future To Do's
- **User Settings**: Enable user to change styling or placement of the text. Also dev settings for more robust logging.
- **Hover color**: When hovering over the job, it should go transparent so the user can see behind.
  
