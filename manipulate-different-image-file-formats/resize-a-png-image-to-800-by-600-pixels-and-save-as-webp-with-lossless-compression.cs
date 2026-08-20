// HOW-TO: Resize PNG to 800x600 and Save as Lossless WebP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.webp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image pngImage = Image.Load(inputPath))
            {
                // Create a WebPImage from the loaded raster image
                using (WebPImage webpImage = new WebPImage((RasterImage)pngImage))
                {
                    // Resize to 800x600 using nearest neighbour resampling
                    webpImage.Resize(800, 600, ResizeType.NearestNeighbourResample);

                    // Save as lossless WebP
                    var webpOptions = new WebPOptions
                    {
                        Lossless = true
                    };
                    webpImage.Save(outputPath, webpOptions);
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
 * 1. When you need to generate web‑optimized thumbnails from high‑resolution PNG assets while preserving full visual fidelity using lossless WebP in a C# application.
 * 2. When a content management system must convert uploaded PNG graphics to a standardized 800×600 size and store them as compact, lossless WebP files for faster page loads.
 * 3. When an e‑commerce platform wants to resize product images to a fixed dimension and serve them in WebP format to reduce bandwidth without sacrificing image quality.
 * 4. When a desktop utility processes batches of PNG screenshots, resizing each to 800×600 and saving them as lossless WebP to save disk space while keeping exact pixel data.
 * 5. When a mobile app backend prepares user‑provided PNG avatars for display on various devices by resizing them and delivering them as lossless WebP to ensure consistent appearance across platforms.
 */
