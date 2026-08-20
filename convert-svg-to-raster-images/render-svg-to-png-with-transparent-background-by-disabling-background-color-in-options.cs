// HOW-TO: Convert SVG to PNG with Transparent Background in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\test.svg";
            string outputPath = @"C:\temp\test.output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (SvgImage svgImage = new SvgImage(inputPath))
            {
                // Configure rasterization options with a transparent background
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.Transparent,
                    PageSize = svgImage.Size // preserve original size
                };

                // Set PNG save options and attach rasterization options
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save as PNG with transparent background
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
 * 1. When you need to generate PNG icons from SVG assets while preserving transparency for web UI.
 * 2. When converting vector logos stored as SVG into PNG files for email signatures that require a clear background.
 * 3. When creating thumbnails of SVG diagrams for PDF reports and the background must remain invisible.
 * 4. When processing user‑uploaded SVG illustrations in a C# service and saving them as transparent PNGs for a mobile app.
 * 5. When automating batch conversion of SVG graphics to PNG for a design system that needs overlay compatibility.
 */
