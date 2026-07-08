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
        string inputPath = @"c:\temp\sample.tif";
        string outputPath = @"c:\temp\sample.motionblur.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access Filter method
                TiffImage tiffImage = (TiffImage)image;

                // Apply a horizontal motion blur (angle = 0 degrees)
                // Parameters: length = 10, sigma = 1.0, angle = 0.0
                tiffImage.Filter(
                    tiffImage.Bounds,
                    new MotionWienerFilterOptions(10, 1.0, 0.0));

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
 * 1. When a developer needs to reduce motion artifacts in a scanned document stored as a TIFF and deliver a web‑ready PNG with a horizontal motion blur applied.
 * 2. When an imaging pipeline must convert high‑resolution TIFF photographs to PNG while applying a 10‑pixel horizontal motion blur to simulate camera shake for visual effects.
 * 3. When a batch process requires loading a multi‑page TIFF, applying a motion‑blur filter with angle 0° to each page, and saving the result as a single PNG for thumbnail generation.
 * 4. When a .NET application has to validate that a TIFF file exists, apply a horizontal motion blur using MotionWienerFilterOptions, and export the processed image to PNG for further analysis.
 * 5. When a developer wants to programmatically ensure the output directory exists, apply a motion blur filter to a TIFF image, and save the filtered image as PNG for inclusion in a PDF report.
 */