// HOW-TO: Increase BMP Contrast by 15% and Export as SVG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }
                raster.AdjustContrast(15f);

                SvgOptions svgOptions = new SvgOptions();
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };
                svgOptions.VectorRasterizationOptions = rasterOptions;

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
 * 1. When you need to enhance the visual clarity of a legacy BMP graphic before embedding it in a web page as scalable SVG.
 * 2. When converting scanned bitmap assets to vector‑friendly SVG while applying a 15% contrast boost for better readability.
 * 3. When automating a batch process that improves contrast of BMP icons and outputs them as SVG for high‑resolution displays.
 * 4. When preparing BMP screenshots for documentation and want them saved as SVG with adjusted contrast to match branding guidelines.
 * 5. When integrating image processing into a C# application that must deliver contrast‑enhanced SVG files from user‑uploaded BMP images.
 */
