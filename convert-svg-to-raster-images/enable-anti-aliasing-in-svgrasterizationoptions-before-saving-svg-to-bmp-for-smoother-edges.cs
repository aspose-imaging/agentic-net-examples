using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\input.svg";
            string outputPath = @"C:\Images\output.bmp";

            // Verify that the input SVG exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
            {
                // Configure rasterization options with anti‑aliasing
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    SmoothingMode = SmoothingMode.AntiAlias
                };

                // Set up BMP save options and attach the rasterization options
                var bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the rasterized image as BMP
                svgImage.Save(outputPath, bmpOptions);
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
 * 1. When a web application needs to generate high‑quality BMP thumbnails from user‑uploaded SVG logos, enabling anti‑aliasing ensures smooth edges in the rasterized output.
 * 2. When converting vector illustrations to BMP for legacy Windows printing pipelines, applying SmoothingMode.AntiAlias prevents jagged lines and preserves visual fidelity.
 * 3. When an automated report generator creates BMP charts from SVG diagrams, anti‑aliasing in SvgRasterizationOptions yields professional‑looking graphics for PDF export.
 * 4. When a desktop tool batch‑processes SVG icons into BMP assets for a game engine, enabling anti‑aliasing avoids pixelated borders on high‑resolution screens.
 * 5. When a C# service transforms SVG floor plans into BMP maps for GIS applications, anti‑aliasing improves the clarity of walls and room outlines during rasterization.
 */