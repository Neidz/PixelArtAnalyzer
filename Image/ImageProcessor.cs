namespace PixelArtAnalyzer.ImageProcessor;

using SixLabors.ImageSharp;
using PixelArtAnalyzer.ImageColorUtils;

class ImageProcessor
{
    // Creates list of coordinates pointing to pixels that are considered as target and will be searched for, rest of the pixels are considered to be background
    public static List<int[]> ExtractTargetShapeCoordinates(Image<Rgba32> image, Rgba32 targetImageShapeColor, int tolerance)
    {
        List<int[]> targetShapeCoordinates = new();


        for (int y = 0; y < image.Height; y++)
        {
            for (int x = 0; x < image.Width; x++)
            {
                if (ImageColorUtils.AreColorsEqual(image[x, y], targetImageShapeColor, tolerance))
                {
                    targetShapeCoordinates.Add(new int[] { x, y });
                }
            }
        }

        return targetShapeCoordinates;
    }
}