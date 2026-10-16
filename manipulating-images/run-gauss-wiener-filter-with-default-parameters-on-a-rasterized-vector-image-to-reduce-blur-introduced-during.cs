// HOW-TO: Apply Gauss Wiener Filter to Rasterized SVG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
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
        string inputPath = "input.svg";
        string tempRasterPath = "temp/temp.png";
        string outputPath = "output/output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(tempRasterPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image vectorImage = Image.Load(inputPath))
            {
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions()
                };
                vectorImage.Save(tempRasterPath, pngOptions);
            }

            using (RasterImage rasterImage = (RasterImage)Image.Load(tempRasterPath))
            {
                rasterImage.Filter(rasterImage.Bounds, new GaussWienerFilterOptions());

                PngOptions outOptions = new PngOptions();
                rasterImage.Save(outputPath, outOptions);
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
 * 1. When you need to convert an SVG logo to a high‑quality PNG for web use and want to remove conversion blur with a Gauss‑Wiener filter in C#.
 * 2. When you generate raster thumbnails from vector graphics and require automatic de‑blurring to keep sharp edges using Aspose.Imaging.
 * 3. When a desktop application processes user‑uploaded SVG files and must output clean PNGs for printing, applying a default Gauss‑Wiener filter to improve clarity.
 * 4. When you batch‑process vector illustrations into PNG assets for a mobile app and need a simple C# solution that rasterizes and denoises the images in one workflow.
 * 5. When you integrate image preprocessing into a C# pipeline that reads SVG diagrams, rasterizes them, and applies a Gauss‑Wiener filter to reduce artifacts before further analysis.
 */
