namespace Tests.CommandLineHandler;

using PixelArtAnalyzer.Image;
using SixLabors.ImageSharp;
using Xunit;



public class ImageUtilsTests
{
    public class AreColorsEqualTests
    {
        Rgba32 color1 = new(100, 150, 200, 255);
        Rgba32 color2 = new(101, 151, 201, 255);
        Rgba32 color3 = new(105, 145, 195, 255);

        [Fact]
        public void FailsForDifferentColorsWithNoTolerance()
        {
            bool result = ImageUtils.AreColorsEqual(color1, color2, 0);

            Assert.Equal(result, false);
        }

        public void CorrectlyComparesColorsWithTolerance()
        {
            bool result1 = ImageUtils.AreColorsEqual(color1, color1, 0);
            bool result2 = ImageUtils.AreColorsEqual(color1, color2, 1);
            bool result3 = ImageUtils.AreColorsEqual(color1, color3, 5);

            Assert.Equal(result1, true);
            Assert.Equal(result2, true);
            Assert.Equal(result3, true);
        }
    }


}
