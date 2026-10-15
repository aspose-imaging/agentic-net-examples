// HOW-TO: Apply Gaussian Blur to BigTIFF and Save as PNG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.BigTiff;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\input.tif";
        string outputPath = "Output\\output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var bigTiff = (Aspose.Imaging.FileFormats.BigTiff.BigTiffImage)Aspose.Imaging.Image.Load(inputPath))
            {
                var raster = (Aspose.Imaging.RasterImage)bigTiff;

                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.5);
                raster.Filter(raster.Bounds, blurOptions);

                var pngOptions = new PngOptions();
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
 * 1. When you need to reduce noise in a large scientific BigTIFF image before sharing it as a lightweight PNG.
 * 2. When converting high‑resolution microscopy scans stored as BigTIFF to web‑friendly PNGs with a soft blur effect.
 * 3. When preparing archival satellite imagery in BigTIFF for presentation slides by applying Gaussian blur and exporting to PNG.
 * 4. When automating a workflow that processes massive TIFF files, adds a blur filter for privacy, and saves the result as PNG.
 * 5. When integrating Aspose.Imaging into a C# application to transform large medical imaging files into blurred PNG thumbnails.
 */
