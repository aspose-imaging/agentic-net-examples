// HOW-TO: Invert BMP Colors and Save as SVG Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.bmp";
        string outputPath = "output/inverted.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);
                for (int i = 0; i < pixels.Length; i++)
                {
                    int pixel = pixels[i];
                    int a = (pixel >> 24) & 0xFF;
                    int r = (pixel >> 16) & 0xFF;
                    int g = (pixel >> 8) & 0xFF;
                    int b = pixel & 0xFF;
                    r = 255 - r;
                    g = 255 - g;
                    b = 255 - b;
                    pixels[i] = (a << 24) | (r << 16) | (g << 8) | b;
                }
                raster.SaveArgb32Pixels(raster.Bounds, pixels);

                SvgGraphics2D svgGraphics = new SvgGraphics2D(raster.Width, raster.Height, 96);
                svgGraphics.DrawImage(raster, new Point(0, 0));
                SvgImage svgImage = svgGraphics.EndRecording();

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                svgImage.Save(outputPath, new SvgOptions());
                svgImage.Dispose();
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
 * 1. When you need to create a negative‑style version of a BMP logo and export it as a scalable SVG for responsive web design.
 * 2. When a batch process must convert legacy BMP assets to high‑contrast SVG icons by inverting colors for better visibility on dark themes.
 * 3. When preparing print‑ready artwork that requires color inversion of raster images before embedding them in vector SVG files.
 * 4. When generating SVG previews of medical or scientific BMP scans with inverted colors to highlight details for analysis tools.
 * 5. When automating the transformation of user‑uploaded BMP photos into inverted SVG illustrations for a custom graphics editor.
 */
