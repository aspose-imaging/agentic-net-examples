// HOW-TO: Convert ODG to PNG with Anti‑Aliasing Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\input\sample.odg";
        string outputPath = @"C:\output\sample.png";

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

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options with anti‑aliasing
                var rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size,
                    SmoothingMode = SmoothingMode.AntiAlias,
                    TextRenderingHint = TextRenderingHint.AntiAlias
                };

                // Set up PNG save options and attach rasterization options
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the image as PNG
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to generate high‑quality PNG thumbnails from ODG graphics for a web gallery while preserving smooth edges.
 * 2. When you want to convert ODG diagrams to PNG for PDF reports and require anti‑aliased text and shapes for better readability.
 * 3. When an application must batch‑process multiple ODG files into PNGs with a consistent white background and anti‑aliasing to improve visual appearance.
 * 4. When you are building a document viewer that renders ODG vector drawings as raster PNG images with crisp, smooth visuals on Windows.
 * 5. When you need to maintain the original ODG page size in the PNG output and apply anti‑aliasing to enhance visual fidelity.
 */
