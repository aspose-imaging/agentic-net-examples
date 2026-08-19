// HOW-TO: Convert ODG to BMP with 150 DPI Resolution in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.odg";
            string outputPath = @"C:\Images\sample_converted.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image odgImage = Image.Load(inputPath))
            {
                // Save as BMP using BmpOptions
                BmpOptions bmpOptions = new BmpOptions();
                odgImage.Save(outputPath, bmpOptions);
            }

            // Load the newly saved BMP to set custom resolution
            using (BmpImage bmpImage = (BmpImage)Image.Load(outputPath))
            {
                // Set resolution to 150 DPI for both axes
                bmpImage.SetResolution(150.0, 150.0);
                // Overwrite the BMP with the new resolution
                bmpImage.Save(outputPath);
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
 * 1. When you need to import OpenDocument graphics into a Windows application that only supports BMP files and require a specific 150 DPI resolution for accurate on‑screen rendering.
 * 2. When preparing ODG diagrams for high‑quality printing where the printer expects BMP images at a defined DPI setting.
 * 3. When archiving legacy ODG artwork in a BMP format while preserving a consistent resolution for downstream processing pipelines.
 * 4. When converting ODG assets for use in a game engine that loads BMP textures and needs a uniform 150 DPI to match other assets.
 * 5. When automating a batch workflow that transforms ODG files to BMP and sets a custom resolution to ensure correct scaling in PDF reports.
 */
