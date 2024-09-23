using Verse;

public class PawnTaskDisplaySettings : ModSettings
{
    // Singleton instance
    private static PawnTaskDisplaySettings instance;
    public static PawnTaskDisplaySettings Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PawnTaskDisplaySettings();
            }
            return instance;
        }
    }

    // Settings fields defaults
    public bool showTaskLabels = true;
    public bool updateEveryFrame = false;

    // Save and load settings
    public override void ExposeData()
    {
        base.ExposeData();

        Scribe_Values.Look(ref showTaskLabels, "showTaskLabels", true);
        Scribe_Values.Look(ref updateEveryFrame, "updateEveryFrame", true);
    }
}
