namespace PixelArtAnalyzer.Image;

static class ImageUtils
{
    // T
    public static bool AreColorsEqual(Rgba32 pixel1, Rgba32 pixel2, int tolerance)
    {
        int red1 = pixel1.R;
        int green1 = pixel1.G;
        int blue1 = pixel1.B;
        int alpha1 = pixel1.A;

        int red2 = pixel2.R;
        int green2 = pixel1.G;
        int blue2 = pixel1.B;
        int alpha2 = pixel1.A;

        int redDiff = Math.Abs(red1 - red2);
        int greenDiff = Math.Abs(green1 - green2);
        int blue1Diff = Math.Abs(blue1 - blue2);
        int alphaDiff = Math.Abs(alpha1 - alpha2);

        return (redDiff <= tolerance) && (greenDiff <= tolerance) && (blue1Diff <= tolerance) && (alphaDiff <= tolerance);
    }

    public static Color ConvertRgbaToColor(Rgba32 rgbaColor)
    {
        return Color.FromRgba(rgbaColor.R, rgbaColor.G, rgbaColor.B, rgbaColor.A);
    }

    // Returns coordinate of top-left pixel and bottom-right pixel from window containing coordinate list
    public static int[][] FindWindowCornersFromCoordinates(List<int[]> coordinateList)
    {
        int smallestX = int.MaxValue;
        int smallestY = int.MaxValue;

        int biggestX = int.MinValue;
        int biggestY = int.MinValue;

        foreach (int[] coordinate in coordinateList)
        {
            if (coordinate[0] < smallestX)
            {
                smallestX = coordinate[0];
            }
            if (coordinate[0] > biggestX)
            {
                biggestX = coordinate[0];
            }

            if (coordinate[1] < smallestY)
            {
                smallestY = coordinate[1];
            }
            if (coordinate[1] > biggestY)
            {
                biggestY = coordinate[1];
            }
        }

        return new int[][] { new int[] { smallestX, smallestY }, new int[] { biggestX, biggestY } };
    }
}