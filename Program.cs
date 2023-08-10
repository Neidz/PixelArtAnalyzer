using PixelArtAnalyzer.Image;
using PixelArtAnalyzer.ApplicationConfiguration;
using PixelArtAnalyzer.CommandLineHandler;

class Program
{
    static void Main(string[] args)
    {
        // Image to look for targetImage in
        string sourceImageLocation = "Resources/SampleImages/final_2023_place.png";
        // Image which should be found in sourceImage
        string targetImageLocation = "Resources/SampleImages/crewmate.png";

        ApplicationConfiguration configuration = new()
        {
            TargetImageLocation = targetImageLocation,
            SourceImageLocation = sourceImageLocation
        };

        CommandLineHandler.ParseArgsToConfig(args, configuration);

        ImageAnalyzer imageAnalyzer = new(configuration);
        imageAnalyzer.FindPattern();
    }
}