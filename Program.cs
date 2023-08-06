using PixelArtAnalyzer.Image;

class Program
{
    static void Main(string[] args)
    {
        // image to look for targetImage in
        string sourceImageLocation = "Resources/SampleImages/reversedCrewmate.png";
        // image which should be found in sourceImage
        string targetImageLocation = "Resources/SampleImages/crewmate.png";

        ImageAnalyzer imageAnalyzer;
        try
        {
            imageAnalyzer = new(sourceImageLocation, targetImageLocation);
        }
        catch (Exception e)
        {
            Console.WriteLine("Failed to load images" + e.Message);
            return;
        }

        imageAnalyzer.LogDetails();
        imageAnalyzer.FindPattern();

    }
}