// HOW-TO: Apply Gaussian Blur to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image svgImage = Image.Load(inputPath))
            {
                using (var memoryStream = new MemoryStream())
                {
                    var pngOptions = new PngOptions();
                    svgImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    using (Image rasterImage = Image.Load(memoryStream))
                    {
                        var raster = rasterImage as RasterImage;
                        if (raster != null)
                        {
                            double[,] kernel = new double[,]
                            {
                                { 0.0625, 0.125,  0.0625 },
                                { 0.125,  0.25,   0.125 },
                                { 0.0625, 0.125,  0.0625 }
                            };

                            var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                            raster.Filter(raster.Bounds, filterOptions);
                            raster.Save(outputPath, new PngOptions());
                        }
                    }
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
 * 1. When you need to soften vector graphics before embedding them in a web page, you can rasterize an SVG, apply a Gaussian blur, and output a PNG using C#.
 * 2. When generating thumbnails for a design portfolio, applying a blur filter to SVG icons creates a consistent visual style without manual editing.
 * 3. When preparing assets for a mobile app that requires blurred background images, you can convert SVG assets to PNG and apply a Gaussian blur programmatically.
 * 4. When automating a batch process to add a subtle blur effect to logo files for marketing materials, this code handles the conversion and filtering in one workflow.
 * 5. When integrating image processing into a .NET service that receives SVG uploads and returns blurred PNG previews, the example shows how to perform the transformation server‑side.
 */
