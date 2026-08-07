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
            string inputPath = @"C:\temp\input.jpg";
            string outputPath = @"C:\temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image (any supported format)
            using (Image image = Image.Load(inputPath))
            {
                // Save as PNG with default options
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
            }

            // Validate that the saved PNG can be loaded (viewable)
            if (Image.CanLoad(outputPath))
            {
                Console.WriteLine("PNG file saved successfully and is viewable.");
            }
            else
            {
                Console.Error.WriteLine("Saved PNG file could not be loaded.");
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
 * 1. When a developer needs to batch‑convert user‑uploaded JPEG photos to lossless PNG files for storage in a web application and must ensure the resulting files can be opened by standard image viewers.
 * 2. When an automated image‑processing pipeline must generate PNG thumbnails from original JPEG assets and verify that each thumbnail is not corrupted before publishing to a content delivery network.
 * 3. When a desktop utility program has to replace legacy JPEG images with PNG equivalents for compliance with a corporate branding guideline while confirming the new files are viewable in Windows Photo Viewer.
 * 4. When a background service processes scanned documents saved as JPEG, converts them to PNG for OCR preprocessing, and needs to validate that the conversion succeeded without data loss.
 * 5. When a migration script moves product catalog images from a legacy system, converts them from JPEG to PNG for better transparency support, and checks that each converted image can be loaded by the Aspose.Imaging library.
 */