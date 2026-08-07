using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.svg";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG image
            using (SvgImage svgImage = new SvgImage(inputPath))
            {
                // Remove background using default analysis
                svgImage.RemoveBackground();

                // Set up rasterization options for PNG conversion
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size // preserve original size
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save as PNG
                svgImage.Save(outputPath, pngOptions);
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
 * 1. When a web application needs to generate transparent PNG thumbnails from user‑uploaded SVG logos, a developer can load the SVG, remove its background, and save it as PNG using Aspose.Imaging for .NET.
 * 2. When an e‑commerce platform wants to display product icons without any background color across different browsers, the code can strip the SVG background and rasterize it to a PNG for consistent rendering.
 * 3. When a mobile app requires high‑quality PNG assets derived from vector illustrations while ensuring the background is removed to reduce file size, this C# routine automates the conversion.
 * 4. When a reporting tool must embed SVG diagrams into PDF reports that only support raster images, the developer can convert the SVG to a background‑free PNG before embedding.
 * 5. When an automated CI/CD pipeline processes design assets and needs to validate that SVG files have no background before publishing them as PNG assets, the script performs the background removal and rasterization step.
 */