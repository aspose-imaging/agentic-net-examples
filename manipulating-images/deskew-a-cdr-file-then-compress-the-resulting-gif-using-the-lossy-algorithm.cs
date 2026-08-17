// HOW-TO: Deskew CDR Image and Save as Lossy GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.cdr";
            string outputPath = "output\\deskewed.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (Image image = Image.Load(inputPath))
            {
                // Deskew the image by normalizing its angle
                if (image is RasterImage rasterImage)
                {
                    rasterImage.NormalizeAngle();
                }

                // Prepare GIF save options with reduced color resolution (lossy compression)
                var gifOptions = new GifOptions
                {
                    ColorResolution = 8 // reduces the number of colors, resulting in lossy compression
                };

                // Save the processed image as a GIF
                image.Save(outputPath, gifOptions);
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
 * 1. When you need to automatically straighten scanned CorelDRAW (CDR) drawings before publishing them as small GIF files for web pages.
 * 2. When a batch process must convert legacy CDR assets into GIFs with reduced color depth to meet email attachment size limits.
 * 3. When an application has to correct skewed vector artwork from a CDR source and store it in a lossy GIF format for faster loading on mobile devices.
 * 4. When you want to integrate Aspose.Imaging into a C# service that prepares CDR diagrams for documentation by deskewing and applying lossy compression.
 * 5. When a workflow requires extracting a CDR page, normalizing its orientation, and saving it as a low‑size GIF for archival or thumbnail generation.
 */
