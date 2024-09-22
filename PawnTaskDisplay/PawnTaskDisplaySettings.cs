using UnityEngine;
using Verse;


public class PawnTaskDisplaySettings: ModSettings
{
    public bool showTaskLabels = true;
    public bool updateEveryFrame = false;

    public override void ExposeData()
    {
        base.ExposeData();

        Scribe_Values.Look(ref showTaskLabels, "showTaskLabels", true);
    }
}
