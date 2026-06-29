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
            string outputPath = "output.svg";

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

                SvgGraphics2D graphics = new SvgGraphics2D(width, height, 96);

                graphics.DrawImage(raster, new Point(0, 0), new Size(width, height));

                Pen redPen = new Pen(Color.Red, 1);
                graphics.DrawRectangle(redPen, 0, 0, width, height);

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
 * 1. When a developer needs to convert a product photo PNG into an SVG for responsive web design while adding a red border to highlight the image.
 * 2. When a developer wants to generate vector graphics from scanned PNG icons and emphasize their outlines with a red stroke for UI mockups.
 * 3. When a developer must create an SVG version of a PNG logo for print media and apply a red rectangle border to meet branding guidelines.
 * 4. When a developer is building an automated pipeline that transforms PNG screenshots into SVG diagrams with red outlines for documentation purposes.
 * 5. When a developer requires a C# solution to load a raster PNG, draw it onto an SvgGraphics2D canvas, add a red stroke rectangle, and save the result as an SVG file for cross‑platform rendering.
 */