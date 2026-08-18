// HOW-TO: Resize WebP Image From Byte Array To 1024x768 Losslessly In C# (Aspose.Imaging for .NET)
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
        string inputPath = @"C:\temp\input.webp";
        string outputPath = @"C:\temp\output.webp";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the WebP image from a byte array
            byte[] imageData = File.ReadAllBytes(inputPath);
            using (MemoryStream ms = new MemoryStream(imageData))
            using (WebPImage webPImage = new WebPImage(ms))
            {
                // Resize to 1024x768 using bilinear resampling
                webPImage.Resize(1024, 768, ResizeType.BilinearResample);

                // Prepare lossless WebP save options
                WebPOptions saveOptions = new WebPOptions
                {
                    Lossless = true
                };

                // Save the resized image with lossless compression
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
 * 1. When you need to downscale a WebP photo received as a byte stream for a responsive web page while preserving exact visual quality.
 * 2. When an API returns WebP images in memory and you must resize them to a standard 1024×768 thumbnail without introducing compression artifacts.
 * 3. When processing user‑uploaded WebP files on a server, you want to store a lossless, resized version for archival or further editing.
 * 4. When generating product‑catalog images from WebP assets stored in a database, you must convert the byte data to a fixed size for consistent layout.
 * 5. When building a C# microservice that transforms raw WebP byte arrays into uniformly sized, losslessly compressed files for downstream image pipelines.
 */
