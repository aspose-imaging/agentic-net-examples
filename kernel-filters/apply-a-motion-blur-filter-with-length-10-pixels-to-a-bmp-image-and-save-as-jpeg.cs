// HOW-TO: Apply 10‑Pixel Motion Blur to BMP and Save as JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.jpg";

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

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Apply a motion blur filter with length 10 pixels, smooth factor 1.0, angle 90 degrees
                rasterImage.Filter(rasterImage.Bounds, new MotionWienerFilterOptions(10, 1.0, 90.0));

                // Save the result as JPEG
                rasterImage.Save(outputPath, new JpegOptions());
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
 * 1. When you need to add a realistic motion‑blur effect to a scanned BMP diagram before delivering it as a compressed JPEG to a web client.
 * 2. When converting legacy BMP assets from a desktop application into JPEG thumbnails while applying a 10‑pixel vertical blur to hide sensitive details.
 * 3. When preprocessing product photos stored as BMP files by adding motion blur to simulate movement and then saving them as JPEG for faster page loads.
 * 4. When automating a batch job that reads BMP screenshots, applies a consistent motion‑blur filter, and outputs JPEG files for archival storage.
 * 5. When integrating Aspose.Imaging in a C# service that must transform BMP images with a specific blur length into JPEG format for email attachments.
 */
