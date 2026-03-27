using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.odg";
        string outputPath = "output\\cropped.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to OdgImage to access ODG-specific methods
            OdgImage odgImage = (OdgImage)image;

            // Define the region to crop (x, y, width, height)
            var cropRect = new Rectangle(50, 50, 200, 200);

            // Crop the image
            odgImage.Crop(cropRect);

            // Prepare PNG save options
            var pngOptions = new PngOptions();

            // Save the cropped image as PNG
            odgImage.Save(outputPath, pngOptions);
        }
    }
}