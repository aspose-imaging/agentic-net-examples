// HOW-TO: Apply Gaussian Blur to PNG and Rasterize SVG to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPngPath = "input.png";
            string outputPngPath = "output.png";
            string inputSvgPath = "input.svg";
            string outputSvgPath = "output.svg";
            string outputSvgRasterPngPath = "svg_rasterized.png";

            if (!File.Exists(inputPngPath))
            {
                Console.Error.WriteLine($"File not found: {inputPngPath}");
                return;
            }
            if (!File.Exists(inputSvgPath))
            {
                Console.Error.WriteLine($"File not found: {inputSvgPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPngPath) ?? string.Empty);
            Directory.CreateDirectory(Path.GetDirectoryName(outputSvgPath) ?? string.Empty);
            Directory.CreateDirectory(Path.GetDirectoryName(outputSvgRasterPngPath) ?? string.Empty);

            using (RasterImage pngImage = (RasterImage)Image.Load(inputPngPath))
            {
                var blurOptions = new GaussianBlurFilterOptions(5, 1.0);
                pngImage.Filter(pngImage.Bounds, blurOptions);
                var pngSaveOptions = new PngOptions();
                pngImage.Save(outputPngPath, pngSaveOptions);
            }

            using (Image svgImage = Image.Load(inputSvgPath))
            {
                var svgSaveOptions = new SvgOptions();
                svgImage.Save(outputSvgPath, svgSaveOptions);
            }

            using (Image svgImage = Image.Load(inputSvgPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = 800,
                    PageHeight = 600
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                svgImage.Save(outputSvgRasterPngPath, pngOptions);
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
 * 1. When you need to programmatically blur a PNG image before saving it as a thumbnail or preview in a C# web application.
 * 2. When you want to load an SVG file and save it back to ensure it conforms to the standard SVG format for further editing.
 * 3. When you must convert an SVG into a raster PNG of a specific width and height to embed it in reports or UI components.
 * 4. When you are running a batch image‑processing job and must create output folders automatically before writing the processed files.
 * 5. When you require graceful error handling for missing source PNG or SVG files while performing image transformations in .NET.
 */
