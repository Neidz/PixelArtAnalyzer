namespace PixelArtAnalyzer.CommandLineHandler;

using PixelArtAnalyzer.ApplicationConfiguration;

class CommandLineHandler
{
    public static void ParseArgsToConfig(string[] args, ApplicationConfiguration configuration)
    {
        for (int i = 0; i < args.Length; i += 2)
        {
            if (i + 1 < args.Length)
            {
                string option = args[i];
                string value = args[i + 1];


            }
        }
    }
}