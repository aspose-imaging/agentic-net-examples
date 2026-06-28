using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input PNG path
            string inputPath = @"C:\Images\source.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output SVG path
            string outputPath = @"C:\Images\result.svg";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image as a raster image
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                int width = raster.Width;
                int height = raster.Height;
                int dpi = 96; // Standard screen DPI

                // Create an SVG graphics context with the same dimensions as the PNG
                SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

                // Draw a black stroke rectangle around the image bounds
                graphics.DrawRectangle(new Pen(Color.Black, 1), 0, 0, width, height);

                // Embed the raster PNG into the SVG
                graphics.DrawImage(raster, new Point(0, 0), new Size(width, height));

                // Finalize the SVG image
                using (SvgImage svgImage = graphics.EndRecording())
                {
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
 * 1. When a developer needs to convert a product photo stored as PNG into an SVG for responsive web design while preserving the original dimensions and adding a black border.
 * 2. When an e‑learning platform wants to embed raster diagrams in scalable SVG slides and ensure a consistent black stroke outline for visual consistency.
 * 3. When a branding tool must generate vector‑compatible logos from PNG assets, adding a thin black rectangle to meet brand guidelines before saving as SVG.
 * 4. When a reporting system requires converting PNG charts into SVG files so they can be printed at any resolution with a defined black border for clarity.
 * 5. When a desktop application automates the creation of SVG icons from PNG resources, applying a black stroke rectangle to maintain a uniform icon frame across the UI.
 */