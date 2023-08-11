namespace Tests.CommandLineHandler;

using PixelArtAnalyzer.CommandLineHandler;
using SixLabors.ImageSharp;
using Xunit;



public class CommandLineHandlerUtilsTests
{
    [Fact]
    public void CorrectlyParsesRgba()
    {
        string validRgbaValue = "rgba(100,150,200,255)";

        Rgba32 result = CommandLineHandlerUtils.TryParseRgba(validRgbaValue);

        Assert.Equal(100, result.R);
        Assert.Equal(150, result.G);
        Assert.Equal(200, result.B);
        Assert.Equal(255, result.A);
    }

    [Fact]
    public void CorrectlyParsesRgb()
    {
        string validRgbaValue = "rgb(200,100,200)";

        Rgba32 result = CommandLineHandlerUtils.TryParseRgba(validRgbaValue);

        Assert.Equal(200, result.R);
        Assert.Equal(100, result.G);
        Assert.Equal(200, result.B);
        Assert.Equal(255, result.A);
    }

    [Fact]
    public void TryParseRgbaFailsOnHex()
    {
        string invalidValue = "#000000";

        Assert.Throws<ArgumentException>(() => CommandLineHandlerUtils.TryParseRgba(invalidValue));
    }
}
