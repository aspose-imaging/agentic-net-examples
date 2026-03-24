using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the BMP image, apply a sharpen (edge detection) filter, and save the result
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;
            // Apply sharpen filter with kernel size 5 and sigma 4.0
            raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));
            raster.Save(outputPath);
        }
    }
}