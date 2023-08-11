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

    public static void SaveImage(Image<Rgba32> image, string fileName, string fileExtension = ".png")
    {
        string rootPath = Environment.CurrentDirectory;

        if (!Directory.Exists(Path.Combine(rootPath, "GeneratedImages")))
        {
            try
            {
                Directory.CreateDirectory(Path.Combine(rootPath, "GeneratedImages"));
            }
            catch (Exception e)
            {
                throw new Exception("Failed to create directory GeneratedImages at the root of this project: " + e.Message);
            }
        }

        string outputPath = Path.Combine(rootPath, "GeneratedImages", fileName);
        string outputPathWithExtension = outputPath + fileExtension;

        if (!File.Exists(outputPathWithExtension))
        {
            try
            {
                image.Save(outputPathWithExtension);
                return;
            }
            catch (Exception e)
            {
                throw new Exception("Failed to save image: " + e.Message);
            }
        }

        // If image with specified name already exists tries to save it adding number at the end of the name 
        for (int i = 2; i < 50; i++)
        {
            string outputPathWithNumber = outputPath + i.ToString() + fileExtension;

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

        throw new Exception("Failed to save image. Provide different name or delete existing images with this name");
    }
}