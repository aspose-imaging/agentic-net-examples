using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.png";
        string outputPath = @"c:\temp\sample.filtered.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Apply the filter pipeline
        ApplyFilters(inputPath, outputPath);
    }

    // Reusable pipeline: bilateral smoothing → sharpen → median filter
    static void ApplyFilters(string inputPath, string outputPath)
    {
        using (Image image = Image.Load(inputPath))
        {
            var rasterImage = (RasterImage)image;

            // Bilateral smoothing with kernel size 5
            rasterImage.Filter(rasterImage.Bounds, new BilateralSmoothingFilterOptions(5));

            // Sharpen filter with kernel size 5 and sigma 4.0
            rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

            // Median filter with size 5
            rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

            // Save the processed image
            rasterImage.Save(outputPath);
        }
    }
}