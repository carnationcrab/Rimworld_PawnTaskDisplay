using Verse;

public static class SettingsUIHelper
{
    private const float smallGap = 5f;
    private const float mediumGap = 10f;
    private const float largeGap = 20f;

    public static void SmallGap(this Listing_Standard listing)
    {
        listing.Gap(smallGap);
    }

    public static void MediumGap(this Listing_Standard listing)
    {
        listing.Gap(mediumGap);
    }

    public static void LargeGap(this Listing_Standard listing)
    {
        listing.Gap(largeGap);
    }

    public static void DrawHorizontalLineWithGaps(this Listing_Standard listing, float horizontalGap = mediumGap)
    {
        listing.Gap(horizontalGap);
        listing.GapLine();
        listing.Gap(horizontalGap);
    }
}
