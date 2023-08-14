namespace PixelArtAnalyzer.Image;

using SixLabors.ImageSharp;
using PixelArtAnalyzer.ApplicationConfiguration;

// Core class used for loading images, processing and searching for patterns
public class ImageAnalyzer
{
    private readonly Image<Rgba32> _sourceImage;
    private readonly Image<Rgba32> _targetImage;

    private readonly ApplicationConfiguration _configuration;

    public ImageAnalyzer(ApplicationConfiguration configuration)
    {
        _configuration = configuration;

        if (configuration.SourceImageLocation == null)
        {
            Console.WriteLine("Usage: Please provide the required parameter -sourceImageLocation. The program cannot continue without it.");
            Environment.Exit(1);
        }
        if (configuration.TargetImageLocation == null)
        {
            Console.WriteLine("Usage: Please provide the required parameter -targetImageLocation. The program cannot continue without it.");
            Environment.Exit(1);
        }

        try
        {
            _sourceImage = ImageFileManager.LoadImage(configuration.SourceImageLocation);
            _targetImage = ImageFileManager.LoadImage(configuration.TargetImageLocation);
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
        var matches = imagePatternMatcher.FindMatches(_sourceImage, _targetImage, _configuration.TargetImageShapeColor, _configuration.Tolerance);

        if (_configuration.LogAmountOfMatches)
        {
            Console.WriteLine("Amount of found matches: " + matches.Count);
        }


        if (_configuration.GenerateImageWithMarkedMatches)
        {
            ImageVisualization.CreateImageWithMarkedMatches(_sourceImage, matches, _configuration.VisualizationBorderColor);
        }

        if (_configuration.GenerateNewBlankImageWithMatches)
        {
            ImageVisualization.CreateNewBlankImageWithMatches(_sourceImage, matches, _configuration.VisualizationShapeColor, _configuration.VisualizationBackgroundColor);
        }

        if (_configuration.GenerateImageWithMatchingPixelsColored)
        {
            ImageVisualization.CreateImageWithMatchingPixelsColored(_sourceImage, matches, _configuration.VisualizationBackgroundColor);
        }
    }
}