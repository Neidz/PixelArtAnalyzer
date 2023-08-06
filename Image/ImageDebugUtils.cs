namespace PixelArtAnalyzer.ImageDebugUtils;

using System;

class ImageDebugUtils
{
    public void LogCoordinateList(List<int[]> coordinateList)
    {
        for (int i = 0; i < coordinateList.Count; i++)
        {
            int[] pixelArray = coordinateList[i];
            Console.WriteLine($"Array {i}: [{pixelArray[0]}, {pixelArray[1]}]");
        }
    }
}