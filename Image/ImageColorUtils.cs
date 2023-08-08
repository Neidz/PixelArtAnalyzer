namespace PixelArtAnalyzer.Image;

static class ImageColorUtils
{
    // T
    public static bool AreColorsEqual(Rgba32 pixel1, Rgba32 pixel2, int tolerance)
    {
        int red1 = pixel1.R;
        int green1 = pixel1.G;
        int blue1 = pixel1.B;

        int red2 = pixel2.R;
        int green2 = pixel1.G;
        int blue2 = pixel1.B;

        int redDiff = Math.Abs(red1 - red2);
        int greenDiff = Math.Abs(green1 - green2);
        int blue1Diff = Math.Abs(blue1 - blue2);

        return (redDiff <= tolerance) && (greenDiff <= tolerance) && (blue1Diff <= tolerance);
    }

    public static Color ConvertRgbaToColor(Rgba32 rgbaColor)
    {
        return Color.FromRgba(rgbaColor.R, rgbaColor.G, rgbaColor.B, rgbaColor.A);
    }

}