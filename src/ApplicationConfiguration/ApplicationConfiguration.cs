namespace PixelArtAnalyzer.ApplicationConfiguration;

public class ApplicationConfiguration
{
    public string? SourceImageLocation { get; set; }
    public string? TargetImageLocation { get; set; }

    public int Tolerance { get; set; } = 1;

    public Rgba32 TargetImageShapeColor { get; set; } = Color.Black;
    public Rgba32 VisualizationShapeColor { get; set; } = Color.White;
    public Rgba32 VisualizationBackgroundColor { get; set; } = Color.Black;
    public Rgba32 VisualizationBorderColor { get; set; } = Color.Red;

    public bool LogAmountOfMatches { get; set; } = true;
    public bool GenerateNewBlankImageWithMatches { get; set; } = false;
    public bool GenerateImageWithMarkedMatches { get; set; } = false;
    public bool GenerateImageWithMatchingPixelsColored { get; set; } = false;
}