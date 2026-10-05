// HOW-TO: Convert BMP to Scalable SVG with Custom ViewBox in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "image.bmp");
            string outputPath = Path.Combine("Output", "result.svg");

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

                SvgGraphics2D svgGraphics = new SvgGraphics2D(width, height, dpi);
                svgGraphics.DrawImage(raster, new Point(0, 0));

                using (SvgImage svgImage = svgGraphics.EndRecording())
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
 * 1. When you need to embed a legacy BMP logo into a responsive web page, converting it to an SVG with a defined viewbox ensures the graphic scales without loss of quality.
 * 2. When generating printable PDFs from desktop applications, converting high‑resolution BMP scans to SVG allows the vector format to be rendered sharply at any DPI.
 * 3. When creating an automated asset pipeline that transforms user‑uploaded bitmap images into scalable icons for mobile apps, this code provides a C# solution using Aspose.Imaging.
 * 4. When modernizing an old Windows Forms UI that stores images as BMP files, converting them to SVG enables you to reuse the graphics in modern XAML or HTML5 interfaces.
 * 5. When building a batch process that prepares map tiles stored as BMP for GIS web services, converting each tile to SVG with a custom viewbox preserves geographic coordinates for further vector editing.
 */
