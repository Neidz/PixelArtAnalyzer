namespace PixelArtAnalyzer.Image;

using SixLabors.ImageSharp;

static class ImageFileManager
{
    public static Image<Rgba32> LoadImage(string imageLocation)
    {
        try
        {
            using FileStream fileStream = File.Open(imageLocation, FileMode.Open);
            return Image.Load<Rgba32>(fileStream);
        }
        catch (Exception e)
        {
            throw new Exception("Failed to load image: " + e.Message);
        }
    }

    public static void SaveImage(Image<Rgba32> image, string fileName)
    {
        string rootPath = Environment.CurrentDirectory;
        string outputPath = Path.Combine(rootPath, "GeneratedImages", fileName);

        if (!File.Exists(outputPath))
        {
            try
            {
                image.Save(outputPath);
                return;
            }
            catch (Exception e)
            {
                throw new Exception("Failed to save image: " + e.Message);
            }
        }

        // If image with specified name already exists tries to save it adding number at the end of the name 
        for (int i = 2; i < 7; i++)
        {
            string outputPathWithNumber = Path.Combine(outputPath, i.ToString());
            if (!File.Exists(outputPathWithNumber))
            {
                try
                {
                    image.Save(outputPathWithNumber);
                    return;
                }
                catch (Exception e)
                {
                    throw new Exception("Failed to save image: " + e.Message);
                }
            }
        }
    }
}