// HOW-TO: Create SVG From BMP With 3 Pixel Border In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output.svg";

        try
        {
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

                // Draw the raster image onto the SVG canvas
                graphics.DrawImage(raster, new Point(0, 0));

                // Draw a border with a 3‑pixel stroke width
                graphics.DrawRectangle(new Pen(Color.Black, 3), 0, 0, width, height);

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
 * 1. When you need to embed a bitmap logo into a scalable SVG document and ensure it has a consistent 3‑pixel outline for branding purposes.
 * 2. When generating printable graphics where a raster photograph must be wrapped in a vector border to maintain sharp edges at any resolution.
 * 3. When converting legacy BMP assets to SVG for web use while adding a uniform stroke to match a site’s design system.
 * 4. When creating automated reports that combine raster screenshots with vector annotations, such as a 3‑pixel frame around each image.
 * 5. When building a batch process that transforms a folder of raster images into SVG files with a predefined border thickness for consistent UI icons.
 */
