// HOW-TO: Set Custom Hex Background Color When Converting SVG to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
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

        try
        {
            // Load the SVG image
            using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
            {
                // Configure rasterization options with a custom background color (hex #1A2B3C)
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.FromArgb(255, 0x1A, 0x2B, 0x3C), // opaque custom color
                    PageSize = svgImage.Size
                };

                // Set PNG save options and attach rasterization options
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the rasterized PNG
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
 * 1. When you need to generate PNG thumbnails from SVG logos with a specific brand color as the canvas background.
 * 2. When exporting SVG diagrams to PNG for reports and must ensure a consistent dark background that matches corporate styling.
 * 3. When converting user-uploaded SVG icons to PNG assets for a web app and want to replace transparent areas with a custom hex color.
 * 4. When creating print-ready PNG images from SVG illustrations and need to set an opaque background to avoid unwanted transparency.
 * 5. When automating batch processing of SVG files to PNG and require a fixed background shade to maintain visual uniformity across all output files.
 */
