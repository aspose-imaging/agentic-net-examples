// HOW-TO: How To Render SVG As Anti-Aliased GIF In C# With Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.svg";
            string outputPath = @"C:\temp\output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
            {
                // Configure vector rasterization options with smoothing (anti-aliasing)
                VectorRasterizationOptions rasterOptions = new VectorRasterizationOptions
                {
                    // Use the original SVG size
                    PageSize = svgImage.Size,
                    // Apply anti-aliasing to reduce pixelation
                    SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias,
                    // Optional: set background color if needed
                    BackgroundColor = Aspose.Imaging.Color.White
                };

                // Set up GIF save options and attach rasterization options
                GifOptions gifOptions = new GifOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    // Enable palette correction for better color quality (optional)
                    DoPaletteCorrection = true,
                    // Enable interlacing for smoother progressive display (optional)
                    Interlaced = true
                };

                // Save the image as GIF with the specified options
                svgImage.Save(outputPath, gifOptions);
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
 * 1. When you need to convert vector SVG graphics to animated GIFs while preserving smooth edges and avoiding pixelated artifacts in a C# application.
 * 2. When generating web‑ready GIF previews of SVG icons and want anti‑aliasing to improve visual quality on high‑resolution displays.
 * 3. When creating a batch process that converts a folder of SVG files to GIFs with consistent background color and palette correction using Aspose.Imaging.
 * 4. When developing a reporting tool that embeds SVG charts as GIF animations and requires interlaced output for progressive rendering in browsers.
 * 5. When optimizing GIF assets for email newsletters by applying smoothing mode to reduce jagged lines and ensure the animation looks professional across email clients.
 */
