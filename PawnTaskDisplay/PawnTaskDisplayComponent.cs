using RimWorld;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using Verse.AI;


public class PawnTaskDisplayComponent : MapComponent
{
    public PawnTaskDisplayComponent(Map map) : base(map)
    {
    }

    private Dictionary<Pawn, string> pawnJobReports = new Dictionary<Pawn, string>();
    private Dictionary<Pawn, JobDef> pawnPreviousJobs = new Dictionary<Pawn, JobDef>();

    private int accumulator = 0; // accumulates Rimworld game ticks


    public override void MapComponentTick()
    {
        base.MapComponentTick();

        if (!PawnTaskDisplayMod.settings.updateEveryFrame)
        {
            // Increment tick counter
            accumulator++;

            // Updates job reports every minute
            while (accumulator >= 60)
            {
                accumulator = 0;
                WritePawnTaskCache();
                Log.Message("[PawnTaskDisplay] updating every second.");
            }
        }
        else
        {
            Log.Message("[PawnTaskDisplay] updating every frame.");
            WritePawnTaskCache();
        }
    }

    private void WritePawnTaskCache()
    {
        if (Find.CurrentMap != map || !PawnTaskDisplayMod.settings.showTaskLabels) return;

        bool DevMode = Prefs.DevMode;

        foreach (var pawn in map.mapPawns.AllPawnsSpawned)
        {
            if (pawn.Faction != Faction.OfPlayer || !pawn.RaceProps.Humanlike) continue; // Skip non-player pawns and pets

            Job currentJob = pawn.CurJob;

            if (currentJob == null)
            {
                if (DevMode)
                {
                    Log.Message($"[PawnTaskDisplay] {pawn.Name} has no current job.");
                }

                // Remove from caches
                ClearPawnJobCaches(pawn);
                continue;
            }

            JobDef currentJobDef = currentJob.def;

            if (DevMode && currentJobDef == null)
            {
                Log.Message($"[PawnTaskDisplay] {pawn.Name} has a job, but the JobDef is null.");
                continue;
            }

            // Check if the job report needs updating
            if (!pawnJobReports.TryGetValue(pawn, out string cachedReport) ||
                !pawnPreviousJobs.TryGetValue(pawn, out JobDef previousJobDef) ||
                previousJobDef != currentJobDef)
            {
                cachedReport = FirstCharToUpper(currentJob.GetReport(pawn));

                // Update caches
                UpdatePawnJobCaches(pawn, currentJobDef, cachedReport);
            }
        }
    }

    public override void MapComponentOnGUI()
    {
        base.MapComponentOnGUI();
        if (Find.CurrentMap != map || !PawnTaskDisplayMod.settings.showTaskLabels) return;

        foreach (var pawn in map.mapPawns.AllPawnsSpawned)
        {
            if (pawn.Faction != Faction.OfPlayer || !pawn.RaceProps.Humanlike) continue; // Skip non-player pawns and pets

            // Retrieve the cached job report
            if (pawnJobReports.TryGetValue(pawn, out string cachedReport))
            {
                DrawLabelBelowPawn(pawn, cachedReport);
            }
        }
    }

    private void UpdatePawnJobCaches(Pawn pawn, JobDef currentJobDef, string cachedReport)
    {
        pawnJobReports[pawn] = cachedReport;
        pawnPreviousJobs[pawn] = currentJobDef;
    }

    private void ClearPawnJobCaches(Pawn pawn)
    {
        pawnJobReports.Remove(pawn);
        pawnPreviousJobs.Remove(pawn);
    }

    private void DrawLabelBelowPawn(Pawn pawn, string label)
    {
        Vector2 screenPosition = GenMapUI.LabelDrawPosFor(pawn, -0.6f);
        Verse.Text.Font = GameFont.Tiny;
        var labelSize = Verse.Text.CalcSize(label);

        // Position: Slightly below pawn's name TODO make this a setting
        Rect labelRect = new Rect(screenPosition.x - (labelSize.x / 2), screenPosition.y + 15, labelSize.x, labelSize.y);
        Verse.Text.Anchor = TextAnchor.UpperCenter;

        // Draw the label
        GUI.color = Color.white;
        Widgets.Label(labelRect, label);

        Verse.Text.Anchor = TextAnchor.UpperLeft; // Reset the anchor
    }

    public static string FirstCharToUpper(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        return char.ToUpper(input[0]) + input.Substring(1);
    }
}
