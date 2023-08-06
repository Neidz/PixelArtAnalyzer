namespace PixelArtAnalyzer.ImagePatternMatcher;

using SixLabors.ImageSharp;
using System;
using PixelArtAnalyzer.ImageColorUtils;
using PixelArtAnalyzer.ImageProcessor;

class ImagePatternMatcher
{
    // Defines named constants for pixel offsets
    private const int Left = -1;
    private const int Right = 1;
    private const int Top = -1;
    private const int Bottom = 1;
    private const int Center = 0;

    // Stores offset pointing to every pixel surrounding relative pixel at 0, 0
    private readonly int[][] _surroundingPixelOffsets = new int[][] {
    new int[] { Left, Top },
    new int[] { Center, Top },
    new int[] { Right, Top },
    new int[] { Left, Center },
    new int[] { Right, Center },
    new int[] { Left, Bottom },
    new int[] { Center, Bottom },
    new int[] { Right, Bottom }
};

    // Searches for shape present in targetImage (marked using targetImageShapeColor) in sourceImage 
    // with tolerance allowing color mismatch in every color by provided value
    public void FindMatches(Image<Rgba32> sourceImage, Image<Rgba32> targetImage, Rgba32 targetImageShapeColor, int tolerance)
    {
        var targetShapeCoordinates = ImageProcessor.ExtractTargetShapeCoordinates(targetImage, targetImageShapeColor, tolerance);

        int sourceImageWidth = sourceImage.Width;
        int sourceImageHeight = sourceImage.Height;

        int targetImageWidth = targetImage.Width;
        int targetImageHeight = targetImage.Height;

        if (targetImageWidth > sourceImageWidth || targetImageHeight > sourceImageHeight)
        {
            Console.WriteLine("Can't match, target image is bigger than source image");
        }

        // Using Sliding Window to find target shape in sourceImage 
        for (int offsetY = 0; offsetY <= sourceImageHeight - targetImageHeight; offsetY++)
        {
            for (int offsetX = 0; offsetX <= sourceImageWidth - targetImageWidth; offsetX++)
            {
                if (IsShapeInSlidingWindow(sourceImage, targetShapeCoordinates, offsetX, offsetY, tolerance))
                {
                    Console.WriteLine($"Found shape in window starting at {offsetX}, {offsetY}");
                }
            }
        }
    }

    private bool IsShapeInSlidingWindow(Image<Rgba32> sourceImage, List<int[]> targetShapeCoordinates, int offsetX, int offsetY, int tolerance)
    {
        int[] firstPixel = targetShapeCoordinates[0];

        // Color of the first relevant pixel is stored here since we are only looking for instances of pixel art where entire shape is the same color
        Rgba32 currentColor = sourceImage[firstPixel[0] + offsetX, firstPixel[1] + offsetY];

        foreach (int[] pixelCoordinates in targetShapeCoordinates)
        {
            int pixelXWithOffset = pixelCoordinates[0] + offsetX;
            int pixelYWithOffset = pixelCoordinates[1] + offsetY;

            // Check if the pixel is outside the bounds of the sourceImage
            if (pixelXWithOffset < 0 || pixelXWithOffset >= sourceImage.Width || pixelYWithOffset < 0 || pixelYWithOffset >= sourceImage.Height)
            {
                return false;
            }

            // Check if the pixel is the same color as first pixel from the shape
            if (!ImageColorUtils.AreColorsEqual(currentColor, sourceImage[pixelXWithOffset, pixelYWithOffset], tolerance))
            {
                return false;
            }

            // Checks all surrounding pixels to make sure they are different color than the color of the shape
            foreach (int[] surroundingOffset in _surroundingPixelOffsets)
            {
                int surroundingX = pixelXWithOffset + surroundingOffset[0];
                int surroundingY = pixelYWithOffset + surroundingOffset[1];

                // Check if the pixel is outside the bounds of the sourceImage
                if (surroundingX < 0 || surroundingX >= sourceImage.Width || surroundingY < 0 || surroundingY >= sourceImage.Height)
                {
                    continue;
                }

                bool isPartOfTheShape = targetShapeCoordinates.Any(coordinate => coordinate.SequenceEqual(new int[] { surroundingX - offsetX, surroundingY - offsetY })
                );

                if (!isPartOfTheShape && ImageColorUtils.AreColorsEqual(currentColor, sourceImage[surroundingX, surroundingY], tolerance))
                {
                    return false;
                }
            }
        }
        return true;
    }
}