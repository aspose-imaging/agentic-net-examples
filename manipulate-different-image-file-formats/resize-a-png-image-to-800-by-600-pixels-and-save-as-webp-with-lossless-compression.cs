// HOW-TO: Resize PNG to 800x600 and Save as Lossless WebP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output/output.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.Resize(800, 600, ResizeType.NearestNeighbourResample);

                using (WebPOptions options = new WebPOptions())
                {
                    options.Lossless = true;
                    image.Save(outputPath, options);
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
 * 1. When a web developer needs to generate smaller, lossless WebP thumbnails from original PNG assets for faster page loads.
 * 2. When an e‑commerce platform wants to convert product PNG images to a standardized 800×600 WebP format to reduce bandwidth while preserving image quality.
 * 3. When a mobile app prepares user‑uploaded PNG photos for storage by resizing them and saving them as lossless WebP to save device space.
 * 4. When a content management system batch‑processes PNG graphics to a fixed resolution and stores them in WebP for consistent delivery across browsers.
 * 5. When a game developer optimizes UI sprites by resizing PNGs and converting them to lossless WebP to improve rendering performance.
 */
