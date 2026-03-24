using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.png";
        string outputPath = @"C:\temp\sample.corrected.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Adjust contrast and brightness using RasterImage methods
            if (image is RasterImage rasterImage)
            {
                rasterImage.AdjustContrast(30f);      // Increase contrast (range -100 to 100)
                rasterImage.AdjustBrightness(20);    // Increase brightness (range -255 to 255)
            }

            // Perform automatic brightness/contrast/color normalization if supported
            if (image is RasterCachedImage cachedImage)
            {
                cachedImage.AutoBrightnessContrast(); // Enhances contrast, brightness, and color balance
            }

            // Save the processed image
            image.Save(outputPath);
        }
    }
}