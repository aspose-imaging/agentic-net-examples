using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.webp";
        string outputPath = @"C:\temp\output.webp";

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

            // Load the WebP image from a byte array
            byte[] imageBytes = File.ReadAllBytes(inputPath);
            using (var memoryStream = new MemoryStream(imageBytes))
            using (var webPImage = new WebPImage(memoryStream))
            {
                // Resize to 1024 × 768 using bilinear resampling
                webPImage.Resize(1024, 768, ResizeType.BilinearResample);

                // Set lossless compression options
                var saveOptions = new WebPOptions
                {
                    Lossless = true
                };

                // Save the resized image
                webPImage.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application receives uploaded WebP images as byte streams and must generate standardized 1024 × 768 thumbnails without quality loss for display in a product gallery.
 * 2. When a mobile app syncs photos to a server, converting the raw WebP byte data into a fixed‑resolution lossless image to ensure consistent rendering across devices.
 * 3. When an e‑commerce platform needs to batch‑process vendor‑supplied WebP assets stored in a database, resizing them to 1024 × 768 and saving them losslessly for high‑resolution print catalogs.
 * 4. When a digital asset management system imports WebP files from external APIs, transforms them to a uniform size while preserving lossless compression before archiving.
 * 5. When a content delivery network (CDN) script prepares WebP images from byte arrays for on‑the‑fly resizing to 1024 × 768, ensuring lossless quality for premium users.
 */