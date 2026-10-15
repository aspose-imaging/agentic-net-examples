// HOW-TO: Reduce Emboss Filter Intensity on SVG When Converting to PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var svgImage = (Aspose.Imaging.FileFormats.Svg.SvgImage)image;

                double[,] emboss5x5 = new double[,]
                {
                    { -0.5, -0.5, -0.5, -0.5, 0.0 },
                    { -0.5, -0.5, -0.5, 0.0, 0.5 },
                    { -0.5, -0.5, 0.0, 0.5, 0.5 },
                    { -0.5, 0.0, 0.5, 0.5, 0.5 },
                    { 0.0, 0.5, 0.5, 0.5, 0.5 }
                };

                var rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = svgImage.Width,
                    PageHeight = svgImage.Height
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                using (var ms = new MemoryStream())
                {
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(ms))
                    {
                        var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(emboss5x5);
                        raster.Filter(raster.Bounds, filterOptions);

                        var outPngOptions = new PngOptions();
                        raster.Save(outputPath, outPngOptions);
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
 * 1. When you need to convert an SVG diagram to a PNG thumbnail while applying a subtle emboss effect for a polished UI.
 * 2. When you want to rasterize vector graphics and control the emboss strength to avoid overly harsh shadows in a web report.
 * 3. When generating product catalog images from SVG logos and need a gentle 3‑D look without losing detail.
 * 4. When preprocessing SVG assets for a game UI and require a lightweight emboss filter that doesn’t dominate the artwork.
 * 5. When automating batch conversion of SVG icons to PNGs with a customized convolution kernel to match a brand’s soft emboss style.
 */
