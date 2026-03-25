using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.svg";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load PNG, apply median filter, resize, and save as SVG
        using (RasterImage raster = (RasterImage)Image.Load(inputPath))
        {
            // Apply median filter with size 5
            raster.Filter(raster.Bounds, new MedianFilterOptions(5));

            // Resize to thumbnail size (e.g., 150x150)
            raster.Resize(150, 150);

            // Save as SVG
            raster.Save(outputPath, new SvgOptions());
        }
    }
}