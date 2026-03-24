using System;
using System.IO;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input image path
        string inputPath = @"c:\temp\sample.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Apply Median filter
        ApplyFilter(
            inputPath,
            @"c:\temp\sample.MedianFilter.png",
            new MedianFilterOptions(5));

        // Apply Bilateral Smoothing filter
        ApplyFilter(
            inputPath,
            @"c:\temp\sample.BilateralSmoothingFilter.png",
            new BilateralSmoothingFilterOptions(5));

        // Apply Gaussian Blur filter
        ApplyFilter(
            inputPath,
            @"c:\temp\sample.GaussianBlurFilter.png",
            new GaussianBlurFilterOptions(5, 4.0));

        // Apply Gauss-Wiener filter
        ApplyFilter(
            inputPath,
            @"c:\temp\sample.GaussWienerFilter.png",
            new GaussWienerFilterOptions(5, 4.0));

        // Apply Motion Wiener filter
        ApplyFilter(
            inputPath,
            @"c:\temp\sample.MotionWienerFilter.png",
            new MotionWienerFilterOptions(10, 1.0, 90.0));

        // Apply Sharpen filter
        ApplyFilter(
            inputPath,
            @"c:\temp\sample.SharpenFilter.png",
            new SharpenFilterOptions(5, 4.0));
    }

    // Helper method to load image, apply filter, and save result
    static void ApplyFilter(string inputPath, string outputPath, FilterOptionsBase options)
    {
        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image, cast to RasterImage, apply filter, and save
        using (Image image = Image.Load(inputPath))
        {
            RasterImage rasterImage = (RasterImage)image;
            rasterImage.Filter(rasterImage.Bounds, options);
            rasterImage.Save(outputPath);
        }
    }
}