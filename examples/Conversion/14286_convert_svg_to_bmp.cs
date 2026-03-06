using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define input SVG and output BMP file paths
        string inputPath = "input.svg";
        string outputPath = "output.bmp";

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Create BMP save options
            using (BmpOptions bmpOptions = new BmpOptions())
            {
                // Save the image as BMP
                image.Save(outputPath, bmpOptions);
            }
        }
    }
}