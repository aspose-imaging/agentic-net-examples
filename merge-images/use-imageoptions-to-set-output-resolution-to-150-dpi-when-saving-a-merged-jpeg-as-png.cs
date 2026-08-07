using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output.png";

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

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG save options with 150 DPI resolution
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
 * 1. When a web application needs to convert high‑resolution JPEG photographs to PNG thumbnails while preserving a print‑ready 150 DPI resolution for consistent display across devices.
 * 2. When an e‑commerce platform merges product JPEG images and saves them as PNG files with a fixed 150 DPI setting to meet the catalog’s printing specifications.
 * 3. When a desktop utility processes scanned JPEG documents and outputs PNG files at 150 DPI so that downstream OCR tools receive images at the required resolution.
 * 4. When a mobile app generates PNG assets from user‑uploaded JPEGs and enforces a 150 DPI resolution to ensure the graphics appear sharp when printed from the app.
 * 5. When a batch‑processing script automates the conversion of archival JPEG images to PNG format with a standardized 150 DPI resolution to maintain uniform quality in a digital library.
 */