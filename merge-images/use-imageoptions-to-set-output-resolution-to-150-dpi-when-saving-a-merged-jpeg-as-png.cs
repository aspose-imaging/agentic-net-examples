// HOW-TO: Save JPEG As PNG With 150 DPI Resolution Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output.png";

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

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG save options with 150 DPI resolution
                PngOptions saveOptions = new PngOptions
                {
                    ResolutionSettings = new ResolutionSetting(150.0, 150.0)
                };

                // Save the image as PNG using the configured options
                image.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert a high‑resolution JPEG photograph to a PNG file for lossless web display while preserving a specific print‑ready DPI of 150.
 * 2. When generating PNG assets for a desktop publishing workflow that requires a fixed 150 DPI resolution to ensure consistent layout across different printers.
 * 3. When processing scanned JPEG images in a batch job and saving them as PNG with a set DPI so that downstream OCR or PDF creation tools interpret the image size correctly.
 * 4. When creating thumbnails or preview images from JPEG sources where the PNG output must maintain a known DPI for accurate scaling in design software.
 * 5. When integrating Aspose.Imaging into a C# application that must export user‑uploaded JPEGs as PNGs with a defined 150 DPI to meet corporate branding guidelines.
 */
