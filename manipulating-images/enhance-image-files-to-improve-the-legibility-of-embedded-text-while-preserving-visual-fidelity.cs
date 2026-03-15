using System;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Expect input and output file paths as arguments
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <inputPath> <outputPath>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for pixel operations
            RasterImage raster = (RasterImage)image;

            // Ensure image data is cached
            if (!raster.IsCached)
                raster.CacheData();

            // Enhance legibility: auto brightness/contrast
            raster.AutoBrightnessContrast();

            // Normalize histogram to use full dynamic range
            raster.NormalizeHistogram();

            // Slightly increase contrast for clearer text
            raster.AdjustContrast(0.2f);

            // Save the enhanced image, preserving original format
            image.Save(outputPath);
        }
    }
}