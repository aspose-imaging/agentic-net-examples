// HOW-TO: Convert Multi‑Page TIFF to Animated WebP with Low Memory in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.tif";
            string outputPath = @"C:\temp\output.webp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multi‑page TIFF
            using (Image image = Image.Load(inputPath))
            {
                // If the image supports page exporting, release each page after it is saved
                if (image is RasterCachedMultipageImage multiPageImage)
                {
                    multiPageImage.PageExportingAction = (index, page) =>
                    {
                        // Force garbage collection to free page resources
                        GC.Collect();
                    };
                }

                // Configure WebP export (all pages become animated frames)
                var webpOptions = new WebPOptions
                {
                    MultiPageOptions = null, // export all pages
                    Lossless = false,
                    Quality = 80
                };

                // Save as a single WebP file
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
 * 1. When you need to transform a large multi‑page scanned document (TIFF) into a single animated WebP for faster web delivery while keeping server memory usage low.
 * 2. When a cloud‑based image service must batch‑process high‑resolution TIFF archives into WebP without loading all pages into memory at once.
 * 3. When a mobile app requires converting multi‑frame TIFF medical images into an animated WebP thumbnail to reduce file size and improve loading speed.
 * 4. When an e‑commerce platform wants to display product manuals stored as TIFFs as lightweight animated WebP previews without exhausting RAM.
 * 5. When a digital archiving workflow needs to generate a single WebP animation from multi‑page TIFFs while ensuring each page is released promptly to avoid memory leaks.
 */
