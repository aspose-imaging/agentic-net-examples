using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

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
 * 1. A developer converting high‑resolution JPEG photographs to PNG for a print catalog needs to preserve a 150 DPI resolution using Aspose.Imaging ImageOptions in C#.
 * 2. When generating PNG assets from scanned JPEG documents for archival purposes, setting the output resolution to 150 DPI ensures consistent print quality across all files.
 * 3. An e‑commerce platform that merges product JPEG images and saves them as PNG thumbnails may require a fixed 150 DPI resolution to meet the vendor’s packaging guidelines.
 * 4. A desktop application that batch‑processes JPEG graphics for inclusion in a PDF brochure uses Aspose.Imaging to save each image as PNG with a 150 DPI setting to maintain layout fidelity.
 * 5. In a medical imaging workflow, converting diagnostic JPEG scans to lossless PNG while enforcing a 150 DPI resolution helps meet regulatory standards for image clarity.
 */