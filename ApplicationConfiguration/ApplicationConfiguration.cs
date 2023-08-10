namespace PixelArtAnalyzer.ApplicationConfiguration;

class ApplicationConfiguration
{
    public string SourceImageLocation { get; set; } = "";
    public string TargetImageLocation { get; set; } = "";

    public int Tolerance { get; set; } = 1;

    public Rgba32 TargetImageShapeColor { get; set; } = Color.Black;
    public Rgba32 VisualisationShapeColor { get; set; } = Color.White;
    public Rgba32 VisualisationBackgroundColor { get; set; } = Color.Black;
    public Rgba32 VisualisationBorderColor { get; set; } = Color.Red;

    public bool LogAmountOfMatches { get; set; } = true;
    public bool GenerateNewBlankImageWithMatches { get; set; } = false;
    public bool GenerateImageWithMarkedMatches { get; set; } = false;
    public bool GenerateImageWithMatchingPixelColored { get; set; } = false;
}