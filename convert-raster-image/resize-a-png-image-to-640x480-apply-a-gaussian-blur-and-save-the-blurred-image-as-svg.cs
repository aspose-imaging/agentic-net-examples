// HOW-TO: Resize PNG to 640x480, Apply Gaussian Blur and Save as SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageFilters.FilterOptions;

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

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached)
                    image.CacheData();

                image.Resize(640, 480);
                image.Filter(image.Bounds, new GaussianBlurFilterOptions(5, 1.0));

                SvgOptions svgOptions = new SvgOptions();
                image.Save(outputPath, svgOptions);
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
 * 1. When you need to generate a scalable vector thumbnail with a soft blur for web previews.
 * 2. When you must convert high‑resolution PNG assets into smaller, blurred SVG icons for responsive UI design.
 * 3. When an application creates blurred background images for PDFs and stores them as SVG to keep file size low.
 * 4. When a batch process prepares product images by resizing them to 640×480, applying a Gaussian blur, and exporting to SVG for print‑ready layouts.
 * 5. When you want to programmatically transform user‑uploaded PNG photos into blurred SVG graphics for use in HTML5 canvas animations.
 */
