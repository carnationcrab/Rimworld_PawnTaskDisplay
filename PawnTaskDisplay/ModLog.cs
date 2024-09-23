using Verse;

public static class ModLog
{
    public static void Message(string message)
    {
        if (Prefs.DevMode)
        {
            Log.Message($"[Pawn Task Display] {message}");
        }
    }

    public static void Warning(string message)
    {
        if (Prefs.DevMode)
        {
            Log.Warning($"[Pawn Task Display] {message}");
        }
    }

    public static void Error(string message)
    {
        if (Prefs.DevMode)
        {
            Log.Error($"[Pawn Task Display] {message}");
        }
    }
}
