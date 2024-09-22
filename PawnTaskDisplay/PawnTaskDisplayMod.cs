using UnityEngine;
using Verse;

public class PawnTaskDisplayMod : Mod
{
    public static PawnTaskDisplaySettings settings;

    public PawnTaskDisplayMod(ModContentPack content) : base(content)
    {
        settings = GetSettings<PawnTaskDisplaySettings>();
    }

    public override void DoSettingsWindowContents(Rect settingsRect)
    {
        Listing_Standard listingStandard = new Listing_Standard();
        listingStandard.Begin(settingsRect);

        listingStandard.CheckboxLabeled("Show Task Labels", ref settings.showTaskLabels, "Enable or disable the display of pawn task labels.");

        listingStandard.End();
        base.DoSettingsWindowContents(settingsRect);
    }

    public override string SettingsCategory()
    {
        return "Pawn Task Display";
    }
}
