using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
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
                RasterImage raster = (RasterImage)image;

                // Compute average brightness before applying the filter
                double avgBefore = ComputeAverageBrightness(raster);

                // Apply motion blur (size = 10, sigma = 1.0, angle = 150 degrees)
                var motionOptions = new MotionWienerFilterOptions(10, 1.0, 150.0);
                raster.Filter(raster.Bounds, motionOptions);

                // Compute average brightness after the filter
                double avgAfter = ComputeAverageBrightness(raster);
                double brightnessShift = avgAfter - avgBefore;
                Console.WriteLine($"Brightness shift after motion blur: {brightnessShift:F2}");

                // Save the processed image
                raster.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Helper method to calculate average brightness of a raster image
    static double ComputeAverageBrightness(RasterImage raster)
    {
        // Load all ARGB pixels within the image bounds
        int[] pixels = raster.GetDefaultArgb32Pixels(raster.Bounds);
        long totalBrightness = 0;

        foreach (int argb in pixels)
        {
            // Extract R, G, B components
            int r = (argb >> 16) & 0xFF;
            int g = (argb >> 8) & 0xFF;
            int b = argb & 0xFF;

            // Simple luminance approximation (average of R, G, B)
            totalBrightness += (r + g + b) / 3;
        }

        return (double)totalBrightness / pixels.Length;
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to generate a motion‑blurred preview of a PNG product template for an e‑commerce site and verify that the blur does not unintentionally darken the image, they can use this code to apply a 150° motion blur of size 10 and measure the brightness shift.
 * 2. When building an automated quality‑control pipeline that checks whether a PNG watermark remains visible after simulating camera shake, the code can apply a motion blur filter and compare average brightness before and after to ensure compliance.
 * 3. When creating a visual‑effects tool that lets users preview motion blur on PNG assets and instantly see how the overall luminance changes, developers can employ this snippet to compute the histogram‑based brightness shift for real‑time feedback.
 * 4. When preparing training data for a machine‑learning model that classifies blurred versus sharp PNG images, the code can programmatically blur each template with a 150° motion blur and record the brightness change as a feature.
 * 5. When integrating Aspose.Imaging into a C# desktop application that generates animated GIF frames from a static PNG template, the developer can first apply a motion blur with size 10 and angle 150 and then use the measured brightness shift to adjust subsequent frames for consistent exposure.
 */