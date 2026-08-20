// HOW-TO: Convert PNG to SVG with Embedded Fonts Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure SVG options to embed fonts
                var svgOptions = new SvgOptions
                {
                    TextAsShapes = false,                     // Keep text as text (fonts can be embedded)
                    Callback = new SvgResourceKeeperCallback() // Handles embedding of resources such as fonts
                };

                // Set rasterization options based on the source image size
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };
                svgOptions.VectorRasterizationOptions = rasterOptions;

                // Save as SVG with embedded fonts
                image.Save(outputPath, svgOptions);
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
 * 1. When you need to transform a raster PNG logo into a scalable SVG while keeping the original text editable by embedding the required font family.
 * 2. When generating web‑ready vector graphics from user‑uploaded PNGs and you must ensure the SVG displays the correct typography across browsers.
 * 3. When creating printable SVG assets from PNG designs and you want the fonts to be self‑contained so the file can be opened on any system without installing the font.
 * 4. When automating a batch conversion pipeline that converts PNG icons to SVGs and requires embedded fonts to maintain brand consistency.
 * 5. When developing a C# application that extracts PNG images and saves them as SVGs with embedded fonts for use in design tools that rely on vector formats.
 */
