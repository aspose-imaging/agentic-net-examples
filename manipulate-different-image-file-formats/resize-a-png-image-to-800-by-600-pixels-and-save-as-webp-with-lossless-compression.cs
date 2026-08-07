using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.png";
            string outputPath = @"C:\temp\output.webp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (PngImage pngImage = new PngImage(inputPath))
            {
                // Convert to WebP image
                using (WebPImage webpImage = new WebPImage(pngImage))
                {
                    // Resize to 800x600 using bilinear resampling
                    webpImage.Resize(800, 600, ResizeType.BilinearResample);

                    // Save as lossless WebP
                    var webpOptions = new WebPOptions { Lossless = true };
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
 * 1. When a web developer needs to generate optimized, lossless WebP thumbnails from high‑resolution PNG assets for faster page loads.
 * 2. When an e‑commerce platform must convert product PNG images to 800×600 WebP files to reduce bandwidth while preserving image quality.
 * 3. When a mobile app backend processes user‑uploaded PNG photos, resizes them to a standard 800×600 size, and stores them as lossless WebP for efficient storage.
 * 4. When a content management system automates batch conversion of PNG graphics to WebP with exact dimensions for responsive design.
 * 5. When a digital publishing workflow requires converting PNG illustrations to 800×600 lossless WebP to maintain visual fidelity across browsers.
 */