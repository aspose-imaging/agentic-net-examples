using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.png";
        string outputPath = @"C:\temp\sample.AdjustBrightness.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image, adjust brightness, and save
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access AdjustBrightness
            RasterImage rasterImage = (RasterImage)image;

            // Adjust brightness (range -255 to 255)
            rasterImage.AdjustBrightness(50);

            // Save the modified image
            rasterImage.Save(outputPath);
        }
    }
}