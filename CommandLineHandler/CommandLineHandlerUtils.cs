namespace PixelArtAnalyzer.CommandLineHandler;

using System.Text.RegularExpressions;

class CommandLineHandlerUtils
{
    private static Rgba32 TryParseRgba(string value)
    {
        Match matchWithAlpha = Regex.Match(value, @"\((\d+),(\d+),(\d+),(\d+)\)");
        Match matchWithoutAlpha = Regex.Match(value, @"\((\d+),(\d+),(\d+)\)");

        if (matchWithAlpha.Success &&
            byte.TryParse(matchWithAlpha.Groups[1].Value, out byte r) &&
            byte.TryParse(matchWithAlpha.Groups[2].Value, out byte g) &&
            byte.TryParse(matchWithAlpha.Groups[3].Value, out byte b) &&
            byte.TryParse(matchWithAlpha.Groups[4].Value, out byte a))
        {
            return new Rgba32(r, g, b, a);
        }
        else if (matchWithoutAlpha.Success &&
                 byte.TryParse(matchWithoutAlpha.Groups[1].Value, out r) &&
                 byte.TryParse(matchWithoutAlpha.Groups[2].Value, out g) &&
                 byte.TryParse(matchWithoutAlpha.Groups[3].Value, out b))
        {
            return new Rgba32(r, g, b, 255);
        }
        throw new ArgumentException("Invalid color format: " + value);
    }
}