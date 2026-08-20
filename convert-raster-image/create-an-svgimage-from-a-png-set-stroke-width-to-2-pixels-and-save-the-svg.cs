// HOW-TO: Convert PNG to SVG with 2‑Pixel Border in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.FileFormats.Svg;

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

            using (Aspose.Imaging.RasterImage pngImage = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                int width = pngImage.Width;
                int height = pngImage.Height;
                int dpi = 96;

                var graphics = new Aspose.Imaging.FileFormats.Svg.Graphics.SvgGraphics2D(width, height, dpi);

                // Draw the PNG onto the SVG canvas
                graphics.DrawImage(pngImage, new Aspose.Imaging.Point(0, 0));

                // Draw a rectangle border with a 2‑pixel stroke
                var pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2);
                graphics.DrawRectangle(pen, 0, 0, width, height);

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
 * 1. When you need to embed a raster PNG into a scalable SVG for responsive web graphics while adding a uniform 2‑pixel outline.
 * 2. When generating vector assets from user‑uploaded PNG logos and you want to ensure a consistent border for branding guidelines.
 * 3. When creating printable SVG diagrams from PNG screenshots and require a precise stroke width to match design specifications.
 * 4. When automating batch conversion of PNG icons to SVG format with a defined border for use in UI icon libraries.
 * 5. When integrating Aspose.Imaging in a C# application to transform raster images into SVG files that include a custom stroke for visual emphasis.
 */
