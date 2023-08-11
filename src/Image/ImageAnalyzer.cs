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
            ImageVisualisation.CreateImageWithMarkedMatches(_sourceImage, matches, _configuration.VisualisationBorderColor);
        }

        if (_configuration.GenerateNewBlankImageWithMatches)
        {
            ImageVisualisation.CreateNewBlankImageWithMatches(_sourceImage, matches, _configuration.VisualisationShapeColor, _configuration.VisualisationBackgroundColor);
        }

        if (_configuration.GenerateImageWithMatchingPixelsColored)
        {
            ImageVisualisation.CreateImageWithMatchingPixelsColored(_sourceImage, matches, _configuration.VisualisationBackgroundColor);
        }
    }
}