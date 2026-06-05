using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

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

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PNG save options with 150 DPI resolution
                PngOptions saveOptions = new PngOptions
                {
                    ResolutionSettings = new ResolutionSetting(150.0, 150.0)
                };

                // Save as PNG with the specified options
                image.Save(outputPath, saveOptions);
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
 * 1. When a C# application must convert high‑resolution JPEG photographs to lossless PNG files for print‑ready PDFs while preserving a specific 150 DPI resolution using Aspose.Imaging.
 * 2. When a web service needs to generate PNG thumbnails from uploaded JPEG images and enforce a uniform 150 DPI setting to ensure consistent sizing across different browsers.
 * 3. When an automated batch job processes scanned JPEG documents, merges them, and saves the result as PNG with a 150 DPI resolution to meet archival standards.
 * 4. When a desktop utility must re‑encode JPEG assets to PNG for UI assets while controlling the output DPI to match design specifications in a C# project.
 * 5. When a reporting tool creates PNG charts from JPEG sources and requires the images to have a fixed 150 DPI resolution for accurate scaling in printed reports.
 */