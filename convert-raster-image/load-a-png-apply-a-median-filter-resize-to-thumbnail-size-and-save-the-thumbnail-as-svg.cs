// HOW-TO: Create A 100x100 PNG Thumbnail With Median Filter And Save As SVG In C# (Aspose.Imaging for .NET)
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
            string inputPath = "input/input.png";
            string outputPath = "output/output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                var medianOptions = new MedianFilterOptions(3);
                raster.Filter(raster.Bounds, medianOptions);

                raster.Resize(100, 100);

                SvgOptions svgOptions = new SvgOptions();
                svgOptions.VectorRasterizationOptions = new SvgRasterizationOptions();

                raster.Save(outputPath, svgOptions);
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
 * 1. When you need to generate a small, noise‑reduced preview of a PNG for web pages and store it as a scalable SVG file.
 * 2. When an application must convert high‑resolution PNG assets into lightweight 100 × 100 thumbnails while preserving vector compatibility.
 * 3. When you want to preprocess PNG graphics with a median filter before raster‑to‑vector conversion to improve visual quality.
 * 4. When a reporting tool requires PNG charts to be embedded as SVG thumbnails for resolution‑independent rendering.
 * 5. When automating batch processing of PNG images to create filtered, resized SVG icons for mobile UI assets.
 */
