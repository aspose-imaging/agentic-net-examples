using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.webp";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (BmpImage bmpImage = new BmpImage(inputPath))
            {
                // Configure lossless WebP options
                var webpOptions = new WebPOptions
                {
                    Lossless = true
                };

                // Save the image as WebP with lossless compression
                bmpImage.Save(outputPath, webpOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert legacy BMP assets to modern WebP format for faster web page loading while preserving pixel‑perfect quality using lossless compression in a C# application.
 * 2. When a C# service processes user‑uploaded BMP screenshots and stores them as compact WebP files to reduce storage costs without sacrificing image fidelity.
 * 3. When an automated build pipeline must generate WebP thumbnails from BMP source images for responsive design, ensuring lossless output via Aspose.Imaging.
 * 4. When a desktop utility has to batch‑convert BMP icons to WebP for use in cross‑platform UI frameworks, requiring reliable file existence checks and directory creation in .NET.
 * 5. When a cloud function needs to read a BMP file from a temporary folder, apply lossless WebP compression, and save the result to another location for downstream image‑processing workflows.
 */