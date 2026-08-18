// HOW-TO: Convert JPEG to WebP with Quality 75 and Alpha Support in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Wrap the whole logic in a try-catch to handle unexpected errors gracefully
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\input.jpg";
            string outputPath = @"C:\temp\output.webp";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure WebP options: lossy compression with quality 75
                var webpOptions = new WebPOptions
                {
                    Lossless = false,   // lossy compression enables alpha channel support when present
                    Quality = 75f
                };

                // Save the image as WebP using the specified options
                image.Save(outputPath, webpOptions);
            }
        }
        catch (Exception ex)
        {
            // Output any error message without crashing the program
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce page load times by converting high‑resolution JPEG photos to smaller WebP files while preserving visual quality at a 75 % compression level.
 * 2. When an e‑commerce platform wants to serve product images in WebP format with optional transparency for overlay effects, using C# and Aspose.Imaging.
 * 3. When a mobile app processes user‑uploaded JPEG pictures and must output WebP files that retain any existing alpha channel for stickers or masks.
 * 4. When a batch‑processing script must automatically generate WebP thumbnails from JPEG assets with a consistent quality setting for consistent branding.
 * 5. When a content management system integrates C# code to convert legacy JPEG assets to WebP to meet modern browser requirements without losing image fidelity.
 */
