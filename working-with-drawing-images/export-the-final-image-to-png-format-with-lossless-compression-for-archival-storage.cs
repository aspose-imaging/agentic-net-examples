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
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\input.bmp";
            string outputPath = @"C:\Images\output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG export options for lossless archival storage
                var pngOptions = new PngOptions
                {
                    // PNG is inherently lossless; setting compression level to 0 disables compression
                    // which preserves the original data without additional processing.
                    PngCompressionLevel = 0
                };

                // Save the image as PNG using the specified options
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
 * 1. When a developer needs to convert legacy BMP files to PNG with lossless compression for long‑term archival in a .NET application.
 * 2. When a C# service must generate PNG assets from scanned bitmaps while preserving exact pixel data for regulatory compliance.
 * 3. When an image‑processing pipeline requires saving intermediate bitmap results as PNG to ensure no quality loss before further analysis.
 * 4. When a desktop utility has to batch‑export user‑provided BMP images to PNG for storage on a version‑controlled repository.
 * 5. When a cloud‑based document management system must store uploaded BMP images as PNG with zero compression to maintain original fidelity.
 */