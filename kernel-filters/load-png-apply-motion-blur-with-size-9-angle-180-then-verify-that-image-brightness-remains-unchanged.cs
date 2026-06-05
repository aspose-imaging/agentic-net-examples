using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.png";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for processing
                RasterImage raster = (RasterImage)image;

                // Compute average brightness before applying the filter
                double brightnessBefore = ComputeAverageBrightness(raster);

                // Apply motion blur using MotionWienerFilterOptions (size 9, sigma 1.0, angle 180)
                var motionOptions = new MotionWienerFilterOptions(9, 1.0, 180.0);
                raster.Filter(raster.Bounds, motionOptions);

                // Compute average brightness after applying the filter
                double brightnessAfter = ComputeAverageBrightness(raster);

                // Verify that brightness remains unchanged (allow a tiny tolerance)
                const double tolerance = 0.001;
                if (Math.Abs(brightnessBefore - brightnessAfter) <= tolerance)
                {
                    Console.WriteLine("Brightness unchanged after motion blur.");
                }
                else
                {
                    Console.WriteLine($"Brightness changed: before={brightnessBefore:F4}, after={brightnessAfter:F4}");
                }

                // Save the processed image
                raster.Save(outputPath);
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
        return (double)total / argbPixels.Length / 255.0; // Normalized to [0,1]
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to add a realistic motion blur effect to a PNG screenshot in a C# desktop application while ensuring the overall brightness of the image stays consistent for UI consistency.
 * 2. When an e‑commerce platform wants to generate stylized product thumbnails with a horizontal motion blur (size 9, angle 180) using Aspose.Imaging for .NET and must confirm that the brightness does not shift, preserving color accuracy.
 * 3. When a medical imaging tool processes PNG scans, applies a motion‑blur filter to simulate patient movement, and verifies that the average brightness remains unchanged to avoid diagnostic misinterpretation.
 * 4. When a game developer creates animated sprite sheets in PNG format, applies a backward motion blur for visual effect, and uses the brightness check to guarantee that lighting levels match the original assets.
 * 5. When an automated CI pipeline validates image processing scripts by loading a PNG, applying a 9‑pixel motion blur at 180°, and asserting that the computed average brightness before and after the filter is within a tiny tolerance, ensuring regression‑free image quality.
 */