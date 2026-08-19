// HOW-TO: Set JPEG Image DPI to 300 Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output_300dpi.jpg";

        // Check that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG save options with 300 DPI resolution
                var jpegOptions = new JpegOptions
                {
                    // Set horizontal and vertical DPI to 300
                    ResolutionSettings = new ResolutionSetting(300.0, 300.0),
                    ResolutionUnit = ResolutionUnit.Inch,
                    // Optional: keep default quality (100) and other settings
                    Quality = 100
                };

                // Save the image as JPEG with the specified DPI
                image.Save(outputPath, jpegOptions);
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
 * 1. When preparing photos for high‑resolution printing, you need to set the JPEG’s DPI to 300 before sending it to the printer.
 * 2. When converting scanned documents to JPEG for archival, you must ensure the output has a 300 dpi resolution for compliance with industry standards.
 * 3. When generating thumbnails for a web gallery that require a specific physical size, adjusting the JPEG DPI guarantees consistent print‑size calculations.
 * 4. When integrating a document‑management system that stores images with metadata, you may need to enforce a 300 dpi setting on each saved JPEG to maintain uniform quality.
 * 5. When processing batch image uploads in a C# application, you can use Aspose.Imaging to re‑save each JPEG with a 300 dpi resolution to meet downstream workflow requirements.
 */
