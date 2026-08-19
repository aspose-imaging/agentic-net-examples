// HOW-TO: Convert OTG to PNG with Maximum Lossless Compression in C# (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\output\sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PNG save options with maximum compression
                var pngOptions = new PngOptions
                {
                    CompressionLevel = 9,
                    // Set up rasterization options for vector source
                    VectorRasterizationOptions = new OtgRasterizationOptions
                    {
                        PageSize = image.Size
                    }
                };

                // Save as PNG
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
 * 1. When you need to generate web‑ready PNG thumbnails from OTG vector drawings while keeping the file size as small as possible.
 * 2. When an automated build pipeline must batch‑convert OTG design assets to PNG for inclusion in a mobile app with strict bandwidth limits.
 * 3. When a reporting tool has to embed high‑quality PNG images derived from OTG files into PDF documents without increasing the PDF size.
 * 4. When a cloud service receives OTG uploads and must store them as losslessly compressed PNGs for fast retrieval and preview.
 * 5. When a desktop application allows users to export their OTG artwork to PNG with the highest compression level to save disk space on low‑capacity devices.
 */
