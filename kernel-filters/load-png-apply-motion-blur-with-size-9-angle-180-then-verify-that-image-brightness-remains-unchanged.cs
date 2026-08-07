using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    // Compute average brightness (simple average of R, G, B components) of a raster image.
    static double ComputeAverageBrightness(RasterImage img)
    {
        // Load all ARGB pixels for the whole image.
        int[] argb = img.GetDefaultArgb32Pixels(img.Bounds);
        long total = 0;
        foreach (int pixel in argb)
        {
            // Extract R, G, B components.
            int r = (pixel >> 16) & 0xFF;
            int g = (pixel >> 8) & 0xFF;
            int b = pixel & 0xFF;
            total += r + g + b;
        }
        // Each pixel contributes three components.
        double avg = (double)total / (argb.Length * 3);
        return avg;
    }

    static void Main()
    {
        // Hardcoded input and output paths.
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists.
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists.
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the PNG image.
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities.
                RasterImage raster = (RasterImage)image;

                // Compute brightness before applying the filter.
                double brightnessBefore = ComputeAverageBrightness(raster);

                // Apply motion blur (size 9, angle 180) using MotionWienerFilterOptions.
                // Length = 9, smooth = 1.0 (default), angle = 180 degrees.
                var motionOptions = new MotionWienerFilterOptions(9, 1.0, 180.0);
                raster.Filter(raster.Bounds, motionOptions);

                // Compute brightness after applying the filter.
                double brightnessAfter = ComputeAverageBrightness(raster);

                // Save the processed image.
                raster.Save(outputPath);

                // Verify that brightness remains unchanged (allow a tiny tolerance).
                const double tolerance = 0.5; // acceptable difference in brightness value.
                if (Math.Abs(brightnessBefore - brightnessAfter) <= tolerance)
                {
                    Console.WriteLine("Brightness verification passed.");
                }
                else
                {
                    Console.WriteLine($"Brightness verification failed. Before: {brightnessBefore:F2}, After: {brightnessAfter:F2}");
                }
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
 * 1. When a web application needs to add a subtle motion‑blur effect to user‑uploaded PNG avatars while confirming that the overall brightness of the image stays the same for consistent UI appearance.
 * 2. When an automated batch‑processing tool for e‑commerce product photos applies a 9‑pixel horizontal motion blur to PNG files and validates brightness to ensure the visual impact does not darken or lighten the items.
 * 3. When a scientific imaging pipeline simulates camera shake on PNG microscopy images using a 180‑degree motion blur and checks average RGB brightness to guarantee that quantitative analysis remains unaffected.
 * 4. When a game development asset pipeline adds a motion‑blur overlay to PNG texture maps and compares pre‑ and post‑filter brightness to keep lighting calculations stable.
 * 5. When a digital forensics script reproduces a motion‑blur artifact on a PNG evidence file and verifies that the blur operation does not alter the image’s overall brightness, preserving forensic integrity.
 */