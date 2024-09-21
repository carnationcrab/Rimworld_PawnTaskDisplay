using HarmonyLib;
using Verse;

[StaticConstructorOnStartup]
public static class DisplayPawnTaskMod
{
    static DisplayPawnTaskMod()
    {
        var harmony = new Harmony("com.example.rimworld.mod");
        harmony.PatchAll();
        Log.Message("[PawnTaskDisplay] Harmony patches applied successfully.");
    }
}

[HarmonyPatch(typeof(Map), "FinalizeInit")]
public static class MapPatch
{
    static void Postfix(Map __instance)
    {
        __instance.components.Add(new PawnTaskDisplayComponent(__instance));
        Log.Message("[PawnTaskDisplay] MapComponent added successfully.");
    }
}
