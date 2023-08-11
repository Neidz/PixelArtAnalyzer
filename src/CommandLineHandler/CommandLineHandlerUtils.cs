namespace PixelArtAnalyzer.CommandLineHandler;

using System.Text.RegularExpressions;
using SixLabors.ImageSharp;

public class CommandLineHandlerUtils
{
    public static Rgba32 TryParseRgba(string value)
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
        throw new ArgumentException("Failed to parse value as rgb/rgba: " + value);
    }

    public static Rgba32 TryParseHex(string value)
    {
        try
        {
            return Rgba32.ParseHex(value);
        }
        catch
        {
            throw new ArgumentException("Failed to parse value as hex: " + value);
        }
    }

    public static Rgba32 ParseColorWithDefault(string value, string optionName, Rgba32 defaultValue)
    {
        try
        {
            if (Regex.IsMatch(value, @"^#([0-9A-Fa-f]{6}|[0-9A-Fa-f]{8})$"))
            {
                return TryParseHex(value);
            }
            if (Regex.IsMatch(value, @"^(rgb\(\s*\d{1,3}\s*,\s*\d{1,3}\s*,\s*\d{1,3}\s*\)|rgba\(\s*\d{1,3}\s*,\s*\d{1,3}\s*,\s*\d{1,3}\s*,\s*(1|0?\.\d+)\s*\))$"))
            {
                return TryParseRgba(value);
            }
            throw new ArgumentException("Value doesn't match rgb/rgba or hex: " + value);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine($"Couldn't parse provided value for {optionName}, using default: {defaultValue}");
            return defaultValue;
        }
    }
    public static bool ParseBoolWithDefault(string value, string optionName, bool defaultValue)
    {
        try
        {
            return bool.Parse(value);
        }
        catch
        {
            Console.WriteLine($"Couldn't parse provided value for {optionName}, using default: {defaultValue}");
            return defaultValue;
        }

    }

    public static int ParseIntWithDefault(string value, string optionName, int defaultValue)
    {
        try
        {
            return int.Parse(value);
        }
        catch
        {
            Console.WriteLine($"Couldn't parse provided value for {optionName}, using default: {defaultValue}");
            return defaultValue;
        }

    }
}