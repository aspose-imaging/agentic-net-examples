using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\vector.svg";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the vector image (SVG, CDR, etc.)
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG export options
                var pngOptions = new PngOptions
                {
                    // 16‑bit per channel depth for high‑quality output
                    BitDepth = 16,
                    // Truecolor with alpha supports 16‑bit depth
                    ColorType = PngColorType.TruecolorWithAlpha,
                    // Optional: enable progressive PNG
                    Progressive = true
                };

                // Set up vector rasterization options with anti‑aliasing
                var rasterOptions = new VectorRasterizationOptions
                {
                    // Apply anti‑aliasing to lines, curves and filled areas
                    SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias,
                    // Apply anti‑aliasing to text rendering
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.AntiAlias,
                    // Use the original image size for rasterization
                    PageSize = image.Size
                };

                pngOptions.VectorRasterizationOptions = rasterOptions;

                // Save the rasterized image as PNG
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
 * 1. When a developer needs to convert an SVG logo to a print‑ready PNG with smooth edges, using anti‑aliasing and 16‑bit color depth for high‑quality output.
 * 2. When a web application must generate retina‑ready PNG thumbnails from vector icons on the fly, preserving crisp lines and text through vector rasterization with anti‑aliasing.
 * 3. When a desktop utility processes CAD or CDR vector drawings and exports them as lossless PNGs with truecolor and alpha channels for archival or sharing.
 * 4. When an automated build pipeline creates progressive PNG assets from vector sources, applying 16‑bit per channel depth and anti‑aliasing to reduce file size while retaining image fidelity.
 * 5. When a reporting system needs to embed vector diagrams into PDFs by first rasterizing them to high‑quality PNGs with anti‑aliased text and shapes.
 */