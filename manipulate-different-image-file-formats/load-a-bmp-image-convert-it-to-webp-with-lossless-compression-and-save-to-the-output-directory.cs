using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output.webp";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Set lossless WebP options
                var webpOptions = new WebPOptions
                {
                    Lossless = true
                };

                // Save as WebP with lossless compression
                image.Save(outputPath, webpOptions);
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
 * 1. When a developer needs to convert legacy BMP assets to modern WebP format for faster web page loading while preserving pixel‑perfect quality using lossless compression in a C# application.
 * 2. When an image‑processing service must batch‑process user‑uploaded BMP screenshots and store them as compact lossless WebP files on a server using Aspose.Imaging for .NET.
 * 3. When a Windows desktop tool has to generate WebP thumbnails from BMP source images to reduce storage costs without sacrificing visual fidelity.
 * 4. When a migration script is required to replace BMP icons in a legacy software package with WebP equivalents to support modern browsers and mobile devices.
 * 5. When an automated build pipeline needs to validate that BMP resources exist, create missing output folders, and save them as lossless WebP files for inclusion in a cross‑platform .NET project.
 */