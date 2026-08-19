// HOW-TO: Convert CDR to PNG with Lossless Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cdr";
        string outputPath = @"C:\Images\sample.png";

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

            // Load the CDR image
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // Set up rasterization options to keep original dimensions (default scale 1.0)
                var rasterOptions = new CdrRasterizationOptions
                {
                    // No explicit page size; defaults preserve original aspect ratio and dimensions
                    ScaleX = 1.0f,
                    ScaleY = 1.0f
                };

                // Configure PNG save options with lossless compression
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save as PNG
                cdrImage.Save(outputPath, pngOptions);
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
 * 1. When a designer provides CorelDRAW (.cdr) artwork that must be displayed on a website without quality loss, a developer can use this code to convert it to a lossless PNG while keeping the original size.
 * 2. When an automated build pipeline needs to generate thumbnail previews of CDR files for a digital asset management system, the snippet ensures the PNGs retain exact dimensions and lossless detail.
 * 3. When migrating legacy graphic assets from CorelDRAW to a modern content management system, this code enables batch conversion to PNG with lossless compression to preserve visual fidelity.
 * 4. When creating print‑ready PDFs that embed PNG images derived from CDR sources, developers can first convert the CDR to a lossless PNG at original dimensions to avoid scaling artifacts.
 * 5. When implementing a C# desktop application that lets users export their CorelDRAW drawings as high‑quality PNGs for archival purposes, the example provides the necessary steps to maintain size and compression.
 */
