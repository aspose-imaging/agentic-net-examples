using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
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

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage raster = (RasterImage)image;

            // Apply motion blur (using MotionWienerFilterOptions as closest match)
            // Length = 2, smooth = 1.0 (default), angle = 0 degrees
            raster.Filter(raster.Bounds, new MotionWienerFilterOptions(2, 1.0, 0.0));

            // Prepare PNG save options, preserving metadata
            PngOptions pngOptions = new PngOptions
            {
                KeepMetadata = true,
                Source = new FileCreateSource(outputPath, false)
            };

            // Save the processed image as PNG
            raster.Save(outputPath, pngOptions);
        }
    }
}