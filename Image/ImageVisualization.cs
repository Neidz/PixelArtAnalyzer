namespace PixelArtAnalyzer.Image;

using SixLabors.ImageSharp;

static class ImageVisualisation
{
    public static void CreateNewImageFromMatches(Image sourceImage, List<List<int[]>> matches, Rgba32 shapeColor, Rgba32 backgroundColor)
    {
        int sourceImageWidth = sourceImage.Width;
        int sourceImageHeight = sourceImage.Height;

        Image<Rgba32> newImage = new(sourceImageWidth, sourceImageHeight);

        newImage.Mutate(ctx => ctx.BackgroundColor(ImageColorUtils.ConvertRgbaToColor(backgroundColor)));

        foreach (List<int[]> match in matches)
        {
            foreach (int[] coordinate in match)
            {
                newImage[coordinate[0], coordinate[1]] = shapeColor;
            }
        }

        ImageFileManager.SaveImage(newImage, "Test");
    }
}