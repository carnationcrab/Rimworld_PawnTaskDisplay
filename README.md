# PawnTaskDisplay

Simply adds the pawn's current task below the pawn's name. For use in the game Rimworld, (c)Ludeon Studios.

Find it on steam [here](https://steamcommunity.com/sharedfiles/filedetails/?id=3335474906)!

![image](https://github.com/user-attachments/assets/48b5c28f-3159-4dff-8f33-7a70976a30bf)

---

## 📝 Troubleshooting the Pawn Task Display Mod

*This mod requires the Harmony Library.* 

I have included built-in logging in the mod to help you monitor and understand any bugs. The mod itself is very simple and shouldn't conflict with other mods or cause any issues. I have tested it in most places in the load order and it has worked. Put it as far down as you are able.

### 🔍 Log Messages Explained
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

### 💡 How to View the Logs
- **In-Game**: Enable Development Mode from RimWorld’s options menu. You can open the debug log console by pressing `~` (tilde) while in debug mode (enable in settings) or clicking the bug icon at the top right corner.
- **Outside the Game**: Logs are saved in RimWorld's log files. On Windows, you can find these in:
  ```
  %USERPROFILE%\AppData\LocalLow\Ludeon Studios\RimWorld by Ludeon Studios\Player.log
  ```
