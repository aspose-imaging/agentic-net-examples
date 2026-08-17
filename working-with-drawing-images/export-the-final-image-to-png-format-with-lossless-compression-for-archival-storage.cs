// HOW-TO: How To Convert JPEG To PNG With Lossless Compression In C# (Aspose.Imaging for .NET)
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
                // Configure PNG export options (lossless compression)
                PngOptions pngOptions = new PngOptions
                {
                    // Use the default compression level (lossless)
                    PngCompressionLevel = PngOptions.DefaultCompressionLevel
                };

                // Save the image as PNG
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
 * 1. When you need to archive original photographs by converting high‑resolution JPEGs to lossless PNG files using C# and Aspose.Imaging.
 * 2. When a web application must store user‑uploaded JPEG images in a format that preserves every pixel for future editing.
 * 3. When a digital asset management system requires consistent PNG assets for thumbnails while keeping the source image quality intact.
 * 4. When you want to ensure regulatory compliance by saving medical imaging scans as lossless PNGs instead of lossy JPEGs.
 * 5. When a batch processing script has to convert a folder of JPEG files to PNG with default lossless compression for long‑term storage.
 */
