namespace PixelArtAnalyzer.Image;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;


static class ImageVisualisation
{
    // Generates image that contains only pixels from matches
    public static void CreateNewImageFromMatches(Image<Rgba32> sourceImage, List<List<int[]>> matches, Rgba32 shapeColor, Rgba32 backgroundColor)
    {
        int sourceImageWidth = sourceImage.Width;
        int sourceImageHeight = sourceImage.Height;

        Image<Rgba32> newImage = new(sourceImageWidth, sourceImageHeight);

        newImage.Mutate(ctx => ctx.BackgroundColor(ImageUtils.ConvertRgbaToColor(backgroundColor)));

        foreach (List<int[]> match in matches)
        {
            foreach (int[] coordinate in match)
            {
                newImage[coordinate[0], coordinate[1]] = shapeColor;
            }
        }

        ImageFileManager.SaveImage(newImage, "BlankVisualisationWithMatches");
    }

    // Generates image where matches are replaced with chosen color
    public static void CreateImageWithMatchingPixelsColored(Image<Rgba32> sourceImage, List<List<int[]>> matches, Rgba32 color)
    {
        Image<Rgba32> newImage = sourceImage.Clone();

        foreach (List<int[]> match in matches)
        {
            foreach (int[] coordinate in match)
            {
                newImage[coordinate[0], coordinate[1]] = color;
            }
        }

        ImageFileManager.SaveImage(newImage, "VisualisationWithColoredMatches");
    }

    // Generates image with border around matches
    public static void CreateImageWithMarkedMatches(Image<Rgba32> sourceImage, List<List<int[]>> matches, Rgba32 borderColor, int borderWidth = 3)
    {
        Image<Rgba32> newImage = sourceImage.Clone();

        foreach (List<int[]> match in matches)
        {
            var corners = ImageUtils.FindWindowCornersFromCoordinates(match);
            int[] topLeftCorner = corners[0];
            int[] bottomRightCorner = corners[1];

            int windowWidth = bottomRightCorner[0] - topLeftCorner[0];
            int windowWidthWithBorder = windowWidth + (borderWidth * 2);
            int windowHeight = bottomRightCorner[1] - topLeftCorner[1];
            int windowHeightWithBorder = windowHeight + (borderWidth * 2);

            var rectangle = new Rectangle(new Point(topLeftCorner[0] - borderWidth, topLeftCorner[1] - borderWidth), new Size(windowWidthWithBorder, windowHeightWithBorder));

            var pen = Pens.Solid(borderColor, borderWidth);

            newImage.Mutate(ctx => ctx.Draw(pen, rectangle));
        }

        ImageFileManager.SaveImage(newImage, "VisualisationWithMarkedMatches");
    }
}