// HOW-TO: Invert BMP Colors and Export as SVG Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/input.bmp";
        string outputPath = "Output/inverted.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);
                for (int i = 0; i < pixels.Length; i++)
                {
                    int pixel = pixels[i];
                    int a = (pixel >> 24) & 0xFF;
                    int rgb = pixel & 0x00FFFFFF;
                    int inv = (~rgb) & 0x00FFFFFF;
                    pixels[i] = (a << 24) | inv;
                }
                raster.SaveArgb32Pixels(raster.Bounds, pixels);

                using (SvgOptions svgOptions = new SvgOptions())
                {
                    image.Save(outputPath, svgOptions);
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
 * 1. When you need to generate a vector graphic version of a legacy BMP with its colors reversed for branding or UI themes.
 * 2. When an application must programmatically convert scanned bitmap images into SVG while applying a negative filter for visual effects.
 * 3. When a batch process has to prepare inverted SVG assets from BMP files for responsive web design.
 * 4. When a game development tool requires color‑inverted SVG icons derived from original BMP sprites.
 * 5. When a reporting system needs to embed high‑resolution, color‑inverted diagrams by converting BMP charts to scalable SVG format.
 */
