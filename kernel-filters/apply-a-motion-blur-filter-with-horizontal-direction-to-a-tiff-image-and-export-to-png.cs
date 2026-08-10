// HOW-TO: Apply Horizontal Motion Blur to TIFF and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.tif";
        string outputPath = @"C:\Images\sample.MotionBlur.png";

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
            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access the Filter method
                TiffImage tiffImage = (TiffImage)image;

                // Apply a motion blur (motion Wiener) filter with horizontal direction (angle = 0)
                // Parameters: length = 10, sigma = 1.0, angle = 0 degrees
                var motionOptions = new MotionWienerFilterOptions(10, 1.0, 0.0);
                tiffImage.Filter(tiffImage.Bounds, motionOptions);

                // Save the result as PNG
                tiffImage.Save(outputPath, new PngOptions());
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
 * 1. When you need to reduce motion artifacts in scanned documents by adding a horizontal blur before converting them from TIFF to PNG for web display.
 * 2. When a batch process must transform high‑resolution TIFF photographs into PNG thumbnails with a consistent motion‑blur effect for artistic styling.
 * 3. When an automated workflow requires applying a motion‑Wiener filter to satellite TIFF imagery to simulate camera shake before archiving the result as PNG.
 * 4. When a .NET application has to preprocess medical TIFF scans with a horizontal blur to anonymize fine details and then export them as PNG for reporting.
 * 5. When you want to programmatically enhance legacy TIFF graphics with a subtle horizontal motion blur and save them as PNG files for inclusion in a cross‑platform UI.
 */
