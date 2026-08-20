// HOW-TO: Convert SVG to 16‑Bit PNG with Anti‑Aliasing in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options with anti-aliasing
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size,
                    SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias,
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.AntiAlias,
                    BackgroundColor = Aspose.Imaging.Color.White
                };

                // Configure PNG options with 16‑bit depth
                var pngOptions = new PngOptions
                {
                    BitDepth = 16,
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rasterized PNG
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
 * 1. When you need to generate print‑ready 16‑bit PNG assets from SVG logos while preserving smooth edges using anti‑aliasing in a C# application.
 * 2. When a web service must dynamically convert user‑uploaded SVG diagrams to high‑quality PNG thumbnails with accurate color depth for downstream processing.
 * 3. When an automated build pipeline has to rasterize vector icons into 16‑bit PNGs for inclusion in a Windows desktop application that requires lossless image quality.
 * 4. When a reporting tool creates PDF reports and needs to embed SVG charts as crisp 16‑bit PNG images with anti‑aliased rendering to match corporate branding.
 * 5. When a mobile app backend prepares scalable graphics for different screen densities by converting SVG assets to anti‑aliased 16‑bit PNGs before delivery.
 */
