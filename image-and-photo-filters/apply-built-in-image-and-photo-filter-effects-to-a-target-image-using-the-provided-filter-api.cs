using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.png";

        // Output paths for different filter results
        string outputSharpenPath = @"C:\temp\output_sharpen.png";
        string outputGaussianPath = @"C:\temp\output_gaussian.png";
        string outputMedianPath = @"C:\temp\output_median.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputSharpenPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputGaussianPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputMedianPath));

        // Load the image once and reuse for each filter
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage rasterImage = (RasterImage)image;

            // ---------- Sharpen Filter ----------
            // Apply a sharpen filter with kernel size 5 and sigma 4.0
            rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));
            rasterImage.Save(outputSharpenPath);

            // Reload original image for next filter to avoid cumulative effects
            rasterImage.Dispose();
        }

        // Reload original image for Gaussian blur
        using (Image image = Image.Load(inputPath))
        {
            RasterImage rasterImage = (RasterImage)image;

            // ---------- Gaussian Blur Filter ----------
            // Apply a Gaussian blur with radius 5 and sigma 4.0
            rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));
            rasterImage.Save(outputGaussianPath);

            rasterImage.Dispose();
        }

        // Reload original image for Median filter
        using (Image image = Image.Load(inputPath))
        {
            RasterImage rasterImage = (RasterImage)image;

            // ---------- Median Filter ----------
            // Apply a median filter with rectangle size 5
            rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));
            rasterImage.Save(outputMedianPath);

            rasterImage.Dispose();
        }
    }
}