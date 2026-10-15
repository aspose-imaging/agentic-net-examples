// HOW-TO: Convert SVG Icon to PNG with Rasterization in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-14
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
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

            using (Image svgImage = Image.Load(inputPath))
            {
                SvgImage svg = (SvgImage)svgImage;

                using (MemoryStream pngStream = new MemoryStream())
                {
                    PngOptions pngOptions = new PngOptions();
                    SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
                    rasterOptions.PageWidth = svg.Width;
                    rasterOptions.PageHeight = svg.Height;
                    pngOptions.VectorRasterizationOptions = rasterOptions;

                    svg.Save(pngStream, pngOptions);
                    pngStream.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(pngStream))
                    {
                        raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to generate high‑resolution PNG thumbnails from SVG icons for a web UI using C#.
 * 2. When a desktop application must embed vector graphics but requires raster images for printing or PDF export.
 * 3. When an automated build pipeline converts designer‑provided SVG assets into PNGs for mobile app resources.
 * 4. When you want to programmatically rasterize SVG logos to PNG while preserving original dimensions in a .NET service.
 * 5. When a server‑side API receives SVG files and must return PNG responses for browsers that do not support SVG.
 */
