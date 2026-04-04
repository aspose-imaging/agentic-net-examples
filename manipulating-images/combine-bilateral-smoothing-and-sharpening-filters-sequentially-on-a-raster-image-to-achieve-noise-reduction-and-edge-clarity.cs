using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input\\sample.png";
        string outputPath = "output\\result.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load image and apply filters sequentially
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Bilateral smoothing filter with kernel size 5
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.BilateralSmoothingFilterOptions(5));

            // Sharpen filter with kernel size 5 and sigma 4.0
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

            // Save the processed image as PNG
            raster.Save(outputPath, new PngOptions());
        }
    }
}