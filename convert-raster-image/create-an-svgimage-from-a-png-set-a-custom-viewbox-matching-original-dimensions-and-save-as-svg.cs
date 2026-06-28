using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\source.png";
        string outputPath = @"C:\Images\result.svg";

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

            // Load the PNG image
            using (Image pngImage = Image.Load(inputPath))
            {
                // Cast to RasterImage to access drawing methods
                var raster = pngImage as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("The input file is not a raster image.");
                    return;
                }

                int width = raster.Width;
                int height = raster.Height;
                int dpi = 96; // Standard screen DPI

                // Create an SVG graphics context with the same dimensions as the PNG
                var graphics = new SvgGraphics2D(width, height, dpi);

                // Draw the raster PNG onto the SVG canvas, covering the whole area
                graphics.DrawImage(raster, new Point(0, 0), new Size(width, height));

                // Finalize the SVG image
                using (SvgImage svgImage = graphics.EndRecording())
                {
                    // The viewbox is automatically set to match the canvas size (width x height)
                    // Save the SVG to the specified output path
                    svgImage.Save(outputPath);
                }
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
 * 1. When a developer needs to convert a raster PNG logo into a scalable SVG file for responsive web design while preserving the original dimensions.
 * 2. When an application must generate vector‑based icons from user‑uploaded PNG images to ensure crisp rendering on high‑DPI screens.
 * 3. When a workflow requires embedding PNG graphics into SVG documents for print‑ready PDFs, keeping the viewbox aligned with the source image size.
 * 4. When a batch‑processing tool automates the transformation of legacy PNG assets into SVG format for a modern UI asset pipeline.
 * 5. When a C# service creates SVG placeholders from PNG thumbnails to be used in dynamic SVG spritesheets without losing the original aspect ratio.
 */