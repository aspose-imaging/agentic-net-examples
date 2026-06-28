using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.webp";
            string outputPath = @"C:\Images\output.webp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load WebP image from a byte array
            byte[] imageBytes = File.ReadAllBytes(inputPath);
            using (var memoryStream = new MemoryStream(imageBytes))
            using (WebPImage webPImage = new WebPImage(memoryStream))
            {
                // Resize to 1024x768 using bilinear resampling
                webPImage.Resize(1024, 768, ResizeType.BilinearResample);

                // Save with lossless compression
                var saveOptions = new WebPOptions
                {
                    Lossless = true
                };
                webPImage.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to load a WebP image from a byte array, resize it to 1024 × 768, and save it with lossless compression to generate high‑quality thumbnails for a responsive web gallery.
 * 2. When an e‑commerce application must downscale product photos stored as WebP files in memory to a standard 1024 × 768 resolution while preserving lossless quality before uploading to a CDN.
 * 3. When a mobile backend processes user‑uploaded WebP screenshots, resizes them to 1024 × 768, and saves them losslessly for archival and later editing.
 * 4. When a server‑side batch job reads WebP images from a database BLOB, resizes each to 1024 × 768 using bilinear resampling, and writes the output back as lossless WebP files.
 * 5. When a content management system receives raw WebP assets via an API, converts them to a uniform 1024 × 768 size in C# and saves them with lossless compression for consistent downstream processing.
 */