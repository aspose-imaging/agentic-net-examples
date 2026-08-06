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
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\source.jpg";
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
                // Configure PNG options with a balanced compression level
                var pngOptions = new PngOptions
                {
                    // CompressionLevel range is 0-9; 6 offers a good trade‑off
                    CompressionLevel = 6,
                    // Optional: enable progressive loading
                    Progressive = true
                };

                // Save the image as PNG using the configured options
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
 * 1. When a web application needs to convert user‑uploaded JPEG photos to PNG with a balanced compression level to reduce bandwidth while preserving visual quality.
 * 2. When a desktop utility processes a batch of high‑resolution images and saves them as progressive PNG files for faster incremental rendering in browsers.
 * 3. When an e‑commerce platform generates product thumbnails in PNG format and wants to control the compression level to keep file sizes small without noticeable loss.
 * 4. When a mobile app prepares images for offline storage by converting JPEGs to PNG with a specific CompressionLevel to optimize device storage usage.
 * 5. When a document management system archives scanned documents as PNG and requires consistent compression settings to maintain a predictable archive size.
 */