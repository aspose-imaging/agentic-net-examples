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
            string inputPath = "C:\\temp\\input.png";
            string outputPath = "C:\\temp\\output.webp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Resize to 800x600 pixels
                image.Resize(800, 600, ResizeType.NearestNeighbourResample);

                // Save as WebP with lossless compression
                var webpOptions = new WebPOptions { Lossless = true };
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
 * 1. When a web developer needs to generate optimized, lossless WebP thumbnails from user‑uploaded PNG graphics for faster page loads.
 * 2. When an e‑commerce platform must convert product PNG images to a standard 800 × 600 size and store them as WebP to reduce bandwidth while preserving image quality.
 * 3. When a mobile app backend processes PNG assets and creates lossless WebP versions at 800 × 600 pixels for consistent display across devices.
 * 4. When a content management system automates batch conversion of PNG banners to a fixed 800 × 600 resolution and saves them as WebP to support modern browsers.
 * 5. When a digital publishing workflow requires resizing PNG illustrations to 800 × 600 and exporting them as lossless WebP files using C# and Aspose.Imaging for archival purposes.
 */