using UnityEngine;
using Verse;

public class PawnTaskDisplayMod : Mod
{
    public static PawnTaskDisplaySettings settings;

    public PawnTaskDisplayMod(ModContentPack content) : base(content)
    {
        settings = PawnTaskDisplaySettings.Instance;
        GetSettings<PawnTaskDisplaySettings>();
    }

    public override void DoSettingsWindowContents(Rect settingsRect)
    {
        Listing_Standard SettingsList = new Listing_Standard();

        SettingsList.Begin(settingsRect);
        // Title/Header
        SettingsList.Label("Pawn Task Display Settings", (float)GameFont.Medium);
        SettingsList.GapLine();
        SettingsList.Gap(10);

        // Show task labels toggle
        SettingsList.CheckboxLabeled("Enable Task Display", ref settings.showTaskLabels, "Toggle to enable or disable task labels.");
        SettingsList.Gap(5);

        // Update Frequency Section
        SettingsList.CheckboxLabeled("Update Task Display Every Frame", ref settings.updateEveryFrame, "Updates labels in real time (Faster! Nicer!) instead of the default, once per second. WARNING: Can cause lag in large colonies.");
        SettingsList.Gap(5);

        SettingsList.GapLine();

        SettingsList.End();
        base.DoSettingsWindowContents(settingsRect);
    }

    public override string SettingsCategory()
    {
        return "Pawn Task Display";
    }
}
