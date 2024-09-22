using RimWorld;
using System;
using UnityEngine;
using Verse;
using Verse.AI;

public class PawnTaskDisplayComponent : MapComponent
{
    public PawnTaskDisplayComponent(Map map) : base(map)
    {
    }

    public override void MapComponentOnGUI()
    {
        base.MapComponentOnGUI();
        if (Find.CurrentMap != map) return;

        foreach (var pawn in map.mapPawns.AllPawnsSpawned)
        {
            if (pawn.Faction != Faction.OfPlayer || !pawn.RaceProps.Humanlike) continue; // Skip non-player pawns and pets, it was getting cluttered

            Job currentJob = pawn.CurJob;
            if (currentJob == null)
            {
                Log.Message($"[PawnTaskDisplay] {pawn.Name} has no current job.");
                continue;
            }

            if (currentJob.def == null)
            {
                Log.Message($"[PawnTaskDisplay] {pawn.Name} has a job, but the JobDef is null.");
                continue;
            }

            string reportString = FirstCharToUpper(currentJob.GetReport(pawn));

            DrawLabelBelowPawn(pawn, $"{reportString}");
        }
    }

    private void DrawLabelBelowPawn(Pawn pawn, string label)
    {
        Vector2 screenPosition = GenMapUI.LabelDrawPosFor(pawn, -0.6f);
        Verse.Text.Font = GameFont.Tiny;
        var labelSize = Verse.Text.CalcSize(label);

        // Position: Slightly below pawn's name
        Rect labelRect = new Rect(screenPosition.x - (labelSize.x / 2), screenPosition.y + 15, labelSize.x, labelSize.y);
        Verse.Text.Anchor = TextAnchor.UpperCenter;
        
        // Set the color to match the pawn name label and draw report
        Color nameColor = PawnNameColorUtility.PawnNameColorOf(pawn);
        GUI.color = nameColor;
        Widgets.Label(labelRect, label);
        GUI.color = Color.white; // Reset the color back to white, must be done to prevent the rest of the gui being changed

        Widgets.Label(labelRect, label);
        Verse.Text.Anchor = TextAnchor.UpperLeft; // Reset the anchor
    }

    public static string FirstCharToUpper(string input)
    {
        return string.Concat(input[0].ToString().ToUpper(), input.Substring(1));
    }
}
