// HOW-TO: Convert PNG to SVG With Original Dimensions Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                int width = raster.Width;
                int height = raster.Height;

                SvgGraphics2D svgGraphics = new SvgGraphics2D(width, height, 96);
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
 * 1. When you need to embed a raster logo into a scalable vector graphic for responsive web design.
 * 2. When you want to generate SVG assets from user‑uploaded PNG files while preserving the exact pixel size for print layouts.
 * 3. When converting icons stored as PNG into SVG to reduce file size and enable CSS styling without losing the original dimensions.
 * 4. When automating a batch process that transforms product images from PNG to SVG for use in vector‑based reporting tools.
 * 5. When creating an SVG placeholder that matches a PNG’s width and height for dynamic image replacement in a WPF application.
 */
