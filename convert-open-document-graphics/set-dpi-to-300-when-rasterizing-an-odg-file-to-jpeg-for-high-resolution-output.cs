// HOW-TO: Rasterize ODG to JPEG with 300 DPI in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Input\sample.odg";
            string outputPath = @"C:\Output\sample.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for ODG
                OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size
                };

                // Configure JPEG save options with 300 DPI
                JpegOptions jpegOptions = new JpegOptions
                {
                    ResolutionSettings = new ResolutionSetting(300.0, 300.0),
                    ResolutionUnit = ResolutionUnit.Inch,
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rasterized image as JPEG
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
 * 1. When you need to convert an OpenDocument Graphic (ODG) into a high‑resolution JPEG for professional printing at 300 DPI.
 * 2. When generating print‑ready marketing assets from ODG files that must meet standard DPI requirements for brochures.
 * 3. When archiving vector drawings as raster images with consistent resolution for inclusion in PDF reports.
 * 4. When creating high‑quality product images from ODG designs for e‑commerce platforms that require 300 DPI JPEGs.
 * 5. When developing a C# application that batch‑processes ODG files into JPEGs with precise DPI settings for downstream image analysis.
 */
