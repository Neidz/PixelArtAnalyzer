using PixelArtAnalyzer.Image;

class Program
{
    static void Main(string[] args)
    {
        // Image to look for targetImage in
        string sourceImageLocation = "Resources/SampleImages/final_2023_place.png";
        // Image which should be found in sourceImage
        string targetImageLocation = "Resources/SampleImages/crewmate.png";

        ImageAnalyzer imageAnalyzer = new(sourceImageLocation, targetImageLocation);

        imageAnalyzer.FindPattern();
    }
}