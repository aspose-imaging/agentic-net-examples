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
            string inputPath = @"C:\temp\input.bmp";
            string outputPath = @"C:\temp\output.webp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Save as lossless WebP
                var webpOptions = new WebPOptions
                {
                    Lossless = true
                };
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
 * 2. When an image‑processing pipeline must batch‑process user‑uploaded BMP screenshots and store them as compact, lossless WebP files on a server using Aspose.Imaging for .NET.
 * 3. When a desktop utility has to ensure that generated graphics are saved in a web‑friendly format without quality loss, by loading a BMP and saving it as lossless WebP in C#.
 * 4. When a migration script has to replace BMP icons in a Windows application with smaller WebP equivalents while keeping the original appearance intact.
 * 5. When a cloud service needs to validate that an input BMP file exists, create the target directory, and then transform the image to lossless WebP for storage optimization in a .NET environment.
 */