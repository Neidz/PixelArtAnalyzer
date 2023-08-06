namespace PixelArtAnalyzer.ImagePatternMatcher;

using SixLabors.ImageSharp;
using System;

class ImagePatternMatcher
{
    public void FindMatches(Image sourceImage, Image targetImage, List<int[]> targetImageRelevantPixels)
    {
        int sourceImageWidth = sourceImage.Width;
        int sourceImageHeight = sourceImage.Height;

        int targetImageWidth = targetImage.Width;
        int targetImageHeight = targetImage.Height;

        if (targetImageWidth > sourceImageWidth || targetImageHeight > sourceImageHeight)
        {
            Console.WriteLine("Can't match, target image is bigger than source image");
        }
    }


}