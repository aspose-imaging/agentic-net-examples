// HOW-TO: Batch Convert BMP Images to Lossless WebP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\Images\Bmp";
        string outputDirectory = @"C:\Images\Webp";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all BMP files in the input directory
            string[] bmpFiles = Directory.GetFiles(inputDirectory, "*.bmp", SearchOption.TopDirectoryOnly);

            foreach (string inputPath in bmpFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output file path with .webp extension
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".webp";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Set lossless WebP options
                    var webpOptions = new WebPOptions
                    {
                        Lossless = true
                    };

                    // Save as WebP
                    image.Save(outputPath, webpOptions);
                }
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
 * 1. When you need to shrink a folder of legacy BMP assets for faster web page loading while preserving pixel‑perfect quality.
 * 2. When preparing game textures stored as BMP for a mobile app that requires lossless WebP to reduce package size.
 * 3. When migrating an old desktop application's image library from BMP to a modern WebP format for cross‑platform compatibility.
 * 4. When automating a nightly build process that converts newly added BMP screenshots into lossless WebP for archival storage.
 * 5. When integrating Aspose.Imaging in a C# service to batch process user‑uploaded BMP files into WebP before delivering them to a CDN.
 */
