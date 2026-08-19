// HOW-TO: Convert ODG to PNG with Maximum Lossless Compression in C# (Aspose.Imaging for .NET)
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
            string inputPath = "sample.odg";
            string outputPath = "sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG options with maximum lossless compression
                var pngOptions = new PngOptions
                {
                    CompressionLevel = 9 // 0-9, 9 = maximum compression
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
 * 1. When a developer needs to generate web‑ready PNG thumbnails from OpenDocument graphics while keeping the smallest possible file size.
 * 2. When an application must batch‑process ODG diagrams and store them as losslessly compressed PNGs for archival without quality loss.
 * 3. When a reporting tool converts vector ODG charts into PNG images to embed in PDFs and wants maximum compression to reduce document size.
 * 4. When a cloud service receives user‑uploaded ODG files and needs to convert them to PNG for preview thumbnails with optimal storage efficiency.
 * 5. When a desktop utility automates the conversion of ODG assets to PNG for use in mobile apps, requiring the highest lossless compression to meet bandwidth constraints.
 */
