using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.svg";
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

            // Load SVG image
            using (var svgImage = new SvgImage(inputPath))
            {
                // Remove background using default analysis
                svgImage.RemoveBackground();

                // Set up rasterization options
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size // use original size
                };

                // Set up PNG save options
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
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
 * 1. When a web application needs to convert user‑uploaded SVG logos to transparent PNG thumbnails for display on different devices, a developer can use this code to load the SVG, strip its background, and rasterize it to PNG.
 * 2. When generating product catalog PDFs that require high‑resolution PNG images without any background color from original SVG artwork, this C# snippet removes the background and saves the rasterized image.
 * 3. When an e‑commerce platform wants to create watermark‑ready PNG assets from SVG icons while ensuring the background is removed automatically, the code provides the necessary Aspose.Imaging operations.
 * 4. When automating a batch process that prepares SVG diagrams for inclusion in PowerPoint slides by converting them to PNG with transparent backgrounds, developers can employ this example to handle file I/O and rasterization.
 * 5. When building a desktop tool that lets designers preview SVG files as PNG previews without background clutter, this C# routine loads the SVG, performs default background analysis, and saves a clean PNG file.
 */