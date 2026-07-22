using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\temp\\source.jpg";
            string outputPath = "C:\\temp\\output.webp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure WebP options: lossy compression with quality 75
                var webpOptions = new WebPOptions
                {
                    Lossless = false,   // enable lossy (alpha channel is preserved if present)
                    Quality = 75f
                };

                // Save as WebP
                image.Save(outputPath, webpOptions);
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
 * 1. When a developer needs to reduce page load times by converting high‑resolution JPEG photos to smaller WebP files with lossy compression at quality 75 while preserving any existing alpha channel, they can use this C# Aspose.Imaging code.
 * 2. When building a .NET web service that receives user‑uploaded JPEG images and must store them as WebP for efficient bandwidth usage, this snippet shows how to load the JPEG, set WebPOptions, and save with the desired quality.
 * 3. When creating automated batch processing to prepare product catalog images for responsive design, a developer can employ this code to convert each JPEG to a WebP image with a consistent quality level of 75 and retain transparency where needed.
 * 4. When integrating image optimization into a Windows desktop application that generates thumbnails, the example demonstrates how to use Aspose.Imaging in C# to read a JPEG, apply lossy WebP compression, and output a WebP file with an alpha channel for overlay effects.
 * 5. When developing a mobile app backend that serves images in WebP format to Android devices, this code provides a straightforward way to convert source JPEG assets to WebP with a 75‑percent quality setting and optional alpha channel support.
 */