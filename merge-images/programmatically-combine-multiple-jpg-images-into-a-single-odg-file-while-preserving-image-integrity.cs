using System;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Input JPEG image file paths
        string[] inputFiles = new string[]
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Output ODG file path
        string outputPath = "combined.odg";

        // Create a multipage image from the JPEG files
        using (Image odgImage = Image.Create(inputFiles))
        {
            // Save the combined image as ODG
            odgImage.Save(outputPath);
        }
    }
}