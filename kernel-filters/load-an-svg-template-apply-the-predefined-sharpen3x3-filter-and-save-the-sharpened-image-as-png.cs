// HOW-TO: Sharpen SVG Image and Save as PNG Using Aspose.Imaging C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "template.svg";
            string outputPath = "output/sharpened.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image svgImage = Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var rasterOptions = new SvgRasterizationOptions
                    {
                        PageWidth = svgImage.Width,
                        PageHeight = svgImage.Height
                    };

                    var pngExportOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    svgImage.Save(ms, pngExportOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions());

                        var saveOptions = new PngOptions();
                        raster.Save(outputPath, saveOptions);
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
 * 1. When you need to convert a vector‑based SVG logo into a high‑resolution PNG thumbnail and enhance its edges for sharper web display.
 * 2. When an e‑commerce platform must generate product‑image previews from SVG designs and apply a sharpening filter to improve visual clarity on mobile devices.
 * 3. When a reporting tool creates SVG charts and you want to embed them as PNGs in PDF reports while boosting contrast with a 3×3 sharpen filter.
 * 4. When a content‑management system automatically processes user‑uploaded SVG illustrations, rasterizes them to PNG, and sharpens the result to meet print‑ready quality standards.
 * 5. When a batch‑processing script needs to read multiple SVG templates, apply a predefined Sharpen3x3 filter, and save the enhanced PNG files for downstream image‑analysis pipelines.
 */
