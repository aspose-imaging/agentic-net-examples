// HOW-TO: Apply Sharpen Filter to PNG Image Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

namespace AsposeImagingFilterDemo
{
    class Program
    {
        static void Main()
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\sample.png";
            string outputPath = @"C:\temp\sample.SharpenFilter.png";

            try
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image from the input path
                using (Image image = Image.Load(inputPath))
                {
                    // Cast the loaded image to RasterImage to access filtering capabilities
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply a sharpen filter with kernel size 5 and sigma 4.0 to the entire image
                    rasterImage.Filter(
                        rasterImage.Bounds,
                        new SharpenFilterOptions(5, 4.0));

                    // Save the processed image to the output path
                    rasterImage.Save(outputPath);
                }
            }
            catch (Exception ex)
            {
                // Output any unexpected errors without crashing the application
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to enhance the details of a PNG photograph before displaying it in a web gallery.
 * 2. When you want to programmatically sharpen scanned documents to improve readability in a .NET application.
 * 3. When you are building an image‑processing pipeline that requires a custom kernel size and sigma for sharpening.
 * 4. When you must ensure the output folder exists and handle missing input files gracefully while applying filters.
 * 5. When you need to integrate Aspose.Imaging’s raster filtering API into an automated batch‑processing job for multiple images.
 */
