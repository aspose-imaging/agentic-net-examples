using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image and process it
        using (var image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Cast to RasterImage for pixel-level operations
            var raster = (Aspose.Imaging.RasterImage)image;

            // Cache data if not already cached
            if (!raster.IsCached)
                raster.CacheData();

            // Enhance legibility: auto brightness/contrast, slight contrast boost, brightness boost, histogram normalization
            raster.AutoBrightnessContrast();
            raster.AdjustContrast(0.2f);      // increase contrast slightly
            raster.AdjustBrightness(10);     // brighten a bit
            raster.NormalizeHistogram();     // stretch histogram for better contrast

            // Preserve original format options
            var saveOptions = image.GetOriginalOptions();

            // Save the enhanced image
            image.Save(outputPath, saveOptions);
        }
    }
}