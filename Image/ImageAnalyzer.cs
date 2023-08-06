namespace PixelArtAnalyzer.Image;

using SixLabors.ImageSharp;
using System;
using PixelArtAnalyzer.ImageProcessor;
using PixelArtAnalyzer.ImageDebugUtils;
using PixelArtAnalyzer.ImagePatternMatcher;

class ImageAnalyzer
{
    private readonly Image<Rgba32> _sourceImage;
    private readonly Image<Rgba32> _targetImage;
    private readonly List<int[]> _targetImageRelevantPixels;

    private readonly Rgba32 _targetImageShapeColor = new(0, 0, 0, 0);
    private readonly int _tolerance = 10;

    public ImageAnalyzer(string sourceImageLocation, string targetImageLocation)
    {
        using FileStream sourceFileStream = File.Open(sourceImageLocation, FileMode.Open);
        using FileStream targetFileStream = File.Open(targetImageLocation, FileMode.Open);
        _sourceImage = Image.Load<Rgba32>(sourceFileStream);
        _targetImage = Image.Load<Rgba32>(targetFileStream);


        ImageProcessor imageProcessor = new();
        _targetImageRelevantPixels = imageProcessor.ExtractTargetRelevantPixels(_targetImage, _targetImageShapeColor, _tolerance);
    }

    public void FindPattern()
    {
        ImagePatternMatcher imagePatternMatcher = new();
        imagePatternMatcher.FindMatches(_sourceImage, _targetImage, _targetImageRelevantPixels);
    }

    public void LogDetails()
    {
        Console.WriteLine("Target image relevant pixel coordinates");
        ImageDebugUtils debugUtils = new();
        debugUtils.LogCoordinateList(_targetImageRelevantPixels);
    }
}