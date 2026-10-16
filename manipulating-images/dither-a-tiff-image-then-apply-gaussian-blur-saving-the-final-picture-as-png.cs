// HOW-TO: Dither TIFF, Apply Gaussian Blur, and Save As PNG In C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input\\image.tif";
        string outputPath = "output\\result.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                raster.Dither(DitheringMethod.FloydSteinbergDithering, 1);

                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0f);
                raster.Filter(raster.Bounds, blurOptions);

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
 * 1. When you need to convert a high‑contrast TIFF scan into a web‑friendly PNG with dithering to reduce file size while preserving visual detail.
 * 2. When you want to soften the edges of a dithered TIFF image using a Gaussian blur before publishing it online.
 * 3. When you are preparing legacy TIFF graphics for a mobile app and require both dithering and blur effects in a single C# workflow.
 * 4. When you must automate batch processing of TIFF files to produce PNG thumbnails with consistent blur and dithering for a digital archive.
 * 5. When you need to integrate Aspose.Imaging into a .NET service that receives TIFF uploads, applies visual enhancements, and returns PNG responses.
 */
