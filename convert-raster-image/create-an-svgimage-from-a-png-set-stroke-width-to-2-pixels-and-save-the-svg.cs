using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output/output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                int width = raster.Width;
                int height = raster.Height;
                int dpi = 96;

                SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

                // Draw a rectangle border with 2‑pixel stroke
                graphics.DrawRectangle(new Pen(Color.Black, 2), 0, 0, width, height);

                // Embed the PNG image
                graphics.DrawImage(raster, new Point(0, 0));

                using (SvgImage svgImage = graphics.EndRecording())
                {
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
 * 1. When a developer needs to convert a raster PNG logo into a scalable SVG for responsive web design while adding a 2‑pixel border.
 * 2. When an e‑commerce platform wants to generate lightweight SVG product thumbnails from high‑resolution PNG images with a consistent stroke width.
 * 3. When a reporting tool must embed PNG charts into SVG diagrams so they can be printed at any DPI without losing quality.
 * 4. When a mobile app creates vector‑based icons from user‑uploaded PNG avatars, applying a 2‑pixel outline for better visibility on dark backgrounds.
 * 5. When an automated CI pipeline transforms PNG assets into SVG files with a defined stroke to ensure consistent styling across different browsers.
 */