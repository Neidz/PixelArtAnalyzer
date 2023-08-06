namespace PixelArtAnalyzer.ImageProcessor;

using SixLabors.ImageSharp;

class ImageProcessor
{
    public static bool IsTheSameColor(Rgba32 pixel1, Rgba32 pixel2, int tolerance)
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

    public List<int[]> ExtractTargetRelevantPixels(Image<Rgba32> image, Rgba32 targetImageShapeColor, int tolerance)
    {
        List<int[]> relevantPixels = new();

        for (int y = 0; y < image.Height; y++)
        {
            for (int x = 0; x < image.Width; x++)
            {
                if (IsTheSameColor(image[x, y], targetImageShapeColor, tolerance))
                {
                    relevantPixels.Add(new int[] { x, y });
                }
            }
        }

        return relevantPixels;
    }
}