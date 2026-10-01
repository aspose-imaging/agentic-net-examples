// HOW-TO: Create a Filtered Thumbnail from JPEG and Save as SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.svg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.Filter(image.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));

                int thumbWidth = 150;
                int thumbHeight = 150;
                image.Resize(thumbWidth, thumbHeight);

                SvgOptions options = new SvgOptions();
                image.Save(outputPath, options);
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
 * 1. When you need to generate a small, noise‑reduced preview of a JPEG for web pages and deliver it as a scalable SVG graphic.
 * 2. When you want to preprocess scanned photos by applying a median filter before converting them into vector‑friendly thumbnails for responsive design.
 * 3. When an application must automatically create lightweight SVG icons from user‑uploaded raster images while preserving visual quality.
 * 4. When you are building a batch process that converts high‑resolution JPEGs into 150×150 SVG thumbnails for PDF or e‑book embedding.
 * 5. When you require a C# routine that filters out speckle noise, resizes images, and outputs them in SVG format for cross‑platform UI components.
 */
