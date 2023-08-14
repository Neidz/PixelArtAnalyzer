namespace Tests.CommandLineHandler;

using PixelArtAnalyzer.CommandLineHandler;
using SixLabors.ImageSharp;
using Xunit;



public class CommandLineHandlerUtilsTests
{
    public class TryParseRgbaTests
    {
        [Fact]
        public void CorrectlyParsesRgba()
        {
            string validValue = "rgba(100, 150, 200, 255)";

            Rgba32 result = CommandLineHandlerUtils.TryParseRgba(validValue);

            Assert.Equal(100, result.R);
            Assert.Equal(150, result.G);
            Assert.Equal(200, result.B);
            Assert.Equal(255, result.A);
        }

        [Fact]
        public void CorrectlyParsesRgb()
        {
            string validValue = "rgb(200, 100, 200)";

            Rgba32 result = CommandLineHandlerUtils.TryParseRgba(validValue);

            Assert.Equal(200, result.R);
            Assert.Equal(100, result.G);
            Assert.Equal(200, result.B);
            Assert.Equal(255, result.A);
        }

        [Fact]
        public void FailsForHex()
        {
            string invalidValue = "#000000";

            Assert.Throws<ArgumentException>(() => CommandLineHandlerUtils.TryParseRgba(invalidValue));
        }
    }

    public class TryParseHexTests
    {
        [Fact]
        public void CorrectlyParsesHex()
        {
            string validValue = "#6496c8";

            Rgba32 result = CommandLineHandlerUtils.TryParseHex(validValue);

            Assert.Equal(100, result.R);
            Assert.Equal(150, result.G);
            Assert.Equal(200, result.B);
            Assert.Equal(255, result.A);
        }

        [Fact]
        public void FailsForRgb()
        {
            string invalidValue = "rgb(200,100,200)";

            Assert.Throws<ArgumentException>(() => CommandLineHandlerUtils.TryParseHex(invalidValue));
        }
    }
}
