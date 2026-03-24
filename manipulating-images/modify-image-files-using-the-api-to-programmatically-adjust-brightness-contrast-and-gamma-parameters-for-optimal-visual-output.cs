using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image and adjust visual parameters
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Cast to RasterImage to access adjustment methods
            Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

            // Cache data for performance
            if (!raster.IsCached)
                raster.CacheData();

            // Adjust brightness, contrast, and gamma
            raster.AdjustBrightness(30);          // Increase brightness
            raster.AdjustContrast(0.2f);          // Increase contrast
            raster.AdjustGamma(1.1f);             // Slight gamma correction

            // Save the adjusted image
            raster.Save(outputPath);
        }
    }
}