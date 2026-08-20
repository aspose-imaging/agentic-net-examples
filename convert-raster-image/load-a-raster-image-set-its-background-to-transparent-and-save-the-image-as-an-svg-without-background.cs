// HOW-TO: Convert PNG to SVG with Transparent Background Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Configure SVG rasterization options with transparent background
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Aspose.Imaging.Color.Transparent
                };

                // Set up SVG save options
                var saveOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the image as SVG without background
                image.Save(outputPath, saveOptions);
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
 * 1. When you need to embed a logo originally in PNG into a web page as a scalable SVG without any background color.
 * 2. When generating vector graphics for print layouts from raster assets while preserving transparency to overlay on other designs.
 * 3. When creating responsive UI icons that must scale without pixelation and require a transparent canvas in SVG format.
 * 4. When converting user‑uploaded images to SVG for a graphics editor that expects a transparent background layer.
 * 5. When automating batch processing of product images to produce SVG files that can be tinted or styled with CSS.
 */
