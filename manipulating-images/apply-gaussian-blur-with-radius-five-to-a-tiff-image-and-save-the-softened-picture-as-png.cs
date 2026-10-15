// HOW-TO: Apply Gaussian Blur to TIFF and Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output\\softened.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 5);
                raster.Filter(raster.Bounds, blurOptions);

                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, pngOptions);
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
 * 1. When you need to soften high‑resolution scanned documents (TIFF) before publishing them as web‑friendly PNGs.
 * 2. When a medical imaging application must reduce noise in TIFF X‑ray images using a Gaussian blur before converting to PNG for reports.
 * 3. When an e‑commerce platform wants to apply a uniform blur effect to product photos stored as TIFF and deliver them as PNG thumbnails.
 * 4. When a batch‑processing script has to convert archival TIFF files to PNG while applying a radius‑5 Gaussian blur to improve visual aesthetics.
 * 5. When a document management system requires programmatic image preprocessing—blur and format change—from TIFF to PNG using C# and Aspose.Imaging.
 */
