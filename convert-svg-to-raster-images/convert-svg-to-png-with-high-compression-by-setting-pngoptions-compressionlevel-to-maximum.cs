using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.svg";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for SVG
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Set PNG options with maximum compression
                var pngOptions = new PngOptions
                {
                    CompressionLevel = 9,
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the rasterized PNG
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to generate web‑optimized PNG thumbnails from vector SVG assets while minimizing file size for faster page loads.
 * 2. When an e‑commerce platform must convert product illustration SVGs to high‑compression PNGs for email newsletters that have strict attachment size limits.
 * 3. When a reporting tool creates printable charts as SVG and then rasterizes them to PNG with maximum compression to store them efficiently in a database.
 * 4. When a mobile app backend processes user‑uploaded SVG icons and saves them as compressed PNGs to reduce bandwidth consumption on device downloads.
 * 5. When a CI/CD pipeline automates asset preparation by converting design‑team SVG files to PNG with Aspose.Imaging’s PngOptions.CompressionLevel set to 9 for optimal storage in a version‑controlled repository.
 */