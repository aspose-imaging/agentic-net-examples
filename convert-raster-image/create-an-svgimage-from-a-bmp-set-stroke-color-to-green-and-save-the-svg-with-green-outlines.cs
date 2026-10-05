// HOW-TO: Convert BMP to SVG With Green Outline In C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/input.bmp";
            string outputPath = "Output/output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image bmpImage = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)bmpImage;

                using (SvgImage svgImage = (SvgImage)Image.Create(new SvgOptions(), raster.Width, raster.Height))
                {
                    Graphics graphics = new Graphics(svgImage);
                    graphics.DrawImage(raster, new Point(0, 0));

                    Pen greenPen = new Pen(Color.Green);
                    graphics.DrawRectangle(greenPen, new Rectangle(0, 0, raster.Width, raster.Height));

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
 * 1. When you need to embed a bitmap logo into a web page as scalable SVG while highlighting its border in green.
 * 2. When you want to generate vector graphics from legacy BMP assets for printing, adding a green outline for brand colors.
 * 3. When an application must convert user‑uploaded BMP files to SVG format and automatically apply a green stroke for visual emphasis.
 * 4. When creating diagrammatic thumbnails from BMP screenshots and requiring a consistent green frame in the resulting SVG files.
 * 5. When automating batch processing of BMP icons to SVG with a green border to match a UI theme using Aspose.Imaging in C#.
 */
