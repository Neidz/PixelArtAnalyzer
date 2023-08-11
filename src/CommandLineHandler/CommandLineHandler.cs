namespace PixelArtAnalyzer.CommandLineHandler;

using PixelArtAnalyzer.ApplicationConfiguration;

public class CommandLineHandler
{
    public static void ParseArgsToConfig(string[] args, ApplicationConfiguration configuration)
    {
        for (int i = 0; i < args.Length; i += 2)
        {
            if (i + 1 < args.Length)
            {
                string option = args[i];
                string value = args[i + 1];

                switch (option)
                {
                    case "-sourceImageLocation":
                        configuration.SourceImageLocation = value;
                        break;
                    case "-targetImageLocation":
                        configuration.TargetImageLocation = value;
                        break;

                    case "-tolerance":
                        configuration.Tolerance = CommandLineHandlerUtils.ParseIntWithDefault(value, "-tolerance", configuration.Tolerance);
                        break;

                    case "-targetImageShapeColor":
                        configuration.TargetImageShapeColor = CommandLineHandlerUtils.ParseColorWithDefault(value, "-targetImageShapeColor", configuration.TargetImageShapeColor);
                        break;
                    case "-visualisationShapeColor":
                        configuration.VisualisationShapeColor = CommandLineHandlerUtils.ParseColorWithDefault(value, "-visualisationShapeColor", configuration.VisualisationShapeColor);
                        break;
                    case "-visualisationBackgroundColor":
                        configuration.VisualisationBackgroundColor = CommandLineHandlerUtils.ParseColorWithDefault(value, "-visualisationBackgroundColor", configuration.VisualisationBackgroundColor);
                        break;
                    case "-visualisationBorderColor":
                        configuration.VisualisationBorderColor = CommandLineHandlerUtils.ParseColorWithDefault(value, "-visualisationBorderColor", configuration.VisualisationBorderColor);
                        break;

                    case "-logAmountOfMatches":
                        configuration.LogAmountOfMatches = CommandLineHandlerUtils.ParseBoolWithDefault(value, "-logAmountOfMatches", configuration.LogAmountOfMatches);
                        break;
                    case "-generateNewBlankImageWithMatches":
                        configuration.GenerateNewBlankImageWithMatches = CommandLineHandlerUtils.ParseBoolWithDefault(value, "-generateNewBlankImageWithMatches", configuration.GenerateNewBlankImageWithMatches);
                        break;
                    case "-generateImageWithMarkedMatches":
                        configuration.GenerateImageWithMarkedMatches = CommandLineHandlerUtils.ParseBoolWithDefault(value, "-generateImageWithMarkedMatches", configuration.GenerateImageWithMarkedMatches);
                        break;
                    case "-generateImageWithMatchingPixelsColored":
                        configuration.GenerateImageWithMatchingPixelsColored = CommandLineHandlerUtils.ParseBoolWithDefault(value, "-generateImageWithMatchingPixelsColored", configuration.GenerateImageWithMatchingPixelsColored);
                        break;
                }
            }
        }
    }
}