using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\input.webp";
        string outputPath = @"c:\temp\output_resized.webp";

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

            // Load the WebP image
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Resize to half the original dimensions using bilinear resampling
                int newWidth = webPImage.Width / 2;
                int newHeight = webPImage.Height / 2;
                webPImage.Resize(newWidth, newHeight, ResizeType.BilinearResample);

                // Save with high quality (lossy) WebP options
                var saveOptions = new WebPOptions
                {
                    Quality = 100f // maximum quality
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
 * 1. When a web developer needs to generate smaller thumbnail versions of high‑resolution WebP images for faster page loads while preserving maximum visual quality.
 * 2. When an e‑commerce platform must automatically downscale product photos in WebP format to half size before uploading them to a CDN to reduce bandwidth usage.
 * 3. When a mobile app backend processes user‑uploaded WebP avatars, resizing them to half the original dimensions and saving them with 100 % quality for consistent display across devices.
 * 4. When a digital asset management system needs to create backup copies of existing WebP files at reduced dimensions without losing lossy compression quality.
 * 5. When a content management system batch‑processes WebP graphics, applying bilinear resampling to shrink images by 50 % and storing the results with high‑quality WebP options for archival purposes.
 */