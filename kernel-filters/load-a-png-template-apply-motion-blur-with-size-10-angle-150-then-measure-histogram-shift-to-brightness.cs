// HOW-TO: Apply Motion Blur to PNG and Measure Brightness Shift in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\template.png";
            string outputPath = @"C:\Images\output_motion_blur.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for pixel access and filtering
                RasterImage raster = (RasterImage)image;

                // Compute average brightness before applying the filter
                double avgBefore = ComputeAverageBrightness(raster);

                // Apply motion blur using MotionWienerFilterOptions (size=10, brightness=1.0, angle=150)
                raster.Filter(raster.Bounds, new MotionWienerFilterOptions(10, 1.0, 150.0));

                // Compute average brightness after applying the filter
                double avgAfter = ComputeAverageBrightness(raster);

                // Calculate histogram shift (brightness change)
                double brightnessShift = avgAfter - avgBefore;
                Console.WriteLine($"Brightness shift: {brightnessShift:F4}");

                // Save the processed image
                raster.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Helper method to compute average brightness of a raster image
    private static double ComputeAverageBrightness(RasterImage raster)
    {
        // Load all ARGB pixels for the whole image
        int[] argbPixels = raster.GetDefaultArgb32Pixels(raster.Bounds);
        long total = 0;
        foreach (int pixel in argbPixels)
        {
            // Extract RGB components
            int r = (pixel >> 16) & 0xFF;
            int g = (pixel >> 8) & 0xFF;
            int b = pixel & 0xFF;
            // Simple luminance approximation
            total += (r + g + b) / 3;
        }
        return (double)total / argbPixels.Length;
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to simulate camera shake on a PNG template and evaluate how the blur affects overall image brightness.
 * 2. When creating automated tests that compare pre‑ and post‑filter brightness levels for quality‑control pipelines.
 * 3. When generating motion‑blurred assets for games or UI mockups while tracking the histogram shift to maintain visual consistency.
 * 4. When processing scanned documents to add a realistic motion effect and measuring the resulting brightness change for OCR preprocessing.
 * 5. When building a batch image‑processing tool that applies a specific motion‑blur angle and size, then logs the brightness difference for analytics.
 */
