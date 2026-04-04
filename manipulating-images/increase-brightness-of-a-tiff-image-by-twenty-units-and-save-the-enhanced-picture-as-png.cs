using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.tif";
        string outputPath = @"C:\temp\sample_bright.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image, adjust brightness, and save as PNG
        using (Image image = Image.Load(inputPath))
        {
            // Cast to TiffImage to access AdjustBrightness
            TiffImage tiffImage = (TiffImage)image;

            // Increase brightness by 20 units (range -255 to 255)
            tiffImage.AdjustBrightness(20);

            // Save the modified image as PNG
            tiffImage.Save(outputPath, new PngOptions());
        }
    }
}