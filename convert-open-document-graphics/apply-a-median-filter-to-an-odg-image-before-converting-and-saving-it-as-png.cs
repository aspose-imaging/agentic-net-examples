// HOW-TO: Apply Median Filter to ODG Image and Convert to PNG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.odg";
            string outputPath = "Output/result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string tempPath = "Output/temp.png";
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

            using (Image odgImage = Image.Load(inputPath))
            {
                odgImage.Save(tempPath, new PngOptions());
            }

            using (RasterImage raster = (RasterImage)Image.Load(tempPath))
            {
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));
                raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to reduce speckle noise in an OpenDocument Graphic (ODG) before delivering a clean PNG for web publishing.
 * 2. When a document conversion pipeline must preserve visual quality by applying a median filter to vector‑based ODG files prior to rasterizing them as PNGs in a C# application.
 * 3. When an automated report generator processes ODG diagrams and requires a noise‑free PNG output for inclusion in PDFs or presentations.
 * 4. When a batch‑processing tool converts legacy ODG assets to PNG thumbnails and needs to smooth edges using a 3×3 median filter to improve thumbnail clarity.
 * 5. When integrating Aspose.Imaging into a C# service that receives ODG uploads, applies image denoising, and returns optimized PNG files for downstream image‑analysis algorithms.
 */
