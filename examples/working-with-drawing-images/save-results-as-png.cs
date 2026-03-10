using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string dir = @"C:\temp\";
        string inputPath = System.IO.Path.Combine(dir, "sample.bmp");
        string outputPath = System.IO.Path.Combine(dir, "output.png");

        // Load the source image (any supported format)
        using (Image image = Image.Load(inputPath))
        {
            // Create PNG save options (default settings)
            PngOptions pngOptions = new PngOptions();

            // Save the loaded image as a PNG file
            image.Save(outputPath, pngOptions);
        }
    }
}