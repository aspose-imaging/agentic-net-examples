// HOW-TO: Apply 3x3 Box Blur to SVG and Export as PNG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

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

            using (Aspose.Imaging.Image svgImage = Aspose.Imaging.Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions();
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(ms))
                    {
                        double[,] kernel = new double[,]
                        {
                            { 1.0 / 9, 1.0 / 9, 1.0 / 9 },
                            { 1.0 / 9, 1.0 / 9, 1.0 / 9 },
                            { 1.0 / 9, 1.0 / 9, 1.0 / 9 }
                        };

                        var filterOptions = new ConvolutionFilterOptions(kernel);
                        raster.Filter(raster.Bounds, filterOptions);

                        var finalPngOptions = new PngOptions();
                        raster.Save(outputPath, finalPngOptions);
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
 * 1. When you need to soften vector graphics before displaying them on a web page, you can rasterize an SVG, apply a 3x3 box blur, and save the result as a PNG.
 * 2. When generating thumbnails for a gallery, applying a uniform blur to SVG icons ensures a consistent visual style across all PNG previews.
 * 3. When preparing assets for a mobile app, you may want to reduce sharp edges in SVG logos by applying a convolution blur and exporting them as PNGs for faster rendering.
 * 4. When creating background images for UI components, a developer can use Aspose.Imaging to blur an SVG pattern and output a PNG that blends smoothly with other elements.
 * 5. When performing batch image processing, this code lets you automate the conversion of multiple SVG files to blurred PNGs for use in print or digital marketing materials.
 */
