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

    public enum UpdateFrequency
    {
        EveryFrame,
        EverySecond
    }

    // Settings fields defaults
    public UpdateFrequency updateFrequency = UpdateFrequency.EverySecond;
    public bool showTaskLabels = true;

    // Save and load settings
    public override void ExposeData()
    {
        base.ExposeData();

        Scribe_Values.Look(ref updateFrequency, "updateFrequency", updateFrequency);
        Scribe_Values.Look(ref showTaskLabels, "showTaskLabels", showTaskLabels);
    }
}
