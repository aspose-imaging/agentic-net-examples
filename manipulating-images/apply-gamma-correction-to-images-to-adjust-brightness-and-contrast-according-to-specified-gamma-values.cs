using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output\\sample.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load image, apply gamma correction, and save as PNG
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;
            raster.AdjustGamma(2.5f); // Apply gamma correction
            raster.Save(outputPath, new PngOptions());
        }
    }
}