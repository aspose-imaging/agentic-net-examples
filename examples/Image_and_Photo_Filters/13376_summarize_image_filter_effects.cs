using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using System.Drawing;

class Program
{
    static void Main()
    {
        string dir = "c:\\temp\\";
        string inputPath = dir + "sample.png";

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access the Filter method
            RasterImage rasterImage = (RasterImage)image;

            // Median filter - reduces noise while preserving edges
            ApplyFilter(rasterImage, new MedianFilterOptions(5), "MedianFilter", "Reduces noise while preserving edges.");

            // Bilateral smoothing filter - smooths image while keeping edge details
            ApplyFilter(rasterImage, new BilateralSmoothingFilterOptions(5), "BilateralSmoothingFilter", "Smooths image while preserving edge details.");

            // Gaussian blur filter - applies a soft blur effect
            ApplyFilter(rasterImage, new GaussianBlurFilterOptions(5, 4.0), "GaussianBlurFilter", "Applies a soft blur effect.");

            // Gauss‑Wiener filter - reduces noise using adaptive smoothing
            ApplyFilter(rasterImage, new GaussWienerFilterOptions(5, 4.0), "GaussWienerFilter", "Reduces noise with adaptive smoothing.");

            // Motion Wiener filter - reduces motion blur along a specified angle
            ApplyFilter(rasterImage, new MotionWienerFilterOptions(10, 1.0, 90.0), "MotionWienerFilter", "Reduces motion blur along the 90° direction.");

            // Sharpen filter - enhances edges and overall sharpness
            ApplyFilter(rasterImage, new SharpenFilterOptions(5, 4.0), "SharpenFilter", "Enhances edges and overall sharpness.");
        }
    }

    // Helper method to apply a filter, save the result, and output a description
    static void ApplyFilter(RasterImage image, FilterOptionsBase options, string suffix, string description)
    {
        // Apply the filter to the entire image bounds
        image.Filter(image.Bounds, options);

        // Save the filtered image
        string outputPath = $"c:\\temp\\sample.{suffix}.png";
        image.Save(outputPath, new PngOptions());

        // Write a summary of the effect to the console
        Console.WriteLine($"{suffix}: {description} Saved to {outputPath}");
    }
}