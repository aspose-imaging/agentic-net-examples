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
                // Cast to RasterImage for filtering
                RasterImage rasterImage = (RasterImage)image;

                // Compute original average brightness
                double originalBrightness = ComputeAverageBrightness(rasterImage);

                // Apply motion blur using MotionWienerFilterOptions (size=10, sigma=1.0, angle=150)
                var motionOptions = new MotionWienerFilterOptions(10, 1.0, 150.0);
                rasterImage.Filter(rasterImage.Bounds, motionOptions);

                // Compute new average brightness after blur
                double newBrightness = ComputeAverageBrightness(rasterImage);

                // Calculate histogram shift (brightness change)
                double brightnessShift = newBrightness - originalBrightness;
                Console.WriteLine($"Brightness shift after motion blur: {brightnessShift:F4}");

                // Save the processed image
                rasterImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Helper method to compute average brightness of a RasterImage
    private static double ComputeAverageBrightness(RasterImage raster)
    {
        // Load all ARGB pixels
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
 * 1. When creating a visual effect for a marketing banner, a developer can load a PNG template, apply a 10‑pixel motion blur at a 150° angle with Aspose.Imaging, and verify the brightness change to ensure the blurred text remains readable.
 * 2. When preprocessing product photos for an e‑commerce site, a developer can simulate camera shake by applying motion blur to PNG images and measure the histogram shift to adjust exposure settings automatically.
 * 3. When generating animated GIF frames from a static PNG, a developer can use motion blur to create a sense of movement and compute the average brightness before and after the filter to maintain consistent lighting across frames.
 * 4. When testing a computer‑vision algorithm that must ignore motion artifacts, a developer can blur PNG test images, calculate the brightness shift, and use the result as a quantitative metric for algorithm robustness.
 * 5. When building an accessibility tool that highlights low‑contrast areas, a developer can apply motion blur to a PNG template, measure the histogram shift, and flag images where the brightness change exceeds a threshold, indicating potential readability issues.
 */