namespace PixelArtAnalyzer.Image;

using SixLabors.ImageSharp;

// Core class used for loading images, processing and searching for patterns
class ImageAnalyzer
{
    private readonly Image<Rgba32> _sourceImage;
    private readonly Image<Rgba32> _targetImage;

    private readonly Rgba32 _targetImageShapeColor = new(0, 0, 0, 0);
    private readonly int _tolerance = 1;

    private readonly Rgba32 _visualisationShapeColor = Color.White;
    private readonly Rgba32 _visualisationBackgroundColor = Color.Black;
    private readonly Rgba32 _visualisationBorderColor = Color.Red;

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

    public void FindPattern(bool generatePreview = false)
    {
        ImagePatternMatcher imagePatternMatcher = new();
        var matches = imagePatternMatcher.FindMatches(_sourceImage, _targetImage, _targetImageShapeColor, _tolerance);

        Console.WriteLine("Amount of found matches: " + matches.Count);

        if (generatePreview)
        {
            // ImageVisualisation.CreateNewImageFromMatches(_sourceImage, matches, _visualisationShapeColor, _visualisationBackgroundColor);
            // ImageVisualisation.CreateImageWithMarkedMatches(_sourceImage, matches, _visualisationBorderColor);
            ImageVisualisation.CreateImageWithMatchingPixelsColored(_sourceImage, matches, _visualisationBackgroundColor);

            Console.WriteLine("Generated image with preview of matches");
        }
    }
}