using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths (provide via command line or use defaults)
        string inputPath = args.Length > 0 ? args[0] : "input.png";
        string outputPath = args.Length > 1 ? args[1] : "output.png";

        // Load the image (any supported format) and cast to RasterImage for raster operations
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Cache pixel data for faster subsequent processing
            if (!raster.IsCached)
                raster.CacheData();

            // Example raster manipulation can be performed here, e.g., raster.Grayscale();

            // Save the raster image (preserves original format unless further options are applied)
            raster.Save(outputPath);
        }
    }
}