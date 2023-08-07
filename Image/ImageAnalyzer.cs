namespace PixelArtAnalyzer.Image;

using SixLabors.ImageSharp;

// Core class used for loading images, processing and searching for patterns
class ImageAnalyzer
{
    private readonly Image<Rgba32> _sourceImage;
    private readonly Image<Rgba32> _targetImage;

    private readonly Rgba32 _targetImageShapeColor = new(0, 0, 0, 0);
    private readonly int _tolerance = 1;

    public ImageAnalyzer(string sourceImageLocation, string targetImageLocation)
    {
        try
        {
            _sourceImage = ImageFileManager.LoadImage(sourceImageLocation);
            _targetImage = Image.Load<Rgba32>(targetImageLocation);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Environment.Exit(1);
        }
    }

    public void FindPattern()
    {
        ImagePatternMatcher imagePatternMatcher = new();
        var matches = imagePatternMatcher.FindMatches(_sourceImage, _targetImage, _targetImageShapeColor, _tolerance);

        Console.WriteLine("Amount of found matches: " + matches.Count);
    }
}