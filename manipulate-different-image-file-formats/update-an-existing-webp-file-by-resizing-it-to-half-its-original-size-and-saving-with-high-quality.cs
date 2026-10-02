// HOW-TO: Resize WebP Image to Half Size with High Quality in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.webp";
        string outputPath = "output\\resized.webp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (WebPImage image = (WebPImage)Image.Load(inputPath))
            {
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;

                image.Resize(newWidth, newHeight, ResizeType.HighQualityResample);

                WebPOptions options = new WebPOptions
                {
                    Lossless = false,
                    Quality = 100
                };

                image.Save(outputPath, options);
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
 * 1. When you need to generate a smaller, high‑quality version of an existing WebP photo for responsive web design.
 * 2. When a mobile app must downscale user‑uploaded WebP images to reduce bandwidth while preserving visual fidelity.
 * 3. When an e‑commerce platform wants to create half‑size product thumbnails from original WebP assets without losing quality.
 * 4. When a content management system automatically resizes WebP graphics before storing them to save disk space yet keep sharpness.
 * 5. When a batch‑processing script must update legacy WebP files to a standardized size for consistent display across browsers.
 */
