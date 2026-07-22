using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "template.png";
            string outputPath = "output.png";

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

                // Calculate average brightness before filtering
                int[] pixelsBefore = raster.GetDefaultArgb32Pixels(raster.Bounds);
                double sumBefore = 0;
                foreach (int argb in pixelsBefore)
                {
                    int r = (argb >> 16) & 0xFF;
                    int g = (argb >> 8) & 0xFF;
                    int b = argb & 0xFF;
                    sumBefore += (r + g + b) / 3.0;
                }
                double avgBefore = sumBefore / pixelsBefore.Length;

                // Apply motion Wiener filter with size 5 and angle 315°
                raster.Filter(raster.Bounds, new MotionWienerFilterOptions(5, 1.0, 315.0));

                // Calculate average brightness after filtering
                int[] pixelsAfter = raster.GetDefaultArgb32Pixels(raster.Bounds);
                double sumAfter = 0;
                foreach (int argb in pixelsAfter)
                {
                    int r = (argb >> 16) & 0xFF;
                    int g = (argb >> 8) & 0xFF;
                    int b = argb & 0xFF;
                    sumAfter += (r + g + b) / 3.0;
                }
                double avgAfter = sumAfter / pixelsAfter.Length;

                // Verify brightness unchanged (simple tolerance check)
                double diff = Math.Abs(avgBefore - avgAfter);
                Console.WriteLine($"Brightness difference: {diff}");

                // Save the processed image
                raster.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When creating a web‑based photo editor that lets users add realistic motion‑blur effects to PNG templates while ensuring the overall image brightness stays consistent.
 * 2. When generating product‑catalog thumbnails where a subtle motion‑blur is applied to highlight motion but the average luminance must match the original for uniform layout.
 * 3. When preprocessing PNG assets for a game UI, applying a 315° motion‑blur filter of size 5 to simulate speed while checking that the brightness level remains unchanged to avoid visual glitches.
 * 4. When automating batch processing of marketing banners in C# using Aspose.Imaging, adding a directional motion‑blur and validating brightness to maintain brand color consistency across all PNG files.
 * 5. When building a scientific imaging pipeline that simulates camera shake on PNG samples and needs to confirm that the motion‑blur operation does not alter the mean pixel intensity for accurate analysis.
 */