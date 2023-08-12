using PixelArtAnalyzer.Image;
using PixelArtAnalyzer.ApplicationConfiguration;
using PixelArtAnalyzer.CommandLineHandler;

class Program
{
    static void Main(string[] args)
    {
        ApplicationConfiguration configuration = new();

        CommandLineHandler.ParseArgsToConfig(args, configuration);

        ImageAnalyzer imageAnalyzer = new(configuration);
        imageAnalyzer.FindPattern();
    }
}