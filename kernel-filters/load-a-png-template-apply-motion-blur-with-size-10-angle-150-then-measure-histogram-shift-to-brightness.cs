using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\template.png";
            string outputPath = @"C:\Images\output_blur.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for pixel access and filtering
                RasterImage raster = (RasterImage)image;

                // Compute average brightness before applying the filter
                double avgBefore = ComputeAverageBrightness(raster);

                // Apply motion blur (motion wiener filter) with size 10 and angle 150 degrees
                raster.Filter(raster.Bounds, new MotionWienerFilterOptions(10, 1.0, 150.0));

                // Compute average brightness after applying the filter
                double avgAfter = ComputeAverageBrightness(raster);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the processed image
                raster.Save(outputPath);

                // Report the brightness shift
                Console.WriteLine($"Brightness shift: {avgAfter - avgBefore}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Helper method to calculate average brightness of a raster image
    private static double ComputeAverageBrightness(RasterImage raster)
    {
        long total = 0;
        int width = raster.Width;
        int height = raster.Height;
        int pixelCount = width * height;

        // Iterate over all pixels
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int argb = raster.GetArgb32Pixel(x, y);
                // Extract RGB components
                int r = (argb >> 16) & 0xFF;
                int g = (argb >> 8) & 0xFF;
                int b = argb & 0xFF;
                // Simple luminance approximation
                int brightness = (r + g + b) / 3;
                total += brightness;
            }
        }

        return (double)total / pixelCount;
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to add realistic motion blur to a PNG template for a product catalog and then quantify how the blur affects overall image brightness.
 * 2. When an automated graphics pipeline must process user‑uploaded PNG assets, apply a 10‑pixel motion‑wiener filter at a 150° angle, and verify the brightness change before saving the result.
 * 3. When a game‑development tool requires pre‑rendered background PNGs with directional blur and needs to log the histogram shift to maintain visual consistency across scenes.
 * 4. When a medical‑imaging application wants to simulate motion artifacts on PNG scans and measure the average brightness difference for quality‑control reporting.
 * 5. When a web‑service generates promotional banners by loading a PNG template, applying motion blur, and comparing before‑and‑after brightness to adjust downstream color‑grading algorithms.
 */