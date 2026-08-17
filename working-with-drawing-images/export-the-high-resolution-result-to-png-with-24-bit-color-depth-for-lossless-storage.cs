// HOW-TO: Convert JPEG to High‑Resolution 24‑Bit PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.jpg";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG options for 24‑bit (Truecolor) output
                PngOptions pngOptions = new PngOptions
                {
                    // Truecolor = 24‑bit (8 bits per channel, no alpha)
                    ColorType = Aspose.Imaging.FileFormats.Png.PngColorType.Truecolor,
                    BitDepth = 8,
                    // High resolution (e.g., 300 DPI) for high‑resolution result
                    ResolutionSettings = new ResolutionSetting(300.0, 300.0),
                    // Optional: best compression and progressive loading
                    CompressionLevel = 9,
                    Progressive = true
                };

                // Save the image as PNG with the specified options
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
 * 1. When you need to archive photographic assets as lossless PNG files while preserving the original 300 DPI resolution for printing.
 * 2. When a web application must generate high‑quality PNG thumbnails from user‑uploaded JPEGs without introducing color banding.
 * 3. When a desktop tool converts scanned JPEG documents into true‑color PNGs for archival compliance with industry standards.
 * 4. When an automated pipeline prepares images for GIS or CAD systems that require 24‑bit PNG with exact resolution settings.
 * 5. When you want to reduce JPEG file size by re‑encoding to PNG with maximum compression while keeping full color fidelity for digital catalogs.
 */
