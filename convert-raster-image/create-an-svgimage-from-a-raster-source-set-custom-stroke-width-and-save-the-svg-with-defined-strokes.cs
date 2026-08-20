// HOW-TO: Create SVG From BMP With Custom Border Stroke Width In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
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

            using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                int width = raster.Width;
                int height = raster.Height;
                int dpi = 96;

                var svgGraphics = new SvgGraphics2D(width, height, dpi);

                var borderPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 5);
                svgGraphics.DrawRectangle(borderPen, 0, 0, width, height);

                svgGraphics.DrawImage(raster, new Aspose.Imaging.Point(0, 0), new Aspose.Imaging.Size(width, height));

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
 * 1. When you need to embed a bitmap logo into a scalable SVG document while adding a thick black outline for branding consistency.
 * 2. When generating printable vector graphics from scanned photos and you want a uniform border to match corporate style guidelines.
 * 3. When converting UI screenshots to SVG for responsive web design and require a defined stroke width around the image to preserve layout spacing.
 * 4. When automating batch processing of BMP assets to SVG format and need to ensure each output includes a consistent border for visual separation.
 * 5. When creating diagram assets programmatically in C# and want to overlay a custom‑width rectangle around a raster image before saving as SVG for further editing.
 */
