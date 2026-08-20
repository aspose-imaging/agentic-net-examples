// HOW-TO: Convert SVG to PNG with High Quality Vector Rasterization in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                image.Save(outputPath, pngOptions);
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
 * 1. When you need to generate pixel‑perfect PNG thumbnails from scalable SVG logos for web pages.
 * 2. When a reporting system must embed SVG charts into PDF documents that only accept raster images.
 * 3. When an e‑commerce platform converts product vector illustrations to PNG for email newsletters.
 * 4. When a desktop application rasterizes user‑drawn SVG diagrams at high quality for printing.
 * 5. When a CI pipeline validates SVG assets by rendering them as PNGs to compare visual differences.
 */
